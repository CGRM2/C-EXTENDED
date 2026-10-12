using System;

namespace C_Extended.Core
{
    /// <summary>
    /// Representa un token reconocido por el analizador léxico de C-extended.
    /// Línea y columna comienzan en 1.
    /// </summary>
    public sealed class Token
    {
        public string Lexema       { get; private set; }
        public string TipoToken    { get; private set; }
        public int    Linea        { get; private set; }
        public int    Columna      { get; private set; }

        public Token(string lexema, string tipoToken, int linea, int columna)
        {
            Lexema    = lexema;
            TipoToken = tipoToken;
            Linea     = linea;
            Columna   = columna;
        }

        public override string ToString()
            => $"[{TipoToken}] \"{Lexema}\" @ {Linea}:{Columna}";
    }
}

