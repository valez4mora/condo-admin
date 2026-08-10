namespace UI.Forms
{
    partial class FrmMorosidad
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblPropietarioValor = new System.Windows.Forms.Label();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.nudMontoAdeudado = new System.Windows.Forms.NumericUpDown();
            this.lblMontoAdeudado = new System.Windows.Forms.Label();
            this.nudFacturasPendientes = new System.Windows.Forms.NumericUpDown();
            this.lblFacturasPendientes = new System.Windows.Forms.Label();
            this.nudMesesMora = new System.Windows.Forms.NumericUpDown();
            this.lblMesesMora = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.grpResultado = new System.Windows.Forms.GroupBox();
            this.txtFechaCalculo = new System.Windows.Forms.TextBox();
            this.lblFechaCalculo = new System.Windows.Forms.Label();
            this.txtClasificacion = new System.Windows.Forms.TextBox();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.txtIndiceRiesgo = new System.Windows.Forms.TextBox();
            this.lblIndiceRiesgo = new System.Windows.Forms.Label();
            this.btnCalcularRegistrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoAdeudado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFacturasPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesesMora)).BeginInit();
            this.grpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(850, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 61);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(323, 13);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Cálculo y registro del índice de riesgo financiero de una propiedad";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(29, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(272, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Control de Morosidad";
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblPropietarioValor);
            this.grpDatos.Controls.Add(this.lblPropietario);
            this.grpDatos.Controls.Add(this.nudMontoAdeudado);
            this.grpDatos.Controls.Add(this.lblMontoAdeudado);
            this.grpDatos.Controls.Add(this.nudFacturasPendientes);
            this.grpDatos.Controls.Add(this.lblFacturasPendientes);
            this.grpDatos.Controls.Add(this.nudMesesMora);
            this.grpDatos.Controls.Add(this.lblMesesMora);
            this.grpDatos.Controls.Add(this.cmbPropiedad);
            this.grpDatos.Controls.Add(this.lblPropiedad);
            this.grpDatos.Location = new System.Drawing.Point(34, 128);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(782, 225);
            this.grpDatos.TabIndex = 1;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de la propiedad";
            // 
            // lblPropietarioValor
            // 
            this.lblPropietarioValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPropietarioValor.Location = new System.Drawing.Point(175, 73);
            this.lblPropietarioValor.Name = "lblPropietarioValor";
            this.lblPropietarioValor.Size = new System.Drawing.Size(533, 23);
            this.lblPropietarioValor.TabIndex = 9;
            this.lblPropietarioValor.Text = "-";
            this.lblPropietarioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Location = new System.Drawing.Point(38, 78);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(60, 13);
            this.lblPropietario.TabIndex = 8;
            this.lblPropietario.Text = "Propietario:";
            // 
            // nudMontoAdeudado
            // 
            this.nudMontoAdeudado.DecimalPlaces = 2;
            this.nudMontoAdeudado.Location = new System.Drawing.Point(522, 158);
            this.nudMontoAdeudado.Name = "nudMontoAdeudado";
            this.nudMontoAdeudado.Size = new System.Drawing.Size(186, 20);
            this.nudMontoAdeudado.TabIndex = 4;
            this.nudMontoAdeudado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoAdeudado.ThousandsSeparator = true;
            // 
            // lblMontoAdeudado
            // 
            this.lblMontoAdeudado.AutoSize = true;
            this.lblMontoAdeudado.Location = new System.Drawing.Point(399, 160);
            this.lblMontoAdeudado.Name = "lblMontoAdeudado";
            this.lblMontoAdeudado.Size = new System.Drawing.Size(91, 13);
            this.lblMontoAdeudado.TabIndex = 6;
            this.lblMontoAdeudado.Text = "Monto adeudado:";
            // 
            // nudFacturasPendientes
            // 
            this.nudFacturasPendientes.Location = new System.Drawing.Point(175, 158);
            this.nudFacturasPendientes.Name = "nudFacturasPendientes";
            this.nudFacturasPendientes.Size = new System.Drawing.Size(170, 20);
            this.nudFacturasPendientes.TabIndex = 3;
            this.nudFacturasPendientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFacturasPendientes
            // 
            this.lblFacturasPendientes.AutoSize = true;
            this.lblFacturasPendientes.Location = new System.Drawing.Point(38, 160);
            this.lblFacturasPendientes.Name = "lblFacturasPendientes";
            this.lblFacturasPendientes.Size = new System.Drawing.Size(104, 13);
            this.lblFacturasPendientes.TabIndex = 4;
            this.lblFacturasPendientes.Text = "Facturas pendientes:";
            // 
            // nudMesesMora
            // 
            this.nudMesesMora.Location = new System.Drawing.Point(175, 118);
            this.nudMesesMora.Name = "nudMesesMora";
            this.nudMesesMora.Size = new System.Drawing.Size(170, 20);
            this.nudMesesMora.TabIndex = 2;
            this.nudMesesMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMesesMora
            // 
            this.lblMesesMora.AutoSize = true;
            this.lblMesesMora.Location = new System.Drawing.Point(38, 120);
            this.lblMesesMora.Name = "lblMesesMora";
            this.lblMesesMora.Size = new System.Drawing.Size(79, 13);
            this.lblMesesMora.TabIndex = 2;
            this.lblMesesMora.Text = "Meses de mora:";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.FormattingEnabled = true;
            this.cmbPropiedad.Location = new System.Drawing.Point(175, 34);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(250, 21);
            this.cmbPropiedad.TabIndex = 1;
            this.cmbPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedad_SelectedIndexChanged);
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Location = new System.Drawing.Point(38, 37);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(58, 13);
            this.lblPropiedad.TabIndex = 0;
            this.lblPropiedad.Text = "Propiedad:";
            // 
            // grpResultado
            // 
            this.grpResultado.Controls.Add(this.txtFechaCalculo);
            this.grpResultado.Controls.Add(this.lblFechaCalculo);
            this.grpResultado.Controls.Add(this.txtClasificacion);
            this.grpResultado.Controls.Add(this.lblClasificacion);
            this.grpResultado.Controls.Add(this.txtIndiceRiesgo);
            this.grpResultado.Controls.Add(this.lblIndiceRiesgo);
            this.grpResultado.Location = new System.Drawing.Point(34, 377);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(782, 137);
            this.grpResultado.TabIndex = 2;
            this.grpResultado.TabStop = false;
            this.grpResultado.Text = "Resultado";
            // 
            // txtFechaCalculo
            // 
            this.txtFechaCalculo.Location = new System.Drawing.Point(522, 81);
            this.txtFechaCalculo.Name = "txtFechaCalculo";
            this.txtFechaCalculo.ReadOnly = true;
            this.txtFechaCalculo.Size = new System.Drawing.Size(186, 20);
            this.txtFechaCalculo.TabIndex = 7;
            // 
            // lblFechaCalculo
            // 
            this.lblFechaCalculo.AutoSize = true;
            this.lblFechaCalculo.Location = new System.Drawing.Point(399, 84);
            this.lblFechaCalculo.Name = "lblFechaCalculo";
            this.lblFechaCalculo.Size = new System.Drawing.Size(91, 13);
            this.lblFechaCalculo.TabIndex = 4;
            this.lblFechaCalculo.Text = "Fecha de cálculo:";
            // 
            // txtClasificacion
            // 
            this.txtClasificacion.Location = new System.Drawing.Point(175, 81);
            this.txtClasificacion.Name = "txtClasificacion";
            this.txtClasificacion.ReadOnly = true;
            this.txtClasificacion.Size = new System.Drawing.Size(170, 20);
            this.txtClasificacion.TabIndex = 6;
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Location = new System.Drawing.Point(38, 84);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(70, 13);
            this.lblClasificacion.TabIndex = 2;
            this.lblClasificacion.Text = "Clasificación:";
            // 
            // txtIndiceRiesgo
            // 
            this.txtIndiceRiesgo.Location = new System.Drawing.Point(175, 40);
            this.txtIndiceRiesgo.Name = "txtIndiceRiesgo";
            this.txtIndiceRiesgo.ReadOnly = true;
            this.txtIndiceRiesgo.Size = new System.Drawing.Size(170, 20);
            this.txtIndiceRiesgo.TabIndex = 5;
            // 
            // lblIndiceRiesgo
            // 
            this.lblIndiceRiesgo.AutoSize = true;
            this.lblIndiceRiesgo.Location = new System.Drawing.Point(38, 43);
            this.lblIndiceRiesgo.Name = "lblIndiceRiesgo";
            this.lblIndiceRiesgo.Size = new System.Drawing.Size(86, 13);
            this.lblIndiceRiesgo.TabIndex = 0;
            this.lblIndiceRiesgo.Text = "Índice de riesgo:";
            // 
            // btnCalcularRegistrar
            // 
            this.btnCalcularRegistrar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnCalcularRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnCalcularRegistrar.Location = new System.Drawing.Point(460, 545);
            this.btnCalcularRegistrar.Name = "btnCalcularRegistrar";
            this.btnCalcularRegistrar.Size = new System.Drawing.Size(205, 40);
            this.btnCalcularRegistrar.TabIndex = 8;
            this.btnCalcularRegistrar.Text = "Calcular y registrar";
            this.btnCalcularRegistrar.UseVisualStyleBackColor = false;
            this.btnCalcularRegistrar.Click += new System.EventHandler(this.btnCalcularRegistrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(671, 545);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(145, 40);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmMorosidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcularRegistrar);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMorosidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Morosidad";
            this.Load += new System.EventHandler(this.FrmMorosidad_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoAdeudado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFacturasPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesesMora)).EndInit();
            this.grpResultado.ResumeLayout(false);
            this.grpResultado.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblPropietarioValor;
        private System.Windows.Forms.NumericUpDown nudMesesMora;
        private System.Windows.Forms.Label lblMesesMora;
        private System.Windows.Forms.NumericUpDown nudFacturasPendientes;
        private System.Windows.Forms.Label lblFacturasPendientes;
        private System.Windows.Forms.NumericUpDown nudMontoAdeudado;
        private System.Windows.Forms.Label lblMontoAdeudado;
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.TextBox txtIndiceRiesgo;
        private System.Windows.Forms.Label lblIndiceRiesgo;
        private System.Windows.Forms.TextBox txtClasificacion;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.TextBox txtFechaCalculo;
        private System.Windows.Forms.Label lblFechaCalculo;
        private System.Windows.Forms.Button btnCalcularRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
