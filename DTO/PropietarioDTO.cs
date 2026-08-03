using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PropietarioDTO : PersonaDTO
    {
        public int IdPropietario { get; set; }

        public bool EstadoMorosidad { get; set; }
    }
}
