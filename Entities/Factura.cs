using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalColones { get; set; }
        public decimal TotalDolares { get; set; }
        public int IdPropiedad { get; set; }
        public string Estado { get; set; }
        public XElement XmlFactura { get; set; }

    }
}
