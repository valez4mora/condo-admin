using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Singleton;

namespace DAL.DAO
{
    public class PropietarioDAO
    {
        Conexion conexion = Conexion.Instancia;

        public bool Registrar(PropietarioDTO propietario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"INSERT INTO Propietario (IdPersona) VALUES (@IdPersona)";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdPersona", propietario.IdPersona);
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
                        EstadoMorosidad = Convert.ToBoolean(dr["EstadoMorosidad"]),
                        Fotografia = dr["Fotografia"] != DBNull.Value
                                     ? (byte[])dr["Fotografia"]
                                     : null
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
                cmd.Parameters.AddWithValue("@Identificacion", propietario.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", propietario.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", propietario.Apellidos);

                cmd.Parameters.AddWithValue("@Sexo",
                    string.IsNullOrWhiteSpace(propietario.Sexo)
                        ? (object)DBNull.Value : propietario.Sexo);

                cmd.Parameters.AddWithValue("@Telefono",
                    string.IsNullOrWhiteSpace(propietario.Telefono)
                        ? (object)DBNull.Value : propietario.Telefono);

                cmd.Parameters.AddWithValue("@Email",
                    string.IsNullOrWhiteSpace(propietario.Email)
                        ? (object)DBNull.Value : propietario.Email);

                cmd.Parameters.AddWithValue("@Direccion",
                    string.IsNullOrWhiteSpace(propietario.Direccion)
                        ? (object)DBNull.Value : propietario.Direccion);

                SqlParameter paramFoto =
                    cmd.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1);
                paramFoto.Value = propietario.Fotografia != null
                                  ? (object)propietario.Fotografia
                                  : DBNull.Value;

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public bool Eliminar(int idPersona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "DELETE FROM Propietario WHERE IdPersona = @IdPersona";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ExistePorPersona(int idPersona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = @"SELECT COUNT(*) FROM Propietario WHERE IdPersona = @IdPersona";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}