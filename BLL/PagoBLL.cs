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

        public PagoBLL()
        {
            pagoDAO = new PagoDAO();
        }

        public bool Registrar(PagoDTO pago)
        {
            ValidarPago(pago);

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

            ValidarPago(pago);

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

        private void ValidarPago(PagoDTO pago)
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
        }
    }
}