using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;
using DTO;  

namespace DAL.Persistencia
{
    public class PropietarioDAL
    {
        Conexion conexion = Conexion.Instancia;

        public bool Registrar(PropietarioDTO propietario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO Propietario
                               (IdPersona, EstadoMorosidad)
                               VALUES
                               (@IdPersona,@EstadoMorosidad)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdPersona", propietario.IdPersona);
                cmd.Parameters.AddWithValue("@EstadoMorosidad", propietario.EstadoMorosidad);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<PropietarioDTO> ObtenerTodos()
        {
            List<PropietarioDTO> lista = new List<PropietarioDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT * FROM Propietario";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new PropietarioDTO
                    {
                        IdPropietario = Convert.ToInt32(dr["IdPropietario"]),
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        EstadoMorosidad = Convert.ToBoolean(dr["EstadoMorosidad"])
                    });
                }
            }

            return lista;
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM Propietario WHERE IdPropietario=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(PropietarioDTO propietario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE Propietario
                       SET EstadoMorosidad=@EstadoMorosidad
                       WHERE IdPropietario=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@EstadoMorosidad", propietario.EstadoMorosidad);
                cmd.Parameters.AddWithValue("@Id", propietario.IdPropietario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
