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
            this.cmbPropiedades = new System.Windows.Forms.ComboBox();
            this.dvgResultado = new System.Windows.Forms.DataGridView();
            this.btnPenalizacion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPropiedades
            // 
            this.cmbPropiedades.FormattingEnabled = true;
            this.cmbPropiedades.Location = new System.Drawing.Point(24, 32);
            this.cmbPropiedades.Name = "cmbPropiedades";
            this.cmbPropiedades.Size = new System.Drawing.Size(205, 25);
            this.cmbPropiedades.TabIndex = 1;
            // 
            // dvgResultado
            // 
            this.dvgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgResultado.Location = new System.Drawing.Point(334, 129);
            this.dvgResultado.Name = "dvgResultado";
            this.dvgResultado.Size = new System.Drawing.Size(478, 297);
            this.dvgResultado.TabIndex = 2;
            this.dvgResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPenalizacion
            // 
            this.btnPenalizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnPenalizacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPenalizacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPenalizacion.Location = new System.Drawing.Point(61, 203);
            this.btnPenalizacion.Name = "btnPenalizacion";
            this.btnPenalizacion.Size = new System.Drawing.Size(181, 33);
            this.btnPenalizacion.TabIndex = 3;
            this.btnPenalizacion.Text = "+ Generar penalización";
            this.btnPenalizacion.UseVisualStyleBackColor = false;
            this.btnPenalizacion.Click += new System.EventHandler(this.btnPenalizacion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 109);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Image = global::UI.Properties.Resources.ciudad__1_3;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(31, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "     Gestión de Penalizaciones";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPropiedades);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione una Propiedad ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(34, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generación de penalizaciones por incumplimientos en el condominio";
            // 
            // FrmPenalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPenalizacion);
            this.Controls.Add(this.dvgResultado);
            this.Name = "FrmPenalizacion";
            this.Text = "FrmPenalizacion";
            this.Load += new System.EventHandler(this.FrmPenalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgResultado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPropiedades;
        private System.Windows.Forms.DataGridView dvgResultado;
        private System.Windows.Forms.Button btnPenalizacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}