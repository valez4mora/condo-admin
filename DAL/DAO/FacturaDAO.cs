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
    /// Administra el acceso a los datos relacionados con las facturas
    /// y sus respectivos detalles.
    /// </summary>
    /// <remarks>
    /// Implementa las operaciones definidas por <see cref="IFacturaDAL"/>
    /// y utiliza procedimientos almacenados de SQL Server.
    /// </remarks>
    public class FacturaDAO : IFacturaDAL
    {
        /// <summary>
        /// Instancia única utilizada para obtener conexiones con la base de datos.
        /// </summary>
        private readonly Conexion _cn = Conexion.Instancia;

        // ── REGISTRAR ─────────────────────────────────────────────────

        /// <summary>
        /// Registra una factura y todos sus detalles dentro de una transacción.
        /// </summary>
        /// <param name="factura">
        /// Factura que contiene el encabezado y los detalles por registrar.
        /// </param>
        /// <returns>
        /// Identificador generado para la nueva factura.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando la factura no contiene al menos un detalle.
        /// </exception>
        public int Registrar(FacturaDTO factura)
        {
            int idGenerado = 0;
            if (factura == null || factura.Detalles == null || factura.Detalles.Count == 0)
                throw new ArgumentException("La factura debe contener al menos un detalle.");

            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction tx = cn.BeginTransaction())
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_RegistrarFactura", cn, tx);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Encabezado
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = factura.Fecha.Date;
                        AgregarDecimal(cmd, "@TotalColones", factura.TotalColones);
                        AgregarDecimal(cmd, "@TotalDolares", factura.TotalDolares);
                        AgregarDecimal(cmd, "@TipoCambio", factura.TipoCambio);
                        cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = factura.IdPropiedad;
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value =
                            string.IsNullOrWhiteSpace(factura.Estado) ? "Emitida" : factura.Estado.Trim();

                        // Parámetro de salida
                        SqlParameter paramId = new SqlParameter("@IdFactura", SqlDbType.Int);
                        paramId.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramId);

                        cmd.ExecuteNonQuery();
                        idGenerado = Convert.ToInt32(paramId.Value);

                        foreach (DetalleFacturaDTO detalle in factura.Detalles)
                        {
                            using (SqlCommand detalleCmd = new SqlCommand("sp_RegistrarDetalleFactura", cn, tx))
                            {
                                detalleCmd.CommandType = CommandType.StoredProcedure;
                                detalleCmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idGenerado;
                                detalleCmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = detalle.IdCargo;
                                detalleCmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                                AgregarDecimal(detalleCmd, "@Precio", detalle.Precio);
                                AgregarDecimal(detalleCmd, "@Subtotal", detalle.SubTotal);
                                detalleCmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
            }

            return idGenerado;
        }

        // ── ANULAR ────────────────────────────────────────────────────

        /// <summary>
        /// Cambia el estado de una factura a anulada.
        /// </summary>
        /// <param name="idFactura">
        /// Identificador de la factura que se desea anular.
        /// </param>
        /// <returns>
        /// <c>true</c> si la factura fue actualizada; de lo contrario,
        /// <c>false</c>.
        /// </returns>
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
        /// Guarda el contenido XML asociado a una factura.
        /// </summary>
        /// <param name="idFactura">
        /// Identificador de la factura que recibirá el XML.
        /// </param>
        /// <param name="xmlContent">
        /// Contenido XML que se almacenará en la base de datos.
        /// </param>
        /// <returns>
        /// <c>true</c> si el XML fue almacenado; de lo contrario,
        /// <c>false</c>.
        /// </returns>
        public bool GuardarXml(int idFactura, string xmlContent)
        {
            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_GuardarXmlFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;

                // sp_GuardarXmlFactura recibe NVARCHAR(MAX) y realiza el CAST a XML.
                // El texto ya se genera sin declaración de encoding incompatible.
                cmd.Parameters.Add("@XmlFactura", SqlDbType.NVarChar, -1).Value =
                    string.IsNullOrWhiteSpace(xmlContent) ? (object)DBNull.Value : xmlContent;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Verifica si un cargo facturable ya se encuentra asociado
        /// con alguna factura.
        /// </summary>
        /// <param name="idCargo">
        /// Identificador del cargo facturable que se desea consultar.
        /// </param>
        /// <returns>
        /// <c>true</c> si existe una factura asociada al cargo;
        /// de lo contrario, <c>false</c>.
        /// </returns>
        public bool ExisteFacturaParaCargo(int idCargo)
        {
            using (SqlConnection cn = _cn.ObtenerConexion())
            {
                cn.Open();
                const string sql = @"SELECT COUNT(1)
                                     FROM DetalleFactura
                                     WHERE IdCargo = @IdCargo";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdCargo", SqlDbType.Int).Value = idCargo;
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // ── OBTENER POR ID ────────────────────────────────────────────

        /// <summary>
        /// Obtiene una factura completa, incluyendo su encabezado
        /// y sus detalles.
        /// </summary>
        /// <param name="idFactura">
        /// Identificador de la factura que se desea consultar.
        /// </param>
        /// <returns>
        /// Factura encontrada o <c>null</c> si no existe.
        /// </returns>
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

        /// <summary>
        /// Obtiene todas las facturas asociadas con una propiedad.
        /// </summary>
        /// <param name="idPropiedad">
        /// Identificador de la propiedad que se desea consultar.
        /// </param>
        /// <returns>
        /// Lista de facturas pertenecientes a la propiedad.
        /// </returns>
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

        /// <summary>
        /// Obtiene todas las facturas registradas en el sistema.
        /// </summary>
        /// <returns>
        /// Lista con todas las facturas encontradas.
        /// </returns>
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

        /// <summary>
        /// Agrega un parámetro decimal a un comando SQL con una precisión
        /// y escala definidas.
        /// </summary>
        /// <param name="cmd">
        /// Comando SQL al que se agregará el parámetro.
        /// </param>
        /// <param name="nombre">
        /// Nombre del parámetro SQL.
        /// </param>
        /// <param name="valor">
        /// Valor decimal que se asignará al parámetro.
        /// </param>
        private static void AgregarDecimal(SqlCommand cmd, string nombre, decimal valor)
        {
            SqlParameter parametro = cmd.Parameters.Add(nombre, SqlDbType.Decimal);
            parametro.Precision = 10;
            parametro.Scale = 2;
            parametro.Value = decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Convierte la fila actual del lector SQL en el encabezado
        /// de una factura.
        /// </summary>
        /// <param name="dr">
        /// Lector SQL posicionado en el registro que se desea convertir.
        /// </param>
        /// <returns>
        /// Objeto <see cref="FacturaDTO"/> con los datos del encabezado.
        /// </returns>
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
                Estado = dr["Estado"].ToString(),
                TotalPagado = ExisteColumna(dr, "TotalPagado") && dr["TotalPagado"] != DBNull.Value
                    ? Convert.ToDecimal(dr["TotalPagado"]) : 0m,
                SaldoPendiente = ExisteColumna(dr, "SaldoPendiente") && dr["SaldoPendiente"] != DBNull.Value
                    ? Convert.ToDecimal(dr["SaldoPendiente"]) : Convert.ToDecimal(dr["TotalColones"]),
                TipoCambio = ExisteColumna(dr, "TipoCambio") && dr["TipoCambio"] != DBNull.Value
                    ? Convert.ToDecimal(dr["TipoCambio"]) : 0m
            };
        }

        /// <summary>
        /// Verifica si el resultado del lector SQL contiene una columna
        /// con el nombre indicado.
        /// </summary>
        /// <param name="dr">
        /// Lector SQL cuyo conjunto de columnas se desea revisar.
        /// </param>
        /// <param name="nombre">
        /// Nombre de la columna que se desea localizar.
        /// </param>
        /// <returns>
        /// <c>true</c> si la columna existe; de lo contrario,
        /// <c>false</c>.
        /// </returns>
        private static bool ExisteColumna(SqlDataReader dr, string nombre)
        {
            for (int i = 0; i < dr.FieldCount; i++)
                if (string.Equals(dr.GetName(i), nombre,
                    StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }

        /// <summary>
        /// Convierte la fila actual del lector SQL en el detalle
        /// de una factura.
        /// </summary>
        /// <param name="dr">
        /// Lector SQL posicionado en el registro que se desea convertir.
        /// </param>
        /// <returns>
        /// Objeto <see cref="DetalleFacturaDTO"/> con los datos del detalle.
        /// </returns>
        private static DetalleFacturaDTO MapearDetalle(SqlDataReader dr)
        {
            return new DetalleFacturaDTO
            {
                IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                IdFactura = Convert.ToInt32(dr["IdFactura"]),
                IdCargo = Convert.ToInt32(dr["IdCargo"]),
                DescripcionCargo = dr["DescripcionCargo"].ToString(),
                TipoCargo = ExisteColumna(dr, "Tipo") ? dr["Tipo"].ToString() : "",
                MontoBase = ExisteColumna(dr, "MontoBase")
                    ? Convert.ToDecimal(dr["MontoBase"])
                    : Convert.ToDecimal(dr["Precio"]),
                IVA = ExisteColumna(dr, "IVA")
                    ? Convert.ToDecimal(dr["IVA"])
                    : 0m,
                FechaEmision = ExisteColumna(dr, "FechaEmision")
                    ? Convert.ToDateTime(dr["FechaEmision"])
                    : DateTime.MinValue,
                FechaVencimiento = ExisteColumna(dr, "FechaVencimiento")
                    ? Convert.ToDateTime(dr["FechaVencimiento"])
                    : DateTime.MinValue,
                EstadoCargo = ExisteColumna(dr, "EstadoCargo")
                    ? dr["EstadoCargo"].ToString()
                    : "",
                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                Precio = Convert.ToDecimal(dr["Precio"]),
                SubTotal = Convert.ToDecimal(dr["SubTotal"])
            };
        }
    }
}