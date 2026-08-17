namespace UI.Forms
{
    partial class FrmGenerarCuota
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
            System.Windows.Forms.DataGridViewCellStyle encabezado1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle encabezado2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpSeleccion = new System.Windows.Forms.GroupBox();
            this.lblSinDatos = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbPropiedades = new System.Windows.Forms.ComboBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblDatosPropiedad = new System.Windows.Forms.Label();
            this.grpCalculo = new System.Windows.Forms.GroupBox();
            this.lblCalculo = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.btnGenerarCuota = new System.Windows.Forms.Button();
            this.grpCuota = new System.Windows.Forms.GroupBox();
            this.dgvCuota = new System.Windows.Forms.DataGridView();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFactura = new System.Windows.Forms.GroupBox();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.colFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropiedadFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEncabezado.SuspendLayout();
            this.grpSeleccion.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpCalculo.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.grpCuota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuota)).BeginInit();
            this.grpFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.SuspendLayout();
            // pnlEncabezado
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1184, 92);
            this.pnlEncabezado.TabIndex = 0;
            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(190, 215, 239);
            this.lblSubtitulo.Location = new System.Drawing.Point(28, 57);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(431, 17);
            this.lblSubtitulo.Text = "Calcule la cuota mensual, registre el cargo y emita su factura";
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(320, 37);
            this.lblTitulo.Text = "Generación de cuotas";
            // grpSeleccion
            this.grpSeleccion.Controls.Add(this.lblSinDatos);
            this.grpSeleccion.Controls.Add(this.btnActualizar);
            this.grpSeleccion.Controls.Add(this.cmbPropiedades);
            this.grpSeleccion.Controls.Add(this.lblPropiedad);
            this.grpSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSeleccion.Location = new System.Drawing.Point(24, 108);
            this.grpSeleccion.Name = "grpSeleccion";
            this.grpSeleccion.Size = new System.Drawing.Size(1136, 82);
            this.grpSeleccion.TabIndex = 1;
            this.grpSeleccion.TabStop = false;
            this.grpSeleccion.Text = "1. Seleccione la propiedad";
            // lblSinDatos
            this.lblSinDatos.AutoSize = true;
            this.lblSinDatos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSinDatos.ForeColor = System.Drawing.Color.Firebrick;
            this.lblSinDatos.Location = new System.Drawing.Point(632, 36);
            this.lblSinDatos.Name = "lblSinDatos";
            this.lblSinDatos.Size = new System.Drawing.Size(192, 15);
            this.lblSinDatos.Text = "No hay propiedades registradas.";
            this.lblSinDatos.Visible = false;
            // btnActualizar
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 181, 193);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.btnActualizar.Location = new System.Drawing.Point(496, 28);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(116, 31);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // cmbPropiedades
            this.cmbPropiedades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedades.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(104, 31);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(374, 25);
            this.cmbPropiedades.TabIndex = 1;
            this.cmbPropiedades.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedades_SelectedIndexChanged);
            // lblPropiedad
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropiedad.Location = new System.Drawing.Point(20, 35);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(64, 15);
            this.lblPropiedad.Text = "Propiedad:";
            // grpDatos
            this.grpDatos.Controls.Add(this.lblDatosPropiedad);
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatos.Location = new System.Drawing.Point(24, 202);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(446, 190);
            this.grpDatos.TabIndex = 2;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de la propiedad";
            // lblDatosPropiedad
            this.lblDatosPropiedad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDatosPropiedad.Location = new System.Drawing.Point(20, 29);
            this.lblDatosPropiedad.Name = "lblDatosPropiedad";
            this.lblDatosPropiedad.Size = new System.Drawing.Size(402, 144);
            this.lblDatosPropiedad.Text = "Seleccione una propiedad para consultar sus datos.";
            // grpCalculo
            this.grpCalculo.Controls.Add(this.lblCalculo);
            this.grpCalculo.Controls.Add(this.lblFormula);
            this.grpCalculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCalculo.Location = new System.Drawing.Point(486, 202);
            this.grpCalculo.Name = "grpCalculo";
            this.grpCalculo.Size = new System.Drawing.Size(674, 190);
            this.grpCalculo.TabIndex = 3;
            this.grpCalculo.TabStop = false;
            this.grpCalculo.Text = "2. Vista previa del cálculo";
            // lblCalculo
            this.lblCalculo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCalculo.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.lblCalculo.Location = new System.Drawing.Point(20, 65);
            this.lblCalculo.Name = "lblCalculo";
            this.lblCalculo.Size = new System.Drawing.Size(626, 108);
            this.lblCalculo.Text = "Cuota base: ₡0,00\r\nIVA (13 %): ₡0,00\r\nTotal: ₡0,00\r\nFondo de reserva (10 %): ₡0,00";
            // lblFormula
            this.lblFormula.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFormula.Location = new System.Drawing.Point(20, 29);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(626, 30);
            this.lblFormula.Text = "Fórmula: —";
            // pnlAcciones
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(244, 247, 250);
            this.pnlAcciones.Controls.Add(this.lblEstado);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnGenerarFactura);
            this.pnlAcciones.Controls.Add(this.btnGenerarCuota);
            this.pnlAcciones.Location = new System.Drawing.Point(24, 406);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1136, 66);
            this.pnlAcciones.TabIndex = 4;
            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(90, 100, 110);
            this.lblEstado.Location = new System.Drawing.Point(20, 25);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(142, 15);
            this.lblEstado.Text = "Seleccione una propiedad";
            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 181, 193);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(691, 17);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 34);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // btnGenerarCuota
            this.btnGenerarCuota.BackColor = System.Drawing.Color.FromArgb(39, 108, 174);
            this.btnGenerarCuota.FlatAppearance.BorderSize = 0;
            this.btnGenerarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCuota.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCuota.Location = new System.Drawing.Point(826, 17);
            this.btnGenerarCuota.Name = "btnGenerarCuota";
            this.btnGenerarCuota.Size = new System.Drawing.Size(140, 34);
            this.btnGenerarCuota.TabIndex = 4;
            this.btnGenerarCuota.Text = "Generar cuota";
            this.btnGenerarCuota.UseVisualStyleBackColor = false;
            this.btnGenerarCuota.Click += new System.EventHandler(this.btnGenerarCuota_Click);
            // btnGenerarFactura
            this.btnGenerarFactura.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnGenerarFactura.Enabled = false;
            this.btnGenerarFactura.FlatAppearance.BorderSize = 0;
            this.btnGenerarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarFactura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerarFactura.ForeColor = System.Drawing.Color.White;
            this.btnGenerarFactura.Location = new System.Drawing.Point(976, 17);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(140, 34);
            this.btnGenerarFactura.TabIndex = 5;
            this.btnGenerarFactura.Text = "Emitir factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = false;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // grpCuota
            this.grpCuota.Controls.Add(this.dgvCuota);
            this.grpCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCuota.Location = new System.Drawing.Point(24, 486);
            this.grpCuota.Name = "grpCuota";
            this.grpCuota.Size = new System.Drawing.Size(1136, 150);
            this.grpCuota.TabIndex = 5;
            this.grpCuota.TabStop = false;
            this.grpCuota.Text = "3. Cuota generada";
            // dgvCuota
            encabezado1.BackColor = System.Drawing.Color.FromArgb(230, 237, 244);
            encabezado1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            encabezado1.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            encabezado1.SelectionBackColor = System.Drawing.Color.FromArgb(230, 237, 244);
            encabezado1.SelectionForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.dgvCuota.BackgroundColor = System.Drawing.Color.White;
            this.dgvCuota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCuota.ColumnHeadersDefaultCellStyle = encabezado1;
            this.dgvCuota.ColumnHeadersHeight = 36;
            this.dgvCuota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colCargo, this.colDescripcion, this.colBase, this.colIva, this.colTotal, this.colVencimiento, this.colEstadoCargo });
            this.dgvCuota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuota.EnableHeadersVisualStyles = false;
            this.dgvCuota.Location = new System.Drawing.Point(3, 19);
            this.dgvCuota.Name = "dgvCuota";
            this.dgvCuota.Size = new System.Drawing.Size(1130, 128);
            // columnas cuota
            this.colCargo.DataPropertyName = "IdCargo"; this.colCargo.HeaderText = "N.° cargo"; this.colCargo.FillWeight = 55F;
            this.colDescripcion.DataPropertyName = "Descripcion"; this.colDescripcion.HeaderText = "Descripción"; this.colDescripcion.FillWeight = 170F;
            this.colBase.DataPropertyName = "MontoBase"; this.colBase.HeaderText = "Monto base"; this.colBase.DefaultCellStyle.Format = "C2";
            this.colIva.DataPropertyName = "IVA"; this.colIva.HeaderText = "IVA"; this.colIva.DefaultCellStyle.Format = "C2";
            this.colTotal.DataPropertyName = "Total"; this.colTotal.HeaderText = "Total"; this.colTotal.DefaultCellStyle.Format = "C2";
            this.colVencimiento.DataPropertyName = "FechaVencimiento"; this.colVencimiento.HeaderText = "Vencimiento"; this.colVencimiento.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colEstadoCargo.DataPropertyName = "Estado"; this.colEstadoCargo.HeaderText = "Estado";
            // grpFactura
            this.grpFactura.Controls.Add(this.dgvFactura);
            this.grpFactura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFactura.Location = new System.Drawing.Point(24, 648);
            this.grpFactura.Name = "grpFactura";
            this.grpFactura.Size = new System.Drawing.Size(1136, 150);
            this.grpFactura.TabIndex = 6;
            this.grpFactura.TabStop = false;
            this.grpFactura.Text = "4. Factura emitida";
            // dgvFactura
            encabezado2.BackColor = System.Drawing.Color.FromArgb(230, 237, 244);
            encabezado2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            encabezado2.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            encabezado2.SelectionBackColor = System.Drawing.Color.FromArgb(230, 237, 244);
            encabezado2.SelectionForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.dgvFactura.BackgroundColor = System.Drawing.Color.White;
            this.dgvFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFactura.ColumnHeadersDefaultCellStyle = encabezado2;
            this.dgvFactura.ColumnHeadersHeight = 36;
            this.dgvFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colFactura, this.colFecha, this.colPropiedadFactura, this.colColones, this.colDolares, this.colTipoCambio, this.colEstadoFactura });
            this.dgvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFactura.EnableHeadersVisualStyles = false;
            this.dgvFactura.Location = new System.Drawing.Point(3, 19);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.Size = new System.Drawing.Size(1130, 128);
            // columnas factura
            this.colFactura.DataPropertyName = "IdFactura"; this.colFactura.HeaderText = "N.° factura";
            this.colFecha.DataPropertyName = "Fecha"; this.colFecha.HeaderText = "Fecha"; this.colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colPropiedadFactura.DataPropertyName = "CodigoPropiedad"; this.colPropiedadFactura.HeaderText = "Propiedad";
            this.colColones.DataPropertyName = "TotalColones"; this.colColones.HeaderText = "Total (₡)"; this.colColones.DefaultCellStyle.Format = "N2";
            this.colDolares.DataPropertyName = "TotalDolares"; this.colDolares.HeaderText = "Total (USD)"; this.colDolares.DefaultCellStyle.Format = "N2";
            this.colTipoCambio.DataPropertyName = "TipoCambio"; this.colTipoCambio.HeaderText = "Tipo de cambio"; this.colTipoCambio.DefaultCellStyle.Format = "N4";
            this.colEstadoFactura.DataPropertyName = "Estado"; this.colEstadoFactura.HeaderText = "Estado";
            // FrmGenerarCuota
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 821);
            this.Controls.Add(this.grpFactura);
            this.Controls.Add(this.grpCuota);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.grpCalculo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.grpSeleccion);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 860);
            this.Name = "FrmGenerarCuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generar cuotas de mantenimiento";
            this.Load += new System.EventHandler(this.FrmGenerarCuota_Load);
            this.pnlEncabezado.ResumeLayout(false); this.pnlEncabezado.PerformLayout();
            this.grpSeleccion.ResumeLayout(false); this.grpSeleccion.PerformLayout();
            this.grpDatos.ResumeLayout(false); this.grpCalculo.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false); this.pnlAcciones.PerformLayout();
            this.grpCuota.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvCuota)).EndInit();
            this.grpFactura.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.Label lblSinDatos;
        private System.Windows.Forms.Label lblDatosPropiedad;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label lblCalculo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpSeleccion;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpCalculo;
        private System.Windows.Forms.GroupBox grpCuota;
        private System.Windows.Forms.GroupBox grpFactura;
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGenerarCuota;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.DataGridView dgvCuota;
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropiedadFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoFactura;
    }
}
