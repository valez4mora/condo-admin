using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsuarioDAL
    {

        int Registrar(UsuarioDTO usuario);                            
        List<UsuarioDTO> ObtenerTodos();                                     
        UsuarioDTO ObtenerPorCredenciales(string usuario, string hashContrasena); 
        bool Modificar(UsuarioDTO usuario);                              
        bool CambiarContrasena(int idUsuario, string nuevoHash);         
        bool Eliminar(int idUsuario);







    }
}
