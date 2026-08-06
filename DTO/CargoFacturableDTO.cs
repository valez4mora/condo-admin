using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class CargoFacturableDTO
    {
        public int IdCargo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal MontoBase { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public int IdPropiedad { get; set; }
        public bool Penalizado { get; set; }
    }
}
