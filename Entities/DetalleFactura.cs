using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdCargo { get; set; }
        public int cantidad  { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

    }
}
