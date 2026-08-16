using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL.Singleton;

namespace DAL.DAO
{
    public class PropiedadDAO
    {
        Conexion conexion = Conexion.Instancia;

        // ── Mapeo reutilizable ────────────────────────────────────────
        /// Lee una fila del DataReader y construye un PropiedadDTO completo.
        /// Se usa en todos los métodos de consulta para evitar duplicar código.
        private PropiedadDTO MapearDesdeReader(SqlDataReader dr)
        {
            return new PropiedadDTO
            {
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                Codigo = dr["Codigo"].ToString(),
                Tipo = dr["Tipo"].ToString(),
                Area = Convert.ToDecimal(dr["Area"]),
                CantidadResidentes = Convert.ToInt32(dr["CantidadResidentes"]),
                TarifaMetro = Convert.ToDecimal(dr["TarifaMetro"]),
                CargoFijo = Convert.ToDecimal(dr["CargoFijo"]),
                CuotaMantenimiento = Convert.ToDecimal(dr["CuotaMantenimiento"]),
                Direccion = dr["Direccion"] != DBNull.Value ? dr["Direccion"].ToString() : string.Empty,
                IdPropietario = Convert.ToInt32(dr["IdPropietario"]),
                NombrePropietario = dr["NombrePropietario"] != DBNull.Value ? dr["NombrePropietario"].ToString() : string.Empty,
                EstadoMorosidad = dr["EstadoMorosidad"] != DBNull.Value && Convert.ToBoolean(dr["EstadoMorosidad"])
            };
        }

        // ── Registrar ─────────────────────────────────────────────────
        public bool Registrar(PropiedadDTO propiedad)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_RegistrarPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", propiedad.Codigo);
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Area", propiedad.Area);
                cmd.Parameters.AddWithValue("@CantidadResidentes", propiedad.CantidadResidentes);
                cmd.Parameters.AddWithValue("@TarifaMetro", propiedad.TarifaMetro);
                cmd.Parameters.AddWithValue("@CargoFijo", propiedad.CargoFijo);
                cmd.Parameters.AddWithValue("@CuotaMantenimiento", propiedad.CuotaMantenimiento);
                cmd.Parameters.AddWithValue("@Direccion",
                    string.IsNullOrWhiteSpace(propiedad.Direccion)
                        ? (object)DBNull.Value : propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Fotografia", DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPropietario", propiedad.IdPropietario);

                // sp_RegistrarPropiedad devuelve el nuevo IdPropiedad con SELECT SCOPE_IDENTITY()
                object resultado = cmd.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    propiedad.IdPropiedad = Convert.ToInt32(resultado);
                    return true;
                }
                return false;
            }
        }

        // ── ObtenerTodas ──────────────────────────────────────────────
        public List<PropiedadDTO> ObtenerTodas()
        {
            List<PropiedadDTO> lista = new List<PropiedadDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerPropiedades", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(MapearDesdeReader(dr));
            }

            return lista;
        }

        // ── ObtenerPorId ──────────────────────────────────────────────
        public PropiedadDTO ObtenerPorId(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                // JOIN para traer NombrePropietario y EstadoMorosidad
                string sql = @"
                    SELECT
                        pr.IdPropiedad, pr.Codigo, pr.Tipo, pr.Area,
                        pr.CantidadResidentes, pr.TarifaMetro, pr.CargoFijo,
                        pr.CuotaMantenimiento, pr.Direccion, pr.IdPropietario,
                        CONCAT(pe.Nombre, ' ', pe.Apellidos) AS NombrePropietario,
                        CAST(CASE WHEN EXISTS (
                            SELECT 1 FROM CargoFacturable c
                            WHERE c.IdPropiedad = pr.IdPropiedad
                              AND c.Estado IN ('Pendiente','Vencido')
                              AND c.FechaVencimiento < CAST(GETDATE() AS DATE)
                        ) THEN 1 ELSE 0 END AS BIT) AS EstadoMorosidad
                    FROM Propiedad pr
                    INNER JOIN Persona pe ON pe.IdPersona = pr.IdPropietario
                    WHERE pr.IdPropiedad = @Id";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read() ? MapearDesdeReader(dr) : null;
            }
        }

        // ── ObtenerPorCodigo ──────────────────────────────────────────
        public PropiedadDTO ObtenerPorCodigo(string codigo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT
                        pr.IdPropiedad, pr.Codigo, pr.Tipo, pr.Area,
                        pr.CantidadResidentes, pr.TarifaMetro, pr.CargoFijo,
                        pr.CuotaMantenimiento, pr.Direccion, pr.IdPropietario,
                        CONCAT(pe.Nombre, ' ', pe.Apellidos) AS NombrePropietario,
                        CAST(CASE WHEN EXISTS (
                            SELECT 1 FROM CargoFacturable c
                            WHERE c.IdPropiedad = pr.IdPropiedad
                              AND c.Estado IN ('Pendiente','Vencido')
                              AND c.FechaVencimiento < CAST(GETDATE() AS DATE)
                        ) THEN 1 ELSE 0 END AS BIT) AS EstadoMorosidad
                    FROM Propiedad pr
                    INNER JOIN Persona pe ON pe.IdPersona = pr.IdPropietario
                    WHERE pr.Codigo = @Codigo";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read() ? MapearDesdeReader(dr) : null;
            }
        }

        // ── Modificar ─────────────────────────────────────────────────
        public bool Modificar(PropiedadDTO propiedad)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ModificarPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // CORRECCIÓN: usar SP en lugar de SQL directo.
                // El SQL directo tenía "Estado=@Estado" que no existe en la tabla
                // y el parámetro nunca era agregado al comando.
                cmd.Parameters.AddWithValue("@IdPropiedad", propiedad.IdPropiedad);
                cmd.Parameters.AddWithValue("@Codigo", propiedad.Codigo);
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Area", propiedad.Area);
                cmd.Parameters.AddWithValue("@CantidadResidentes", propiedad.CantidadResidentes);
                cmd.Parameters.AddWithValue("@TarifaMetro", propiedad.TarifaMetro);
                cmd.Parameters.AddWithValue("@CargoFijo", propiedad.CargoFijo);
                cmd.Parameters.AddWithValue("@CuotaMantenimiento", propiedad.CuotaMantenimiento);
                cmd.Parameters.AddWithValue("@Direccion",
                    string.IsNullOrWhiteSpace(propiedad.Direccion)
                        ? (object)DBNull.Value : propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Fotografia", DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPropietario", propiedad.IdPropietario);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // ── Eliminar ──────────────────────────────────────────────────
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_EliminarPropiedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPropiedad", id);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // ── ExisteCodigo ──────────────────────────────────────────────
        public bool ExisteCodigo(string codigo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                string sql = "SELECT COUNT(*) FROM Propiedad WHERE Codigo = @Codigo";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}