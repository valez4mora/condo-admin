namespace UI.Forms
{
    partial class FrmFacturas
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnEmitirPendientes = new System.Windows.Forms.Button();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstadoFiltro = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPropiedadFiltro = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.splitPrincipal = new System.Windows.Forms.SplitContainer();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.pnlListaTitulo = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.tblResumen = new System.Windows.Forms.TableLayoutPanel();
            this.lblIdFacturaLbl = new System.Windows.Forms.Label();
            this.lblFechaLbl = new System.Windows.Forms.Label();
            this.lblPropiedadLbl = new System.Windows.Forms.Label();
            this.lblColonesLbl = new System.Windows.Forms.Label();
            this.lblDolaresLbl = new System.Windows.Forms.Label();
            this.lblEstadoLbl = new System.Windows.Forms.Label();
            this.lblIdFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.lblColones = new System.Windows.Forms.Label();
            this.lblDolares = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnAnular = new System.Windows.Forms.Button();
            this.txtEmailDestinatario = new System.Windows.Forms.TextBox();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.btnEnviarCorreo = new System.Windows.Forms.Button();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.btnExportarXml = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.pnlListaTitulo.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.tblResumen.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.btnEmitirPendientes);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1388, 86);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 54);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(348, 17);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Consulte, descargue, envíe y controle las facturas emitidas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(253, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de facturas";
            // 
            // btnEmitirPendientes
            // 
            this.btnEmitirPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmitirPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnEmitirPendientes.FlatAppearance.BorderSize = 0;
            this.btnEmitirPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitirPendientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEmitirPendientes.ForeColor = System.Drawing.Color.White;
            this.btnEmitirPendientes.Location = new System.Drawing.Point(2188, 24);
            this.btnEmitirPendientes.Name = "btnEmitirPendientes";
            this.btnEmitirPendientes.Size = new System.Drawing.Size(205, 40);
            this.btnEmitirPendientes.TabIndex = 2;
            this.btnEmitirPendientes.Text = "+ Emitir cargos pendientes";
            this.btnEmitirPendientes.UseVisualStyleBackColor = false;
            this.btnEmitirPendientes.Click += new System.EventHandler(this.btnEmitirPendientes_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.btnActualizar);
            this.pnlFiltros.Controls.Add(this.btnLimpiarFiltro);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.chkFechas);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.lblEstadoFiltro);
            this.pnlFiltros.Controls.Add(this.cmbPropiedad);
            this.pnlFiltros.Controls.Add(this.lblPropiedadFiltro);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 86);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlFiltros.Size = new System.Drawing.Size(1388, 116);
            this.pnlFiltros.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(2283, 33);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 32);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLimpiarFiltro.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(925, 33);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(105, 32);
            this.btnLimpiarFiltro.TabIndex = 1;
            this.btnLimpiarFiltro.Text = "Limpiar";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(817, 33);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 32);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Aplicar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(690, 36);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(672, 40);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(13, 15);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "a";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(554, 36);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(112, 23);
            this.dtpDesde.TabIndex = 5;
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.Location = new System.Drawing.Point(554, 15);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(109, 19);
            this.chkFechas.TabIndex = 6;
            this.chkFechas.Text = "Filtrar por fecha";
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Emitida",
            "Pagada",
            "Anulada"});
            this.cmbEstado.Location = new System.Drawing.Point(414, 36);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(125, 23);
            this.cmbEstado.TabIndex = 7;
            // 
            // lblEstadoFiltro
            // 
            this.lblEstadoFiltro.AutoSize = true;
            this.lblEstadoFiltro.Location = new System.Drawing.Point(414, 15);
            this.lblEstadoFiltro.Name = "lblEstadoFiltro";
            this.lblEstadoFiltro.Size = new System.Drawing.Size(42, 15);
            this.lblEstadoFiltro.TabIndex = 8;
            this.lblEstadoFiltro.Text = "Estado";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Location = new System.Drawing.Point(214, 36);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(185, 23);
            this.cmbPropiedad.TabIndex = 9;
            // 
            // lblPropiedadFiltro
            // 
            this.lblPropiedadFiltro.AutoSize = true;
            this.lblPropiedadFiltro.Location = new System.Drawing.Point(214, 15);
            this.lblPropiedadFiltro.Name = "lblPropiedadFiltro";
            this.lblPropiedadFiltro.Size = new System.Drawing.Size(61, 15);
            this.lblPropiedadFiltro.TabIndex = 10;
            this.lblPropiedadFiltro.Text = "Propiedad";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(24, 36);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(175, 23);
            this.txtBuscar.TabIndex = 11;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(24, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(91, 15);
            this.lblBuscar.TabIndex = 12;
            this.lblBuscar.Text = "N.° o propiedad";
            // 
            // splitPrincipal
            // 
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.Location = new System.Drawing.Point(0, 202);
            this.splitPrincipal.Name = "splitPrincipal";
            this.splitPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPrincipal.Panel1
            // 
            this.splitPrincipal.Panel1.Controls.Add(this.dgvFacturas);
            this.splitPrincipal.Panel1.Controls.Add(this.pnlListaTitulo);
            // 
            // splitPrincipal.Panel2
            // 
            this.splitPrincipal.Panel2.Controls.Add(this.pnlDetalle);
            this.splitPrincipal.Panel2.Controls.Add(this.pnlAcciones);
            this.splitPrincipal.Size = new System.Drawing.Size(1388, 654);
            this.splitPrincipal.SplitterDistance = 464;
            this.splitPrincipal.SplitterWidth = 6;
            this.splitPrincipal.TabIndex = 0;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 44);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(1388, 420);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.SelectionChanged += new System.EventHandler(this.dgvFacturas_SelectionChanged);
            // 
            // pnlListaTitulo
            // 
            this.pnlListaTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlListaTitulo.Controls.Add(this.lblResultados);
            this.pnlListaTitulo.Controls.Add(this.lblListado);
            this.pnlListaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListaTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlListaTitulo.Name = "pnlListaTitulo";
            this.pnlListaTitulo.Size = new System.Drawing.Size(1388, 44);
            this.pnlListaTitulo.TabIndex = 1;
            // 
            // lblResultados
            // 
            this.lblResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblResultados.Location = new System.Drawing.Point(2188, 14);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(205, 20);
            this.lblResultados.TabIndex = 0;
            this.lblResultados.Text = "0 facturas encontradas";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblListado.Location = new System.Drawing.Point(24, 12);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(126, 20);
            this.lblListado.TabIndex = 1;
            this.lblListado.Text = "Facturas emitidas";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.tblResumen);
            this.pnlDetalle.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new System.Windows.Forms.Padding(24, 8, 24, 12);
            this.pnlDetalle.Size = new System.Drawing.Size(1388, 118);
            this.pnlDetalle.TabIndex = 0;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(24, 112);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(1340, 0);
            this.dgvDetalle.TabIndex = 0;
            // 
            // tblResumen
            // 
            this.tblResumen.ColumnCount = 6;
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.7F));
            this.tblResumen.Controls.Add(this.lblIdFacturaLbl, 0, 0);
            this.tblResumen.Controls.Add(this.lblFechaLbl, 1, 0);
            this.tblResumen.Controls.Add(this.lblPropiedadLbl, 2, 0);
            this.tblResumen.Controls.Add(this.lblColonesLbl, 3, 0);
            this.tblResumen.Controls.Add(this.lblDolaresLbl, 4, 0);
            this.tblResumen.Controls.Add(this.lblEstadoLbl, 5, 0);
            this.tblResumen.Controls.Add(this.lblIdFactura, 0, 1);
            this.tblResumen.Controls.Add(this.lblFecha, 1, 1);
            this.tblResumen.Controls.Add(this.lblPropiedad, 2, 1);
            this.tblResumen.Controls.Add(this.lblColones, 3, 1);
            this.tblResumen.Controls.Add(this.lblDolares, 4, 1);
            this.tblResumen.Controls.Add(this.lblEstado, 5, 1);
            this.tblResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblResumen.Location = new System.Drawing.Point(24, 44);
            this.tblResumen.Name = "tblResumen";
            this.tblResumen.RowCount = 2;
            this.tblResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tblResumen.Size = new System.Drawing.Size(1340, 68);
            this.tblResumen.TabIndex = 1;
            // 
            // lblIdFacturaLbl
            // 
            this.lblIdFacturaLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdFacturaLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblIdFacturaLbl.Location = new System.Drawing.Point(3, 0);
            this.lblIdFacturaLbl.Name = "lblIdFacturaLbl";
            this.lblIdFacturaLbl.Size = new System.Drawing.Size(217, 25);
            this.lblIdFacturaLbl.TabIndex = 0;
            this.lblIdFacturaLbl.Text = "FACTURA";
            this.lblIdFacturaLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFechaLbl
            // 
            this.lblFechaLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaLbl.Location = new System.Drawing.Point(226, 0);
            this.lblFechaLbl.Name = "lblFechaLbl";
            this.lblFechaLbl.Size = new System.Drawing.Size(217, 25);
            this.lblFechaLbl.TabIndex = 1;
            this.lblFechaLbl.Text = "FECHA";
            this.lblFechaLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblPropiedadLbl
            // 
            this.lblPropiedadLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPropiedadLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblPropiedadLbl.Location = new System.Drawing.Point(449, 0);
            this.lblPropiedadLbl.Name = "lblPropiedadLbl";
            this.lblPropiedadLbl.Size = new System.Drawing.Size(217, 25);
            this.lblPropiedadLbl.TabIndex = 2;
            this.lblPropiedadLbl.Text = "PROPIEDAD";
            this.lblPropiedadLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblColonesLbl
            // 
            this.lblColonesLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColonesLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblColonesLbl.Location = new System.Drawing.Point(672, 0);
            this.lblColonesLbl.Name = "lblColonesLbl";
            this.lblColonesLbl.Size = new System.Drawing.Size(217, 25);
            this.lblColonesLbl.TabIndex = 3;
            this.lblColonesLbl.Text = "TOTAL COLONES";
            this.lblColonesLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDolaresLbl
            // 
            this.lblDolaresLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDolaresLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblDolaresLbl.Location = new System.Drawing.Point(895, 0);
            this.lblDolaresLbl.Name = "lblDolaresLbl";
            this.lblDolaresLbl.Size = new System.Drawing.Size(217, 25);
            this.lblDolaresLbl.TabIndex = 4;
            this.lblDolaresLbl.Text = "TOTAL DÓLARES";
            this.lblDolaresLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblEstadoLbl
            // 
            this.lblEstadoLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoLbl.ForeColor = System.Drawing.Color.DimGray;
            this.lblEstadoLbl.Location = new System.Drawing.Point(1118, 0);
            this.lblEstadoLbl.Name = "lblEstadoLbl";
            this.lblEstadoLbl.Size = new System.Drawing.Size(219, 25);
            this.lblEstadoLbl.TabIndex = 5;
            this.lblEstadoLbl.Text = "ESTADO";
            this.lblEstadoLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblIdFactura
            // 
            this.lblIdFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdFactura.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblIdFactura.Location = new System.Drawing.Point(3, 25);
            this.lblIdFactura.Name = "lblIdFactura";
            this.lblIdFactura.Size = new System.Drawing.Size(217, 43);
            this.lblIdFactura.TabIndex = 6;
            this.lblIdFactura.Text = "—";
            this.lblIdFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(226, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(217, 43);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "—";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPropiedad.Location = new System.Drawing.Point(449, 25);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(217, 43);
            this.lblPropiedad.TabIndex = 8;
            this.lblPropiedad.Text = "—";
            this.lblPropiedad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblColones
            // 
            this.lblColones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColones.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblColones.Location = new System.Drawing.Point(672, 25);
            this.lblColones.Name = "lblColones";
            this.lblColones.Size = new System.Drawing.Size(217, 43);
            this.lblColones.TabIndex = 9;
            this.lblColones.Text = "—";
            this.lblColones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDolares
            // 
            this.lblDolares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDolares.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDolares.Location = new System.Drawing.Point(895, 25);
            this.lblDolares.Name = "lblDolares";
            this.lblDolares.Size = new System.Drawing.Size(217, 43);
            this.lblDolares.TabIndex = 10;
            this.lblDolares.Text = "—";
            this.lblDolares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(1118, 25);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEstado.Size = new System.Drawing.Size(219, 43);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "—";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleTitulo
            // 
            this.lblDetalleTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(24, 8);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(1340, 36);
            this.lblDetalleTitulo.TabIndex = 2;
            this.lblDetalleTitulo.Text = "Detalle de la factura seleccionada";
            this.lblDetalleTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlAcciones.Controls.Add(this.btnAnular);
            this.pnlAcciones.Controls.Add(this.txtEmailDestinatario);
            this.pnlAcciones.Controls.Add(this.lblEmailLbl);
            this.pnlAcciones.Controls.Add(this.btnEnviarCorreo);
            this.pnlAcciones.Controls.Add(this.btnExportarPdf);
            this.pnlAcciones.Controls.Add(this.btnExportarXml);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 118);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1388, 66);
            this.pnlAcciones.TabIndex = 1;
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnAnular.Enabled = false;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(2251, 17);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(142, 34);
            this.btnAnular.TabIndex = 0;
            this.btnAnular.Text = "Anular factura";
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // txtEmailDestinatario
            // 
            this.txtEmailDestinatario.Enabled = false;
            this.txtEmailDestinatario.Location = new System.Drawing.Point(322, 29);
            this.txtEmailDestinatario.Name = "txtEmailDestinatario";
            this.txtEmailDestinatario.Size = new System.Drawing.Size(250, 23);
            this.txtEmailDestinatario.TabIndex = 1;
            // 
            // lblEmailLbl
            // 
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.Location = new System.Drawing.Point(319, 8);
            this.lblEmailLbl.Name = "lblEmailLbl";
            this.lblEmailLbl.Size = new System.Drawing.Size(129, 15);
            this.lblEmailLbl.TabIndex = 2;
            this.lblEmailLbl.Text = "Enviar copia por correo";
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnEnviarCorreo.Enabled = false;
            this.btnEnviarCorreo.FlatAppearance.BorderSize = 0;
            this.btnEnviarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarCorreo.ForeColor = System.Drawing.Color.White;
            this.btnEnviarCorreo.Location = new System.Drawing.Point(580, 24);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(112, 30);
            this.btnEnviarCorreo.TabIndex = 3;
            this.btnEnviarCorreo.Text = "Enviar";
            this.btnEnviarCorreo.UseVisualStyleBackColor = false;
            this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnExportarPdf.Enabled = false;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Location = new System.Drawing.Point(164, 17);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(132, 34);
            this.btnExportarPdf.TabIndex = 4;
            this.btnExportarPdf.Text = "Descargar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnExportarXml
            // 
            this.btnExportarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.btnExportarXml.Enabled = false;
            this.btnExportarXml.FlatAppearance.BorderSize = 0;
            this.btnExportarXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarXml.ForeColor = System.Drawing.Color.White;
            this.btnExportarXml.Location = new System.Drawing.Point(24, 17);
            this.btnExportarXml.Name = "btnExportarXml";
            this.btnExportarXml.Size = new System.Drawing.Size(132, 34);
            this.btnExportarXml.TabIndex = 5;
            this.btnExportarXml.Text = "Descargar XML";
            this.btnExportarXml.UseVisualStyleBackColor = false;
            this.btnExportarXml.Click += new System.EventHandler(this.btnExportarXml_Click);
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1388, 856);
            this.Controls.Add(this.splitPrincipal);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "FrmFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Facturas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.pnlListaTitulo.ResumeLayout(false);
            this.pnlListaTitulo.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.tblResumen.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlEncabezado, pnlFiltros, pnlListaTitulo, pnlDetalle, pnlAcciones;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblBuscar, lblPropiedadFiltro, lblEstadoFiltro, lblHasta, lblResultados, lblListado, lblDetalleTitulo;
        private System.Windows.Forms.Label lblIdFacturaLbl, lblIdFactura, lblFechaLbl, lblFecha, lblPropiedadLbl, lblPropiedad, lblColonesLbl, lblColones, lblDolaresLbl, lblDolares, lblEstadoLbl, lblEstado, lblEmailLbl;
        private System.Windows.Forms.Button btnEmitirPendientes, btnActualizar, btnLimpiarFiltro, btnFiltrar, btnAnular, btnEnviarCorreo, btnExportarPdf, btnExportarXml;
        private System.Windows.Forms.TextBox txtBuscar, txtEmailDestinatario;
        private System.Windows.Forms.ComboBox cmbPropiedad, cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.DataGridView dgvFacturas, dgvDetalle;
        private System.Windows.Forms.TableLayoutPanel tblResumen;
    }
}
