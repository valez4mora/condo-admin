using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportePropiedadDTO
    {
        public int IdPropiedad { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public decimal Area { get; set; }
        public int CantidadResidentes { get; set; }
        public decimal CuotaMantenimiento { get; set; }
        public int IdPropietario { get; set; }
        public string NombrePropietario { get; set; }
        public string EstadoFinanciero { get; set; }
    }
}
