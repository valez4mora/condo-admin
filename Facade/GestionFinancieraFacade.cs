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
    public class GestionFinancieraFacade
    {
        private readonly CargoFacturableBLL cargoBLL;
        private readonly FondoReservaBLL fondoReservaBLL;
        private readonly IndicadorMorosidadBLL indicadorBLL;
        private readonly PenalizacionBLL penalizacionBLL;

        public GestionFinancieraFacade()
        {
            cargoBLL = new CargoFacturableBLL();
            fondoReservaBLL = new FondoReservaBLL();
            indicadorBLL = new IndicadorMorosidadBLL();
            penalizacionBLL = new PenalizacionBLL();
        }

        // 1. CUOTA DE MANTENIMIENTO

        /// Genera y registra la cuota ordinaria de mantenimiento
        /// correspondiente a una propiedad.

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


        /// Calcula el aporte al fondo de reserva y registra
        /// el movimiento histórico correspondiente.

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


        /// Calcula y registra un cargo correspondiente al interés
        /// generado por morosidad.

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

        /// Aplica la penalización correspondiente a una propiedad
        /// según la antigüedad de su deuda.
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

        /// Calcula y registra el indicador de riesgo financiero
        /// correspondiente a una propiedad.
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

        /// Aplica las penalizaciones correspondientes a todas las
        /// propiedades que cumplen las condiciones de morosidad.
        /// Devuelve la cantidad de penalizaciones procesadas.
        public int AplicarPenalizacionesMorosas()
        {
            return indicadorBLL.AplicarPenalizaciones();
        }
    }
}