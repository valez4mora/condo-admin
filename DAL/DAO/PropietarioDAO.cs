using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Singleton;

namespace DAL.DAO
{
    public class PropietarioDAL
    {
        Conexion conexion = Conexion.Instancia;

        public bool Registrar(PropietarioDTO propietario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistrarPropietario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("sp_ObtenerPropietarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new PropietarioDTO
                    {
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        Identificacion = dr["Identificacion"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Sexo = dr["Sexo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        EstadoMorosidad = Convert.ToBoolean(dr["EstadoMorosidad"])
                    });
                }
            }
            return lista;
        }

        public bool Modificar(PropietarioDTO propietario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ModificarPropietario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersona", propietario.IdPersona);
                cmd.Parameters.AddWithValue("@EstadoMorosidad", propietario.EstadoMorosidad);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idPersona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarPropietario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}