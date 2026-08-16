using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AreaComunDTO
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion{ get; set; }
        public TimeSpan HoraApertura{ get; set; }
        public TimeSpan HoraCierre { get; set; }
        public int CapacidadMaxima{ get; set; }
        public decimal Tarifa  { get; set; }


        //propiedades calculadas que solo van en la ui 

        // formato de la hora
      
        public string HorarioTexto =>
            $"{DateTime.Today.Add(HoraApertura):hh:mm tt} – " +
            $"{DateTime.Today.Add(HoraCierre):hh:mm tt}";

        //vrdadero si el área cobra tarifa por uso
        public bool TieneTarifa => Tarifa > 0;
    }
}
