using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Hacienda
{
    public interface IHaciendaService
    {
        HaciendaResponseDTO ConsultarIdentificacion(string identificacion);
    }
}
