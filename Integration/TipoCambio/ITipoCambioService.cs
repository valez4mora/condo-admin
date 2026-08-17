using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.TipoCambio
{
    public interface ITipoCambioService
    {
        TipoCambioResponseDTO ObtenerTipoCambio();

        decimal ConvertirColonesADolares(decimal colones);

        decimal ConvertirDolaresAColones(decimal dolares);
    }
}
