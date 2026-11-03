using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using C_Extended.Core;

namespace C_Extended.UI
{
    public partial class FrmPrincipal
    {
        private Timer temporizadorAnalisis;
        private DataGridView dgvDiccionario;
        private TextBox txtPalabra;
        private TextBox txtDescripcionPalabra;
        private ComboBox cboTipoPalabra;
        private string palabraSeleccionada;

        private void InicializarDiccionario()
        {
            temporizadorAnalisis = new Timer(components) { Interval = 400 };
            temporizadorAnalisis.Tick += (s, e) => {
                temporizadorAnalisis.Stop();
                if (!string.IsNullOrWhiteSpace(rtbEditor.Text)) btnAnalizar_Click(s, e);
            };
            var pagina = new TabPage("Diccionario") {
                BackColor = Color.FromArgb(28, 28, 28), ForeColor = ColorTexto
            };
            var campos = new TableLayoutPanel {
                Dock = DockStyle.Top, Height = 200, ColumnCount = 2, RowCount = 4,
                Padding = new Padding(8)
            };
            campos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            campos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            txtPalabra = new TextBox { Dock = DockStyle.Fill };
            txtDescripcionPalabra = new TextBox { Dock = DockStyle.Fill };
            cboTipoPalabra = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            txtPalabra.BackColor = Color.FromArgb(40, 40, 40);
            txtPalabra.ForeColor = ColorTexto;
            txtDescripcionPalabra.BackColor = Color.FromArgb(40, 40, 40);
            txtDescripcionPalabra.ForeColor = ColorTexto;
            cboTipoPalabra.BackColor = Color.FromArgb(40, 40, 40);
            cboTipoPalabra.ForeColor = ColorTexto;
            cboTipoPalabra.FlatStyle = FlatStyle.Flat;
            cboTipoPalabra.Items.AddRange(new object[] { "TK_RESERVADA", "TK_IDENTIFICADOR" });
            cboTipoPalabra.SelectedIndex = 0;
            campos.Controls.Add(new Label { Text = "Palabra", AutoSize = true }, 0, 0);
            campos.Controls.Add(txtPalabra, 1, 0);
            campos.Controls.Add(new Label { Text = "Tipo", AutoSize = true }, 0, 1);
            campos.Controls.Add(cboTipoPalabra, 1, 1);
            campos.Controls.Add(new Label { Text = "Descripción", AutoSize = true }, 0, 2);
            campos.Controls.Add(txtDescripcionPalabra, 1, 2);
            var acciones = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
            AgregarAccion(acciones, "Nuevo", () => LimpiarEntrada());
            AgregarAccion(acciones, "Agregar", () => GuardarPalabra(false));
            AgregarAccion(acciones, "Modificar", () => GuardarPalabra(true));
            AgregarAccion(acciones, "Eliminar", EliminarPalabra);
            campos.Controls.Add(acciones, 0, 3);
            campos.SetColumnSpan(acciones, 2);
            dgvDiccionario = new DataGridView {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false, MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoGenerateColumns = true, BackgroundColor = dgvTokens.BackgroundColor
            };
            dgvDiccionario.EnableHeadersVisualStyles = false;
            dgvDiccionario.GridColor = Color.FromArgb(65, 65, 65);
            dgvDiccionario.DefaultCellStyle = new DataGridViewCellStyle {
                BackColor = Color.FromArgb(28, 28, 28), ForeColor = ColorTexto,
                SelectionBackColor = ColorAcento, SelectionForeColor = Color.White
            };
            dgvDiccionario.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle {
                BackColor = Color.FromArgb(40, 40, 40)
            };
            dgvDiccionario.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle {
                BackColor = Color.FromArgb(50, 50, 50), ForeColor = ColorTexto,
                SelectionBackColor = Color.FromArgb(50, 50, 50), SelectionForeColor = ColorTexto
            };
            dgvDiccionario.RowHeadersDefaultCellStyle = new DataGridViewCellStyle {
                BackColor = Color.FromArgb(50, 50, 50), ForeColor = ColorTexto,
                SelectionBackColor = ColorAcento, SelectionForeColor = Color.White
            };
            dgvDiccionario.SelectionChanged += (s, e) => {
                var entrada = dgvDiccionario.CurrentRow == null ? null :
                    dgvDiccionario.CurrentRow.DataBoundItem as EntradaDiccionario;
                if (entrada == null) return;
                palabraSeleccionada = entrada.Palabra;
                txtPalabra.Text = entrada.Palabra;
                cboTipoPalabra.SelectedItem = entrada.Tipo;
                txtDescripcionPalabra.Text = entrada.Descripcion;
            };
            pagina.Controls.Add(dgvDiccionario);
            pagina.Controls.Add(campos);
            tabResultados.TabPages.Add(pagina);
            try { RefrescarDiccionario(); }
            catch (Exception ex) { MessageBox.Show("No se pudo leer el diccionario: " + ex.Message); }
        }

        private void AgregarAccion(FlowLayoutPanel panel, string texto, Action accion)
        {
            var boton = new Button {
                Text = texto, AutoSize = true, Height = 30,
                BackColor = Color.FromArgb(0, 90, 158), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, UseVisualStyleBackColor = false,
                Cursor = Cursors.Hand
            };
            boton.FlatAppearance.BorderColor = ColorAcento;
            boton.Click += (s, e) => accion();
            panel.Controls.Add(boton);
        }

        private void LimpiarEntrada()
        {
            dgvDiccionario.ClearSelection();
            palabraSeleccionada = null;
            txtPalabra.Clear();
            txtDescripcionPalabra.Clear();
            cboTipoPalabra.SelectedIndex = 0;
            txtPalabra.Focus();
        }

        private void RefrescarDiccionario()
        {
            dgvDiccionario.DataSource = AutomataAFD.ObtenerDiccionario().OrderBy(x => x.Palabra).ToList();
            LimpiarEntrada();
        }

        private void GuardarPalabra(bool modificar)
        {
            if (modificar && palabraSeleccionada == null)
            {
                MessageBox.Show("Selecciona la palabra que deseas modificar.");
                return;
            }
            try
            {
                AutomataAFD.GuardarEntrada(modificar ? palabraSeleccionada : null,
                    txtPalabra.Text, (string)cboTipoPalabra.SelectedItem, txtDescripcionPalabra.Text);
                RefrescarDiccionario();
                ActualizarPorDiccionario();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Diccionario", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void EliminarPalabra()
        {
            if (palabraSeleccionada == null)
            {
                MessageBox.Show("Selecciona la palabra que deseas eliminar.");
                return;
            }
            if (MessageBox.Show("¿Eliminar '" + palabraSeleccionada + "' del diccionario?",
                "Diccionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                AutomataAFD.EliminarEntrada(palabraSeleccionada);
                RefrescarDiccionario();
                ActualizarPorDiccionario();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Diccionario", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void ActualizarPorDiccionario()
        {
            if (!string.IsNullOrWhiteSpace(rtbEditor.Text)) btnAnalizar_Click(this, EventArgs.Empty);
            else InvalidarResultados();
        }
    }
}
