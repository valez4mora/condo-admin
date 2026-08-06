using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IIndicadorMorosidadDAL
    {
        void Insertar(IndicadorMorosidad indicador);

        List<IndicadorMorosidad> ObtenerTodos();

        IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad);
        
    }
}
