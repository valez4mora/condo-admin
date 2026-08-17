using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmPagos : Form
    {
        private readonly PagoBLL _pagoBLL = new PagoBLL();
        private readonly FacturaBLL _facturaBLL = new FacturaBLL();
        private readonly PropiedadBLL _propiedadBLL = new PropiedadBLL();
        private FacturaDTO _facturaSeleccionada;
        private bool _cargando;

        public FrmPagos()
        {
            InitializeComponent();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                dtpFechaPago.MinDate = new DateTime(2000, 1, 1);
                dtpFechaPago.MaxDate = DateTime.Today;
                dtpFechaPago.Value = DateTime.Today;
                CargarMetodosPago();
                CargarPropiedades();
                PrepararFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el formulario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cargando = false;
            }
        }

        private void CargarPropiedades()
        {
            List<PropiedadDTO> lista = _propiedadBLL.ObtenerTodas()
                .OrderBy(x => x.Codigo).ToList();
            cmbPropiedad.DisplayMember = "Codigo";
            cmbPropiedad.ValueMember = "IdPropiedad";
            cmbPropiedad.DataSource = lista;
            cmbPropiedad.SelectedIndex = -1;
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new object[]
            {
                "Efectivo", "Transferencia bancaria", "SINPE Móvil",
                "Tarjeta de débito", "Tarjeta de crédito"
            });
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void PrepararFormulario()
        {
            dgvFacturasPendientes.DataSource = null;
            dgvHistorialPagos.DataSource = null;
            lblResultado.Text = "Seleccione una propiedad y cargue sus facturas pendientes.";
            LimpiarPago(false);
        }

        private void cmbPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            dgvFacturasPendientes.DataSource = null;
            dgvHistorialPagos.DataSource = null;
            lblResultado.Text = cmbPropiedad.SelectedIndex < 0
                ? "Seleccione una propiedad."
                : "Presione Cargar / actualizar para consultar las facturas.";
            LimpiarPago(false);
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            CargarFacturas(true);
        }

        private void CargarFacturas(bool mostrarAviso)
        {
            PropiedadDTO propiedad = cmbPropiedad.SelectedItem as PropiedadDTO;
            if (propiedad == null)
            {
                if (mostrarAviso)
                    MessageBox.Show("Seleccione una propiedad.", "Dato requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                List<FacturaDTO> pendientes = _facturaBLL.ObtenerPorPropiedad(propiedad.IdPropiedad)
                    .Where(EstaPendiente).OrderBy(x => x.Fecha).ToList();

                _cargando = true;
                dgvFacturasPendientes.DataSource = pendientes;
                FormatearGridFacturas();
                dgvFacturasPendientes.ClearSelection();
                _cargando = false;
                LimpiarPago(false);

                lblResultado.Text = pendientes.Count == 0
                    ? "Esta propiedad no tiene facturas pendientes."
                    : pendientes.Count + (pendientes.Count == 1
                        ? " factura pendiente. Seleccione la fila que desea pagar."
                        : " facturas pendientes. Seleccione la fila que desea pagar.");
            }
            catch (Exception ex)
            {
                _cargando = false;
                MessageBox.Show("No se pudieron cargar las facturas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static bool EstaPendiente(FacturaDTO factura)
        {
            if (factura == null || string.IsNullOrWhiteSpace(factura.Estado)) return false;
            string estado = factura.Estado.Replace(" ", "").ToLowerInvariant();
            return estado == "emitida" || estado == "parcialmentepagada";
        }

        private void dgvFacturasPendientes_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvFacturasPendientes.SelectedRows.Count == 0) return;

            _facturaSeleccionada =
                dgvFacturasPendientes.SelectedRows[0].DataBoundItem as FacturaDTO;
            if (_facturaSeleccionada == null) return;

            decimal saldo = ObtenerSaldo(_facturaSeleccionada);
            lblFacturaSeleccionada.Text = "Factura N.° " + _facturaSeleccionada.IdFactura;
            lblDetalleFactura.Text = "Propiedad " + _facturaSeleccionada.CodigoPropiedad +
                "  |  Emitida: " + _facturaSeleccionada.Fecha.ToString("dd/MM/yyyy");
            lblSaldoPendiente.Text = "₡" + saldo.ToString("N2");
            txtMonto.Text = saldo.ToString("0.00");
            grpPago.Enabled = saldo > 0;
            CargarHistorial(_facturaSeleccionada.IdFactura);
        }

        private static decimal ObtenerSaldo(FacturaDTO factura)
        {
            if (factura.SaldoPendiente > 0) return factura.SaldoPendiente;
            decimal calculado = factura.TotalColones - factura.TotalPagado;
            return calculado > 0 ? calculado : 0;
        }

        private void btnUsarSaldo_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada != null)
                txtMonto.Text = ObtenerSaldo(_facturaSeleccionada).ToString("0.00");
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura.", "Dato requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal monto;
            if (!decimal.TryParse(txtMonto.Text.Trim(), out monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto mayor que cero.", "Monto inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            decimal saldo = ObtenerSaldo(_facturaSeleccionada);
            if (monto > saldo)
            {
                MessageBox.Show("El monto supera el saldo pendiente de ₡" + saldo.ToString("N2") + ".",
                    "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            if (cmbMetodoPago.SelectedItem == null) return;
            string metodo = cmbMetodoPago.SelectedItem.ToString();
            if (metodo != "Efectivo" && string.IsNullOrWhiteSpace(txtReferencia.Text))
            {
                MessageBox.Show("Ingrese la referencia o comprobante del pago.",
                    "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferencia.Focus();
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Registrar el pago de ₡" + monto.ToString("N2") +
                " para la factura N.° " + _facturaSeleccionada.IdFactura + "?",
                "Confirmar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                PagoDTO pago = new PagoDTO
                {
                    IdFactura = _facturaSeleccionada.IdFactura,
                    Monto = monto,
                    FechaPago = dtpFechaPago.Value.Date,
                    MetodoPago = metodo,
                    Referencia = txtReferencia.Text.Trim()
                };

                if (!_pagoBLL.Registrar(pago))
                    throw new InvalidOperationException("La base de datos no confirmó el registro.");

                MessageBox.Show("Pago registrado correctamente.", "Pago registrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFacturas(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el pago: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial(int idFactura)
        {
            try
            {
                List<PagoDTO> pagos = _pagoBLL.ObtenerPorFactura(idFactura)
                    .OrderByDescending(x => x.FechaPago).ThenByDescending(x => x.IdPago).ToList();
                dgvHistorialPagos.DataSource = pagos;
                FormatearGridHistorial();
                dgvHistorialPagos.ClearSelection();
                lblHistorialTitulo.Text = pagos.Count == 0
                    ? "Historial de pagos — sin movimientos"
                    : "Historial de pagos — " + pagos.Count +
                      (pagos.Count == 1 ? " movimiento" : " movimientos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPago(_facturaSeleccionada != null);
        }

        private void LimpiarPago(bool conservarFactura)
        {
            txtMonto.Clear();
            txtReferencia.Clear();
            dtpFechaPago.Value = DateTime.Today;
            if (cmbMetodoPago.Items.Count > 0) cmbMetodoPago.SelectedIndex = 0;

            if (conservarFactura)
            {
                txtMonto.Text = ObtenerSaldo(_facturaSeleccionada).ToString("0.00");
                return;
            }

            _facturaSeleccionada = null;
            lblFacturaSeleccionada.Text = "Ninguna factura seleccionada";
            lblDetalleFactura.Text = "Seleccione una fila de la lista superior.";
            lblSaldoPendiente.Text = "₡0,00";
            lblHistorialTitulo.Text = "Historial de pagos";
            dgvHistorialPagos.DataSource = null;
            grpPago.Enabled = false;
        }

        private void FormatearGridFacturas()
        {
            Ocultar(dgvFacturasPendientes, "IdPropiedad");
            Ocultar(dgvFacturasPendientes, "Detalles");
            Ocultar(dgvFacturasPendientes, "TipoCambio");
            Columna(dgvFacturasPendientes, "IdFactura", "Factura", "");
            Columna(dgvFacturasPendientes, "Fecha", "Fecha", "dd/MM/yyyy");
            Columna(dgvFacturasPendientes, "CodigoPropiedad", "Propiedad", "");
            Columna(dgvFacturasPendientes, "TotalColones", "Total (₡)", "N2");
            Columna(dgvFacturasPendientes, "TotalPagado", "Pagado (₡)", "N2");
            Columna(dgvFacturasPendientes, "SaldoPendiente", "Saldo (₡)", "N2");
            Columna(dgvFacturasPendientes, "Estado", "Estado", "");
        }

        private void FormatearGridHistorial()
        {
            Ocultar(dgvHistorialPagos, "IdFactura");
            Columna(dgvHistorialPagos, "IdPago", "Pago N.°", "");
            Columna(dgvHistorialPagos, "FechaPago", "Fecha", "dd/MM/yyyy");
            Columna(dgvHistorialPagos, "Monto", "Monto (₡)", "N2");
            Columna(dgvHistorialPagos, "MetodoPago", "Método", "");
            Columna(dgvHistorialPagos, "Referencia", "Referencia / comprobante", "");
        }

        private static void Ocultar(DataGridView grid, string nombre)
        {
            if (grid.Columns[nombre] != null) grid.Columns[nombre].Visible = false;
        }

        private static void Columna(DataGridView grid, string nombre, string titulo, string formato)
        {
            if (grid.Columns[nombre] == null) return;
            grid.Columns[nombre].HeaderText = titulo;
            if (!string.IsNullOrEmpty(formato))
                grid.Columns[nombre].DefaultCellStyle.Format = formato;
        }
    }
}
