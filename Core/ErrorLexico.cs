using System;

namespace C_Extended.Core
{
    /// <summary>
    /// Representa un error léxico detectado durante el análisis.
    /// CaracterInvalido contiene la secuencia completa que produjo el error.
    /// Línea y columna comienzan en 1 e indican el inicio de la secuencia.
    /// </summary>
    public sealed class ErrorLexico
    {
        /// <summary>Secuencia completa de caracteres inválidos o mal formados.</summary>
        public string CaracterInvalido { get; private set; }
        public int    Linea            { get; private set; }
        public int    Columna          { get; private set; }
        public string Descripcion      { get; private set; }

        public ErrorLexico(string caracterInvalido, int linea, int columna, string descripcion)
        {
            CaracterInvalido = caracterInvalido;
            Linea            = linea;
            Columna          = columna;
            Descripcion      = descripcion;
        }

        public override string ToString()
            => $"Error en {Linea}:{Columna} — {Descripcion} (\"{CaracterInvalido}\")";
    }
}

