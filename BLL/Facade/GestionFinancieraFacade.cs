using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //------------ 4. Indicador de morosidad ----------
        public void CrearPenalizacion(CargoFacturableDTO idPropiedad, decimal monto, string descripcion)
        {

        }

    }
}
