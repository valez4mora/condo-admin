namespace UI.Forms
{
    partial class FrmCargosFacturables
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.pnlVencidos = new System.Windows.Forms.Panel();
            this.lblVencidosValor = new System.Windows.Forms.Label();
            this.lblVencidosTitulo = new System.Windows.Forms.Label();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.lblPendientesValor = new System.Windows.Forms.Label();
            this.lblPendientesTitulo = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNuevoEstado = new System.Windows.Forms.Label();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroPropiedad = new System.Windows.Forms.ComboBox();
            this.lblFiltroPropiedad = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.grpFormulario = new System.Windows.Forms.GroupBox();
            this.lblNotaIva = new System.Windows.Forms.Label();
            this.lblVistaTotalValor = new System.Windows.Forms.Label();
            this.lblVistaTotal = new System.Windows.Forms.Label();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblBaseValor = new System.Windows.Forms.Label();
            this.lblBase = new System.Windows.Forms.Label();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.lblEmision = new System.Windows.Forms.Label();
            this.txtMontoBase = new System.Windows.Forms.TextBox();
            this.lblMontoBase = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblModo = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlVencidos.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.grpFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 14, 24, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1284, 78);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(560, 15);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Registre multas, cuotas extraordinarias y reservas. Las cuotas ordinarias se gene" +
    "ran desde Generar Cuotas.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(216, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Cargos facturables";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlResumen.Controls.Add(this.pnlTotal);
            this.pnlResumen.Controls.Add(this.pnlVencidos);
            this.pnlResumen.Controls.Add(this.pnlPendientes);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Location = new System.Drawing.Point(0, 78);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1284, 82);
            this.pnlResumen.TabIndex = 1;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.Controls.Add(this.lblTotalValor);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Location = new System.Drawing.Point(414, 12);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(260, 58);
            this.pnlTotal.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTotalValor.Location = new System.Drawing.Point(12, 27);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(60, 25);
            this.lblTotalValor.TabIndex = 0;
            this.lblTotalValor.Text = "₡0,00";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalTitulo.Location = new System.Drawing.Point(14, 9);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(153, 15);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "TOTAL PENDIENTE (FILTRO)";
            // 
            // pnlVencidos
            // 
            this.pnlVencidos.BackColor = System.Drawing.Color.White;
            this.pnlVencidos.Controls.Add(this.lblVencidosValor);
            this.pnlVencidos.Controls.Add(this.lblVencidosTitulo);
            this.pnlVencidos.Location = new System.Drawing.Point(222, 12);
            this.pnlVencidos.Name = "pnlVencidos";
            this.pnlVencidos.Size = new System.Drawing.Size(178, 58);
            this.pnlVencidos.TabIndex = 1;
            // 
            // lblVencidosValor
            // 
            this.lblVencidosValor.AutoSize = true;
            this.lblVencidosValor.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblVencidosValor.ForeColor = System.Drawing.Color.Firebrick;
            this.lblVencidosValor.Location = new System.Drawing.Point(12, 27);
            this.lblVencidosValor.Name = "lblVencidosValor";
            this.lblVencidosValor.Size = new System.Drawing.Size(23, 25);
            this.lblVencidosValor.TabIndex = 0;
            this.lblVencidosValor.Text = "0";
            // 
            // lblVencidosTitulo
            // 
            this.lblVencidosTitulo.AutoSize = true;
            this.lblVencidosTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblVencidosTitulo.Location = new System.Drawing.Point(14, 9);
            this.lblVencidosTitulo.Name = "lblVencidosTitulo";
            this.lblVencidosTitulo.Size = new System.Drawing.Size(63, 15);
            this.lblVencidosTitulo.TabIndex = 1;
            this.lblVencidosTitulo.Text = "VENCIDOS";
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.BackColor = System.Drawing.Color.White;
            this.pnlPendientes.Controls.Add(this.lblPendientesValor);
            this.pnlPendientes.Controls.Add(this.lblPendientesTitulo);
            this.pnlPendientes.Location = new System.Drawing.Point(30, 12);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(178, 58);
            this.pnlPendientes.TabIndex = 2;
            // 
            // lblPendientesValor
            // 
            this.lblPendientesValor.AutoSize = true;
            this.lblPendientesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPendientesValor.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblPendientesValor.Location = new System.Drawing.Point(12, 27);
            this.lblPendientesValor.Name = "lblPendientesValor";
            this.lblPendientesValor.Size = new System.Drawing.Size(23, 25);
            this.lblPendientesValor.TabIndex = 0;
            this.lblPendientesValor.Text = "0";
            // 
            // lblPendientesTitulo
            // 
            this.lblPendientesTitulo.AutoSize = true;
            this.lblPendientesTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblPendientesTitulo.Location = new System.Drawing.Point(14, 9);
            this.lblPendientesTitulo.Name = "lblPendientesTitulo";
            this.lblPendientesTitulo.Size = new System.Drawing.Size(74, 15);
            this.lblPendientesTitulo.TabIndex = 1;
            this.lblPendientesTitulo.Text = "PENDIENTES";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.pnlListado);
            this.pnlContenido.Controls.Add(this.pnlFormulario);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 160);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(18);
            this.pnlContenido.Size = new System.Drawing.Size(1284, 601);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlListado
            // 
            this.pnlListado.Controls.Add(this.dgvCargos);
            this.pnlListado.Controls.Add(this.lblSeleccion);
            this.pnlListado.Controls.Add(this.pnlAcciones);
            this.pnlListado.Controls.Add(this.lblResultados);
            this.pnlListado.Controls.Add(this.pnlFiltros);
            this.pnlListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListado.Location = new System.Drawing.Point(428, 18);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Padding = new System.Windows.Forms.Padding(14);
            this.pnlListado.Size = new System.Drawing.Size(838, 565);
            this.pnlListado.TabIndex = 0;
            // 
            // dgvCargos
            // 
            this.dgvCargos.AllowUserToAddRows = false;
            this.dgvCargos.AllowUserToDeleteRows = false;
            this.dgvCargos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCargos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCargos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCargos.Location = new System.Drawing.Point(14, 124);
            this.dgvCargos.MultiSelect = false;
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.ReadOnly = true;
            this.dgvCargos.RowHeadersVisible = false;
            this.dgvCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargos.Size = new System.Drawing.Size(810, 353);
            this.dgvCargos.TabIndex = 0;
            this.dgvCargos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargos_CellClick);
            this.dgvCargos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCargos_CellFormatting);
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSeleccion.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeleccion.Location = new System.Drawing.Point(14, 477);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(810, 28);
            this.lblSeleccion.TabIndex = 1;
            this.lblSeleccion.Text = "Seleccione una fila para habilitar sus acciones.";
            this.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnEditar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.lblNuevoEstado);
            this.pnlAcciones.Controls.Add(this.cmbNuevoEstado);
            this.pnlAcciones.Controls.Add(this.btnCambiarEstado);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(14, 505);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(810, 46);
            this.pnlAcciones.TabIndex = 2;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(13, 8);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(95, 32);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(123, 8);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 32);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNuevoEstado
            // 
            this.lblNuevoEstado.Location = new System.Drawing.Point(488, 14);
            this.lblNuevoEstado.Name = "lblNuevoEstado";
            this.lblNuevoEstado.Size = new System.Drawing.Size(44, 20);
            this.lblNuevoEstado.TabIndex = 3;
            this.lblNuevoEstado.Text = "Estado:";
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoEstado.Enabled = false;
            this.cmbNuevoEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Vencido",
            "Pagado",
            "Anulado"});
            this.cmbNuevoEstado.Location = new System.Drawing.Point(549, 11);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(110, 23);
            this.cmbNuevoEstado.TabIndex = 4;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.btnCambiarEstado.Enabled = false;
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEstado.Location = new System.Drawing.Point(676, 8);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(126, 32);
            this.btnCambiarEstado.TabIndex = 5;
            this.btnCambiarEstado.Text = "Cambiar estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = false;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // lblResultados
            // 
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultados.Location = new System.Drawing.Point(14, 90);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Padding = new System.Windows.Forms.Padding(2, 8, 0, 0);
            this.lblResultados.Size = new System.Drawing.Size(810, 34);
            this.lblResultados.TabIndex = 3;
            this.lblResultados.Text = "0 cargo(s) encontrado(s)";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFiltros.Controls.Add(this.btnActualizarLista);
            this.pnlFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.pnlFiltros.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlFiltros.Controls.Add(this.cmbFiltroPropiedad);
            this.pnlFiltros.Controls.Add(this.lblFiltroPropiedad);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(14, 14);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(810, 76);
            this.pnlFiltros.TabIndex = 4;
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnActualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLista.ForeColor = System.Drawing.Color.White;
            this.btnActualizarLista.Location = new System.Drawing.Point(688, 29);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(114, 27);
            this.btnActualizarLista.TabIndex = 0;
            this.btnActualizarLista.Text = "Actualizar lista";
            this.btnActualizarLista.UseVisualStyleBackColor = false;
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(568, 29);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(110, 27);
            this.btnLimpiarFiltros.TabIndex = 1;
            this.btnLimpiarFiltros.Text = "Limpiar filtros";
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(428, 31);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(125, 23);
            this.cmbFiltroEstado.TabIndex = 2;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.FiltroCambiado);
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Location = new System.Drawing.Point(428, 10);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(42, 15);
            this.lblFiltroEstado.TabIndex = 3;
            this.lblFiltroEstado.Text = "Estado";
            // 
            // cmbFiltroPropiedad
            // 
            this.cmbFiltroPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroPropiedad.Location = new System.Drawing.Point(244, 31);
            this.cmbFiltroPropiedad.Name = "cmbFiltroPropiedad";
            this.cmbFiltroPropiedad.Size = new System.Drawing.Size(170, 23);
            this.cmbFiltroPropiedad.TabIndex = 4;
            this.cmbFiltroPropiedad.SelectedIndexChanged += new System.EventHandler(this.FiltroCambiado);
            // 
            // lblFiltroPropiedad
            // 
            this.lblFiltroPropiedad.AutoSize = true;
            this.lblFiltroPropiedad.Location = new System.Drawing.Point(244, 10);
            this.lblFiltroPropiedad.Name = "lblFiltroPropiedad";
            this.lblFiltroPropiedad.Size = new System.Drawing.Size(61, 15);
            this.lblFiltroPropiedad.TabIndex = 5;
            this.lblFiltroPropiedad.Text = "Propiedad";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(10, 31);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 23);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.FiltroCambiado);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(10, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(42, 15);
            this.lblBuscar.TabIndex = 7;
            this.lblBuscar.Text = "Buscar";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.grpFormulario);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormulario.Location = new System.Drawing.Point(18, 18);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlFormulario.Size = new System.Drawing.Size(410, 565);
            this.pnlFormulario.TabIndex = 1;
            // 
            // grpFormulario
            // 
            this.grpFormulario.BackColor = System.Drawing.Color.White;
            this.grpFormulario.Controls.Add(this.lblNotaIva);
            this.grpFormulario.Controls.Add(this.lblVistaTotalValor);
            this.grpFormulario.Controls.Add(this.lblVistaTotal);
            this.grpFormulario.Controls.Add(this.lblIvaValor);
            this.grpFormulario.Controls.Add(this.lblIva);
            this.grpFormulario.Controls.Add(this.lblBaseValor);
            this.grpFormulario.Controls.Add(this.lblBase);
            this.grpFormulario.Controls.Add(this.pnlSeparador);
            this.grpFormulario.Controls.Add(this.btnCancelar);
            this.grpFormulario.Controls.Add(this.btnGuardar);
            this.grpFormulario.Controls.Add(this.dtpVencimiento);
            this.grpFormulario.Controls.Add(this.lblVencimiento);
            this.grpFormulario.Controls.Add(this.dtpEmision);
            this.grpFormulario.Controls.Add(this.lblEmision);
            this.grpFormulario.Controls.Add(this.txtMontoBase);
            this.grpFormulario.Controls.Add(this.lblMontoBase);
            this.grpFormulario.Controls.Add(this.cmbTipo);
            this.grpFormulario.Controls.Add(this.lblTipo);
            this.grpFormulario.Controls.Add(this.cmbPropiedad);
            this.grpFormulario.Controls.Add(this.lblPropiedad);
            this.grpFormulario.Controls.Add(this.txtDescripcion);
            this.grpFormulario.Controls.Add(this.lblDescripcion);
            this.grpFormulario.Controls.Add(this.lblModo);
            this.grpFormulario.Controls.Add(this.btnNuevo);
            this.grpFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormulario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpFormulario.Location = new System.Drawing.Point(0, 0);
            this.grpFormulario.Name = "grpFormulario";
            this.grpFormulario.Size = new System.Drawing.Size(396, 565);
            this.grpFormulario.TabIndex = 0;
            this.grpFormulario.TabStop = false;
            this.grpFormulario.Text = "Registro del cargo";
            // 
            // lblNotaIva
            // 
            this.lblNotaIva.ForeColor = System.Drawing.Color.DimGray;
            this.lblNotaIva.Location = new System.Drawing.Point(18, 483);
            this.lblNotaIva.Name = "lblNotaIva";
            this.lblNotaIva.Size = new System.Drawing.Size(360, 18);
            this.lblNotaIva.TabIndex = 0;
            this.lblNotaIva.Text = "Este tipo de cargo no aplica IVA.";
            // 
            // lblVistaTotalValor
            // 
            this.lblVistaTotalValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVistaTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblVistaTotalValor.Location = new System.Drawing.Point(170, 455);
            this.lblVistaTotalValor.Name = "lblVistaTotalValor";
            this.lblVistaTotalValor.Size = new System.Drawing.Size(208, 25);
            this.lblVistaTotalValor.TabIndex = 1;
            this.lblVistaTotalValor.Text = "₡0,00";
            this.lblVistaTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVistaTotal
            // 
            this.lblVistaTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVistaTotal.Location = new System.Drawing.Point(18, 457);
            this.lblVistaTotal.Name = "lblVistaTotal";
            this.lblVistaTotal.Size = new System.Drawing.Size(60, 22);
            this.lblVistaTotal.TabIndex = 2;
            this.lblVistaTotal.Text = "TOTAL";
            // 
            // lblIvaValor
            // 
            this.lblIvaValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIvaValor.Location = new System.Drawing.Point(225, 431);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(153, 18);
            this.lblIvaValor.TabIndex = 3;
            this.lblIvaValor.Text = "₡0,00";
            this.lblIvaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(18, 431);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(24, 15);
            this.lblIva.TabIndex = 4;
            this.lblIva.Text = "IVA";
            // 
            // lblBaseValor
            // 
            this.lblBaseValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBaseValor.Location = new System.Drawing.Point(225, 405);
            this.lblBaseValor.Name = "lblBaseValor";
            this.lblBaseValor.Size = new System.Drawing.Size(153, 18);
            this.lblBaseValor.TabIndex = 5;
            this.lblBaseValor.Text = "₡0,00";
            this.lblBaseValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(18, 405);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(70, 15);
            this.lblBase.TabIndex = 6;
            this.lblBase.Text = "Monto base";
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSeparador.Location = new System.Drawing.Point(18, 389);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(360, 1);
            this.pnlSeparador.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(207, 516);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(171, 34);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar edición";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(18, 516);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(170, 34);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar cargo";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(207, 347);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(171, 23);
            this.dtpVencimiento.TabIndex = 10;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Location = new System.Drawing.Point(207, 326);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(131, 15);
            this.lblVencimiento.TabIndex = 11;
            this.lblVencimiento.Text = "Fecha de vencimiento *";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(18, 347);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(170, 23);
            this.dtpEmision.TabIndex = 12;
            // 
            // lblEmision
            // 
            this.lblEmision.AutoSize = true;
            this.lblEmision.Location = new System.Drawing.Point(18, 326);
            this.lblEmision.Name = "lblEmision";
            this.lblEmision.Size = new System.Drawing.Size(107, 15);
            this.lblEmision.TabIndex = 13;
            this.lblEmision.Text = "Fecha de emisión *";
            // 
            // txtMontoBase
            // 
            this.txtMontoBase.Location = new System.Drawing.Point(18, 291);
            this.txtMontoBase.Name = "txtMontoBase";
            this.txtMontoBase.Size = new System.Drawing.Size(170, 23);
            this.txtMontoBase.TabIndex = 14;
            this.txtMontoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoBase.TextChanged += new System.EventHandler(this.CampoCalculoCambiado);
            // 
            // lblMontoBase
            // 
            this.lblMontoBase.AutoSize = true;
            this.lblMontoBase.Location = new System.Drawing.Point(18, 270);
            this.lblMontoBase.Name = "lblMontoBase";
            this.lblMontoBase.Size = new System.Drawing.Size(95, 15);
            this.lblMontoBase.TabIndex = 15;
            this.lblMontoBase.Text = "Monto base (₡) *";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(18, 146);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(360, 23);
            this.cmbTipo.TabIndex = 16;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.CampoCalculoCambiado);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(18, 125);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(88, 15);
            this.lblTipo.TabIndex = 17;
            this.lblTipo.Text = "Tipo de cargo *";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Location = new System.Drawing.Point(18, 91);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(360, 23);
            this.cmbPropiedad.TabIndex = 18;
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Location = new System.Drawing.Point(18, 70);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(69, 15);
            this.lblPropiedad.TabIndex = 19;
            this.lblPropiedad.Text = "Propiedad *";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(18, 201);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(360, 58);
            this.txtDescripcion.TabIndex = 20;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(18, 180);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(77, 15);
            this.lblDescripcion.TabIndex = 21;
            this.lblDescripcion.Text = "Descripción *";
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblModo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblModo.ForeColor = System.Drawing.Color.White;
            this.lblModo.Location = new System.Drawing.Point(18, 27);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(135, 25);
            this.lblModo.TabIndex = 22;
            this.lblModo.Text = "NUEVO CARGO";
            this.lblModo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(286, 25);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(92, 30);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "Nuevo / limpiar";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // FrmCargosFacturables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "FrmCargosFacturables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Cargos Facturables";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCargosFacturables_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlVencidos.ResumeLayout(false);
            this.pnlVencidos.PerformLayout();
            this.pnlPendientes.ResumeLayout(false);
            this.pnlPendientes.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.grpFormulario.ResumeLayout(false);
            this.grpFormulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader, pnlResumen, pnlTotal, pnlVencidos, pnlPendientes, pnlContenido, pnlListado, pnlAcciones, pnlFiltros, pnlFormulario, pnlSeparador;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblTotalValor, lblTotalTitulo, lblVencidosValor, lblVencidosTitulo, lblPendientesValor, lblPendientesTitulo, lblSeleccion, lblResultados, lblFiltroEstado, lblFiltroPropiedad, lblBuscar, lblNotaIva, lblVistaTotalValor, lblVistaTotal, lblIvaValor, lblIva, lblBaseValor, lblBase, lblVencimiento, lblEmision, lblMontoBase, lblTipo, lblPropiedad, lblDescripcion, lblModo;
        private System.Windows.Forms.DataGridView dgvCargos;
        private System.Windows.Forms.Button btnCambiarEstado, btnEliminar, btnEditar, btnActualizarLista, btnLimpiarFiltros, btnCancelar, btnGuardar, btnNuevo;
        private System.Windows.Forms.ComboBox cmbNuevoEstado, cmbFiltroEstado, cmbFiltroPropiedad, cmbTipo, cmbPropiedad;
        private System.Windows.Forms.Label lblNuevoEstado;
        private System.Windows.Forms.TextBox txtBuscar, txtMontoBase, txtDescripcion;
        private System.Windows.Forms.GroupBox grpFormulario;
        private System.Windows.Forms.DateTimePicker dtpVencimiento, dtpEmision;
    }
}
