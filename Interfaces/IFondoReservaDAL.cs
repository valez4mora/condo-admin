using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFondoReservaDAL
    {
        void Insertar(FondoReserva fondo);

        List<FondoReserva> ObtenerTodos();

        List<FondoReserva> ObtenerPorPropiedad(int idPropiedad);
    }
}
