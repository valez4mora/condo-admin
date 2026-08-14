using DTO;
using Interfaces;
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
    /// <summary>
    /// Acceso a datos para la tabla Factura / DetalleFactura.
    /// Usa stored procedures para todas las operaciones.
    /// </summary>
    public class FacturaDAO : IFacturaDAL
    {
        private readonly Conexion _cn = Conexion.Instancia;

        // ── REGISTRAR ─────────────────────────────────────────────────
        /// <summary>
        /// Llama a sp_RegistrarFactura y retorna el Id generado.
        /// </summary>
        public int Registrar(FacturaDTO factura)
        {
            int idGenerado = 0;
            DetalleFacturaDTO detalle = factura.Detalles[0];

            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_RegistrarFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Encabezado
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@TotalColones", factura.TotalColones);
                cmd.Parameters.AddWithValue("@TotalDolares", factura.TotalDolares);
                cmd.Parameters.AddWithValue("@IdPropiedad", factura.IdPropiedad);
                cmd.Parameters.AddWithValue("@Estado", factura.Estado);

                // Detalle (un único cargo por llamada)
                cmd.Parameters.AddWithValue("@IdCargo", detalle.IdCargo);
                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", detalle.Precio);
                cmd.Parameters.AddWithValue("@Subtotal", detalle.SubTotal);

                // Parámetro de salida
                SqlParameter paramId = new SqlParameter("@IdFactura", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();
                idGenerado = Convert.ToInt32(paramId.Value);
            }

            return idGenerado;
        }

        // ── ANULAR ────────────────────────────────────────────────────
        /// <summary>
        /// Cambia el estado de la factura a "Anulada".
        /// Llama a sp_AnularFactura.
        /// </summary>
        public bool Anular(int idFactura)
        {
            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_AnularFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── GUARDAR XML ───────────────────────────────────────────────
        /// <summary>
        /// Persiste el XML de la factura en la columna XmlFactura.
        /// Llama a sp_GuardarXmlFactura.
        /// </summary>
        public bool GuardarXml(int idFactura, string xmlContent)
        {
            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_GuardarXmlFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                cmd.Parameters.AddWithValue("@XmlFactura", xmlContent);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── OBTENER POR ID ────────────────────────────────────────────
        /// <summary>
        /// Retorna la factura completa (encabezado + detalles) por su Id.
        /// Llama a sp_ObtenerFacturaPorId.
        /// </summary>
        public FacturaDTO ObtenerPorId(int idFactura)
        {
            FacturaDTO factura = null;

            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerFacturaPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Primera tabla: encabezado
                    if (dr.Read())
                        factura = MapearEncabezado(dr);

                    // Segunda tabla: detalles
                    if (factura != null && dr.NextResult())
                    {
                        while (dr.Read())
                            factura.Detalles.Add(MapearDetalle(dr));
                    }
                }
            }

            return factura;
        }

        // ── OBTENER POR PROPIEDAD ─────────────────────────────────────
        public List<FacturaDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();

            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerFacturasPorPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(MapearEncabezado(dr));
                }
            }

            return lista;
        }

        // ── OBTENER TODAS ─────────────────────────────────────────────
        public List<FacturaDTO> ObtenerTodas()
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();

            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerTodasLasFacturas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(MapearEncabezado(dr));
                }
            }

            return lista;
        }

        // ── MAPEO PRIVADO ─────────────────────────────────────────────

        private static FacturaDTO MapearEncabezado(SqlDataReader dr)
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

        private static DetalleFacturaDTO MapearDetalle(SqlDataReader dr)
        {
            return new DetalleFacturaDTO
            {
                IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                IdFactura = Convert.ToInt32(dr["IdFactura"]),
                IdCargo = Convert.ToInt32(dr["IdCargo"]),
                DescripcionCargo = dr["DescripcionCargo"].ToString(),
                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                Precio = Convert.ToDecimal(dr["Precio"]),
                SubTotal = Convert.ToDecimal(dr["SubTotal"])
            };
        }
    }
}
