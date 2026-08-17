using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class PermisoDTO
    {

        public int IdPermiso { get; set; }
        public int IdRol { get; set; }
        public string Modulo { get; set; }  
        public bool PuedeVer { get; set; }
        public bool PuedeCrear { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeEliminar { get; set; }



    }
}
