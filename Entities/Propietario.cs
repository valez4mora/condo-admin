using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Propietario :Persona
    {
        public int IdPropietario { get; set; }
        public bool EstadoMorosidad { get; set; }
    }
}
