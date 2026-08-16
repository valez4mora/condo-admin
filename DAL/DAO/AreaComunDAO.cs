using DAL.Singleton;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class AreaComunDAO : IAreaComunDAL
    {
        private readonly Conexion _conexion = Conexion.Instancia;

        public bool Insertar(AreaComunDTO area)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarAreaComun", cn))  
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", area.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", area.Descripcion ?? string.Empty);
                    cmd.Parameters.AddWithValue("@HoraApertura", area.HoraApertura); 
                    cmd.Parameters.AddWithValue("@HoraCierre", area.HoraCierre);
                    cmd.Parameters.AddWithValue("@CapacidadMaxima", area.CapacidadMaxima);
                    cmd.Parameters.AddWithValue("@Tarifa", area.Tarifa);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool Actualizar(AreaComunDTO area) 
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ModificarAreaComun", cn))  
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdArea", area.IdArea);
                    cmd.Parameters.AddWithValue("@Nombre", area.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", area.Descripcion ?? string.Empty);
                    cmd.Parameters.AddWithValue("@HoraApertura", area.HoraApertura); 
                    cmd.Parameters.AddWithValue("@HoraCierre", area.HoraCierre);
                    cmd.Parameters.AddWithValue("@CapacidadMaxima", area.CapacidadMaxima);
                    cmd.Parameters.AddWithValue("@Tarifa", area.Tarifa);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool Eliminar(int idArea)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion()) 
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_EliminarAreaComun", cn))  
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdArea", idArea);  

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<AreaComunDTO> ObtenerTodas()
        {
            List<AreaComunDTO> lista = new List<AreaComunDTO>();  

            using (SqlConnection cn = _conexion.ObtenerConexion())  
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerAreasComunes", cn))  
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(MapearFila(dr));
                        }
                    }
                }
            }
            return lista;
        }

        public AreaComunDTO ObtenerPorId(int idArea)
        {
            using (SqlConnection cn = _conexion.ObtenerConexion())  
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerAreaComunPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdArea", idArea);  

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return MapearFila(dr);
                    }
                }
            }
            return null;
        }

        private AreaComunDTO MapearFila(SqlDataReader dr)
        {
            return new AreaComunDTO
            {
                IdArea = Convert.ToInt32(dr["IdArea"]),
                Nombre = dr["Nombre"].ToString(),
                Descripcion = dr["Descripcion"].ToString(),
                HoraApertura = (TimeSpan)dr["HoraApertura"],
                HoraCierre = (TimeSpan)dr["HoraCierre"],
                CapacidadMaxima = Convert.ToInt32(dr["CapacidadMaxima"]),
                Tarifa = Convert.ToDecimal(dr["Tarifa"])
            };
        }
    }
}