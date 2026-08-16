using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DTO;
using Interfaces;

namespace BLL
{
    /// Contiene las validaciones y reglas de negocio
    /// correspondientes al módulo de reportes.
    public class ReporteBLL
    {
        private readonly IReporteDAL reporteDAL;

        public ReporteBLL()
        {
            reporteDAL = new ReporteDAO();
        }

        // ============================================================
        // REPORTE DE PROPIEDADES
        // ============================================================

        /// Obtiene todas las propiedades o las propiedades
        /// correspondientes a un propietario específico.
        public List<ReportePropiedadDTO> ObtenerPropiedades(
            int? idPropietario = null)
        {
            if (idPropietario.HasValue &&
                idPropietario.Value <= 0)
            {
                throw new ArgumentException(
                    "El propietario seleccionado no es válido."
                );
            }

            return reporteDAL.ObtenerPropiedades(idPropietario);
        }

        // ============================================================
        // REPORTE DE FACTURACIÓN POR PROPIEDAD
        // ============================================================

        /// Obtiene los cargos facturables de una propiedad.
        /// El rango de fechas es opcional.
        public List<ReporteFacturacionPropiedadDTO>
            ObtenerFacturacionPorPropiedad(
                int idPropiedad,
                DateTime? fechaInicio = null,
                DateTime? fechaFin = null)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar una propiedad válida."
                );
            }

            if (fechaInicio.HasValue &&
                fechaFin.HasValue &&
                fechaInicio.Value.Date > fechaFin.Value.Date)
            {
                throw new ArgumentException(
                    "La fecha inicial no puede ser posterior " +
                    "a la fecha final."
                );
            }

            return reporteDAL.ObtenerFacturacionPorPropiedad(
                idPropiedad,
                fechaInicio,
                fechaFin
            );
        }

        // ============================================================
        // REPORTE DE PROPIEDADES MOROSAS
        // ============================================================

        /// Obtiene todas las propiedades con al menos
        /// un cargo vencido y todavía no pagado.
        public List<ReporteMorosidadDTO>
            ObtenerPropiedadesMorosas()
        {
            return reporteDAL.ObtenerPropiedadesMorosas();
        }

        // ============================================================
        // REPORTE DE INGRESOS MENSUALES
        // ============================================================

        /// Obtiene el total facturado para cada mes
        /// del año indicado.
        public List<IngresoMensualDTO>
            ObtenerIngresosMensuales(int anio)
        {
            int anioActual = DateTime.Now.Year;

            if (anio < 2000 || anio > anioActual + 1)
            {
                throw new ArgumentException(
                    "El año seleccionado no es válido."
                );
            }

            return reporteDAL.ObtenerIngresosMensuales(anio);
        }

        // ============================================================
        // CÁLCULOS PARA LA INTERFAZ
        // ============================================================

        /// Suma las cuotas de las propiedades mostradas.
        public decimal CalcularTotalCuotas(
            List<ReportePropiedadDTO> propiedades)
        {
            if (propiedades == null)
                return 0;

            decimal total = 0;

            foreach (ReportePropiedadDTO propiedad in propiedades)
            {
                total += propiedad.CuotaMantenimiento;
            }

            return total;
        }

        /// Suma el monto adeudado por las propiedades morosas.
        public decimal CalcularTotalAdeudado(
            List<ReporteMorosidadDTO> propiedadesMorosas)
        {
            if (propiedadesMorosas == null)
                return 0;

            decimal total = 0;

            foreach (ReporteMorosidadDTO propiedad in propiedadesMorosas)
            {
                total += propiedad.MontoTotalAdeudado;
            }

            return total;
        }

        /// Obtiene la cantidad total de cargos vencidos.
        public int CalcularCantidadCargosVencidos(
            List<ReporteMorosidadDTO> propiedadesMorosas)
        {
            if (propiedadesMorosas == null)
                return 0;

            int total = 0;

            foreach (ReporteMorosidadDTO propiedad in propiedadesMorosas)
            {
                total += propiedad.CantidadCargosPendientes;
            }

            return total;
        }

        /// Suma el total facturado en colones durante el año.
        public decimal CalcularTotalAnualColones(
            List<IngresoMensualDTO> ingresos)
        {
            if (ingresos == null)
                return 0;

            decimal total = 0;

            foreach (IngresoMensualDTO ingreso in ingresos)
            {
                total += ingreso.TotalColones;
            }

            return total;
        }

        /// Suma el total facturado en dólares durante el año.
        public decimal CalcularTotalAnualDolares(
            List<IngresoMensualDTO> ingresos)
        {
            if (ingresos == null)
                return 0;

            decimal total = 0;

            foreach (IngresoMensualDTO ingreso in ingresos)
            {
                total += ingreso.TotalDolares;
            }

            return total;
        }
    }
}