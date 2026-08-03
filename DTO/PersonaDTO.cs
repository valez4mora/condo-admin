using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public string Identificacion { get; set; }
        public string Apellido { get; set; }
        public char Sexo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public byte[] Fotografia { get; set; }
    }
}
