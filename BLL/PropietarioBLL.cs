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
        PersonaDAO personaDAL = new PersonaDAO();
        PropietarioDAL propietarioDAL = new PropietarioDAL();

        public bool Registrar(PropietarioDTO propietario)
        {

            PersonaDTO persona = new PersonaDTO();

            persona.Identificacion = propietario.Identificacion;
            persona.Nombre = propietario.Nombre;
            persona.Apellidos = propietario.Apellidos;
            persona.Sexo = propietario.Sexo;
            persona.Telefono = propietario.Telefono;
            persona.Email = propietario.Email;
            persona.Direccion = propietario.Direccion;


            // Guarda persona
            bool guardado = personaDAL.Registrar(persona);


            if (guardado)
            {
                // Busca el Id generado
                int idPersona = personaDAL.ObtenerIdPorIdentificacion(
                                  propietario.Identificacion);


                propietario.IdPersona = idPersona;


                // Guarda propietario
                return propietarioDAL.Registrar(propietario);
            }

            return false;
        }
    } 
}
