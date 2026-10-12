using System;
using System.Collections.Generic;
using System.IO;

namespace C_Extended.Core
{
    /// <summary>
    /// Recorre el código fuente una sola vez, carácter a carácter.
    /// Cada rama implementa transiciones de un reconocedor manual (sin Regex).
    ///
    /// Convenciones:
    ///   - Línea y columna comienzan en 1.
    ///   - CRLF cuenta como un solo salto de línea.
    ///   - Cada llamada a Analizar() reinicia tokens, errores y símbolos.
    ///   - Los comentarios reconocidos aparecen en la lista de tokens.
    ///   - Se aplica máximo avance: comentarios tienen prioridad sobre división;
    ///     operadores de dos caracteres tienen prioridad sobre los de uno.
    ///   - Una cadena o carácter literal sin cerrar genera error hasta fin de línea
    ///     y el análisis continúa en la siguiente.
    ///   - Un comentario de bloque sin cerrar consume hasta EOF y genera un error.
    ///   - TotalLineas es la línea en la que se detuvo el cursor al terminar el análisis.
    /// </summary>
    public sealed class AnalizadorLexico
    {
        // ----------------------------------------------------------------
        // Estado interno del cursor
        // ----------------------------------------------------------------
        private string codigoFuente = "";
        private int    indiceActual;
        private int    lineaActual;
        private int    columnaActual;

        private readonly List<Token>       listaTokens  = new List<Token>();
        private readonly List<ErrorLexico> listaErrores = new List<ErrorLexico>();
        private          TablaDeSimbolos   tablaSimbolos = new TablaDeSimbolos();

        /// <summary>
        /// Línea donde se detuvo el cursor al finalizar el análisis.
        /// Incluye líneas vacías y la convención de salto final.
        /// </summary>
        public int TotalLineas => lineaActual;

        // ----------------------------------------------------------------
        // Puntos de entrada públicos
        // ----------------------------------------------------------------

        /// <summary>Lee el archivo, detecta BOM y analiza su contenido.</summary>
        public void AnalizarArchivo(string ruta)
            => Analizar(File.ReadAllText(ruta, System.Text.Encoding.UTF8));

        /// <summary>Analiza la cadena de código proporcionada.</summary>
        public void Analizar(string codigo)
        {
            codigoFuente  = codigo ?? "";
            indiceActual  = 0;
            lineaActual   = 1;
            columnaActual = 1;
            listaTokens.Clear();
            listaErrores.Clear();
            tablaSimbolos = new TablaDeSimbolos();

            while (!Fin)
            {
                char actual = Actual;

                if (char.IsWhiteSpace(actual))
                {
                    Avanzar();
                }
                else if (AutomataAFD.EsInicioIdentificador(actual))
                {
                    LeerIdentificador();
                }
                else if (char.IsDigit(actual))
                {
                    LeerNumero();
                }
                else if (actual == '"')
                {
                    LeerCadena();
                }
                else if (actual == '\'')
                {
                    LeerCaracterLiteral();
                }
                // Prioridad: comentario sobre división
                else if (actual == '/' && Siguiente == '/')
                {
                    LeerComentarioLinea();
                }
                else if (actual == '/' && Siguiente == '*')
                {
                    LeerComentarioBloque();
                }
                else
                {
                    LeerOperadorODelimitador();
                }
            }
        }

        // ----------------------------------------------------------------
        // Getters de resultado (devuelven copias defensivas)
        // ----------------------------------------------------------------

        public List<Token>       ObtenerTokens()   => new List<Token>(listaTokens);
        public List<ErrorLexico> ObtenerErrores()  => new List<ErrorLexico>(listaErrores);
        public List<Simbolo>     ObtenerSimbolos() => tablaSimbolos.ObtenerSimbolos();

        // ----------------------------------------------------------------
        // Propiedades de cursor
        // ----------------------------------------------------------------

        private bool Fin      => indiceActual >= codigoFuente.Length;
        private char Actual   => Fin ? '\0' : codigoFuente[indiceActual];
        private char Siguiente
            => indiceActual + 1 < codigoFuente.Length
               ? codigoFuente[indiceActual + 1]
               : '\0';

        // ----------------------------------------------------------------
        // Avanzar: CRLF cuenta como un solo salto
        // ----------------------------------------------------------------
        private void Avanzar()
        {
            if (Fin) return;
            char c = codigoFuente[indiceActual++];
            if (c == '\r')
            {
                if (!Fin && codigoFuente[indiceActual] == '\n') indiceActual++;
                lineaActual++;
                columnaActual = 1;
            }
            else if (c == '\n')
            {
                lineaActual++;
                columnaActual = 1;
            }
            else
            {
                columnaActual++;
            }
        }

        // ----------------------------------------------------------------
        // Helpers para construir tokens y errores
        // ----------------------------------------------------------------
        private string LexemaDesde(int inicio)
            => codigoFuente.Substring(inicio, indiceActual - inicio);

        private void TokenDesde(int inicio, int linea, int columna, string tipo)
            => listaTokens.Add(new Token(LexemaDesde(inicio), tipo, linea, columna));

        private void ErrorDesde(int inicio, int linea, int columna, string descripcion)
            => listaErrores.Add(new ErrorLexico(LexemaDesde(inicio), linea, columna, descripcion));

        // ----------------------------------------------------------------
        // Reconocedor de identificadores y palabras reservadas
        // Estado S1: (L|_)(L|D|_)*
        // ----------------------------------------------------------------
        private void LeerIdentificador()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            do { Avanzar(); }
            while (!Fin && AutomataAFD.EsParteIdentificador(Actual));

            string lexema = LexemaDesde(inicio);
            if (AutomataAFD.EsReservada(lexema))
                TokenDesde(inicio, linea, columna, "TK_RESERVADA");
            else
            {
                TokenDesde(inicio, linea, columna, "TK_IDENTIFICADOR");
                tablaSimbolos.AgregarSimbolo(lexema, linea, columna);
            }
        }

        // ----------------------------------------------------------------
        // Reconocedor de números
        // S2: D+
        // S3: D+ '.' requiere D (→ S4) o es error
        // S4: D+ '.' D+
        // Recuperación: consume todo el token inválido como un solo error.
        // ----------------------------------------------------------------
        private void LeerNumero()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;

            // Consumir dígitos enteros (S2)
            while (!Fin && char.IsDigit(Actual)) Avanzar();

            bool decimalValido = false;

            // ¿Hay un punto?
            if (!Fin && Actual == '.')
            {
                Avanzar(); // consume el punto

                if (Fin || !char.IsDigit(Actual))
                {
                    // Punto sin dígito después → número mal formado.
                    // Consumir puntos y dígitos adicionales para evitar cascada.
                    while (!Fin && (Actual == '.' || char.IsDigit(Actual))) Avanzar();
                    ErrorDesde(inicio, linea, columna,
                        "Número decimal mal formado: falta un dígito después del punto");
                    return;
                }

                // S4: dígitos decimales
                decimalValido = true;
                while (!Fin && char.IsDigit(Actual)) Avanzar();
            }

            // Detectar continuación inválida: punto adicional o inicio de identificador
            if (!Fin && (Actual == '.' || AutomataAFD.EsInicioIdentificador(Actual)))
            {
                // Consumir toda la secuencia inválida
                while (!Fin && (char.IsDigit(Actual) || Actual == '.' ||
                                AutomataAFD.EsInicioIdentificador(Actual))) Avanzar();
                ErrorDesde(inicio, linea, columna,
                    decimalValido || LexemaDesde(inicio).Contains(".")
                        ? "Número decimal mal formado"
                        : "Identificador con inicio numérico");
                return;
            }

            TokenDesde(inicio, linea, columna,
                decimalValido ? "TK_NUM_DECIMAL" : "TK_NUM_ENTERO");
        }

        // ----------------------------------------------------------------
        // Reconocedor de cadenas de texto: " contenido "
        // Escapes válidos: \n \t \r \0 \\ \" \'
        // Sin cerrar → error hasta fin de línea, continúa en siguiente.
        // ----------------------------------------------------------------
        private void LeerCadena()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            bool escapeInvalido = false;
            Avanzar(); // comilla inicial

            while (!Fin && Actual != '\r' && Actual != '\n')
            {
                if (Actual == '"')
                {
                    Avanzar(); // comilla de cierre
                    if (escapeInvalido)
                        ErrorDesde(inicio, linea, columna, "Secuencia de escape no válida en cadena");
                    else
                        TokenDesde(inicio, linea, columna, "TK_CADENA");
                    return;
                }
                if (Actual == '\\')
                {
                    Avanzar(); // barra
                    if (Fin || Actual == '\r' || Actual == '\n') break;
                    if (!AutomataAFD.EsEscapeValido(Actual)) escapeInvalido = true;
                    Avanzar(); // carácter de escape
                }
                else
                {
                    Avanzar();
                }
            }
            ErrorDesde(inicio, linea, columna, "Cadena de texto sin cerrar");
        }

        // ----------------------------------------------------------------
        // Reconocedor de caracteres literales: ' u '
        // Debe contener exactamente una unidad o un escape válido.
        // ----------------------------------------------------------------
        private void LeerCaracterLiteral()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            bool escapeInvalido = false;
            int  caracteres     = 0;
            Avanzar(); // comilla inicial

            while (!Fin && Actual != '\r' && Actual != '\n')
            {
                if (Actual == '\'')
                {
                    Avanzar(); // comilla de cierre
                    if (escapeInvalido)
                        ErrorDesde(inicio, linea, columna, "Secuencia de escape no válida en carácter literal");
                    else if (caracteres != 1)
                        ErrorDesde(inicio, linea, columna,
                            "Un carácter literal debe contener exactamente un carácter");
                    else
                        TokenDesde(inicio, linea, columna, "TK_CARACTER");
                    return;
                }
                if (Actual == '\\')
                {
                    Avanzar(); // barra
                    if (Fin || Actual == '\r' || Actual == '\n') break;
                    if (!AutomataAFD.EsEscapeValido(Actual)) escapeInvalido = true;
                    Avanzar(); // carácter de escape
                }
                else
                {
                    Avanzar();
                }
                caracteres++;
            }
            ErrorDesde(inicio, linea, columna, "Carácter literal sin cerrar");
        }

        // ----------------------------------------------------------------
        // Comentario de línea: // ... hasta fin de línea
        // ----------------------------------------------------------------
        private void LeerComentarioLinea()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            Avanzar(); Avanzar(); // //
            while (!Fin && Actual != '\r' && Actual != '\n') Avanzar();
            TokenDesde(inicio, linea, columna, "TK_COMENTARIO_LINEA");
        }

        // ----------------------------------------------------------------
        // Comentario de bloque: /* ... */ (no anidado; cierra en el primer */)
        // Sin cerrar → consume hasta EOF y genera error.
        // ----------------------------------------------------------------
        private void LeerComentarioBloque()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            Avanzar(); Avanzar(); // /*
            while (!Fin)
            {
                if (Actual == '*' && Siguiente == '/')
                {
                    Avanzar(); Avanzar(); // */
                    TokenDesde(inicio, linea, columna, "TK_COMENTARIO_BLOQUE");
                    return;
                }
                Avanzar();
            }
            ErrorDesde(inicio, linea, columna, "Comentario multilínea sin cerrar");
        }

        // ----------------------------------------------------------------
        // Operadores y delimitadores
        // Se prueba primero el operador de dos caracteres (máximo avance).
        // Prioridades documentadas:
        //   ++  +=   --  -=   *=  /=  %=   ==  !=  <=  >=   &&  ||
        //   +   -    *   /    %                   <   >   =   !
        //   (   )    {   }    [   ]   ;   ,   .   :
        // ----------------------------------------------------------------
        private void LeerOperadorODelimitador()
        {
            int    inicio   = indiceActual;
            int    linea    = lineaActual;
            int    columna  = columnaActual;
            char   c        = Actual;
            char   sig      = Siguiente;
            string tipo     = null;

            // Operadores y asignaciones de dos caracteres
            if ((c == '+' && (sig == '+' || sig == '=')) ||
                (c == '-' && (sig == '-' || sig == '=')) ||
                ((c == '*' || c == '/' || c == '%') && sig == '=') ||
                ((c == '=' || c == '!' || c == '<' || c == '>') && sig == '=') ||
                (c == '&' && sig == '&') ||
                (c == '|' && sig == '|'))
            {
                Avanzar(); Avanzar();
                if (sig == '=' && (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '='))
                    tipo = c == '=' ? "TK_OP_RELACIONAL" : "TK_OP_ASIGNACION";
                else if (c == '&' || c == '|')
                    tipo = "TK_OP_LOGICO";
                else if (c == '!' || c == '<' || c == '>')
                    tipo = "TK_OP_RELACIONAL";
                else
                    tipo = "TK_OP_ARITMETICO"; // ++ --
            }
            else
            {
                Avanzar();
                switch (c)
                {
                    case '+': case '-': case '*': case '/': case '%':
                        tipo = "TK_OP_ARITMETICO";  break;
                    case '<': case '>':
                        tipo = "TK_OP_RELACIONAL";  break;
                    case '=':
                        tipo = "TK_OP_ASIGNACION";  break;
                    case '!':
                        tipo = "TK_OP_LOGICO";       break;
                    case '(': case ')': case '{': case '}':
                    case '[': case ']': case ';':  case ',':
                    case '.': case ':':
                        tipo = "TK_DELIMITADOR";    break;
                }
            }

            if (tipo == null)
                ErrorDesde(inicio, linea, columna, "Carácter no permitido");
            else
                TokenDesde(inicio, linea, columna, tipo);
        }
    }
}

