using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class SesionActual
    {

        // Datos del usuario logueado 
        public static int IdUsuario { get; private set; }
        public static string Usuario { get; private set; }
        public static int IdRol { get; private set; }
        public static string NombreRol { get; private set; }
        public static bool EstaActiva { get; private set; }

        // Lista de permisos cargados al hacer login
        private static List<PermisoDTO> _permisos = new List<PermisoDTO>();


        public static void Iniciar(UsuarioDTO usuario, List<PermisoDTO> permisos)
        {
            IdUsuario = usuario.IdUsuario;
            Usuario = usuario.Usuario;
            IdRol = usuario.IdRol;
            NombreRol = usuario.NombreRol;
            EstaActiva = true;
            _permisos = permisos ?? new List<PermisoDTO>();
        }


        public static void Cerrar()
        {
            IdUsuario = 0;
            Usuario = null;
            IdRol = 0;
            NombreRol = null;
            EstaActiva = false;
            _permisos.Clear();
        }


        public static bool TienePermiso(string modulo, string accion)
        {
            // El administrador siempre tiene acceso total
            if (NombreRol == "Administrador") return true;

            PermisoDTO p = _permisos
                .FirstOrDefault(x => x.Modulo == modulo);

            if (p == null) return false;  // no hay permiso registrado para ese módulo

            switch (accion)
            {
                case "Ver": return p.PuedeVer;
                case "Crear": return p.PuedeCrear;
                case "Editar": return p.PuedeEditar;
                case "Eliminar": return p.PuedeEliminar;
                default: return false;
            }
        }


    }
}
