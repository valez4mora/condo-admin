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
        private readonly Conexion conexion = Conexion.Instancia;

        // Convierte una fila de la base de datos en PropiedadDTO.
        private PropiedadDTO MapearDesdeReader(SqlDataReader dr)
        {
            return new PropiedadDTO
            {
                IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                Codigo = dr["Codigo"].ToString(),
                Tipo = dr["Tipo"].ToString(),
                Area = Convert.ToDecimal(dr["Area"]),
                CantidadResidentes =
                    Convert.ToInt32(dr["CantidadResidentes"]),
                TarifaMetro = Convert.ToDecimal(dr["TarifaMetro"]),
                CargoFijo = Convert.ToDecimal(dr["CargoFijo"]),
                CuotaMantenimiento =
                    Convert.ToDecimal(dr["CuotaMantenimiento"]),

                Direccion = dr["Direccion"] != DBNull.Value
                    ? dr["Direccion"].ToString()
                    : string.Empty,

                IdPropietario = Convert.ToInt32(dr["IdPropietario"]),

                NombrePropietario =
                    dr["NombrePropietario"] != DBNull.Value
                        ? dr["NombrePropietario"].ToString()
                        : string.Empty,

                EstadoMorosidad =
                    dr["EstadoMorosidad"] != DBNull.Value &&
                    Convert.ToBoolean(dr["EstadoMorosidad"])
            };
        }

        // Registra una propiedad y recupera el ID generado.
        public bool Registrar(PropiedadDTO propiedad)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd =
                   new SqlCommand("sp_RegistrarPropiedad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                AgregarParametrosPropiedad(cmd, propiedad);

                cn.Open();

                object resultado = cmd.ExecuteScalar();

                if (resultado == null || resultado == DBNull.Value)
                    return false;

                propiedad.IdPropiedad = Convert.ToInt32(resultado);
                return propiedad.IdPropiedad > 0;
            }
        }

        // Obtiene todas las propiedades.
        public List<PropiedadDTO> ObtenerTodas()
        {
            List<PropiedadDTO> lista =
                new List<PropiedadDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd =
                   new SqlCommand("sp_ObtenerPropiedades", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(MapearDesdeReader(dr));
                    }
                }
            }

            return lista;
        }

        // Obtiene una propiedad mediante su ID.
        public PropiedadDTO ObtenerPorId(int id)
        {
            const string sql = @"
                SELECT
                    pr.IdPropiedad,
                    pr.Codigo,
                    pr.Tipo,
                    pr.Area,
                    pr.CantidadResidentes,
                    pr.TarifaMetro,
                    pr.CargoFijo,
                    pr.CuotaMantenimiento,
                    pr.Direccion,
                    pr.IdPropietario,
                    CONCAT(pe.Nombre, ' ', pe.Apellidos)
                        AS NombrePropietario,
                    CAST(
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM CargoFacturable c
                                WHERE c.IdPropiedad = pr.IdPropiedad
                                  AND c.Estado IN
                                      ('Pendiente', 'Vencido')
                                  AND c.FechaVencimiento <
                                      CAST(GETDATE() AS DATE)
                            )
                            THEN 1
                            ELSE 0
                        END
                        AS BIT
                    ) AS EstadoMorosidad
                FROM Propiedad pr
                INNER JOIN Persona pe
                    ON pe.IdPersona = pr.IdPropietario
                WHERE pr.IdPropiedad = @IdPropiedad;";

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters
                    .Add("@IdPropiedad", SqlDbType.Int)
                    .Value = id;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    return dr.Read()
                        ? MapearDesdeReader(dr)
                        : null;
                }
            }
        }

        // Obtiene una propiedad mediante su código.
        public PropiedadDTO ObtenerPorCodigo(string codigo)
        {
            const string sql = @"
                SELECT
                    pr.IdPropiedad,
                    pr.Codigo,
                    pr.Tipo,
                    pr.Area,
                    pr.CantidadResidentes,
                    pr.TarifaMetro,
                    pr.CargoFijo,
                    pr.CuotaMantenimiento,
                    pr.Direccion,
                    pr.IdPropietario,
                    CONCAT(pe.Nombre, ' ', pe.Apellidos)
                        AS NombrePropietario,
                    CAST(
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM CargoFacturable c
                                WHERE c.IdPropiedad = pr.IdPropiedad
                                  AND c.Estado IN
                                      ('Pendiente', 'Vencido')
                                  AND c.FechaVencimiento <
                                      CAST(GETDATE() AS DATE)
                            )
                            THEN 1
                            ELSE 0
                        END
                        AS BIT
                    ) AS EstadoMorosidad
                FROM Propiedad pr
                INNER JOIN Persona pe
                    ON pe.IdPersona = pr.IdPropietario
                WHERE pr.Codigo = @Codigo;";

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters
                    .Add("@Codigo", SqlDbType.VarChar, 20)
                    .Value = codigo;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    return dr.Read()
                        ? MapearDesdeReader(dr)
                        : null;
                }
            }
        }

        // Modifica una propiedad.
        public bool Modificar(PropiedadDTO propiedad)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd =
                   new SqlCommand("sp_ModificarPropiedad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters
                    .Add("@IdPropiedad", SqlDbType.Int)
                    .Value = propiedad.IdPropiedad;

                AgregarParametrosPropiedad(cmd, propiedad);

                cn.Open();

                // El SP utiliza SET NOCOUNT ON, por lo que ExecuteNonQuery
                // puede retornar -1 aunque la actualización sea exitosa.
                cmd.ExecuteNonQuery();

                return true;
            }
        }

        // Elimina una propiedad.
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd =
                   new SqlCommand("sp_EliminarPropiedad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters
                    .Add("@IdPropiedad", SqlDbType.Int)
                    .Value = id;

                cn.Open();

                // Si el procedimiento no puede eliminarla,
                // SQL Server lanzará una excepción.
                cmd.ExecuteNonQuery();

                return true;
            }
        }

        // Comprueba si un código ya está registrado.
        public bool ExisteCodigo(string codigo)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM Propiedad
                WHERE Codigo = @Codigo;";

            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters
                    .Add("@Codigo", SqlDbType.VarChar, 20)
                    .Value = codigo;

                cn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Agrega los parámetros compartidos por Registrar y Modificar.
        private void AgregarParametrosPropiedad(
            SqlCommand cmd,
            PropiedadDTO propiedad)
        {
            cmd.Parameters
                .Add("@Codigo", SqlDbType.VarChar, 20)
                .Value = propiedad.Codigo;

            cmd.Parameters
                .Add("@Tipo", SqlDbType.VarChar, 50)
                .Value = propiedad.Tipo;

            SqlParameter area =
                cmd.Parameters.Add(
                    "@Area",
                    SqlDbType.Decimal);

            area.Precision = 10;
            area.Scale = 2;
            area.Value = propiedad.Area;

            cmd.Parameters
                .Add("@CantidadResidentes", SqlDbType.Int)
                .Value = propiedad.CantidadResidentes;

            SqlParameter tarifa =
                cmd.Parameters.Add(
                    "@TarifaMetro",
                    SqlDbType.Decimal);

            tarifa.Precision = 10;
            tarifa.Scale = 2;
            tarifa.Value = propiedad.TarifaMetro;

            SqlParameter cargoFijo =
                cmd.Parameters.Add(
                    "@CargoFijo",
                    SqlDbType.Decimal);

            cargoFijo.Precision = 10;
            cargoFijo.Scale = 2;
            cargoFijo.Value = propiedad.CargoFijo;

            SqlParameter cuota =
                cmd.Parameters.Add(
                    "@CuotaMantenimiento",
                    SqlDbType.Decimal);

            cuota.Precision = 10;
            cuota.Scale = 2;
            cuota.Value = propiedad.CuotaMantenimiento;

            cmd.Parameters
                .Add("@Direccion", SqlDbType.VarChar, 250)
                .Value = string.IsNullOrWhiteSpace(
                    propiedad.Direccion)
                        ? (object)DBNull.Value
                        : propiedad.Direccion;

            // Fotografía opcional.
            // -1 representa VARBINARY(MAX).
            cmd.Parameters
                .Add("@Fotografia", SqlDbType.VarBinary, -1)
                .Value = DBNull.Value;

            cmd.Parameters
                .Add("@IdPropietario", SqlDbType.Int)
                .Value = propiedad.IdPropietario;
        }
    }
}