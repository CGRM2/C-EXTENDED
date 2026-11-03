using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Extended.Core
{
    public sealed class ErrorSintactico
    {
        public string Encontrado { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }
        public string Descripcion { get; set; }
    }

    public sealed class DeclaracionSintactica
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Rol { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }
    }

    public sealed class AnalizadorSintactico
    {
        private List<Token> tokens;
        private int posicion;
        private int profundidad;
        private int ciclos;
        private int selecciones;
        private int funciones;
        private int limiteExpresion;
        private bool ultimaAccion;
        private int lineaFin;
        private int columnaFin;
        public List<ErrorSintactico> Errores { get; } = new List<ErrorSintactico>();
        public List<DeclaracionSintactica> Declaraciones { get; } = new List<DeclaracionSintactica>();
        public int TotalInstrucciones { get; private set; }
        private Token Actual => posicion < tokens.Count ? tokens[posicion] : new Token("fin de archivo", "EOF", lineaFin, columnaFin);
        private string Lexema => Actual.Lexema;
        private bool Fin => posicion >= tokens.Count;
        private bool EsTipo(string texto) => new[] { "var", "int", "float", "double", "char", "bool", "string", "void" }.Contains(texto);
        private bool Identificador => Actual.TipoToken == "TK_IDENTIFICADOR";
        private string Siguiente => posicion + 1 < tokens.Count ? tokens[posicion + 1].Lexema : "";

        public void Analizar(List<Token> entrada, string fuente)
        {
            tokens = (entrada ?? new List<Token>()).Where(t => !t.TipoToken.StartsWith("TK_COMENTARIO")).ToList();
            posicion = profundidad = ciclos = selecciones = funciones = limiteExpresion = TotalInstrucciones = 0;
            ultimaAccion = false;
            Errores.Clear();
            Declaraciones.Clear();
            string normalizado = (fuente ?? "").Replace("\r\n", "\n").Replace('\r', '\n');
            string[] lineas = normalizado.Split('\n');
            lineaFin = lineas.Length;
            columnaFin = lineas[lineas.Length - 1].Length + 1;
            while (!Fin && Errores.Count < 200)
            {
                int antes = posicion;
                Instruccion();
                if (posicion == antes) posicion++;
            }
            if (!Fin) Error("Se alcanzó el límite de 200 errores; corrige los primeros y vuelve a analizar.");
        }

        private void Error(string mensaje)
        {
            Errores.Add(new ErrorSintactico { Encontrado = Lexema, Linea = Actual.Linea,
                Columna = Actual.Columna, Descripcion = mensaje });
        }

        private bool Tomar(string texto)
        {
            if (Fin || Lexema != texto) return false;
            posicion++;
            return true;
        }

        private bool Esperar(string texto)
        {
            if (Tomar(texto)) return true;
            Error("Se esperaba '" + texto + "'; se encontró '" + Lexema + "'.");
            return false;
        }

        private Token Nombre(string rol, string tipo)
        {
            if (!Identificador) { Error("Se esperaba un identificador para " + rol + "."); return null; }
            Token nombre = Actual;
            posicion++;
            Declaraciones.Add(new DeclaracionSintactica { Nombre = nombre.Lexema, Tipo = tipo,
                Rol = rol, Linea = nombre.Linea, Columna = nombre.Columna });
            return nombre;
        }

        private void Instruccion()
        {
            if (++profundidad > 128)
            {
                Error("Anidamiento excesivo: máximo 128 niveles.");
                posicion = tokens.Count;
                profundidad--;
                return;
            }
            TotalInstrucciones++;
            try { LeerInstruccion(); }
            finally { profundidad--; }
        }

        private bool EsDeclaracion()
        {
            if (EsTipo(Lexema)) return true;
            if (!Identificador) return false;
            int siguiente = posicion + 1;
            while (siguiente + 1 < tokens.Count && tokens[siguiente].Lexema == "[" &&
                tokens[siguiente + 1].Lexema == "]") siguiente += 2;
            return siguiente < tokens.Count && tokens[siguiente].TipoToken == "TK_IDENTIFICADOR";
        }

        private void LeerInstruccion()
        {
            if (Tomar(";")) return;
            if (Lexema == "{") { Bloque(); return; }
            bool modificador = false;
            var modificadores = new HashSet<string>(StringComparer.Ordinal);
            while (Lexema == "public" || Lexema == "private" || Lexema == "static")
            {
                if (!modificadores.Add(Lexema)) Error("Modificador repetido: '" + Lexema + "'.");
                if ((Lexema == "public" && modificadores.Contains("private")) ||
                    (Lexema == "private" && modificadores.Contains("public")))
                    Error("No se permite combinar 'public' y 'private'.");
                posicion++; modificador = true;
            }
            if (Tomar("namespace"))
            {
                Nombre("espacio de nombres", "namespace");
                while (Tomar(".")) Nombre("espacio de nombres", "namespace");
                Bloque(); return;
            }
            if (Tomar("class")) { Nombre("clase", "class"); Bloque(); return; }
            if (Tomar("enum")) { Enumeracion(); return; }
            if (Tomar("using"))
            {
                Nombre("importación", "using");
                while (Tomar(".")) Nombre("importación", "using");
                Esperar(";"); return;
            }
            if (Tomar("func")) { Nombre("función", "func"); Funcion(); return; }
            if (EsDeclaracion())
            { Declaracion(true); return; }
            if (modificador) { Error("Se esperaba una declaración después del modificador."); return; }
            if (Tomar("if"))
            {
                Condicion(); Cuerpo();
                if (Tomar("else")) Cuerpo();
                return;
            }
            if (Tomar("while"))
            {
                Condicion(); ciclos++; Cuerpo(); ciclos--; return;
            }
            if (Tomar("for")) { Para(); return; }
            if (Tomar("switch")) { Seleccion(); return; }
            if (Tomar("return"))
            {
                if (funciones == 0) Error("'return' está fuera de una función.");
                if (Lexema != ";" && Lexema != "}" && !Fin) Expresion();
                Esperar(";"); return;
            }
            if (Lexema == "break" || Lexema == "continue")
            {
                bool continuar = Lexema == "continue";
                if (ciclos == 0 && (continuar || selecciones == 0))
                    Error("'" + Lexema + "' está fuera de " + (continuar ? "un ciclo." : "un ciclo o switch."));
                posicion++; Esperar(";"); return;
            }
            if (Lexema == "else" || Lexema == "case" || Lexema == "default" || Lexema == "}" || Lexema == ")" || Lexema == "]")
            { Error("'" + Lexema + "' no tiene una apertura o estructura correspondiente."); posicion++; return; }
            if (Actual.TipoToken == "TK_RESERVADA" && Lexema != "true" && Lexema != "false" && Lexema != "nil" && Lexema != "new")
            { Error("La palabra reservada '" + Lexema + "' no tiene una regla sintáctica en esta gramática."); Recuperar(); return; }
            Expresion();
            if (!ultimaAccion) Error("Se esperaba una asignación, llamada o incremento/decremento como instrucción.");
            Esperar(";");
        }

        private void Bloque()
        {
            if (!Esperar("{")) return;
            while (!Fin && Lexema != "}" && Errores.Count < 200)
            {
                int antes = posicion;
                Instruccion();
                if (antes == posicion) posicion++;
            }
            Esperar("}");
        }

        private void Cuerpo()
        {
            if (Fin || Lexema == "}" || Lexema == "else") { Error("Falta el cuerpo de la instrucción."); return; }
            Instruccion();
        }

        private void Condicion()
        { Esperar("("); Expresion(); Esperar(")"); }

        private void Declaracion(bool puntoComa)
        {
            string tipo = Lexema;
            posicion++;
            while (Tomar("[")) { Esperar("]"); tipo += "[]"; }
            if (tipo.StartsWith("void[")) Error("No se permiten arreglos de void.");
            Token nombre = Nombre("variable", tipo);
            if (nombre == null) { Recuperar(); return; }
            if (Lexema == "(")
            {
                Declaraciones[Declaraciones.Count - 1].Rol = "función";
                Funcion(); return;
            }
            if (tipo == "void" || tipo.StartsWith("void[")) Error("'void' solo puede usarse como retorno de una función.");
            if (Tomar("=")) Expresion();
            while (Tomar(","))
            { Nombre("variable", tipo); if (Tomar("=")) Expresion(); }
            if (puntoComa) Esperar(";");
        }

        private void Funcion()
        {
            Esperar("(");
            if (Lexema != ")")
            {
                do
                {
                    if (!EsTipo(Lexema) && !Identificador) { Error("Se esperaba el tipo del parámetro."); break; }
                    string tipo = Lexema;
                    if (tipo == "void") Error("Un parámetro no puede tener tipo 'void'.");
                    posicion++;
                    while (Tomar("[")) { Esperar("]"); tipo += "[]"; }
                    Nombre("parámetro", tipo);
                } while (Tomar(","));
            }
            Esperar(")");
            // Una función tiene su propio contexto de control de flujo.
            int ciclosExternos = ciclos, seleccionesExternas = selecciones;
            ciclos = selecciones = 0;
            funciones++;
            try { Bloque(); }
            finally { funciones--; ciclos = ciclosExternos; selecciones = seleccionesExternas; }
        }

        private void Enumeracion()
        {
            Nombre("enumeración", "enum");
            if (!Esperar("{")) return;
            if (Lexema != "}")
            {
                do
                {
                    if (Lexema == "}") break;
                    if (Nombre("miembro de enum", "enum") == null) { Recuperar(); break; }
                    if (Tomar("=")) Expresion(2);
                } while (Tomar(","));
            }
            Esperar("}"); Tomar(";");
        }

        private void Para()
        {
            Esperar("(");
            if (Lexema != ";")
            {
                if (EsDeclaracion()) Declaracion(false);
                else ListaExpresiones();
            }
            Esperar(";");
            if (Lexema != ";") Expresion();
            Esperar(";");
            if (Lexema != ")") ListaExpresiones();
            Esperar(")");
            ciclos++; Cuerpo(); ciclos--;
        }

        private void Seleccion()
        {
            Condicion();
            if (!Esperar("{")) return;
            selecciones++;
            bool defecto = false;
            bool etiqueta = false;
            while (!Fin && Lexema != "}" && Errores.Count < 200)
            {
                int antes = posicion;
                if (Tomar("case")) { etiqueta = true; Expresion(); Esperar(":"); }
                else if (Tomar("default"))
                {
                    if (defecto) Error("Solo se permite un 'default' en cada switch.");
                    defecto = etiqueta = true; Esperar(":");
                }
                else { if (!etiqueta) Error("Se esperaba 'case' o 'default'."); Instruccion(); }
                if (antes == posicion) posicion++;
            }
            selecciones--;
            Esperar("}");
        }

        private void ListaExpresiones()
        { Expresion(); while (Tomar(",")) Expresion(); }

        private int Prioridad(string texto)
        {
            switch (texto)
            {
                case "=": case "+=": case "-=": case "*=": case "/=": case "%=": return 1;
                case "||": return 2;
                case "&&": return 3;
                case "==": case "!=": return 4;
                case "<": case ">": case "<=": case ">=": return 5;
                case "+": case "-": return 6;
                case "*": case "/": case "%": return 7;
                default: return 0;
            }
        }

        private bool Expresion(int minimo = 1)
        {
            if (++limiteExpresion > 128)
            { Error("Expresión demasiado anidada: máximo 128 niveles."); posicion = tokens.Count; limiteExpresion--; return false; }
            try
            {
                bool asignable = Primaria();
                bool accion = ultimaAccion;
                while (!Fin && Prioridad(Lexema) >= minimo && Prioridad(Lexema) > 0)
                {
                    int prioridad = Prioridad(Lexema);
                    if (prioridad == 1 && !asignable) Error("El lado izquierdo de una asignación debe ser una variable, miembro o elemento de arreglo.");
                    posicion++;
                    Expresion(prioridad == 1 ? prioridad : prioridad + 1);
                    asignable = false;
                    accion = prioridad == 1;
                }
                ultimaAccion = accion;
                return asignable;
            }
            finally { limiteExpresion--; }
        }

        private bool Primaria()
        {
            bool asignable = false;
            bool accion = false;
            if (Lexema == "!" || Lexema == "+" || Lexema == "-" || Lexema == "++" || Lexema == "--")
            {
                string operador = Lexema;
                posicion++;
                bool destino = Expresion(8);
                if ((operador == "++" || operador == "--") && !destino)
                    Error("El incremento o decremento necesita una variable, miembro o elemento de arreglo.");
                ultimaAccion = operador == "++" || operador == "--";
                return false;
            }
            if (Tomar("(")) { asignable = Expresion(); Esperar(")"); }
            else if (Tomar("new"))
            {
                accion = true;
                if (!Identificador && !EsTipo(Lexema)) { Error("Se esperaba un tipo después de 'new'."); return false; }
                if (Lexema == "void" || Lexema == "var")
                    Error("No se puede construir un valor de tipo '" + Lexema + "'.");
                posicion++;
                if (Tomar("(")) { if (Lexema != ")") ListaExpresiones(); Esperar(")"); }
                else if (Tomar("[")) { Expresion(); Esperar("]"); }
                else Error("Se esperaba '(' o '[' después del tipo.");
            }
            else if (Identificador || Actual.TipoToken == "TK_NUM_ENTERO" || Actual.TipoToken == "TK_NUM_DECIMAL" ||
                Actual.TipoToken == "TK_CADENA" || Actual.TipoToken == "TK_CARACTER" || Lexema == "true" || Lexema == "false" || Lexema == "nil")
            { asignable = Identificador; posicion++; }
            else
            {
                Error("Se esperaba una expresión; se encontró '" + Lexema + "'.");
                if (!Fin && !new[] { ";", ")", "]", "}", ",", ":", "{" }.Contains(Lexema)) posicion++;
                ultimaAccion = false;
                return false;
            }
            while (!Fin)
            {
                if (Tomar(".")) { if (!Identificador) { Error("Se esperaba un miembro después de '.'."); break; } posicion++; asignable = true; accion = false; }
                else if (Tomar("(")) { if (Lexema != ")") ListaExpresiones(); Esperar(")"); asignable = false; accion = true; }
                else if (Tomar("[")) { Expresion(); Esperar("]"); asignable = true; accion = false; }
                else if (Tomar("++") || Tomar("--"))
                {
                    if (!asignable) Error("El incremento o decremento necesita una variable, miembro o elemento de arreglo.");
                    asignable = false;
                    accion = true;
                    break;
                }
                else break;
            }
            ultimaAccion = accion;
            return asignable;
        }

        private void Recuperar()
        {
            int linea = Actual.Linea;
            while (!Fin && Lexema != ";" && Lexema != "}" && Actual.Linea == linea) posicion++;
            Tomar(";");
        }
    }
}
