using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Enumeraciones
{
    /// <summary>
    /// Clasificación de los cargos facturables del condominio.
    /// </summary>
    public enum TipoCargo
    {
        CuotaMantenimiento,
        Multa,
        CuotaExtraordinaria,
        Reserva,
        Penalizacion,
        FondoReserva,
        InteresMora
    }
}