using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Representa la información general de una factura emitida
    /// para una propiedad del condominio.
    /// </summary>
    /// <remarks>
    /// Este DTO transporta el encabezado de la factura, sus totales,
    /// su estado financiero y la lista de cargos incluidos.
    /// </remarks>
    public class FacturaDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador de la factura.
        /// </summary>
        public int IdFactura { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de de emisión de la factura.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece el total de la factura expresado en colones.
        /// </summary>
        public decimal TotalColones { get; set; }

        /// <summary>
        /// Obtiene o establece el total de la factura expresado en dólares.
        /// </summary>
        public decimal TotalDolares { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad facturada.
        /// </summary>
        public int IdPropiedad { get; set; }

        /// <summary>
        /// Obtiene o establece el código de la propiedad facturada.
        /// </summary>
        public string CodigoPropiedad { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual de la factura.
        /// </summary>
        /// <remarks>
        /// Algunos estados posibles son Emitida, Pagada o Anulada.
        /// </remarks>
        public string Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el monto total pagado de la factura.
        /// </summary>
        public decimal TotalPagado { get; set; }

        /// <summary>
        /// Obtiene o establece el saldo que continúa pendiente de pago.
        /// </summary>
        public decimal SaldoPendiente { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de cambio utilizado para convertir
        /// el total de colones a dólares.
        /// </summary>
        public decimal TipoCambio { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de detalles o cargos
        /// incluidos en la factura.
        /// </summary>
        public List<DetalleFacturaDTO> Detalles { get; set; } =
            new List<DetalleFacturaDTO>();
    }

    /// <summary>
    /// Representa un cargo individual incluido dentro de una factura.
    /// </summary>
    /// <remarks>
    /// Contiene la información del cargo facturable, su precio,
    /// impuestos, cantidad y subtotal.
    /// </remarks>
    public class DetalleFacturaDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador del detalle de factura.
        /// </summary>
        public int IdDetalle { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la factura
        /// a la que pertenece el detalle.
        /// </summary>
        public int IdFactura { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del cargo facturable asociado.
        /// </summary>
        public int IdCargo { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del cargo facturado.
        /// </summary>
        public string DescripcionCargo { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de cargo incluido en la factura.
        /// </summary>
        public string TipoCargo { get; set; }

        /// <summary>
        /// Obtiene o establece el monto del cargo antes de aplicar impuestos.
        /// </summary>
        public decimal MontoBase { get; set; }

        /// <summary>
        /// Obtiene o establece el monto correspondiente al impuesto
        /// sobre el valor agregado.
        /// </summary>
        public decimal IVA { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se emitió el cargo.
        /// </summary>
        public DateTime FechaEmision { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha límite de pago del cargo.
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual del cargo facturable.
        /// </summary>
        public string EstadoCargo { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de unidades facturadas.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Obtiene o establece el precio unitario del cargo.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Obtiene o establece el subtotal correspondiente al detalle.
        /// </summary>
        public decimal SubTotal { get; set; }
    }
}