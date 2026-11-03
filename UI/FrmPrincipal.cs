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
    /// Formulario principal de C-extended | Analizador lexico y sintactico.
    /// Organizacion: barra de acciones (arriba)  editor con numeracion (izquierda) 
    ///               pestanas de resultados (derecha)  panel de resumen (abajo) 
    ///               barra de estado (inferior).
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        // ----------------------------------------------------------------
        // Estado de la sesion
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
            InicializarDiccionario();
            InicializarSintaxis();
            InicializarNavegacion();
        }

        private void InicializarEstadoFormulario()
        {
            btnExportar.Enabled = false;
            lblFuente.Text      = "Codigo escrito en el editor";
            toolTipPrincipal.SetToolTip(lblFuente, "Editor de codigo activo");
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
                Title       = "Cargar archivo de codigo",
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
        /// Lee un archivo de texto aplicando deteccion y consumo riguroso de BOM,
        /// validacion estricta de codificacion (sin sustitucion silenciosa con U+FFFD)
        /// y rechazo claro de codificaciones no admitidas como UTF-32.
        /// </summary>

        public static bool IntentarLeerArchivo(
        string ruta,
        out string contenido,
        out string errorMensaje)
        {
            if (!IntentarDecodificarArchivo(
                ruta, out contenido, out errorMensaje))
            {
                return false;
            }

            if (contenido.IndexOf('\0') >= 0)
            {
                contenido = null;
                errorMensaje =
                    "El archivo contiene caracteres nulos y no puede " +
                    "cargarse como codigo de texto.\n" +
                    "Guardalo nuevamente como texto UTF-8.";

                return false;
            }

            return true;
        }

        private static bool IntentarDecodificarArchivo(string ruta, out string contenido, out string errorMensaje)
        {
            contenido = null;
            errorMensaje = null;
            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);

                // Archivo vacio
                if (bytes.Length == 0)
                {
                    contenido = "";
                    return true;
                }

                // 1. Detectar firmas de 4 bytes (UTF-32 LE y BE)
                if (bytes.Length >= 4 && bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0x00 && bytes[3] == 0x00)
                {
                    errorMensaje = "La codificacion detectada es UTF-32 LE, la cual no esta admitida por el analizador.\nPor favor guarde el archivo en codificacion UTF-8 o UTF-16.";
                    return false;
                }
                if (bytes.Length >= 4 && bytes[0] == 0x00 && bytes[1] == 0x00 && bytes[2] == 0xFE && bytes[3] == 0xFF)
                {
                    errorMensaje = "La codificacion detectada es UTF-32 BE, la cual no esta admitida por el analizador.\nPor favor guarde el archivo en codificacion UTF-8 o UTF-16.";
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
                        errorMensaje = "El archivo presenta encabezado UTF-8 (BOM) pero contiene bytes no validos para la codificacion UTF-8.";
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
                        errorMensaje = "El archivo presenta encabezado UTF-16 LE pero contiene secuencias de bytes no validas.";
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
                        errorMensaje = "El archivo presenta encabezado UTF-16 BE pero contiene secuencias de bytes no validas.";
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

                // 6. Decodificacion estricta UTF-8 sin BOM
                try
                {
                    var encUtf8Strict = new UTF8Encoding(false, throwOnInvalidBytes: true);
                    contenido = encUtf8Strict.GetString(bytes, 0, bytes.Length);
                    return true;
                }
                catch (DecoderFallbackException)
                {
                    errorMensaje = "El archivo no contiene una codificacion UTF-8 valida y fue rechazado para evitar distorsion del codigo fuente.\nGuarde el archivo como texto UTF-8.";
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
            temporizadorAnalisis.Stop();
            string texto = rtbEditor.Text;
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Escribe o carga codigo antes de analizar.",
                    "Editor vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fuente = string.IsNullOrEmpty(_rutaArchivoCargado)
                ? "Codigo escrito en el editor"
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
                InvalidarResultados();

                MessageBox.Show(
                    $"Ocurrio un error inesperado durante el analisis lexico o sintactico:\n{ex.Message}",
                    "Error del analizador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblEstado.Text = "Error en analisis: " + ex.Message;
                lblEstado.ForeColor = ColorError;
            }
        }

        // ---- Exportar ----
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_ultimoResultado == null || !_resultadosValidos)
            {
                MessageBox.Show("Realiza un analisis antes de exportar.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new SaveFileDialog
            {
                Title       = "Exportar resultados del analisis",
                Filter      = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                FilterIndex = 1,
                FileName    = "resultados_c_extended.txt"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                if (EsArchivoFuente(dlg.FileName))
                {
                    MessageBox.Show("Elige otro nombre: el informe no debe sobrescribir el codigo fuente cargado.",
                        "Proteger codigo fuente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Exportador.ExportarTxt(dlg.FileName, _ultimoResultado);

                    MessageBox.Show($"Resultados exportados correctamente en:\n{dlg.FileName}",
                        "Exportacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error al escribir el archivo:\n{ex.Message}",
                        "Error de escritura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Sin permisos para escribir en la ubicacion seleccionada.",
                        "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool EsArchivoFuente(string destino)
        {
            return !string.IsNullOrEmpty(_rutaArchivoCargado) &&
                string.Equals(Path.GetFullPath(destino), Path.GetFullPath(_rutaArchivoCargado),
                    StringComparison.OrdinalIgnoreCase);
        }

        // ---- Limpiar ----
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _suprimiendoCambio  = true;
            rtbEditor.Clear();
            _suprimiendoCambio  = false;

            _rutaArchivoCargado = null;
            lblFuente.Text      = "Codigo escrito en el editor";
            toolTipPrincipal.SetToolTip(lblFuente, "Editor de codigo activo");

            InvalidarResultados();
            pnlNumeros.Invalidate();

            lblEstado.Text      = "Editor limpio. Listo.";
            lblEstado.ForeColor = ColorTexto;
        }

        // ================================================================
        // Eventos del Editor y Numeracion
        // ================================================================
        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            pnlNumeros.Invalidate();

            if (_suprimiendoCambio) return;

            temporizadorAnalisis.Stop();
            InvalidarResultados();
            ActualizarBarraEstado(null);
            if (!string.IsNullOrWhiteSpace(rtbEditor.Text))
            {
                lblEstado.Text = "Codigo modificado. Actualizando analisis...";
                temporizadorAnalisis.Start();
            }
        }
        private void rtbEditor_VScroll(object sender, EventArgs e) => pnlNumeros.Invalidate();
        private void rtbEditor_Resize(object sender, EventArgs e)  => pnlNumeros.Invalidate();
        private void rtbEditor_SelectionChanged(object sender, EventArgs e) => pnlNumeros.Invalidate();

        private void pnlNumeros_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pnlNumeros.BackColor);

            int totalLineas = Math.Max(1, rtbEditor.Lines.Length);

            // Ajustar el margen a la cantidad real de lineas.
            int digitos = totalLineas.ToString().Length;
            int anchoRequerido = Math.Max(48, 16 + digitos * 9);

            if (pnlNumeros.Width != anchoRequerido)
            {
                pnlNumeros.Width = anchoRequerido;
                pnlNumeros.Invalidate();
                return;
            }

            int primerCharVisible =
                rtbEditor.GetCharIndexFromPosition(new Point(2, 2));

            int primeraLineaVisible =
                rtbEditor.GetLineFromCharIndex(primerCharVisible);

            using (var brush = new SolidBrush(pnlNumeros.ForeColor))
            using (var fmt = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near
            })
            {
                float altoLinea = rtbEditor.Font.GetHeight(e.Graphics);

                for (int i = primeraLineaVisible; i < totalLineas; i++)
                {
                    int charIndex = rtbEditor.GetFirstCharIndexFromLine(i);
                    if (charIndex < 0) break;

                    Point pt = rtbEditor.GetPositionFromCharIndex(charIndex);

                    if (pt.Y > pnlNumeros.Height) break;
                    if (pt.Y + altoLinea < 0) continue;

                    var rect = new RectangleF(
                        0, pt.Y, pnlNumeros.Width - 6, altoLinea + 2);

                    e.Graphics.DrawString(
                        (i + 1).ToString(),
                        pnlNumeros.Font,
                        brush,
                        rect,
                        fmt);
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
                lblSinErrores.Text = r.ErroresSintacticos.Count > 0
                    ? "No se encontraron errores lexicos.\nHay errores sintacticos; consulta su pestana."
                    : "No se encontraron errores lexicos.\nConsulta tambien el resultado sintactico.";
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

            // ---- Simbolos ----
            dgvSimbolos.Rows.Clear();
            int ns = 1;
            foreach (var s in r.Simbolos)
            {
                dgvSimbolos.Rows.Add(ns++, s.NombreIdentificador, s.TipoToken,
                                     s.LineaPrimeraAparicion, s.ColumnaInicio);
            }

            // ---- Estadisticas, Resumen y Estado ----
            MostrarSintaxis(r);
            MostrarEstadisticas(r);
            ActualizarResumen(r);
            ActualizarBarraEstado(r);
        }

        private void MostrarEstadisticas(ResultadoAnalisis r)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=============================================================");
            sb.AppendLine("  ESTADISTICAS DEL ANALISIS LEXICO Y SINTACTICO");
            sb.AppendLine($"  Fecha y hora: {r.FechaHora:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"  Fuente      : {r.NombreFuente}");
            sb.AppendLine("=============================================================");
            sb.AppendLine($"Tokens totales reconocidos : {r.Tokens.Count}");
            sb.AppendLine($"Errores lexicos detectados : {r.Errores.Count}");
            sb.AppendLine("Estado sintactico          : " + (r.SintaxisEvaluada ? "Evaluado" : "Pendiente por errores lexicos"));
            sb.AppendLine("Errores sintacticos        : " + (r.SintaxisEvaluada ? r.ErroresSintacticos.Count.ToString() : "No evaluados"));
            sb.AppendLine("Errores totales detectados : " + r.TotalErrores);
            sb.AppendLine("Estructuras procesadas     : " + (r.SintaxisEvaluada ? r.TotalInstrucciones.ToString() : "No evaluadas"));
            sb.AppendLine("Declaraciones encontradas  : " + (r.SintaxisEvaluada ? r.Declaraciones.Count.ToString() : "No evaluadas"));
            sb.AppendLine("Tiempo lexico              : " + r.TiempoMs + " ms");
            sb.AppendLine("Tiempo sintactico          : " + (r.SintaxisEvaluada ? r.TiempoSintacticoMs + " ms" : "No evaluado"));
            sb.AppendLine($"Identificadores unicos     : {r.Simbolos.Count}");
            sb.AppendLine($"Total de lineas procesadas : {r.TotalLineas}");
            sb.AppendLine($"Tiempo total                : {r.TiempoTotalMs} ms");
            sb.AppendLine();

            var conteos = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var t in r.Tokens)
            {
                if (!conteos.ContainsKey(t.TipoToken)) conteos[t.TipoToken] = 0;
                conteos[t.TipoToken]++;
            }

            sb.AppendLine("Distribucion de tokens por categoria:");
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
                lblResumenErrores.ForeColor = ColorTexto;
                toolTipPrincipal.SetToolTip(lblResumenErrores, "Sin resultados vigentes. Ambas etapas estan pendientes.");
                lblResumenSimbolos.Text = "Simbolos: 0";
                lblResumenLineas.Text   = "Lineas: 0";
                lblResumenTiempo.Text   = "Tiempo: 0 ms";
            }
            else
            {
                lblResumenTokens.Text   = $"Tokens: {r.Tokens.Count}";
                lblResumenErrores.Text  = $"Errores: {r.TotalErrores}";
                toolTipPrincipal.SetToolTip(lblResumenErrores, "Lexicos: " + r.Errores.Count + "; sintacticos: " + (r.SintaxisEvaluada ? r.ErroresSintacticos.Count.ToString() : "pendientes"));
                lblResumenErrores.ForeColor = r.TotalErrores > 0 ? ColorError : Color.FromArgb(0, 200, 80);
                lblResumenSimbolos.Text = $"Simbolos: {r.Simbolos.Count}";
                lblResumenLineas.Text   = $"Lineas: {r.TotalLineas}";
                lblResumenTiempo.Text   = $"Tiempo: {r.TiempoTotalMs} ms";
            }
        }

        private void ActualizarBarraEstado(ResultadoAnalisis r)
        {
            if (r == null)
            {
                lblEstado.Text      = "Listo";
                lblEstado.ForeColor = ColorTexto;
            }
            else if (r.TotalErrores > 0)
            {
                lblEstado.Text      = $"Analisis completado: {r.Tokens.Count} tokens, {r.Errores.Count} errores lexicos, sintacticos: {(r.SintaxisEvaluada ? r.ErroresSintacticos.Count.ToString() : "pendientes")} ({r.TiempoTotalMs} ms).";
                lblEstado.ForeColor = ColorError;
            }
            else
            {
                lblEstado.Text      = $"Analisis completado con exito: {r.Tokens.Count} tokens, 0 errores lexicos y sintacticos ({r.TiempoTotalMs} ms).";
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
            if (dgvSintacticos != null)
            {
                dgvSintacticos.Rows.Clear();
                lblEstadoSintactico.Text = "Pendiente de analisis.";
                lblEstadoSintactico.ForeColor = ColorTexto;
            }

            _suprimiendoCambio   = true;
            txtEstadisticas.Clear();
            _suprimiendoCambio   = false;

            lblSinErrores.Visible = false;
            dgvErrores.Visible    = true;

            ActualizarResumen(null);
            ActualizarBarraEstado(null);
        }

        /// <summary>
        /// Representacion visible para las celdas del DataGridView en tiempo de ejecucion.
        /// </summary>
        private static string EscaparParaGrid(string s)
        {
            if (s == null) return "";
            return s.Replace("\r\n", "")
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Replace("\t", "->");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

