using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReporteMorosidadDTO
    {
        public int IdPropiedad { get; set; }

        public string CodigoPropiedad { get; set; }

        public int IdPropietario { get; set; }

        public string NombrePropietario { get; set; }

        public decimal MontoTotalAdeudado { get; set; }

        public int CantidadCargosPendientes { get; set; }

        public DateTime? UltimoPago { get; set; }

        public int DiasMaximosMora { get; set; }

        public string ClasificacionRiesgo { get; set; }

        public string UltimoPagoTexto
        {
            get
            {
                return UltimoPago.HasValue
                    ? UltimoPago.Value.ToString("dd/MM/yyyy")
                    : "Sin pagos registrados";
            }
        }
    }
}
