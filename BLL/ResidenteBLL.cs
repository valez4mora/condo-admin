using DAL.Persistencia;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResidenteBLL
    {
        PersonaDAO personaDAL = new PersonaDAO();
        ResidenteDAO residenteDAL = new ResidenteDAO();

        public bool Registrar(ResidenteDTO residente)
        {
            // Crear objeto Persona
            PersonaDTO persona = new PersonaDTO();

            persona.Identificacion = residente.Identificacion;
            persona.Nombre = residente.Nombre;
            persona.Apellido = residente.Apellido;
            persona.Sexo = residente.Sexo;
            persona.Telefono = residente.Telefono;
            persona.Email = residente.Email;
            persona.Direccion = residente.Direccion;

            // Guardar Persona primero
            bool guardado = personaDAL.Registrar(persona);

            if (guardado)
            {
                // Obtener IdPersona generado
                int idPersona = personaDAL.ObtenerIdPorIdentificacion(
                    residente.Identificacion);

                // Asignarlo al residente
                residente.IdPersona = idPersona;

                // Guardar residente
                return residenteDAL.Registrar(residente);
            }

            return false;
        }

        public bool Modificar(ResidenteDTO residente)
        {
            return residenteDAL.Modificar(residente);
        }

        public bool Eliminar(int id)
        {
            return residenteDAL.Eliminar(id);
        }
        public List<ResidenteDTO> ObtenerTodos()
        {
            return residenteDAL.ObtenerTodos();
        }

    }
}
