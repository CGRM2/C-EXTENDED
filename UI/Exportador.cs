using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using C_Extended.Core;

namespace C_Extended.UI
{
    /// <summary>
    /// Genera el archivo TXT de exportacion a partir de una instantanea de analisis.
    /// La exportacion parte siempre de los objetos del analisis, nunca del texto
    /// visible en los controles.
    /// Aplica una convencion de escape reversible y libre de ambiguedades.
    /// </summary>
    public static class Exportador
    {
        /// <summary>
        /// Transforma una cadena a una representacion reversible y sin ambiguedades,
        /// protegiendo barras invertidas, saltos de linea, retornos de carro, tabulaciones,
        /// comillas y caracteres de control.
        /// </summary>
        public static string EscaparCadena(string s)
        {
            if (s == null) return "";
            var sb = new StringBuilder(s.Length + 16);
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\\': sb.Append(@"\\"); break;
                    case '\r': sb.Append(@"\r"); break;
                    case '\n': sb.Append(@"\n"); break;
                    case '\t': sb.Append(@"\t"); break;
                    case '\"': sb.Append(@"\"""); break;
                    case '\0': sb.Append(@"\0"); break;
                    default:
                        if (c < 32)
                            sb.AppendFormat(@"\u{0:x4}", (int)c);
                        else
                            sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Operacion inversa a EscaparCadena: reconstruye el texto original exacto.
        /// Garantiza que DesescaparCadena(EscaparCadena(s)) == s.
        /// </summary>
        public static string DesescaparCadena(string s)
        {
            if (s == null) return "";
            var sb = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\\' && i + 1 < s.Length)
                {
                    char next = s[i + 1];
                    switch (next)
                    {
                        case '\\': sb.Append('\\'); i++; break;
                        case 'r':  sb.Append('\r'); i++; break;
                        case 'n':  sb.Append('\n'); i++; break;
                        case 't':  sb.Append('\t'); i++; break;
                        case '\"': sb.Append('\"'); i++; break;
                        case '0':  sb.Append('\0'); i++; break;
                        case 'u':
                            if (i + 5 < s.Length && int.TryParse(s.Substring(i + 2, 4), System.Globalization.NumberStyles.HexNumber, null, out int code))
                            {
                                sb.Append((char)code);
                                i += 5;
                            }
                            else
                            {
                                sb.Append('\\');
                            }
                            break;
                        default:
                            sb.Append('\\');
                            break;
                    }
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Exporta la instantanea completa de ResultadoAnalisis a un archivo TXT.
        /// </summary>
        public static void ExportarTxt(string rutaDestino, ResultadoAnalisis resultado)
        {
            if (resultado == null) throw new ArgumentNullException(nameof(resultado));
            ExportarTxt(
                rutaDestino,
                resultado.NombreFuente,
                resultado.FechaHora,
                resultado.Tokens,
                resultado.Errores,
                resultado.Simbolos,
                resultado.TotalLineas,
                resultado.TiempoMs,
                resultado.ErroresSintacticos, resultado.SintaxisEvaluada,
                resultado.TotalInstrucciones, resultado.TiempoSintacticoMs, resultado.Declaraciones);
        }

        /// <summary>
        /// Escribe el informe TXT completo en la ruta indicada.
        /// Lanza IOException si la escritura falla.
        /// </summary>
        public static void ExportarTxt(
            string            rutaDestino,
            string            nombreFuente,
            DateTime          fechaHoraAnalisis,
            List<Token>       tokens,
            List<ErrorLexico> errores,
            List<Simbolo>     simbolos,
            int               totalLineas,
            long              tiempoMs,
            List<ErrorSintactico> erroresSintacticos = null,
            bool sintaxisEvaluada = false,
            int instrucciones = 0,
            long tiempoSintacticoMs = 0,
            List<DeclaracionSintactica> declaraciones = null)
        {
            tokens   = tokens   ?? new List<Token>();
            errores  = errores  ?? new List<ErrorLexico>();
            simbolos = simbolos ?? new List<Simbolo>();

            erroresSintacticos = erroresSintacticos ?? new List<ErrorSintactico>();
            declaraciones = declaraciones ?? new List<DeclaracionSintactica>();
            var sb = new StringBuilder();

            // ---- Encabezado ----
            sb.AppendLine("=============================================================");
            sb.AppendLine("  C-extended | Analizador Lexico y Sintactico - Informe de resultados");
            sb.AppendLine($"  Fecha y hora de analisis   : {fechaHoraAnalisis:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"  Fecha y hora de exportacion: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"  Fuente analizada           : {nombreFuente}");
            sb.AppendLine("=============================================================");
            sb.AppendLine("  Convencion de escape reversible aplicada:");
            sb.AppendLine(@"    '\\'     -> barra invertida literal (\)");
            sb.AppendLine(@"    '\n'     -> salto de linea (LF)");
            sb.AppendLine(@"    '\r'     -> retorno de carro (CR)");
            sb.AppendLine(@"    '\t'     -> tabulacion horizontal");
            sb.AppendLine(@"    '\""'    -> comilla doble ("")");
            sb.AppendLine(@"    '\0'     -> byte nulo");
            sb.AppendLine(@"    '\uXXXX' -> codigo Unicode hexadecimal para otros caracteres de control");
            sb.AppendLine("=============================================================");
            sb.AppendLine();

            // ---- Resumen ----
            sb.AppendLine("--- RESUMEN ---");
            sb.AppendLine($"Total de tokens     : {tokens.Count}");
            sb.AppendLine($"Total de errores detectados: {errores.Count + (sintaxisEvaluada ? erroresSintacticos.Count : 0)}");
            sb.AppendLine($"Errores lexicos      : {errores.Count}");
            sb.AppendLine("Estado sintactico   : " + (sintaxisEvaluada ? "Evaluado" : "Pendiente / no evaluado"));
            sb.AppendLine("Errores sintacticos : " + (sintaxisEvaluada ? erroresSintacticos.Count.ToString() : "No evaluados"));
            sb.AppendLine("Estructuras         : " + (sintaxisEvaluada ? instrucciones.ToString() : "No evaluadas"));
            sb.AppendLine("Declaraciones       : " + (sintaxisEvaluada ? declaraciones.Count.ToString() : "No evaluadas"));
            sb.AppendLine("Tiempo sintactico   : " + (sintaxisEvaluada ? tiempoSintacticoMs + " ms" : "No evaluado"));
            sb.AppendLine("Tiempo total        : " + (tiempoMs + tiempoSintacticoMs) + " ms");
            sb.AppendLine($"Simbolos unicos     : {simbolos.Count}");
            sb.AppendLine($"Total de lineas     : {totalLineas}");
            sb.AppendLine($"Tiempo de analisis  : {tiempoMs} ms");
            sb.AppendLine();

            // ---- Conteo por categoria ----
            sb.AppendLine("--- TOKENS POR CATEGORIA ---");
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
                sb.AppendLine($"  {"#",-5} {"Lexema (escapado)",-45} {"Tipo de token",-25} {"Linea",-7} {"Columna"}");
                sb.AppendLine($"  {new string('-', 95)}");
                int n = 1;
                foreach (var t in tokens)
                {
                    string lexemaVisible = EscaparCadena(t.Lexema);
                    sb.AppendLine($"  {n,-5} {lexemaVisible,-45} {t.TipoToken,-25} {t.Linea,-7} {t.Columna}");
                    n++;
                }
            }
            sb.AppendLine();

            // ---- Errores lexicos ----
            sb.AppendLine("--- ERRORES LEXICOS ---");
            if (errores.Count == 0)
            {
                sb.AppendLine("  No se encontraron errores lexicos.");
            }
            else
            {
                sb.AppendLine($"  {"#",-5} {"Secuencia invalida (escapada)",-40} {"Linea",-7} {"Columna",-9} {"Descripcion"}");
                sb.AppendLine($"  {new string('-', 100)}");
                int n = 1;
                foreach (var e in errores)
                {
                    string seqVisible = EscaparCadena(e.CaracterInvalido);
                    sb.AppendLine($"  {n,-5} {seqVisible,-40} {e.Linea,-7} {e.Columna,-9} {e.Descripcion}");
                    n++;
                }
            }
            sb.AppendLine();

            sb.AppendLine("--- ERRORES SINTACTICOS ---");
            if (!sintaxisEvaluada) sb.AppendLine("  Analisis sintactico pendiente / no evaluado. Corrige primero los errores lexicos si existen.");
            else if (erroresSintacticos.Count == 0) sb.AppendLine("  Sin errores segun la gramatica de C-Extended. No se verifican tipos ni nombres declarados.");
            else foreach (var error in erroresSintacticos)
                sb.AppendLine("  " + error.Linea + ":" + error.Columna + " | " + EscaparCadena(error.Encontrado) + " | " + error.Descripcion);
            sb.AppendLine();
            sb.AppendLine("--- DECLARACIONES SINTACTICAS ENCONTRADAS (SIN RESOLUCION DE AMBITOS) ---");
            if (!sintaxisEvaluada) sb.AppendLine("  No evaluadas: analisis sintactico pendiente.");
            else if (declaraciones.Count == 0) sb.AppendLine("  No se encontraron declaraciones.");
            else foreach (var declaracion in declaraciones)
                sb.AppendLine("  " + EscaparCadena(declaracion.Nombre) + " | " + EscaparCadena(declaracion.Tipo) + " | " + declaracion.Rol + " | " + declaracion.Linea + ":" + declaracion.Columna);
            sb.AppendLine();

            // ---- Tabla de simbolos ----
            sb.AppendLine("--- TABLA DE SIMBOLOS ---");
            if (simbolos.Count == 0)
            {
                sb.AppendLine("  (tabla vacia)");
            }
            else
            {
                sb.AppendLine($"  {"#",-5} {"Identificador",-35} {"Tipo de token",-20} {"Primera linea",-15} {"Primera columna"}");
                sb.AppendLine($"  {new string('-', 90)}");
                int n = 1;
                foreach (var s in simbolos)
                {
                    string idVisible = EscaparCadena(s.NombreIdentificador);
                    sb.AppendLine($"  {n++,-5} {idVisible,-35} {s.TipoToken,-20} {s.LineaPrimeraAparicion,-15} {s.ColumnaInicio}");
                }
            }
            sb.AppendLine();
            sb.AppendLine("=============================================================");
            sb.AppendLine("  Fin del informe");
            sb.AppendLine("=============================================================");

            File.WriteAllText(rutaDestino, sb.ToString(), new UTF8Encoding(false));
        }
    }
}

