using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PropietarioBLL
    {
        private PersonaDAO personaDAL = new PersonaDAO();
        private PropietarioDAL propietarioDAL = new PropietarioDAL();

        public bool Registrar(PropietarioDTO propietario)
        {
            Validar(propietario);

            if (personaDAL.ExisteIdentificacion(
                propietario.Identificacion))
            {
                throw new Exception(
                    "Ya existe una persona con esa identificación.");
            }

            PersonaDTO persona = new PersonaDTO
            {
                Identificacion = propietario.Identificacion,
                Nombre = propietario.Nombre,
                Apellidos = propietario.Apellidos,
                Sexo = propietario.Sexo,
                Telefono = propietario.Telefono,
                Email = propietario.Email,
                Direccion = propietario.Direccion,
                Fotografia = propietario.Fotografia
            };

            bool personaGuardada = personaDAL.Registrar(persona);

            if (!personaGuardada)
                return false;

            propietario.IdPersona =
                personaDAL.ObtenerIdPorIdentificacion(
                    propietario.Identificacion);

            return propietarioDAL.Registrar(propietario);
        }

        public List<PropietarioDTO> ObtenerTodos()
        {
            return propietarioDAL.ObtenerTodos();
        }

        public bool Modificar(PropietarioDTO propietario)
        {
            if (propietario.IdPersona <= 0)
                throw new Exception(
                    "Debe seleccionar un propietario.");

            Validar(propietario);

            PersonaDTO persona = new PersonaDTO
            {
                IdPersona = propietario.IdPersona,
                Identificacion = propietario.Identificacion,
                Nombre = propietario.Nombre,
                Apellidos = propietario.Apellidos,
                Sexo = propietario.Sexo,
                Telefono = propietario.Telefono,
                Email = propietario.Email,
                Direccion = propietario.Direccion,
                Fotografia = propietario.Fotografia
            };

            bool personaActualizada =
                personaDAL.Modificar(persona);

            if (!personaActualizada)
                return false;

            return propietarioDAL.Modificar(propietario);
        }

        public bool Eliminar(int idPersona)
        {
            if (idPersona <= 0)
                throw new Exception(
                    "Debe seleccionar un propietario.");

            bool propietarioEliminado =
                propietarioDAL.Eliminar(idPersona);

            if (!propietarioEliminado)
                return false;

            return personaDAL.Eliminar(idPersona);
        }

        private bool EmailValido(string email)
        {
            try
            {
                var direccion =
                    new System.Net.Mail.MailAddress(email);

                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void Validar(PropietarioDTO propietario)
        {
            if (string.IsNullOrWhiteSpace(
                propietario.Identificacion))
                throw new Exception(
                    "La identificación es obligatoria.");

            if (string.IsNullOrWhiteSpace(propietario.Nombre))
                throw new Exception(
                    "El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(propietario.Apellidos))
                throw new Exception(
                    "Los apellidos son obligatorios.");

            if (string.IsNullOrWhiteSpace(propietario.Sexo))
                throw new Exception(
                    "Debe seleccionar el sexo.");

            if (string.IsNullOrWhiteSpace(propietario.Telefono))
                throw new Exception(
                    "El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(propietario.Email))
                throw new Exception(
                    "El correo electrónico es obligatorio.");

            if (!propietario.Email.Contains("@"))
                throw new Exception(
                    "El correo electrónico no es válido.");

            if (string.IsNullOrWhiteSpace(propietario.Direccion))
                throw new Exception(
                    "La dirección es obligatoria.");
        }
    }
}