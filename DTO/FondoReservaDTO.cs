using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FondoReservaDTO
    {
        public int IdPropiedad { get; set; }
        public decimal CuotaMantenimiento { get; set; }
        public decimal FondoReserva { get; set; }
        public DateTime Fecha { get; set; }
    }
}
