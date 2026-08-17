using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BLL
{
    public class ResidenteBLL
    {
        private readonly PersonaDAO personaDAO = new PersonaDAO();
        private readonly ResidenteDAO residenteDAO = new ResidenteDAO();

        public bool Registrar(ResidenteDTO residente)
        {
            Validar(residente);
            if (personaDAO.ExisteIdentificacion(residente.Identificacion))
                throw new Exception("Ya existe una persona con esa identificación.");

            if (!personaDAO.Registrar(MapearPersona(residente))) return false;

            residente.IdPersona = personaDAO.ObtenerIdPorIdentificacion(residente.Identificacion);
            if (residente.IdPersona <= 0)
                throw new Exception("No fue posible recuperar la persona registrada.");

            return residenteDAO.Registrar(residente);
        }

        public bool Modificar(ResidenteDTO residente)
        {
            if (residente.IdPersona <= 0)
                throw new Exception("Debe seleccionar un residente.");
            Validar(residente);
            return residenteDAO.Modificar(residente);
        }

        public bool Eliminar(int idPersona)
        {
            if (idPersona <= 0)
                throw new Exception("Debe seleccionar un residente.");
            return residenteDAO.Eliminar(idPersona);
        }

        public List<ResidenteDTO> ObtenerTodos() { return residenteDAO.ObtenerTodos(); }

        private static PersonaDTO MapearPersona(ResidenteDTO r)
        {
            return new PersonaDTO
            {
                IdPersona = r.IdPersona,
                Identificacion = r.Identificacion,
                Nombre = r.Nombre,
                Apellidos = r.Apellidos,
                Sexo = r.Sexo,
                Telefono = r.Telefono,
                Email = r.Email,
                Direccion = r.Direccion,
                Fotografia = r.Fotografia
            };
        }

        private static void Validar(ResidenteDTO r)
        {
            if (r == null)
            {
                throw new ArgumentNullException("r");
            }

            if (string.IsNullOrWhiteSpace(r.Identificacion))
            {
                throw new Exception(
                    "La identificación es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(r.Nombre))
            {
                throw new Exception(
                    "El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(r.Apellidos))
            {
                throw new Exception(
                    "Los apellidos son obligatorios.");
            }

            if (r.Sexo != "M" && r.Sexo != "F")
            {
                throw new Exception(
                    "Debe seleccionar el sexo.");
            }

            if (string.IsNullOrWhiteSpace(r.Telefono))
            {
                throw new Exception(
                    "El teléfono es obligatorio.");
            }

            if (!EmailValido(r.Email))
            {
                throw new Exception(
                    "El correo electrónico no es válido.");
            }

            if (r.IdPropiedad <= 0)
            {
                throw new Exception(
                    "Debe seleccionar la propiedad asignada.");
            }
        }

        private static bool EmailValido(string email)
        {
            try
            {
                MailAddress direccion = new MailAddress(email ?? string.Empty);
                return direccion.Address == email;
            }
            catch { return false; }
        }
    }
}
