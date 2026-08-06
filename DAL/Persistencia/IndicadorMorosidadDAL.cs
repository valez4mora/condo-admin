using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;

namespace DAL.Persistencia
{
        public class IndicadorMorosidadDAL : IIndicadorMorosidadDAL
        {
            Conexion conexion = Conexion.Instancia;

            public void Insertar(IndicadorMorosidad indicador)
            {
                SqlConnection cn = conexion.ObtenerConexion();

                string sql = @"INSERT INTO IndicadorMorosidad
            (
                IdPropiedad,
                MesesMora,
                FacturasPendientes,
                MontoAdeudado,
                TasaInteres,
                InteresCalculado,
                IndiceRiesgo,
                Clasificacion,
                FechaCalculo
            )
            VALUES
            (
                @IdPropiedad,
                @MesesMora,
                @FacturasPendientes,
                @MontoAdeudado,
                @TasaInteres,
                @InteresCalculado,
                @IndiceRiesgo,
                @Clasificacion,
                @FechaCalculo
            )";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdPropiedad", indicador.IdPropiedad);
                cmd.Parameters.AddWithValue("@MesesMora", indicador.MesesMora);
                cmd.Parameters.AddWithValue("@FacturasPendientes", indicador.FacturasPendientes);
                cmd.Parameters.AddWithValue("@MontoAdeudado", indicador.MontoAdeudado);
                cmd.Parameters.AddWithValue("@TasaInteres", indicador.TasaInteres);
                cmd.Parameters.AddWithValue("@InteresCalculado", indicador.InteresCalculado);
                cmd.Parameters.AddWithValue("@IndiceRiesgo", indicador.IndiceRiesgo);
                cmd.Parameters.AddWithValue("@Clasificacion", indicador.Clasificacion);
                cmd.Parameters.AddWithValue("@FechaCalculo", indicador.FechaCalculo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            public List<IndicadorMorosidad> ObtenerTodos()
            {
                return new List<IndicadorMorosidad>();
            }

            public IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad)
            {
                return null;
            }
        
    }
}
