using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class AreaComun
    {
        public int IdArea { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraApertura { get; set; }
        public DateTime HoraCierre { get; set; }
        public int CapacidadMax { get; set; }

        public decimal TarifaUso { get; set; }
    }
}
