using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Patrones
{
    public class CargoFacturableFactory
    {
        private const decimal PORCENTAJE_IVA = 0.3m;

        public static CargoFacturableDTO CrearCuotaMantenimiento(int idPropiedad,decimal montoBase)
        {
            decimal iva = montoBase * PORCENTAJE_IVA;
            decimal total = montoBase + iva;

            return new CargoFacturableDTO // se crea el objeto
            {
                Descripcion = "Cuota de mantenimiento",
                Tipo = "Cuota de mantenimiento",
                MontoBase = montoBase,
                IVA = iva,
                Total = total,
                FechaEmision=DateTime.Now,
                FechaVencimiento=DateTime.Now.AddDays(30),
                Estado="Pendiente",
                IdPropiedad=idPropiedad



            };


        }
    }
}
