namespace C_Extended.UI
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ---- Controles declarados ----
            this.toolTipPrincipal  = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBarra          = new System.Windows.Forms.Panel();
            this.btnCargar         = new System.Windows.Forms.Button();
            this.btnAnalizar       = new System.Windows.Forms.Button();
            this.btnExportar       = new System.Windows.Forms.Button();
            this.btnLimpiar        = new System.Windows.Forms.Button();
            this.lblFuente         = new System.Windows.Forms.Label();
            this.splitMain         = new System.Windows.Forms.SplitContainer();
            this.pnlEditorContenedor = new System.Windows.Forms.Panel();
            this.pnlNumeros        = new System.Windows.Forms.Panel();
            this.rtbEditor         = new System.Windows.Forms.RichTextBox();
            this.pnlDerecho        = new System.Windows.Forms.Panel();
            this.tabResultados     = new System.Windows.Forms.TabControl();
            this.tabTokens         = new System.Windows.Forms.TabPage();
            this.dgvTokens         = new System.Windows.Forms.DataGridView();
            this.tabErrores        = new System.Windows.Forms.TabPage();
            this.lblSinErrores     = new System.Windows.Forms.Label();
            this.dgvErrores        = new System.Windows.Forms.DataGridView();
            this.tabSimbolos       = new System.Windows.Forms.TabPage();
            this.dgvSimbolos       = new System.Windows.Forms.DataGridView();
            this.tabEstadisticas   = new System.Windows.Forms.TabPage();
            this.txtEstadisticas   = new System.Windows.Forms.TextBox();
            this.pnlEstado         = new System.Windows.Forms.Panel();
            this.lblEstado         = new System.Windows.Forms.Label();

            // ---- Suspender layout ----
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitMain).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlEditorContenedor.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.tabResultados.SuspendLayout();
            this.tabTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTokens).BeginInit();
            this.tabErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvErrores).BeginInit();
            this.tabSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSimbolos).BeginInit();
            this.tabEstadisticas.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            this.SuspendLayout();

            // ==============================================================
            // pnlBarra — barra de acciones superior
            // ==============================================================
            this.pnlBarra.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Height    = 48;
            this.pnlBarra.Padding   = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlBarra.Controls.AddRange(new System.Windows.Forms.Control[]
            { this.btnCargar, this.btnAnalizar, this.btnExportar, this.btnLimpiar, this.lblFuente });

            ConfigBoton(this.btnCargar,  "Cargar archivo",  0);
            ConfigBoton(this.btnAnalizar,"Analizar",        125);
            ConfigBoton(this.btnExportar,"Exportar resultados", 250);
            ConfigBoton(this.btnLimpiar, "Limpiar",         400);

            this.lblFuente.AutoSize  = false;
            this.lblFuente.Anchor    = System.Windows.Forms.AnchorStyles.Left |
                                       System.Windows.Forms.AnchorStyles.Right |
                                       System.Windows.Forms.AnchorStyles.Top |
                                       System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFuente.Left      = 510;
            this.lblFuente.Top       = 6;
            this.lblFuente.Width     = 480;
            this.lblFuente.Height    = 36;
            this.lblFuente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFuente.Font      = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Italic);

            // ==============================================================
            // splitMain — divisor principal izquierda/derecha
            // ==============================================================
            this.splitMain.Dock             = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.SplitterDistance = 440;
            this.splitMain.Panel1MinSize    = 280;
            this.splitMain.Panel2MinSize    = 380;
            this.splitMain.Panel1.Controls.Add(this.pnlEditorContenedor);
            this.splitMain.Panel2.Controls.Add(this.pnlDerecho);

            // ==============================================================
            // pnlEditorContenedor — contiene numeración + editor
            // ==============================================================
            this.pnlEditorContenedor.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlNumeros.Dock  = System.Windows.Forms.DockStyle.Left;
            this.pnlNumeros.Width = 44;

            this.rtbEditor.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlEditorContenedor.Controls.Add(this.rtbEditor);
            this.pnlEditorContenedor.Controls.Add(this.pnlNumeros);

            // ==============================================================
            // pnlDerecho — pestañas de resultados
            // ==============================================================
            this.pnlDerecho.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Controls.Add(this.tabResultados);

            // ==============================================================
            // tabResultados
            // ==============================================================
            this.tabResultados.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.tabResultados.Font      = new System.Drawing.Font("Segoe UI", 9.5f);
            this.tabResultados.TabPages.AddRange(new System.Windows.Forms.TabPage[]
            { this.tabTokens, this.tabErrores, this.tabSimbolos, this.tabEstadisticas });

            // -- Tab Tokens
            this.tabTokens.Text    = "Tokens";
            this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
            this.dgvTokens.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.tabTokens.Controls.Add(this.dgvTokens);

            // -- Tab Errores
            this.tabErrores.Text = "Errores léxicos";

            this.lblSinErrores.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblSinErrores.Text      = "No se encontraron errores léxicos.";
            this.lblSinErrores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinErrores.Font      = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Italic);
            this.lblSinErrores.Visible   = false;

            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabErrores.Controls.Add(this.dgvErrores);
            this.tabErrores.Controls.Add(this.lblSinErrores);

            // -- Tab Símbolos
            this.tabSimbolos.Text  = "Tabla de símbolos";
            this.dgvSimbolos.Dock  = System.Windows.Forms.DockStyle.Fill;
            this.tabSimbolos.Controls.Add(this.dgvSimbolos);

            // -- Tab Estadísticas
            this.tabEstadisticas.Text = "Estadísticas";
            this.txtEstadisticas.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.txtEstadisticas.Multiline  = true;
            this.txtEstadisticas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEstadisticas.ReadOnly   = true;
            this.txtEstadisticas.Font       = new System.Drawing.Font("Consolas", 10.5f);
            this.tabEstadisticas.Controls.Add(this.txtEstadisticas);

            // ==============================================================
            // pnlEstado — barra de estado inferior
            // ==============================================================
            this.pnlEstado.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstado.Height = 26;
            this.pnlEstado.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

            this.lblEstado.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstado.Font      = new System.Drawing.Font("Segoe UI", 9f);
            this.pnlEstado.Controls.Add(this.lblEstado);

            // ==============================================================
            // Formulario principal
            // ==============================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlEstado);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Text        = "C-extended | Analizador léxico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Suscripciones a eventos
            this.btnCargar.Click      += new System.EventHandler(this.btnCargar_Click);
            this.btnAnalizar.Click    += new System.EventHandler(this.btnAnalizar_Click);
            this.btnExportar.Click    += new System.EventHandler(this.btnExportar_Click);
            this.btnLimpiar.Click     += new System.EventHandler(this.btnLimpiar_Click);
            this.rtbEditor.TextChanged += new System.EventHandler(this.rtbEditor_TextChanged);
            this.rtbEditor.VScroll    += new System.EventHandler(this.rtbEditor_VScroll);

            // ---- Reanudar layout ----
            this.pnlBarra.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.pnlEditorContenedor.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.tabTokens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvTokens).EndInit();
            this.tabErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvErrores).EndInit();
            this.tabSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvSimbolos).EndInit();
            this.tabEstadisticas.ResumeLayout(false);
            this.pnlEstado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitMain).EndInit();
            this.ResumeLayout(false);
        }

        private static void ConfigBoton(System.Windows.Forms.Button btn, string texto, int left)
        {
            btn.Text    = texto;
            btn.Left    = left;
            btn.Top     = 8;
            btn.Width   = 110;
            btn.Height  = 30;
            btn.Anchor  = System.Windows.Forms.AnchorStyles.Left |
                          System.Windows.Forms.AnchorStyles.Top;
        }

        #endregion

        // ---- Campos del diseñador ----
        private System.Windows.Forms.ToolTip           toolTipPrincipal;
        private System.Windows.Forms.Panel             pnlBarra;
        private System.Windows.Forms.Button            btnCargar;
        private System.Windows.Forms.Button            btnAnalizar;
        private System.Windows.Forms.Button            btnExportar;
        private System.Windows.Forms.Button            btnLimpiar;
        private System.Windows.Forms.Label             lblFuente;
        private System.Windows.Forms.SplitContainer    splitMain;
        private System.Windows.Forms.Panel             pnlEditorContenedor;
        private System.Windows.Forms.Panel             pnlNumeros;
        private System.Windows.Forms.RichTextBox       rtbEditor;
        private System.Windows.Forms.Panel             pnlDerecho;
        private System.Windows.Forms.TabControl        tabResultados;
        private System.Windows.Forms.TabPage           tabTokens;
        private System.Windows.Forms.DataGridView      dgvTokens;
        private System.Windows.Forms.TabPage           tabErrores;
        private System.Windows.Forms.Label             lblSinErrores;
        private System.Windows.Forms.DataGridView      dgvErrores;
        private System.Windows.Forms.TabPage           tabSimbolos;
        private System.Windows.Forms.DataGridView      dgvSimbolos;
        private System.Windows.Forms.TabPage           tabEstadisticas;
        private System.Windows.Forms.TextBox           txtEstadisticas;
        private System.Windows.Forms.Panel             pnlEstado;
        private System.Windows.Forms.Label             lblEstado;
        private System.Windows.Forms.Panel             pnlResumen;  // kept for compat reference
    }
}

