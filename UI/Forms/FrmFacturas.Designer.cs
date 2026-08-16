namespace UI.Forms
{
    partial class FrmFacturas
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
            this.grpFiltro           = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltro    = new System.Windows.Forms.Button();
            this.btnFiltrar          = new System.Windows.Forms.Button();
            this.cmbPropiedad        = new System.Windows.Forms.ComboBox();
            this.lblFiltroPropiedad  = new System.Windows.Forms.Label();
            this.dgvFacturas         = new System.Windows.Forms.DataGridView();
            this.grpDetalle          = new System.Windows.Forms.GroupBox();
            this.txtEmailDestinatario = new System.Windows.Forms.TextBox();
            this.lblEmailLbl         = new System.Windows.Forms.Label();
            this.btnEnviarCorreo     = new System.Windows.Forms.Button();
            this.btnExportarXml      = new System.Windows.Forms.Button();
            this.btnExportarPdf      = new System.Windows.Forms.Button();
            this.btnAnular           = new System.Windows.Forms.Button();
            this.dgvDetalle          = new System.Windows.Forms.DataGridView();
            this.lblEstado           = new System.Windows.Forms.Label();
            this.lblEstadoLbl        = new System.Windows.Forms.Label();
            this.lblDolares          = new System.Windows.Forms.Label();
            this.lblDolaresLbl       = new System.Windows.Forms.Label();
            this.lblColones          = new System.Windows.Forms.Label();
            this.lblColonesLbl       = new System.Windows.Forms.Label();
            this.lblPropiedad        = new System.Windows.Forms.Label();
            this.lblPropiedadLbl     = new System.Windows.Forms.Label();
            this.lblFecha            = new System.Windows.Forms.Label();
            this.lblFechaLbl         = new System.Windows.Forms.Label();
            this.lblIdFactura        = new System.Windows.Forms.Label();
            this.lblIdFacturaLbl     = new System.Windows.Forms.Label();

            this.grpFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // grpFiltro
            this.grpFiltro.Controls.Add(this.btnLimpiarFiltro);
            this.grpFiltro.Controls.Add(this.btnFiltrar);
            this.grpFiltro.Controls.Add(this.cmbPropiedad);
            this.grpFiltro.Controls.Add(this.lblFiltroPropiedad);
            this.grpFiltro.Location = new System.Drawing.Point(12, 12);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(960, 60);
            this.grpFiltro.TabIndex = 0;
            this.grpFiltro.Text = "Filtrar por propiedad";

            // lblFiltroPropiedad
            this.lblFiltroPropiedad.Location = new System.Drawing.Point(10, 25);
            this.lblFiltroPropiedad.Text = "Propiedad:";
            this.lblFiltroPropiedad.Size = new System.Drawing.Size(70, 20);

            // cmbPropiedad
            this.cmbPropiedad.Location = new System.Drawing.Point(85, 22);
            this.cmbPropiedad.Size = new System.Drawing.Size(200, 21);
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnFiltrar
            this.btnFiltrar.Location = new System.Drawing.Point(300, 21);
            this.btnFiltrar.Size = new System.Drawing.Size(90, 23);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // btnLimpiarFiltro
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(400, 21);
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(90, 23);
            this.btnLimpiarFiltro.Text = "Ver todas";
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);

            // dgvFacturas
            this.dgvFacturas.Location = new System.Drawing.Point(12, 80);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(960, 200);
            this.dgvFacturas.TabIndex = 1;
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.SelectionChanged += new System.EventHandler(this.dgvFacturas_SelectionChanged);

            // grpDetalle
            this.grpDetalle.Controls.Add(this.txtEmailDestinatario);
            this.grpDetalle.Controls.Add(this.lblEmailLbl);
            this.grpDetalle.Controls.Add(this.btnEnviarCorreo);
            this.grpDetalle.Controls.Add(this.btnExportarXml);
            this.grpDetalle.Controls.Add(this.btnExportarPdf);
            this.grpDetalle.Controls.Add(this.btnAnular);
            this.grpDetalle.Controls.Add(this.dgvDetalle);
            this.grpDetalle.Controls.Add(this.lblEstado);
            this.grpDetalle.Controls.Add(this.lblEstadoLbl);
            this.grpDetalle.Controls.Add(this.lblDolares);
            this.grpDetalle.Controls.Add(this.lblDolaresLbl);
            this.grpDetalle.Controls.Add(this.lblColones);
            this.grpDetalle.Controls.Add(this.lblColonesLbl);
            this.grpDetalle.Controls.Add(this.lblPropiedad);
            this.grpDetalle.Controls.Add(this.lblPropiedadLbl);
            this.grpDetalle.Controls.Add(this.lblFecha);
            this.grpDetalle.Controls.Add(this.lblFechaLbl);
            this.grpDetalle.Controls.Add(this.lblIdFactura);
            this.grpDetalle.Controls.Add(this.lblIdFacturaLbl);
            this.grpDetalle.Location = new System.Drawing.Point(12, 290);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(960, 360);
            this.grpDetalle.Text = "Detalle de la factura seleccionada";

            // Labels fila 1
            this.lblIdFacturaLbl.Location = new System.Drawing.Point(10, 25); this.lblIdFacturaLbl.Text = "N.° Factura:"; this.lblIdFacturaLbl.Size = new System.Drawing.Size(80, 20);
            this.lblIdFactura.Location    = new System.Drawing.Point(95, 25); this.lblIdFactura.Size = new System.Drawing.Size(60, 20); this.lblIdFactura.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.lblFechaLbl.Location     = new System.Drawing.Point(170, 25); this.lblFechaLbl.Text = "Fecha:"; this.lblFechaLbl.Size = new System.Drawing.Size(50, 20);
            this.lblFecha.Location        = new System.Drawing.Point(225, 25); this.lblFecha.Size = new System.Drawing.Size(130, 20);
            this.lblPropiedadLbl.Location = new System.Drawing.Point(365, 25); this.lblPropiedadLbl.Text = "Propiedad:"; this.lblPropiedadLbl.Size = new System.Drawing.Size(65, 20);
            this.lblPropiedad.Location    = new System.Drawing.Point(435, 25); this.lblPropiedad.Size = new System.Drawing.Size(80, 20); this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            // Labels fila 2
            this.lblColonesLbl.Location  = new System.Drawing.Point(10, 55);  this.lblColonesLbl.Text  = "Total (₡):";  this.lblColonesLbl.Size  = new System.Drawing.Size(70, 20);
            this.lblColones.Location     = new System.Drawing.Point(85, 55);   this.lblColones.Size     = new System.Drawing.Size(100, 20);
            this.lblDolaresLbl.Location  = new System.Drawing.Point(195, 55);  this.lblDolaresLbl.Text  = "Total ($):";  this.lblDolaresLbl.Size  = new System.Drawing.Size(60, 20);
            this.lblDolares.Location     = new System.Drawing.Point(260, 55);  this.lblDolares.Size     = new System.Drawing.Size(100, 20);
            this.lblEstadoLbl.Location   = new System.Drawing.Point(370, 55);  this.lblEstadoLbl.Text   = "Estado:";     this.lblEstadoLbl.Size   = new System.Drawing.Size(50, 20);
            this.lblEstado.Location      = new System.Drawing.Point(425, 55);  this.lblEstado.Size      = new System.Drawing.Size(90, 20); this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            // dgvDetalle
            this.dgvDetalle.Location = new System.Drawing.Point(10, 85);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(935, 150);
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.AllowUserToAddRows = false;

            // Email row
            this.lblEmailLbl.Location = new System.Drawing.Point(10, 250); this.lblEmailLbl.Text = "Email destino:"; this.lblEmailLbl.Size = new System.Drawing.Size(85, 20);
            this.txtEmailDestinatario.Location = new System.Drawing.Point(100, 247); this.txtEmailDestinatario.Size = new System.Drawing.Size(220, 23);

            // Botones
            this.btnAnular.Location        = new System.Drawing.Point(10,  315); this.btnAnular.Size = new System.Drawing.Size(120, 30);
            this.btnAnular.Text            = "Anular factura"; this.btnAnular.BackColor = System.Drawing.Color.Tomato;
            this.btnAnular.ForeColor       = System.Drawing.Color.White; this.btnAnular.Enabled = false;
            this.btnAnular.Click          += new System.EventHandler(this.btnAnular_Click);

            this.btnExportarXml.Location   = new System.Drawing.Point(145, 315); this.btnExportarXml.Size = new System.Drawing.Size(120, 30);
            this.btnExportarXml.Text       = "Exportar XML"; this.btnExportarXml.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExportarXml.ForeColor  = System.Drawing.Color.White; this.btnExportarXml.Enabled = false;
            this.btnExportarXml.Click     += new System.EventHandler(this.btnExportarXml_Click);

            this.btnExportarPdf.Location   = new System.Drawing.Point(280, 315); this.btnExportarPdf.Size = new System.Drawing.Size(120, 30);
            this.btnExportarPdf.Text       = "Exportar PDF"; this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnExportarPdf.ForeColor  = System.Drawing.Color.White; this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0; this.btnExportarPdf.Enabled = false;
            this.btnExportarPdf.Click     += new System.EventHandler(this.btnExportarPdf_Click);

            this.btnEnviarCorreo.Location  = new System.Drawing.Point(415, 315); this.btnEnviarCorreo.Size = new System.Drawing.Size(140, 30);
            this.btnEnviarCorreo.Text      = "Enviar por correo"; this.btnEnviarCorreo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEnviarCorreo.ForeColor = System.Drawing.Color.White; this.btnEnviarCorreo.Enabled = false;
            this.btnEnviarCorreo.Click    += new System.EventHandler(this.btnEnviarCorreo_Click);

            // FrmFacturas
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 665);
            this.Controls.Add(this.grpFiltro);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.grpDetalle);
            this.Name = "FrmFacturas";
            this.Text = "Gestión de Facturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);

            this.grpFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Button   btnLimpiarFiltro;
        private System.Windows.Forms.Button   btnFiltrar;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label    lblFiltroPropiedad;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TextBox  txtEmailDestinatario;
        private System.Windows.Forms.Label    lblEmailLbl;
        private System.Windows.Forms.Button   btnEnviarCorreo;
        private System.Windows.Forms.Button   btnExportarXml;
        private System.Windows.Forms.Button   btnExportarPdf;
        private System.Windows.Forms.Button   btnAnular;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label    lblEstado;
        private System.Windows.Forms.Label    lblEstadoLbl;
        private System.Windows.Forms.Label    lblDolares;
        private System.Windows.Forms.Label    lblDolaresLbl;
        private System.Windows.Forms.Label    lblColones;
        private System.Windows.Forms.Label    lblColonesLbl;
        private System.Windows.Forms.Label    lblPropiedad;
        private System.Windows.Forms.Label    lblPropiedadLbl;
        private System.Windows.Forms.Label    lblFecha;
        private System.Windows.Forms.Label    lblFechaLbl;
        private System.Windows.Forms.Label    lblIdFactura;
        private System.Windows.Forms.Label    lblIdFacturaLbl;
    }
}
