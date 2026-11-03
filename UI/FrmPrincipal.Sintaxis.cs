using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace C_Extended.UI
{
    public partial class FrmPrincipal
    {
        private DataGridView dgvSintacticos;
        private Label lblEstadoSintactico;

        private void InicializarSintaxis()
        {
            Text = "C-extended | Analizador lexico y sintactico";
            var pagina = new TabPage("Errores sintacticos") {
                BackColor = Color.FromArgb(28, 28, 28), ForeColor = ColorTexto
            };
            lblEstadoSintactico = new Label {
                Dock = DockStyle.Top, Height = 65, Padding = new Padding(8),
                Text = "Pendiente de analisis.", ForeColor = ColorTexto
            };
            dgvSintacticos = new DataGridView {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false,
                BackgroundColor = dgvTokens.BackgroundColor, EnableHeadersVisualStyles = false,
                DefaultCellStyle = dgvDiccionario.DefaultCellStyle.Clone(),
                AlternatingRowsDefaultCellStyle = dgvDiccionario.AlternatingRowsDefaultCellStyle.Clone(),
                ColumnHeadersDefaultCellStyle = dgvDiccionario.ColumnHeadersDefaultCellStyle.Clone(),
                RowHeadersDefaultCellStyle = dgvDiccionario.RowHeadersDefaultCellStyle.Clone(),
                GridColor = dgvDiccionario.GridColor, RowHeadersVisible = false
            };
            dgvSintacticos.Columns.Add("Numero", "#");
            dgvSintacticos.Columns.Add("Encontrado", "Encontrado");
            dgvSintacticos.Columns.Add("Linea", "Linea");
            dgvSintacticos.Columns.Add("Columna", "Columna");
            dgvSintacticos.Columns.Add("Descripcion", "Descripcion / correccion");
            dgvSintacticos.Columns[2].MinimumWidth = 60;
            dgvSintacticos.Columns[3].MinimumWidth = 75;
            dgvSintacticos.Columns[0].FillWeight = 25;
            dgvSintacticos.Columns[2].FillWeight = 35;
            dgvSintacticos.Columns[3].FillWeight = 35;
            dgvSintacticos.Columns[4].FillWeight = 240;
            var cabecera = new Panel { Dock = DockStyle.Top, Height = 65 };
            lblEstadoSintactico.Dock = DockStyle.Fill;
            var botonAyuda = new Button {
                Name = "btnAyudaSintaxis", Text = "Ayuda", Dock = DockStyle.Right, Width = 85,
                BackColor = Color.FromArgb(0, 90, 158), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, UseVisualStyleBackColor = false, Cursor = Cursors.Hand
            };
            botonAyuda.FlatAppearance.BorderColor = ColorAcento;
            botonAyuda.Click += (s, e) => MostrarAyudaSintaxis();
            cabecera.Controls.Add(lblEstadoSintactico);
            cabecera.Controls.Add(botonAyuda);
            pagina.Controls.Add(dgvSintacticos);
            pagina.Controls.Add(cabecera);
            var paginas = tabResultados.TabPages.Cast<TabPage>().ToList();
            paginas.Insert(2, pagina);
            tabResultados.TabPages.Clear();
            tabResultados.TabPages.AddRange(paginas.ToArray());
            dgvTokens.Columns.Add("UsoSintactico", "Declaracion sintactica");
            dgvSimbolos.Columns.Add("Declaraciones", "Declaraciones encontradas");
            dgvTokens.Columns["UsoSintactico"].MinimumWidth = 200;
            dgvSimbolos.Columns["Declaraciones"].MinimumWidth = 200;
            toolTipPrincipal.SetToolTip(dgvSimbolos,
                "Identificadores lexicos y declaraciones encontradas por nombre. No resuelve ambitos ni verifica tipos.");
        }

        private void MostrarAyudaSintaxis()
        {
            var respuesta = MessageBox.Show(this,
                "Carga un archivo o escribe codigo y pulsa Analizar.\n" +
                "Revisa primero Errores lexicos y despues Errores sintacticos.\n" +
                "Cada error indica su linea, columna y descripcion. Corrige el codigo y vuelve a analizar.\n\n" +
                "Deseas consultar el Manual de Uso completo?",
                "Ayuda rapida", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta != DialogResult.Yes) return;
            try
            {
                string contenido = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Manual_de_Uso.txt"));
                using (var ventana = new Form {
                    Text = "C-Extended | Manual de Uso", Size = new Size(800, 650),
                    StartPosition = FormStartPosition.CenterParent, MinimizeBox = false,
                    BackColor = Color.FromArgb(28, 28, 28), ForeColor = ColorTexto
                })
                {
                    var texto = new TextBox {
                        Dock = DockStyle.Fill, Multiline = true, ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical, WordWrap = true,
                        BackColor = Color.FromArgb(28, 28, 28), ForeColor = ColorTexto,
                        Font = new Font("Segoe UI", 10), Text = contenido
                    };
                    ventana.Controls.Add(texto);
                    ventana.ShowDialog(this);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "No se pudo abrir Manual_de_Uso.txt: " + ex.Message,
                    "Manual de Uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(this, "No se pudo leer el manual: " + ex.Message,
                    "Manual de Uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarSintaxis(ResultadoAnalisis resultado)
        {
            dgvSintacticos.Rows.Clear();
            if (!resultado.SintaxisEvaluada)
            {
                lblEstadoSintactico.Text = "ANALISIS SINTACTICO PENDIENTE: corrige los errores lexicos y vuelve a analizar. No se puede afirmar que la sintaxis sea correcta.";
                lblEstadoSintactico.ForeColor = ColorAdvertencia;
                return;
            }
            lblEstadoSintactico.Text = resultado.ErroresSintacticos.Count == 0
                ? "Sin errores sintacticos segun la gramatica de C-Extended. Esto no verifica tipos ni variables declaradas."
                : "Errores sintacticos: " + resultado.ErroresSintacticos.Count + ". Corrige las primeras filas y vuelve a analizar para reducir errores derivados.";
            lblEstadoSintactico.ForeColor = resultado.ErroresSintacticos.Count == 0 ? Color.FromArgb(0, 200, 80) : ColorError;
            int numero = 1;
            foreach (var error in resultado.ErroresSintacticos)
                dgvSintacticos.Rows.Add(numero++, EscaparParaGrid(error.Encontrado), error.Linea, error.Columna, error.Descripcion);
            foreach (DataGridViewRow fila in dgvTokens.Rows)
            {
                int linea = Convert.ToInt32(fila.Cells[3].Value);
                int columna = Convert.ToInt32(fila.Cells[4].Value);
                var declaracion = resultado.Declaraciones.FirstOrDefault(d => d.Linea == linea && d.Columna == columna);
                fila.Cells[5].Value = declaracion == null ? "" : declaracion.Rol + " (" + declaracion.Tipo + ")";
            }
            foreach (DataGridViewRow fila in dgvSimbolos.Rows)
                fila.Cells[5].Value = string.Join(", ", resultado.Declaraciones
                    .Where(d => d.Nombre == Convert.ToString(fila.Cells[1].Value))
                    .Select(d => d.Rol + " (" + d.Tipo + ")").Distinct());
        }
    }
}
