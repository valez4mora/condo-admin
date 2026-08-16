namespace UI.Forms
{
    partial class FrmControlAcceso
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRegistro = new System.Windows.Forms.TabPage();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblVisitante = new System.Windows.Forms.Label();
            this.txtNombreVisitante = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.grpQR = new System.Windows.Forms.GroupBox();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.btnGuardarQR = new System.Windows.Forms.Button();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroProp = new System.Windows.Forms.Label();
            this.cmbFiltroProp = new System.Windows.Forms.ComboBox();
            this.chkUsarFecha = new System.Windows.Forms.CheckBox();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.grpValidarQR = new System.Windows.Forms.GroupBox();
            this.lblValidarQR = new System.Windows.Forms.Label();
            this.txtCodigoQR = new System.Windows.Forms.TextBox();
            this.btnValidarQR = new System.Windows.Forms.Button();
            this.lblResultadoQR = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabRegistro.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.tabHistorial.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.grpValidarQR.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRegistro);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1207, 645);
            this.tabControl.TabIndex = 0;
            // 
            // tabRegistro
            // 
            this.tabRegistro.Controls.Add(this.grpDatos);
            this.tabRegistro.Controls.Add(this.grpQR);
            this.tabRegistro.Location = new System.Drawing.Point(4, 26);
            this.tabRegistro.Name = "tabRegistro";
            this.tabRegistro.Padding = new System.Windows.Forms.Padding(9);
            this.tabRegistro.Size = new System.Drawing.Size(1199, 615);
            this.tabRegistro.TabIndex = 0;
            this.tabRegistro.Text = "  Registrar Visita  ";
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblPropiedad);
            this.grpDatos.Controls.Add(this.cmbPropiedad);
            this.grpDatos.Controls.Add(this.lblVisitante);
            this.grpDatos.Controls.Add(this.txtNombreVisitante);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.dtpFecha);
            this.grpDatos.Controls.Add(this.lblHoraEntrada);
            this.grpDatos.Controls.Add(this.dtpHoraEntrada);
            this.grpDatos.Controls.Add(this.btnRegistrar);
            this.grpDatos.Controls.Add(this.btnRegistrarSalida);
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatos.Location = new System.Drawing.Point(70, 37);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(607, 468);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de la Visita";
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPropiedad.Location = new System.Drawing.Point(17, 35);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(137, 20);
            this.lblPropiedad.TabIndex = 0;
            this.lblPropiedad.Text = "Propiedad destino:";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPropiedad.Location = new System.Drawing.Point(17, 55);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(438, 25);
            this.cmbPropiedad.TabIndex = 1;
            // 
            // lblVisitante
            // 
            this.lblVisitante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVisitante.Location = new System.Drawing.Point(17, 91);
            this.lblVisitante.Name = "lblVisitante";
            this.lblVisitante.Size = new System.Drawing.Size(137, 20);
            this.lblVisitante.TabIndex = 2;
            this.lblVisitante.Text = "Nombre del visitante:";
            // 
            // txtNombreVisitante
            // 
            this.txtNombreVisitante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreVisitante.Location = new System.Drawing.Point(17, 111);
            this.txtNombreVisitante.MaxLength = 100;
            this.txtNombreVisitante.Name = "txtNombreVisitante";
            this.txtNombreVisitante.Size = new System.Drawing.Size(438, 24);
            this.txtNombreVisitante.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(17, 147);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(137, 20);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha de visita:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(17, 167);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(206, 24);
            this.dtpFecha.TabIndex = 5;
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHoraEntrada.Location = new System.Drawing.Point(17, 204);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(137, 20);
            this.lblHoraEntrada.TabIndex = 6;
            this.lblHoraEntrada.Text = "Hora de entrada:";
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.Location = new System.Drawing.Point(17, 224);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.Size = new System.Drawing.Size(206, 24);
            this.dtpHoraEntrada.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(17, 277);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(229, 36);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "✔  Registrar Visita y Generar QR";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRegistrarSalida.Enabled = false;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(284, 277);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(171, 36);
            this.btnRegistrarSalida.TabIndex = 9;
            this.btnRegistrarSalida.Text = "🚪  Registrar Salida";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // grpQR
            // 
            this.grpQR.Controls.Add(this.picQR);
            this.grpQR.Controls.Add(this.lblCodigoQR);
            this.grpQR.Controls.Add(this.btnGuardarQR);
            this.grpQR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQR.Location = new System.Drawing.Point(799, 37);
            this.grpQR.Name = "grpQR";
            this.grpQR.Size = new System.Drawing.Size(317, 468);
            this.grpQR.TabIndex = 1;
            this.grpQR.TabStop = false;
            this.grpQR.Text = "Código QR de Acceso";
            // 
            // picQR
            // 
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(51, 35);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(215, 217);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // lblCodigoQR
            // 
            this.lblCodigoQR.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCodigoQR.ForeColor = System.Drawing.Color.Gray;
            this.lblCodigoQR.Location = new System.Drawing.Point(13, 264);
            this.lblCodigoQR.Name = "lblCodigoQR";
            this.lblCodigoQR.Size = new System.Drawing.Size(291, 52);
            this.lblCodigoQR.TabIndex = 1;
            this.lblCodigoQR.Text = "El código QR aparecerá\ndespués de registrar la visita.";
            this.lblCodigoQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardarQR
            // 
            this.btnGuardarQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnGuardarQR.Enabled = false;
            this.btnGuardarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardarQR.ForeColor = System.Drawing.Color.White;
            this.btnGuardarQR.Location = new System.Drawing.Point(64, 329);
            this.btnGuardarQR.Name = "btnGuardarQR";
            this.btnGuardarQR.Size = new System.Drawing.Size(180, 33);
            this.btnGuardarQR.TabIndex = 2;
            this.btnGuardarQR.Text = "💾  Guardar QR como imagen";
            this.btnGuardarQR.UseVisualStyleBackColor = false;
            this.btnGuardarQR.Click += new System.EventHandler(this.btnGuardarQR_Click);
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.pnlFiltros);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.grpValidarQR);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(9);
            this.tabHistorial.Size = new System.Drawing.Size(1199, 615);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "  Historial de Visitas  ";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.lblFiltroProp);
            this.pnlFiltros.Controls.Add(this.cmbFiltroProp);
            this.pnlFiltros.Controls.Add(this.chkUsarFecha);
            this.pnlFiltros.Controls.Add(this.lblFiltroFecha);
            this.pnlFiltros.Controls.Add(this.dtpFiltroFecha);
            this.pnlFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlFiltros.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.pnlFiltros.Location = new System.Drawing.Point(9, 9);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(820, 61);
            this.pnlFiltros.TabIndex = 0;
            // 
            // lblFiltroProp
            // 
            this.lblFiltroProp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroProp.Location = new System.Drawing.Point(7, 7);
            this.lblFiltroProp.Name = "lblFiltroProp";
            this.lblFiltroProp.Size = new System.Drawing.Size(69, 17);
            this.lblFiltroProp.TabIndex = 0;
            this.lblFiltroProp.Text = "Propiedad:";
            // 
            // cmbFiltroProp
            // 
            this.cmbFiltroProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroProp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbFiltroProp.Location = new System.Drawing.Point(7, 26);
            this.cmbFiltroProp.Name = "cmbFiltroProp";
            this.cmbFiltroProp.Size = new System.Drawing.Size(172, 21);
            this.cmbFiltroProp.TabIndex = 1;
            // 
            // chkUsarFecha
            // 
            this.chkUsarFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkUsarFecha.Location = new System.Drawing.Point(190, 7);
            this.chkUsarFecha.Name = "chkUsarFecha";
            this.chkUsarFecha.Size = new System.Drawing.Size(77, 17);
            this.chkUsarFecha.TabIndex = 2;
            this.chkUsarFecha.Text = "Filtrar fecha";
            this.chkUsarFecha.CheckedChanged += new System.EventHandler(this.chkUsarFecha_CheckedChanged);
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroFecha.Location = new System.Drawing.Point(190, 7);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(43, 17);
            this.lblFiltroFecha.TabIndex = 3;
            this.lblFiltroFecha.Text = "Fecha:";
            this.lblFiltroFecha.Visible = false;
            // 
            // dtpFiltroFecha
            // 
            this.dtpFiltroFecha.Enabled = false;
            this.dtpFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(190, 26);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(146, 23);
            this.dtpFiltroFecha.TabIndex = 4;
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroEstado.Location = new System.Drawing.Point(350, 7);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(47, 17);
            this.lblFiltroEstado.TabIndex = 5;
            this.lblFiltroEstado.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Dentro",
            "Fuera"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(350, 26);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(112, 21);
            this.cmbFiltroEstado.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(480, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 28);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "🔍  Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(587, 22);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(94, 28);
            this.btnLimpiarFiltros.TabIndex = 8;
            this.btnLimpiarFiltros.Text = "✖  Limpiar";
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorial.Location = new System.Drawing.Point(9, 78);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(819, 312);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellClick);
            // 
            // grpValidarQR
            // 
            this.grpValidarQR.Controls.Add(this.lblValidarQR);
            this.grpValidarQR.Controls.Add(this.txtCodigoQR);
            this.grpValidarQR.Controls.Add(this.btnValidarQR);
            this.grpValidarQR.Controls.Add(this.lblResultadoQR);
            this.grpValidarQR.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpValidarQR.Location = new System.Drawing.Point(9, 400);
            this.grpValidarQR.Name = "grpValidarQR";
            this.grpValidarQR.Size = new System.Drawing.Size(819, 87);
            this.grpValidarQR.TabIndex = 2;
            this.grpValidarQR.TabStop = false;
            this.grpValidarQR.Text = "Validar Código QR";
            // 
            // lblValidarQR
            // 
            this.lblValidarQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValidarQR.Location = new System.Drawing.Point(13, 26);
            this.lblValidarQR.Name = "lblValidarQR";
            this.lblValidarQR.Size = new System.Drawing.Size(103, 20);
            this.lblValidarQR.TabIndex = 0;
            this.lblValidarQR.Text = "Código escaneado:";
            // 
            // txtCodigoQR
            // 
            this.txtCodigoQR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoQR.Location = new System.Drawing.Point(120, 23);
            this.txtCodigoQR.Name = "txtCodigoQR";
            this.txtCodigoQR.Size = new System.Drawing.Size(258, 23);
            this.txtCodigoQR.TabIndex = 1;
            // 
            // btnValidarQR
            // 
            this.btnValidarQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnValidarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidarQR.ForeColor = System.Drawing.Color.White;
            this.btnValidarQR.Location = new System.Drawing.Point(390, 21);
            this.btnValidarQR.Name = "btnValidarQR";
            this.btnValidarQR.Size = new System.Drawing.Size(111, 28);
            this.btnValidarQR.TabIndex = 2;
            this.btnValidarQR.Text = "✔  Validar QR";
            this.btnValidarQR.UseVisualStyleBackColor = false;
            this.btnValidarQR.Click += new System.EventHandler(this.btnValidarQR_Click);
            // 
            // lblResultadoQR
            // 
            this.lblResultadoQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultadoQR.Location = new System.Drawing.Point(514, 17);
            this.lblResultadoQR.Name = "lblResultadoQR";
            this.lblResultadoQR.Size = new System.Drawing.Size(291, 52);
            this.lblResultadoQR.TabIndex = 3;
            // 
            // FrmControlAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 645);
            this.Controls.Add(this.tabControl);
            this.Name = "FrmControlAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Acceso y Visitas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmControlAcceso_Load);
            this.tabControl.ResumeLayout(false);
            this.tabRegistro.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpQR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.tabHistorial.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.grpValidarQR.ResumeLayout(false);
            this.grpValidarQR.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Tab control
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRegistro;
        private System.Windows.Forms.TabPage tabHistorial;

        // Tab registro
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.Label lblVisitante;
        private System.Windows.Forms.TextBox txtNombreVisitante;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.GroupBox grpQR;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Button btnGuardarQR;

        // Tab historial
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltroProp;
        private System.Windows.Forms.ComboBox cmbFiltroProp;
        private System.Windows.Forms.CheckBox chkUsarFecha;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvHistorial;

        // Validacion QR
        private System.Windows.Forms.GroupBox grpValidarQR;
        private System.Windows.Forms.Label lblValidarQR;
        private System.Windows.Forms.TextBox txtCodigoQR;
        private System.Windows.Forms.Button btnValidarQR;
        private System.Windows.Forms.Label lblResultadoQR;
    }
}
