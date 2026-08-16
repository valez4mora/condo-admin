namespace UI.Forms
{
    partial class FrmFondoReserva
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.pnlAportes = new System.Windows.Forms.Panel();
            this.lblAportesValor = new System.Windows.Forms.Label();
            this.lblAportesTitulo = new System.Windows.Forms.Label();
            this.pnlPromedio = new System.Windows.Forms.Panel();
            this.lblPromedioValor = new System.Windows.Forms.Label();
            this.lblPromedioTitulo = new System.Windows.Forms.Label();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.dgvFondos = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlAportes.SuspendLayout();
            this.pnlPromedio.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1148, 105);
            this.pnlEncabezado.TabIndex = 4;
            // 
            // lblActualizado
            // 
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblActualizado.Location = new System.Drawing.Point(1748, 42);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(320, 20);
            this.lblActualizado.TabIndex = 0;
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 62);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(398, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Historial de aportes calculados sobre las cuotas de mantenimiento";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(238, 38);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Fondo de reserva";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblPropiedad);
            this.grpFiltros.Controls.Add(this.cmbPropiedad);
            this.grpFiltros.Controls.Add(this.chkUsarFechas);
            this.grpFiltros.Controls.Add(this.lblDesde);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.lblHasta);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.grpFiltros.Location = new System.Drawing.Point(28, 122);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1092, 92);
            this.grpFiltros.TabIndex = 3;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de consulta";
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Location = new System.Drawing.Point(18, 29);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(61, 15);
            this.lblPropiedad.TabIndex = 0;
            this.lblPropiedad.Text = "Propiedad";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Location = new System.Drawing.Point(21, 51);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(220, 23);
            this.cmbPropiedad.TabIndex = 1;
            this.cmbPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedad_SelectedIndexChanged);
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Location = new System.Drawing.Point(269, 29);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(114, 19);
            this.chkUsarFechas.TabIndex = 2;
            this.chkUsarFechas.Text = "Filtrar por fechas";
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(269, 55);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(40, 15);
            this.lblDesde.TabIndex = 3;
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(320, 51);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 23);
            this.dtpDesde.TabIndex = 4;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(449, 55);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(37, 15);
            this.lblHasta.TabIndex = 5;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(496, 51);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 23);
            this.dtpHasta.TabIndex = 6;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(858, 40);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 34);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(975, 40);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 34);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tlpResumen
            // 
            this.tlpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpResumen.ColumnCount = 3;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpResumen.Controls.Add(this.pnlTotal, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlAportes, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlPromedio, 2, 0);
            this.tlpResumen.Location = new System.Drawing.Point(28, 230);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpResumen.Size = new System.Drawing.Size(1092, 88);
            this.tlpResumen.TabIndex = 2;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.Controls.Add(this.lblTotalValor);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(18, 12, 10, 8);
            this.pnlTotal.Size = new System.Drawing.Size(352, 88);
            this.pnlTotal.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblTotalValor.Location = new System.Drawing.Point(18, 36);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(324, 44);
            this.lblTotalValor.TabIndex = 0;
            this.lblTotalValor.Text = "₡0,00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(324, 24);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "TOTAL ACUMULADO";
            // 
            // pnlAportes
            // 
            this.pnlAportes.BackColor = System.Drawing.Color.White;
            this.pnlAportes.Controls.Add(this.lblAportesValor);
            this.pnlAportes.Controls.Add(this.lblAportesTitulo);
            this.pnlAportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAportes.Location = new System.Drawing.Point(364, 0);
            this.pnlAportes.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlAportes.Name = "pnlAportes";
            this.pnlAportes.Padding = new System.Windows.Forms.Padding(18, 12, 10, 8);
            this.pnlAportes.Size = new System.Drawing.Size(351, 88);
            this.pnlAportes.TabIndex = 1;
            // 
            // lblAportesValor
            // 
            this.lblAportesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAportesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblAportesValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblAportesValor.Location = new System.Drawing.Point(18, 36);
            this.lblAportesValor.Name = "lblAportesValor";
            this.lblAportesValor.Size = new System.Drawing.Size(323, 44);
            this.lblAportesValor.TabIndex = 0;
            this.lblAportesValor.Text = "0";
            this.lblAportesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAportesTitulo
            // 
            this.lblAportesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAportesTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblAportesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAportesTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblAportesTitulo.Name = "lblAportesTitulo";
            this.lblAportesTitulo.Size = new System.Drawing.Size(323, 24);
            this.lblAportesTitulo.TabIndex = 1;
            this.lblAportesTitulo.Text = "APORTES REGISTRADOS";
            // 
            // pnlPromedio
            // 
            this.pnlPromedio.BackColor = System.Drawing.Color.White;
            this.pnlPromedio.Controls.Add(this.lblPromedioValor);
            this.pnlPromedio.Controls.Add(this.lblPromedioTitulo);
            this.pnlPromedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPromedio.Location = new System.Drawing.Point(727, 0);
            this.pnlPromedio.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPromedio.Name = "pnlPromedio";
            this.pnlPromedio.Padding = new System.Windows.Forms.Padding(18, 12, 10, 8);
            this.pnlPromedio.Size = new System.Drawing.Size(365, 88);
            this.pnlPromedio.TabIndex = 2;
            // 
            // lblPromedioValor
            // 
            this.lblPromedioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPromedioValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblPromedioValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblPromedioValor.Location = new System.Drawing.Point(18, 36);
            this.lblPromedioValor.Name = "lblPromedioValor";
            this.lblPromedioValor.Size = new System.Drawing.Size(337, 44);
            this.lblPromedioValor.TabIndex = 0;
            this.lblPromedioValor.Text = "₡0,00";
            this.lblPromedioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPromedioTitulo
            // 
            this.lblPromedioTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPromedioTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblPromedioTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPromedioTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblPromedioTitulo.Name = "lblPromedioTitulo";
            this.lblPromedioTitulo.Size = new System.Drawing.Size(337, 24);
            this.lblPromedioTitulo.TabIndex = 1;
            this.lblPromedioTitulo.Text = "APORTE PROMEDIO";
            // 
            // pnlTabla
            // 
            this.pnlTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.pnlSinDatos);
            this.pnlTabla.Controls.Add(this.dgvFondos);
            this.pnlTabla.Controls.Add(this.lblResultado);
            this.pnlTabla.Location = new System.Drawing.Point(28, 336);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(1092, 330);
            this.pnlTabla.TabIndex = 1;
            // 
            // pnlSinDatos
            // 
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Location = new System.Drawing.Point(340, 120);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(410, 90);
            this.pnlSinDatos.TabIndex = 0;
            this.pnlSinDatos.Visible = false;
            // 
            // lblSinDatosDetalle
            // 
            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(0, 35);
            this.lblSinDatosDetalle.Name = "lblSinDatosDetalle";
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(410, 55);
            this.lblSinDatosDetalle.TabIndex = 0;
            this.lblSinDatosDetalle.Text = "Cambie los filtros o genere una cuota de mantenimiento.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSinDatosTitulo
            // 
            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosTitulo.Name = "lblSinDatosTitulo";
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(410, 35);
            this.lblSinDatosTitulo.TabIndex = 1;
            this.lblSinDatosTitulo.Text = "No hay aportes para mostrar";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvFondos
            // 
            this.dgvFondos.AllowUserToAddRows = false;
            this.dgvFondos.AllowUserToDeleteRows = false;
            this.dgvFondos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFondos.BackgroundColor = System.Drawing.Color.White;
            this.dgvFondos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFondos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFondos.ColumnHeadersHeight = 38;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFondos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFondos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFondos.Location = new System.Drawing.Point(0, 42);
            this.dgvFondos.Name = "dgvFondos";
            this.dgvFondos.ReadOnly = true;
            this.dgvFondos.RowHeadersVisible = false;
            this.dgvFondos.RowTemplate.Height = 34;
            this.dgvFondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFondos.Size = new System.Drawing.Size(1092, 288);
            this.dgvFondos.TabIndex = 1;
            // 
            // lblResultado
            // 
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblResultado.Location = new System.Drawing.Point(0, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Padding = new System.Windows.Forms.Padding(14, 12, 0, 0);
            this.lblResultado.Size = new System.Drawing.Size(1092, 42);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "0 aportes mostrados";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1025, 682);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 34);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmFondoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1148, 735);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.tlpResumen);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "FrmFondoReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fondo de reserva";
            this.Load += new System.EventHandler(this.FrmFondoReserva_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.tlpResumen.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlAportes.ResumeLayout(false);
            this.pnlPromedio.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlEncabezado, pnlTotal, pnlAportes, pnlPromedio, pnlTabla, pnlSinDatos;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblActualizado, lblPropiedad, lblDesde, lblHasta, lblTotalTitulo, lblTotalValor, lblAportesTitulo, lblAportesValor, lblPromedioTitulo, lblPromedioValor, lblResultado, lblSinDatosTitulo, lblSinDatosDetalle;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.Button btnActualizar, btnLimpiar, btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.DataGridView dgvFondos;
    }
}
