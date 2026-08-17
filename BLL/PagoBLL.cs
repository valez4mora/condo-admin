using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PagoBLL
    {
        private readonly PagoDAO pagoDAO;
        private readonly FacturaBLL facturaBLL;

        public PagoBLL()
        {
            pagoDAO = new PagoDAO();
            facturaBLL = new FacturaBLL();
        }

        public bool Registrar(PagoDTO pago)
        {
            ValidarPago(pago, 0);

            // Si no se especificó la fecha,
            // se utiliza la fecha actual.
            if (pago.FechaPago == DateTime.MinValue)
            {
                pago.FechaPago = DateTime.Now;
            }

            return pagoDAO.Registrar(pago);
        }

        public List<PagoDTO> ObtenerTodos()
        {
            return pagoDAO.ObtenerTodos();
        }

        public List<PagoDTO> ObtenerPorFactura(int idFactura)
        {
            if (idFactura <= 0)
            {
                throw new ArgumentException(
                    "El Id de la factura no es válido."
                );
            }

            return pagoDAO.ObtenerPorFactura(idFactura);
        }

        public bool Modificar(PagoDTO pago)
        {
            if (pago == null)
            {
                throw new ArgumentNullException(
                    "El pago no puede ser nulo."
                );
            }

            if (pago.IdPago <= 0)
            {
                throw new ArgumentException(
                    "El Id del pago no es válido."
                );
            }

            ValidarPago(pago, pago.IdPago);

            return pagoDAO.Modificar(pago);
        }

        public bool Eliminar(int idPago)
        {
            if (idPago <= 0)
            {
                throw new ArgumentException(
                    "El Id del pago no es válido."
                );
            }

            return pagoDAO.Eliminar(idPago);
        }

        private void ValidarPago(PagoDTO pago, int idPagoExcluir)
        {
            if (pago == null)
            {
                throw new ArgumentNullException(
                    "El pago no puede ser nulo."
                );
            }

            if (pago.IdFactura <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar una factura válida."
                );
            }

            if (pago.Monto <= 0)
            {
                throw new ArgumentException(
                    "El monto del pago debe ser mayor a cero."
                );
            }

            if (string.IsNullOrWhiteSpace(pago.MetodoPago))
            {
                throw new ArgumentException(
                    "Debe seleccionar un método de pago."
                );
            }

            string[] metodosPermitidos = { "Efectivo", "Tarjeta", "Transferencia", "SINPE" };
            if (!metodosPermitidos.Contains(pago.MetodoPago))
                throw new ArgumentException("El método de pago seleccionado no es válido.");

            if (pago.FechaPago.Date > DateTime.Today)
                throw new ArgumentException("La fecha del pago no puede ser futura.");

            if (pago.Referencia != null && pago.Referencia.Trim().Length > 100)
                throw new ArgumentException("La referencia no puede superar 100 caracteres.");

            if (pago.MetodoPago != "Efectivo" && string.IsNullOrWhiteSpace(pago.Referencia))
                throw new ArgumentException("Ingrese la referencia del pago.");

            FacturaDTO factura = facturaBLL.ObtenerPorId(pago.IdFactura);
            if (factura == null)
                throw new ArgumentException("La factura seleccionada no existe.");

            if (factura.Estado == "Anulada")
                throw new ArgumentException("No se puede pagar una factura anulada.");

            if (factura.Estado == "Pagada")
                throw new ArgumentException("La factura ya se encuentra pagada.");

            decimal pagado = pagoDAO.ObtenerPorFactura(pago.IdFactura)
                .Where(x => x.IdPago != idPagoExcluir)
                .Sum(x => x.Monto);
            decimal saldo = factura.TotalColones - pagado;
            if (saldo <= 0)
                throw new ArgumentException("La factura no tiene saldo pendiente.");

            if (pago.Monto > saldo)
                throw new ArgumentException(
                    "El pago supera el saldo pendiente de la factura: ₡" + saldo.ToString("N2"));
        }
    }
}
