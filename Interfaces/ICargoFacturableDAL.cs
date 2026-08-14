using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    /// <summary>
    /// Contrato de acceso a datos para la entidad CargoFacturable.
    /// </summary>
    public interface ICargoFacturableDAL
    {
        /// <summary>Inserta un cargo y retorna true si el Id generado es mayor a 0.</summary>
        bool Registrar(CargoFacturableDTO cargo);

        /// <summary>Actualiza descripción, tipo, montos, fechas y estado de un cargo existente.</summary>
        bool Modificar(CargoFacturableDTO cargo);

        /// <summary>Elimina un cargo por su Id. Solo debe llamarse si el cargo está Pendiente.</summary>
        bool Eliminar(int idCargo);

        /// <summary>Cambia el estado del cargo a "Pagado".</summary>
        bool MarcarComoPagado(int idCargo);

        /// <summary>Obtiene un cargo por su Id primario.</summary>
        CargoFacturableDTO ObtenerPorId(int idCargo);

        /// <summary>Todos los cargos de una propiedad específica.</summary>
        List<CargoFacturableDTO> ObtenerPorPropiedad(int idPropiedad);

        /// <summary>Todos los cargos de todas las propiedades.</summary>
        List<CargoFacturableDTO> ObtenerTodos();
    }
}