using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.BD_Connection;


namespace DAL.Persistencia
{
    public class FacturaDAO: IFacturaDAL
    {

        Conexion conexion = Conexion.Instancia;

        public int Registrar(FacturaDTO factura)
        {
            int idGenerado = 0;

            //se toma el primer detalle
            DetalleFacturaDTO detalle = factura.Detalles[0];

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                //se llama al stored procedure para registrar la factura 
                SqlCommand cmd = new SqlCommand("sp_RegistrarFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                // Parámetros de la cabecera de la Factura
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@TotalColones", factura.TotalColones);
                cmd.Parameters.AddWithValue("@TotalDolares", factura.TotalDolares);
                cmd.Parameters.AddWithValue("@IdPropiedad", factura.IdPropiedad);
                cmd.Parameters.AddWithValue("@Estado", factura.Estado);

                // Parámetros del detalle (la cuota ordinaria)
                cmd.Parameters.AddWithValue("@IdCargo", detalle.IdCargo);
                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", detalle.Precio);
                cmd.Parameters.AddWithValue("@Subtotal", detalle.SubTotal);


                //  el store procedure nos retorna el IdFactura generado
                SqlParameter paramId = new SqlParameter("@IdFactura", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();

                //se recupera el id generado por la base de datos 
                idGenerado = Convert.ToInt32(paramId.Value);
            }

            return idGenerado;
        }

        //obtiene todas las facturas de una propiedad.
        // llama al stored procedure sp_ObtenerFacturasPorPropiedad.

        public List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerFacturasPorPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(MapearFactura(dr));
                }
            }

            return lista;
        }

        //obtiene todas las facturas del sistema.
        //llama al stored procedure sp_ObtenerTodasLasFacturas.
        public List<FacturaDTO> ObtenerTodas()
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerTodasLasFacturas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(MapearFactura(dr));
                }
            }

            return lista;
        }

        // convierte una fila del DataReader en FacturaDTO.
        private FacturaDTO MapearFactura(SqlDataReader dr)
        {
            return new FacturaDTO
            {
                IdFactura = Convert.ToInt32(dr["IdFactura"]),
                Fecha = Convert.ToDateTime(dr["Fecha"]),
                TotalColones = Convert.ToDecimal(dr["TotalColones"]),
                TotalDolares = Convert.ToDecimal(dr["TotalDolares"]),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                CodigoPropiedad = dr["CodigoPropiedad"].ToString(),
                Estado = dr["Estado"].ToString()
            };
        }
    }
}



