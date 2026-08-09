using DAL.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaBLL
    {
        PersonaDAO dal = new PersonaDAO();

        public bool Registrar(PersonaDTO persona)
        {
            // Validaciones 

            if (string.IsNullOrEmpty(persona.Identificacion))
                throw new Exception("La identificación es obligatoria");


            if (string.IsNullOrEmpty(persona.Nombre))
                throw new Exception("El nombre es obligatorio");


            if (string.IsNullOrEmpty(persona.Apellidos))
                throw new Exception("Los apellidos son obligatorios");


            if (dal.ExisteIdentificacion(persona.Identificacion))
                throw new Exception("La identificación ya existe");


            return dal.Registrar(persona);
        }

        public bool Modificar(PersonaDTO persona)
        {
            return dal.Modificar(persona);
        }

        public bool Eliminar(int id)
        {
            return dal.Eliminar(id);
        }

        public List<PersonaDTO> ObtenerTodas()
        {
            return dal.ObtenerTodas();
        }

        public PersonaDTO ObtenerPorId(int id)
        {
            return dal.ObtenerPorId(id);
        }
    }
}
