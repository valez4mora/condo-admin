using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public int IdUsuario { get; set; }
        public string Evento { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaHora { get; set; }
        public string Ip { get; set; }
    }
}
