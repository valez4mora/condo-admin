using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRolDAL
    {
        int Registrar(RolDTO rol);               
        List<RolDTO> ObtenerTodos();                      
        RolDTO ObtenerPorId(int idRol);             
        bool Modificar(RolDTO rol);               
        bool Eliminar(int idRol);                 
        List<PermisoDTO> ObtenerPermisos(int idRol);        
        bool GuardarPermiso(PermisoDTO permiso);




    }
}
