namespace UI.Forms
{
    partial class FrmPropiedad
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.grpIdentificacion = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.grpOcupacion = new System.Windows.Forms.GroupBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.nudArea = new System.Windows.Forms.NumericUpDown();
            this.lblAreaSufijo = new System.Windows.Forms.Label();
            this.lblResidentes = new System.Windows.Forms.Label();
            this.nudResidentes = new System.Windows.Forms.NumericUpDown();
            this.grpPropietario = new System.Windows.Forms.GroupBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.cmbPropietario = new System.Windows.Forms.ComboBox();
            this.lblEstadoLabel = new System.Windows.Forms.Label();
            this.lblEstadoValor = new System.Windows.Forms.Label();
            this.grpFinanciero = new System.Windows.Forms.GroupBox();
            this.lblTarifaM2 = new System.Windows.Forms.Label();
            this.txtTarifaM2 = new System.Windows.Forms.TextBox();
            this.lblCargoFijo = new System.Windows.Forms.Label();
            this.txtCargoFijo = new System.Windows.Forms.TextBox();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblCuotaColones = new System.Windows.Forms.Label();
            this.txtCuotaColones = new System.Windows.Forms.TextBox();
            this.lblCuotaDolares = new System.Windows.Forms.Label();
            this.txtCuotaDolares = new System.Windows.Forms.TextBox();
            this.btnConvertirDolar = new System.Windows.Forms.Button();
            this.lblFondoReserva = new System.Windows.Forms.Label();
            this.txtFondoReserva = new System.Windows.Forms.TextBox();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCargarTodos = new System.Windows.Forms.Button();
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.grpIdentificacion.SuspendLayout();
            this.grpOcupacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).BeginInit();
            this.grpPropietario.SuspendLayout();
            this.grpFinanciero.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 85);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(34, 56);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(370, 15);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Registro, búsqueda y administración de propiedades del condominio";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(333, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "🏢  Gestión de Propiedades";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlAcciones.Controls.Add(this.btnRegistrar);
            this.pnlAcciones.Controls.Add(this.btnActualizar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnReporte);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 689);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1200, 60);
            this.pnlAcciones.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(15, 10);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(160, 40);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "✚  Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(190, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 40);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "✎  Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(365, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "🗑  Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(540, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 40);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "↺  Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Location = new System.Drawing.Point(1015, 10);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(170, 40);
            this.btnReporte.TabIndex = 4;
            this.btnReporte.Text = "📊  Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlIzquierda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlIzquierda.Controls.Add(this.grpIdentificacion);
            this.pnlIzquierda.Controls.Add(this.grpOcupacion);
            this.pnlIzquierda.Controls.Add(this.grpPropietario);
            this.pnlIzquierda.Controls.Add(this.grpFinanciero);
            this.pnlIzquierda.Location = new System.Drawing.Point(0, 85);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(530, 604);
            this.pnlIzquierda.TabIndex = 0;
            // 
            // grpIdentificacion
            // 
            this.grpIdentificacion.Controls.Add(this.lblCodigo);
            this.grpIdentificacion.Controls.Add(this.txtCodigo);
            this.grpIdentificacion.Controls.Add(this.lblTipo);
            this.grpIdentificacion.Controls.Add(this.cmbTipo);
            this.grpIdentificacion.Controls.Add(this.lblDireccion);
            this.grpIdentificacion.Controls.Add(this.txtDireccion);
            this.grpIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.grpIdentificacion.Location = new System.Drawing.Point(12, 10);
            this.grpIdentificacion.Name = "grpIdentificacion";
            this.grpIdentificacion.Size = new System.Drawing.Size(506, 130);
            this.grpIdentificacion.TabIndex = 0;
            this.grpIdentificacion.TabStop = false;
            this.grpIdentificacion.Text = "  Identificación de la Propiedad";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblCodigo.Location = new System.Drawing.Point(14, 30);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(49, 15);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigo.Location = new System.Drawing.Point(175, 27);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(310, 23);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblTipo.Location = new System.Drawing.Point(14, 65);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(107, 15);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo de Propiedad:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.Location = new System.Drawing.Point(175, 62);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(310, 23);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblDireccion.Location = new System.Drawing.Point(14, 100);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(96, 15);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección Exacta:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(175, 97);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(310, 23);
            this.txtDireccion.TabIndex = 5;
            // 
            // grpOcupacion
            // 
            this.grpOcupacion.Controls.Add(this.lblArea);
            this.grpOcupacion.Controls.Add(this.nudArea);
            this.grpOcupacion.Controls.Add(this.lblAreaSufijo);
            this.grpOcupacion.Controls.Add(this.lblResidentes);
            this.grpOcupacion.Controls.Add(this.nudResidentes);
            this.grpOcupacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpOcupacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.grpOcupacion.Location = new System.Drawing.Point(12, 150);
            this.grpOcupacion.Name = "grpOcupacion";
            this.grpOcupacion.Size = new System.Drawing.Size(506, 80);
            this.grpOcupacion.TabIndex = 1;
            this.grpOcupacion.TabStop = false;
            this.grpOcupacion.Text = "  Dimensiones y Ocupación";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblArea.Location = new System.Drawing.Point(14, 28);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(34, 15);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Área:";
            // 
            // nudArea
            // 
            this.nudArea.DecimalPlaces = 2;
            this.nudArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudArea.Location = new System.Drawing.Point(175, 25);
            this.nudArea.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudArea.Name = "nudArea";
            this.nudArea.Size = new System.Drawing.Size(130, 23);
            this.nudArea.TabIndex = 1;
            this.nudArea.ValueChanged += new System.EventHandler(this.nudArea_ValueChanged);
            // 
            // lblAreaSufijo
            // 
            this.lblAreaSufijo.AutoSize = true;
            this.lblAreaSufijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAreaSufijo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.lblAreaSufijo.Location = new System.Drawing.Point(310, 28);
            this.lblAreaSufijo.Name = "lblAreaSufijo";
            this.lblAreaSufijo.Size = new System.Drawing.Size(22, 15);
            this.lblAreaSufijo.TabIndex = 2;
            this.lblAreaSufijo.Text = "m²";
            // 
            // lblResidentes
            // 
            this.lblResidentes.AutoSize = true;
            this.lblResidentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResidentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblResidentes.Location = new System.Drawing.Point(14, 55);
            this.lblResidentes.Name = "lblResidentes";
            this.lblResidentes.Size = new System.Drawing.Size(133, 15);
            this.lblResidentes.TabIndex = 3;
            this.lblResidentes.Text = "Cantidad de Residentes:";
            // 
            // nudResidentes
            // 
            this.nudResidentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudResidentes.Location = new System.Drawing.Point(175, 52);
            this.nudResidentes.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudResidentes.Name = "nudResidentes";
            this.nudResidentes.Size = new System.Drawing.Size(130, 23);
            this.nudResidentes.TabIndex = 4;
            // 
            // grpPropietario
            // 
            this.grpPropietario.Controls.Add(this.lblPropietario);
            this.grpPropietario.Controls.Add(this.cmbPropietario);
            this.grpPropietario.Controls.Add(this.lblEstadoLabel);
            this.grpPropietario.Controls.Add(this.lblEstadoValor);
            this.grpPropietario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.grpPropietario.Location = new System.Drawing.Point(12, 240);
            this.grpPropietario.Name = "grpPropietario";
            this.grpPropietario.Size = new System.Drawing.Size(506, 82);
            this.grpPropietario.TabIndex = 2;
            this.grpPropietario.TabStop = false;
            this.grpPropietario.Text = "  Propietario y Estado";
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblPropietario.Location = new System.Drawing.Point(14, 28);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(68, 15);
            this.lblPropietario.TabIndex = 0;
            this.lblPropietario.Text = "Propietario:";
            // 
            // cmbPropietario
            // 
            this.cmbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropietario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropietario.Location = new System.Drawing.Point(175, 25);
            this.cmbPropietario.Name = "cmbPropietario";
            this.cmbPropietario.Size = new System.Drawing.Size(310, 23);
            this.cmbPropietario.TabIndex = 1;
            // 
            // lblEstadoLabel
            // 
            this.lblEstadoLabel.AutoSize = true;
            this.lblEstadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblEstadoLabel.Location = new System.Drawing.Point(14, 57);
            this.lblEstadoLabel.Name = "lblEstadoLabel";
            this.lblEstadoLabel.Size = new System.Drawing.Size(91, 15);
            this.lblEstadoLabel.TabIndex = 2;
            this.lblEstadoLabel.Text = "Estado de Pago:";
            // 
            // lblEstadoValor
            // 
            this.lblEstadoValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.lblEstadoValor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstadoValor.ForeColor = System.Drawing.Color.White;
            this.lblEstadoValor.Location = new System.Drawing.Point(175, 52);
            this.lblEstadoValor.Name = "lblEstadoValor";
            this.lblEstadoValor.Size = new System.Drawing.Size(120, 24);
            this.lblEstadoValor.TabIndex = 3;
            this.lblEstadoValor.Text = "Sin datos";
            this.lblEstadoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFinanciero
            // 
            this.grpFinanciero.Controls.Add(this.lblTarifaM2);
            this.grpFinanciero.Controls.Add(this.txtTarifaM2);
            this.grpFinanciero.Controls.Add(this.lblCargoFijo);
            this.grpFinanciero.Controls.Add(this.txtCargoFijo);
            this.grpFinanciero.Controls.Add(this.pnlSeparador);
            this.grpFinanciero.Controls.Add(this.lblCuotaColones);
            this.grpFinanciero.Controls.Add(this.txtCuotaColones);
            this.grpFinanciero.Controls.Add(this.lblCuotaDolares);
            this.grpFinanciero.Controls.Add(this.txtCuotaDolares);
            this.grpFinanciero.Controls.Add(this.btnConvertirDolar);
            this.grpFinanciero.Controls.Add(this.lblFondoReserva);
            this.grpFinanciero.Controls.Add(this.txtFondoReserva);
            this.grpFinanciero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFinanciero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.grpFinanciero.Location = new System.Drawing.Point(12, 332);
            this.grpFinanciero.Name = "grpFinanciero";
            this.grpFinanciero.Size = new System.Drawing.Size(506, 265);
            this.grpFinanciero.TabIndex = 3;
            this.grpFinanciero.TabStop = false;
            this.grpFinanciero.Text = "  Resumen Financiero";
            // 
            // lblTarifaM2
            // 
            this.lblTarifaM2.AutoSize = true;
            this.lblTarifaM2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarifaM2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblTarifaM2.Location = new System.Drawing.Point(14, 28);
            this.lblTarifaM2.Name = "lblTarifaM2";
            this.lblTarifaM2.Size = new System.Drawing.Size(123, 15);
            this.lblTarifaM2.TabIndex = 0;
            this.lblTarifaM2.Text = "Tarifa por m² (config):";
            // 
            // txtTarifaM2
            // 
            this.txtTarifaM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtTarifaM2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarifaM2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.txtTarifaM2.Location = new System.Drawing.Point(230, 25);
            this.txtTarifaM2.Name = "txtTarifaM2";
            this.txtTarifaM2.ReadOnly = true;
            this.txtTarifaM2.Size = new System.Drawing.Size(140, 23);
            this.txtTarifaM2.TabIndex = 1;
            // 
            // lblCargoFijo
            // 
            this.lblCargoFijo.AutoSize = true;
            this.lblCargoFijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCargoFijo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblCargoFijo.Location = new System.Drawing.Point(14, 60);
            this.lblCargoFijo.Name = "lblCargoFijo";
            this.lblCargoFijo.Size = new System.Drawing.Size(109, 15);
            this.lblCargoFijo.TabIndex = 2;
            this.lblCargoFijo.Text = "Cargo Fijo (config):";
            // 
            // txtCargoFijo
            // 
            this.txtCargoFijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtCargoFijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCargoFijo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.txtCargoFijo.Location = new System.Drawing.Point(230, 57);
            this.txtCargoFijo.Name = "txtCargoFijo";
            this.txtCargoFijo.ReadOnly = true;
            this.txtCargoFijo.Size = new System.Drawing.Size(140, 23);
            this.txtCargoFijo.TabIndex = 3;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(230)))));
            this.pnlSeparador.Location = new System.Drawing.Point(14, 92);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(476, 1);
            this.pnlSeparador.TabIndex = 4;
            // 
            // lblCuotaColones
            // 
            this.lblCuotaColones.AutoSize = true;
            this.lblCuotaColones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCuotaColones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.lblCuotaColones.Location = new System.Drawing.Point(14, 103);
            this.lblCuotaColones.Name = "lblCuotaColones";
            this.lblCuotaColones.Size = new System.Drawing.Size(165, 15);
            this.lblCuotaColones.TabIndex = 5;
            this.lblCuotaColones.Text = "Cuota de Mantenimiento (₡):";
            // 
            // txtCuotaColones
            // 
            this.txtCuotaColones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.txtCuotaColones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtCuotaColones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.txtCuotaColones.Location = new System.Drawing.Point(230, 99);
            this.txtCuotaColones.Name = "txtCuotaColones";
            this.txtCuotaColones.ReadOnly = true;
            this.txtCuotaColones.Size = new System.Drawing.Size(260, 27);
            this.txtCuotaColones.TabIndex = 6;
            this.txtCuotaColones.Text = "₡ 0.00";
            // 
            // lblCuotaDolares
            // 
            this.lblCuotaDolares.AutoSize = true;
            this.lblCuotaDolares.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCuotaDolares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblCuotaDolares.Location = new System.Drawing.Point(14, 145);
            this.lblCuotaDolares.Name = "lblCuotaDolares";
            this.lblCuotaDolares.Size = new System.Drawing.Size(117, 15);
            this.lblCuotaDolares.TabIndex = 7;
            this.lblCuotaDolares.Text = "Cuota en Dólares ($):";
            // 
            // txtCuotaDolares
            // 
            this.txtCuotaDolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtCuotaDolares.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtCuotaDolares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.txtCuotaDolares.Location = new System.Drawing.Point(230, 141);
            this.txtCuotaDolares.Name = "txtCuotaDolares";
            this.txtCuotaDolares.ReadOnly = true;
            this.txtCuotaDolares.Size = new System.Drawing.Size(170, 25);
            this.txtCuotaDolares.TabIndex = 8;
            this.txtCuotaDolares.Text = "$ —";
            // 
            // btnConvertirDolar
            // 
            this.btnConvertirDolar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConvertirDolar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertirDolar.FlatAppearance.BorderSize = 0;
            this.btnConvertirDolar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertirDolar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnConvertirDolar.ForeColor = System.Drawing.Color.White;
            this.btnConvertirDolar.Location = new System.Drawing.Point(406, 141);
            this.btnConvertirDolar.Name = "btnConvertirDolar";
            this.btnConvertirDolar.Size = new System.Drawing.Size(84, 26);
            this.btnConvertirDolar.TabIndex = 9;
            this.btnConvertirDolar.Text = "⟳ Convertir";
            this.btnConvertirDolar.UseVisualStyleBackColor = false;
            this.btnConvertirDolar.Click += new System.EventHandler(this.btnConvertirDolar_Click);
            // 
            // lblFondoReserva
            // 
            this.lblFondoReserva.AutoSize = true;
            this.lblFondoReserva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFondoReserva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblFondoReserva.Location = new System.Drawing.Point(14, 185);
            this.lblFondoReserva.Name = "lblFondoReserva";
            this.lblFondoReserva.Size = new System.Drawing.Size(159, 15);
            this.lblFondoReserva.TabIndex = 10;
            this.lblFondoReserva.Text = "Aporte Fondo de Reserva (₡):";
            // 
            // txtFondoReserva
            // 
            this.txtFondoReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.txtFondoReserva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFondoReserva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.txtFondoReserva.Location = new System.Drawing.Point(230, 182);
            this.txtFondoReserva.Name = "txtFondoReserva";
            this.txtFondoReserva.ReadOnly = true;
            this.txtFondoReserva.Size = new System.Drawing.Size(260, 23);
            this.txtFondoReserva.TabIndex = 11;
            this.txtFondoReserva.Text = "₡ 0.00";
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDerecha.BackColor = System.Drawing.Color.White;
            this.pnlDerecha.Controls.Add(this.pnlBusqueda);
            this.pnlDerecha.Controls.Add(this.dgvPropiedades);
            this.pnlDerecha.Controls.Add(this.pnlInfo);
            this.pnlDerecha.Location = new System.Drawing.Point(535, 85);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(665, 604);
            this.pnlDerecha.TabIndex = 1;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlBusqueda.Controls.Add(this.lblBusqueda);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.btnCargarTodos);
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(665, 55);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.lblBusqueda.Location = new System.Drawing.Point(10, 18);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(64, 15);
            this.lblBusqueda.TabIndex = 0;
            this.lblBusqueda.Text = "🔍 Código:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(80, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(260, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(350, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCargarTodos
            // 
            this.btnCargarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnCargarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarTodos.FlatAppearance.BorderSize = 0;
            this.btnCargarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCargarTodos.ForeColor = System.Drawing.Color.White;
            this.btnCargarTodos.Location = new System.Drawing.Point(460, 12);
            this.btnCargarTodos.Name = "btnCargarTodos";
            this.btnCargarTodos.Size = new System.Drawing.Size(100, 28);
            this.btnCargarTodos.TabIndex = 3;
            this.btnCargarTodos.Text = "Ver Todos";
            this.btnCargarTodos.UseVisualStyleBackColor = false;
            this.btnCargarTodos.Click += new System.EventHandler(this.btnCargarTodos_Click);
            // 
            // dgvPropiedades
            // 
            this.dgvPropiedades.AllowUserToAddRows = false;
            this.dgvPropiedades.AllowUserToDeleteRows = false;
            this.dgvPropiedades.AllowUserToResizeRows = false;
            this.dgvPropiedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPropiedades.BackgroundColor = System.Drawing.Color.White;
            this.dgvPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPropiedades.ColumnHeadersHeight = 34;
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPropiedades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.dgvPropiedades.Location = new System.Drawing.Point(0, 55);
            this.dgvPropiedades.MultiSelect = false;
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.ReadOnly = true;
            this.dgvPropiedades.RowHeadersVisible = false;
            this.dgvPropiedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropiedades.Size = new System.Drawing.Size(665, 514);
            this.dgvPropiedades.TabIndex = 1;
            this.dgvPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPropiedades_CellClick);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Location = new System.Drawing.Point(0, 569);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(665, 35);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(332, 15);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Haga clic en una fila para cargar la propiedad en el formulario";
            // 
            // FrmPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.pnlIzquierda);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FrmPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Propiedades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPropiedad_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlIzquierda.ResumeLayout(false);
            this.grpIdentificacion.ResumeLayout(false);
            this.grpIdentificacion.PerformLayout();
            this.grpOcupacion.ResumeLayout(false);
            this.grpOcupacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).EndInit();
            this.grpPropietario.ResumeLayout(false);
            this.grpPropietario.PerformLayout();
            this.grpFinanciero.ResumeLayout(false);
            this.grpFinanciero.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Declaraciones ─────────────────────────────────────────────
        private System.Windows.Forms.Panel       pnlHeader;
        private System.Windows.Forms.Label       lblTitulo;
        private System.Windows.Forms.Label       lblSubtitulo;
        private System.Windows.Forms.Panel       pnlAcciones;
        private System.Windows.Forms.Button      btnRegistrar;
        private System.Windows.Forms.Button      btnActualizar;
        private System.Windows.Forms.Button      btnEliminar;
        private System.Windows.Forms.Button      btnLimpiar;
        private System.Windows.Forms.Button      btnReporte;
        private System.Windows.Forms.Panel       pnlIzquierda;
        private System.Windows.Forms.GroupBox    grpIdentificacion;
        private System.Windows.Forms.Label       lblCodigo;
        private System.Windows.Forms.TextBox     txtCodigo;
        private System.Windows.Forms.Label       lblTipo;
        private System.Windows.Forms.ComboBox    cmbTipo;
        private System.Windows.Forms.Label       lblDireccion;
        private System.Windows.Forms.TextBox     txtDireccion;
        private System.Windows.Forms.GroupBox    grpOcupacion;
        private System.Windows.Forms.Label       lblArea;
        private System.Windows.Forms.NumericUpDown nudArea;
        private System.Windows.Forms.Label       lblAreaSufijo;
        private System.Windows.Forms.Label       lblResidentes;
        private System.Windows.Forms.NumericUpDown nudResidentes;
        private System.Windows.Forms.GroupBox    grpPropietario;
        private System.Windows.Forms.Label       lblPropietario;
        private System.Windows.Forms.ComboBox    cmbPropietario;
        private System.Windows.Forms.Label       lblEstadoLabel;
        private System.Windows.Forms.Label       lblEstadoValor;
        private System.Windows.Forms.GroupBox    grpFinanciero;
        private System.Windows.Forms.Label       lblTarifaM2;
        private System.Windows.Forms.TextBox     txtTarifaM2;
        private System.Windows.Forms.Label       lblCargoFijo;
        private System.Windows.Forms.TextBox     txtCargoFijo;
        private System.Windows.Forms.Panel       pnlSeparador;
        private System.Windows.Forms.Label       lblCuotaColones;
        private System.Windows.Forms.TextBox     txtCuotaColones;
        private System.Windows.Forms.Label       lblCuotaDolares;
        private System.Windows.Forms.TextBox     txtCuotaDolares;
        private System.Windows.Forms.Button      btnConvertirDolar;
        private System.Windows.Forms.Label       lblFondoReserva;
        private System.Windows.Forms.TextBox     txtFondoReserva;
        private System.Windows.Forms.Panel       pnlDerecha;
        private System.Windows.Forms.Panel       pnlBusqueda;
        private System.Windows.Forms.Label       lblBusqueda;
        private System.Windows.Forms.TextBox     txtBuscar;
        private System.Windows.Forms.Button      btnBuscar;
        private System.Windows.Forms.Button      btnCargarTodos;
        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.Panel       pnlInfo;
        private System.Windows.Forms.Label       lblInfo;
    }
}
