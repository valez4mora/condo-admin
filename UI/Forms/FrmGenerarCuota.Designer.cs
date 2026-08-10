namespace UI.Forms
{
    partial class FrmGenerarCuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbPropiedades = new System.Windows.Forms.ComboBox();
            this.btbGenerarCuota = new System.Windows.Forms.Button();
            this.dvgResultado = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.dvgFactura = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPropiedades
            // 
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(107, 28);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(204, 21);
            this.cmbPropiedades.TabIndex = 1;
            // 
            // btbGenerarCuota
            // 
            this.btbGenerarCuota.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btbGenerarCuota.Location = new System.Drawing.Point(224, 120);
            this.btbGenerarCuota.Name = "btbGenerarCuota";
            this.btbGenerarCuota.Size = new System.Drawing.Size(165, 23);
            this.btbGenerarCuota.TabIndex = 2;
            this.btbGenerarCuota.Text = "Generar Cuota ";
            this.btbGenerarCuota.UseVisualStyleBackColor = false;
            this.btbGenerarCuota.Click += new System.EventHandler(this.btbGenerarCuota_Click);
            // 
            // dvgResultado
            // 
            this.dvgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgResultado.Location = new System.Drawing.Point(23, 168);
            this.dvgResultado.Name = "dvgResultado";
            this.dvgResultado.Size = new System.Drawing.Size(556, 73);
            this.dvgResultado.TabIndex = 3;
            this.dvgResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgResultado_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPropiedades);
            this.groupBox1.Location = new System.Drawing.Point(23, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 73);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una propiedad";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnGenerarFactura.Location = new System.Drawing.Point(224, 270);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(165, 23);
            this.btnGenerarFactura.TabIndex = 5;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = false;
            this.btnGenerarFactura.Click += new System.EventHandler(this.button1_Click);
            // 
            // dvgFactura
            // 
            this.dvgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFactura.Location = new System.Drawing.Point(23, 311);
            this.dvgFactura.Name = "dvgFactura";
            this.dvgFactura.Size = new System.Drawing.Size(556, 74);
            this.dvgFactura.TabIndex = 6;
            // 
            // FrmGenerarCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 495);
            this.Controls.Add(this.dvgFactura);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dvgResultado);
            this.Controls.Add(this.btbGenerarCuota);
            this.Name = "FrmGenerarCuota";
            this.Text = "FrmFacturacion";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.Button btbGenerarCuota;
        private System.Windows.Forms.DataGridView dvgResultado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.DataGridView dvgFactura;
    }
}