using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

        public class IngresoMensualDTO
        {
            public int NumeroMes { get; set; }
            public string Mes { get; set; }
            public decimal TotalColones { get; set; }
            public decimal TotalDolares { get; set; }
        }
    
}
