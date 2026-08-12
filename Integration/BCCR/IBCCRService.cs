using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.BCCR
{
    public interface IBCCRService
    {
        BCCRResponseDTO ObtenerTipoCambioVenta();

        decimal ConvertirColonesADolares(decimal colones);

        decimal ConvertirDolaresAColones(decimal dolares);
    }
}