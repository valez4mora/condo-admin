using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Propiedad
    {
        public int IdPropiedad { get; set; }
        public string Codigo { get; set; }
        public string  Tipo { get; set; }
        public decimal AreaM2 { get; set; }
        public decimal CargoFijo { get; set; }
        public decimal TarifaM2 { get; set; }
        public  int IdPropietario { get; set; }
        public decimal CuotaMantenimiento { get; set; }
        public int CantidadResidente { get; set; }

        public string Direccion { get; set; }
    }
}
