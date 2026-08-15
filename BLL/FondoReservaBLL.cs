using DAL.DAO;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FondoReservaBLL
    {
        private readonly FondoReservaDAO dal = new FondoReservaDAO();

        public void RegistrarFondo(
            PropiedadDTO propiedad,
            decimal montoCuota)
        {
            if (propiedad == null)
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");

            if (propiedad.IdPropiedad <= 0)
                throw new ArgumentException(
                    "La propiedad indicada no es válida.");

            if (montoCuota <= 0)
                throw new ArgumentException(
                    "El monto de la cuota debe ser mayor que cero.");

            FondoReserva fondo = new FondoReserva
            {
                IdPropiedad = propiedad.IdPropiedad,
                Porcentaje = 10,
                Monto = montoCuota * 0.10m,
                Fecha = DateTime.Now
            };

            dal.Insertar(fondo);
        }
    }
}
