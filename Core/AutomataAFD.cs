using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace C_Extended.Core
{
    /// <summary>
    /// Alfabeto y predicados auxiliares del reconocedor manual.
    /// No usa Regex. Define qué caracteres pertenecen a cada clase.
    ///
    /// Alfabeto (ASCII + letras Unicode):
    ///   L  = letra Unicode (char.IsLetter) o guion bajo '_'
    ///   D  = dígito ASCII 0–9 (char.IsDigit en subconjunto ASCII)
    ///   L|D|_ = conjunto de continuación de identificador
    ///
    /// Reservadas definitivas de C-extended (30 palabras):
    ///   Conjunto original (E1): namespace class enum func var nil
    ///                           if else for while return break continue
    ///   Ampliadas (E3):         int float double char bool string void
    ///                           static true false switch case default
    ///                           public private using new
    ///
    /// Escapes válidos dentro de cadenas y caracteres literales:
    ///   \n  \t  \r  \0  \\  \"  \'
    /// </summary>
    public sealed class EntradaDiccionario
    {
        public string Palabra { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }

    public static class AutomataAFD
    {
        // HashSet para búsqueda O(1); comparación ordinal (case-sensitive).
        private static readonly HashSet<string> Reservadas = new HashSet<string>(
            new[]
            {
                // Conjunto original — Entregable 1
                "namespace", "class", "enum", "func", "var", "nil",
                "if", "else", "for", "while", "return", "break", "continue",
                // Ampliadas — Entregable 3
                "int", "float", "double", "char", "bool", "string", "void",
                "static", "true", "false", "switch", "case", "default",
                "public", "private", "using", "new"
            },
            StringComparer.Ordinal);

        // ----------------------------------------------------------------
        // Predicados de alfabeto
        // ----------------------------------------------------------------

        /// <summary>
        /// Estado inicial de identificador: letra Unicode o guion bajo.
        /// Se admiten letras de cualquier escritura para permitir identificadores
        /// en español (é, ñ, etc.) que son comunes en código de ejemplo.
        /// </summary>
        public static bool EsInicioIdentificador(char c)
            => char.IsLetter(c) || c == '_';

        /// <summary>
        /// Continuación de identificador: letra, dígito o guion bajo.
        /// </summary>
        public static bool EsParteIdentificador(char c)
             => EsInicioIdentificador(c) || EsDigito(c);

        /// <summary>Devuelve true si el lexema completo es una palabra reservada.</summary>
        public static bool EsReservada(string lexema)
            => ObtenerTipo(lexema) == "TK_RESERVADA";

        /// <summary>
        /// Escapes válidos tras una barra invertida dentro de cadena o carácter.
        /// Los siete escapes de la especificación: n t r 0 \ " '
        /// </summary>
        public static bool EsEscapeValido(char c)
            => c == 'n' || c == 't' || c == 'r' || c == '0' ||
               c == '\\' || c == '"' || c == '\'';

        /// <summary>
        /// Reconoce exclusivamente dígitos ASCII del 0 al 9.
        /// </summary>
        private static readonly string RutaDiccionario = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "C-Extended", "diccionario.xml");
        private static List<EntradaDiccionario> entradas;

        public static List<EntradaDiccionario> ObtenerDiccionario()
        {
            if (entradas == null)
            {
                if (File.Exists(RutaDiccionario))
                    entradas = XDocument.Load(RutaDiccionario).Root.Elements("Palabra")
                        .Select(x => new EntradaDiccionario {
                            Palabra = (string)x.Attribute("nombre"),
                            Tipo = (string)x.Attribute("tipo"),
                            Descripcion = (string)x.Attribute("descripcion") ?? ""
                        }).ToList();
                else
                    entradas = Reservadas.OrderBy(x => x).Select(x => new EntradaDiccionario {
                        Palabra = x, Tipo = "TK_RESERVADA", Descripcion = "Palabra reservada de C-Extended"
                    }).ToList();
            }
            return entradas.Select(x => new EntradaDiccionario {
                Palabra = x.Palabra, Tipo = x.Tipo, Descripcion = x.Descripcion
            }).ToList();
        }

        public static string ObtenerTipo(string palabra)
        {
            var entrada = ObtenerDiccionario().Find(x => x.Palabra == palabra);
            return entrada == null ? "TK_IDENTIFICADOR" : entrada.Tipo;
        }

        public static void GuardarEntrada(string original, string palabra, string tipo, string descripcion)
        {
            palabra = (palabra ?? "").Trim();
            if (palabra.Length == 0 || !EsInicioIdentificador(palabra[0]) ||
                palabra.Any(c => !EsParteIdentificador(c)))
                throw new ArgumentException("Escribe una palabra válida: letra o guion bajo al inicio, sin espacios.");
            if (tipo != "TK_RESERVADA" && tipo != "TK_IDENTIFICADOR")
                throw new ArgumentException("Selecciona un tipo válido.");
            var lista = ObtenerDiccionario();
            if (lista.Any(x => x.Palabra == palabra && x.Palabra != original))
                throw new ArgumentException("La palabra ya existe en el diccionario.");
            if (original != null) lista.RemoveAll(x => x.Palabra == original);
            lista.Add(new EntradaDiccionario { Palabra = palabra, Tipo = tipo, Descripcion = descripcion ?? "" });
            GuardarDiccionario(lista);
        }

        public static void EliminarEntrada(string palabra)
        {
            var lista = ObtenerDiccionario();
            lista.RemoveAll(x => x.Palabra == palabra);
            GuardarDiccionario(lista);
        }

        private static void GuardarDiccionario(List<EntradaDiccionario> lista)
        {
            var documento = new XDocument(new XElement("Diccionario", lista.OrderBy(x => x.Palabra)
                .Select(x => new XElement("Palabra", new XAttribute("nombre", x.Palabra),
                    new XAttribute("tipo", x.Tipo), new XAttribute("descripcion", x.Descripcion)))));
            Directory.CreateDirectory(Path.GetDirectoryName(RutaDiccionario));
            string temporal = RutaDiccionario + ".tmp";
            documento.Save(temporal);
            File.Copy(temporal, RutaDiccionario, true);
            File.Delete(temporal);
            entradas = lista;
        }
        public static bool EsDigito(char c)
            => c >= '0' && c <= '9';
    }
}


