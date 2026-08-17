namespace UI.Forms
{
    partial class FrmMorosidad
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblActualizado = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.nudTasa = new System.Windows.Forms.NumericUpDown();
            this.lblTasa = new System.Windows.Forms.Label();
            this.chkSuspendidas = new System.Windows.Forms.CheckBox();
            this.cmbRiesgo = new System.Windows.Forms.ComboBox();
            this.lblRiesgo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnPenalizaciones = new System.Windows.Forms.Button();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPropiedades = new System.Windows.Forms.Panel();
            this.lblPropiedadesValor = new System.Windows.Forms.Label();
            this.lblPropiedadesTitulo = new System.Windows.Forms.Label();
            this.pnlDeuda = new System.Windows.Forms.Panel();
            this.lblDeudaValor = new System.Windows.Forms.Label();
            this.lblDeudaTitulo = new System.Windows.Forms.Label();
            this.pnlInteres = new System.Windows.Forms.Panel();
            this.lblInteresValor = new System.Windows.Forms.Label();
            this.lblInteresTitulo = new System.Windows.Forms.Label();
            this.pnlCriticas = new System.Windows.Forms.Panel();
            this.lblCriticasValor = new System.Windows.Forms.Label();
            this.lblCriticasTitulo = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlSinDatos = new System.Windows.Forms.Panel();
            this.lblSinDatos = new System.Windows.Forms.Label();
            this.dgvMorosidad = new System.Windows.Forms.DataGridView();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasa)).BeginInit();
            this.tlpResumen.SuspendLayout();
            this.pnlPropiedades.SuspendLayout();
            this.pnlDeuda.SuspendLayout();
            this.pnlInteres.SuspendLayout();
            this.pnlCriticas.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosidad)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.pnlCabecera.Controls.Add(this.lblActualizado);
            this.pnlCabecera.Controls.Add(this.lblSubtitulo);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1204, 96);
            this.pnlCabecera.TabIndex = 6;
            // 
            // lblActualizado
            // 
            this.lblActualizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualizado.ForeColor = System.Drawing.Color.MistyRose;
            this.lblActualizado.Location = new System.Drawing.Point(1914, 40);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(260, 23);
            this.lblActualizado.TabIndex = 0;
            this.lblActualizado.Text = "Actualizado: --";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.MistyRose;
            this.lblSubtitulo.Location = new System.Drawing.Point(29, 60);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(461, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Saldos vencidos, intereses, riesgo y restricciones calculados automáticamente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 37);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Control de morosidad";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.nudTasa);
            this.grpFiltros.Controls.Add(this.lblTasa);
            this.grpFiltros.Controls.Add(this.chkSuspendidas);
            this.grpFiltros.Controls.Add(this.cmbRiesgo);
            this.grpFiltros.Controls.Add(this.lblRiesgo);
            this.grpFiltros.Controls.Add(this.txtBuscar);
            this.grpFiltros.Controls.Add(this.lblBuscar);
            this.grpFiltros.Location = new System.Drawing.Point(22, 108);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1160, 94);
            this.grpFiltros.TabIndex = 5;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Consulta y cálculo";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(1026, 43);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 34);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // nudTasa
            // 
            this.nudTasa.DecimalPlaces = 2;
            this.nudTasa.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudTasa.Location = new System.Drawing.Point(695, 49);
            this.nudTasa.Name = "nudTasa";
            this.nudTasa.Size = new System.Drawing.Size(110, 24);
            this.nudTasa.TabIndex = 1;
            // 
            // lblTasa
            // 
            this.lblTasa.Location = new System.Drawing.Point(692, 26);
            this.lblTasa.Name = "lblTasa";
            this.lblTasa.Size = new System.Drawing.Size(150, 18);
            this.lblTasa.TabIndex = 2;
            this.lblTasa.Text = "Tasa mensual (%)";
            // 
            // chkSuspendidas
            // 
            this.chkSuspendidas.Location = new System.Drawing.Point(497, 51);
            this.chkSuspendidas.Name = "chkSuspendidas";
            this.chkSuspendidas.Size = new System.Drawing.Size(175, 22);
            this.chkSuspendidas.TabIndex = 3;
            this.chkSuspendidas.Text = "Reservas suspendidas";
            this.chkSuspendidas.CheckedChanged += new System.EventHandler(this.filtro_Cambio);
            // 
            // cmbRiesgo
            // 
            this.cmbRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRiesgo.Location = new System.Drawing.Point(322, 49);
            this.cmbRiesgo.Name = "cmbRiesgo";
            this.cmbRiesgo.Size = new System.Drawing.Size(150, 25);
            this.cmbRiesgo.TabIndex = 4;
            this.cmbRiesgo.SelectedIndexChanged += new System.EventHandler(this.filtro_Cambio);
            // 
            // lblRiesgo
            // 
            this.lblRiesgo.Location = new System.Drawing.Point(319, 26);
            this.lblRiesgo.Name = "lblRiesgo";
            this.lblRiesgo.Size = new System.Drawing.Size(100, 18);
            this.lblRiesgo.TabIndex = 5;
            this.lblRiesgo.Text = "Clasificación";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(19, 49);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(280, 24);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.filtro_Cambio);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Location = new System.Drawing.Point(16, 26);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(170, 18);
            this.lblBuscar.TabIndex = 7;
            this.lblBuscar.Text = "Propiedad o propietario";
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.btnRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcular.ForeColor = System.Drawing.Color.White;
            this.btnRecalcular.Location = new System.Drawing.Point(1000, 214);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(182, 37);
            this.btnRecalcular.TabIndex = 1;
            this.btnRecalcular.Text = "Recalcular morosidad";
            this.btnRecalcular.UseVisualStyleBackColor = false;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // btnPenalizaciones
            // 
            this.btnPenalizaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPenalizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(104)))), ((int)(((byte)(31)))));
            this.btnPenalizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPenalizaciones.ForeColor = System.Drawing.Color.White;
            this.btnPenalizaciones.Location = new System.Drawing.Point(790, 214);
            this.btnPenalizaciones.Name = "btnPenalizaciones";
            this.btnPenalizaciones.Size = new System.Drawing.Size(198, 37);
            this.btnPenalizaciones.TabIndex = 0;
            this.btnPenalizaciones.Text = "Aplicar penalizaciones";
            this.btnPenalizaciones.UseVisualStyleBackColor = false;
            this.btnPenalizaciones.Click += new System.EventHandler(this.btnPenalizaciones_Click);
            // 
            // tlpResumen
            // 
            this.tlpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpResumen.ColumnCount = 4;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpResumen.Controls.Add(this.pnlPropiedades, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlDeuda, 1, 0);
            this.tlpResumen.Controls.Add(this.pnlInteres, 2, 0);
            this.tlpResumen.Controls.Add(this.pnlCriticas, 3, 0);
            this.tlpResumen.Location = new System.Drawing.Point(22, 263);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpResumen.Size = new System.Drawing.Size(1160, 86);
            this.tlpResumen.TabIndex = 4;
            // 
            // pnlPropiedades
            // 
            this.pnlPropiedades.BackColor = System.Drawing.Color.White;
            this.pnlPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPropiedades.Controls.Add(this.lblPropiedadesValor);
            this.pnlPropiedades.Controls.Add(this.lblPropiedadesTitulo);
            this.pnlPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropiedades.Location = new System.Drawing.Point(5, 5);
            this.pnlPropiedades.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPropiedades.Name = "pnlPropiedades";
            this.pnlPropiedades.Size = new System.Drawing.Size(280, 76);
            this.pnlPropiedades.TabIndex = 0;
            // 
            // lblPropiedadesValor
            // 
            this.lblPropiedadesValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblPropiedadesValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.lblPropiedadesValor.Location = new System.Drawing.Point(14, 36);
            this.lblPropiedadesValor.Name = "lblPropiedadesValor";
            this.lblPropiedadesValor.Size = new System.Drawing.Size(250, 38);
            this.lblPropiedadesValor.TabIndex = 0;
            this.lblPropiedadesValor.Text = "0";
            // 
            // lblPropiedadesTitulo
            // 
            this.lblPropiedadesTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblPropiedadesTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblPropiedadesTitulo.Name = "lblPropiedadesTitulo";
            this.lblPropiedadesTitulo.Size = new System.Drawing.Size(240, 20);
            this.lblPropiedadesTitulo.TabIndex = 1;
            this.lblPropiedadesTitulo.Text = "Propiedades morosas";
            // 
            // pnlDeuda
            // 
            this.pnlDeuda.BackColor = System.Drawing.Color.White;
            this.pnlDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeuda.Controls.Add(this.lblDeudaValor);
            this.pnlDeuda.Controls.Add(this.lblDeudaTitulo);
            this.pnlDeuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeuda.Location = new System.Drawing.Point(295, 5);
            this.pnlDeuda.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDeuda.Name = "pnlDeuda";
            this.pnlDeuda.Size = new System.Drawing.Size(280, 76);
            this.pnlDeuda.TabIndex = 1;
            // 
            // lblDeudaValor
            // 
            this.lblDeudaValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblDeudaValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.lblDeudaValor.Location = new System.Drawing.Point(14, 36);
            this.lblDeudaValor.Name = "lblDeudaValor";
            this.lblDeudaValor.Size = new System.Drawing.Size(250, 38);
            this.lblDeudaValor.TabIndex = 0;
            this.lblDeudaValor.Text = "0";
            // 
            // lblDeudaTitulo
            // 
            this.lblDeudaTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblDeudaTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblDeudaTitulo.Name = "lblDeudaTitulo";
            this.lblDeudaTitulo.Size = new System.Drawing.Size(240, 20);
            this.lblDeudaTitulo.TabIndex = 1;
            this.lblDeudaTitulo.Text = "Saldo vencido";
            // 
            // pnlInteres
            // 
            this.pnlInteres.BackColor = System.Drawing.Color.White;
            this.pnlInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInteres.Controls.Add(this.lblInteresValor);
            this.pnlInteres.Controls.Add(this.lblInteresTitulo);
            this.pnlInteres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInteres.Location = new System.Drawing.Point(585, 5);
            this.pnlInteres.Margin = new System.Windows.Forms.Padding(5);
            this.pnlInteres.Name = "pnlInteres";
            this.pnlInteres.Size = new System.Drawing.Size(280, 76);
            this.pnlInteres.TabIndex = 2;
            // 
            // lblInteresValor
            // 
            this.lblInteresValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblInteresValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.lblInteresValor.Location = new System.Drawing.Point(14, 36);
            this.lblInteresValor.Name = "lblInteresValor";
            this.lblInteresValor.Size = new System.Drawing.Size(250, 38);
            this.lblInteresValor.TabIndex = 0;
            this.lblInteresValor.Text = "0";
            // 
            // lblInteresTitulo
            // 
            this.lblInteresTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblInteresTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblInteresTitulo.Name = "lblInteresTitulo";
            this.lblInteresTitulo.Size = new System.Drawing.Size(240, 20);
            this.lblInteresTitulo.TabIndex = 1;
            this.lblInteresTitulo.Text = "Interés calculado";
            // 
            // pnlCriticas
            // 
            this.pnlCriticas.BackColor = System.Drawing.Color.White;
            this.pnlCriticas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCriticas.Controls.Add(this.lblCriticasValor);
            this.pnlCriticas.Controls.Add(this.lblCriticasTitulo);
            this.pnlCriticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCriticas.Location = new System.Drawing.Point(875, 5);
            this.pnlCriticas.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCriticas.Name = "pnlCriticas";
            this.pnlCriticas.Size = new System.Drawing.Size(280, 76);
            this.pnlCriticas.TabIndex = 3;
            // 
            // lblCriticasValor
            // 
            this.lblCriticasValor.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblCriticasValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.lblCriticasValor.Location = new System.Drawing.Point(14, 36);
            this.lblCriticasValor.Name = "lblCriticasValor";
            this.lblCriticasValor.Size = new System.Drawing.Size(250, 38);
            this.lblCriticasValor.TabIndex = 0;
            this.lblCriticasValor.Text = "0";
            // 
            // lblCriticasTitulo
            // 
            this.lblCriticasTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblCriticasTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblCriticasTitulo.Name = "lblCriticasTitulo";
            this.lblCriticasTitulo.Size = new System.Drawing.Size(240, 20);
            this.lblCriticasTitulo.TabIndex = 1;
            this.lblCriticasTitulo.Text = "Riesgo alto o crítico";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenido.Controls.Add(this.pnlSinDatos);
            this.pnlContenido.Controls.Add(this.dgvMorosidad);
            this.pnlContenido.Location = new System.Drawing.Point(22, 363);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1160, 310);
            this.pnlContenido.TabIndex = 3;
            // 
            // pnlSinDatos
            // 
            this.pnlSinDatos.BackColor = System.Drawing.Color.White;
            this.pnlSinDatos.Controls.Add(this.lblSinDatos);
            this.pnlSinDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSinDatos.Location = new System.Drawing.Point(0, 0);
            this.pnlSinDatos.Name = "pnlSinDatos";
            this.pnlSinDatos.Size = new System.Drawing.Size(1158, 308);
            this.pnlSinDatos.TabIndex = 0;
            // 
            // lblSinDatos
            // 
            this.lblSinDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblSinDatos.ForeColor = System.Drawing.Color.DimGray;
            this.lblSinDatos.Location = new System.Drawing.Point(0, 0);
            this.lblSinDatos.Name = "lblSinDatos";
            this.lblSinDatos.Size = new System.Drawing.Size(1158, 308);
            this.lblSinDatos.TabIndex = 0;
            this.lblSinDatos.Text = "No existen propiedades con cargos vencidos y saldo pendiente.";
            this.lblSinDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMorosidad
            // 
            this.dgvMorosidad.AllowUserToAddRows = false;
            this.dgvMorosidad.AllowUserToDeleteRows = false;
            this.dgvMorosidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMorosidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvMorosidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMorosidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMorosidad.ColumnHeadersHeight = 42;
            this.dgvMorosidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMorosidad.EnableHeadersVisualStyles = false;
            this.dgvMorosidad.Location = new System.Drawing.Point(0, 0);
            this.dgvMorosidad.Name = "dgvMorosidad";
            this.dgvMorosidad.ReadOnly = true;
            this.dgvMorosidad.RowHeadersVisible = false;
            this.dgvMorosidad.RowTemplate.Height = 32;
            this.dgvMorosidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMorosidad.Size = new System.Drawing.Size(1158, 308);
            this.dgvMorosidad.TabIndex = 1;
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblResultado);
            this.pnlPie.Controls.Add(this.btnCerrar);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 684);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1204, 57);
            this.pnlPie.TabIndex = 2;
            // 
            // lblResultado
            // 
            this.lblResultado.Location = new System.Drawing.Point(22, 20);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(400, 20);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "0 propiedades morosas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(2066, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 35);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmMorosidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1204, 741);
            this.Controls.Add(this.btnPenalizaciones);
            this.Controls.Add(this.btnRecalcular);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.tlpResumen);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.pnlCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1120, 700);
            this.Name = "FrmMorosidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control de morosidad";
            this.Load += new System.EventHandler(this.FrmMorosidad_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasa)).EndInit();
            this.tlpResumen.ResumeLayout(false);
            this.pnlPropiedades.ResumeLayout(false);
            this.pnlDeuda.ResumeLayout(false);
            this.pnlInteres.ResumeLayout(false);
            this.pnlCriticas.ResumeLayout(false);
            this.pnlContenido.ResumeLayout(false);
            this.pnlSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorosidad)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCabecera, pnlPropiedades, pnlDeuda, pnlInteres, pnlCriticas, pnlContenido, pnlSinDatos, pnlPie;
        private System.Windows.Forms.Label lblActualizado, lblSubtitulo, lblTitulo, lblBuscar, lblRiesgo, lblTasa;
        private System.Windows.Forms.Label lblPropiedadesValor, lblPropiedadesTitulo, lblDeudaValor, lblDeudaTitulo, lblInteresValor, lblInteresTitulo, lblCriticasValor, lblCriticasTitulo, lblSinDatos, lblResultado;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbRiesgo;
        private System.Windows.Forms.CheckBox chkSuspendidas;
        private System.Windows.Forms.NumericUpDown nudTasa;
        private System.Windows.Forms.Button btnLimpiar, btnRecalcular, btnPenalizaciones, btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.DataGridView dgvMorosidad;
    }
}
