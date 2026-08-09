using DAL.DAO;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IndicadorMorosidadBLL
    {
        private readonly IndicadorMorosidadDAO dal = new IndicadorMorosidadDAO();

        public void RegistrarMorosidad(IndicadorMorosidadDTO dto)
        {
            decimal interes = dto.MontoAdeudado *
                              (dto.TasaInteres / 100m) *
                              dto.MesesMora;

            IndicadorMorosidad indicador = new IndicadorMorosidad
            {
                IdPropiedad = dto.IdPropiedad,
                MesesMora = dto.MesesMora,
                FacturasPendientes = dto.FacturasPendientes,
                MontoAdeudado = dto.MontoAdeudado,
                TasaInteres = dto.TasaInteres,
                InteresCalculado = interes,
                FechaCalculo = DateTime.Now
            };

            if (dto.MesesMora == 0)
            {
                indicador.Clasificacion = "Bajo";
                indicador.IndiceRiesgo = 0;
            }
            else if (dto.MesesMora <= 2)
            {
                indicador.Clasificacion = "Medio";
                indicador.IndiceRiesgo = 50;
            }
            else
            {
                indicador.Clasificacion = "Alto";
                indicador.IndiceRiesgo = 100;
            }

            dal.Insertar(indicador);
        }
    }
}
