using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PropietarioBLL
    {
        private readonly PersonaDAO _personaDAL = new PersonaDAO();
        private readonly PropietarioDAO _propietarioDAL = new PropietarioDAO();

        public bool Registrar(PropietarioDTO propietario)
        {
            Validar(propietario);

            if (_personaDAL.ExisteIdentificacion(propietario.Identificacion))
                throw new Exception("Ya existe una persona con esa identificación.");

            PersonaDTO persona = MapearPersona(propietario);
            bool personaGuardada = _personaDAL.Registrar(persona);
            if (!personaGuardada) return false;

            propietario.IdPersona =
                _personaDAL.ObtenerIdPorIdentificacion(propietario.Identificacion);

            return _propietarioDAL.Registrar(propietario);
        }

        public List<PropietarioDTO> ObtenerTodos()
        {
            return _propietarioDAL.ObtenerTodos();
        }

        public bool Modificar(PropietarioDTO propietario)
        {
            if (propietario.IdPersona <= 0)
                throw new Exception("Debe seleccionar un propietario.");

            Validar(propietario);

            return _propietarioDAL.Modificar(propietario);
        }

        public bool Eliminar(int idPersona)
        {
            if (idPersona <= 0)
                throw new Exception("Debe seleccionar un propietario.");

            bool propietarioEliminado = _propietarioDAL.Eliminar(idPersona);
            if (!propietarioEliminado) return false;

            return _personaDAL.Eliminar(idPersona);
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private PersonaDTO MapearPersona(PropietarioDTO p) => new PersonaDTO
        {
            IdPersona = p.IdPersona,
            Identificacion = p.Identificacion,
            Nombre = p.Nombre,
            Apellidos = p.Apellidos,
            Sexo = p.Sexo,
            Telefono = p.Telefono,
            Email = p.Email,
            Direccion = p.Direccion,
            Fotografia = p.Fotografia
        };

        private void Validar(PropietarioDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.Identificacion))
                throw new Exception("La identificación es obligatoria.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Apellidos))
                throw new Exception("Los apellidos son obligatorios.");
            if (string.IsNullOrWhiteSpace(p.Sexo))
                throw new Exception("Debe seleccionar el sexo.");
            if (string.IsNullOrWhiteSpace(p.Telefono))
                throw new Exception("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Email) || !p.Email.Contains("@"))
                throw new Exception("El correo electrónico no es válido.");
            if (string.IsNullOrWhiteSpace(p.Direccion))
                throw new Exception("La dirección es obligatoria.");
        }

        private bool EmailValido(string email)
        {
            try
            {
                var dir = new System.Net.Mail.MailAddress(email);
                return dir.Address == email;
            }
            catch { return false; }
        }
    }
}