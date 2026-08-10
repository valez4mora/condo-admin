namespace UI.Forms
{
    partial class FrmPropietario
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
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvPropietarios = new System.Windows.Forms.DataGridView();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.btnLimpiarFormulario = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnBuscarHacienda = new System.Windows.Forms.Button();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 73);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSubtitulo.Location = new System.Drawing.Point(222, 47);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(183, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Registro y Listado de Propietarios";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(262, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(121, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Propietarios";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlContenedor.Controls.Add(this.dgvPropietarios);
            this.pnlContenedor.Controls.Add(this.btnActualizarLista);
            this.pnlContenedor.Controls.Add(this.pnlFormulario);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 73);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlContenedor.Size = new System.Drawing.Size(1060, 505);
            this.pnlContenedor.TabIndex = 1;
            // 
            // dgvPropietarios
            // 
            this.dgvPropietarios.AllowUserToAddRows = false;
            this.dgvPropietarios.AllowUserToDeleteRows = false;
            this.dgvPropietarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropietarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPropietarios.Location = new System.Drawing.Point(294, 44);
            this.dgvPropietarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPropietarios.Name = "dgvPropietarios";
            this.dgvPropietarios.ReadOnly = true;
            this.dgvPropietarios.RowHeadersVisible = false;
            this.dgvPropietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.Size = new System.Drawing.Size(751, 445);
            this.dgvPropietarios.TabIndex = 2;
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizarLista.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLista.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizarLista.Location = new System.Drawing.Point(294, 16);
            this.btnActualizarLista.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(751, 28);
            this.btnActualizarLista.TabIndex = 1;
            this.btnActualizarLista.Text = "Actualizar lista";
            this.btnActualizarLista.UseVisualStyleBackColor = false;
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.btnLimpiarFormulario);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.txtDireccion);
            this.pnlFormulario.Controls.Add(this.lblDireccion);
            this.pnlFormulario.Controls.Add(this.txtEmail);
            this.pnlFormulario.Controls.Add(this.lblEmail);
            this.pnlFormulario.Controls.Add(this.txtTelefono);
            this.pnlFormulario.Controls.Add(this.lblTelefono);
            this.pnlFormulario.Controls.Add(this.cmbSexo);
            this.pnlFormulario.Controls.Add(this.lblSexo);
            this.pnlFormulario.Controls.Add(this.txtApellidos);
            this.pnlFormulario.Controls.Add(this.lblApellidos);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.btnBuscarHacienda);
            this.pnlFormulario.Controls.Add(this.txtIdentificacion);
            this.pnlFormulario.Controls.Add(this.lblIdentificacion);
            this.pnlFormulario.Controls.Add(this.lblFormTitulo);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormulario.Location = new System.Drawing.Point(15, 16);
            this.pnlFormulario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlFormulario.Size = new System.Drawing.Size(279, 473);
            this.pnlFormulario.TabIndex = 0;
            // 
            // btnLimpiarFormulario
            // 
            this.btnLimpiarFormulario.BackColor = System.Drawing.Color.Chocolate;
            this.btnLimpiarFormulario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFormulario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiarFormulario.Location = new System.Drawing.Point(120, 358);
            this.btnLimpiarFormulario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarFormulario.Name = "btnLimpiarFormulario";
            this.btnLimpiarFormulario.Size = new System.Drawing.Size(98, 28);
            this.btnLimpiarFormulario.TabIndex = 17;
            this.btnLimpiarFormulario.Text = "Limpiar";
            this.btnLimpiarFormulario.UseVisualStyleBackColor = false;
            this.btnLimpiarFormulario.Click += new System.EventHandler(this.btnLimpiarFormulario_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Location = new System.Drawing.Point(11, 358);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 28);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(11, 302);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(207, 41);
            this.txtDireccion.TabIndex = 15;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(11, 288);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 14;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(11, 262);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(11, 248);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Correo";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(11, 221);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(207, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(11, 207);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(11, 180);
            this.cmbSexo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(207, 21);
            this.cmbSexo.TabIndex = 9;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(11, 167);
            this.lblSexo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(31, 13);
            this.lblSexo.TabIndex = 8;
            this.lblSexo.Text = "Sexo";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(11, 140);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(207, 20);
            this.txtApellidos.TabIndex = 7;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(11, 126);
            this.lblApellidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(49, 13);
            this.lblApellidos.TabIndex = 6;
            this.lblApellidos.Text = "Apellidos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(11, 99);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(11, 85);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";
            // 
            // btnBuscarHacienda
            // 
            this.btnBuscarHacienda.BackColor = System.Drawing.Color.Teal;
            this.btnBuscarHacienda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHacienda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscarHacienda.Location = new System.Drawing.Point(177, 51);
            this.btnBuscarHacienda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarHacienda.Name = "btnBuscarHacienda";
            this.btnBuscarHacienda.Size = new System.Drawing.Size(77, 33);
            this.btnBuscarHacienda.TabIndex = 3;
            this.btnBuscarHacienda.Text = "Buscar";
            this.btnBuscarHacienda.UseVisualStyleBackColor = false;
            this.btnBuscarHacienda.Click += new System.EventHandler(this.btnBuscarHacienda_Click);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(11, 58);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(144, 20);
            this.txtIdentificacion.TabIndex = 2;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(11, 45);
            this.lblIdentificacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.lblIdentificacion.TabIndex = 1;
            this.lblIdentificacion.Text = "Identificación";
            // 
            // lblFormTitulo
            // 
            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFormTitulo.Location = new System.Drawing.Point(11, 12);
            this.lblFormTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Size = new System.Drawing.Size(168, 21);
            this.lblFormTitulo.TabIndex = 0;
            this.lblFormTitulo.Text = "Registrar Propietario";
            // 
            // FrmPropietario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 578);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmPropietario";
            this.Text = "Propietarios";
            this.Load += new System.EventHandler(this.FrmPropietario_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvPropietarios;
        private System.Windows.Forms.Button btnActualizarLista;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Button btnBuscarHacienda;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiarFormulario;
    }
}