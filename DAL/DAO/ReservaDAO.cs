
using DAL.DAO;
using DAL.Singleton;
using DTO;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DAL.DAO
{
    public class ReservaDAO : IReservaDAL
    {

        private readonly Conexion _conexion = Conexion.Instancia;

        //insertar,store procedure 
        public bool Insertar(ReservaDTO reserva)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarReserva", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Fecha", reserva.Fecha);
                    cmd.Parameters.AddWithValue("@HoraInicio", reserva.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", reserva.HoraFin);
                    cmd.Parameters.AddWithValue("@CantidadPersonas", reserva.CantidadPersonas);
                    cmd.Parameters.AddWithValue("@Estado", reserva.Estado);
                    cmd.Parameters.AddWithValue("@MotivoCancelacion", (object)reserva.MotivoCancelacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdArea", reserva.IdArea);
                    cmd.Parameters.AddWithValue("@IdPropiedad", reserva.IdPropiedad);
                    cmd.Parameters.AddWithValue("@IdResidente", reserva.IdResidente);


                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        //cambiar estado 
        public bool CambiarEstado(int idReserva, string estado, string motivo)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CambiarEstadoReserva", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdReserva", idReserva);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@MotivoCancelacion", (object)motivo ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
        }


        //obtener todas las reservas 
        public List<ReservaDTO> ObtenerTodas()
        {
            List<ReservaDTO> lista = new List<ReservaDTO>();

            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerReservas", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(MapearFila(dr));
                        }
                    }
                }
                return lista;
            }
        }


        //obtener por propiedad 
        public List<ReservaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            List<ReservaDTO> lista = new List<ReservaDTO>();

            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerReservasPorPropiedad", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            lista.Add(MapearFila(dr));
                    }
                }
            }

            return lista;

        }


        //obtener por id 
        public ReservaDTO ObtenerPorId(int idReserva)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerReservaPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdReserva", idReserva);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return MapearFila(dr);
                    }
                }
            }
            return null;
        }


        //verificar bloqueo de mantenimiento 
        public bool VerificarBloqueoMantenimiento(int idArea, DateTime fecha)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_VerificarBloqueoMantenimiento", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdArea", idArea);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    return resultado > 0; 
                }
            }
        }

        //verificar morosidad 
        public int ObtenerMesesMoraPropiedad(int idPropiedad)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_VerificarMorosidadPropiedad", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return Convert.ToInt32(dr["MesesMora"]);
                    }
                }
            }
            return 0; // sin mora registrada
        }


        //mapaer fila 

        private ReservaDTO MapearFila(SqlDataReader dr)
        {
            return new ReservaDTO
            {
                IdReserva = Convert.ToInt32(dr["IdReserva"]),
                Fecha = Convert.ToDateTime(dr["Fecha"]),
                HoraInicio = (TimeSpan)dr["HoraInicio"],
                HoraFin = (TimeSpan)dr["HoraFin"],
                CantidadPersonas = Convert.ToInt32(dr["CantidadPersonas"]),
                Estado = dr["Estado"].ToString(),
                MotivoCancelacion = dr["MotivoCancelacion"] == DBNull.Value
                ? string.Empty
                : dr["MotivoCancelacion"].ToString(),
                IdArea = Convert.ToInt32(dr["IdArea"]),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                IdResidente = Convert.ToInt32(dr["IdResidente"]),
                // Columnas del JOIN 
                AreaComun = dr["AreaComun"] != DBNull.Value ? dr["AreaComun"].ToString() : string.Empty,
                Tarifa = dr["Tarifa"] != DBNull.Value ? Convert.ToDecimal(dr["Tarifa"]) : 0,
                CodigoPropiedad = dr["CodigoPropiedad"] != DBNull.Value ? dr["CodigoPropiedad"].ToString() : string.Empty,
                NombreResidente = dr["NombreResidente"] != DBNull.Value ? dr["NombreResidente"].ToString() : string.Empty
            };
        }
    }
}
