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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPropiedades = new System.Windows.Forms.ComboBox();
            this.btbGenerarCuota = new System.Windows.Forms.Button();
            this.dvgResultado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una propiedad";
            // 
            // cmbPropiedades
            // 
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(189, 49);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(204, 21);
            this.cmbPropiedades.TabIndex = 1;
            // 
            // btbGenerarCuota
            // 
            this.btbGenerarCuota.Location = new System.Drawing.Point(43, 189);
            this.btbGenerarCuota.Name = "btbGenerarCuota";
            this.btbGenerarCuota.Size = new System.Drawing.Size(165, 23);
            this.btbGenerarCuota.TabIndex = 2;
            this.btbGenerarCuota.Text = "Generar Cuota ";
            this.btbGenerarCuota.UseVisualStyleBackColor = true;
            this.btbGenerarCuota.Click += new System.EventHandler(this.btbGenerarCuota_Click);
            // 
            // dvgResultado
            // 
            this.dvgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgResultado.Location = new System.Drawing.Point(23, 303);
            this.dvgResultado.Name = "dvgResultado";
            this.dvgResultado.Size = new System.Drawing.Size(562, 122);
            this.dvgResultado.TabIndex = 3;
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 495);
            this.Controls.Add(this.dvgResultado);
            this.Controls.Add(this.btbGenerarCuota);
            this.Controls.Add(this.cmbPropiedades);
            this.Controls.Add(this.label1);
            this.Name = "FrmFacturacion";
            this.Text = "FrmFacturacion";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.Button btbGenerarCuota;
        private System.Windows.Forms.DataGridView dvgResultado;
    }
}