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
        public TimeSpan HoraEntrada { get; set; }
        public Nullable<TimeSpan> HoraSalida { get; set; }

        public string CodigoQR { get; set; }
        public int IdPropiedad { get; set; }
        public string CodigoPropiedad { get; set; }

        public string Estado => HoraSalida.HasValue ? "Fuera" : "Dentro";

        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");

        public string HoraEntradaTexto =>
            DateTime.Today.Add(HoraEntrada).ToString("hh:mm tt");

        public string HoraSalidaTexto =>
            HoraSalida.HasValue
            ? DateTime.Today.Add(HoraSalida.Value).ToString("hh:mm tt")
            : "—";
    }
}
