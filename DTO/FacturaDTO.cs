using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalColones { get; set; }
        public decimal TotalDolares { get; set; }
        public int IdPropiedad { get; set; }
        public string CodigoPropiedad { get; set; }
        public string Estado { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal TipoCambio { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; } = new List<DetalleFacturaDTO>();
    }

    public class DetalleFacturaDTO
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdCargo { get; set; }
        public string DescripcionCargo { get; set; }
        public string TipoCargo { get; set; }
        public decimal MontoBase { get; set; }
        public decimal IVA { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoCargo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
    }
}
