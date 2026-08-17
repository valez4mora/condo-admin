using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Representa la información del indicador de morosidad correspondiente
    /// a una propiedad del condominio.
    /// </summary>
    /// <remarks>
    /// Este DTO transporta los datos de la deuda, el interés calculado,
    /// el nivel de riesgo y las restricciones aplicadas a la propiedad.
    /// </remarks>
    public class IndicadorMorosidadDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador del indicador de morosidad.
        /// </summary>
        public int IdIndicador { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad evaluada.
        /// </summary>
        public int IdPropiedad { get; set; }

        /// <summary>
        /// Obtiene o establece el código de la propiedad.
        /// </summary>
        public string CodigoPropiedad { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del propietario.
        /// </summary>
        public string NombrePropietario { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de días de atraso.
        /// </summary>
        public int DiasMora { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de meses de atraso.
        /// </summary>
        public int MesesMora { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de facturas pendientes de pago.
        /// </summary>
        public int FacturasPendientes { get; set; }

        /// <summary>
        /// Obtiene o establece el monto total pendiente de pago.
        /// </summary>
        public decimal MontoAdeudado { get; set; }

        /// <summary>
        /// Obtiene o establece la tasa de interés utilizada para calcular
        /// el cargo por morosidad.
        /// </summary>
        public decimal TasaInteres { get; set; }

        /// <summary>
        /// Obtiene o establece el monto de interés calculado sobre la deuda.
        /// </summary>
        public decimal InteresCalculado { get; set; }

        /// <summary>
        /// Obtiene o establece el índice numérico de riesgo de la propiedad.
        /// </summary>
        public decimal IndiceRiesgo { get; set; }

        /// <summary>
        /// Obtiene o establece la clasificación del riesgo de morosidad,
        /// por ejemplo: Bajo, Medio, Alto o Crítico.
        /// </summary>
        public string Clasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el porcentaje de penalización correspondiente
        /// al nivel de morosidad.
        /// </summary>
        public decimal PorcentajePenalizacion { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si las reservas de áreas
        /// comunes se encuentran suspendidas.
        /// </summary>
        public bool ReservasSuspendidas { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de vencimiento más antigua
        /// entre las facturas pendientes.
        /// </summary>
        public DateTime FechaVencimientoMasAntigua { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se calculó el indicador
        /// de morosidad.
        /// </summary>
        public DateTime FechaCalculo { get; set; }
    }
}