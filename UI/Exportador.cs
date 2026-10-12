using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using C_Extended.Core;

namespace C_Extended.UI
{
    /// <summary>
    /// Genera el archivo TXT de exportación a partir de una instantánea de análisis.
    /// La exportación parte siempre de los objetos del análisis, nunca del texto
    /// visible en los controles.
    /// </summary>
    public static class Exportador
    {
        /// <summary>
        /// Escribe el informe TXT completo en la ruta indicada.
        /// Lanza IOException si la escritura falla.
        /// </summary>
        public static void ExportarTxt(
            string           rutaDestino,
            string           nombreFuente,
            List<Token>      tokens,
            List<ErrorLexico> errores,
            List<Simbolo>    simbolos,
            int              totalLineas,
            long             tiempoMs)
        {
            var sb = new StringBuilder();

            // ---- Encabezado ----
            sb.AppendLine("=============================================================");
            sb.AppendLine("  C-extended | Analizador Léxico — Informe de resultados");
            sb.AppendLine($"  Fecha y hora : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"  Fuente       : {nombreFuente}");
            sb.AppendLine("=============================================================");
            sb.AppendLine();

            // ---- Resumen ----
            sb.AppendLine("--- RESUMEN ---");
            sb.AppendLine($"Total de tokens  : {tokens.Count}");
            sb.AppendLine($"Total de errores : {errores.Count}");
            sb.AppendLine($"Símbolos únicos  : {simbolos.Count}");
            sb.AppendLine($"Total de líneas  : {totalLineas}");
            sb.AppendLine($"Tiempo de análisis: {tiempoMs} ms");
            sb.AppendLine();

            // ---- Conteo por categoría ----
            sb.AppendLine("--- TOKENS POR CATEGORÍA ---");
            var conteos = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var t in tokens)
            {
                if (!conteos.ContainsKey(t.TipoToken)) conteos[t.TipoToken] = 0;
                conteos[t.TipoToken]++;
            }
            foreach (var kv in conteos)
                sb.AppendLine($"  {kv.Key,-30} : {kv.Value}");
            sb.AppendLine($"  {"TOTAL",-30} : {tokens.Count}");
            sb.AppendLine();

            // ---- Tabla de tokens ----
            sb.AppendLine("--- TOKENS ---");
            if (tokens.Count == 0)
            {
                sb.AppendLine("  (no se encontraron tokens)");
            }
            else
            {
                sb.AppendLine($"  {"#",-5} {"Lexema",-35} {"Tipo de token",-25} {"Línea",-7} {"Columna"}");
                sb.AppendLine($"  {new string('-', 80)}");
                int n = 1;
                foreach (var t in tokens)
                {
                    // Para la exportación mostramos el lexema original completo.
                    // Los saltos de línea internos (en comentarios de bloque) se
                    // representan con la secuencia visible <LF> para no confundir
                    // con separadores de fila del informe.
                    string lexemaVisible = t.Lexema
                        .Replace("\r\n", "<CRLF>")
                        .Replace("\r",   "<CR>")
                        .Replace("\n",   "<LF>")
                        .Replace("\t",   "<TAB>");
                    sb.AppendLine($"  {n,-5} {lexemaVisible,-35} {t.TipoToken,-25} {t.Linea,-7} {t.Columna}");
                    n++;
                }
            }
            sb.AppendLine();

            // ---- Errores léxicos ----
            sb.AppendLine("--- ERRORES LÉXICOS ---");
            if (errores.Count == 0)
            {
                sb.AppendLine("  No se encontraron errores léxicos.");
            }
            else
            {
                sb.AppendLine($"  {"#",-5} {"Secuencia inválida",-30} {"Línea",-7} {"Columna",-9} {"Descripción"}");
                sb.AppendLine($"  {new string('-', 90)}");
                int n = 1;
                foreach (var e in errores)
                {
                    string seqVisible = e.CaracterInvalido
                        .Replace("\r\n", "<CRLF>")
                        .Replace("\r",   "<CR>")
                        .Replace("\n",   "<LF>")
                        .Replace("\t",   "<TAB>");
                    sb.AppendLine($"  {n,-5} {seqVisible,-30} {e.Linea,-7} {e.Columna,-9} {e.Descripcion}");
                    n++;
                }
            }
            sb.AppendLine();

            // ---- Tabla de símbolos ----
            sb.AppendLine("--- TABLA DE SÍMBOLOS ---");
            if (simbolos.Count == 0)
            {
                sb.AppendLine("  (tabla vacía)");
            }
            else
            {
                sb.AppendLine($"  {"#",-5} {"Identificador",-30} {"Tipo de token",-20} {"Primera línea",-15} {"Primera columna"}");
                sb.AppendLine($"  {new string('-', 80)}");
                int n = 1;
                foreach (var s in simbolos)
                    sb.AppendLine($"  {n++,-5} {s.NombreIdentificador,-30} {s.TipoToken,-20} {s.LineaPrimeraAparicion,-15} {s.ColumnaInicio}");
            }
            sb.AppendLine();
            sb.AppendLine("=============================================================");
            sb.AppendLine("  Fin del informe");
            sb.AppendLine("=============================================================");

            // Escribir en UTF-8; confirmar éxito solo cuando la escritura termina.
            File.WriteAllText(rutaDestino, sb.ToString(), new UTF8Encoding(false));
        }
    }
}

