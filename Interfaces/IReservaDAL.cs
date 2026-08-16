using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IReservaDAL
    {

        bool Insertar(ReservaDTO reserva);
        bool CambiarEstado(int idReserva, string estado, string motivo);
        List<ReservaDTO> ObtenerTodas();
        List<ReservaDTO> ObtenerPorPropiedad(int idPropiedad);
        ReservaDTO ObtenerPorId(int idReserva);
        bool VerificarBloqueoMantenimiento(int idArea, System.DateTime fecha);
        int ObtenerMesesMoraPropiedad(int idPropiedad);





    }
}
