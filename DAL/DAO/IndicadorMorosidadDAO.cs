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
        private readonly Conexion conexion = Conexion.Instancia;

        public List<IndicadorMorosidad> RecalcularTodos(decimal tasaMensual)
        {
            return EjecutarLista("sp_RecalcularMorosidad", cmd =>
                cmd.Parameters.Add("@TasaMensual", SqlDbType.Decimal).Value = tasaMensual);
        }

        public List<IndicadorMorosidad> ObtenerTodos()
        {
            return EjecutarLista("sp_ObtenerIndicadoresMorosidad", null);
        }

        public int AplicarPenalizaciones()
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_AplicarPenalizacionesMorosidad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad)
        {
            List<IndicadorMorosidad> lista = EjecutarLista(
                "sp_ObtenerIndicadorPorPropiedad",
                cmd => cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = idPropiedad);

            return lista.Count == 0 ? null : lista[0];
        }

        private List<IndicadorMorosidad> EjecutarLista(
            string procedimiento,
            Action<SqlCommand> configurar)
        {
            List<IndicadorMorosidad> lista = new List<IndicadorMorosidad>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(procedimiento, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (configurar != null) configurar(cmd);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) lista.Add(Mapear(dr));
                }
            }
            return lista;
        }

        private static IndicadorMorosidad Mapear(SqlDataReader dr)
        {
            return new IndicadorMorosidad
            {
                IdIndicador = Convert.ToInt32(dr["IdIndicador"]),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                CodigoPropiedad = dr["CodigoPropiedad"].ToString(),
                NombrePropietario = dr["NombrePropietario"].ToString(),
                DiasMora = Convert.ToInt32(dr["DiasMora"]),
                MesesMora = Convert.ToInt32(dr["MesesMora"]),
                FacturasPendientes = Convert.ToInt32(dr["FacturasPendientes"]),
                MontoAdeudado = Convert.ToDecimal(dr["MontoAdeudado"]),
                TasaInteres = Convert.ToDecimal(dr["TasaInteres"]),
                InteresCalculado = Convert.ToDecimal(dr["InteresCalculado"]),
                IndiceRiesgo = Convert.ToDecimal(dr["IndiceRiesgo"]),
                Clasificacion = dr["Clasificacion"].ToString(),
                PorcentajePenalizacion = Convert.ToDecimal(dr["PorcentajePenalizacion"]),
                ReservasSuspendidas = Convert.ToBoolean(dr["ReservasSuspendidas"]),
                FechaVencimientoMasAntigua = Convert.ToDateTime(dr["FechaVencimientoMasAntigua"]),
                FechaCalculo = Convert.ToDateTime(dr["FechaCalculo"])
            };
        }
    }
}
