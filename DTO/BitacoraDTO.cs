using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BitacoraDTO
    {
        public int IdBitacora { get; set; }
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
    }
}
