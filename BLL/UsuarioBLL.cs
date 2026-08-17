using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using Util;

namespace BLL
{
    
    public class UsuarioBLL
    {
        private readonly IUsuarioDAL _dal;
        private readonly IRolDAL _dalRol;

        
        private static readonly Dictionary<string, int> _intentosFallidos
            = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private const int MAX_INTENTOS = 3; // bloquea al cuarto intento

        public UsuarioBLL()
        {
            _dal = new UsuarioDAO();
            _dalRol = new RolDAO();
        }

     
        public UsuarioDTO Login(string nombreUsuario, string contrasenaPlana)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new Exception("Ingrese el nombre de usuario.");
            if (string.IsNullOrWhiteSpace(contrasenaPlana))
                throw new Exception("Ingrese la contraseña.");

            // se verifica si el usuario ya está bloqueado por intentos
            if (_intentosFallidos.TryGetValue(nombreUsuario, out int intentos)
                && intentos >= MAX_INTENTOS)
            {
                throw new Exception(
                    $"Usuario bloqueado por {MAX_INTENTOS} intentos fallidos. " +
                    "Contacte al administrador.");
            }

            // hashear la contraseña ingresada antes de consultar la BD
            string hash = HashUtil.Hashear(contrasenaPlana);

            // consultar bd
            UsuarioDTO usuario = _dal.ObtenerPorCredenciales(nombreUsuario, hash);

            if (usuario == null)
            {
                //si la credencial es incorrecta se aumenta el contador
                if (!_intentosFallidos.ContainsKey(nombreUsuario))
                    _intentosFallidos[nombreUsuario] = 0;
                _intentosFallidos[nombreUsuario]++;

                int restantes = MAX_INTENTOS - _intentosFallidos[nombreUsuario];

                if (restantes <= 0)
                    throw new Exception(
                        $"Usuario bloqueado. Ha superado el límite de {MAX_INTENTOS} intentos.");

                throw new Exception(
                    $"Usuario o contraseña incorrectos. " +
                    $"Intentos restantes: {restantes}.");
            }

            
            _intentosFallidos.Remove(nombreUsuario);

            // cargar permisos del rol e iniciar sesión
            List<PermisoDTO> permisos = _dalRol.ObtenerPermisos(usuario.IdRol);
            SesionActual.Iniciar(usuario, permisos);

            return usuario;
        }

       
        public int Registrar(UsuarioDTO usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("El usuario no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(usuario.Usuario))
                throw new Exception("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new Exception("La contraseña es obligatoria.");
            if (usuario.Contrasena.Length < 6)
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
            if (usuario.IdRol <= 0)
                throw new Exception("Debe asignar un rol al usuario.");

            // Hashear antes de enviar al DAL
            usuario.Contrasena = HashUtil.Hashear(usuario.Contrasena);
            return _dal.Registrar(usuario);
        }

        public List<UsuarioDTO> ObtenerTodos() => _dal.ObtenerTodos();

        public bool Modificar(UsuarioDTO usuario)
        {
            if (usuario == null || usuario.IdUsuario <= 0)
                throw new Exception("Datos de usuario inválidos.");
            if (string.IsNullOrWhiteSpace(usuario.Usuario))
                throw new Exception("El nombre de usuario es obligatorio.");
            if (usuario.IdRol <= 0)
                throw new Exception("Debe asignar un rol.");

            return _dal.Modificar(usuario);
        }

       
        public bool CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            if (idUsuario <= 0)
                throw new Exception("Id de usuario no válido.");
            if (string.IsNullOrWhiteSpace(nuevaContrasena) || nuevaContrasena.Length < 6)
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");

            string hash = HashUtil.Hashear(nuevaContrasena);
            return _dal.CambiarContrasena(idUsuario, hash);
        }

        public bool Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Id de usuario no válido.");
            return _dal.Eliminar(idUsuario);
        }
    }
}