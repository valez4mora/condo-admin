using DAL.DAO;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
   
    public class RolBLL
    {
        
        private readonly IRolDAL _dal;

        public RolBLL()
        {
            _dal = new RolDAO(); 
        }

        
        public int Registrar(RolDTO rol)
        {
            if (rol == null)
                throw new ArgumentNullException("El rol no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(rol.Nombre))
                throw new Exception("El nombre del rol es obligatorio.");
            if (rol.Nombre.Length > 50)
                throw new Exception("El nombre no puede superar 50 caracteres.");

            return _dal.Registrar(rol);
        }

        
        public List<RolDTO> ObtenerTodos() => _dal.ObtenerTodos();

    
        public RolDTO ObtenerPorId(int idRol)
        {
            if (idRol <= 0) throw new Exception("Id de rol no válido.");
            return _dal.ObtenerPorId(idRol);
        }

        
        public bool Modificar(RolDTO rol)
        {
            if (rol == null || rol.IdRol <= 0)
                throw new Exception("Datos del rol inválidos.");
            if (string.IsNullOrWhiteSpace(rol.Nombre))
                throw new Exception("El nombre del rol es obligatorio.");

            return _dal.Modificar(rol);
        }

      
        public bool Eliminar(int idRol)
        {
            if (idRol <= 0) throw new Exception("Id de rol no válido.");
           
            return _dal.Eliminar(idRol);
        }

        
        public List<PermisoDTO> ObtenerPermisos(int idRol)
        {
            if (idRol <= 0) throw new Exception("Id de rol no válido.");
            return _dal.ObtenerPermisos(idRol);
        }

        public bool GuardarPermiso(PermisoDTO permiso)
        {
            if (permiso == null || permiso.IdRol <= 0)
                throw new Exception("Datos de permiso inválidos.");
            if (string.IsNullOrWhiteSpace(permiso.Modulo))
                throw new Exception("El módulo del permiso es obligatorio.");

            return _dal.GuardarPermiso(permiso);
        }
    }
}