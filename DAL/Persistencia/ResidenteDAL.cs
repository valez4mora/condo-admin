using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;

namespace DAL.Persistencia
{
    public class ResidenteDAL
    {
        Conexion conexion = Conexion.Instancia;

        public bool Registrar(ResidenteDTO residente)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO Residente
                               (IdPersona,IdPropiedad)
                               VALUES
                               (@IdPersona,@IdPropiedad)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdPersona", residente.IdPersona);
                cmd.Parameters.AddWithValue("@IdPropiedad", residente.IdPropiedad);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<ResidenteDTO> ObtenerTodos()
        {
            List<ResidenteDTO> lista = new List<ResidenteDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT * FROM Residente";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new ResidenteDTO
                    {
                        IdResidente = Convert.ToInt32(dr["IdResidente"]),
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        IdPropiedad = Convert.ToInt32(dr["IdPropiedad"])
                    });
                }
            }

            return lista;
        }

        public bool Modificar(ResidenteDTO residente)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE Residente
                       SET IdPropiedad=@IdPropiedad
                       WHERE IdResidente=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdPropiedad", residente.IdPropiedad);
                cmd.Parameters.AddWithValue("@Id", residente.IdResidente);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM Residente WHERE IdResidente=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

