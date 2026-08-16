using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IReporteDAL
    {
        List<ReportePropiedadDTO> ObtenerPropiedades(
            int? idPropietario);

        List<ReporteFacturacionPropiedadDTO> ObtenerFacturacionPorPropiedad(
            int idPropiedad,
            DateTime? fechaInicio,
            DateTime? fechaFin);

        List<ReporteMorosidadDTO> ObtenerPropiedadesMorosas();

        List<IngresoMensualDTO> ObtenerIngresosMensuales(int anio);
    }
}
