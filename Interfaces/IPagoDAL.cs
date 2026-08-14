using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IPagoDAL
    {
        bool Registrar(PagoDTO pago);

        List<PagoDTO> ObtenerTodos();

        List<PagoDTO> ObtenerPorFactura(int idFactura);

        bool Modificar(PagoDTO pago);

        bool Eliminar(int idPago);
    }
}

