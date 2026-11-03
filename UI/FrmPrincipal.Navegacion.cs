using System;
using System.Windows.Forms;

namespace C_Extended.UI
{
    public partial class FrmPrincipal
    {
        private void InicializarNavegacion()
        {
            rtbEditor.HideSelection = false;
            dgvErrores.CellDoubleClick += (s, e) => IrAFila(dgvErrores, e.RowIndex, 2, 3);
            dgvSintacticos.CellDoubleClick += (s, e) => IrAFila(dgvSintacticos, e.RowIndex, 2, 3);
            dgvTokens.CellDoubleClick += (s, e) => IrAFila(dgvTokens, e.RowIndex, 3, 4);
            dgvSimbolos.CellDoubleClick += (s, e) => IrAFila(dgvSimbolos, e.RowIndex, 3, 4);
            toolTipPrincipal.SetToolTip(dgvErrores, "Doble clic en una fila para ir al error en el editor.");
            toolTipPrincipal.SetToolTip(dgvSintacticos, "Doble clic para ir al error. La ubicación puede indicar dónde falta un símbolo.");
            toolTipPrincipal.SetToolTip(btnAnalizar, "Analizar ambas etapas (F5).");
            toolTipPrincipal.SetToolTip(btnCargar, "Cargar código (Ctrl+O).");
            toolTipPrincipal.SetToolTip(btnExportar, "Exportar el informe de ambas etapas (Ctrl+E).");
        }

        private void IrAFila(DataGridView tabla, int fila, int columnaLinea, int columnaPosicion)
        {
            if (!_resultadosValidos || fila < 0 || fila >= tabla.Rows.Count) return;
            int linea = Convert.ToInt32(tabla.Rows[fila].Cells[columnaLinea].Value);
            int columna = Convert.ToInt32(tabla.Rows[fila].Cells[columnaPosicion].Value);
            IrAUbicacion(linea, columna);
        }

        private void IrAUbicacion(int linea, int columna)
        {
            string texto = rtbEditor.Text;
            int indice = 0, actual = 1;
            while (indice < texto.Length && actual < linea)
            {
                char c = texto[indice++];
                if (c == '\r')
                {
                    if (indice < texto.Length && texto[indice] == '\n') indice++;
                    actual++;
                }
                else if (c == '\n') actual++;
            }
            int fin = indice;
            while (fin < texto.Length && texto[fin] != '\r' && texto[fin] != '\n') fin++;
            indice = Math.Min(fin, indice + Math.Max(0, columna - 1));
            rtbEditor.Focus();
            rtbEditor.Select(indice, indice < fin ? 1 : 0);
            rtbEditor.ScrollToCaret();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) { btnAnalizar.PerformClick(); return true; }
            if (keyData == (Keys.Control | Keys.O)) { btnCargar.PerformClick(); return true; }
            if (keyData == (Keys.Control | Keys.E)) { btnExportar.PerformClick(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
