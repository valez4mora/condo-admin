
using DAL.DAO;
using DAL.Singleton;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class RolDAO : IRolDAL
    {


        public int Registrar(RolDTO rol)
        {
        
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarRol", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)rol.Descripcion ?? DBNull.Value);
                    object resultado = cmd.ExecuteScalar();
                    return Convert.ToInt32(resultado);
                }
            }
        }

        public List<RolDTO> ObtenerTodos()
        {
            List<RolDTO> lista = new List<RolDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerRoles", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RolDTO
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"] == DBNull.Value
                                              ? string.Empty
                                              : dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }


        public RolDTO ObtenerPorId(int idRol)
        { 
            return ObtenerTodos().Find(r => r.IdRol == idRol);
        }

        public bool Modificar(RolDTO rol)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ModificarRol", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", rol.IdRol);
                    cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)rol.Descripcion ?? DBNull.Value);

                    // ExecuteNonQuery retorna filas afectadas; > 0 significa éxito
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        
        public bool Eliminar(int idRol)
        {
      
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_EliminarRol", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idRol);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<PermisoDTO> ObtenerPermisos(int idRol)
        {
            List<PermisoDTO> lista = new List<PermisoDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPermisosPorRol", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idRol);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new PermisoDTO
                            {
                                IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Modulo = dr["Modulo"].ToString(),
                                PuedeVer = Convert.ToBoolean(dr["PuedeVer"]),
                                PuedeCrear = Convert.ToBoolean(dr["PuedeCrear"]),
                                PuedeEditar = Convert.ToBoolean(dr["PuedeEditar"]),
                                PuedeEliminar = Convert.ToBoolean(dr["PuedeEliminar"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

 
        public bool GuardarPermiso(PermisoDTO permiso)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GuardarPermisos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", permiso.IdRol);
                    cmd.Parameters.AddWithValue("@Modulo", permiso.Modulo);
                    cmd.Parameters.AddWithValue("@PuedeVer", permiso.PuedeVer);
                    cmd.Parameters.AddWithValue("@PuedeCrear", permiso.PuedeCrear);
                    cmd.Parameters.AddWithValue("@PuedeEditar", permiso.PuedeEditar);
                    cmd.Parameters.AddWithValue("@PuedeEliminar", permiso.PuedeEliminar);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
