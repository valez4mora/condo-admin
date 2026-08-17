using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;
using Factory;

namespace Facade
{
    /// <summary>
    /// Proporciona un punto de acceso simplificado a las principales
    /// operaciones financieras del condominio.
    /// </summary>
    /// <remarks>
    /// Esta clase implementa el patrón Facade y coordina las clases de
    /// lógica de negocio y el Factory financiero. Permite generar cuotas,
    /// fondos de reserva, intereses, penalizaciones e indicadores de
    /// morosidad sin exponer su implementación interna a la interfaz.
    /// </remarks>
    public class GestionFinancieraFacade
    {
        /// <summary>
        /// Lógica de negocio encargada de administrar los cargos facturables.
        /// </summary>
        private readonly CargoFacturableBLL cargoBLL;

        /// <summary>
        /// Lógica de negocio encargada de administrar el fondo de reserva.
        /// </summary>
        private readonly FondoReservaBLL fondoReservaBLL;

        /// <summary>
        /// Lógica de negocio encargada de calcular y administrar
        /// los indicadores de morosidad.
        /// </summary>
        private readonly IndicadorMorosidadBLL indicadorBLL;

        /// <summary>
        /// Lógica de negocio encargada de generar las penalizaciones.
        /// </summary>
        private readonly PenalizacionBLL penalizacionBLL;

        /// <summary>
        /// Inicializa la fachada y las clases de lógica de negocio
        /// necesarias para ejecutar las operaciones financieras.
        /// </summary>
        public GestionFinancieraFacade()
        {
            cargoBLL = new CargoFacturableBLL();
            fondoReservaBLL = new FondoReservaBLL();
            indicadorBLL = new IndicadorMorosidadBLL();
            penalizacionBLL = new PenalizacionBLL();
        }

        // 1. CUOTA DE MANTENIMIENTO

        /// <summary>
        /// Genera y registra la cuota ordinaria de mantenimiento
        /// correspondiente a una propiedad.
        /// </summary>
        /// <param name="propiedad">
        /// Propiedad para la cual se generará la cuota de mantenimiento.
        /// </param>
        /// <returns>
        /// Cargo facturable generado y registrado.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando la propiedad recibida es nula.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el identificador de la propiedad no es válido.
        /// </exception>
        public CargoFacturableDTO GenerarCuotaOrdinaria(
            PropiedadDTO propiedad)
        {
            if (propiedad == null)
            {
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");
            }

            if (propiedad.IdPropiedad <= 0)
            {
                throw new ArgumentException(
                    "La propiedad indicada no es válida.",
                    nameof(propiedad));
            }

            return cargoBLL.GenerarCuotaOrdinaria(propiedad);
        }

        // 2. FONDO DE RESERVA

        /// <summary>
        /// Calcula el aporte al fondo de reserva y registra
        /// el movimiento histórico correspondiente.
        /// </summary>
        /// <param name="propiedad">
        /// Propiedad a la que pertenece el aporte al fondo de reserva.
        /// </param>
        /// <param name="montoCuota">
        /// Monto de la cuota utilizado como base para calcular el aporte.
        /// </param>
        /// <returns>
        /// Cargo facturable correspondiente al fondo de reserva.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando la propiedad recibida es nula.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Se produce cuando la propiedad no es válida o el monto de
        /// la cuota no es mayor que cero.
        /// </exception>
        public CargoFacturableDTO GenerarFondoReserva(
            PropiedadDTO propiedad,
            decimal montoCuota)
        {
            if (propiedad == null)
            {
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");
            }

            if (propiedad.IdPropiedad <= 0)
            {
                throw new ArgumentException(
                    "La propiedad indicada no es válida.",
                    nameof(propiedad));
            }

            if (montoCuota <= 0)
            {
                throw new ArgumentException(
                    "El monto de la cuota debe ser mayor que cero.",
                    nameof(montoCuota));
            }

            CargoFacturableDTO fondo =
                GestionFinancieraFactory.CrearFondoReserva(
                    propiedad.IdPropiedad,
                    montoCuota);

            fondoReservaBLL.RegistrarFondo(
                propiedad,
                montoCuota);

            return fondo;
        }

        // 3. INTERÉS POR MORA

        /// <summary>
        /// Calcula y registra un cargo correspondiente al interés
        /// generado por morosidad.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad que mantiene la deuda.
        /// </param>
        /// <param name="saldoPendiente">
        /// Saldo pendiente sobre el que se calculará el interés.
        /// </param>
        /// <param name="tasaMensual">
        /// Tasa de interés mensual que se aplicará al saldo.
        /// </param>
        /// <param name="mesesMora">
        /// Cantidad de meses de atraso de la propiedad.
        /// </param>
        /// <returns>
        /// Cargo facturable correspondiente al interés por mora.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el identificador, el saldo, la tasa o
        /// la cantidad de meses no contienen valores válidos.
        /// </exception>
        public CargoFacturableDTO GenerarInteresMora(
            int idPropiedad,
            decimal saldoPendiente,
            decimal tasaMensual,
            int mesesMora)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException(
                    "Debe indicar una propiedad válida.",
                    nameof(idPropiedad));
            }

            if (saldoPendiente <= 0)
            {
                throw new ArgumentException(
                    "El saldo pendiente debe ser mayor que cero.",
                    nameof(saldoPendiente));
            }

            if (tasaMensual <= 0)
            {
                throw new ArgumentException(
                    "La tasa mensual debe ser mayor que cero.",
                    nameof(tasaMensual));
            }

            if (mesesMora <= 0)
            {
                throw new ArgumentException(
                    "Los meses de mora deben ser mayores que cero.",
                    nameof(mesesMora));
            }

            CargoFacturableDTO interes =
                GestionFinancieraFactory.CrearInteresMora(
                    idPropiedad,
                    saldoPendiente,
                    tasaMensual,
                    mesesMora);

            return cargoBLL.RegistrarManual(interes);
        }

        // 4. PENALIZACIÓN INDIVIDUAL POR MORA

        /// <summary>
        /// Aplica la penalización correspondiente a una propiedad
        /// según la antigüedad de su deuda.
        /// </summary>
        /// <param name="propiedad">
        /// Propiedad a la que se aplicará la penalización.
        /// </param>
        /// <returns>
        /// Cargo facturable generado por concepto de penalización.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando la propiedad recibida es nula.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el identificador de la propiedad no es válido.
        /// </exception>
        public CargoFacturableDTO AplicarPenalizacion(
            PropiedadDTO propiedad)
        {
            if (propiedad == null)
            {
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");
            }

            if (propiedad.IdPropiedad <= 0)
            {
                throw new ArgumentException(
                    "La propiedad indicada no es válida.",
                    nameof(propiedad));
            }

            return penalizacionBLL.AplicarPenalizacion(propiedad);
        }

        // 5. INDICADOR DE MOROSIDAD

        /// <summary>
        /// Calcula y registra el indicador de riesgo financiero
        /// correspondiente a una propiedad.
        /// </summary>
        /// <param name="indicador">
        /// Información necesaria para calcular el indicador de morosidad.
        /// </param>
        /// <returns>
        /// Indicador de morosidad calculado y registrado.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce cuando los datos del indicador son nulos.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Se produce cuando el identificador de la propiedad no es válido.
        /// </exception>
        public IndicadorMorosidadDTO CalcularIndicadorMorosidad(
            IndicadorMorosidadDTO indicador)
        {
            if (indicador == null)
            {
                throw new ArgumentNullException(
                    nameof(indicador),
                    "Debe indicar los datos de morosidad.");
            }

            if (indicador.IdPropiedad <= 0)
            {
                throw new ArgumentException(
                    "La propiedad indicada no es válida.",
                    nameof(indicador));
            }

            return indicadorBLL.CalcularIndicador(indicador);
        }

        // 6. PENALIZACIONES MASIVAS POR MOROSIDAD

        /// <summary>
        /// Aplica las penalizaciones correspondientes a todas las
        /// propiedades que cumplen las condiciones de morosidad.
        /// </summary>
        /// <returns>
        /// Cantidad de penalizaciones procesadas y registradas.
        /// </returns>
        public int AplicarPenalizacionesMorosas()
        {
            return indicadorBLL.AplicarPenalizaciones();
        }
    }
}