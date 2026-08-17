using DAL.DAO;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class IndicadorMorosidadBLL
    {
        private readonly IndicadorMorosidadDAO dal = new IndicadorMorosidadDAO();

        public List<IndicadorMorosidadDTO> RecalcularTodos(decimal tasaMensual)
        {
            if (tasaMensual < 0 || tasaMensual > 100)
                throw new ArgumentException("La tasa mensual debe estar entre 0 y 100.");

            return dal.RecalcularTodos(tasaMensual).Select(Convertir).ToList();
        }

        public List<IndicadorMorosidadDTO> ObtenerTodos()
        {
            return dal.ObtenerTodos().Select(Convertir).ToList();
        }

        public int AplicarPenalizaciones()
        {
            return dal.AplicarPenalizaciones();
        }

        public IndicadorMorosidadDTO CalcularIndicador(IndicadorMorosidadDTO indicador)
        {
            if (indicador == null || indicador.IdPropiedad <= 0)
                throw new ArgumentException("Debe indicar una propiedad válida.");

            IndicadorMorosidadDTO resultado = RecalcularTodos(2.00m)
                .FirstOrDefault(x => x.IdPropiedad == indicador.IdPropiedad);

            if (resultado == null)
                throw new Exception("La propiedad no tiene cargos vencidos con saldo pendiente.");

            return resultado;
        }

        public IndicadorMorosidadDTO ObtenerPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0) throw new ArgumentException("Propiedad no válida.");
            IndicadorMorosidad entidad = dal.ObtenerPorPropiedad(idPropiedad);
            return entidad == null ? null : Convertir(entidad);
        }

        private static IndicadorMorosidadDTO Convertir(IndicadorMorosidad x)
        {
            return new IndicadorMorosidadDTO
            {
                IdIndicador = x.IdIndicador,
                IdPropiedad = x.IdPropiedad,
                CodigoPropiedad = x.CodigoPropiedad,
                NombrePropietario = x.NombrePropietario,
                DiasMora = x.DiasMora,
                MesesMora = x.MesesMora,
                FacturasPendientes = x.FacturasPendientes,
                MontoAdeudado = x.MontoAdeudado,
                TasaInteres = x.TasaInteres,
                InteresCalculado = x.InteresCalculado,
                IndiceRiesgo = x.IndiceRiesgo,
                Clasificacion = x.Clasificacion,
                PorcentajePenalizacion = x.PorcentajePenalizacion,
                ReservasSuspendidas = x.ReservasSuspendidas,
                FechaVencimientoMasAntigua = x.FechaVencimientoMasAntigua,
                FechaCalculo = x.FechaCalculo
            };
        }
    }
}
