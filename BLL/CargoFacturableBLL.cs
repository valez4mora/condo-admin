using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace BLL
{
    public class CargoFacturableBILL
    {
        ICargoFacturableDAL dal= new CargoFacturableDAO();

        public CargoFacturableDTO  GenerarCuotaOrdinaria(PropiedadDTO propiedad) //cuota de mantenimiento
        {
            if (propiedad == null)
            {
                throw new Exception("Debe indicar una propiedad válida.");
            }
            if (propiedad.Area <= 0)
            {
                throw new Exception("La propiedad no tiene un área válida.");
            }
            if (propiedad.TarifaMetro <= 0)
            {
                throw new Exception("La propiedad no tiene tarifa configurada.");
            }
            decimal MontoBase= (propiedad.Area * propiedad.TarifaMetro) + propiedad.CargoFijo;
            CargoFacturableDTO cargo = GestionFinancieraFactory.CrearCuotaMantenimiento(propiedad.IdPropiedad, MontoBase);

            bool guardado=dal.Registrar(cargo);

            if (!guardado)
            {
                throw new Exception("No se pudo guardar la cuota en la base de datos.");
            }
            return cargo;
        }
    }
}
