namespace UI.Forms
{
    partial class FrmReporteIngresoMensual
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.pnlPromedio = new System.Windows.Forms.Panel();
            this.lblPromedioValor = new System.Windows.Forms.Label();
            this.lblPromedioTitulo = new System.Windows.Forms.Label();
            this.pnlMejorMes = new System.Windows.Forms.Panel();
            this.lblMejorMesValor = new System.Windows.Forms.Label();
            this.lblMejorMesTitulo = new System.Windows.Forms.Label();
            this.splitContenido = new System.Windows.Forms.SplitContainer();
            this.pnlGrafico = new System.Windows.Forms.Panel();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlPromedio.SuspendLayout();
            this.pnlMejorMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).BeginInit();
            this.splitContenido.Panel1.SuspendLayout();
            this.splitContenido.Panel2.SuspendLayout();
            this.splitContenido.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
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
            this.pnlEncabezado.Size = new System.Drawing.Size(1438, 105);
            this.pnlEncabezado.TabIndex = 5;
            // 
            // lblActualizado
            // 
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblActualizado.Location = new System.Drawing.Point(2038, 42);
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
            this.lblSubtitulo.Size = new System.Drawing.Size(341, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Evolución mensual de la facturación en colones y dólares";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(472, 38);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Ingresos mensuales del condominio";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblAnio);
            this.grpFiltros.Controls.Add(this.nudAnio);
            this.grpFiltros.Controls.Add(this.lblMoneda);
            this.grpFiltros.Controls.Add(this.cmbMoneda);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.grpFiltros.Location = new System.Drawing.Point(28, 122);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1382, 82);
            this.grpFiltros.TabIndex = 4;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Configuración del reporte";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(20, 35);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 15);
            this.lblAnio.TabIndex = 0;
            this.lblAnio.Text = "Año";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(62, 31);
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(95, 23);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(192, 35);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(51, 15);
            this.lblMoneda.TabIndex = 2;
            this.lblMoneda.Text = "Moneda";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.Items.AddRange(new object[] {
            "Colones",
            "Dólares"});
            this.cmbMoneda.Location = new System.Drawing.Point(255, 31);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(145, 23);
            this.cmbMoneda.TabIndex = 3;
            this.cmbMoneda.SelectedIndexChanged += new System.EventHandler(this.cmbMoneda_SelectedIndexChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(425, 26);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(130, 34);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
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
            this.tlpResumen.Controls.Add(this.pnlPromedio, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlMejorMes, 2, 0);
            this.tlpResumen.Location = new System.Drawing.Point(28, 220);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpResumen.Size = new System.Drawing.Size(1382, 88);
            this.tlpResumen.TabIndex = 3;
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
            this.pnlTotal.Size = new System.Drawing.Size(448, 88);
            this.pnlTotal.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblTotalValor.Location = new System.Drawing.Point(18, 36);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(420, 44);
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
            this.lblTotalTitulo.Size = new System.Drawing.Size(420, 24);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "TOTAL FACTURADO DEL AÑO";
            // 
            // pnlPromedio
            // 
            this.pnlPromedio.BackColor = System.Drawing.Color.White;
            this.pnlPromedio.Controls.Add(this.lblPromedioValor);
            this.pnlPromedio.Controls.Add(this.lblPromedioTitulo);
            this.pnlPromedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPromedio.Location = new System.Drawing.Point(460, 0);
            this.pnlPromedio.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlPromedio.Name = "pnlPromedio";
            this.pnlPromedio.Padding = new System.Windows.Forms.Padding(18, 12, 10, 8);
            this.pnlPromedio.Size = new System.Drawing.Size(448, 88);
            this.pnlPromedio.TabIndex = 1;
            // 
            // lblPromedioValor
            // 
            this.lblPromedioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPromedioValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblPromedioValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblPromedioValor.Location = new System.Drawing.Point(18, 36);
            this.lblPromedioValor.Name = "lblPromedioValor";
            this.lblPromedioValor.Size = new System.Drawing.Size(420, 44);
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
            this.lblPromedioTitulo.Size = new System.Drawing.Size(420, 24);
            this.lblPromedioTitulo.TabIndex = 1;
            this.lblPromedioTitulo.Text = "PROMEDIO MENSUAL";
            // 
            // pnlMejorMes
            // 
            this.pnlMejorMes.BackColor = System.Drawing.Color.White;
            this.pnlMejorMes.Controls.Add(this.lblMejorMesValor);
            this.pnlMejorMes.Controls.Add(this.lblMejorMesTitulo);
            this.pnlMejorMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMejorMes.Location = new System.Drawing.Point(920, 0);
            this.pnlMejorMes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMejorMes.Name = "pnlMejorMes";
            this.pnlMejorMes.Padding = new System.Windows.Forms.Padding(18, 12, 10, 8);
            this.pnlMejorMes.Size = new System.Drawing.Size(462, 88);
            this.pnlMejorMes.TabIndex = 2;
            // 
            // lblMejorMesValor
            // 
            this.lblMejorMesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMejorMesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblMejorMesValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblMejorMesValor.Location = new System.Drawing.Point(18, 36);
            this.lblMejorMesValor.Name = "lblMejorMesValor";
            this.lblMejorMesValor.Size = new System.Drawing.Size(434, 44);
            this.lblMejorMesValor.TabIndex = 0;
            this.lblMejorMesValor.Text = "Sin datos";
            this.lblMejorMesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMejorMesTitulo
            // 
            this.lblMejorMesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMejorMesTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblMejorMesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMejorMesTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblMejorMesTitulo.Name = "lblMejorMesTitulo";
            this.lblMejorMesTitulo.Size = new System.Drawing.Size(434, 24);
            this.lblMejorMesTitulo.TabIndex = 1;
            this.lblMejorMesTitulo.Text = "MES CON MAYOR FACTURACIÓN";
            // 
            // splitContenido
            // 
            this.splitContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.splitContenido.Location = new System.Drawing.Point(28, 350);
            this.splitContenido.Name = "splitContenido";
            // 
            // splitContenido.Panel1
            // 
            this.splitContenido.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContenido.Panel1.Controls.Add(this.pnlGrafico);
            // 
            // splitContenido.Panel2
            // 
            this.splitContenido.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContenido.Panel2.Controls.Add(this.pnlDetalle);
            this.splitContenido.Size = new System.Drawing.Size(1382, 408);
            this.splitContenido.SplitterDistance = 885;
            this.splitContenido.SplitterWidth = 10;
            this.splitContenido.TabIndex = 1;
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.BackColor = System.Drawing.Color.White;
            this.pnlGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrafico.Location = new System.Drawing.Point(0, 0);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(885, 408);
            this.pnlGrafico.TabIndex = 0;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.pnlSinDatos);
            this.pnlDetalle.Controls.Add(this.dgvIngresos);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(487, 408);
            this.pnlDetalle.TabIndex = 0;
            // 
            // pnlSinDatos
            // 
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Location = new System.Drawing.Point(171, 269);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(320, 90);
            this.pnlSinDatos.TabIndex = 0;
            this.pnlSinDatos.Visible = false;
            // 
            // lblSinDatosDetalle
            // 
            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(0, 36);
            this.lblSinDatosDetalle.Name = "lblSinDatosDetalle";
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(320, 54);
            this.lblSinDatosDetalle.TabIndex = 0;
            this.lblSinDatosDetalle.Text = "Seleccione otro año o genere facturas.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSinDatosDetalle.Click += new System.EventHandler(this.lblSinDatosDetalle_Click);
            // 
            // lblSinDatosTitulo
            // 
            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosTitulo.Name = "lblSinDatosTitulo";
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(320, 36);
            this.lblSinDatosTitulo.TabIndex = 1;
            this.lblSinDatosTitulo.Text = "No hay facturación registrada";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinDatosTitulo.Click += new System.EventHandler(this.lblSinDatosTitulo_Click);
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresos.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngresos.ColumnHeadersHeight = 42;
            this.dgvIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngresos.Location = new System.Drawing.Point(0, 42);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.RowTemplate.Height = 28;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(487, 366);
            this.dgvIngresos.TabIndex = 1;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDetalle.Location = new System.Drawing.Point(0, 0);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.lblDetalle.Size = new System.Drawing.Size(487, 42);
            this.lblDetalle.TabIndex = 2;
            this.lblDetalle.Text = "Detalle por mes";
            // 
            // lblResultado
            // 
            this.lblResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblResultado.Location = new System.Drawing.Point(28, 321);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1382, 24);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "Generando reporte...";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1315, 773);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 34);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmReporteIngresoMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1438, 823);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.splitContenido);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.tlpResumen);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 730);
            this.Name = "FrmReporteIngresoMensual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingresos mensuales";
            this.Load += new System.EventHandler(this.FrmReporteIngresoMensual_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlPromedio.ResumeLayout(false);
            this.pnlMejorMes.ResumeLayout(false);
            this.splitContenido.Panel1.ResumeLayout(false);
            this.splitContenido.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenido)).EndInit();
            this.splitContenido.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlEncabezado, pnlTotal, pnlPromedio, pnlMejorMes, pnlDetalle, pnlSinDatos;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblActualizado, lblAnio, lblMoneda, lblTotalTitulo, lblTotalValor, lblPromedioTitulo, lblPromedioValor, lblMejorMesTitulo, lblMejorMesValor, lblResultado, lblDetalle, lblSinDatosTitulo, lblSinDatosDetalle;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Button btnGenerar, btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.SplitContainer splitContenido;
        private System.Windows.Forms.Panel pnlGrafico;
        private System.Windows.Forms.DataGridView dgvIngresos;
    }
}
