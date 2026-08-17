namespace UI.Forms
{
    partial class FrmResidente
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.rdoCedula = new System.Windows.Forms.RadioButton();
            this.rdoPasaporte = new System.Windows.Forms.RadioButton();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblAyudaId = new System.Windows.Forms.Label();
            this.btnBuscarHacienda = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.grpFoto = new System.Windows.Forms.GroupBox();
            this.lblSinFoto = new System.Windows.Forms.Label();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpListado = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvResidentes = new System.Windows.Forms.DataGridView();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.pnlEncabezado.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpFoto.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblEstado);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1175, 78);
            this.pnlEncabezado.TabIndex = 4;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(293, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de residentes";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblEstado.Location = new System.Drawing.Point(31, 51);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(283, 17);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Complete los datos para registrar un residente";
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.rdoCedula);
            this.grpDatos.Controls.Add(this.rdoPasaporte);
            this.grpDatos.Controls.Add(this.lblIdentificacion);
            this.grpDatos.Controls.Add(this.txtIdentificacion);
            this.grpDatos.Controls.Add(this.lblAyudaId);
            this.grpDatos.Controls.Add(this.btnBuscarHacienda);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblApellidos);
            this.grpDatos.Controls.Add(this.txtApellidos);
            this.grpDatos.Controls.Add(this.lblSexo);
            this.grpDatos.Controls.Add(this.cmbSexo);
            this.grpDatos.Controls.Add(this.lblTelefono);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.lblEmail);
            this.grpDatos.Controls.Add(this.txtEmail);
            this.grpDatos.Controls.Add(this.lblDireccion);
            this.grpDatos.Controls.Add(this.txtDireccion);
            this.grpDatos.Controls.Add(this.lblPropiedad);
            this.grpDatos.Controls.Add(this.cmbPropiedad);
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.grpDatos.Location = new System.Drawing.Point(25, 94);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(860, 310);
            this.grpDatos.TabIndex = 3;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Información personal y asignación";
            // 
            // rdoCedula
            // 
            this.rdoCedula.AutoSize = true;
            this.rdoCedula.Checked = true;
            this.rdoCedula.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoCedula.Location = new System.Drawing.Point(22, 27);
            this.rdoCedula.Name = "rdoCedula";
            this.rdoCedula.Size = new System.Drawing.Size(110, 19);
            this.rdoCedula.TabIndex = 0;
            this.rdoCedula.TabStop = true;
            this.rdoCedula.Text = "Cédula nacional";
            this.rdoCedula.CheckedChanged += new System.EventHandler(this.rdoTipoId_CheckedChanged);
            // 
            // rdoPasaporte
            // 
            this.rdoPasaporte.AutoSize = true;
            this.rdoPasaporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoPasaporte.Location = new System.Drawing.Point(158, 27);
            this.rdoPasaporte.Name = "rdoPasaporte";
            this.rdoPasaporte.Size = new System.Drawing.Size(77, 19);
            this.rdoPasaporte.TabIndex = 1;
            this.rdoPasaporte.Text = "Pasaporte";
            this.rdoPasaporte.CheckedChanged += new System.EventHandler(this.rdoTipoId_CheckedChanged);
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(22, 58);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(86, 15);
            this.lblIdentificacion.TabIndex = 2;
            this.lblIdentificacion.Text = "Identificación ";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(22, 79);
            this.txtIdentificacion.MaxLength = 20;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(220, 23);
            this.txtIdentificacion.TabIndex = 3;
            // 
            // lblAyudaId
            // 
            this.lblAyudaId.AutoSize = true;
            this.lblAyudaId.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblAyudaId.ForeColor = System.Drawing.Color.Gray;
            this.lblAyudaId.Location = new System.Drawing.Point(20, 105);
            this.lblAyudaId.Name = "lblAyudaId";
            this.lblAyudaId.Size = new System.Drawing.Size(63, 12);
            this.lblAyudaId.TabIndex = 4;
            this.lblAyudaId.Text = "9 a 12 dígitos";
            // 
            // btnBuscarHacienda
            // 
            this.btnBuscarHacienda.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarHacienda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHacienda.ForeColor = System.Drawing.Color.White;
            this.btnBuscarHacienda.Location = new System.Drawing.Point(252, 78);
            this.btnBuscarHacienda.Name = "btnBuscarHacienda";
            this.btnBuscarHacienda.Size = new System.Drawing.Size(145, 34);
            this.btnBuscarHacienda.TabIndex = 5;
            this.btnBuscarHacienda.Text = "Consultar Hacienda";
            this.btnBuscarHacienda.UseVisualStyleBackColor = false;
            this.btnBuscarHacienda.Click += new System.EventHandler(this.btnBuscarHacienda_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(420, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 15);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre ";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(420, 79);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 23);
            this.txtNombre.TabIndex = 7;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(635, 58);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(60, 15);
            this.lblApellidos.TabIndex = 8;
            this.lblApellidos.Text = "Apellidos ";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(635, 79);
            this.txtApellidos.MaxLength = 100;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(200, 23);
            this.txtApellidos.TabIndex = 9;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(22, 132);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(38, 15);
            this.lblSexo.TabIndex = 10;
            this.lblSexo.Text = "Sexo ";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexo.Location = new System.Drawing.Point(22, 153);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(120, 23);
            this.cmbSexo.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(162, 132);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(59, 15);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Teléfono ";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(162, 153);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(160, 23);
            this.txtTelefono.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(342, 132);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(114, 15);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Correo electrónico ";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(342, 153);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            this.txtEmail.TabIndex = 15;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(22, 205);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(155, 15);
            this.lblDireccion.TabIndex = 18;
            this.lblDireccion.Text = "Dirección de la propiedad";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(22, 226);
            this.txtDireccion.MaxLength = 220;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(580, 58);
            this.txtDireccion.TabIndex = 19;
            this.txtDireccion.TabStop = false;
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Location = new System.Drawing.Point(622, 132);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(116, 15);
            this.lblPropiedad.TabIndex = 20;
            this.lblPropiedad.Text = "Propiedad asignada ";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPropiedad.Location = new System.Drawing.Point(622, 153);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(213, 23);
            this.cmbPropiedad.TabIndex = 21;
            this.cmbPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbPropiedad_SelectedIndexChanged);
            // 
            // grpFoto
            // 
            this.grpFoto.Controls.Add(this.picFoto);
            this.grpFoto.Controls.Add(this.lblSinFoto);
            this.grpFoto.Controls.Add(this.btnSeleccionarFoto);
            this.grpFoto.Controls.Add(this.btnQuitarFoto);
            this.grpFoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.grpFoto.Location = new System.Drawing.Point(905, 94);
            this.grpFoto.Name = "grpFoto";
            this.grpFoto.Size = new System.Drawing.Size(245, 310);
            this.grpFoto.TabIndex = 2;
            this.grpFoto.TabStop = false;
            this.grpFoto.Text = "Fotografía del residente";
            // 
            // lblSinFoto
            // 
            this.lblSinFoto.BackColor = System.Drawing.Color.Transparent;
            this.lblSinFoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSinFoto.ForeColor = System.Drawing.Color.Gray;
            this.lblSinFoto.Location = new System.Drawing.Point(54, 115);
            this.lblSinFoto.Name = "lblSinFoto";
            this.lblSinFoto.Size = new System.Drawing.Size(138, 20);
            this.lblSinFoto.TabIndex = 1;
            this.lblSinFoto.Text = "Sin fotografía";
            this.lblSinFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSeleccionarFoto
            // 
            this.btnSeleccionarFoto.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSeleccionarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFoto.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(25, 247);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(195, 28);
            this.btnSeleccionarFoto.TabIndex = 2;
            this.btnSeleccionarFoto.Text = "Seleccionar foto";
            this.btnSeleccionarFoto.UseVisualStyleBackColor = false;
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);
            // 
            // btnQuitarFoto
            // 
            this.btnQuitarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnQuitarFoto.Enabled = false;
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFoto.Location = new System.Drawing.Point(25, 278);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(195, 26);
            this.btnQuitarFoto.TabIndex = 3;
            this.btnQuitarFoto.Text = "Quitar foto";
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Controls.Add(this.btnActualizar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Location = new System.Drawing.Point(25, 416);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1125, 48);
            this.pnlAcciones.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.Enabled = false;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(195, 5);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(180, 34);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(390, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 34);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(945, 5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 34);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Nuevo / Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grpListado
            // 
            this.grpListado.Controls.Add(this.lblBuscar);
            this.grpListado.Controls.Add(this.txtBuscar);
            this.grpListado.Controls.Add(this.btnBuscar);
            this.grpListado.Controls.Add(this.btnActualizarLista);
            this.grpListado.Controls.Add(this.lblTotal);
            this.grpListado.Controls.Add(this.dgvResidentes);
            this.grpListado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpListado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.grpListado.Location = new System.Drawing.Point(25, 476);
            this.grpListado.Name = "grpListado";
            this.grpListado.Size = new System.Drawing.Size(1125, 300);
            this.grpListado.TabIndex = 0;
            this.grpListado.TabStop = false;
            this.grpListado.Text = "Residentes registrados";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(20, 31);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(47, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(78, 27);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(400, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(490, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnActualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLista.ForeColor = System.Drawing.Color.White;
            this.btnActualizarLista.Location = new System.Drawing.Point(602, 25);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(135, 28);
            this.btnActualizarLista.TabIndex = 3;
            this.btnActualizarLista.Text = "Actualizar lista";
            this.btnActualizarLista.UseVisualStyleBackColor = false;
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTotal.Location = new System.Drawing.Point(880, 31);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(109, 15);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: 0 residente(s)";
            // 
            // dgvResidentes
            // 
            this.dgvResidentes.AllowUserToAddRows = false;
            this.dgvResidentes.AllowUserToDeleteRows = false;
            this.dgvResidentes.BackgroundColor = System.Drawing.Color.White;
            this.dgvResidentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResidentes.ColumnHeadersHeight = 34;
            this.dgvResidentes.Location = new System.Drawing.Point(20, 67);
            this.dgvResidentes.MultiSelect = false;
            this.dgvResidentes.Name = "dgvResidentes";
            this.dgvResidentes.ReadOnly = true;
            this.dgvResidentes.RowHeadersVisible = false;
            this.dgvResidentes.RowTemplate.Height = 29;
            this.dgvResidentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidentes.Size = new System.Drawing.Size(1085, 210);
            this.dgvResidentes.TabIndex = 5;
            this.dgvResidentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidentes_CellClick);
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(25, 29);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(195, 205);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // FrmResidente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1175, 800);
            this.Controls.Add(this.grpListado);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.grpFoto);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1191, 839);
            this.Name = "FrmResidente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Residentes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResidente_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpFoto.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.grpListado.ResumeLayout(false);
            this.grpListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlEncabezado,pnlAcciones; private System.Windows.Forms.Label lblTitulo,lblEstado,lblIdentificacion,lblAyudaId,lblNombre,lblApellidos,lblSexo,lblTelefono,lblEmail,lblDireccion,lblPropiedad,lblSinFoto,lblBuscar,lblTotal;
        private System.Windows.Forms.GroupBox grpDatos,grpFoto,grpListado; private System.Windows.Forms.RadioButton rdoCedula,rdoPasaporte; private System.Windows.Forms.TextBox txtIdentificacion,txtNombre,txtApellidos,txtTelefono,txtEmail,txtDireccion,txtBuscar;
        private System.Windows.Forms.ComboBox cmbSexo,cmbPropiedad; private System.Windows.Forms.Button btnBuscarHacienda,btnSeleccionarFoto,btnQuitarFoto,btnGuardar,btnActualizar,btnEliminar,btnLimpiar,btnBuscar,btnActualizarLista; private System.Windows.Forms.PictureBox picFoto; private System.Windows.Forms.DataGridView dgvResidentes;
    }
}
