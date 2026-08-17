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
        List<IndicadorMorosidad> RecalcularTodos(decimal tasaMensual);
        int AplicarPenalizaciones();
        List<IndicadorMorosidad> ObtenerTodos();
        IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad);
    }
}
