using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PropiedadBLL
    {
        PropiedadDAO dal = new PropiedadDAO();

        public bool Registrar(PropiedadDTO propiedad)
        {
            if (string.IsNullOrWhiteSpace(propiedad.Codigo))
                throw new Exception("El código es obligatorio.");

            if (propiedad.Codigo.Length > 20)
                throw new Exception("El código supera el límite permitido.");

            if (dal.ExisteCodigo(propiedad.Codigo))
                throw new Exception("El código ya existe.");

            if (string.IsNullOrWhiteSpace(propiedad.Tipo))
                throw new Exception("Debe indicar el tipo de propiedad.");

            if (propiedad.Area <= 0)
                throw new Exception("El área debe ser mayor a cero.");

            if (propiedad.CantidadResidentes < 0)
                throw new Exception("Cantidad de residentes inválida.");

            if (propiedad.IdPropietario <= 0)
                throw new Exception("Debe seleccionar un propietario.");

            return dal.Registrar(propiedad);
        }

        public List<PropiedadDTO> ObtenerTodas()
        {
            return dal.ObtenerTodas();
        }
    }
}

