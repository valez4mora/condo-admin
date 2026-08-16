using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class ReporteFacturacionPropiedadDTO
        {
            public int IdCargo { get; set; }
            public int IdPropiedad { get; set; }
            public string CodigoPropiedad { get; set; }
            public string TipoCargo { get; set; }
            public string Descripcion { get; set; }
            public decimal MontoBase { get; set; }
            public decimal Impuesto { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
            public DateTime FechaEmision { get; set; }
            public DateTime FechaVencimiento { get; set; }
        }
    
}
