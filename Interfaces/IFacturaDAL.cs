using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// Contrato de acceso a datos para la entidad Factura.
    public interface IFacturaDAL
    {
        ///Inserta una factura con su detalle. Retorna el Id generado.
        int Registrar(FacturaDTO factura);

        ///Cambia el estado de la factura a "Anulada".
        bool Anular(int idFactura);

        ///Guarda el string XML de la factura en la base de datos.
        bool GuardarXml(int idFactura, string xmlContent);
        bool ExisteFacturaParaCargo(int idCargo);

        ///Obtiene una factura por su Id (incluye detalles).
        FacturaDTO ObtenerPorId(int idFactura);

        ///Todas las facturas de una propiedad.
        List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad);

        ///Todas las facturas del sistema.
        List<FacturaDTO> ObtenerTodas();
    }
}
