using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;
using DAL.Singleton;

namespace DAL.DAO
{
    public class CargoFacturableDAO : ICargoFacturableDAL
    {
        // ── REGISTRAR ─────────────────────────────────────────────────
        public bool Registrar(CargoFacturableDTO cargo)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = @"
                    INSERT INTO CargoFacturable
                        (Descripcion, Tipo, MontoBase, IVA, Total,
                         FechaEmision, FechaVencimiento, Estado, IdPropiedad)
                    VALUES
                        (@Descripcion, @Tipo, @MontoBase, @IVA, @Total,
                         @FechaEmision, @FechaVencimiento, @Estado, @IdPropiedad);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AsignarParametros(cmd, cargo);

                    int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                    cargo.IdCargo = idGenerado;
                    return idGenerado > 0;
                }
            }
        }

        // ── MODIFICAR ─────────────────────────────────────────────────
        public bool Modificar(CargoFacturableDTO cargo)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = @"
                    UPDATE CargoFacturable SET
                        Descripcion      = @Descripcion,
                        Tipo             = @Tipo,
                        MontoBase        = @MontoBase,
                        IVA              = @IVA,
                        Total            = @Total,
                        FechaEmision     = @FechaEmision,
                        FechaVencimiento = @FechaVencimiento,
                        Estado           = @Estado
                    WHERE IdCargo = @IdCargo";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AsignarParametros(cmd, cargo);
                    cmd.Parameters.AddWithValue("@IdCargo", cargo.IdCargo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ── ELIMINAR ──────────────────────────────────────────────────
        public bool Eliminar(int idCargo)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                // Si el cargo ya aparece en una factura no se puede borrar físicamente
                // por la llave foránea. En ese caso se anula para conservar el historial.
                const string sql = @"
                    IF EXISTS (SELECT 1 FROM DetalleFactura WHERE IdCargo = @IdCargo)
                    BEGIN
                        UPDATE CargoFacturable
                        SET Estado = 'Anulado'
                        WHERE IdCargo = @IdCargo
                          AND Estado <> 'Pagado';
                    END
                    ELSE
                    BEGIN
                        DELETE FROM CargoFacturable
                        WHERE IdCargo = @IdCargo
                          AND Estado <> 'Pagado';
                    END";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCargo", idCargo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ── MARCAR COMO PAGADO ────────────────────────────────────────
        public bool MarcarComoPagado(int idCargo)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = @"
                    UPDATE CargoFacturable
                    SET Estado = 'Pagado'
                    WHERE IdCargo = @IdCargo AND Estado IN ('Pendiente', 'Vencido')";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCargo", idCargo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ── OBTENER POR ID ────────────────────────────────────────────
        public CargoFacturableDTO ObtenerPorId(int idCargo)
        {
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = "SELECT * FROM CargoFacturable WHERE IdCargo = @IdCargo";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCargo", idCargo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return LeerFila(dr);
                    }
                }
            }
            return null;
        }

        // ── OBTENER POR PROPIEDAD ─────────────────────────────────────
        public List<CargoFacturableDTO> ObtenerPorPropiedad(int idPropiedad)
        {
            var lista = new List<CargoFacturableDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = @"
                    SELECT * FROM CargoFacturable
                    WHERE IdPropiedad = @IdPropiedad
                    ORDER BY FechaEmision DESC";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            lista.Add(LeerFila(dr));
                    }
                }
            }
            return lista;
        }

        // ── OBTENER TODOS ─────────────────────────────────────────────
        public List<CargoFacturableDTO> ObtenerTodos()
        {
            var lista = new List<CargoFacturableDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                const string sql = @"
                    SELECT * FROM CargoFacturable
                    ORDER BY FechaEmision DESC";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(LeerFila(dr));
                }
            }
            return lista;
        }

        // ── HELPERS PRIVADOS ──────────────────────────────────────────

        ///Asigna los parámetros comunes para INSERT y UPDATE.
        private static void AsignarParametros(SqlCommand cmd, CargoFacturableDTO c)
        {
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value =
                string.IsNullOrWhiteSpace(c.Descripcion) ? (object)DBNull.Value : c.Descripcion.Trim();
            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(c.Tipo) ? (object)DBNull.Value : c.Tipo.Trim();

            AgregarDecimal(cmd, "@MontoBase", c.MontoBase);
            AgregarDecimal(cmd, "@IVA", c.IVA);
            AgregarDecimal(cmd, "@Total", c.Total);

            cmd.Parameters.Add("@FechaEmision", SqlDbType.Date).Value = c.FechaEmision.Date;
            cmd.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = c.FechaVencimiento.Date;
            cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value =
                string.IsNullOrWhiteSpace(c.Estado) ? "Pendiente" : c.Estado.Trim();
            cmd.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = c.IdPropiedad;
        }

        private static void AgregarDecimal(SqlCommand cmd, string nombre, decimal valor)
        {
            SqlParameter parametro = cmd.Parameters.Add(nombre, SqlDbType.Decimal);
            parametro.Precision = 10;
            parametro.Scale = 2;
            parametro.Value = decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        ///Mapea una fila del DataReader a un CargoFacturableDTO.
        private static CargoFacturableDTO LeerFila(SqlDataReader dr)
        {
            return new CargoFacturableDTO
            {
                IdCargo = Convert.ToInt32(dr["IdCargo"]),
                Descripcion = dr["Descripcion"].ToString(),
                Tipo = dr["Tipo"].ToString(),
                MontoBase = Convert.ToDecimal(dr["MontoBase"]),
                IVA = Convert.ToDecimal(dr["IVA"]),
                Total = Convert.ToDecimal(dr["Total"]),
                FechaEmision = Convert.ToDateTime(dr["FechaEmision"]),
                FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                Estado = dr["Estado"].ToString(),
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"])
            };
        }
    }
}
