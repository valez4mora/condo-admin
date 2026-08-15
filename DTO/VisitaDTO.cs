using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VisitaDTO
    {
        public int IdVisita { get; set; }
        public string NombreVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }   // nullable: null = aún dentro
        public string CodigoQR { get; set; }
        public int IdPropiedad { get; set; }

        // Solo para mostrar en grids (no se guarda en BD)
        public string CodigoPropiedad { get; set; }
        public string Estado => HoraSalida.HasValue ? "Fuera" : "Dentro";
    }
}
