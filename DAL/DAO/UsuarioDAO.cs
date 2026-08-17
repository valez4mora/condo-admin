using DAL.Singleton;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    
    public class UsuarioDAO : IUsuarioDAL
    {
       
        public int Registrar(UsuarioDTO usuario)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@ContrasenaHash", usuario.Contrasena); // ya hasheada
                    cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                    object resultado = cmd.ExecuteScalar();
                    return Convert.ToInt32(resultado);
                }
            }
        }

     
        public List<UsuarioDTO> ObtenerTodos()
        {
            List<UsuarioDTO> lista = new List<UsuarioDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new UsuarioDTO
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Usuario = dr["Usuario"].ToString(),
                                Contrasena = string.Empty, // no se le de vuelve el hash a la ui
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                NombreRol = dr["NombreRol"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        
        public UsuarioDTO ObtenerPorCredenciales(string usuario, string hashContrasena)
        {
 
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorCredenciales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@ContrasenaHash", hashContrasena);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new UsuarioDTO
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Usuario = dr["Usuario"].ToString(),
                                Contrasena = string.Empty, // no devolver hash
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                NombreRol = dr["NombreRol"].ToString()
                            };
                        }
                        return null; 
                    }
                }
            }
        }

        
        public bool Modificar(UsuarioDTO usuario)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

      
        public bool CambiarContrasena(int idUsuario, string nuevoHash)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@ContrasenaHash", nuevoHash);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

       
        public bool Eliminar(int idUsuario)
        {
    
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}