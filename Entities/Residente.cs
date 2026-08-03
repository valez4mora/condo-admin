using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Residente : Persona
    {
        public int IdResidente { get; set; }
        public int IdPropiedad { get; set; }
    }
}
