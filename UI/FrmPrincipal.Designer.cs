namespace C_Extended.UI
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se debe modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFuente = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlEditorContenedor = new System.Windows.Forms.Panel();
            this.rtbEditor = new System.Windows.Forms.RichTextBox();
            this.pnlNumeros = new System.Windows.Forms.Panel();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.tabResultados = new System.Windows.Forms.TabControl();
            this.tabTokens = new System.Windows.Forms.TabPage();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.colTokenNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokenLexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokenTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokenLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokenColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabErrores = new System.Windows.Forms.TabPage();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.colErrNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrSecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSinErrores = new System.Windows.Forms.Label();
            this.tabSimbolos = new System.Windows.Forms.TabPage();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.colSimNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabEstadisticas = new System.Windows.Forms.TabPage();
            this.txtEstadisticas = new System.Windows.Forms.TextBox();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblResumenTiempo = new System.Windows.Forms.Label();
            this.lblResumenLineas = new System.Windows.Forms.Label();
            this.lblResumenSimbolos = new System.Windows.Forms.Label();
            this.lblResumenErrores = new System.Windows.Forms.Label();
            this.lblResumenTokens = new System.Windows.Forms.Label();
            this.lblResumenTitulo = new System.Windows.Forms.Label();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlEditorContenedor.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.tabResultados.SuspendLayout();
            this.tabTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.tabErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.tabSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.tabEstadisticas.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBarra.Controls.Add(this.btnCargar);
            this.pnlBarra.Controls.Add(this.btnAnalizar);
            this.pnlBarra.Controls.Add(this.btnExportar);
            this.pnlBarra.Controls.Add(this.btnLimpiar);
            this.pnlBarra.Controls.Add(this.lblFuente);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlBarra.Size = new System.Drawing.Size(1200, 48);
            this.pnlBarra.TabIndex = 0;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(8, 9);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(115, 30);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar archivo";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnAnalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAnalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.ForeColor = System.Drawing.Color.White;
            this.btnAnalizar.Location = new System.Drawing.Point(130, 9);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(115, 30);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(252, 9);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(140, 30);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar resultados";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(399, 9);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFuente
            // 
            this.lblFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFuente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFuente.Location = new System.Drawing.Point(510, 6);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(680, 36);
            this.lblFuente.TabIndex = 4;
            this.lblFuente.Text = "Código escrito en el editor";
            this.lblFuente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 48);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlEditorContenedor);
            this.splitMain.Panel1MinSize = 280;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlDerecho);
            this.splitMain.Panel2MinSize = 380;
            this.splitMain.Size = new System.Drawing.Size(1200, 608);
            this.splitMain.SplitterDistance = 440;
            this.splitMain.TabIndex = 1;
            // 
            // pnlEditorContenedor
            // 
            this.pnlEditorContenedor.Controls.Add(this.rtbEditor);
            this.pnlEditorContenedor.Controls.Add(this.pnlNumeros);
            this.pnlEditorContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditorContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditorContenedor.Name = "pnlEditorContenedor";
            this.pnlEditorContenedor.Size = new System.Drawing.Size(440, 608);
            this.pnlEditorContenedor.TabIndex = 0;
            // 
            // rtbEditor
            // 
            this.rtbEditor.AcceptsTab = true;
            this.rtbEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtbEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEditor.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rtbEditor.Location = new System.Drawing.Point(48, 0);
            this.rtbEditor.Name = "rtbEditor";
            this.rtbEditor.Size = new System.Drawing.Size(392, 608);
            this.rtbEditor.TabIndex = 1;
            this.rtbEditor.Text = "";
            this.rtbEditor.WordWrap = false;
            this.rtbEditor.SelectionChanged += new System.EventHandler(this.rtbEditor_SelectionChanged);
            this.rtbEditor.VScroll += new System.EventHandler(this.rtbEditor_VScroll);
            this.rtbEditor.TextChanged += new System.EventHandler(this.rtbEditor_TextChanged);
            this.rtbEditor.Resize += new System.EventHandler(this.rtbEditor_Resize);
            // 
            // pnlNumeros
            // 
            this.pnlNumeros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlNumeros.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNumeros.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNumeros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.pnlNumeros.Location = new System.Drawing.Point(0, 0);
            this.pnlNumeros.Name = "pnlNumeros";
            this.pnlNumeros.Size = new System.Drawing.Size(48, 608);
            this.pnlNumeros.TabIndex = 0;
            this.pnlNumeros.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNumeros_Paint);
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.Controls.Add(this.tabResultados);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Location = new System.Drawing.Point(0, 0);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(756, 608);
            this.pnlDerecho.TabIndex = 0;
            // 
            // tabResultados
            // 
            this.tabResultados.Controls.Add(this.tabTokens);
            this.tabResultados.Controls.Add(this.tabErrores);
            this.tabResultados.Controls.Add(this.tabSimbolos);
            this.tabResultados.Controls.Add(this.tabEstadisticas);
            this.tabResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabResultados.Location = new System.Drawing.Point(0, 0);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.SelectedIndex = 0;
            this.tabResultados.Size = new System.Drawing.Size(756, 608);
            this.tabResultados.TabIndex = 0;
            // 
            // tabTokens
            // 
            this.tabTokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabTokens.Controls.Add(this.dgvTokens);
            this.tabTokens.Location = new System.Drawing.Point(4, 30);
            this.tabTokens.Name = "tabTokens";
            this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
            this.tabTokens.Size = new System.Drawing.Size(748, 574);
            this.tabTokens.TabIndex = 0;
            this.tabTokens.Text = "Tokens";
            // 
            // dgvTokens
            // 
            this.dgvTokens.AllowUserToAddRows = false;
            this.dgvTokens.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvTokens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTokens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTokens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTokenNum,
            this.colTokenLexema,
            this.colTokenTipo,
            this.colTokenLinea,
            this.colTokenColumna});
            this.dgvTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTokens.EnableHeadersVisualStyles = false;
            this.dgvTokens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvTokens.Location = new System.Drawing.Point(3, 3);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.ReadOnly = true;
            this.dgvTokens.RowHeadersVisible = false;
            this.dgvTokens.RowHeadersWidth = 51;
            this.dgvTokens.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvTokens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvTokens.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dgvTokens.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTokens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTokens.Size = new System.Drawing.Size(742, 568);
            this.dgvTokens.TabIndex = 0;
            // 
            // colTokenNum
            // 
            this.colTokenNum.HeaderText = "#";
            this.colTokenNum.MinimumWidth = 6;
            this.colTokenNum.Name = "colTokenNum";
            this.colTokenNum.ReadOnly = true;
            this.colTokenNum.Width = 45;
            // 
            // colTokenLexema
            // 
            this.colTokenLexema.HeaderText = "Lexema";
            this.colTokenLexema.MinimumWidth = 6;
            this.colTokenLexema.Name = "colTokenLexema";
            this.colTokenLexema.ReadOnly = true;
            this.colTokenLexema.Width = 240;
            // 
            // colTokenTipo
            // 
            this.colTokenTipo.HeaderText = "Tipo de token";
            this.colTokenTipo.MinimumWidth = 6;
            this.colTokenTipo.Name = "colTokenTipo";
            this.colTokenTipo.ReadOnly = true;
            this.colTokenTipo.Width = 160;
            // 
            // colTokenLinea
            // 
            this.colTokenLinea.HeaderText = "Línea";
            this.colTokenLinea.MinimumWidth = 6;
            this.colTokenLinea.Name = "colTokenLinea";
            this.colTokenLinea.ReadOnly = true;
            this.colTokenLinea.Width = 65;
            // 
            // colTokenColumna
            // 
            this.colTokenColumna.HeaderText = "Columna";
            this.colTokenColumna.MinimumWidth = 6;
            this.colTokenColumna.Name = "colTokenColumna";
            this.colTokenColumna.ReadOnly = true;
            this.colTokenColumna.Width = 70;
            // 
            // tabErrores
            // 
            this.tabErrores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabErrores.Controls.Add(this.dgvErrores);
            this.tabErrores.Controls.Add(this.lblSinErrores);
            this.tabErrores.Location = new System.Drawing.Point(4, 30);
            this.tabErrores.Name = "tabErrores";
            this.tabErrores.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrores.Size = new System.Drawing.Size(748, 574);
            this.tabErrores.TabIndex = 1;
            this.tabErrores.Text = "Errores léxicos";
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvErrores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colErrNum,
            this.colErrSecuencia,
            this.colErrLinea,
            this.colErrColumna,
            this.colErrDesc});
            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvErrores.Location = new System.Drawing.Point(3, 3);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.RowHeadersWidth = 51;
            this.dgvErrores.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvErrores.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvErrores.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dgvErrores.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(742, 568);
            this.dgvErrores.TabIndex = 0;
            // 
            // colErrNum
            // 
            this.colErrNum.HeaderText = "#";
            this.colErrNum.MinimumWidth = 6;
            this.colErrNum.Name = "colErrNum";
            this.colErrNum.ReadOnly = true;
            this.colErrNum.Width = 45;
            // 
            // colErrSecuencia
            // 
            this.colErrSecuencia.HeaderText = "Secuencia inválida";
            this.colErrSecuencia.MinimumWidth = 6;
            this.colErrSecuencia.Name = "colErrSecuencia";
            this.colErrSecuencia.ReadOnly = true;
            this.colErrSecuencia.Width = 180;
            // 
            // colErrLinea
            // 
            this.colErrLinea.HeaderText = "Línea";
            this.colErrLinea.MinimumWidth = 6;
            this.colErrLinea.Name = "colErrLinea";
            this.colErrLinea.ReadOnly = true;
            this.colErrLinea.Width = 65;
            // 
            // colErrColumna
            // 
            this.colErrColumna.HeaderText = "Columna";
            this.colErrColumna.MinimumWidth = 6;
            this.colErrColumna.Name = "colErrColumna";
            this.colErrColumna.ReadOnly = true;
            this.colErrColumna.Width = 70;
            // 
            // colErrDesc
            // 
            this.colErrDesc.HeaderText = "Descripción";
            this.colErrDesc.MinimumWidth = 6;
            this.colErrDesc.Name = "colErrDesc";
            this.colErrDesc.ReadOnly = true;
            this.colErrDesc.Width = 320;
            // 
            // lblSinErrores
            // 
            this.lblSinErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinErrores.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.lblSinErrores.Location = new System.Drawing.Point(3, 3);
            this.lblSinErrores.Name = "lblSinErrores";
            this.lblSinErrores.Size = new System.Drawing.Size(742, 568);
            this.lblSinErrores.TabIndex = 1;
            this.lblSinErrores.Text = "No se encontraron errores léxicos.";
            this.lblSinErrores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinErrores.Visible = false;
            // 
            // tabSimbolos
            // 
            this.tabSimbolos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabSimbolos.Controls.Add(this.dgvSimbolos);
            this.tabSimbolos.Location = new System.Drawing.Point(4, 30);
            this.tabSimbolos.Name = "tabSimbolos";
            this.tabSimbolos.Size = new System.Drawing.Size(748, 574);
            this.tabSimbolos.TabIndex = 2;
            this.tabSimbolos.Text = "Tabla de símbolos";
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.AllowUserToAddRows = false;
            this.dgvSimbolos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvSimbolos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSimbolos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvSimbolos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSimbolos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSimNum,
            this.colSimIdentificador,
            this.colSimTipo,
            this.colSimLinea,
            this.colSimColumna});
            this.dgvSimbolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSimbolos.EnableHeadersVisualStyles = false;
            this.dgvSimbolos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvSimbolos.Location = new System.Drawing.Point(0, 0);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.ReadOnly = true;
            this.dgvSimbolos.RowHeadersVisible = false;
            this.dgvSimbolos.RowHeadersWidth = 51;
            this.dgvSimbolos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.dgvSimbolos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvSimbolos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dgvSimbolos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSimbolos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSimbolos.Size = new System.Drawing.Size(748, 574);
            this.dgvSimbolos.TabIndex = 0;
            // 
            // colSimNum
            // 
            this.colSimNum.HeaderText = "#";
            this.colSimNum.MinimumWidth = 6;
            this.colSimNum.Name = "colSimNum";
            this.colSimNum.ReadOnly = true;
            this.colSimNum.Width = 45;
            // 
            // colSimIdentificador
            // 
            this.colSimIdentificador.HeaderText = "Identificador";
            this.colSimIdentificador.MinimumWidth = 6;
            this.colSimIdentificador.Name = "colSimIdentificador";
            this.colSimIdentificador.ReadOnly = true;
            this.colSimIdentificador.Width = 200;
            // 
            // colSimTipo
            // 
            this.colSimTipo.HeaderText = "Tipo de token";
            this.colSimTipo.MinimumWidth = 6;
            this.colSimTipo.Name = "colSimTipo";
            this.colSimTipo.ReadOnly = true;
            this.colSimTipo.Width = 150;
            // 
            // colSimLinea
            // 
            this.colSimLinea.HeaderText = "Primera línea";
            this.colSimLinea.MinimumWidth = 6;
            this.colSimLinea.Name = "colSimLinea";
            this.colSimLinea.ReadOnly = true;
            // 
            // colSimColumna
            // 
            this.colSimColumna.HeaderText = "Primera columna";
            this.colSimColumna.MinimumWidth = 6;
            this.colSimColumna.Name = "colSimColumna";
            this.colSimColumna.ReadOnly = true;
            this.colSimColumna.Width = 110;
            // 
            // tabEstadisticas
            // 
            this.tabEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabEstadisticas.Controls.Add(this.txtEstadisticas);
            this.tabEstadisticas.Location = new System.Drawing.Point(4, 30);
            this.tabEstadisticas.Name = "tabEstadisticas";
            this.tabEstadisticas.Padding = new System.Windows.Forms.Padding(6);
            this.tabEstadisticas.Size = new System.Drawing.Size(748, 574);
            this.tabEstadisticas.TabIndex = 3;
            this.tabEstadisticas.Text = "Estadísticas";
            // 
            // txtEstadisticas
            // 
            this.txtEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtEstadisticas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstadisticas.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadisticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtEstadisticas.Location = new System.Drawing.Point(6, 6);
            this.txtEstadisticas.Multiline = true;
            this.txtEstadisticas.Name = "txtEstadisticas";
            this.txtEstadisticas.ReadOnly = true;
            this.txtEstadisticas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEstadisticas.Size = new System.Drawing.Size(736, 562);
            this.txtEstadisticas.TabIndex = 0;
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlResumen.Controls.Add(this.lblResumenTiempo);
            this.pnlResumen.Controls.Add(this.lblResumenLineas);
            this.pnlResumen.Controls.Add(this.lblResumenSimbolos);
            this.pnlResumen.Controls.Add(this.lblResumenErrores);
            this.pnlResumen.Controls.Add(this.lblResumenTokens);
            this.pnlResumen.Controls.Add(this.lblResumenTitulo);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlResumen.Location = new System.Drawing.Point(0, 656);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlResumen.Size = new System.Drawing.Size(1200, 36);
            this.pnlResumen.TabIndex = 2;
            // 
            // lblResumenTiempo
            // 
            this.lblResumenTiempo.AutoSize = true;
            this.lblResumenTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblResumenTiempo.Location = new System.Drawing.Point(585, 10);
            this.lblResumenTiempo.Name = "lblResumenTiempo";
            this.lblResumenTiempo.Size = new System.Drawing.Size(98, 20);
            this.lblResumenTiempo.TabIndex = 5;
            this.lblResumenTiempo.Text = "Tiempo: 0 ms";
            // 
            // lblResumenLineas
            // 
            this.lblResumenLineas.AutoSize = true;
            this.lblResumenLineas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblResumenLineas.Location = new System.Drawing.Point(465, 10);
            this.lblResumenLineas.Name = "lblResumenLineas";
            this.lblResumenLineas.Size = new System.Drawing.Size(65, 20);
            this.lblResumenLineas.TabIndex = 4;
            this.lblResumenLineas.Text = "Líneas: 0";
            // 
            // lblResumenSimbolos
            // 
            this.lblResumenSimbolos.AutoSize = true;
            this.lblResumenSimbolos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblResumenSimbolos.Location = new System.Drawing.Point(335, 10);
            this.lblResumenSimbolos.Name = "lblResumenSimbolos";
            this.lblResumenSimbolos.Size = new System.Drawing.Size(86, 20);
            this.lblResumenSimbolos.TabIndex = 3;
            this.lblResumenSimbolos.Text = "Símbolos: 0";
            // 
            // lblResumenErrores
            // 
            this.lblResumenErrores.AutoSize = true;
            this.lblResumenErrores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.lblResumenErrores.Location = new System.Drawing.Point(215, 10);
            this.lblResumenErrores.Name = "lblResumenErrores";
            this.lblResumenErrores.Size = new System.Drawing.Size(70, 20);
            this.lblResumenErrores.TabIndex = 2;
            this.lblResumenErrores.Text = "Errores: 0";
            // 
            // lblResumenTokens
            // 
            this.lblResumenTokens.AutoSize = true;
            this.lblResumenTokens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblResumenTokens.Location = new System.Drawing.Point(95, 10);
            this.lblResumenTokens.Name = "lblResumenTokens";
            this.lblResumenTokens.Size = new System.Drawing.Size(69, 20);
            this.lblResumenTokens.TabIndex = 1;
            this.lblResumenTokens.Text = "Tokens: 0";
            // 
            // lblResumenTitulo
            // 
            this.lblResumenTitulo.AutoSize = true;
            this.lblResumenTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblResumenTitulo.Location = new System.Drawing.Point(12, 10);
            this.lblResumenTitulo.Name = "lblResumenTitulo";
            this.lblResumenTitulo.Size = new System.Drawing.Size(83, 20);
            this.lblResumenTitulo.TabIndex = 0;
            this.lblResumenTitulo.Text = "RESUMEN:";
            // 
            // pnlEstado
            // 
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlEstado.Controls.Add(this.lblEstado);
            this.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstado.Location = new System.Drawing.Point(0, 692);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.pnlEstado.Size = new System.Drawing.Size(1200, 28);
            this.pnlEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblEstado.Location = new System.Drawing.Point(8, 4);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1184, 20);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Listo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.pnlBarra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C-extended | Analizador léxico";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlBarra.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlEditorContenedor.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.tabTokens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.tabErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.tabSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.tabEstadisticas.ResumeLayout(false);
            this.tabEstadisticas.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlEstado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipPrincipal;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFuente;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlEditorContenedor;
        private System.Windows.Forms.Panel pnlNumeros;
        private System.Windows.Forms.RichTextBox rtbEditor;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.TabControl tabResultados;
        private System.Windows.Forms.TabPage tabTokens;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokenNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokenLexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokenTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokenLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokenColumna;
        private System.Windows.Forms.TabPage tabErrores;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrSecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrDesc;
        private System.Windows.Forms.Label lblSinErrores;
        private System.Windows.Forms.TabPage tabSimbolos;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSimColumna;
        private System.Windows.Forms.TabPage tabEstadisticas;
        private System.Windows.Forms.TextBox txtEstadisticas;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblResumenTitulo;
        private System.Windows.Forms.Label lblResumenTokens;
        private System.Windows.Forms.Label lblResumenErrores;
        private System.Windows.Forms.Label lblResumenSimbolos;
        private System.Windows.Forms.Label lblResumenLineas;
        private System.Windows.Forms.Label lblResumenTiempo;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}

