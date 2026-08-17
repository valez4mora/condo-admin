namespace UI.Forms
{
    partial class FrmBitacora
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.FlowLayoutPanel flpBotones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvento;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TableLayoutPanel tlpDetalle;
        private System.Windows.Forms.Label lblDetalleFechaTitulo;
        private System.Windows.Forms.Label lblDetalleFecha;
        private System.Windows.Forms.Label lblDetalleUsuarioTitulo;
        private System.Windows.Forms.Label lblDetalleUsuario;
        private System.Windows.Forms.Label lblDetalleIdTitulo;
        private System.Windows.Forms.Label lblDetalleId;
        private System.Windows.Forms.Label lblDetalleEventoTitulo;
        private System.Windows.Forms.TextBox txtDetalleEvento;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.splitPrincipal = new System.Windows.Forms.SplitContainer();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.tlpDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.lblDetalleFechaTitulo = new System.Windows.Forms.Label();
            this.lblDetalleFecha = new System.Windows.Forms.Label();
            this.lblDetalleUsuarioTitulo = new System.Windows.Forms.Label();
            this.lblDetalleUsuario = new System.Windows.Forms.Label();
            this.lblDetalleIdTitulo = new System.Windows.Forms.Label();
            this.lblDetalleId = new System.Windows.Forms.Label();
            this.lblDetalleEventoTitulo = new System.Windows.Forms.Label();
            this.txtDetalleEvento = new System.Windows.Forms.TextBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.flpBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            this.tlpDetalle.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            this.flpBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlEncabezado.Controls.Add(this.btnActualizar);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Padding = new System.Windows.Forms.Padding(28, 18, 28, 16);
            this.pnlEncabezado.Size = new System.Drawing.Size(1245, 92);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(164)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(1093, 27);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(124, 38);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 55);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(415, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Consulta de acciones y eventos importantes registrados en el sistema";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 19F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(27, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(248, 36);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bitácora y auditoría";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlContenido.Controls.Add(this.splitPrincipal);
            this.pnlContenido.Controls.Add(this.grpFiltros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 92);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContenido.Size = new System.Drawing.Size(1245, 669);
            this.pnlContenido.TabIndex = 1;
            // 
            // splitPrincipal
            // 
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPrincipal.Location = new System.Drawing.Point(24, 172);
            this.splitPrincipal.Name = "splitPrincipal";
            // 
            // splitPrincipal.Panel1
            // 
            this.splitPrincipal.Panel1.Controls.Add(this.pnlTabla);
            this.splitPrincipal.Panel1.Padding = new System.Windows.Forms.Padding(0, 12, 8, 0);
            // 
            // splitPrincipal.Panel2
            // 
            this.splitPrincipal.Panel2.Controls.Add(this.grpDetalle);
            this.splitPrincipal.Panel2.Padding = new System.Windows.Forms.Padding(8, 12, 0, 0);
            this.splitPrincipal.Size = new System.Drawing.Size(1197, 473);
            this.splitPrincipal.SplitterDistance = 851;
            this.splitPrincipal.TabIndex = 1;
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.dgvBitacora);
            this.pnlTabla.Controls.Add(this.pnlResumen);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(0, 12);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTabla.Size = new System.Drawing.Size(843, 461);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AllowUserToResizeRows = false;
            this.dgvBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dgvBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBitacora.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBitacora.ColumnHeadersHeight = 42;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(251)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBitacora.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.EnableHeadersVisualStyles = false;
            this.dgvBitacora.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvBitacora.Location = new System.Drawing.Point(1, 1);
            this.dgvBitacora.MultiSelect = false;
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.RowHeadersVisible = false;
            this.dgvBitacora.RowTemplate.Height = 36;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(841, 417);
            this.dgvBitacora.TabIndex = 0;
            this.dgvBitacora.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBitacora_CellFormatting);
            this.dgvBitacora.SelectionChanged += new System.EventHandler(this.dgvBitacora_SelectionChanged);
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblResultados);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(1, 418);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(841, 42);
            this.pnlResumen.TabIndex = 1;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblResultados.Location = new System.Drawing.Point(14, 13);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(127, 15);
            this.lblResultados.TabIndex = 0;
            this.lblResultados.Text = "0 eventos encontrados";
            // 
            // grpDetalle
            // 
            this.grpDetalle.BackColor = System.Drawing.Color.White;
            this.grpDetalle.Controls.Add(this.tlpDetalle);
            this.grpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetalle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpDetalle.Location = new System.Drawing.Point(8, 12);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Padding = new System.Windows.Forms.Padding(18, 12, 18, 18);
            this.grpDetalle.Size = new System.Drawing.Size(334, 461);
            this.grpDetalle.TabIndex = 0;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle del evento";
            // 
            // tlpDetalle
            // 
            this.tlpDetalle.ColumnCount = 2;
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalle.Controls.Add(this.lblDetalleFechaTitulo, 0, 0);
            this.tlpDetalle.Controls.Add(this.lblDetalleFecha, 1, 0);
            this.tlpDetalle.Controls.Add(this.lblDetalleUsuarioTitulo, 0, 1);
            this.tlpDetalle.Controls.Add(this.lblDetalleUsuario, 1, 1);
            this.tlpDetalle.Controls.Add(this.lblDetalleIdTitulo, 0, 2);
            this.tlpDetalle.Controls.Add(this.lblDetalleId, 1, 2);
            this.tlpDetalle.Controls.Add(this.lblDetalleEventoTitulo, 0, 3);
            this.tlpDetalle.Controls.Add(this.txtDetalleEvento, 0, 4);
            this.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalle.Location = new System.Drawing.Point(18, 30);
            this.tlpDetalle.Name = "tlpDetalle";
            this.tlpDetalle.RowCount = 5;
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalle.Size = new System.Drawing.Size(298, 413);
            this.tlpDetalle.TabIndex = 0;
            // 
            // lblDetalleFechaTitulo
            // 
            this.lblDetalleFechaTitulo.AutoSize = true;
            this.lblDetalleFechaTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleFechaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDetalleFechaTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblDetalleFechaTitulo.Name = "lblDetalleFechaTitulo";
            this.lblDetalleFechaTitulo.Size = new System.Drawing.Size(86, 38);
            this.lblDetalleFechaTitulo.TabIndex = 0;
            this.lblDetalleFechaTitulo.Text = "Fecha:";
            this.lblDetalleFechaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleFecha
            // 
            this.lblDetalleFecha.AutoEllipsis = true;
            this.lblDetalleFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetalleFecha.Location = new System.Drawing.Point(95, 0);
            this.lblDetalleFecha.Name = "lblDetalleFecha";
            this.lblDetalleFecha.Size = new System.Drawing.Size(200, 38);
            this.lblDetalleFecha.TabIndex = 1;
            this.lblDetalleFecha.Text = "—";
            this.lblDetalleFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleUsuarioTitulo
            // 
            this.lblDetalleUsuarioTitulo.AutoSize = true;
            this.lblDetalleUsuarioTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleUsuarioTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDetalleUsuarioTitulo.Location = new System.Drawing.Point(3, 38);
            this.lblDetalleUsuarioTitulo.Name = "lblDetalleUsuarioTitulo";
            this.lblDetalleUsuarioTitulo.Size = new System.Drawing.Size(86, 38);
            this.lblDetalleUsuarioTitulo.TabIndex = 2;
            this.lblDetalleUsuarioTitulo.Text = "Usuario:";
            this.lblDetalleUsuarioTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleUsuario
            // 
            this.lblDetalleUsuario.AutoEllipsis = true;
            this.lblDetalleUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetalleUsuario.Location = new System.Drawing.Point(95, 38);
            this.lblDetalleUsuario.Name = "lblDetalleUsuario";
            this.lblDetalleUsuario.Size = new System.Drawing.Size(200, 38);
            this.lblDetalleUsuario.TabIndex = 3;
            this.lblDetalleUsuario.Text = "—";
            this.lblDetalleUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleIdTitulo
            // 
            this.lblDetalleIdTitulo.AutoSize = true;
            this.lblDetalleIdTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleIdTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDetalleIdTitulo.Location = new System.Drawing.Point(3, 76);
            this.lblDetalleIdTitulo.Name = "lblDetalleIdTitulo";
            this.lblDetalleIdTitulo.Size = new System.Drawing.Size(86, 38);
            this.lblDetalleIdTitulo.TabIndex = 4;
            this.lblDetalleIdTitulo.Text = "ID evento:";
            this.lblDetalleIdTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleId
            // 
            this.lblDetalleId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetalleId.Location = new System.Drawing.Point(95, 76);
            this.lblDetalleId.Name = "lblDetalleId";
            this.lblDetalleId.Size = new System.Drawing.Size(200, 38);
            this.lblDetalleId.TabIndex = 5;
            this.lblDetalleId.Text = "—";
            this.lblDetalleId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalleEventoTitulo
            // 
            this.lblDetalleEventoTitulo.AutoSize = true;
            this.tlpDetalle.SetColumnSpan(this.lblDetalleEventoTitulo, 2);
            this.lblDetalleEventoTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalleEventoTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDetalleEventoTitulo.Location = new System.Drawing.Point(3, 114);
            this.lblDetalleEventoTitulo.Name = "lblDetalleEventoTitulo";
            this.lblDetalleEventoTitulo.Size = new System.Drawing.Size(292, 34);
            this.lblDetalleEventoTitulo.TabIndex = 6;
            this.lblDetalleEventoTitulo.Text = "Descripción completa";
            this.lblDetalleEventoTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDetalleEvento
            // 
            this.txtDetalleEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtDetalleEvento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpDetalle.SetColumnSpan(this.txtDetalleEvento, 2);
            this.txtDetalleEvento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalleEvento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetalleEvento.Location = new System.Drawing.Point(3, 151);
            this.txtDetalleEvento.Multiline = true;
            this.txtDetalleEvento.Name = "txtDetalleEvento";
            this.txtDetalleEvento.ReadOnly = true;
            this.txtDetalleEvento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleEvento.Size = new System.Drawing.Size(292, 259);
            this.txtDetalleEvento.TabIndex = 7;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.tlpFiltros);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpFiltros.Location = new System.Drawing.Point(24, 24);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(18, 10, 18, 14);
            this.grpFiltros.Size = new System.Drawing.Size(1197, 148);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de consulta";
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.ColumnCount = 5;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tlpFiltros.Controls.Add(this.lblDesde, 0, 0);
            this.tlpFiltros.Controls.Add(this.lblHasta, 1, 0);
            this.tlpFiltros.Controls.Add(this.lblUsuario, 2, 0);
            this.tlpFiltros.Controls.Add(this.lblBuscar, 3, 0);
            this.tlpFiltros.Controls.Add(this.dtpDesde, 0, 1);
            this.tlpFiltros.Controls.Add(this.dtpHasta, 1, 1);
            this.tlpFiltros.Controls.Add(this.cmbUsuario, 2, 1);
            this.tlpFiltros.Controls.Add(this.txtBuscar, 3, 1);
            this.tlpFiltros.Controls.Add(this.flpBotones, 4, 1);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Location = new System.Drawing.Point(18, 28);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 2;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltros.Size = new System.Drawing.Size(1161, 106);
            this.tlpFiltros.TabIndex = 0;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDesde.Location = new System.Drawing.Point(3, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(202, 30);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde (opcional)";
            this.lblDesde.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblHasta.Location = new System.Drawing.Point(211, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(202, 30);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta (opcional)";
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(419, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(237, 30);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(662, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(307, 30);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar en los eventos";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(0, 38);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(0, 8, 12, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(196, 23);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(208, 38);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(0, 8, 12, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(196, 23);
            this.dtpHasta.TabIndex = 1;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(416, 38);
            this.cmbUsuario.Margin = new System.Windows.Forms.Padding(0, 8, 12, 0);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(231, 23);
            this.cmbUsuario.TabIndex = 2;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(659, 38);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0, 8, 12, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(301, 24);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // flpBotones
            // 
            this.flpBotones.Controls.Add(this.btnBuscar);
            this.flpBotones.Controls.Add(this.btnLimpiar);
            this.flpBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBotones.Location = new System.Drawing.Point(972, 30);
            this.flpBotones.Margin = new System.Windows.Forms.Padding(0);
            this.flpBotones.Name = "flpBotones";
            this.flpBotones.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flpBotones.Size = new System.Drawing.Size(189, 76);
            this.flpBotones.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(164)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(0, 7);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 34);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLimpiar.Location = new System.Drawing.Point(88, 7);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(82, 34);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1245, 761);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitácora y auditoría";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.tlpDetalle.ResumeLayout(false);
            this.tlpDetalle.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            this.flpBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
