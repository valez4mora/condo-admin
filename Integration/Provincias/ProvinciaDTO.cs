using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Integration.Provincias
{
    public class ProvinciaDTO
    {
        [JsonProperty("IdProvincia")]
        public int Id { get; set; }

        [JsonProperty("Descripcion")]
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}