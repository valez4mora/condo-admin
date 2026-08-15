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
            this.grpBusqueda             = new System.Windows.Forms.GroupBox();
            this.btnBuscarFacturas       = new System.Windows.Forms.Button();
            this.cmbPropiedad            = new System.Windows.Forms.ComboBox();
            this.lblPropiedadLbl         = new System.Windows.Forms.Label();
            this.dgvFacturasPendientes   = new System.Windows.Forms.DataGridView();
            this.grpPago                 = new System.Windows.Forms.GroupBox();
            this.lblInfoFactura          = new System.Windows.Forms.Label();
            this.btnVerHistorial         = new System.Windows.Forms.Button();
            this.btnRegistrarPago        = new System.Windows.Forms.Button();
            this.btnLimpiar              = new System.Windows.Forms.Button();
            this.txtReferencia           = new System.Windows.Forms.TextBox();
            this.lblReferencia           = new System.Windows.Forms.Label();
            this.cmbMetodoPago           = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago           = new System.Windows.Forms.Label();
            this.dtpFechaPago            = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPago            = new System.Windows.Forms.Label();
            this.txtMonto                = new System.Windows.Forms.TextBox();
            this.lblMonto                = new System.Windows.Forms.Label();
            this.dgvHistorialPagos       = new System.Windows.Forms.DataGridView();
            this.lblHistorialTitulo      = new System.Windows.Forms.Label();

            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).BeginInit();
            this.grpPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).BeginInit();
            this.SuspendLayout();

            // grpBusqueda
            this.grpBusqueda.Controls.Add(this.btnBuscarFacturas);
            this.grpBusqueda.Controls.Add(this.cmbPropiedad);
            this.grpBusqueda.Controls.Add(this.lblPropiedadLbl);
            this.grpBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grpBusqueda.Size = new System.Drawing.Size(960, 60);
            this.grpBusqueda.Text = "Buscar facturas pendientes";

            this.lblPropiedadLbl.Location = new System.Drawing.Point(10, 25); this.lblPropiedadLbl.Text = "Propiedad:"; this.lblPropiedadLbl.Size = new System.Drawing.Size(70, 20);
            this.cmbPropiedad.Location    = new System.Drawing.Point(85, 22); this.cmbPropiedad.Size = new System.Drawing.Size(220, 21); this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnBuscarFacturas.Location = new System.Drawing.Point(320, 21); this.btnBuscarFacturas.Size = new System.Drawing.Size(130, 23);
            this.btnBuscarFacturas.Text = "Buscar facturas";
            this.btnBuscarFacturas.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarFacturas.ForeColor = System.Drawing.Color.White;
            this.btnBuscarFacturas.Click += new System.EventHandler(this.btnBuscarFacturas_Click);

            // dgvFacturasPendientes
            this.dgvFacturasPendientes.Location = new System.Drawing.Point(12, 80);
            this.dgvFacturasPendientes.Size = new System.Drawing.Size(960, 160);
            this.dgvFacturasPendientes.ReadOnly = true;
            this.dgvFacturasPendientes.AllowUserToAddRows = false;
            this.dgvFacturasPendientes.MultiSelect = false;
            this.dgvFacturasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasPendientes.SelectionChanged += new System.EventHandler(this.dgvFacturasPendientes_SelectionChanged);

            // grpPago
            this.grpPago.Controls.Add(this.lblInfoFactura);
            this.grpPago.Controls.Add(this.lblMonto);
            this.grpPago.Controls.Add(this.txtMonto);
            this.grpPago.Controls.Add(this.lblFechaPago);
            this.grpPago.Controls.Add(this.dtpFechaPago);
            this.grpPago.Controls.Add(this.lblMetodoPago);
            this.grpPago.Controls.Add(this.cmbMetodoPago);
            this.grpPago.Controls.Add(this.lblReferencia);
            this.grpPago.Controls.Add(this.txtReferencia);
            this.grpPago.Controls.Add(this.btnRegistrarPago);
            this.grpPago.Controls.Add(this.btnLimpiar);
            this.grpPago.Location = new System.Drawing.Point(12, 250);
            this.grpPago.Size = new System.Drawing.Size(960, 160);
            this.grpPago.Text = "Registrar pago";
            this.grpPago.Enabled = false;

            this.lblInfoFactura.Location = new System.Drawing.Point(10, 22); this.lblInfoFactura.Size = new System.Drawing.Size(600, 20); this.lblInfoFactura.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            // Fila campos
            this.lblMonto.Location  = new System.Drawing.Point(10, 55);  this.lblMonto.Text  = "Monto (₡):"; this.lblMonto.Size = new System.Drawing.Size(70, 20);
            this.txtMonto.Location  = new System.Drawing.Point(85, 52);  this.txtMonto.Size  = new System.Drawing.Size(110, 22);

            this.lblFechaPago.Location  = new System.Drawing.Point(210, 55); this.lblFechaPago.Text = "Fecha pago:"; this.lblFechaPago.Size = new System.Drawing.Size(75, 20);
            this.dtpFechaPago.Location  = new System.Drawing.Point(290, 52); this.dtpFechaPago.Size = new System.Drawing.Size(140, 22); this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblMetodoPago.Location  = new System.Drawing.Point(445, 55); this.lblMetodoPago.Text = "Método:"; this.lblMetodoPago.Size = new System.Drawing.Size(55, 20);
            this.cmbMetodoPago.Location  = new System.Drawing.Point(505, 52); this.cmbMetodoPago.Size = new System.Drawing.Size(150, 22); this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblReferencia.Location  = new System.Drawing.Point(10, 90);  this.lblReferencia.Text = "Referencia:"; this.lblReferencia.Size = new System.Drawing.Size(70, 20);
            this.txtReferencia.Location  = new System.Drawing.Point(85, 87);  this.txtReferencia.Size = new System.Drawing.Size(300, 22);

            this.btnRegistrarPago.Location = new System.Drawing.Point(10,  120); this.btnRegistrarPago.Size = new System.Drawing.Size(140, 30);
            this.btnRegistrarPago.Text     = "Registrar pago"; this.btnRegistrarPago.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.Click   += new System.EventHandler(this.btnRegistrarPago_Click);

            this.btnLimpiar.Location = new System.Drawing.Point(165, 120); this.btnLimpiar.Size = new System.Drawing.Size(80, 30);
            this.btnLimpiar.Text = "Limpiar"; this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Historial pagos
            this.lblHistorialTitulo.Location = new System.Drawing.Point(12, 420); this.lblHistorialTitulo.Text = "Historial de pagos de la factura seleccionada:"; this.lblHistorialTitulo.Size = new System.Drawing.Size(350, 20); this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            this.btnVerHistorial.Location = new System.Drawing.Point(370, 417); this.btnVerHistorial.Size = new System.Drawing.Size(120, 23);
            this.btnVerHistorial.Text = "Ver historial"; this.btnVerHistorial.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnVerHistorial.ForeColor = System.Drawing.Color.White;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);

            this.dgvHistorialPagos.Location = new System.Drawing.Point(12, 447); this.dgvHistorialPagos.Size = new System.Drawing.Size(960, 150); this.dgvHistorialPagos.ReadOnly = true; this.dgvHistorialPagos.AllowUserToAddRows = false;

            // FrmPagos
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 615);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.dgvFacturasPendientes);
            this.Controls.Add(this.grpPago);
            this.Controls.Add(this.lblHistorialTitulo);
            this.Controls.Add(this.btnVerHistorial);
            this.Controls.Add(this.dgvHistorialPagos);
            this.Name = "FrmPagos";
            this.Text = "Registro de Pagos";
            this.Load += new System.EventHandler(this.FrmPagos_Load);

            this.grpBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasPendientes)).EndInit();
            this.grpPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox       grpBusqueda;
        private System.Windows.Forms.Button         btnBuscarFacturas;
        private System.Windows.Forms.ComboBox       cmbPropiedad;
        private System.Windows.Forms.Label          lblPropiedadLbl;
        private System.Windows.Forms.DataGridView   dgvFacturasPendientes;
        private System.Windows.Forms.GroupBox       grpPago;
        private System.Windows.Forms.Label          lblInfoFactura;
        private System.Windows.Forms.Button         btnVerHistorial;
        private System.Windows.Forms.Button         btnRegistrarPago;
        private System.Windows.Forms.Button         btnLimpiar;
        private System.Windows.Forms.TextBox        txtReferencia;
        private System.Windows.Forms.Label          lblReferencia;
        private System.Windows.Forms.ComboBox       cmbMetodoPago;
        private System.Windows.Forms.Label          lblMetodoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label          lblFechaPago;
        private System.Windows.Forms.TextBox        txtMonto;
        private System.Windows.Forms.Label          lblMonto;
        private System.Windows.Forms.DataGridView   dgvHistorialPagos;
        private System.Windows.Forms.Label          lblHistorialTitulo;
    }
}
