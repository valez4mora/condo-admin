using DAL.Singleton;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    /// <summary>
    /// Proporciona las operaciones de acceso a datos relacionadas con los
    /// indicadores de morosidad de las propiedades del condominio.
    /// </summary>
    /// <remarks>
    /// Esta clase implementa <see cref="IIndicadorMorosidadDAL"/> y utiliza
    /// procedimientos almacenados para consultar, recalcular y aplicar
    /// penalizaciones por morosidad.
    /// </remarks>
    public class IndicadorMorosidadDAO : IIndicadorMorosidadDAL
    {
        /// <summary>
        /// Instancia única utilizada para obtener conexiones con la base de datos.
        /// </summary>
        private readonly Conexion conexion = Conexion.Instancia;

        /// <summary>
        /// Recalcula los indicadores de morosidad de todas las propiedades
        /// utilizando la tasa mensual indicada.
        /// </summary>
        /// <param name="tasaMensual">
        /// Tasa de interés mensual que se utilizará para calcular la morosidad.
        /// </param>
        /// <returns>
        /// Lista con los indicadores de morosidad recalculados.
        /// </returns>
        public List<IndicadorMorosidad> RecalcularTodos(decimal tasaMensual)
        {
            return EjecutarLista("sp_RecalcularMorosidad", cmd =>
                cmd.Parameters.Add("@TasaMensual", SqlDbType.Decimal).Value = tasaMensual);
        }

        /// <summary>
        /// Obtiene todos los indicadores de morosidad registrados.
        /// </summary>
        /// <returns>
        /// Lista con los indicadores de morosidad de las propiedades.
        /// </returns>
        public List<IndicadorMorosidad> ObtenerTodos()
        {
            return EjecutarLista("sp_ObtenerIndicadoresMorosidad", null);
        }

        /// <summary>
        /// Aplica las penalizaciones correspondientes a las propiedades
        /// que cumplen las condiciones de morosidad.
        /// </summary>
        /// <returns>
        /// Cantidad de penalizaciones registradas por el procedimiento almacenado.
        /// </returns>
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

        /// <summary>
        /// Obtiene el indicador de morosidad correspondiente a una propiedad.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad que se desea consultar.
        /// </param>
        /// <returns>
        /// Indicador de morosidad encontrado o <c>null</c> si la propiedad
        /// no tiene un indicador registrado.
        /// </returns>
        public IndicadorMorosidad ObtenerPorPropiedad(int idPropiedad)
        {
            List<IndicadorMorosidad> lista = EjecutarLista(
                "sp_ObtenerIndicadorPorPropiedad",
                cmd => cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = idPropiedad);

            return lista.Count == 0 ? null : lista[0];
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado que devuelve una lista de
        /// indicadores de morosidad.
        /// </summary>
        /// <param name="procedimiento">
        /// Nombre del procedimiento almacenado que se ejecutará.
        /// </param>
        /// <param name="configurar">
        /// Acción opcional utilizada para agregar parámetros al comando SQL.
        /// </param>
        /// <returns>
        /// Lista de indicadores obtenidos desde la base de datos.
        /// </returns>
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

        /// <summary>
        /// Convierte la fila actual de un lector SQL en una entidad
        /// <see cref="IndicadorMorosidad"/>.
        /// </summary>
        /// <param name="dr">
        /// Lector SQL posicionado en el registro que se desea convertir.
        /// </param>
        /// <returns>
        /// Entidad de morosidad con los valores obtenidos de la base de datos.
        /// </returns>
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