using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Hacienda
{
    public class HaciendaResponseDTO
    {
        public int Code { get; set; }
        public string Status { get; set; }

        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }

        public RegimenDTO Regimen { get; set; }
        public SituacionDTO Situacion { get; set; }

        public List<ActividadDTO> Actividades { get; set; }
    }

    public class RegimenDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public class SituacionDTO
    {
        public string Estado { get; set; }
        public string Moroso { get; set; }
        public string Omiso { get; set; }
    }

    public class ActividadDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
