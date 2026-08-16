using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BLL
{
    public class PropiedadBLL
    {
        PropiedadDAO dal = new PropiedadDAO();

        public bool Registrar(PropiedadDTO propiedad)
        {
            CalcularCuota(propiedad);
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

        public PropiedadDTO ObtenerPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("Debe indicar un código para buscar.");

            return dal.ObtenerPorCodigo(codigo);
        }

        public PropiedadDTO ObtenerPorId(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new Exception("Debe indicar una propiedad válida.");

            PropiedadDTO propiedad = dal.ObtenerPorId(idPropiedad);
            if (propiedad == null)
                throw new Exception("La propiedad seleccionada ya no existe.");

            return propiedad;
        }

        public bool Modificar(PropiedadDTO propiedad)
        {
            CalcularCuota(propiedad);
            if (propiedad.IdPropiedad <= 0)
                throw new Exception("Debe buscar una propiedad antes de actualizar.");

            if (string.IsNullOrWhiteSpace(propiedad.Codigo))
                throw new Exception("El código es obligatorio.");

            if (propiedad.Area <= 0)
                throw new Exception("El área debe ser mayor a cero.");

            if (propiedad.CantidadResidentes < 0)
                throw new Exception("Cantidad de residentes inválida.");

            if (propiedad.IdPropietario <= 0)
                throw new Exception("Debe seleccionar un propietario.");

            return dal.Modificar(propiedad);
        }

        private void CalcularCuota(PropiedadDTO propiedad)
        {
            if (propiedad == null)
                throw new Exception("Los datos de la propiedad son obligatorios.");

            if (propiedad.TarifaMetro <= 0)
                throw new Exception("La tarifa por metro cuadrado debe ser mayor a cero.");

            if (propiedad.CargoFijo < 0)
                throw new Exception("El cargo fijo no puede ser negativo.");

            propiedad.CuotaMantenimiento =
                (propiedad.Area * propiedad.TarifaMetro) + propiedad.CargoFijo;
        }

        public bool Eliminar(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new Exception("Debe buscar una propiedad antes de eliminar.");

            return dal.Eliminar(idPropiedad);
        }
    }
}
