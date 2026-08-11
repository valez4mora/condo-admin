using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PagoDTO
    {
        public int IdPago { get; set; }

        public int IdFactura { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; }

        public string Referencia { get; set; }
    }
}