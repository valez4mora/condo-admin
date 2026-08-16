using DAL.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace DAL.DAO
{
    public class VisitaDAO : IVisitaDAL
    {
        private readonly Conexion conexion = Conexion.Instancia;

        // -------------------------------------------------------
        // Registra una nueva visita y devuelve el IdVisita creado
        // -------------------------------------------------------
        public int Registrar(VisitaDTO visita)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistrarVisita", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@NombreVisitante", visita.NombreVisitante);
                cmd.Parameters.AddWithValue("@Fecha", visita.Fecha.Date);
                cmd.Parameters.AddWithValue("@HoraEntrada", visita.HoraEntrada);
                cmd.Parameters.AddWithValue("@CodigoQR",
                    string.IsNullOrEmpty(visita.CodigoQR)
                    ? (object)DBNull.Value : visita.CodigoQR);
                cmd.Parameters.AddWithValue("@IdPropiedad", visita.IdPropiedad);

                object resultado = cmd.ExecuteScalar();
                return resultado != null && resultado != DBNull.Value
                       ? Convert.ToInt32(resultado) : 0;
            }
        }

        // -------------------------------------------------------
        // Actualiza el CodigoQR de una visita ya registrada
        // -------------------------------------------------------
        public bool ActualizarQR(int idVisita, string codigoQR)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ActualizarQRVisita", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdVisita", idVisita);
                cmd.Parameters.AddWithValue("@CodigoQR", codigoQR);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // -------------------------------------------------------
        // Registra la hora de salida de una visita
        // -------------------------------------------------------
        public bool RegistrarSalida(int idVisita, TimeSpan horaSalida)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistrarSalidaVisita", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdVisita", idVisita);
                cmd.Parameters.AddWithValue("@HoraSalida", horaSalida);


                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // -------------------------------------------------------
        // Obtiene visitas con filtros opcionales
        // -------------------------------------------------------
        public List<VisitaDTO> ObtenerPorFiltros(int? idPropiedad, DateTime? fecha, string estado)
        {
            List<VisitaDTO> lista = new List<VisitaDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVisitas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //en caso de que no haya filtro el sp ignora el parametro 
                cmd.Parameters.AddWithValue("@IdPropiedad",
                    idPropiedad.HasValue ? (object)idPropiedad.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha",
                    fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado",
                    string.IsNullOrEmpty(estado) || estado == "Todos" ? (object)DBNull.Value : estado);

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

        // -------------------------------------------------------
        // Obtiene una visita por su ID (para validación de QR)
        // -------------------------------------------------------
        public VisitaDTO ObtenerPorId(int idVisita)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVisitaPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVisita", idVisita);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return MapearFila(dr);
                }
            }
            return null;
        }

        // -------------------------------------------------------
        // Busca una visita por su CodigoQR (validación en acceso)
        // -------------------------------------------------------
        public VisitaDTO ObtenerPorQR(string codigoQR)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVisitaPorQR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoQR", codigoQR);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return MapearFila(dr);
                }
            }
            return null;
        }

        // -------------------------------------------------------
        // Mapea un DataReader a un VisitaDTO
        // -------------------------------------------------------
        private VisitaDTO MapearFila(SqlDataReader dr)
        {
            return new VisitaDTO
            {
                IdVisita = Convert.ToInt32(dr["IdVisita"]),
                NombreVisitante = dr["NombreVisitante"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"]),
                HoraEntrada = (TimeSpan)dr["HoraEntrada"],
                // HoraSalida puede ser null (visitante aún dentro)
                HoraSalida = dr["HoraSalida"] == DBNull.Value
                                  ? (TimeSpan?)null
                                  : (TimeSpan)dr["HoraSalida"],
                CodigoQR = dr["CodigoQR"] == DBNull.Value
                                  ? string.Empty
                                  : dr["CodigoQR"].ToString(),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                CodigoPropiedad = dr["CodigoPropiedad"].ToString()
            };
        }
    }
}
