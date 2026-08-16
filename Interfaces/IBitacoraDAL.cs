using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBitacoraDAL
    {
        bool Registrar(BitacoraDTO entrada);
        List<BitacoraDTO> ObtenerTodas();
        List<BitacoraDTO> ObtenerPorFecha(DateTime desde, DateTime hasta);
    }
}

