using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ReporteDAO : IReporteDAL
    {
        public List<ReportePropiedadDTO> ObtenerPropiedades(
            int? idPropietario)
        {
            // sp_ReportePropiedades
        }

        public List<ReporteFacturacionPropiedadDTO>
            ObtenerFacturacionPorPropiedad(
                int idPropiedad,
                DateTime? fechaInicio,
                DateTime? fechaFin)
        {
            // sp_ReporteFacturacionPorPropiedad
        }

        public List<ReporteMorosidadDTO>
            ObtenerPropiedadesMorosas()
        {
            // sp_ReportePropiedadesMorosas
        }

        public List<IngresoMensualDTO>
            ObtenerIngresosMensuales(int anio)
        {
            // sp_ReporteIngresosMensuales
        }
    }
}
