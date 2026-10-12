using System;
using System.Collections.Generic;

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
            => EsInicioIdentificador(c) || char.IsDigit(c);

        /// <summary>Devuelve true si el lexema completo es una palabra reservada.</summary>
        public static bool EsReservada(string lexema)
            => Reservadas.Contains(lexema);

        /// <summary>
        /// Escapes válidos tras una barra invertida dentro de cadena o carácter.
        /// Los siete escapes de la especificación: n t r 0 \ " '
        /// </summary>
        public static bool EsEscapeValido(char c)
            => c == 'n' || c == 't' || c == 'r' || c == '0' ||
               c == '\\' || c == '"' || c == '\'';
    }
}

