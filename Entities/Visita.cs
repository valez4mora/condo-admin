using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public string NombreVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string  CodigoQR{ get; set; }
        public int IdPropiedad{ get; set; }

    }
}
