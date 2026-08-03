using DAL.Persistencia;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;

namespace BLL
{
    public class CargoFacturableBILL
    {
        ICargoFacturableDAL dal= new CargoFacturableDAL();

        public bool GenerarCuotaOrdinaria(PropiedadDTO propiedad)
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
            CargoFacturableDTO cargo = CargoFacturableFactory.CrearCuotaMantenimiento(propiedad.IdPropiedad, MontoBase);

            return dal.Registrar(cargo);
        }
    }
}
