using DAL.Singleton;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class BitacoraDAO : IBitacoraDAL
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public bool Registrar(BitacoraDTO entrada)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarBitacora", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@Evento", SqlDbType.VarChar, 250).Value = entrada.Evento;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = entrada.IdUsuario;
                cn.Open(); cmd.ExecuteNonQuery(); return true;
            }
        }

        public List<BitacoraDTO> ObtenerTodas() { return Consultar("sp_ObtenerBitacora", null, null); }

        public List<BitacoraDTO> ObtenerPorFecha(DateTime desde, DateTime hasta)
        { return Consultar("sp_ObtenerBitacoraPorFecha", desde.Date, hasta.Date); }

        private List<BitacoraDTO> Consultar(string sp, DateTime? desde, DateTime? hasta)
        {
            List<BitacoraDTO> lista = new List<BitacoraDTO>();
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sp, cn) { CommandType = CommandType.StoredProcedure })
            {
                if (desde.HasValue)
                {
                    cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = desde.Value;
                    cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = hasta.Value;
                }
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                    while (dr.Read()) lista.Add(new BitacoraDTO
                    {
                        IdBitacora = Convert.ToInt32(dr["IdBitacora"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Evento = dr["Evento"].ToString(),
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        NombreUsuario = dr["Usuario"].ToString()
                    });
            }
            return lista;
        }
    }
}
