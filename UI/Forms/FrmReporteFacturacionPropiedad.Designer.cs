namespace UI.Forms
{
    partial class FrmReporteFacturacionPropiedad
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblPropiedad;
        private System.Windows.Forms.ComboBox cmbPropiedad;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Panel pnlCargos;
        private System.Windows.Forms.Label lblCargosTitulo;
        private System.Windows.Forms.Label lblCargosValor;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Label lblBaseTitulo;
        private System.Windows.Forms.Label lblBaseValor;
        private System.Windows.Forms.Panel pnlIva;
        private System.Windows.Forms.Label lblIvaTitulo;
        private System.Windows.Forms.Label lblIvaValor;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblPropiedadSeleccionada;
        private System.Windows.Forms.DataGridView dgvFacturacion;
        private System.Windows.Forms.Panel pnlSinDatos;
        private System.Windows.Forms.Label lblSinDatosTitulo;
        private System.Windows.Forms.Label lblSinDatosDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatosTitulo = new System.Windows.Forms.Label();
            this.lblSinDatosDetalle = new System.Windows.Forms.Label();
            this.dgvFacturacion = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblPropiedadSeleccionada = new System.Windows.Forms.Label();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCargos = new System.Windows.Forms.Panel();
            this.lblCargosValor = new System.Windows.Forms.Label();
            this.lblCargosTitulo = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.lblBaseValor = new System.Windows.Forms.Label();
            this.lblBaseTitulo = new System.Windows.Forms.Label();
            this.pnlIva = new System.Windows.Forms.Panel();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblIvaTitulo = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblPropiedad = new System.Windows.Forms.Label();
            this.cmbPropiedad = new System.Windows.Forms.ComboBox();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlCargos.SuspendLayout();
            this.pnlBase.SuspendLayout();
            this.pnlIva.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblActualizado);
            this.pnlEncabezado.Controls.Add(this.btnCerrar);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1309, 106);
            this.pnlEncabezado.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(380, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Facturación por propiedad";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(31, 63);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(486, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Detalle de cargos emitidos, impuestos, totales, estados y fechas por propiedad";
            // 
            // lblActualizado
            // 
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActualizado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblActualizado.Location = new System.Drawing.Point(944, 67);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(305, 20);
            this.lblActualizado.TabIndex = 2;
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1254, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "×";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlContenido.Controls.Add(this.pnlTabla);
            this.pnlContenido.Controls.Add(this.tlpResumen);
            this.pnlContenido.Controls.Add(this.grpFiltros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 106);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContenido.Size = new System.Drawing.Size(1309, 624);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Controls.Add(this.pnlSinDatos);
            this.pnlTabla.Controls.Add(this.dgvFacturacion);
            this.pnlTabla.Controls.Add(this.lblResultado);
            this.pnlTabla.Controls.Add(this.lblPropiedadSeleccionada);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 235);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(14);
            this.pnlTabla.Size = new System.Drawing.Size(1261, 365);
            this.pnlTabla.TabIndex = 0;
            // 
            // pnlSinDatos
            // 
            this.pnlSinDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatosTitulo);
            this.pnlSinDatos.Controls.Add(this.lblSinDatosDetalle);
            this.pnlSinDatos.Location = new System.Drawing.Point(916, 277);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(420, 105);
            this.pnlSinDatos.TabIndex = 0;
            this.pnlSinDatos.Visible = false;
            // 
            // lblSinDatosTitulo
            // 
            this.lblSinDatosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSinDatosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblSinDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblSinDatosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosTitulo.Name = "lblSinDatosTitulo";
            this.lblSinDatosTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblSinDatosTitulo.TabIndex = 0;
            this.lblSinDatosTitulo.Text = "No se encontraron cargos";
            this.lblSinDatosTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSinDatosDetalle
            // 
            this.lblSinDatosDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatosDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSinDatosDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSinDatosDetalle.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatosDetalle.Name = "lblSinDatosDetalle";
            this.lblSinDatosDetalle.Size = new System.Drawing.Size(420, 105);
            this.lblSinDatosDetalle.TabIndex = 1;
            this.lblSinDatosDetalle.Text = "La propiedad no tiene cargos para los filtros seleccionados.";
            this.lblSinDatosDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvFacturacion
            // 
            this.dgvFacturacion.AllowUserToAddRows = false;
            this.dgvFacturacion.AllowUserToDeleteRows = false;
            this.dgvFacturacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvFacturacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFacturacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFacturacion.ColumnHeadersHeight = 44;
            this.dgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFacturacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturacion.EnableHeadersVisualStyles = false;
            this.dgvFacturacion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(228)))));
            this.dgvFacturacion.Location = new System.Drawing.Point(14, 74);
            this.dgvFacturacion.MultiSelect = false;
            this.dgvFacturacion.Name = "dgvFacturacion";
            this.dgvFacturacion.ReadOnly = true;
            this.dgvFacturacion.RowHeadersVisible = false;
            this.dgvFacturacion.RowTemplate.Height = 35;
            this.dgvFacturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturacion.Size = new System.Drawing.Size(1233, 277);
            this.dgvFacturacion.TabIndex = 1;
            this.dgvFacturacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturacion_CellFormatting);
            // 
            // lblResultado
            // 
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblResultado.Location = new System.Drawing.Point(14, 42);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Padding = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblResultado.Size = new System.Drawing.Size(1233, 32);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "Seleccione una propiedad para generar el reporte.";
            // 
            // lblPropiedadSeleccionada
            // 
            this.lblPropiedadSeleccionada.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPropiedadSeleccionada.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPropiedadSeleccionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblPropiedadSeleccionada.Location = new System.Drawing.Point(14, 14);
            this.lblPropiedadSeleccionada.Name = "lblPropiedadSeleccionada";
            this.lblPropiedadSeleccionada.Padding = new System.Windows.Forms.Padding(2, 0, 0, 4);
            this.lblPropiedadSeleccionada.Size = new System.Drawing.Size(1233, 28);
            this.lblPropiedadSeleccionada.TabIndex = 3;
            this.lblPropiedadSeleccionada.Text = "Propiedad: --";
            // 
            // tlpResumen
            // 
            this.tlpResumen.ColumnCount = 4;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.Controls.Add(this.pnlCargos, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlBase, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlIva, 2, 0);
            this.tlpResumen.Controls.Add(this.pnlTotal, 3, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpResumen.Location = new System.Drawing.Point(24, 127);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1261, 108);
            this.tlpResumen.TabIndex = 1;
            // 
            // pnlCargos
            // 
            this.pnlCargos.Controls.Add(this.lblCargosValor);
            this.pnlCargos.Controls.Add(this.lblCargosTitulo);
            this.pnlCargos.Location = new System.Drawing.Point(3, 15);
            this.pnlCargos.Name = "pnlCargos";
            this.pnlCargos.Size = new System.Drawing.Size(200, 78);
            this.pnlCargos.TabIndex = 0;
            // 
            // lblCargosValor
            // 
            this.lblCargosValor.Location = new System.Drawing.Point(0, 0);
            this.lblCargosValor.Name = "lblCargosValor";
            this.lblCargosValor.Size = new System.Drawing.Size(100, 23);
            this.lblCargosValor.TabIndex = 0;
            // 
            // lblCargosTitulo
            // 
            this.lblCargosTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCargosTitulo.Name = "lblCargosTitulo";
            this.lblCargosTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblCargosTitulo.TabIndex = 1;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.lblBaseValor);
            this.pnlBase.Controls.Add(this.lblBaseTitulo);
            this.pnlBase.Location = new System.Drawing.Point(318, 15);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(200, 78);
            this.pnlBase.TabIndex = 1;
            // 
            // lblBaseValor
            // 
            this.lblBaseValor.Location = new System.Drawing.Point(0, 0);
            this.lblBaseValor.Name = "lblBaseValor";
            this.lblBaseValor.Size = new System.Drawing.Size(100, 23);
            this.lblBaseValor.TabIndex = 0;
            // 
            // lblBaseTitulo
            // 
            this.lblBaseTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblBaseTitulo.Name = "lblBaseTitulo";
            this.lblBaseTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblBaseTitulo.TabIndex = 1;
            // 
            // pnlIva
            // 
            this.pnlIva.Controls.Add(this.lblIvaValor);
            this.pnlIva.Controls.Add(this.lblIvaTitulo);
            this.pnlIva.Location = new System.Drawing.Point(633, 15);
            this.pnlIva.Name = "pnlIva";
            this.pnlIva.Size = new System.Drawing.Size(200, 78);
            this.pnlIva.TabIndex = 2;
            // 
            // lblIvaValor
            // 
            this.lblIvaValor.Location = new System.Drawing.Point(0, 0);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(100, 23);
            this.lblIvaValor.TabIndex = 0;
            // 
            // lblIvaTitulo
            // 
            this.lblIvaTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblIvaTitulo.Name = "lblIvaTitulo";
            this.lblIvaTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblIvaTitulo.TabIndex = 1;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblTotalValor);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Location = new System.Drawing.Point(948, 15);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(200, 78);
            this.pnlTotal.TabIndex = 3;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Location = new System.Drawing.Point(0, 0);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(100, 23);
            this.lblTotalValor.TabIndex = 0;
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTitulo.TabIndex = 1;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.lblBuscar);
            this.grpFiltros.Controls.Add(this.txtBuscar);
            this.grpFiltros.Controls.Add(this.lblPropiedad);
            this.grpFiltros.Controls.Add(this.cmbPropiedad);
            this.grpFiltros.Controls.Add(this.chkUsarFechas);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.lblEstado);
            this.grpFiltros.Controls.Add(this.cmbEstado);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnActualizar);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.grpFiltros.Location = new System.Drawing.Point(24, 24);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.grpFiltros.Size = new System.Drawing.Size(1261, 103);
            this.grpFiltros.TabIndex = 2;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Consulta y filtros";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(610, 29);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(75, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar cargo";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(613, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(195, 24);
            this.txtBuscar.TabIndex = 5;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblPropiedad
            // 
            this.lblPropiedad.AutoSize = true;
            this.lblPropiedad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropiedad.Location = new System.Drawing.Point(20, 29);
            this.lblPropiedad.Name = "lblPropiedad";
            this.lblPropiedad.Size = new System.Drawing.Size(61, 15);
            this.lblPropiedad.TabIndex = 6;
            this.lblPropiedad.Text = "Propiedad";
            // 
            // cmbPropiedad
            // 
            this.cmbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropiedad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPropiedad.Location = new System.Drawing.Point(23, 52);
            this.cmbPropiedad.Name = "cmbPropiedad";
            this.cmbPropiedad.Size = new System.Drawing.Size(135, 25);
            this.cmbPropiedad.TabIndex = 0;
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUsarFechas.Location = new System.Drawing.Point(178, 27);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(114, 19);
            this.chkUsarFechas.TabIndex = 1;
            this.chkUsarFechas.Text = "Filtrar por fechas";
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(181, 52);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(112, 23);
            this.dtpDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(302, 52);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.Location = new System.Drawing.Point(435, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(42, 15);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.Location = new System.Drawing.Point(438, 52);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(150, 25);
            this.cmbEstado.TabIndex = 4;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(826, 45);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(105, 35);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(940, 45);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 35);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(1128, 45);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(108, 35);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmReporteFacturacionPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1309, 730);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1080, 660);
            this.Name = "FrmReporteFacturacionPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de facturación por propiedad";
            this.Load += new System.EventHandler(this.FrmReporteFacturacionPropiedad_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlCargos.ResumeLayout(false);
            this.pnlBase.ResumeLayout(false);
            this.pnlIva.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
