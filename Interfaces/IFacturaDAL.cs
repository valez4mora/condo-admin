using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Contrato de acceso a datos para la entidad Factura.
    /// </summary>
    public interface IFacturaDAL
    {
        /// <summary>Inserta una factura con su detalle. Retorna el Id generado.</summary>
        int Registrar(FacturaDTO factura);

        /// <summary>Cambia el estado de la factura a "Anulada".</summary>
        bool Anular(int idFactura);

        /// <summary>Guarda el string XML de la factura en la base de datos.</summary>
        bool GuardarXml(int idFactura, string xmlContent);

        /// <summary>Obtiene una factura por su Id (incluye detalles).</summary>
        FacturaDTO ObtenerPorId(int idFactura);

        /// <summary>Todas las facturas de una propiedad.</summary>
        List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad);

        /// <summary>Todas las facturas del sistema.</summary>
        List<FacturaDTO> ObtenerTodas();
    }
}
