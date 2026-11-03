using System;
using System.Collections.Generic;
using System.IO;

namespace C_Extended.Core
{
    /// <summary>
    /// Recorre el codigo fuente una sola vez, caracter a caracter.
    /// Cada rama implementa transiciones de un reconocedor manual (sin Regex).
    ///
    /// Convenciones:
    ///   - Linea y columna comienzan en 1.
    ///   - CRLF cuenta como un solo salto de linea.
    ///   - Cada llamada a Analizar() reinicia tokens, errores y simbolos.
    ///   - Los comentarios reconocidos aparecen en la lista de tokens.
    ///   - Se aplica maximo avance: comentarios tienen prioridad sobre division;
    ///     operadores de dos caracteres tienen prioridad sobre los de uno.
    ///   - Una cadena o caracter literal sin cerrar genera error hasta fin de linea
    ///     y el analisis continua en la siguiente.
    ///   - Un comentario de bloque sin cerrar consume hasta EOF y genera un error.
    ///   - TotalLineas es la linea en la que se detuvo el cursor al terminar el analisis.
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
        /// Linea donde se detuvo el cursor al finalizar el analisis.
        /// Incluye lineas vacias y la convencion de salto final.
        /// </summary>
        public int TotalLineas => lineaActual;

        // ----------------------------------------------------------------
        // Puntos de entrada publicos
        // ----------------------------------------------------------------

        /// <summary>Lee el archivo, detecta BOM y analiza su contenido.</summary>
        public void AnalizarArchivo(string ruta)
            => Analizar(File.ReadAllText(ruta, System.Text.Encoding.UTF8));

        /// <summary>Analiza la cadena de codigo proporcionada.</summary>
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
                else if (AutomataAFD.EsDigito(actual))
                {
                    LeerNumero();
                }
                else if (actual == '.' && AutomataAFD.EsDigito(Siguiente))
                {
                    int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
                    Avanzar();
                    while (!Fin && (AutomataAFD.EsParteIdentificador(Actual) || Actual == '.')) Avanzar();
                    ErrorDesde(inicio, linea, columna,
                        "Numero decimal mal formado: falta un digito antes del punto");
                }
                else if (actual == '*' && Siguiente == '/')
                {
                    int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
                    Avanzar(); Avanzar();
                    ErrorDesde(inicio, linea, columna, "Cierre de comentario sin apertura /*");
                }
                else if (actual == '"')
                {
                    LeerCadena();
                }
                else if (actual == '\'')
                {
                    LeerCaracterLiteral();
                }
                // Prioridad: comentario sobre division
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
        // Reconocedor de numeros
        // S2: D+
        // S3: D+ '.' requiere D (-> S4) o es error
        // S4: D+ '.' D+
        // Recuperacion: consume todo el token invalido como un solo error.
        // ----------------------------------------------------------------
        private void LeerNumero()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;

            // Consumir digitos enteros (S2)
            while (!Fin && AutomataAFD.EsDigito(Actual)) Avanzar();

            bool decimalValido = false;

            // Hay un punto?
            if (!Fin && Actual == '.')
            {
                Avanzar(); // consume el punto

                if (Fin || !AutomataAFD.EsDigito(Actual))
                {
                    // Consumir la secuencia invalida completa, incluidas letras
                    // y guiones bajos, sin consumir el separador posterior.
                    while (!Fin && (Actual == '.' ||
                                    AutomataAFD.EsParteIdentificador(Actual)))
                    {
                        Avanzar();
                    }

                    ErrorDesde(inicio, linea, columna,
                        "Numero decimal mal formado: falta un digito despues del punto");
                    return;
                }

                // S4: digitos decimales
                decimalValido = true;
                while (!Fin && AutomataAFD.EsDigito(Actual)) Avanzar();
            }

            // Detectar continuacion invalida: punto adicional o inicio de identificador
            if (!Fin && (Actual == '.' || AutomataAFD.EsInicioIdentificador(Actual)))
            {
                // Consumir toda la secuencia invalida
                while (!Fin && (AutomataAFD.EsDigito(Actual) || Actual == '.' ||
                                AutomataAFD.EsInicioIdentificador(Actual))) Avanzar();
                ErrorDesde(inicio, linea, columna,
                    decimalValido || LexemaDesde(inicio).Contains(".")
                        ? "Numero decimal mal formado"
                        : "Identificador con inicio numerico");
                return;
            }

            TokenDesde(inicio, linea, columna,
                decimalValido ? "TK_NUM_DECIMAL" : "TK_NUM_ENTERO");
        }

        // ----------------------------------------------------------------
        // Reconocedor de cadenas de texto: " contenido "
        // Escapes validos: \n \t \r \0 \\ \" \'
        // Sin cerrar -> error hasta fin de linea, continua en siguiente.
        // ----------------------------------------------------------------
        private void LeerCadena()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            bool escapeInvalido = false;
            bool controlInvalido = false;
            Avanzar(); // comilla inicial

            while (!Fin && Actual != '\r' && Actual != '\n')
            {
                if (Actual == '"')
                {
                    Avanzar(); // comilla de cierre
                    if (controlInvalido)
                        ErrorDesde(inicio, linea, columna, "Caracter de control no permitido en literal; utiliza una secuencia de escape");
                    else if (escapeInvalido)
                        ErrorDesde(inicio, linea, columna, "Secuencia de escape no valida en cadena");
                    else
                        TokenDesde(inicio, linea, columna, "TK_CADENA");
                    return;
                }
                if (Actual == '\\')
                {
                    Avanzar(); // barra
                    if (Fin || Actual == '\r' || Actual == '\n') break;
                    if (!AutomataAFD.EsEscapeValido(Actual)) escapeInvalido = true;
                    Avanzar(); // caracter de escape
                }
                else
                {
                    if (char.IsControl(Actual) && Actual != '\t') controlInvalido = true;
                    Avanzar();
                }
            }
            ErrorDesde(inicio, linea, columna, "Cadena de texto sin cerrar");
        }

        // ----------------------------------------------------------------
        // Reconocedor de caracteres literales: ' u '
        // Debe contener exactamente una unidad o un escape valido.
        // ----------------------------------------------------------------
        private void LeerCaracterLiteral()
        {
            int inicio = indiceActual, linea = lineaActual, columna = columnaActual;
            bool escapeInvalido = false;
            bool controlInvalido = false;
            int  caracteres     = 0;
            Avanzar(); // comilla inicial

            while (!Fin && Actual != '\r' && Actual != '\n')
            {
                if (Actual == '\'')
                {
                    Avanzar(); // comilla de cierre
                    if (controlInvalido)
                        ErrorDesde(inicio, linea, columna, "Caracter de control no permitido en literal; utiliza una secuencia de escape");
                    else if (escapeInvalido)
                        ErrorDesde(inicio, linea, columna, "Secuencia de escape no valida en caracter literal");
                    else if (caracteres != 1)
                        ErrorDesde(inicio, linea, columna,
                            "Un caracter literal debe contener exactamente un caracter");
                    else
                        TokenDesde(inicio, linea, columna, "TK_CARACTER");
                    return;
                }
                if (Actual == '\\')
                {
                    Avanzar(); // barra
                    if (Fin || Actual == '\r' || Actual == '\n') break;
                    if (!AutomataAFD.EsEscapeValido(Actual)) escapeInvalido = true;
                    Avanzar(); // caracter de escape
                }
                else
                {
                    if (char.IsControl(Actual) && Actual != '\t') controlInvalido = true;
                    Avanzar();
                }
                caracteres++;
            }
            ErrorDesde(inicio, linea, columna, "Caracter literal sin cerrar");
        }

        // ----------------------------------------------------------------
        // Comentario de linea: // ... hasta fin de linea
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
        // Sin cerrar -> consume hasta EOF y genera error.
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
            ErrorDesde(inicio, linea, columna, "Comentario multilinea sin cerrar");
        }

        // ----------------------------------------------------------------
        // Operadores y delimitadores
        // Se prueba primero el operador de dos caracteres (maximo avance).
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
            {
                string descripcion;
                switch (c)
                {
                    case '&': descripcion = "Operador logico incompleto: utiliza &&"; break;
                    case '|': descripcion = "Operador logico incompleto: utiliza ||"; break;
                    case '\\': descripcion = "Barra invertida fuera de una cadena o caracter literal"; break;
                    case '\u201c': case '\u201d': case '\u2018': case '\u2019':
                        descripcion = "Comilla tipografica no permitida: utiliza comillas rectas"; break;
                    default:
                        descripcion = char.IsControl(c)
                            ? "Caracter de control no permitido (U+" + ((int)c).ToString("X4") + ")"
                            : "Caracter no permitido";
                        break;
                }
                ErrorDesde(inicio, linea, columna, descripcion);
            }
            else
                TokenDesde(inicio, linea, columna, tipo);
        }
    }
}

