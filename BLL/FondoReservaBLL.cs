
using DAL.Persistencia;
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

        public void RegistrarFondo(PropiedadDTO propiedad)
        {
            decimal cuota = (propiedad.Area * propiedad.TarifaMetro) + propiedad.CargoFijo;

            FondoReserva fondo = new FondoReserva
            {
                IdPropiedad = propiedad.IdPropiedad,
                Porcentaje = 10,
                Monto = cuota * 0.10m,
                Fecha = DateTime.Now
            };

            dal.Insertar(fondo);
        }
    }
}
