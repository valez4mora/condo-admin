using DAL.Singleton;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
 
    public class IndicadorMorosidadDAO : IIndicadorMorosidadDAL
    {
        Conexion conexion = Conexion.Instancia;

   
        // inserta un indicador de morosidad calculado en la BD.
        //llama al stored procedure sp_RegistrarIndicadorMorosidad.
      
        public void Insertar(IndicadorMorosidad indicador)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_RegistrarIndicadorMorosidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPropiedad", indicador.IdPropiedad);
                cmd.Parameters.AddWithValue("@MesesMora", indicador.MesesMora);
                cmd.Parameters.AddWithValue("@FacturasPendientes", indicador.FacturasPendientes);
                cmd.Parameters.AddWithValue("@MontoAdeudado", indicador.MontoAdeudado);
                cmd.Parameters.AddWithValue("@IndiceRiesgo", indicador.IndiceRiesgo);
                cmd.Parameters.AddWithValue("@Clasificacion", indicador.Clasificacion);
                cmd.Parameters.AddWithValue("@FechaCalculo", indicador.FechaCalculo);

                cmd.ExecuteNonQuery();
            }
        }

   
        // obtiene todos los indicadores de morosidad del sistema
        public List<IndicadorMorosidad> ObtenerTodos()
        {
            List<IndicadorMorosidad> lista = new List<IndicadorMorosidad>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerIndicadoresMorosidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(Mapear(dr));
                }
            }

            return lista;
        }

        //obtiene el último indicador de morosidad de una propiedad
       
        public IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad)
        {
            IndicadorMorosidad indicador = null;

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerIndicadorPorPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    indicador = Mapear(dr);
                }
            }

            return indicador;
        }

     
        // convierte una fila del DataReader en un IndicadorMorosidad.
      
        private IndicadorMorosidad Mapear(SqlDataReader dr)
        {
            return new IndicadorMorosidad
            {
                IdIndicador = Convert.ToInt32(dr["IdIndicador"]),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                MesesMora = Convert.ToInt32(dr["MesesMora"]),
                FacturasPendientes = Convert.ToInt32(dr["FacturasPendientes"]),
                MontoAdeudado = Convert.ToDecimal(dr["MontoAdeudado"]),
                IndiceRiesgo = Convert.ToDecimal(dr["IndiceRiesgo"]),
                Clasificacion = dr["Clasificacion"].ToString(),
                FechaCalculo = Convert.ToDateTime(dr["FechaCalculo"])
            };
        }
    }
}