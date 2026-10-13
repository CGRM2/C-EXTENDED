using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C_Extended.Core;
using C_Extended.UI;

namespace PruebasConsola
{
    internal static class Program
    {
        private static int aprobadas;
        private static int fallidas;
        private static readonly StringBuilder informe = new StringBuilder();

        private static void Verificar(string nombre, bool condicion, string detalleFallo = "")
        {
            if (condicion)
            {
                aprobadas++;
                informe.AppendLine("APROBADA | " + nombre);
            }
            else
            {
                fallidas++;
                informe.AppendLine("FALLIDA  | " + nombre + (string.IsNullOrEmpty(detalleFallo) ? "" : " -> " + detalleFallo));
            }
        }

        private static AnalizadorLexico Archivo(string ruta)
        {
            var analizador = new AnalizadorLexico();
            analizador.AnalizarArchivo(ruta);
            informe.AppendLine("ARCHIVO | " + Path.GetFileName(ruta) +
                " | tokens=" + analizador.ObtenerTokens().Count +
                " | símbolos=" + analizador.ObtenerSimbolos().Count +
                " | errores=" + analizador.ObtenerErrores().Count +
                " | líneas=" + analizador.TotalLineas);
            foreach (var error in analizador.ObtenerErrores())
            {
                informe.AppendLine("  ERROR " + error.Linea + ":" + error.Columna +
                    " | " + error.Descripcion + " | " + Exportador.EscaparCadena(error.CaracterInvalido));
            }
            return analizador;
        }

        private static bool HayToken(AnalizadorLexico a, string lexema, string tipo)
            => a.ObtenerTokens().Any(t => t.Lexema == lexema && t.TipoToken == tipo);

        [STAThread]
        private static int Main(string[] args)
        {
            string raiz = args.Length > 0 && Directory.Exists(args[0])
                ? args[0]
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Pruebas");

            if (!Directory.Exists(raiz))
                raiz = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Pruebas"));

            informe.AppendLine("=============================================================");
            informe.AppendLine("  BATERÍA DE PRUEBAS DE VERIFICACIÓN — ENTREGABLE 4");
            informe.AppendLine("  C-EXTENDED | CORRECCIONES Y ROBUSTEZ");
            informe.AppendLine("  Fecha de ejecución: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            informe.AppendLine("=============================================================");
            informe.AppendLine();

            // ==============================================================
            // 1. CINCO CASOS HISTÓRICOS
            // ==============================================================
            informe.AppendLine("--- 1. VERIFICACIÓN DE LOS CINCO CASOS HISTÓRICOS ---");

            // Prueba 1
            var a1 = Archivo(Path.Combine(raiz, "prueba1_sencillo.txt"));
            Verificar("Prueba 1: sin errores", a1.ObtenerErrores().Count == 0);
            Verificar("Prueba 1: recuento tokens esperado (25)", a1.ObtenerTokens().Count == 25);
            Verificar("Prueba 1: reservada e identificador", HayToken(a1, "namespace", "TK_RESERVADA") && HayToken(a1, "contador", "TK_IDENTIFICADOR"));
            Verificar("Prueba 1: += es asignación", HayToken(a1, "+=", "TK_OP_ASIGNACION"));
            var contador = a1.ObtenerSimbolos().SingleOrDefault(s => s.NombreIdentificador == "contador");
            Verificar("Prueba 1: símbolo único y primera posición (5:13)",
                contador != null && contador.LineaPrimeraAparicion == 5 && contador.ColumnaInicio == 13 &&
                a1.ObtenerSimbolos().Count(s => s.NombreIdentificador == "contador") == 1);

            // Prueba 2
            var a2 = Archivo(Path.Combine(raiz, "prueba2_medio.txt"));
            Verificar("Prueba 2: sin errores", a2.ObtenerErrores().Count == 0);
            Verificar("Prueba 2: recuento tokens esperado (62)", a2.ObtenerTokens().Count == 62);
            Verificar("Prueba 2: símbolos únicos (9)", a2.ObtenerSimbolos().Count == 9);
            Verificar("Prueba 2: decimal, for y continue",
                HayToken(a2, "2.5", "TK_NUM_DECIMAL") && HayToken(a2, "for", "TK_RESERVADA") && HayToken(a2, "continue", "TK_RESERVADA"));

            // Prueba 3
            var a3 = Archivo(Path.Combine(raiz, "prueba3_errores.txt"));
            Verificar("Prueba 3: exactamente cuatro errores visibles", a3.ObtenerErrores().Count == 4);
            Verificar("Prueba 3: recuento tokens esperado (20)", a3.ObtenerTokens().Count == 20);
            Verificar("Prueba 3: símbolos únicos (4)", a3.ObtenerSimbolos().Count == 4);
            Verificar("Prueba 3: diagnóstico identificador con inicio numérico (6:13)",
                a3.ObtenerErrores().Any(e => e.Linea == 6 && e.Columna == 13 && e.Descripcion.Contains("inicio numérico")));
            Verificar("Prueba 3: diagnóstico decimal mal formado (9:22)",
                a3.ObtenerErrores().Any(e => e.Linea == 9 && e.Columna == 22 && e.Descripcion.Contains("decimal mal formado")));
            Verificar("Prueba 3: diagnóstico cadena sin cerrar (12:23)",
                a3.ObtenerErrores().Any(e => e.Linea == 12 && e.Columna == 23 && e.Descripcion.Contains("Cadena de texto sin cerrar")));
            Verificar("Prueba 3: diagnóstico comentario multilínea sin cerrar (14:9)",
                a3.ObtenerErrores().Any(e => e.Linea == 14 && e.Columna == 9 && e.Descripcion.Contains("Comentario multilínea sin cerrar")));
            Verificar("Prueba 3: @ permanece dentro del comentario abierto",
                !a3.ObtenerErrores().Any(e => e.CaracterInvalido == "@"));

            // Prueba 4
            var a4 = Archivo(Path.Combine(raiz, "prueba4_recuperacion.txt"));
            Verificar("Prueba 4: exactamente dos errores", a4.ObtenerErrores().Count == 2);
            Verificar("Prueba 4: recuento tokens esperado (21)", a4.ObtenerTokens().Count == 21);
            Verificar("Prueba 4: carácter no permitido @ en 2:1",
                a4.ObtenerErrores()[0].CaracterInvalido == "@" && a4.ObtenerErrores()[0].Linea == 2 && a4.ObtenerErrores()[0].Columna == 1);
            Verificar("Prueba 4: recuperación continúa hasta identificador final",
                HayToken(a4, "final", "TK_IDENTIFICADOR") && HayToken(a4, "despues", "TK_IDENTIFICADOR"));

            // Prueba 5
            var a5 = Archivo(Path.Combine(raiz, "prueba5_categorias.txt"));
            Verificar("Prueba 5: sin errores", a5.ObtenerErrores().Count == 0);
            Verificar("Prueba 5: recuento tokens esperado (59)", a5.ObtenerTokens().Count == 59);
            Verificar("Prueba 5: símbolos únicos (7)", a5.ObtenerSimbolos().Count == 7);
            string[] categoriasRequeridas = {
                "TK_RESERVADA", "TK_IDENTIFICADOR", "TK_NUM_ENTERO", "TK_CADENA", "TK_CARACTER",
                "TK_OP_ARITMETICO", "TK_OP_RELACIONAL", "TK_OP_LOGICO", "TK_OP_ASIGNACION",
                "TK_DELIMITADOR", "TK_COMENTARIO_LINEA", "TK_COMENTARIO_BLOQUE"
            };
            foreach (string tipo in categoriasRequeridas)
            {
                Verificar("Prueba 5: categoría cubierta " + tipo, a5.ObtenerTokens().Any(t => t.TipoToken == tipo));
            }
            informe.AppendLine();

            // ==============================================================
            // 2. CASO NUEVO: PRUEBA 6 (INTERFAZ Y EXPORTACIÓN)
            // ==============================================================
            informe.AppendLine("--- 2. VERIFICACIÓN DEL CASO NUEVO (PRUEBA 6) ---");
            string rutaP6 = Path.Combine(raiz, "prueba6_interfaz_exportacion.txt");
            var a6 = Archivo(rutaP6);
            Verificar("Prueba 6: procesada con motor real", a6 != null);
            Verificar("Prueba 6: detecta comentario literal /*<LF>*/", HayToken(a6, "/*<LF>*/", "TK_COMENTARIO_BLOQUE"));
            Verificar("Prueba 6: detecta comentario literal /*<CRLF>*/", HayToken(a6, "/*<CRLF>*/", "TK_COMENTARIO_BLOQUE"));
            Verificar("Prueba 6: detecta comentario multilínea con salto real",
                a6.ObtenerTokens().Any(t => t.TipoToken == "TK_COMENTARIO_BLOQUE" && t.Lexema.Contains("\n") && t.Lexema.Contains("salto real")));
            Verificar("Prueba 6: detecta cadenas con barras invertidas",
                HayToken(a6, "\"C:\\\\Archivos\\\\Proyecto\\\\test.txt\"", "TK_CADENA"));
            Verificar("Prueba 6: detecta cadenas con escapes y tabulaciones",
                a6.ObtenerTokens().Any(t => t.TipoToken == "TK_CADENA" && t.Lexema.Contains("\\t") && t.Lexema.Contains("\\\"")));
            Verificar("Prueba 6: caracteres literales con escape ('\\\\', '\\'', '\\n')",
                HayToken(a6, "'\\\\'", "TK_CARACTER") && HayToken(a6, "'\\''", "TK_CARACTER") && HayToken(a6, "'\\n'", "TK_CARACTER"));
            Verificar("Prueba 6: contiene exactamente 1 error léxico controlado (# en 26:26)",
                a6.ObtenerErrores().Count == 1 && a6.ObtenerErrores()[0].CaracterInvalido == "#" && a6.ObtenerErrores()[0].Linea == 26 && a6.ObtenerErrores()[0].Columna == 26);
            informe.AppendLine();

            // ==============================================================
            // 3. DEFECTO: CONSUMO Y DETECCIÓN RIGUROSA DE BOM
            // ==============================================================
            informe.AppendLine("--- 3. VERIFICACIÓN DE CARGA FIABLE Y DETECCIÓN DE BOM ---");

            string tempDir = Path.Combine(Path.GetTempPath(), "CExtendedTests_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);

            try
            {
                // UTF-8 con BOM
                string archivoUtf8Bom = Path.Combine(tempDir, "utf8_bom.txt");
                byte[] bytesUtf8Bom = new byte[] { 0xEF, 0xBB, 0xBF, (byte)'v', (byte)'a', (byte)'r', (byte)' ', (byte)'x', (byte)' ', (byte)'=', (byte)' ', (byte)'1', (byte)';' };
                File.WriteAllBytes(archivoUtf8Bom, bytesUtf8Bom);

                string contenidoUtf8Bom, errUtf8Bom;
                bool okUtf8Bom = FrmPrincipal.IntentarLeerArchivo(archivoUtf8Bom, out contenidoUtf8Bom, out errUtf8Bom);
                Verificar("Carga BOM: UTF-8 con BOM se lee correctamente", okUtf8Bom && errUtf8Bom == null);
                Verificar("Carga BOM: U+FEFF es consumido y no pasa al texto ('var x = 1;' sin BOM)",
                    contenidoUtf8Bom == "var x = 1;" && contenidoUtf8Bom[0] == 'v' && !contenidoUtf8Bom.Contains("\uFEFF"),
                    "Obtenido=[" + contenidoUtf8Bom + "] chars=" + string.Join(",", contenidoUtf8Bom.ToCharArray().Select(c => ((int)c).ToString()).ToArray()));

                var motorUtf8Bom = new AnalizadorLexico();
                motorUtf8Bom.Analizar(contenidoUtf8Bom);
                Verificar("Carga BOM: el primer token es 'var' en línea 1 columna 1 sin error de BOM",
                    motorUtf8Bom.ObtenerTokens().Count > 0 &&
                    motorUtf8Bom.ObtenerTokens()[0].Lexema == "var" &&
                    motorUtf8Bom.ObtenerTokens()[0].Linea == 1 &&
                    motorUtf8Bom.ObtenerTokens()[0].Columna == 1 &&
                    motorUtf8Bom.ObtenerErrores().Count == 0);

                // UTF-16 LE con BOM
                string archivoU16Le = Path.Combine(tempDir, "utf16_le.txt");
                File.WriteAllText(archivoU16Le, "var y = 2;", Encoding.Unicode);
                string contenidoU16Le, errU16Le;
                bool okU16Le = FrmPrincipal.IntentarLeerArchivo(archivoU16Le, out contenidoU16Le, out errU16Le);
                Verificar("Carga BOM: UTF-16 LE con BOM se lee y consume correctamente", okU16Le && contenidoU16Le == "var y = 2;");

                // UTF-16 BE con BOM
                string archivoU16Be = Path.Combine(tempDir, "utf16_be.txt");
                File.WriteAllText(archivoU16Be, "var z = 3;", Encoding.BigEndianUnicode);
                string contenidoU16Be, errU16Be;
                bool okU16Be = FrmPrincipal.IntentarLeerArchivo(archivoU16Be, out contenidoU16Be, out errU16Be);
                Verificar("Carga BOM: UTF-16 BE con BOM se lee y consume correctamente", okU16Be && contenidoU16Be == "var z = 3;");

                // UTF-32 LE con BOM (debe ser rechazado claramente sin confundirse con UTF-16 LE)
                string archivoU32Le = Path.Combine(tempDir, "utf32_le.txt");
                byte[] bytesU32Le = new byte[] { 0xFF, 0xFE, 0x00, 0x00, (byte)'v', 0, 0, 0 };
                File.WriteAllBytes(archivoU32Le, bytesU32Le);
                string contU32Le, errU32Le;
                bool okU32Le = FrmPrincipal.IntentarLeerArchivo(archivoU32Le, out contU32Le, out errU32Le);
                Verificar("Carga BOM: UTF-32 LE no se confunde con UTF-16 LE y es rechazado claramente",
                    !okU32Le && errU32Le != null && errU32Le.Contains("UTF-32 LE"));

                // UTF-32 BE con BOM
                string archivoU32Be = Path.Combine(tempDir, "utf32_be.txt");
                byte[] bytesU32Be = new byte[] { 0x00, 0x00, 0xFE, 0xFF, 0, 0, 0, (byte)'v' };
                File.WriteAllBytes(archivoU32Be, bytesU32Be);
                string contU32Be, errU32Be;
                bool okU32Be = FrmPrincipal.IntentarLeerArchivo(archivoU32Be, out contU32Be, out errU32Be);
                Verificar("Carga BOM: UTF-32 BE es rechazado claramente",
                    !okU32Be && errU32Be != null && errU32Be.Contains("UTF-32 BE"));

                // UTF-8 inválido (secuencia corrupta sin fallback a U+FFFD)
                string archivoInvalido = Path.Combine(tempDir, "utf8_invalido.txt");
                byte[] bytesInvalidos = new byte[] { (byte)'v', (byte)'a', (byte)'r', 0xC0, 0xAF, (byte)';' };
                File.WriteAllBytes(archivoInvalido, bytesInvalidos);
                string contInvalido, errInvalido;
                bool okInvalido = FrmPrincipal.IntentarLeerArchivo(archivoInvalido, out contInvalido, out errInvalido);
                Verificar("Carga UTF-8 estricto: bytes corruptos son rechazados y no aceptados con U+FFFD",
                    !okInvalido && errInvalido != null && errInvalido.Contains("UTF-8"));

                // Archivo binario con bytes nulos
                string archivoBinario = Path.Combine(tempDir, "archivo.bin");
                byte[] bytesBinarios = new byte[] { 0x00, 0x01, 0x02, 0x00, 0x55 };
                File.WriteAllBytes(archivoBinario, bytesBinarios);
                string contBin, errBin;
                bool okBin = FrmPrincipal.IntentarLeerArchivo(archivoBinario, out contBin, out errBin);
                Verificar("Carga binario: archivo con bytes nulos es rechazado",
                    !okBin && errBin != null && errBin.Contains("binario"));

                // Archivo vacío
                string archivoVacio = Path.Combine(tempDir, "vacio.txt");
                File.WriteAllBytes(archivoVacio, new byte[0]);
                string contVacio, errVacio;
                bool okVacio = FrmPrincipal.IntentarLeerArchivo(archivoVacio, out contVacio, out errVacio);
                Verificar("Carga vacío: archivo de 0 bytes se carga sin excepción como texto vacío",
                    okVacio && contVacio == "");

                // Código compuesto únicamente por comentarios
                var motorSoloComentarios = new AnalizadorLexico();
                motorSoloComentarios.Analizar("// Comentario 1\r\n/* Comentario 2\r\n multilínea */\r\n// Comentario 3");
                Verificar("Carga comentarios: archivo solo con comentarios se procesa con 0 errores y tokens correspondientes",
                    motorSoloComentarios.ObtenerErrores().Count == 0 &&
                    motorSoloComentarios.ObtenerTokens().Count == 3 &&
                    motorSoloComentarios.ObtenerSimbolos().Count == 0 &&
                    motorSoloComentarios.TotalLineas >= 4);
            }
            finally
            {
                try { Directory.Delete(tempDir, true); } catch { }
            }
            informe.AppendLine();

            // ==============================================================
            // 4. DEFECTO: EXPORTACIÓN SIN AMBIGÜEDAD Y FECHA/HORA
            // ==============================================================
            informe.AppendLine("--- 4. VERIFICACIÓN DE EXPORTACIÓN SIN AMBIGÜEDAD ---");

            // Reversibilidad y no-colisión de /*<LF>*/ vs salto real
            string litLF = "/*<LF>*/";
            string realLF = "/*\n*/";
            string realCRLF = "/*\r\n*/";
            string litCRLF = "/*<CRLF>*/";
            string litBarraN = "/*\\n*/";

            string escLitLF = Exportador.EscaparCadena(litLF);
            string escRealLF = Exportador.EscaparCadena(realLF);
            string escRealCRLF = Exportador.EscaparCadena(realCRLF);
            string escLitCRLF = Exportador.EscaparCadena(litCRLF);
            string escLitBarraN = Exportador.EscaparCadena(litBarraN);

            Verificar("Escape sin ambigüedad: /*<LF>*/ y /*\\n*/ producen representaciones distintas",
                escLitLF != escRealLF);
            Verificar("Escape sin ambigüedad: /*<CRLF>*/ y /*\\r\\n*/ producen representaciones distintas",
                escLitCRLF != escRealCRLF);
            Verificar("Escape sin ambigüedad: /*\\n*/ literal y /*\n*/ real son distinguibles",
                escLitBarraN != escRealLF);

            // Verificación de reversibilidad universal: Desescapar(Escapar(x)) == x
            string[] casosEscape = {
                litLF, realLF, realCRLF, litCRLF, litBarraN,
                "Texto con comillas \"dobles\" y comas, y barras \\ y tabulador \t fin",
                "Cadena con \0 byte nulo y control \u0007",
                "Normal identifier 123",
                "",
                "\"C:\\Windows\\System32\\calc.exe\""
            };
            bool todoReversible = true;
            foreach (var c in casosEscape)
            {
                string esc = Exportador.EscaparCadena(c);
                string des = Exportador.DesescaparCadena(esc);
                if (des != c)
                {
                    todoReversible = false;
                    informe.AppendLine("  FALLO REVERSIBILIDAD: Original=[" + c + "] Escapado=[" + esc + "] Desescapado=[" + des + "]");
                }
            }
            Verificar("Escape reversible: DesescaparCadena(EscaparCadena(s)) == s para todos los casos", todoReversible);

            // Verificación de captura de fecha y hora del análisis en exportación
            DateTime fechaFijada = new DateTime(2026, 10, 12, 14, 30, 45);
            var resExport = new ResultadoAnalisis(
                a6.ObtenerTokens(),
                a6.ObtenerErrores(),
                a6.ObtenerSimbolos(),
                a6.TotalLineas,
                15,
                "prueba6_interfaz_exportacion.txt",
                "texto",
                fechaFijada);

            string rutaTempExport = Path.Combine(Path.GetTempPath(), "export_test_" + Guid.NewGuid().ToString("N") + ".txt");
            try
            {
                Exportador.ExportarTxt(rutaTempExport, resExport);
                string contenidoExport = File.ReadAllText(rutaTempExport, Encoding.UTF8);

                Verificar("Exportación: archivo generado existe y no está vacío", File.Exists(rutaTempExport) && contenidoExport.Length > 0);
                Verificar("Exportación: conserva fecha/hora capturada del análisis (2026-10-12 14:30:45)",
                    contenidoExport.Contains("Fecha y hora de análisis   : 2026-10-12 14:30:45"));
                Verificar("Exportación: muestra fecha y hora de exportación identificada separadamente",
                    contenidoExport.Contains("Fecha y hora de exportación:"));
                Verificar("Exportación: incluye convención de escape reversible en el encabezado",
                    contenidoExport.Contains("Convención de escape reversible"));
                Verificar("Exportación: tabla de tokens incluye lexemas escapados sin ambigüedad",
                    contenidoExport.Contains("/*<LF>*/") && contenidoExport.Contains("--- TOKENS ---"));
                Verificar("Exportación: tabla de errores incluye error # de prueba 6",
                    contenidoExport.Contains("--- ERRORES LÉXICOS ---") && contenidoExport.Contains("#"));
                Verificar("Exportación: tabla de símbolos presente y ordenada",
                    contenidoExport.Contains("--- TABLA DE SÍMBOLOS ---") && contenidoExport.Contains("ExportacionAvanzada"));
            }
            finally
            {
                try { if (File.Exists(rutaTempExport)) File.Delete(rutaTempExport); } catch { }
            }
            informe.AppendLine();

            // ==============================================================
            // 5. DEFECTO: FORMULARIO, SPLITMAIN Y PANEL RESUMEN
            // ==============================================================
            informe.AppendLine("--- 5. VERIFICACIÓN DE FRMPRINCIPAL, SPLITMAIN Y PNLRESUMEN ---");

            try
            {
                using (var form = new FrmPrincipal())
                {
                    Verificar("FrmPrincipal: inicializa sin lanzar InvalidOperationException ni NullReferenceException", form != null);
                    Verificar("FrmPrincipal: título correcto", form.Text == "C-extended | Analizador léxico");
                    Verificar("FrmPrincipal: tamaño de cliente inicial compatible (1200x720)",
                        form.ClientSize.Width == 1200 && form.ClientSize.Height == 720);

                    // Verificar splitMain
                    var split = form.Controls["splitMain"] as SplitContainer;
                    Verificar("splitMain: control presente en controles principales", split != null);
                    if (split != null)
                    {
                        Verificar("splitMain: Panel1MinSize es 280 y Panel2MinSize es 380",
                            split.Panel1MinSize == 280 && split.Panel2MinSize == 380);
                        Verificar("splitMain: SplitterDistance es 440 (compatible con tamaño inicial 1200x608)",
                            split.SplitterDistance == 440);
                    }

                    // Verificar pnlResumen
                    var resumen = form.Controls["pnlResumen"] as Panel;
                    Verificar("pnlResumen: panel presente en controles principales (no es campo nulo)", resumen != null);
                    if (resumen != null)
                    {
                        Verificar("pnlResumen: altura funcional configurada (36)", resumen.Height == 36);
                        Verificar("pnlResumen: contiene etiquetas de resumen (Tokens, Errores, Símbolos, Líneas, Tiempo)",
                            resumen.Controls.ContainsKey("lblResumenTokens") &&
                            resumen.Controls.ContainsKey("lblResumenErrores") &&
                            resumen.Controls.ContainsKey("lblResumenSimbolos") &&
                            resumen.Controls.ContainsKey("lblResumenLineas") &&
                            resumen.Controls.ContainsKey("lblResumenTiempo"));
                    }

                    // Verificar pnlEstado
                    var estado = form.Controls["pnlEstado"] as Panel;
                    Verificar("pnlEstado: barra de estado presente", estado != null && estado.Controls.ContainsKey("lblEstado"));
                }
            }
            catch (Exception ex)
            {
                Verificar("FrmPrincipal: inicialización falló con excepción", false, ex.ToString());
            }
            informe.AppendLine();

            // ==============================================================
            // RESUMEN GLOBAL
            // ==============================================================
            informe.AppendLine("=============================================================");
            informe.AppendLine("TOTAL DE VERIFICACIONES | Aprobadas=" + aprobadas + " | Fallidas=" + fallidas);
            informe.AppendLine("RESULTADO FINAL: " + (fallidas == 0 ? "SATISFACTORIO (100% APROBADO)" : "CON FALLAS DETECTADAS"));
            informe.AppendLine("=============================================================");

            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(informe.ToString());

            string rutaEvidencia = Path.Combine(raiz, "evidencia_pruebas_entregable4.txt");
            File.WriteAllText(rutaEvidencia, informe.ToString(), new UTF8Encoding(false));

            return fallidas == 0 ? 0 : 1;
        }
    }
}
