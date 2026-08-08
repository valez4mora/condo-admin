namespace UI.Forms
{
    partial class FrmPenalizacion
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
            this.dvgResultado = new System.Windows.Forms.DataGridView();
            this.btnPenalizacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una propiedad";
            // 
            // cmbPropiedades
            // 
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(71, 57);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(205, 21);
            this.cmbPropiedades.TabIndex = 1;
            // 
            // dvgResultado
            // 
            this.dvgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgResultado.Location = new System.Drawing.Point(21, 107);
            this.dvgResultado.Name = "dvgResultado";
            this.dvgResultado.Size = new System.Drawing.Size(311, 228);
            this.dvgResultado.TabIndex = 2;
            this.dvgResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPenalizacion
            // 
            this.btnPenalizacion.Location = new System.Drawing.Point(367, 188);
            this.btnPenalizacion.Name = "btnPenalizacion";
            this.btnPenalizacion.Size = new System.Drawing.Size(158, 23);
            this.btnPenalizacion.TabIndex = 3;
            this.btnPenalizacion.Text = "Generar penalización";
            this.btnPenalizacion.UseVisualStyleBackColor = true;
            this.btnPenalizacion.Click += new System.EventHandler(this.btnPenalizacion_Click);
            // 
            // FrmPenalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 472);
            this.Controls.Add(this.btnPenalizacion);
            this.Controls.Add(this.dvgResultado);
            this.Controls.Add(this.cmbPropiedades);
            this.Controls.Add(this.label1);
            this.Name = "FrmPenalizacion";
            this.Text = "FrmPenalizacion";
            this.Load += new System.EventHandler(this.FrmPenalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.DataGridView dvgResultado;
        private System.Windows.Forms.Button btnPenalizacion;
    }
}