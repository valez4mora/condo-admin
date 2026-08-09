using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Util.BD_Connection;

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
                SqlCommand cmd = new SqlCommand("sp_RegistrarResidente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("sp_ObtenerResidentes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ResidenteDTO
                    {
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        Identificacion = dr["Identificacion"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Sexo = dr["Sexo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
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
                SqlCommand cmd = new SqlCommand("sp_ModificarResidente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersona", residente.IdPersona);
                cmd.Parameters.AddWithValue("@IdPropiedad", residente.IdPropiedad);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idPersona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarResidente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}