using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;

namespace BLL
{
    public class GestionFinancieraFacade
    {
        private readonly CargoFacturableBILL cargoBLL = new CargoFacturableBILL();
        private readonly FondoReservaBLL fondoReservaBLL = new FondoReservaBLL();
        private readonly IndicadorMorosidadBLL indicadorBLL = new IndicadorMorosidadBLL();

        // ---------- 1. Cuota de mantenimiento ----------
        public CargoFacturableDTO GenerarCuotaOrdinaria(PropiedadDTO propiedad)
        {
            // Reutiliza la lógica/validaciones ya existentes en CargoFacturableBLL,
            // que internamente ya usa el Factory.
            return cargoBLL.GenerarCuotaOrdinaria(propiedad);
        }

        // ---------- 2. Fondo de reserva ----------
        public CargoFacturableDTO GenerarFondoReserva(PropiedadDTO propiedad, decimal montoCuota)
        {
            if (propiedad == null)
                throw new Exception("Debe indicar una propiedad válida.");

            CargoFacturableDTO cargoFondo = GestionFinancieraFactory.CrearFondoReserva(propiedad.IdPropiedad, montoCuota);

            // Persiste también en la tabla FondoReserva (histórico) usando el BLL existente
            fondoReservaBLL.RegistrarFondo(propiedad);

            return cargoFondo;
        }

        // ---------- 3. Interés por mora ----------
        public CargoFacturableDTO CalcularInteresMora(int idPropiedad, decimal saldo, decimal tasa, int meses)
        {
            return GestionFinancieraFactory.CrearInteresMora(idPropiedad, saldo, tasa, meses);
        }

        // ---------- 4. Penalización ----------
        public CargoFacturableDTO AplicarPenalizacion(int idPropiedad, int diasAtraso, decimal montoBase)
        {
            return GestionFinancieraFactory.CrearPenalizacion(idPropiedad, diasAtraso, montoBase);
        }

        // ---------- 5. Índice de riesgo ----------
        public IndicadorMorosidadDTO CalcularIndiceRiesgo(int idPropiedad, int mesesMora, int facturasPendientes,
                                                            decimal montoAdeudado, decimal tasaInteres)
        {
            IndicadorMorosidadDTO indicador = new IndicadorMorosidadDTO
            {
                IdPropiedad = idPropiedad,
                MesesMora = mesesMora,
                FacturasPendientes = facturasPendientes,
                MontoAdeudado = montoAdeudado,
                TasaInteres = tasaInteres,
                Clasificacion = GestionFinancieraFactory.ClasificarRiesgo(mesesMora),
                FechaCalculo = DateTime.Now
            };

            // Persiste usando el BLL existente (calcula el interés y guarda)
            indicadorBLL.RegistrarMorosidad(indicador);

            return indicador;
        }

        // ---------- 6. Proceso completo: Generar factura mensual ----------
        // Encadena todo el proceso financiero
        // en una sola llamada para que la UI no tenga que orquestar nada.
        public CargoFacturableDTO GenerarFacturaMensual(PropiedadDTO propiedad, int diasAtraso = 0)
        {
            if (propiedad == null)
                throw new Exception("Debe indicar una propiedad válida.");

            // 1. Cuota de mantenimiento
            CargoFacturableDTO cuota = GenerarCuotaOrdinaria(propiedad);

            // 2. Fondo de reserva (sobre la cuota recién generada)
            GenerarFondoReserva(propiedad, cuota.Total);

            // 3. Si hay atraso, calcular interés y penalización
            if (diasAtraso > 0)
            {
                int mesesMora = diasAtraso / 30;
                CalcularInteresMora(propiedad.IdPropiedad, cuota.Total, 0.02m, mesesMora);
                AplicarPenalizacion(propiedad.IdPropiedad, diasAtraso, cuota.Total);

                // 4. Índice de riesgo
                CalcularIndiceRiesgo(propiedad.IdPropiedad, mesesMora, 1, cuota.Total, 0.02m);
            }

            // La cuota es el cargo principal que se le muestra al usuario en pantalla
            return cuota;
        }
    }
}
