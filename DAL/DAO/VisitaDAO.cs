using DAL.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.DAO
{
    public class VisitaDAO
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
                cmd.Parameters.AddWithValue("@IdPropiedad", visita.IdPropiedad);
                cmd.Parameters.AddWithValue("@CodigoQR", visita.CodigoQR ?? (object)DBNull.Value);

                // El SP devuelve el ID generado con OUTPUT
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
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

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // -------------------------------------------------------
        // Registra la hora de salida de una visita
        // -------------------------------------------------------
        public bool RegistrarSalida(int idVisita, DateTime horaSalida)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistrarSalidaVisita", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdVisita", idVisita);
                cmd.Parameters.AddWithValue("@HoraSalida", horaSalida);

                return cmd.ExecuteNonQuery() > 0;
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
                        lista.Add(MapearVisita(dr));
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
                        return MapearVisita(dr);
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
                        return MapearVisita(dr);
                }
            }
            return null;
        }

        // -------------------------------------------------------
        // Mapea un DataReader a un VisitaDTO
        // -------------------------------------------------------
        private VisitaDTO MapearVisita(SqlDataReader dr)
        {
            return new VisitaDTO
            {
                IdVisita = Convert.ToInt32(dr["IdVisita"]),
                NombreVisitante = dr["NombreVisitante"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"]),
                HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"]),
                HoraSalida = dr["HoraSalida"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(dr["HoraSalida"]),
                CodigoQR = dr["CodigoQR"].ToString(),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                CodigoPropiedad = dr["CodigoPropiedad"].ToString()
            };
        }
    }
}
