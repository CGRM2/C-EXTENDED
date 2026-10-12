using System;
using System.Collections.Generic;

namespace C_Extended.Core
{
    /// <summary>
    /// Entrada de la tabla de símbolos. TipoToken es la categoría léxica
    /// (siempre TK_IDENTIFICADOR), no el tipo semántico de la variable.
    /// La primera ubicación no cambia por apariciones posteriores.
    /// </summary>
    public sealed class Simbolo
    {
        public string NombreIdentificador   { get; private set; }
        public string TipoToken             { get; private set; }
        public int    LineaPrimeraAparicion { get; private set; }
        public int    ColumnaInicio         { get; private set; }

        public Simbolo(string nombre, int linea, int columna)
        {
            NombreIdentificador   = nombre;
            TipoToken             = "TK_IDENTIFICADOR";
            LineaPrimeraAparicion = linea;
            ColumnaInicio         = columna;
        }
    }

    /// <summary>
    /// Diccionario de identificadores únicos con orden de aparición.
    /// La comparación es sensible a mayúsculas y minúsculas (Ordinal).
    /// </summary>
    public sealed class TablaDeSimbolos
    {
        private readonly Dictionary<string, Simbolo> tabla =
            new Dictionary<string, Simbolo>(StringComparer.Ordinal);

        private readonly List<Simbolo> ordenAparicion = new List<Simbolo>();

        /// <summary>
        /// Registra un identificador solo si no existe ya en la tabla.
        /// Conserva la primera ubicación; ignora apariciones posteriores.
        /// </summary>
        public void AgregarSimbolo(string lexema, int linea, int columna)
        {
            if (tabla.ContainsKey(lexema)) return;
            var simbolo = new Simbolo(lexema, linea, columna);
            tabla.Add(lexema, simbolo);
            ordenAparicion.Add(simbolo);
        }

        /// <summary>Devuelve los símbolos en orden de primera aparición.</summary>
        public List<Simbolo> ObtenerSimbolos()
            => new List<Simbolo>(ordenAparicion);
    }
}

