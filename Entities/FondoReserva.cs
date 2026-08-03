using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FondoReserva
    {
        public int IdFondoReserva { get; set; }
        public int IdPropiedad { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
