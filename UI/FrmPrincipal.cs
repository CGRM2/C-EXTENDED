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
    ///               pestañas de resultados (derecha) · panel de resumen (abajo).
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        // ----------------------------------------------------------------
        // Estado de la sesión
        // ----------------------------------------------------------------
        private ResultadoAnalisis _ultimoResultado = null;
        private string            _rutaArchivoCargado = null;
        private bool              _resultadosValidos  = false;
        private bool              _suprimiendoCambio  = false;   // evita ciclos al colorear

        // Color de fondo oscuro del boceto de referencia
        private static readonly Color ColorFondo      = Color.FromArgb(30, 30, 30);
        private static readonly Color ColorTexto      = Color.FromArgb(220, 220, 220);
        private static readonly Color ColorAcento     = Color.FromArgb(0, 122, 204);
        private static readonly Color ColorBorde      = Color.FromArgb(60, 60, 60);
        private static readonly Color ColorFilaAlterna= Color.FromArgb(40, 40, 40);
        private static readonly Color ColorError      = Color.FromArgb(210, 50, 50);
        private static readonly Color ColorAdvertencia= Color.FromArgb(220, 160, 0);

        // ----------------------------------------------------------------
        // Constructor
        // ----------------------------------------------------------------
        public FrmPrincipal()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarEditor();
            ConfigurarTablas();
            ActualizarBarraEstado(null);
        }

        // ================================================================
        // Configuración visual del formulario
        // ================================================================
        private void ConfigurarFormulario()
        {
            this.Text            = "C-extended | Analizador léxico";
            this.BackColor       = ColorFondo;
            this.ForeColor       = ColorTexto;
            this.MinimumSize     = new Size(1000, 640);

            // Botones de la barra de acciones
            EstilarBoton(btnCargar);
            EstilarBoton(btnAnalizar);
            EstilarBoton(btnExportar);
            EstilarBoton(btnLimpiar);
            btnExportar.Enabled = false;

            // Panel de numeración
            pnlNumeros.BackColor = Color.FromArgb(45, 45, 45);
            pnlNumeros.ForeColor = Color.FromArgb(130, 130, 130);

            // Editor
            rtbEditor.BackColor = Color.FromArgb(20, 20, 20);
            rtbEditor.ForeColor = ColorTexto;

            // Pestañas
            tabResultados.BackColor = Color.FromArgb(35, 35, 35);

            // Panel de resumen
            pnlResumen.BackColor = Color.FromArgb(38, 38, 38);

            // Etiqueta de fuente
            lblFuente.ForeColor = ColorTexto;
            lblFuente.Text      = "Código escrito en el editor";
        }

        private static void EstilarBoton(Button btn)
        {
            btn.BackColor  = Color.FromArgb(0, 90, 158);
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
            btn.Cursor     = Cursors.Hand;
        }

        // ================================================================
        // Editor y numeración
        // ================================================================
        private void ConfigurarEditor()
        {
            rtbEditor.Font         = new Font("Consolas", 11f);
            rtbEditor.WordWrap     = false;
            rtbEditor.ScrollBars   = RichTextBoxScrollBars.Both;
            rtbEditor.AcceptsTab   = true;
            pnlNumeros.Font        = new Font("Consolas", 11f);

            // Sincronizar desplazamiento vertical
            rtbEditor.VScroll += (s, e) => pnlNumeros.Invalidate();
            rtbEditor.Resize  += (s, e) => pnlNumeros.Invalidate();

            pnlNumeros.Paint += DibujarNumeros_Paint;
        }

        private void DibujarNumeros_Paint(object sender, PaintEventArgs e)
        {
            if (rtbEditor.Lines.Length == 0) return;

            e.Graphics.Clear(pnlNumeros.BackColor);
            int totalLineas = rtbEditor.Lines.Length;
            int alturaLinea = (int)Math.Round(rtbEditor.Font.GetHeight(e.Graphics));
            if (alturaLinea < 1) alturaLinea = 1;

            // Posición de la primera línea visible considerando el scroll vertical.
            // Usamos GetPositionFromCharIndex para calcular la posición Y de la línea 0.
            int offsetY = 0;
            if (rtbEditor.TextLength > 0)
            {
                Point pt = rtbEditor.GetPositionFromCharIndex(0);
                offsetY = pt.Y;
            }

            var brush = new SolidBrush(pnlNumeros.ForeColor);
            var fmt   = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near };

            for (int i = 0; i < totalLineas; i++)
            {
                int y = offsetY + i * alturaLinea;
                if (y + alturaLinea < 0) continue;
                if (y > pnlNumeros.Height) break;
                var rect = new RectangleF(0, y, pnlNumeros.Width - 4, alturaLinea);
                e.Graphics.DrawString((i + 1).ToString(), pnlNumeros.Font, brush, rect, fmt);
            }
            brush.Dispose();
        }

        // ================================================================
        // Tablas de resultados
        // ================================================================
        private void ConfigurarTablas()
        {
            ConfigurarDataGrid(dgvTokens,
                new[] { "#", "Lexema", "Tipo de token", "Línea", "Columna" },
                new[] { 50,  260,      160,             60,      70 });

            ConfigurarDataGrid(dgvErrores,
                new[] { "#", "Secuencia inválida", "Línea", "Columna", "Descripción" },
                new[] { 50,  180,                   60,      70,        350 });

            ConfigurarDataGrid(dgvSimbolos,
                new[] { "#", "Identificador", "Tipo de token", "Primera línea", "Primera columna" },
                new[] { 50,  200,             140,              100,             110 });
        }

        private void ConfigurarDataGrid(DataGridView dgv, string[] encabezados, int[] anchos)
        {
            dgv.BackgroundColor    = Color.FromArgb(28, 28, 28);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = ColorAcento;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTexto;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor              = ColorBorde;
            dgv.BorderStyle            = BorderStyle.None;
            dgv.RowHeadersVisible      = false;
            dgv.AllowUserToAddRows     = false;
            dgv.AllowUserToDeleteRows  = false;
            dgv.ReadOnly               = true;
            dgv.SelectionMode          = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeRowsMode       = DataGridViewAutoSizeRowsMode.None;
            dgv.RowTemplate.Height     = 22;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFilaAlterna;
            dgv.ScrollBars             = ScrollBars.Both;

            dgv.Columns.Clear();
            for (int i = 0; i < encabezados.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = encabezados[i],
                    Width      = anchos[i],
                    SortMode   = DataGridViewColumnSortMode.Automatic,
                    DefaultCellStyle = { WrapMode = DataGridViewTriState.False }
                };
                dgv.Columns.Add(col);
            }
        }

        // ================================================================
        // EVENTOS DE BOTONES
        // ================================================================

        // ---- Cargar archivo ----
        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog
            {
                Title  = "Cargar archivo de código",
                Filter = "Archivos de texto (*.txt)|*.txt|Archivos C# (*.cs)|*.cs|Todos los archivos (*.*)|*.*",
                FilterIndex = 1
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Detectar BOM; UTF-8 por defecto
                    byte[] bytes = File.ReadAllBytes(dlg.FileName);
                    Encoding enc = DetectarCodificacion(bytes);
                    if (enc == null)
                    {
                        MessageBox.Show(
                            "El archivo seleccionado parece ser un archivo binario o usa una codificación no admitida.\nNo se cargará su contenido.",
                            "Archivo no admitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string contenido = enc.GetString(bytes);
                    CargarContenidoEnEditor(contenido, dlg.FileName);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Sin permisos para leer el archivo.", "Error de acceso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error al leer el archivo:\n{ex.Message}", "Error de lectura",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarContenidoEnEditor(string contenido, string ruta)
        {
            _suprimiendoCambio = true;
            rtbEditor.Text     = contenido;
            _suprimiendoCambio = false;

            _rutaArchivoCargado = ruta;
            lblFuente.Text      = Path.GetFileName(ruta);
            lblFuente.Tag       = ruta; // ruta completa en tooltip
            toolTipPrincipal.SetToolTip(lblFuente, ruta);

            InvalidarResultados();
            pnlNumeros.Invalidate();
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
                texto);

            _resultadosValidos = true;
            btnExportar.Enabled = true;

            MostrarResultados(_ultimoResultado);
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
                Title       = "Exportar resultados",
                Filter      = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                FilterIndex = 1,
                FileName    = "resultados_c_extended.txt"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Exportador.ExportarTxt(
                        dlg.FileName,
                        _ultimoResultado.NombreFuente,
                        _ultimoResultado.Tokens,
                        _ultimoResultado.Errores,
                        _ultimoResultado.Simbolos,
                        _ultimoResultado.TotalLineas,
                        _ultimoResultado.TiempoMs);

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
                    MessageBox.Show("Sin permisos para escribir en esa ubicación.",
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
            toolTipPrincipal.SetToolTip(lblFuente, "");
            InvalidarResultados();
            pnlNumeros.Invalidate();
        }

        // ================================================================
        // Detección de modificaciones en el editor
        // ================================================================
        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            pnlNumeros.Invalidate();

            if (_suprimiendoCambio) return;

            if (_resultadosValidos)
            {
                InvalidarResultados();
                ActualizarBarraEstado(null);
                lblEstado.Text      = "Código modificado. Vuelve a analizar.";
                lblEstado.ForeColor = ColorAdvertencia;
            }
        }

        private void rtbEditor_VScroll(object sender, EventArgs e)
            => pnlNumeros.Invalidate();

        // ================================================================
        // Mostrar resultados en las tablas
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
                    int idx = dgvErrores.Rows.Add(ne++, seq, err.Linea, err.Columna, err.Descripcion);
                    dgvErrores.Rows[idx].DefaultCellStyle.ForeColor = ColorError;
                }
            }

            // ---- Símbolos ----
            dgvSimbolos.Rows.Clear();
            int ns = 1;
            foreach (var s in r.Simbolos)
                dgvSimbolos.Rows.Add(ns++, s.NombreIdentificador, s.TipoToken,
                                     s.LineaPrimeraAparicion, s.ColumnaInicio);

            // ---- Estadísticas ----
            MostrarEstadisticas(r);
            ActualizarBarraEstado(r);
        }

        private void MostrarEstadisticas(ResultadoAnalisis r)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Tokens totales : {r.Tokens.Count}");
            sb.AppendLine($"Errores        : {r.Errores.Count}");
            sb.AppendLine($"Símbolos únicos: {r.Simbolos.Count}");
            sb.AppendLine($"Líneas (motor) : {r.TotalLineas}");
            sb.AppendLine($"Tiempo         : {r.TiempoMs} ms");
            sb.AppendLine();

            var conteos = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var t in r.Tokens)
            {
                if (!conteos.ContainsKey(t.TipoToken)) conteos[t.TipoToken] = 0;
                conteos[t.TipoToken]++;
            }
            sb.AppendLine("Por categoría:");
            int suma = 0;
            foreach (var kv in conteos) { sb.AppendLine($"  {kv.Key}: {kv.Value}"); suma += kv.Value; }
            sb.AppendLine($"  ─────────────────────");
            sb.AppendLine($"  TOTAL: {suma}");

            _suprimiendoCambio    = true;
            txtEstadisticas.Text  = sb.ToString();
            _suprimiendoCambio    = false;
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
                lblEstado.Text      = $"Análisis completado: {r.Tokens.Count} tokens, {r.Errores.Count} errores.";
                lblEstado.ForeColor = ColorError;
            }
            else
            {
                lblEstado.Text      = $"Análisis completado: {r.Tokens.Count} tokens, 0 errores.";
                lblEstado.ForeColor = Color.FromArgb(0, 200, 80);
            }
        }

        private void InvalidarResultados()
        {
            _resultadosValidos    = false;
            _ultimoResultado      = null;
            btnExportar.Enabled   = false;
            dgvTokens.Rows.Clear();
            dgvErrores.Rows.Clear();
            dgvSimbolos.Rows.Clear();

            _suprimiendoCambio    = true;
            txtEstadisticas.Clear();
            _suprimiendoCambio    = false;

            lblSinErrores.Visible = false;
            dgvErrores.Visible    = true;
        }

        // ================================================================
        // Helpers
        // ================================================================
        /// <summary>
        /// Reemplaza caracteres de control por secuencias visibles para el grid.
        /// El valor original del objeto no se modifica.
        /// </summary>
        private static string EscaparParaGrid(string s)
            => s.Replace("\r\n", "↵").Replace("\r", "↵").Replace("\n", "↵").Replace("\t", "→");

        /// <summary>
        /// Detecta la codificación a partir del BOM.
        /// Devuelve null si el archivo parece binario.
        /// </summary>
        private static Encoding DetectarCodificacion(byte[] bytes)
        {
            if (bytes.Length == 0) return Encoding.UTF8;

            // BOM UTF-8
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                return new UTF8Encoding(true);
            // BOM UTF-16 LE
            if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                return Encoding.Unicode;
            // BOM UTF-16 BE
            if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
                return Encoding.BigEndianUnicode;

            // Heurística binaria: presencia de bytes nulos o bytes de control raros
            int binario = 0;
            int limite  = Math.Min(bytes.Length, 4096);
            for (int i = 0; i < limite; i++)
            {
                byte b = bytes[i];
                if (b == 0x00 || (b < 0x08)) binario++;
            }
            if (binario > limite / 20) return null; // probable binario

            return Encoding.UTF8;
        }
    }
}

