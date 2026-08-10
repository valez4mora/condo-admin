using DAL.DAO;
using DTO;
using Entities;
using System;

namespace BLL
{
 
    public class IndicadorMorosidadBLL
    {
        private readonly IndicadorMorosidadDAO dal = new IndicadorMorosidadDAO();

       
        //calcula el índice de riesgo de morosidad para una propiedad
        public IndicadorMorosidadDTO CalcularIndicador(IndicadorMorosidadDTO indicador)
        {
            if (indicador == null)
                throw new ArgumentNullException( "Los datos del indicador no pueden ser nulos.");

            if (indicador.IdPropiedad <= 0)
                throw new ArgumentException("Debe indicar una propiedad válida.");

            // aplicar fórmula
            decimal indice = (indicador.MesesMora * 0.5m)
                           + (indicador.FacturasPendientes * 0.3m)
                           + (indicador.MontoAdeudado / 100000m * 0.2m);

            indicador.IndiceRiesgo = Math.Round(indice, 2);
            indicador.FechaCalculo = DateTime.Now;

     
            if (indice <= 2.9m)
                indicador.Clasificacion = "Bajo";
            else if (indice <= 5.9m)
                indicador.Clasificacion = "Medio";
            else if (indice <= 8.9m)
                indicador.Clasificacion = "Alto";
            else
                indicador.Clasificacion = "Critico";

            
            IndicadorMorosidad entidad = new IndicadorMorosidad
            {
                IdPropiedad = indicador.IdPropiedad,
                MesesMora = indicador.MesesMora,
                FacturasPendientes = indicador.FacturasPendientes,
                MontoAdeudado = indicador.MontoAdeudado,
                IndiceRiesgo = indicador.IndiceRiesgo,
                Clasificacion = indicador.Clasificacion,
                FechaCalculo = indicador.FechaCalculo
            };

            dal.Insertar(entidad);

            return indicador;
        }

        public void EliminarPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0)
                throw new ArgumentException("Debe indicar una propiedad válida.");

            bool eliminado = dal.Eliminar(idPropiedad);

            if (!eliminado)
                throw new Exception("No se encontró un indicador de morosidad para la propiedad seleccionada.");
        }

        public IndicadorMorosidadDTO ActualizarIndicador(IndicadorMorosidadDTO indicador)
        {
            if (indicador == null)
                throw new ArgumentNullException("Los datos del indicador no pueden ser nulos.");

            if (indicador.IdPropiedad <= 0)
                throw new ArgumentException("Debe indicar una propiedad válida.");

            // Reutiliza la misma fórmula de CalcularIndicador
            decimal indice = (indicador.MesesMora * 0.5m)
                           + (indicador.FacturasPendientes * 0.3m)
                           + (indicador.MontoAdeudado / 100000m * 0.2m);

            indicador.IndiceRiesgo = Math.Round(indice, 2);
            indicador.FechaCalculo = DateTime.Now;

            if (indice <= 2.9m)
                indicador.Clasificacion = "Bajo";
            else if (indice <= 5.9m)
                indicador.Clasificacion = "Medio";
            else if (indice <= 8.9m)
                indicador.Clasificacion = "Alto";
            else
                indicador.Clasificacion = "Critico";

            IndicadorMorosidad entidad = new IndicadorMorosidad
            {
                IdPropiedad = indicador.IdPropiedad,
                MesesMora = indicador.MesesMora,
                FacturasPendientes = indicador.FacturasPendientes,
                MontoAdeudado = indicador.MontoAdeudado,
                IndiceRiesgo = indicador.IndiceRiesgo,
                Clasificacion = indicador.Clasificacion,
                FechaCalculo = indicador.FechaCalculo
            };

            bool actualizado = dal.Actualizar(entidad);

            if (!actualizado)
                throw new Exception("No se encontró un indicador existente para actualizar. Use Calcular/Registrar primero.");

            return indicador;
        }
    }
}