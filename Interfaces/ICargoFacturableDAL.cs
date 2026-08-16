using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    /// Contrato de acceso a datos para la entidad CargoFacturable.
    public interface ICargoFacturableDAL
    {
        ///Inserta un cargo y retorna true si el Id generado es mayor a 0.
        bool Registrar(CargoFacturableDTO cargo);

        ///Actualiza descripción, tipo, montos, fechas y estado de un cargo existente.
        bool Modificar(CargoFacturableDTO cargo);

        ///Elimina un cargo por su Id. Solo debe llamarse si el cargo está Pendiente.
        bool Eliminar(int idCargo);

        ///Cambia el estado del cargo a "Pagado".
        bool MarcarComoPagado(int idCargo);

        ///Obtiene un cargo por su Id primario.
        CargoFacturableDTO ObtenerPorId(int idCargo);

        ///Todos los cargos de una propiedad específica.
        List<CargoFacturableDTO> ObtenerPorPropiedad(int idPropiedad);

        ///Todos los cargos de todas las propiedades.
        List<CargoFacturableDTO> ObtenerTodos();
    }
}