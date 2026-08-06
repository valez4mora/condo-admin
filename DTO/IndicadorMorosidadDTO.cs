using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IndicadorMorosidadDTO
    {
        public int IdIndicador { get; set; }

        public int IdPropiedad { get; set; }

        public int MesesMora { get; set; }

        public int FacturasPendientes { get; set; }

        public decimal MontoAdeudado { get; set; }

        public decimal TasaInteres { get; set; }

        public decimal InteresCalculado { get; set; }

        public decimal IndiceRiesgo { get; set; }

        public string Clasificacion { get; set; }

        public DateTime FechaCalculo { get; set; }
    }
}
