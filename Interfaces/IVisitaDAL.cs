using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public  interface IVisitaDAL
    {
        //registrar visita y retorna el id que se va a generar por la bd
        int Registrar(VisitaDTO visita);

        // actualizar el codigo QR cuando este generado
        bool ActualizarQR(int idVisita, string CodigoQR);

        //registrar la hora de salida del visitante 
        bool RegistrarSalida(int idVisita, TimeSpan horaSalida);

        //visitas con filtros opcionales para el historial
        List<VisitaDTO> ObtenerPorFiltros(int? idPropiedad, DateTime? fecha, string estado);

     

        //buscar visita por su codigo QR para validar acceso
        VisitaDTO ObtenerPorQR(string codigoQR);

        VisitaDTO ObtenerPorId(int idVisita);




    }
}
