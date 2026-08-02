using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdPropiedad { get; set; }
        public int IdArea { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Estado { get; set; }
        public int CantidadPersonas { get; set; }
        public string MotivoCancelacion { get; set; }
        public int IdResidente { get; set; }

    }
}
