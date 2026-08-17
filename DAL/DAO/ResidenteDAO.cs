using DAL.Singleton;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class ResidenteDAO
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public bool Registrar(ResidenteDTO residente)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarResidente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = residente.IdPersona;
                cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = residente.IdPropiedad;
                cn.Open(); cmd.ExecuteNonQuery(); return true;
            }
        }

        public List<ResidenteDTO> ObtenerTodos()
        {
            List<ResidenteDTO> lista = new List<ResidenteDTO>();
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerResidentes", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ResidenteDTO
                        {
                            IdPersona = Convert.ToInt32(dr["IdPersona"]),
                            Identificacion = Convert.ToString(dr["Identificacion"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Apellidos = Convert.ToString(dr["Apellidos"]),
                            Sexo = Convert.ToString(dr["Sexo"]),
                            Telefono = Convert.ToString(dr["Telefono"]),
                            Email = Convert.ToString(dr["Email"]),
                            Direccion = Convert.ToString(dr["Direccion"]),
                            DireccionPropiedad = Convert.ToString(dr["DireccionPropiedad"]),
                            Fotografia = dr["Fotografia"] == DBNull.Value ? null : (byte[])dr["Fotografia"],
                            IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                            CodigoPropiedad = Convert.ToString(dr["CodigoPropiedad"])
                        });
                    }
                }
            }
            return lista;
        }

        public bool Modificar(ResidenteDTO residente)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarResidente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = residente.IdPersona;
                cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = residente.IdPropiedad;
                cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar, 20).Value = residente.Identificacion;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = residente.Nombre;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = residente.Apellidos;
                AgregarNullable(cmd, "@Sexo", SqlDbType.Char, 1, residente.Sexo);
                AgregarNullable(cmd, "@Telefono", SqlDbType.VarChar, 20, residente.Telefono);
                AgregarNullable(cmd, "@Email", SqlDbType.VarChar, 100, residente.Email);
                AgregarNullable(cmd, "@Direccion", SqlDbType.VarChar, 250, residente.Direccion);
                SqlParameter foto = cmd.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1);
                foto.Value = residente.Fotografia == null ? (object)DBNull.Value : residente.Fotografia;
                cn.Open(); cmd.ExecuteNonQuery(); return true;
            }
        }

        public bool Eliminar(int idPersona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarResidente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;
                cn.Open(); cmd.ExecuteNonQuery(); return true;
            }
        }

        public List<ResidenteDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            List<ResidenteDTO> lista = new List<ResidenteDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerResidentes", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["IdPropiedad"] == DBNull.Value) continue;

                        int idProp = Convert.ToInt32(dr["IdPropiedad"]);
                        if (idProp != idPropiedad) continue;

                        lista.Add(new ResidenteDTO
                        {
                            IdPersona = Convert.ToInt32(dr["IdPersona"]),
                            Identificacion = Convert.ToString(dr["Identificacion"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Apellidos = Convert.ToString(dr["Apellidos"]),
                            Sexo = Convert.ToString(dr["Sexo"]),
                            Telefono = Convert.ToString(dr["Telefono"]),
                            Email = Convert.ToString(dr["Email"]),
                            Direccion = Convert.ToString(dr["Direccion"]),
                            DireccionPropiedad = Convert.ToString(dr["DireccionPropiedad"]),
                            Fotografia = dr["Fotografia"] as byte[],   
                            IdPropiedad = idProp,
                            CodigoPropiedad = Convert.ToString(dr["CodigoPropiedad"])
                        });
                    }
                }
            }
            return lista;
        }
        private static void AgregarNullable(SqlCommand cmd, string nombre, SqlDbType tipo, int longitud, string valor)
        {
            SqlParameter p = cmd.Parameters.Add(nombre, tipo, longitud);
            p.Value = string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor;
        }
    }
}