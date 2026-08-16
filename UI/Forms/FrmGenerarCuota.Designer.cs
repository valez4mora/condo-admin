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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFactura)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPropiedades
            // 
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(77, 30);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(204, 21);
            this.cmbPropiedades.TabIndex = 1;
            // 
            // btbGenerarCuota
            // 
            this.btbGenerarCuota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btbGenerarCuota.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btbGenerarCuota.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btbGenerarCuota.Location = new System.Drawing.Point(442, 448);
            this.btbGenerarCuota.Name = "btbGenerarCuota";
            this.btbGenerarCuota.Size = new System.Drawing.Size(165, 35);
            this.btbGenerarCuota.TabIndex = 2;
            this.btbGenerarCuota.Text = "+ Generar Cuota ";
            this.btbGenerarCuota.UseVisualStyleBackColor = false;
            this.btbGenerarCuota.Click += new System.EventHandler(this.btbGenerarCuota_Click);
            // 
            // dvgResultado
            // 
            this.dvgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgResultado.Location = new System.Drawing.Point(368, 130);
            this.dvgResultado.Name = "dvgResultado";
            this.dvgResultado.Size = new System.Drawing.Size(307, 302);
            this.dvgResultado.TabIndex = 3;
            this.dvgResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgResultado_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbPropiedades);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 73);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una propiedad";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGenerarFactura.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerarFactura.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerarFactura.Location = new System.Drawing.Point(795, 448);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(165, 35);
            this.btnGenerarFactura.TabIndex = 5;
            this.btnGenerarFactura.Text = "+ Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = false;
            this.btnGenerarFactura.Click += new System.EventHandler(this.button1_Click);
            // 
            // dvgFactura
            // 
            this.dvgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFactura.Location = new System.Drawing.Point(702, 129);
            this.dvgFactura.Name = "dvgFactura";
            this.dvgFactura.Size = new System.Drawing.Size(307, 303);
            this.dvgFactura.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 115);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Image = global::UI.Properties.Resources.ciudad__1_3;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "     Generar Cuota ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registro y generación de cuotas de mantenimiento del condominio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Propiedad";
            // 
            // FrmGenerarCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 495);
            this.Controls.Add(this.panel1);
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
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFactura)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.Button btbGenerarCuota;
        private System.Windows.Forms.DataGridView dvgResultado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.DataGridView dvgFactura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}