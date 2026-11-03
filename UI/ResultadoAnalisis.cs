using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<ErrorSintactico> ErroresSintacticos { get; } = new List<ErrorSintactico>();
        public List<DeclaracionSintactica> Declaraciones { get; } = new List<DeclaracionSintactica>();
        public bool SintaxisEvaluada { get; private set; }
        public long TiempoSintacticoMs { get; private set; }
        public long TiempoTotalMs => TiempoMs + TiempoSintacticoMs;
        public int TotalInstrucciones { get; private set; }
        public int TotalErrores => Errores.Count + ErroresSintacticos.Count;
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
            if (Errores.Count == 0)
            {
                var reloj = Stopwatch.StartNew();
                var sintactico = new AnalizadorSintactico();
                sintactico.Analizar(Tokens, TextoAnalizado);
                reloj.Stop();
                ErroresSintacticos.AddRange(sintactico.Errores);
                Declaraciones.AddRange(sintactico.Declaraciones);
                TotalInstrucciones = sintactico.TotalInstrucciones;
                TiempoSintacticoMs = reloj.ElapsedMilliseconds;
                SintaxisEvaluada = true;
            }
        }
    }
}

