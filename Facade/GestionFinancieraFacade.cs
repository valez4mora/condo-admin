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
    /// Fachada para las principales operaciones financieras del condominio.
    /// Centraliza el acceso a cuotas de mantenimiento, fondo de reserva,
    /// intereses por mora, penalizaciones e indicador de morosidad.

    /// La fachada no contiene las reglas de negocio:
    /// delega los cálculos y validaciones a las clases BLL y al Factory.
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
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");

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
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");

            if (propiedad.IdPropiedad <= 0)
                throw new ArgumentException(
                    "La propiedad indicada no es válida.");

            if (montoCuota <= 0)
                throw new ArgumentException(
                    "El monto de la cuota debe ser mayor que cero.");

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
                throw new ArgumentException(
                    "Debe indicar una propiedad válida.");

            if (saldoPendiente <= 0)
                throw new ArgumentException(
                    "El saldo pendiente debe ser mayor que cero.");

            if (tasaMensual <= 0)
                throw new ArgumentException(
                    "La tasa mensual debe ser mayor que cero.");

            if (mesesMora <= 0)
                throw new ArgumentException(
                    "Los meses de mora deben ser mayores que cero.");

            CargoFacturableDTO interes =
                GestionFinancieraFactory.CrearInteresMora(
                    idPropiedad,
                    saldoPendiente,
                    tasaMensual,
                    mesesMora);

            return cargoBLL.RegistrarManual(interes);
        }

        // 4. PENALIZACIÓN POR MORA

        /// Aplica automáticamente la penalización correspondiente
        /// según la antigüedad de la deuda de una propiedad.
        public CargoFacturableDTO AplicarPenalizacion(
            PropiedadDTO propiedad)
        {
            if (propiedad == null)
                throw new ArgumentNullException(
                    nameof(propiedad),
                    "Debe indicar una propiedad válida.");

            if (propiedad.IdPropiedad <= 0)
                throw new ArgumentException(
                    "La propiedad indicada no es válida.");

            return penalizacionBLL.AplicarPenalizacion(propiedad);
        }


        // 5. INDICADOR DE MOROSIDAD

        /// Calcula y registra el indicador de riesgo financiero
        /// correspondiente a una propiedad.
        public IndicadorMorosidadDTO CalcularIndicadorMorosidad(
            IndicadorMorosidadDTO indicador)
        {
            if (indicador == null)
                throw new ArgumentNullException(
                    nameof(indicador),
                    "Debe indicar los datos de morosidad.");

            return indicadorBLL.CalcularIndicador(indicador);
        }
    }
}