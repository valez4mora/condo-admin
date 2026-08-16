using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReservaDTO
    {
        //Datos propios
        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }

        public TimeSpan HoraInicio  { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public string MotivoCancelacion{ get; set; }



        //claves foraneas
        public int IdArea { get; set; }
        public int IdPropiedad { get; set; }
        public int IdResidente { get; set; }


        //datos del join 
        public string AreaComun { get; set; }
        public decimal Tarifa { get; set; }
        public string CodigoPropiedad { get; set; }
        public string NombreResidente { get; set; }


        //propiedades calculadas para la ui 
        public string HorarioTexto =>
            $"{DateTime.Today.Add(HoraInicio):hh:mm tt} – " +
            $"{DateTime.Today.Add(HoraFin):hh:mm tt}";

        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");

        public bool EsPendiente => Estado == "Pendiente";

        public bool GeneraCargo => Tarifa > 0;










    }
}
