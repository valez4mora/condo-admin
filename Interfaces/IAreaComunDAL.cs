using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IAreaComunDAL
    {
        //insertar un area nueva en la base de datos 
        bool Insertar(AreaComunDTO area);
        //actualizar los datos de areas existentes 
        bool Actualizar(AreaComunDTO area);
        //eliminar areas por medio del store procedure
        bool Eliminar(int idAreaCom);
        //retornar todas las areas comunes 
        List<AreaComunDTO> ObtenerTodas();
        //retornar un area por su id o un null en caso de que no exista
        AreaComunDTO ObtenerPorId(int idArea);
    }
}
