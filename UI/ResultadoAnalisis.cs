using System;
using System.Collections.Generic;
using C_Extended.Core;

namespace C_Extended.UI
{
    /// <summary>
    /// Instantánea coherente de un análisis léxico completado.
    /// Todas las tablas y estadísticas de la UI se derivan de esta clase,
    /// garantizando que los datos mostrados corresponden siempre al mismo análisis.
    /// </summary>
    public sealed class ResultadoAnalisis
    {
        public List<Token>        Tokens         { get; }
        public List<ErrorLexico>  Errores        { get; }
        public List<Simbolo>      Simbolos       { get; }
        public int                TotalLineas    { get; }
        public long               TiempoMs       { get; }
        public string             NombreFuente   { get; }
        public string             TextoAnalizado { get; }
        public DateTime           FechaHora      { get; }

        public ResultadoAnalisis(
            List<Token>       tokens,
            List<ErrorLexico> errores,
            List<Simbolo>     simbolos,
            int               totalLineas,
            long              tiempoMs,
            string            nombreFuente,
            string            textoAnalizado,
            DateTime?         fechaHora = null)
        {
            Tokens = tokens == null
                ? new List<Token>()
                : new List<Token>(tokens);

            Errores = errores == null
                ? new List<ErrorLexico>()
                : new List<ErrorLexico>(errores);

            Simbolos = simbolos == null
                ? new List<Simbolo>()
                : new List<Simbolo>(simbolos);
            TotalLineas    = totalLineas;
            TiempoMs       = tiempoMs;
            NombreFuente   = nombreFuente ?? "";
            TextoAnalizado = textoAnalizado ?? "";
            FechaHora      = fechaHora ?? DateTime.Now;
        }
    }
}

