namespace UI.Forms
{
    partial class FrmReportePropiedadesMorosas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblRiesgo;
        private System.Windows.Forms.ComboBox cmbRiesgo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Panel pnlMorosas;
        private System.Windows.Forms.Label lblMorosasTitulo;
        private System.Windows.Forms.Label lblMorosasValor;
        private System.Windows.Forms.Panel pnlDeuda;
        private System.Windows.Forms.Label lblDeudaTitulo;
        private System.Windows.Forms.Label lblDeudaValor;
        private System.Windows.Forms.Panel pnlCargos;
        private System.Windows.Forms.Label lblCargosTitulo;
        private System.Windows.Forms.Label lblCargosValor;
        private System.Windows.Forms.Panel pnlCritico;
        private System.Windows.Forms.Label lblCriticoTitulo;
        private System.Windows.Forms.Label lblCriticoValor;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvMorosas;
        private System.Windows.Forms.Panel pnlSinDatos;
        private System.Windows.Forms.Label lblSinDatosTitulo;
        private System.Windows.Forms.Label lblSinDatosDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.dgvMorosas = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMorosas = new System.Windows.Forms.Panel();
            this.lblMorosasValor = new System.Windows.Forms.Label();
            this.lblMorosasTitulo = new System.Windows.Forms.Label();
            this.pnlDeuda = new System.Windows.Forms.Panel();
            this.lblDeudaValor = new System.Windows.Forms.Label();
            this.lblDeudaTitulo = new System.Windows.Forms.Label();
            this.pnlCargos = new System.Windows.Forms.Panel();
            this.lblCargosValor = new System.Windows.Forms.Label();
            this.lblCargosTitulo = new System.Windows.Forms.Label();
            this.pnlCritico = new System.Windows.Forms.Panel();
            this.lblCriticoValor = new System.Windows.Forms.Label();
            this.lblCriticoTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblRiesgo = new System.Windows.Forms.Label();
            this.cmbRiesgo = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosas)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlMorosas.SuspendLayout();
            this.pnlDeuda.SuspendLayout();
            this.pnlCargos.SuspendLayout();
            this.pnlCritico.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.btnCerrar);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1372, 106);
            this.pnlEncabezado.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(312, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Propiedades morosas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 63);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(471, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Cargos vencidos, deuda acumulada, último pago y nivel de riesgo financiero";
            // 
            // lblActualizado
            // 
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActualizado.ForeColor = System.Drawing.Color.White;
            this.lblActualizado.Location = new System.Drawing.Point(1007, 67);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(305, 20);
            this.lblActualizado.TabIndex = 2;
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1317, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "×";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlContenido.Controls.Add(this.pnlTabla);
            this.pnlContenido.Controls.Add(this.tlpResumen);
            this.pnlContenido.Controls.Add(this.grpFiltros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 106);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContenido.Size = new System.Drawing.Size(1372, 624);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.pnlSinDatos);
            this.pnlTabla.Controls.Add(this.dgvMorosas);
            this.pnlTabla.Controls.Add(this.lblResultado);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 235);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(14);
            this.pnlTabla.Size = new System.Drawing.Size(1324, 365);
            this.pnlTabla.TabIndex = 0;
            // 
            // pnlSinDatos
            // 
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Location = new System.Drawing.Point(948, 277);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(420, 105);
            this.pnlSinDatos.TabIndex = 0;
            this.pnlSinDatos.Visible = false;
            // 
            // lblSinDatosTitulo
            // 
            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosTitulo.Name = "lblSinDatosTitulo";
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblSinDatosTitulo.TabIndex = 0;
            this.lblSinDatosTitulo.Text = "No hay propiedades morosas";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSinDatosDetalle
            // 
            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosDetalle.Name = "lblSinDatosDetalle";
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(420, 105);
            this.lblSinDatosDetalle.TabIndex = 1;
            this.lblSinDatosDetalle.Text = "No existen cargos vencidos para los filtros seleccionados.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvMorosas
            // 
            this.dgvMorosas.AllowUserToAddRows = false;
            this.dgvMorosas.AllowUserToDeleteRows = false;
            this.dgvMorosas.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvMorosas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMorosas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMorosas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMorosas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMorosas.ColumnHeadersHeight = 44;
            this.dgvMorosas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMorosas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMorosas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMorosas.EnableHeadersVisualStyles = false;
            this.dgvMorosas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(228)))));
            this.dgvMorosas.Location = new System.Drawing.Point(14, 46);
            this.dgvMorosas.MultiSelect = false;
            this.dgvMorosas.Name = "dgvMorosas";
            this.dgvMorosas.ReadOnly = true;
            this.dgvMorosas.RowHeadersVisible = false;
            this.dgvMorosas.RowTemplate.Height = 35;
            this.dgvMorosas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMorosas.Size = new System.Drawing.Size(1296, 305);
            this.dgvMorosas.TabIndex = 1;
            this.dgvMorosas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMorosas_CellFormatting);
            // 
            // lblResultado
            // 
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblResultado.Location = new System.Drawing.Point(14, 14);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Padding = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblResultado.Size = new System.Drawing.Size(1296, 32);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "Cargando información financiera...";
            // 
            // tlpResumen
            // 
            this.tlpResumen.ColumnCount = 4;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.Controls.Add(this.pnlMorosas, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlDeuda, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlCargos, 2, 0);
            this.tlpResumen.Controls.Add(this.pnlCritico, 3, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpResumen.Location = new System.Drawing.Point(24, 127);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1324, 108);
            this.tlpResumen.TabIndex = 1;
            // 
            // pnlMorosas
            // 
            this.pnlMorosas.Controls.Add(this.lblMorosasValor);
            this.pnlMorosas.Controls.Add(this.lblMorosasTitulo);
            this.pnlMorosas.Location = new System.Drawing.Point(3, 15);
            this.pnlMorosas.Name = "pnlMorosas";
            this.pnlMorosas.Size = new System.Drawing.Size(200, 78);
            this.pnlMorosas.TabIndex = 0;
            // 
            // lblMorosasValor
            // 
            this.lblMorosasValor.Location = new System.Drawing.Point(0, 0);
            this.lblMorosasValor.Name = "lblMorosasValor";
            this.lblMorosasValor.Size = new System.Drawing.Size(100, 23);
            this.lblMorosasValor.TabIndex = 0;
            // 
            // lblMorosasTitulo
            // 
            this.lblMorosasTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblMorosasTitulo.Name = "lblMorosasTitulo";
            this.lblMorosasTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblMorosasTitulo.TabIndex = 1;
            // 
            // pnlDeuda
            // 
            this.pnlDeuda.Controls.Add(this.lblDeudaValor);
            this.pnlDeuda.Controls.Add(this.lblDeudaTitulo);
            this.pnlDeuda.Location = new System.Drawing.Point(334, 15);
            this.pnlDeuda.Name = "pnlDeuda";
            this.pnlDeuda.Size = new System.Drawing.Size(200, 78);
            this.pnlDeuda.TabIndex = 1;
            // 
            // lblDeudaValor
            // 
            this.lblDeudaValor.Location = new System.Drawing.Point(0, 0);
            this.lblDeudaValor.Name = "lblDeudaValor";
            this.lblDeudaValor.Size = new System.Drawing.Size(100, 23);
            this.lblDeudaValor.TabIndex = 0;
            // 
            // lblDeudaTitulo
            // 
            this.lblDeudaTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblDeudaTitulo.Name = "lblDeudaTitulo";
            this.lblDeudaTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblDeudaTitulo.TabIndex = 1;
            // 
            // pnlCargos
            // 
            this.pnlCargos.Controls.Add(this.lblCargosValor);
            this.pnlCargos.Controls.Add(this.lblCargosTitulo);
            this.pnlCargos.Location = new System.Drawing.Point(665, 15);
            this.pnlCargos.Name = "pnlCargos";
            this.pnlCargos.Size = new System.Drawing.Size(200, 78);
            this.pnlCargos.TabIndex = 2;
            // 
            // lblCargosValor
            // 
            this.lblCargosValor.Location = new System.Drawing.Point(0, 0);
            this.lblCargosValor.Name = "lblCargosValor";
            this.lblCargosValor.Size = new System.Drawing.Size(100, 23);
            this.lblCargosValor.TabIndex = 0;
            // 
            // lblCargosTitulo
            // 
            this.lblCargosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCargosTitulo.Name = "lblCargosTitulo";
            this.lblCargosTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblCargosTitulo.TabIndex = 1;
            // 
            // pnlCritico
            // 
            this.pnlCritico.Controls.Add(this.lblCriticoValor);
            this.pnlCritico.Controls.Add(this.lblCriticoTitulo);
            this.pnlCritico.Location = new System.Drawing.Point(996, 15);
            this.pnlCritico.Name = "pnlCritico";
            this.pnlCritico.Size = new System.Drawing.Size(200, 78);
            this.pnlCritico.TabIndex = 3;
            // 
            // lblCriticoValor
            // 
            this.lblCriticoValor.Location = new System.Drawing.Point(0, 0);
            this.lblCriticoValor.Name = "lblCriticoValor";
            this.lblCriticoValor.Size = new System.Drawing.Size(100, 23);
            this.lblCriticoValor.TabIndex = 0;
            // 
            // lblCriticoTitulo
            // 
            this.lblCriticoTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCriticoTitulo.Name = "lblCriticoTitulo";
            this.lblCriticoTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblCriticoTitulo.TabIndex = 1;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblBuscar);
            this.grpFiltros.Controls.Add(this.txtBuscar);
            this.grpFiltros.Controls.Add(this.lblRiesgo);
            this.grpFiltros.Controls.Add(this.cmbRiesgo);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.grpFiltros.Location = new System.Drawing.Point(24, 24);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.grpFiltros.Size = new System.Drawing.Size(1324, 103);
            this.grpFiltros.TabIndex = 2;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Consulta y filtros";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 29);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(170, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar propiedad o propietario";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(23, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(330, 24);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblRiesgo
            // 
            this.lblRiesgo.AutoSize = true;
            this.lblRiesgo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRiesgo.Location = new System.Drawing.Point(378, 29);
            this.lblRiesgo.Name = "lblRiesgo";
            this.lblRiesgo.Size = new System.Drawing.Size(85, 15);
            this.lblRiesgo.TabIndex = 1;
            this.lblRiesgo.Text = "Nivel de riesgo";
            // 
            // cmbRiesgo
            // 
            this.cmbRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRiesgo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRiesgo.Location = new System.Drawing.Point(381, 52);
            this.cmbRiesgo.Name = "cmbRiesgo";
            this.cmbRiesgo.Size = new System.Drawing.Size(205, 25);
            this.cmbRiesgo.TabIndex = 1;
            this.cmbRiesgo.SelectedIndexChanged += new System.EventHandler(this.cmbRiesgo_SelectedIndexChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(610, 45);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 35);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(1179, 45);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 35);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmReportePropiedadesMorosas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1372, 730);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1080, 660);
            this.Name = "FrmReportePropiedadesMorosas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de propiedades morosas";
            this.Load += new System.EventHandler(this.FrmReportePropiedadesMorosas_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosas)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlMorosas.ResumeLayout(false);
            this.pnlDeuda.ResumeLayout(false);
            this.pnlCargos.ResumeLayout(false);
            this.pnlCritico.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
