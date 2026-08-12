using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.BCCR
{
    public class BCCRResponseDTO
    {
        public int CodigoIndicador { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Valor { get; set; }
    }
}