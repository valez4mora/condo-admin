using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IPropiedadDAL
    {
        bool Registrar(PropiedadDTO propiedad);

        bool Modificar(PropiedadDTO propiedad);

        bool Eliminar(int idPropiedad);

        List<PropiedadDTO> ObtenerTodas();

        PropiedadDTO ObtenerPorId(int idPropiedad);

        bool ExisteCodigo(string codigo);
    }
}
