namespace UI.Forms
{
    partial class FrmPermisos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chePropiedad = new System.Windows.Forms.CheckBox();
            this.cheResidente = new System.Windows.Forms.CheckBox();
            this.cheFacturacion = new System.Windows.Forms.CheckBox();
            this.cheReserva = new System.Windows.Forms.CheckBox();
            this.cheAcceso = new System.Windows.Forms.CheckBox();
            this.cheReporte = new System.Windows.Forms.CheckBox();
            this.cheSeguridad = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 96);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registro, configuración y administración de permisos del sistema";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Image = global::UI.Properties.Resources.ciudad__1_1;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "     Gestión de Permisos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoles);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.groupBox1.Location = new System.Drawing.Point(86, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(40, 27);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(167, 23);
            this.cmbRoles.TabIndex = 1;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(11, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Rol";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cheSeguridad);
            this.groupBox2.Controls.Add(this.cheReporte);
            this.groupBox2.Controls.Add(this.cheAcceso);
            this.groupBox2.Controls.Add(this.cheReserva);
            this.groupBox2.Controls.Add(this.cheFacturacion);
            this.groupBox2.Controls.Add(this.cheResidente);
            this.groupBox2.Controls.Add(this.chePropiedad);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.groupBox2.Location = new System.Drawing.Point(86, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 194);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Módulo :";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.Location = new System.Drawing.Point(166, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 28);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "+ Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chePropiedad
            // 
            this.chePropiedad.AutoSize = true;
            this.chePropiedad.Location = new System.Drawing.Point(14, 49);
            this.chePropiedad.Name = "chePropiedad";
            this.chePropiedad.Size = new System.Drawing.Size(82, 19);
            this.chePropiedad.TabIndex = 1;
            this.chePropiedad.Text = "Propiedad";
            this.chePropiedad.UseVisualStyleBackColor = true;
            // 
            // cheResidente
            // 
            this.cheResidente.AutoSize = true;
            this.cheResidente.Location = new System.Drawing.Point(14, 74);
            this.cheResidente.Name = "cheResidente";
            this.cheResidente.Size = new System.Drawing.Size(82, 19);
            this.cheResidente.TabIndex = 2;
            this.cheResidente.Text = "Residente";
            this.cheResidente.UseVisualStyleBackColor = true;
            // 
            // cheFacturacion
            // 
            this.cheFacturacion.AutoSize = true;
            this.cheFacturacion.Location = new System.Drawing.Point(14, 99);
            this.cheFacturacion.Name = "cheFacturacion";
            this.cheFacturacion.Size = new System.Drawing.Size(90, 19);
            this.cheFacturacion.TabIndex = 3;
            this.cheFacturacion.Text = "Facturación";
            this.cheFacturacion.UseVisualStyleBackColor = true;
            // 
            // cheReserva
            // 
            this.cheReserva.AutoSize = true;
            this.cheReserva.Location = new System.Drawing.Point(14, 124);
            this.cheReserva.Name = "cheReserva";
            this.cheReserva.Size = new System.Drawing.Size(71, 19);
            this.cheReserva.TabIndex = 4;
            this.cheReserva.Text = "Reserva";
            this.cheReserva.UseVisualStyleBackColor = true;
            // 
            // cheAcceso
            // 
            this.cheAcceso.AutoSize = true;
            this.cheAcceso.Location = new System.Drawing.Point(14, 149);
            this.cheAcceso.Name = "cheAcceso";
            this.cheAcceso.Size = new System.Drawing.Size(65, 19);
            this.cheAcceso.TabIndex = 5;
            this.cheAcceso.Text = "Acceso";
            this.cheAcceso.UseVisualStyleBackColor = true;
            // 
            // cheReporte
            // 
            this.cheReporte.AutoSize = true;
            this.cheReporte.Location = new System.Drawing.Point(128, 49);
            this.cheReporte.Name = "cheReporte";
            this.cheReporte.Size = new System.Drawing.Size(72, 19);
            this.cheReporte.TabIndex = 6;
            this.cheReporte.Text = "Reporte";
            this.cheReporte.UseVisualStyleBackColor = true;
            // 
            // cheSeguridad
            // 
            this.cheSeguridad.AutoSize = true;
            this.cheSeguridad.Location = new System.Drawing.Point(128, 74);
            this.cheSeguridad.Name = "cheSeguridad";
            this.cheSeguridad.Size = new System.Drawing.Size(82, 19);
            this.cheSeguridad.TabIndex = 7;
            this.cheSeguridad.Text = "Seguridad";
            this.cheSeguridad.UseVisualStyleBackColor = true;
            // 
            // FrmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 450);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPermisos";
            this.Text = "FrmPermisos";
            this.Load += new System.EventHandler(this.FrmPermisos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox cheSeguridad;
        private System.Windows.Forms.CheckBox cheReporte;
        private System.Windows.Forms.CheckBox cheAcceso;
        private System.Windows.Forms.CheckBox cheReserva;
        private System.Windows.Forms.CheckBox cheFacturacion;
        private System.Windows.Forms.CheckBox cheResidente;
        private System.Windows.Forms.CheckBox chePropiedad;
    }
}