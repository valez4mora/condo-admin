namespace UI.Forms
{
    partial class FrmPagos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle encabezado = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle filas = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnBuscarFacturas = new System.Windows.Forms.Button();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.lblFacturasTitulo = new System.Windows.Forms.Label();
            this.dgvFacturasPendientes = new System.Windows.Forms.DataGridView();
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.btnUsarSaldo = new System.Windows.Forms.Button();
            this.lblAyudaReferencia = new System.Windows.Forms.Label();
            this.lblSaldoPendiente = new System.Windows.Forms.Label();
            this.lblSaldoTitulo = new System.Windows.Forms.Label();
            this.lblDetalleFactura = new System.Windows.Forms.Label();
            this.lblFacturaSeleccionada = new System.Windows.Forms.Label();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.dgvHistorialPagos = new System.Windows.Forms.DataGridView();
            this.pnlEncabezado.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).BeginInit();
            this.grpPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(37, 56, 88);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1100, 82);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(213, 221, 235);
            this.lblSubtitulo.Location = new System.Drawing.Point(29, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(356, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Consulte facturas pendientes y registre abonos de forma segura";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(26, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(219, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de pagos";
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusqueda.Controls.Add(this.lblResultado);
            this.grpBusqueda.Controls.Add(this.btnBuscarFacturas);
            this.grpBusqueda.Controls.Add(this.cmbPropiedad);
            this.grpBusqueda.Controls.Add(this.lblPropiedad);
            this.grpBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpBusqueda.Location = new System.Drawing.Point(24, 98);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(1052, 91);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.TabStop = false;
            this.grpBusqueda.Text = "1. Seleccione la propiedad";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblResultado.ForeColor = System.Drawing.Color.DimGray;
            this.lblResultado.Location = new System.Drawing.Point(16, 62);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 15);
            this.lblResultado.TabIndex = 3;
            // 
            // btnBuscarFacturas
            // 
            this.btnBuscarFacturas.BackColor = System.Drawing.Color.FromArgb(43, 108, 176);
            this.btnBuscarFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarFacturas.FlatAppearance.BorderSize = 0;
            this.btnBuscarFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarFacturas.ForeColor = System.Drawing.Color.White;
            this.btnBuscarFacturas.Location = new System.Drawing.Point(443, 25);
            this.btnBuscarFacturas.Name = "btnBuscarFacturas";
            this.btnBuscarFacturas.Size = new System.Drawing.Size(154, 30);
            this.btnBuscarFacturas.TabIndex = 2;
            this.btnBuscarFacturas.Text = "Cargar / actualizar";
            this.btnBuscarFacturas.UseVisualStyleBackColor = false;
            this.btnBuscarFacturas.Click += new System.EventHandler(this.btnBuscarFacturas_Click);
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropiedad.FormattingEnabled = true;
            this.cmbPropiedad.Location = new System.Drawing.Point(105, 29);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(320, 23);
            this.cmbPropiedad.TabIndex = 1;
            this.cmbPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedad_SelectedIndexChanged);
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropiedad.Location = new System.Drawing.Point(16, 32);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(62, 15);
            this.lblPropiedad.TabIndex = 0;
            this.lblPropiedad.Text = "Propiedad";
            // 
            // lblFacturasTitulo
            // 
            this.lblFacturasTitulo.AutoSize = true;
            this.lblFacturasTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblFacturasTitulo.ForeColor = System.Drawing.Color.FromArgb(37, 56, 88);
            this.lblFacturasTitulo.Location = new System.Drawing.Point(24, 203);
            this.lblFacturasTitulo.Name = "lblFacturasTitulo";
            this.lblFacturasTitulo.Size = new System.Drawing.Size(206, 19);
            this.lblFacturasTitulo.TabIndex = 2;
            this.lblFacturasTitulo.Text = "2. Seleccione la factura a pagar";
            // 
            // dgvFacturasPendientes
            // 
            this.dgvFacturasPendientes.AllowUserToAddRows = false;
            this.dgvFacturasPendientes.AllowUserToDeleteRows = false;
            this.dgvFacturasPendientes.AllowUserToResizeRows = false;
            this.dgvFacturasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturasPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturasPendientes.BackgroundColor = System.Drawing.Color.White;
            encabezado.BackColor = System.Drawing.Color.FromArgb(55, 75, 110);
            encabezado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            encabezado.ForeColor = System.Drawing.Color.White;
            encabezado.SelectionBackColor = System.Drawing.Color.FromArgb(55, 75, 110);
            encabezado.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFacturasPendientes.ColumnHeadersDefaultCellStyle = encabezado;
            this.dgvFacturasPendientes.ColumnHeadersHeight = 34;
            this.dgvFacturasPendientes.EnableHeadersVisualStyles = false;
            filas.Font = new System.Drawing.Font("Segoe UI", 9F);
            filas.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            filas.SelectionForeColor = System.Drawing.Color.FromArgb(25, 45, 75);
            this.dgvFacturasPendientes.DefaultCellStyle = filas;
            this.dgvFacturasPendientes.Location = new System.Drawing.Point(24, 228);
            this.dgvFacturasPendientes.MultiSelect = false;
            this.dgvFacturasPendientes.Name = "dgvFacturasPendientes";
            this.dgvFacturasPendientes.ReadOnly = true;
            this.dgvFacturasPendientes.RowHeadersVisible = false;
            this.dgvFacturasPendientes.RowTemplate.Height = 30;
            this.dgvFacturasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasPendientes.Size = new System.Drawing.Size(1052, 174);
            this.dgvFacturasPendientes.TabIndex = 3;
            this.dgvFacturasPendientes.SelectionChanged += new System.EventHandler(this.dgvFacturasPendientes_SelectionChanged);
            // 
            // grpPago
            // 
            this.grpPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPago.Controls.Add(this.btnUsarSaldo);
            this.grpPago.Controls.Add(this.lblAyudaReferencia);
            this.grpPago.Controls.Add(this.lblSaldoPendiente);
            this.grpPago.Controls.Add(this.lblSaldoTitulo);
            this.grpPago.Controls.Add(this.lblDetalleFactura);
            this.grpPago.Controls.Add(this.lblFacturaSeleccionada);
            this.grpPago.Controls.Add(this.btnRegistrarPago);
            this.grpPago.Controls.Add(this.btnLimpiar);
            this.grpPago.Controls.Add(this.txtReferencia);
            this.grpPago.Controls.Add(this.lblReferencia);
            this.grpPago.Controls.Add(this.cmbMetodoPago);
            this.grpPago.Controls.Add(this.lblMetodoPago);
            this.grpPago.Controls.Add(this.dtpFechaPago);
            this.grpPago.Controls.Add(this.lblFechaPago);
            this.grpPago.Controls.Add(this.txtMonto);
            this.grpPago.Controls.Add(this.lblMonto);
            this.grpPago.Enabled = false;
            this.grpPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpPago.Location = new System.Drawing.Point(24, 418);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(1052, 192);
            this.grpPago.TabIndex = 4;
            this.grpPago.TabStop = false;
            this.grpPago.Text = "3. Complete los datos del pago";
            // 
            // btnUsarSaldo
            // 
            this.btnUsarSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsarSaldo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnUsarSaldo.ForeColor = System.Drawing.Color.FromArgb(43, 108, 176);
            this.btnUsarSaldo.Location = new System.Drawing.Point(203, 90);
            this.btnUsarSaldo.Name = "btnUsarSaldo";
            this.btnUsarSaldo.Size = new System.Drawing.Size(91, 25);
            this.btnUsarSaldo.TabIndex = 7;
            this.btnUsarSaldo.Text = "Usar saldo";
            this.btnUsarSaldo.UseVisualStyleBackColor = true;
            this.btnUsarSaldo.Click += new System.EventHandler(this.btnUsarSaldo_Click);
            // 
            // lblAyudaReferencia
            // 
            this.lblAyudaReferencia.AutoSize = true;
            this.lblAyudaReferencia.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAyudaReferencia.ForeColor = System.Drawing.Color.DimGray;
            this.lblAyudaReferencia.Location = new System.Drawing.Point(648, 145);
            this.lblAyudaReferencia.Name = "lblAyudaReferencia";
            this.lblAyudaReferencia.Size = new System.Drawing.Size(315, 13);
            this.lblAyudaReferencia.TabIndex = 15;
            this.lblAyudaReferencia.Text = "Obligatoria para pagos distintos de efectivo. Máximo 100 caracteres.";
            // 
            // lblSaldoPendiente
            // 
            this.lblSaldoPendiente.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblSaldoPendiente.ForeColor = System.Drawing.Color.FromArgb(28, 105, 76);
            this.lblSaldoPendiente.Location = new System.Drawing.Point(810, 39);
            this.lblSaldoPendiente.Name = "lblSaldoPendiente";
            this.lblSaldoPendiente.Size = new System.Drawing.Size(220, 36);
            this.lblSaldoPendiente.TabIndex = 5;
            this.lblSaldoPendiente.Text = "₡0,00";
            this.lblSaldoPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldoTitulo
            // 
            this.lblSaldoTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSaldoTitulo.Location = new System.Drawing.Point(810, 24);
            this.lblSaldoTitulo.Name = "lblSaldoTitulo";
            this.lblSaldoTitulo.Size = new System.Drawing.Size(220, 16);
            this.lblSaldoTitulo.TabIndex = 4;
            this.lblSaldoTitulo.Text = "SALDO PENDIENTE";
            this.lblSaldoTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetalleFactura
            // 
            this.lblDetalleFactura.AutoSize = true;
            this.lblDetalleFactura.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetalleFactura.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetalleFactura.Location = new System.Drawing.Point(16, 51);
            this.lblDetalleFactura.Name = "lblDetalleFactura";
            this.lblDetalleFactura.Size = new System.Drawing.Size(205, 15);
            this.lblDetalleFactura.TabIndex = 3;
            this.lblDetalleFactura.Text = "Seleccione una fila de la lista superior.";
            // 
            // lblFacturaSeleccionada
            // 
            this.lblFacturaSeleccionada.AutoSize = true;
            this.lblFacturaSeleccionada.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblFacturaSeleccionada.ForeColor = System.Drawing.Color.FromArgb(37, 56, 88);
            this.lblFacturaSeleccionada.Location = new System.Drawing.Point(15, 26);
            this.lblFacturaSeleccionada.Name = "lblFacturaSeleccionada";
            this.lblFacturaSeleccionada.Size = new System.Drawing.Size(213, 20);
            this.lblFacturaSeleccionada.TabIndex = 2;
            this.lblFacturaSeleccionada.Text = "Ninguna factura seleccionada";
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.FromArgb(28, 122, 85);
            this.btnRegistrarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.Location = new System.Drawing.Point(18, 147);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(150, 32);
            this.btnRegistrarPago.TabIndex = 16;
            this.btnRegistrarPago.Text = "Registrar pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(180, 147);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(114, 32);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Restablecer";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReferencia.Location = new System.Drawing.Point(651, 119);
            this.txtReferencia.MaxLength = 100;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(360, 23);
            this.txtReferencia.TabIndex = 14;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReferencia.Location = new System.Drawing.Point(648, 95);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(144, 15);
            this.lblReferencia.TabIndex = 13;
            this.lblReferencia.Text = "Referencia / comprobante";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(445, 119);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(190, 23);
            this.cmbMetodoPago.TabIndex = 12;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.Location = new System.Drawing.Point(442, 95);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(96, 15);
            this.lblMetodoPago.TabIndex = 11;
            this.lblMetodoPago.Text = "Método de pago";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPago.Location = new System.Drawing.Point(312, 119);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(120, 23);
            this.dtpFechaPago.TabIndex = 10;
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaPago.Location = new System.Drawing.Point(309, 95);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(38, 15);
            this.lblFechaPago.TabIndex = 9;
            this.lblFechaPago.Text = "Fecha";
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMonto.Location = new System.Drawing.Point(18, 89);
            this.txtMonto.MaxLength = 18;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(174, 25);
            this.txtMonto.TabIndex = 6;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonto.Location = new System.Drawing.Point(15, 70);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(94, 15);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto del pago";
            // 
            // lblHistorialTitulo
            // 
            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.ForeColor = System.Drawing.Color.FromArgb(37, 56, 88);
            this.lblHistorialTitulo.Location = new System.Drawing.Point(24, 625);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Size = new System.Drawing.Size(123, 19);
            this.lblHistorialTitulo.TabIndex = 5;
            this.lblHistorialTitulo.Text = "Historial de pagos";
            // 
            // dgvHistorialPagos
            // 
            this.dgvHistorialPagos.AllowUserToAddRows = false;
            this.dgvHistorialPagos.AllowUserToDeleteRows = false;
            this.dgvHistorialPagos.AllowUserToResizeRows = false;
            this.dgvHistorialPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialPagos.ColumnHeadersDefaultCellStyle = encabezado;
            this.dgvHistorialPagos.ColumnHeadersHeight = 34;
            this.dgvHistorialPagos.DefaultCellStyle = filas;
            this.dgvHistorialPagos.EnableHeadersVisualStyles = false;
            this.dgvHistorialPagos.Location = new System.Drawing.Point(24, 650);
            this.dgvHistorialPagos.MultiSelect = false;
            this.dgvHistorialPagos.Name = "dgvHistorialPagos";
            this.dgvHistorialPagos.ReadOnly = true;
            this.dgvHistorialPagos.RowHeadersVisible = false;
            this.dgvHistorialPagos.RowTemplate.Height = 28;
            this.dgvHistorialPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialPagos.Size = new System.Drawing.Size(1052, 150);
            this.dgvHistorialPagos.TabIndex = 6;
            // 
            // FrmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.ClientSize = new System.Drawing.Size(1100, 824);
            this.Controls.Add(this.dgvHistorialPagos);
            this.Controls.Add(this.lblHistorialTitulo);
            this.Controls.Add(this.grpPago);
            this.Controls.Add(this.dgvFacturasPendientes);
            this.Controls.Add(this.lblFacturasTitulo);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 760);
            this.Name = "FrmPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de pagos";
            this.Load += new System.EventHandler(this.FrmPagos_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).EndInit();
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnBuscarFacturas;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.Label lblFacturasTitulo;
        private System.Windows.Forms.DataGridView dgvFacturasPendientes;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.Label lblFacturaSeleccionada;
        private System.Windows.Forms.Label lblDetalleFactura;
        private System.Windows.Forms.Label lblSaldoTitulo;
        private System.Windows.Forms.Label lblSaldoPendiente;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnUsarSaldo;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblAyudaReferencia;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblHistorialTitulo;
        private System.Windows.Forms.DataGridView dgvHistorialPagos;
    }
}
