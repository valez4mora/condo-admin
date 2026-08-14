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
            this.components = new System.ComponentModel.Container();

            // ── Controles ──────────────────────────────────────────────
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblSubtitulo       = new System.Windows.Forms.Label();
            this.pnlAcciones        = new System.Windows.Forms.Panel();
            this.btnRegistrar       = new System.Windows.Forms.Button();
            this.btnActualizar      = new System.Windows.Forms.Button();
            this.btnEliminar        = new System.Windows.Forms.Button();
            this.btnLimpiar         = new System.Windows.Forms.Button();
            this.btnReporte         = new System.Windows.Forms.Button();
            this.pnlIzquierda       = new System.Windows.Forms.Panel();
            this.grpIdentificacion  = new System.Windows.Forms.GroupBox();
            this.lblCodigo          = new System.Windows.Forms.Label();
            this.txtCodigo          = new System.Windows.Forms.TextBox();
            this.lblTipo            = new System.Windows.Forms.Label();
            this.cmbTipo            = new System.Windows.Forms.ComboBox();
            this.lblDireccion       = new System.Windows.Forms.Label();
            this.txtDireccion       = new System.Windows.Forms.TextBox();
            this.grpOcupacion       = new System.Windows.Forms.GroupBox();
            this.lblArea            = new System.Windows.Forms.Label();
            this.nudArea            = new System.Windows.Forms.NumericUpDown();
            this.lblAreaSufijo      = new System.Windows.Forms.Label();
            this.lblResidentes      = new System.Windows.Forms.Label();
            this.nudResidentes      = new System.Windows.Forms.NumericUpDown();
            this.grpPropietario     = new System.Windows.Forms.GroupBox();
            this.lblPropietario     = new System.Windows.Forms.Label();
            this.cmbPropietario     = new System.Windows.Forms.ComboBox();
            this.lblEstadoLabel     = new System.Windows.Forms.Label();
            this.lblEstadoValor     = new System.Windows.Forms.Label();
            this.grpFinanciero      = new System.Windows.Forms.GroupBox();
            this.lblTarifaM2        = new System.Windows.Forms.Label();
            this.txtTarifaM2        = new System.Windows.Forms.TextBox();
            this.lblCargoFijo       = new System.Windows.Forms.Label();
            this.txtCargoFijo       = new System.Windows.Forms.TextBox();
            this.pnlSeparador       = new System.Windows.Forms.Panel();
            this.lblCuotaColones    = new System.Windows.Forms.Label();
            this.txtCuotaColones    = new System.Windows.Forms.TextBox();
            this.lblCuotaDolares    = new System.Windows.Forms.Label();
            this.txtCuotaDolares    = new System.Windows.Forms.TextBox();
            this.btnConvertirDolar  = new System.Windows.Forms.Button();
            this.lblFondoReserva    = new System.Windows.Forms.Label();
            this.txtFondoReserva    = new System.Windows.Forms.TextBox();
            this.pnlDerecha         = new System.Windows.Forms.Panel();
            this.pnlBusqueda        = new System.Windows.Forms.Panel();
            this.lblBusqueda        = new System.Windows.Forms.Label();
            this.txtBuscar          = new System.Windows.Forms.TextBox();
            this.btnBuscar          = new System.Windows.Forms.Button();
            this.btnCargarTodos     = new System.Windows.Forms.Button();
            this.dgvPropiedades     = new System.Windows.Forms.DataGridView();
            this.pnlInfo            = new System.Windows.Forms.Panel();
            this.lblInfo            = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.grpIdentificacion.SuspendLayout();
            this.grpOcupacion.SuspendLayout();
            this.grpPropietario.SuspendLayout();
            this.grpFinanciero.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════
            // HEADER
            // ═══════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 85);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "🏢  Gestión de Propiedades";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblSubtitulo.Location = new System.Drawing.Point(34, 56);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Registro, búsqueda y administración de propiedades del condominio";

            // ═══════════════════════════════════════════════
            // PANEL IZQUIERDA (formulario)
            // ═══════════════════════════════════════════════
            this.pnlIzquierda.Location = new System.Drawing.Point(0, 85);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(530, 615);
            this.pnlIzquierda.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlIzquierda.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlIzquierda.Controls.Add(this.grpIdentificacion);
            this.pnlIzquierda.Controls.Add(this.grpOcupacion);
            this.pnlIzquierda.Controls.Add(this.grpPropietario);
            this.pnlIzquierda.Controls.Add(this.grpFinanciero);

            // ── GroupBox Identificación ────────────────────
            this.grpIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIdentificacion.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.grpIdentificacion.Location = new System.Drawing.Point(12, 10);
            this.grpIdentificacion.Name = "grpIdentificacion";
            this.grpIdentificacion.Size = new System.Drawing.Size(506, 130);
            this.grpIdentificacion.Text = "  Identificación de la Propiedad";
            this.grpIdentificacion.Controls.Add(this.lblCodigo);
            this.grpIdentificacion.Controls.Add(this.txtCodigo);
            this.grpIdentificacion.Controls.Add(this.lblTipo);
            this.grpIdentificacion.Controls.Add(this.cmbTipo);
            this.grpIdentificacion.Controls.Add(this.lblDireccion);
            this.grpIdentificacion.Controls.Add(this.txtDireccion);

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblCodigo.Location = new System.Drawing.Point(14, 30);
            this.lblCodigo.Text = "Código:";

            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigo.Location = new System.Drawing.Point(175, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(310, 23);
            this.txtCodigo.MaxLength = 20;

            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblTipo.Location = new System.Drawing.Point(14, 65);
            this.lblTipo.Text = "Tipo de Propiedad:";

            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(175, 62);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(310, 23);

            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblDireccion.Location = new System.Drawing.Point(14, 100);
            this.lblDireccion.Text = "Dirección Exacta:";

            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(175, 97);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(310, 23);

            // ── GroupBox Ocupación ─────────────────────────
            this.grpOcupacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpOcupacion.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.grpOcupacion.Location = new System.Drawing.Point(12, 150);
            this.grpOcupacion.Name = "grpOcupacion";
            this.grpOcupacion.Size = new System.Drawing.Size(506, 80);
            this.grpOcupacion.Text = "  Dimensiones y Ocupación";
            this.grpOcupacion.Controls.Add(this.lblArea);
            this.grpOcupacion.Controls.Add(this.nudArea);
            this.grpOcupacion.Controls.Add(this.lblAreaSufijo);
            this.grpOcupacion.Controls.Add(this.lblResidentes);
            this.grpOcupacion.Controls.Add(this.nudResidentes);

            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblArea.Location = new System.Drawing.Point(14, 28);
            this.lblArea.Text = "Área:";

            this.nudArea.DecimalPlaces = 2;
            this.nudArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudArea.Location = new System.Drawing.Point(175, 25);
            this.nudArea.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            this.nudArea.Name = "nudArea";
            this.nudArea.Size = new System.Drawing.Size(130, 23);
            this.nudArea.ValueChanged += new System.EventHandler(this.nudArea_ValueChanged);

            this.lblAreaSufijo.AutoSize = true;
            this.lblAreaSufijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAreaSufijo.ForeColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblAreaSufijo.Location = new System.Drawing.Point(310, 28);
            this.lblAreaSufijo.Text = "m²";

            this.lblResidentes.AutoSize = true;
            this.lblResidentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResidentes.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblResidentes.Location = new System.Drawing.Point(14, 55);
            this.lblResidentes.Text = "Cantidad de Residentes:";

            this.nudResidentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudResidentes.Location = new System.Drawing.Point(175, 52);
            this.nudResidentes.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.nudResidentes.Name = "nudResidentes";
            this.nudResidentes.Size = new System.Drawing.Size(130, 23);

            // ── GroupBox Propietario ───────────────────────
            this.grpPropietario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPropietario.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.grpPropietario.Location = new System.Drawing.Point(12, 240);
            this.grpPropietario.Name = "grpPropietario";
            this.grpPropietario.Size = new System.Drawing.Size(506, 82);
            this.grpPropietario.Text = "  Propietario y Estado";
            this.grpPropietario.Controls.Add(this.lblPropietario);
            this.grpPropietario.Controls.Add(this.cmbPropietario);
            this.grpPropietario.Controls.Add(this.lblEstadoLabel);
            this.grpPropietario.Controls.Add(this.lblEstadoValor);

            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblPropietario.Location = new System.Drawing.Point(14, 28);
            this.lblPropietario.Text = "Propietario:";

            this.cmbPropietario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropietario.Location = new System.Drawing.Point(175, 25);
            this.cmbPropietario.Name = "cmbPropietario";
            this.cmbPropietario.Size = new System.Drawing.Size(310, 23);

            this.lblEstadoLabel.AutoSize = true;
            this.lblEstadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoLabel.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblEstadoLabel.Location = new System.Drawing.Point(14, 57);
            this.lblEstadoLabel.Text = "Estado de Pago:";

            this.lblEstadoValor.AutoSize = false;
            this.lblEstadoValor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstadoValor.ForeColor = System.Drawing.Color.White;
            this.lblEstadoValor.BackColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblEstadoValor.Location = new System.Drawing.Point(175, 52);
            this.lblEstadoValor.Name = "lblEstadoValor";
            this.lblEstadoValor.Size = new System.Drawing.Size(120, 24);
            this.lblEstadoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstadoValor.Text = "Sin datos";

            // ── GroupBox Financiero ────────────────────────
            this.grpFinanciero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFinanciero.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.grpFinanciero.Location = new System.Drawing.Point(12, 332);
            this.grpFinanciero.Name = "grpFinanciero";
            this.grpFinanciero.Size = new System.Drawing.Size(506, 265);
            this.grpFinanciero.Text = "  Resumen Financiero";
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

            this.lblTarifaM2.AutoSize = true;
            this.lblTarifaM2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarifaM2.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblTarifaM2.Location = new System.Drawing.Point(14, 28);
            this.lblTarifaM2.Text = "Tarifa por m² (config):";

            this.txtTarifaM2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarifaM2.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.txtTarifaM2.ForeColor = System.Drawing.Color.FromArgb(80, 100, 120);
            this.txtTarifaM2.Location = new System.Drawing.Point(230, 25);
            this.txtTarifaM2.Name = "txtTarifaM2";
            this.txtTarifaM2.ReadOnly = true;
            this.txtTarifaM2.Size = new System.Drawing.Size(140, 23);

            this.lblCargoFijo.AutoSize = true;
            this.lblCargoFijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCargoFijo.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblCargoFijo.Location = new System.Drawing.Point(14, 60);
            this.lblCargoFijo.Text = "Cargo Fijo (config):";

            this.txtCargoFijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCargoFijo.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.txtCargoFijo.ForeColor = System.Drawing.Color.FromArgb(80, 100, 120);
            this.txtCargoFijo.Location = new System.Drawing.Point(230, 57);
            this.txtCargoFijo.Name = "txtCargoFijo";
            this.txtCargoFijo.ReadOnly = true;
            this.txtCargoFijo.Size = new System.Drawing.Size(140, 23);

            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(200, 215, 230);
            this.pnlSeparador.Location = new System.Drawing.Point(14, 92);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(476, 1);

            this.lblCuotaColones.AutoSize = true;
            this.lblCuotaColones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCuotaColones.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.lblCuotaColones.Location = new System.Drawing.Point(14, 103);
            this.lblCuotaColones.Text = "Cuota de Mantenimiento (₡):";

            this.txtCuotaColones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtCuotaColones.BackColor = System.Drawing.Color.FromArgb(230, 242, 255);
            this.txtCuotaColones.ForeColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.txtCuotaColones.Location = new System.Drawing.Point(230, 99);
            this.txtCuotaColones.Name = "txtCuotaColones";
            this.txtCuotaColones.ReadOnly = true;
            this.txtCuotaColones.Size = new System.Drawing.Size(260, 28);
            this.txtCuotaColones.Text = "₡ 0.00";

            this.lblCuotaDolares.AutoSize = true;
            this.lblCuotaDolares.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCuotaDolares.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblCuotaDolares.Location = new System.Drawing.Point(14, 145);
            this.lblCuotaDolares.Text = "Cuota en Dólares ($):";

            this.txtCuotaDolares.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtCuotaDolares.BackColor = System.Drawing.Color.FromArgb(240, 248, 240);
            this.txtCuotaDolares.ForeColor = System.Drawing.Color.FromArgb(30, 120, 60);
            this.txtCuotaDolares.Location = new System.Drawing.Point(230, 141);
            this.txtCuotaDolares.Name = "txtCuotaDolares";
            this.txtCuotaDolares.ReadOnly = true;
            this.txtCuotaDolares.Size = new System.Drawing.Size(170, 26);
            this.txtCuotaDolares.Text = "$ —";

            this.btnConvertirDolar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnConvertirDolar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertirDolar.FlatAppearance.BorderSize = 0;
            this.btnConvertirDolar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnConvertirDolar.ForeColor = System.Drawing.Color.White;
            this.btnConvertirDolar.Location = new System.Drawing.Point(406, 141);
            this.btnConvertirDolar.Name = "btnConvertirDolar";
            this.btnConvertirDolar.Size = new System.Drawing.Size(84, 26);
            this.btnConvertirDolar.Text = "⟳ Convertir";
            this.btnConvertirDolar.UseVisualStyleBackColor = false;
            this.btnConvertirDolar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertirDolar.Click += new System.EventHandler(this.btnConvertirDolar_Click);

            this.lblFondoReserva.AutoSize = true;
            this.lblFondoReserva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFondoReserva.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblFondoReserva.Location = new System.Drawing.Point(14, 185);
            this.lblFondoReserva.Text = "Aporte Fondo de Reserva (₡):";

            this.txtFondoReserva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFondoReserva.BackColor = System.Drawing.Color.FromArgb(255, 250, 230);
            this.txtFondoReserva.ForeColor = System.Drawing.Color.FromArgb(130, 80, 0);
            this.txtFondoReserva.Location = new System.Drawing.Point(230, 182);
            this.txtFondoReserva.Name = "txtFondoReserva";
            this.txtFondoReserva.ReadOnly = true;
            this.txtFondoReserva.Size = new System.Drawing.Size(260, 23);
            this.txtFondoReserva.Text = "₡ 0.00";

            // ═══════════════════════════════════════════════
            // PANEL DERECHA (búsqueda + DataGridView)
            // ═══════════════════════════════════════════════
            this.pnlDerecha.Location = new System.Drawing.Point(535, 85);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(665, 615);
            this.pnlDerecha.BackColor = System.Drawing.Color.White;
            this.pnlDerecha.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.pnlDerecha.Controls.Add(this.pnlBusqueda);
            this.pnlDerecha.Controls.Add(this.dgvPropiedades);
            this.pnlDerecha.Controls.Add(this.pnlInfo);

            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(665, 55);
            this.pnlBusqueda.Controls.Add(this.lblBusqueda);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.btnCargarTodos);

            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblBusqueda.Location = new System.Drawing.Point(10, 18);
            this.lblBusqueda.Text = "🔍 Código:";

            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(80, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(260, 23);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(350, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.btnCargarTodos.BackColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.btnCargarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarTodos.FlatAppearance.BorderSize = 0;
            this.btnCargarTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCargarTodos.ForeColor = System.Drawing.Color.White;
            this.btnCargarTodos.Location = new System.Drawing.Point(460, 12);
            this.btnCargarTodos.Name = "btnCargarTodos";
            this.btnCargarTodos.Size = new System.Drawing.Size(100, 28);
            this.btnCargarTodos.Text = "Ver Todos";
            this.btnCargarTodos.UseVisualStyleBackColor = false;
            this.btnCargarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarTodos.Click += new System.EventHandler(this.btnCargarTodos_Click);

            // ── DataGridView ───────────────────────────────
            this.dgvPropiedades.AllowUserToAddRows = false;
            this.dgvPropiedades.AllowUserToDeleteRows = false;
            this.dgvPropiedades.AllowUserToResizeRows = false;
            this.dgvPropiedades.BackgroundColor = System.Drawing.Color.White;
            this.dgvPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPropiedades.ColumnHeadersHeight = 34;
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPropiedades.GridColor = System.Drawing.Color.FromArgb(220, 230, 240);
            this.dgvPropiedades.Location = new System.Drawing.Point(0, 55);
            this.dgvPropiedades.MultiSelect = false;
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.ReadOnly = true;
            this.dgvPropiedades.RowHeadersVisible = false;
            this.dgvPropiedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropiedades.Size = new System.Drawing.Size(665, 525);
            this.dgvPropiedades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPropiedades_CellClick);

            // ── Panel info (fila de totales abajo del grid)
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(26, 58, 92);
            this.pnlInfo.Location = new System.Drawing.Point(0, 580);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(665, 35);
            this.pnlInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlInfo.Controls.Add(this.lblInfo);

            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Text = "Haga clic en una fila para cargar la propiedad en el formulario";

            // ═══════════════════════════════════════════════
            // PANEL ACCIONES (botones abajo)
            // ═══════════════════════════════════════════════
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 700);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1200, 60);
            this.pnlAcciones.Controls.Add(this.btnRegistrar);
            this.pnlAcciones.Controls.Add(this.btnActualizar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnReporte);

            // Registrar
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(15, 10);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(160, 40);
            this.btnRegistrar.Text = "✚  Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // Actualizar
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(190, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 40);
            this.btnActualizar.Text = "✎  Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // Eliminar
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(365, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 40);
            this.btnEliminar.Text = "🗑  Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // Limpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(540, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 40);
            this.btnLimpiar.Text = "↺  Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Reporte
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Location = new System.Drawing.Point(1015, 10);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(170, 40);
            this.btnReporte.Text = "📊  Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);

            // ═══════════════════════════════════════════════
            // FORM
            // ═══════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(1200, 760);
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
            this.grpPropietario.ResumeLayout(false);
            this.grpPropietario.PerformLayout();
            this.grpFinanciero.ResumeLayout(false);
            this.grpFinanciero.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResidentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
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
