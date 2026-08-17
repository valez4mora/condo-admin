namespace UI.Forms
{
    partial class FrmFondoReserva
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle moneyStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle percentStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
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
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.dgvFondos = new System.Windows.Forms.DataGridView();
            this.colIdFondoReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlAportes.SuspendLayout();
            this.pnlPromedio.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1084, 102);
            this.pnlEncabezado.TabIndex = 0;
            //
            // lblActualizado
            //
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(220, 232, 242);
            this.lblActualizado.Location = new System.Drawing.Point(793, 41);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(263, 22);
            this.lblActualizado.TabIndex = 2;
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(220, 232, 242);
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 62);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(416, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Consulta y seguimiento de los aportes generados por las cuotas";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(27, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(242, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Fondo de reserva";
            //
            // grpFiltros
            //
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.lblHasta);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.lblDesde);
            this.grpFiltros.Controls.Add(this.chkUsarFechas);
            this.grpFiltros.Controls.Add(this.cmbPropiedad);
            this.grpFiltros.Controls.Add(this.lblPropiedad);
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.Location = new System.Drawing.Point(24, 118);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1036, 105);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de consulta";
            //
            // btnLimpiar
            //
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.Location = new System.Drawing.Point(796, 49);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 34);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // btnActualizar
            //
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(908, 49);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 34);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // dtpHasta
            //
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(651, 56);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(118, 23);
            this.dtpHasta.TabIndex = 6;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.Location = new System.Drawing.Point(648, 34);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 15);
            this.lblHasta.TabIndex = 5;
            this.lblHasta.Text = "Hasta";
            //
            // dtpDesde
            //
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(515, 56);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(118, 23);
            this.dtpDesde.TabIndex = 4;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.Location = new System.Drawing.Point(512, 34);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(39, 15);
            this.lblDesde.TabIndex = 3;
            this.lblDesde.Text = "Desde";
            //
            // chkUsarFechas
            //
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUsarFechas.Location = new System.Drawing.Point(345, 58);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(136, 19);
            this.chkUsarFechas.TabIndex = 2;
            this.chkUsarFechas.Text = "Filtrar por período";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            //
            // cmbPropiedad
            //
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropiedad.FormattingEnabled = true;
            this.cmbPropiedad.Location = new System.Drawing.Point(20, 56);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(300, 23);
            this.cmbPropiedad.TabIndex = 1;
            this.cmbPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedad_SelectedIndexChanged);
            //
            // lblPropiedad
            //
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropiedad.Location = new System.Drawing.Point(17, 34);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(59, 15);
            this.lblPropiedad.TabIndex = 0;
            this.lblPropiedad.Text = "Propiedad";
            //
            // tlpResumen
            //
            this.tlpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpResumen.ColumnCount = 3;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpResumen.Controls.Add(this.pnlTotal, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlAportes, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlPromedio, 2, 0);
            this.tlpResumen.Location = new System.Drawing.Point(24, 235);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1036, 96);
            this.tlpResumen.TabIndex = 2;
            //
            // pnlTotal
            //
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotal.Controls.Add(this.lblTotalValor);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(337, 96);
            this.pnlTotal.TabIndex = 0;
            //
            // lblTotalValor
            //
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTotalValor.Location = new System.Drawing.Point(17, 39);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(86, 37);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "₡0,00";
            //
            // lblTotalTitulo
            //
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(102, 17);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total acumulado";
            //
            // pnlAportes
            //
            this.pnlAportes.BackColor = System.Drawing.Color.White;
            this.pnlAportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAportes.Controls.Add(this.lblAportesValor);
            this.pnlAportes.Controls.Add(this.lblAportesTitulo);
            this.pnlAportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAportes.Location = new System.Drawing.Point(353, 0);
            this.pnlAportes.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pnlAportes.Name = "pnlAportes";
            this.pnlAportes.Size = new System.Drawing.Size(329, 96);
            this.pnlAportes.TabIndex = 1;
            //
            // lblAportesValor
            //
            this.lblAportesValor.AutoSize = true;
            this.lblAportesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblAportesValor.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblAportesValor.Location = new System.Drawing.Point(17, 39);
            this.lblAportesValor.Name = "lblAportesValor";
            this.lblAportesValor.Size = new System.Drawing.Size(32, 37);
            this.lblAportesValor.TabIndex = 1;
            this.lblAportesValor.Text = "0";
            //
            // lblAportesTitulo
            //
            this.lblAportesTitulo.AutoSize = true;
            this.lblAportesTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblAportesTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblAportesTitulo.Name = "lblAportesTitulo";
            this.lblAportesTitulo.Size = new System.Drawing.Size(119, 17);
            this.lblAportesTitulo.TabIndex = 0;
            this.lblAportesTitulo.Text = "Aportes registrados";
            //
            // pnlPromedio
            //
            this.pnlPromedio.BackColor = System.Drawing.Color.White;
            this.pnlPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPromedio.Controls.Add(this.lblPromedioValor);
            this.pnlPromedio.Controls.Add(this.lblPromedioTitulo);
            this.pnlPromedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPromedio.Location = new System.Drawing.Point(698, 0);
            this.pnlPromedio.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlPromedio.Name = "pnlPromedio";
            this.pnlPromedio.Size = new System.Drawing.Size(338, 96);
            this.pnlPromedio.TabIndex = 2;
            //
            // lblPromedioValor
            //
            this.lblPromedioValor.AutoSize = true;
            this.lblPromedioValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblPromedioValor.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblPromedioValor.Location = new System.Drawing.Point(17, 39);
            this.lblPromedioValor.Name = "lblPromedioValor";
            this.lblPromedioValor.Size = new System.Drawing.Size(86, 37);
            this.lblPromedioValor.TabIndex = 1;
            this.lblPromedioValor.Text = "₡0,00";
            //
            // lblPromedioTitulo
            //
            this.lblPromedioTitulo.AutoSize = true;
            this.lblPromedioTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblPromedioTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblPromedioTitulo.Name = "lblPromedioTitulo";
            this.lblPromedioTitulo.Size = new System.Drawing.Size(123, 17);
            this.lblPromedioTitulo.TabIndex = 0;
            this.lblPromedioTitulo.Text = "Promedio por aporte";
            //
            // pnlContenido
            //
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenido.Controls.Add(this.pnlSinDatos);
            this.pnlContenido.Controls.Add(this.dgvFondos);
            this.pnlContenido.Location = new System.Drawing.Point(24, 345);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1036, 296);
            this.pnlContenido.TabIndex = 3;
            //
            // pnlSinDatos
            //
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSinDatos.Location = new System.Drawing.Point(0, 0);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(1034, 294);
            this.pnlSinDatos.TabIndex = 1;
            //
            // lblSinDatosDetalle
            //
            this.lblSinDatosDetalle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(287, 149);
            this.lblSinDatosDetalle.Name = "lblSinDatosDetalle";
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(460, 25);
            this.lblSinDatosDetalle.TabIndex = 1;
            this.lblSinDatosDetalle.Text = "Cambie los filtros o actualice la consulta.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSinDatosTitulo
            //
            this.lblSinDatosTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(287, 116);
            this.lblSinDatosTitulo.Name = "lblSinDatosTitulo";
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(460, 32);
            this.lblSinDatosTitulo.TabIndex = 0;
            this.lblSinDatosTitulo.Text = "No hay aportes para mostrar";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dgvFondos
            //
            this.dgvFondos.AllowUserToAddRows = false;
            this.dgvFondos.AllowUserToDeleteRows = false;
            this.dgvFondos.AllowUserToResizeRows = false;
            this.dgvFondos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFondos.BackgroundColor = System.Drawing.Color.White;
            this.dgvFondos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFondos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFondos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(236, 242, 248);
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(45, 55, 65);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(236, 242, 248);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 55, 65);
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFondos.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvFondos.ColumnHeadersHeight = 42;
            this.dgvFondos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdFondoReserva,
            this.colPropiedad,
            this.colPorcentaje,
            this.colMonto,
            this.colFecha});
            this.dgvFondos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFondos.EnableHeadersVisualStyles = false;
            this.dgvFondos.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvFondos.Location = new System.Drawing.Point(0, 0);
            this.dgvFondos.MultiSelect = false;
            this.dgvFondos.Name = "dgvFondos";
            this.dgvFondos.ReadOnly = true;
            this.dgvFondos.RowHeadersVisible = false;
            this.dgvFondos.RowTemplate.Height = 34;
            this.dgvFondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFondos.Size = new System.Drawing.Size(1034, 294);
            this.dgvFondos.TabIndex = 0;
            //
            // colIdFondoReserva
            //
            this.colIdFondoReserva.HeaderText = "Id";
            this.colIdFondoReserva.Name = "colIdFondoReserva";
            this.colIdFondoReserva.ReadOnly = true;
            this.colIdFondoReserva.Visible = false;
            //
            // colPropiedad
            //
            this.colPropiedad.FillWeight = 130F;
            this.colPropiedad.HeaderText = "Propiedad";
            this.colPropiedad.Name = "colPropiedad";
            this.colPropiedad.ReadOnly = true;
            //
            // colPorcentaje
            //
            percentStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            percentStyle.Format = "N2' %'";
            this.colPorcentaje.DefaultCellStyle = percentStyle;
            this.colPorcentaje.HeaderText = "Porcentaje aplicado";
            this.colPorcentaje.Name = "colPorcentaje";
            this.colPorcentaje.ReadOnly = true;
            //
            // colMonto
            //
            moneyStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            moneyStyle.Format = "C2";
            moneyStyle.FormatProvider = new System.Globalization.CultureInfo("es-CR");
            this.colMonto.DefaultCellStyle = moneyStyle;
            this.colMonto.HeaderText = "Aporte al fondo";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            //
            // colFecha
            //
            this.colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colFecha.HeaderText = "Fecha del aporte";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            //
            // pnlPie
            //
            this.pnlPie.Controls.Add(this.btnCerrar);
            this.pnlPie.Controls.Add(this.lblResultado);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 653);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1084, 58);
            this.pnlPie.TabIndex = 4;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(74, 84, 94);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(944, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(116, 34);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // lblResultado
            //
            this.lblResultado.AutoSize = true;
            this.lblResultado.ForeColor = System.Drawing.Color.DimGray;
            this.lblResultado.Location = new System.Drawing.Point(24, 21);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(130, 17);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "0 aportes mostrados";
            //
            // FrmFondoReserva
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1084, 711);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.tlpResumen);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
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
            this.pnlTotal.PerformLayout();
            this.pnlAportes.ResumeLayout(false);
            this.pnlAportes.PerformLayout();
            this.pnlPromedio.ResumeLayout(false);
            this.pnlPromedio.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondos)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Panel pnlAportes;
        private System.Windows.Forms.Label lblAportesValor;
        private System.Windows.Forms.Label lblAportesTitulo;
        private System.Windows.Forms.Panel pnlPromedio;
        private System.Windows.Forms.Label lblPromedioValor;
        private System.Windows.Forms.Label lblPromedioTitulo;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlSinDatos;
        private System.Windows.Forms.Label lblSinDatosDetalle;
        private System.Windows.Forms.Label lblSinDatosTitulo;
        private System.Windows.Forms.DataGridView dgvFondos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFondoReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblResultado;
    }
}
