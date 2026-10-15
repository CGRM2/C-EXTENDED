using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using C_Extended.Core;

namespace C_Extended.UI
{
    /// <summary>
    /// Formulario principal de C-extended | Analizador léxico.
    /// Organización: barra de acciones (arriba) · editor con numeración (izquierda) ·
    ///               pestañas de resultados (derecha) · panel de resumen (abajo) ·
    ///               barra de estado (inferior).
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        // ----------------------------------------------------------------
        // Estado de la sesión
        // ----------------------------------------------------------------
        private ResultadoAnalisis _ultimoResultado = null;
        private string            _rutaArchivoCargado = null;
        private bool              _resultadosValidos  = false;
        private bool              _suprimiendoCambio  = false;

        // Colores de la interfaz
        private static readonly Color ColorTexto       = Color.FromArgb(220, 220, 220);
        private static readonly Color ColorAcento      = Color.FromArgb(0, 122, 204);
        private static readonly Color ColorError       = Color.FromArgb(210, 50, 50);
        private static readonly Color ColorAdvertencia = Color.FromArgb(220, 160, 0);

        // ----------------------------------------------------------------
        // Constructor
        // ----------------------------------------------------------------
        public FrmPrincipal()
        {
            InitializeComponent();
            InicializarEstadoFormulario();
        }

        private void InicializarEstadoFormulario()
        {
            btnExportar.Enabled = false;
            lblFuente.Text      = "Código escrito en el editor";
            toolTipPrincipal.SetToolTip(lblFuente, "Editor de código activo");
            ActualizarResumen(null);
            ActualizarBarraEstado(null);
        }

        // ================================================================
        // EVENTOS DE BOTONES
        // ================================================================

        // ---- Cargar archivo ----
        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog
            {
                Title       = "Cargar archivo de código",
                Filter      = "Archivos de texto (*.txt)|*.txt|Archivos C# (*.cs)|*.cs|Todos los archivos (*.*)|*.*",
                FilterIndex = 1
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (!IntentarLeerArchivo(dlg.FileName, out string contenido, out string errorMensaje))
                {
                    MessageBox.Show(errorMensaje, "Error al cargar archivo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CargarContenidoEnEditor(contenido, dlg.FileName);
            }
        }

        /// <summary>
        /// Lee un archivo de texto aplicando detección y consumo riguroso de BOM,
        /// validación estricta de codificación (sin sustitución silenciosa con U+FFFD)
        /// y rechazo claro de codificaciones no admitidas como UTF-32.
        /// </summary>
        public static bool IntentarLeerArchivo(string ruta, out string contenido, out string errorMensaje)
        {
            contenido = null;
            errorMensaje = null;
            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);

                // Archivo vacío
                if (bytes.Length == 0)
                {
                    contenido = "";
                    return true;
                }

                // 1. Detectar firmas de 4 bytes (UTF-32 LE y BE)
                if (bytes.Length >= 4 && bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0x00 && bytes[3] == 0x00)
                {
                    errorMensaje = "La codificación detectada es UTF-32 LE, la cual no está admitida por el analizador.\nPor favor guarde el archivo en codificación UTF-8 o UTF-16.";
                    return false;
                }
                if (bytes.Length >= 4 && bytes[0] == 0x00 && bytes[1] == 0x00 && bytes[2] == 0xFE && bytes[3] == 0xFF)
                {
                    errorMensaje = "La codificación detectada es UTF-32 BE, la cual no está admitida por el analizador.\nPor favor guarde el archivo en codificación UTF-8 o UTF-16.";
                    return false;
                }

                // 2. Detectar BOM UTF-8 (EF BB BF) y consumir los 3 bytes
                if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                {
                    try
                    {
                        var encUtf8 = new UTF8Encoding(false, throwOnInvalidBytes: true);
                        contenido = encUtf8.GetString(bytes, 3, bytes.Length - 3);
                        return true;
                    }
                    catch (DecoderFallbackException)
                    {
                        errorMensaje = "El archivo presenta encabezado UTF-8 (BOM) pero contiene bytes no válidos para la codificación UTF-8.";
                        return false;
                    }
                }

                // 3. Detectar BOM UTF-16 LE (FF FE) y consumir los 2 bytes
                if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                {
                    try
                    {
                        var encU16Le = new UnicodeEncoding(bigEndian: false, byteOrderMark: false, throwOnInvalidBytes: true);
                        contenido = encU16Le.GetString(bytes, 2, bytes.Length - 2);
                        return true;
                    }
                    catch (DecoderFallbackException)
                    {
                        errorMensaje = "El archivo presenta encabezado UTF-16 LE pero contiene secuencias de bytes no válidas.";
                        return false;
                    }
                }

                // 4. Detectar BOM UTF-16 BE (FE FF) y consumir los 2 bytes
                if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
                {
                    try
                    {
                        var encU16Be = new UnicodeEncoding(bigEndian: true, byteOrderMark: false, throwOnInvalidBytes: true);
                        contenido = encU16Be.GetString(bytes, 2, bytes.Length - 2);
                        return true;
                    }
                    catch (DecoderFallbackException)
                    {
                        errorMensaje = "El archivo presenta encabezado UTF-16 BE pero contiene secuencias de bytes no válidas.";
                        return false;
                    }
                }

                // 5. Sin BOM: comprobar si contiene bytes nulos (archivo binario)
                int limite = Math.Min(bytes.Length, 4096);
                for (int i = 0; i < limite; i++)
                {
                    if (bytes[i] == 0x00)
                    {
                        errorMensaje = "El archivo contiene bytes nulos (0x00) y parece ser un archivo binario no admitido.";
                        return false;
                    }
                }

                // 6. Decodificación estricta UTF-8 sin BOM
                try
                {
                    var encUtf8Strict = new UTF8Encoding(false, throwOnInvalidBytes: true);
                    contenido = encUtf8Strict.GetString(bytes, 0, bytes.Length);
                    return true;
                }
                catch (DecoderFallbackException)
                {
                    errorMensaje = "El archivo no contiene una codificación UTF-8 válida y fue rechazado para evitar distorsión del código fuente.\nGuarde el archivo como texto UTF-8.";
                    return false;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                errorMensaje = "Sin permisos de acceso para leer el archivo:\n" + ex.Message;
                return false;
            }
            catch (IOException ex)
            {
                errorMensaje = "Error de lectura de archivo:\n" + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                errorMensaje = "Error inesperado al leer el archivo:\n" + ex.Message;
                return false;
            }
        }

        private void CargarContenidoEnEditor(string contenido, string ruta)
        {
            _suprimiendoCambio = true;
            rtbEditor.Text     = contenido;
            _suprimiendoCambio = false;

            _rutaArchivoCargado = ruta;
            lblFuente.Text      = Path.GetFileName(ruta);
            toolTipPrincipal.SetToolTip(lblFuente, ruta);

            InvalidarResultados();
            pnlNumeros.Invalidate();

            lblEstado.Text      = $"Archivo cargado: '{Path.GetFileName(ruta)}' ({contenido.Length} caracteres). Listo para analizar.";
            lblEstado.ForeColor = ColorTexto;
        }

        // ---- Analizar ----
        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            string texto = rtbEditor.Text;
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Escribe o carga código antes de analizar.",
                    "Editor vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fuente = string.IsNullOrEmpty(_rutaArchivoCargado)
                ? "Código escrito en el editor"
                : Path.GetFileName(_rutaArchivoCargado);

            try
            {
                var motor = new AnalizadorLexico();
                var sw    = Stopwatch.StartNew();
                motor.Analizar(texto);
                sw.Stop();

                _ultimoResultado = new ResultadoAnalisis(
                    motor.ObtenerTokens(),
                    motor.ObtenerErrores(),
                    motor.ObtenerSimbolos(),
                    motor.TotalLineas,
                    sw.ElapsedMilliseconds,
                    fuente,
                    texto,
                    DateTime.Now);

                _resultadosValidos = true;
                btnExportar.Enabled = true;

                MostrarResultados(_ultimoResultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado durante el análisis léxico:\n{ex.Message}",
                    "Error del motor léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblEstado.Text      = "Error en análisis: " + ex.Message;
                lblEstado.ForeColor = ColorError;
            }
        }

        // ---- Exportar ----
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_ultimoResultado == null || !_resultadosValidos)
            {
                MessageBox.Show("Realiza un análisis antes de exportar.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new SaveFileDialog
            {
                Title       = "Exportar resultados del análisis",
                Filter      = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                FilterIndex = 1,
                FileName    = "resultados_c_extended.txt"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.ExportarTxt(dlg.FileName, _ultimoResultado);

                    MessageBox.Show($"Resultados exportados correctamente en:\n{dlg.FileName}",
                        "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error al escribir el archivo:\n{ex.Message}",
                        "Error de escritura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Sin permisos para escribir en la ubicación seleccionada.",
                        "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- Limpiar ----
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _suprimiendoCambio  = true;
            rtbEditor.Clear();
            _suprimiendoCambio  = false;

            _rutaArchivoCargado = null;
            lblFuente.Text      = "Código escrito en el editor";
            toolTipPrincipal.SetToolTip(lblFuente, "Editor de código activo");

            InvalidarResultados();
            pnlNumeros.Invalidate();

            lblEstado.Text      = "Editor limpio. Listo.";
            lblEstado.ForeColor = ColorTexto;
        }

        // ================================================================
        // Eventos del Editor y Numeración
        // ================================================================
        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            pnlNumeros.Invalidate();

            if (_suprimiendoCambio) return;

            if (_resultadosValidos)
            {
                InvalidarResultados();
                ActualizarBarraEstado(null);
                lblEstado.Text      = "Código modificado. Resultados anteriores invalidados. Vuelve a analizar.";
                lblEstado.ForeColor = ColorAdvertencia;
            }
        }

        private void rtbEditor_VScroll(object sender, EventArgs e) => pnlNumeros.Invalidate();
        private void rtbEditor_Resize(object sender, EventArgs e)  => pnlNumeros.Invalidate();
        private void rtbEditor_SelectionChanged(object sender, EventArgs e) => pnlNumeros.Invalidate();

        private void pnlNumeros_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pnlNumeros.BackColor);

            int totalLineas = rtbEditor.Lines.Length;
            if (totalLineas == 0) totalLineas = 1;

            // Ajustar ancho del margen según la cantidad de dígitos
            int digitos = (totalLineas + 1).ToString().Length;
            int anchoRequerido = Math.Max(48, 16 + digitos * 9);
            if (pnlNumeros.Width != anchoRequerido)
            {
                pnlNumeros.Width = anchoRequerido;
                return;
            }

            int primerCharVisible = rtbEditor.GetCharIndexFromPosition(new Point(2, 2));
            int primeraLineaVisible = rtbEditor.GetLineFromCharIndex(primerCharVisible);

            using (var brush = new SolidBrush(pnlNumeros.ForeColor))
            using (var fmt   = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near })
            {
                float altoLinea = rtbEditor.Font.GetHeight(e.Graphics);

                for (int i = primeraLineaVisible; i < totalLineas; i++)
                {
                    int charIndex = rtbEditor.GetFirstCharIndexFromLine(i);
                    if (charIndex < 0) break;

                    Point pt = rtbEditor.GetPositionFromCharIndex(charIndex);
                    if (pt.Y > pnlNumeros.Height) break;
                    if (pt.Y + altoLinea < 0) continue;

                    var rect = new RectangleF(0, pt.Y, pnlNumeros.Width - 6, altoLinea + 2);
                    e.Graphics.DrawString((i + 1).ToString(), pnlNumeros.Font, brush, rect, fmt);
                }

                // Si el editor termina con salto de línea, dibujar la línea virtual final
                if (rtbEditor.TextLength > 0)
                {
                    char ult = rtbEditor.Text[rtbEditor.TextLength - 1];
                    if (ult == '\n' || ult == '\r')
                    {
                        Point ptFin = rtbEditor.GetPositionFromCharIndex(rtbEditor.TextLength);
                        if (ptFin.Y <= pnlNumeros.Height && ptFin.Y + altoLinea >= 0)
                        {
                            var rectFin = new RectangleF(0, ptFin.Y, pnlNumeros.Width - 6, altoLinea + 2);
                            e.Graphics.DrawString((totalLineas + 1).ToString(), pnlNumeros.Font, brush, rectFin, fmt);
                        }
                    }
                }
            }
        }

        // ================================================================
        // Mostrar resultados en las tablas y resumen
        // ================================================================
        private void MostrarResultados(ResultadoAnalisis r)
        {
            // ---- Tokens ----
            dgvTokens.Rows.Clear();
            int n = 1;
            foreach (var t in r.Tokens)
            {
                string lex = EscaparParaGrid(t.Lexema);
                dgvTokens.Rows.Add(n++, lex, t.TipoToken, t.Linea, t.Columna);
            }

            // ---- Errores ----
            dgvErrores.Rows.Clear();
            if (r.Errores.Count == 0)
            {
                lblSinErrores.Visible = true;
                dgvErrores.Visible    = false;
            }
            else
            {
                lblSinErrores.Visible = false;
                dgvErrores.Visible    = true;
                int ne = 1;
                foreach (var err in r.Errores)
                {
                    string seq = EscaparParaGrid(err.CaracterInvalido);
                    dgvErrores.Rows.Add(ne++, seq, err.Linea, err.Columna, err.Descripcion);
                }
            }

            // ---- Símbolos ----
            dgvSimbolos.Rows.Clear();
            int ns = 1;
            foreach (var s in r.Simbolos)
            {
                dgvSimbolos.Rows.Add(ns++, s.NombreIdentificador, s.TipoToken,
                                     s.LineaPrimeraAparicion, s.ColumnaInicio);
            }

            // ---- Estadísticas, Resumen y Estado ----
            MostrarEstadisticas(r);
            ActualizarResumen(r);
            ActualizarBarraEstado(r);
        }

        private void MostrarEstadisticas(ResultadoAnalisis r)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=============================================================");
            sb.AppendLine("  ESTADÍSTICAS DEL ANÁLISIS LÉXICO");
            sb.AppendLine($"  Fecha y hora: {r.FechaHora:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"  Fuente      : {r.NombreFuente}");
            sb.AppendLine("=============================================================");
            sb.AppendLine($"Tokens totales reconocidos : {r.Tokens.Count}");
            sb.AppendLine($"Errores léxicos detectados : {r.Errores.Count}");
            sb.AppendLine($"Identificadores únicos     : {r.Simbolos.Count}");
            sb.AppendLine($"Total de líneas procesadas : {r.TotalLineas}");
            sb.AppendLine($"Tiempo de ejecución        : {r.TiempoMs} ms");
            sb.AppendLine();

            var conteos = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var t in r.Tokens)
            {
                if (!conteos.ContainsKey(t.TipoToken)) conteos[t.TipoToken] = 0;
                conteos[t.TipoToken]++;
            }

            sb.AppendLine("Distribución de tokens por categoría:");
            int suma = 0;
            foreach (var kv in conteos)
            {
                sb.AppendLine($"  {kv.Key,-30} : {kv.Value}");
                suma += kv.Value;
            }
            sb.AppendLine("  " + new string('-', 45));
            sb.AppendLine($"  {"TOTAL TOKENS",-30} : {suma}");

            _suprimiendoCambio   = true;
            txtEstadisticas.Text = sb.ToString();
            _suprimiendoCambio   = false;
        }

        private void ActualizarResumen(ResultadoAnalisis r)
        {
            if (r == null)
            {
                lblResumenTokens.Text   = "Tokens: 0";
                lblResumenErrores.Text  = "Errores: 0";
                lblResumenErrores.ForeColor = Color.FromArgb(0, 200, 80);
                lblResumenSimbolos.Text = "Símbolos: 0";
                lblResumenLineas.Text   = "Líneas: 0";
                lblResumenTiempo.Text   = "Tiempo: 0 ms";
            }
            else
            {
                lblResumenTokens.Text   = $"Tokens: {r.Tokens.Count}";
                lblResumenErrores.Text  = $"Errores: {r.Errores.Count}";
                lblResumenErrores.ForeColor = r.Errores.Count > 0 ? ColorError : Color.FromArgb(0, 200, 80);
                lblResumenSimbolos.Text = $"Símbolos: {r.Simbolos.Count}";
                lblResumenLineas.Text   = $"Líneas: {r.TotalLineas}";
                lblResumenTiempo.Text   = $"Tiempo: {r.TiempoMs} ms";
            }
        }

        private void ActualizarBarraEstado(ResultadoAnalisis r)
        {
            if (r == null)
            {
                lblEstado.Text      = "Listo";
                lblEstado.ForeColor = ColorTexto;
            }
            else if (r.Errores.Count > 0)
            {
                lblEstado.Text      = $"Análisis completado: {r.Tokens.Count} tokens, {r.Errores.Count} errores detectados ({r.TiempoMs} ms).";
                lblEstado.ForeColor = ColorError;
            }
            else
            {
                lblEstado.Text      = $"Análisis completado con éxito: {r.Tokens.Count} tokens, 0 errores ({r.TiempoMs} ms).";
                lblEstado.ForeColor = Color.FromArgb(0, 200, 80);
            }
        }

        private void InvalidarResultados()
        {
            _resultadosValidos  = false;
            _ultimoResultado    = null;
            btnExportar.Enabled = false;

            dgvTokens.Rows.Clear();
            dgvErrores.Rows.Clear();
            dgvSimbolos.Rows.Clear();

            _suprimiendoCambio   = true;
            txtEstadisticas.Clear();
            _suprimiendoCambio   = false;

            lblSinErrores.Visible = false;
            dgvErrores.Visible    = true;

            ActualizarResumen(null);
        }

        /// <summary>
        /// Representación visible para las celdas del DataGridView en tiempo de ejecución.
        /// </summary>
        private static string EscaparParaGrid(string s)
        {
            if (s == null) return "";
            return s.Replace("\r\n", "↵")
                    .Replace("\r", "↵")
                    .Replace("\n", "↵")
                    .Replace("\t", "→");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

