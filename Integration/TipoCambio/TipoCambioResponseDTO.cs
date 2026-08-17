using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.TipoCambio
{
    public class TipoCambioResponseDTO
    {
        public string MonedaBase { get; set; }

        public string MonedaDestino { get; set; }

        public decimal Valor { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public string Proveedor { get; set; }
    }
}
