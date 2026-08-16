using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Singleton;
using System.Data.SqlClient;
using System.Data;

namespace DAL.DAO
{
        public class ReporteDAO : IReporteDAL
        {
            // REPORTE 1: PROPIEDADES

            /// Obtiene el listado de propiedades con su propietario
            /// y su estado financiero.
           
            /// Si idPropietario es null, obtiene todas las propiedades.
            /// Si contiene un valor, filtra por ese propietario.
       
            public List<ReportePropiedadDTO> ObtenerPropiedades(
                int? idPropietario)
            {
                List<ReportePropiedadDTO> lista =
                    new List<ReportePropiedadDTO>();

                using (SqlConnection conexion = Conexion.Instancia.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_ReportePropiedades", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        SqlParameter parametroPropietario = comando.Parameters.Add("@IdPropietario", SqlDbType.Int);

                        parametroPropietario.Value = idPropietario.HasValue ? (object)idPropietario.Value : DBNull.Value;

                        conexion.Open();

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReportePropiedadDTO reporte = new ReportePropiedadDTO
                                    {
                                        IdPropiedad = Convert.ToInt32(reader["IdPropiedad"]),
                                        Codigo = reader["Codigo"].ToString(),
                                        Tipo = reader["Tipo"].ToString(),
                                        Area = Convert.ToDecimal(reader["Area"]),
                                        CantidadResidentes = Convert.ToInt32(reader["CantidadResidentes"]),
                                        CuotaMantenimiento = Convert.ToDecimal(reader["CuotaMantenimiento"]),
                                        IdPropietario = Convert.ToInt32(reader["IdPropietario"]),
                                        NombrePropietario = reader["NombrePropietario"].ToString(),
                                        CedulaPropietario = reader["CedulaPropietario"].ToString(),
                                        EsMorosa = Convert.ToBoolean(reader["EsMorosa"])
                                    };
                                lista.Add(reporte);
                            }
                        }
                    }
                }

                return lista;
            }

            // REPORTE 2: FACTURACIÓN POR PROPIEDAD

            /// Obtiene todos los cargos facturables pertenecientes
            /// a una propiedad.
            
            /// El rango de fechas es opcional.
            
            public List<ReporteFacturacionPropiedadDTO>
                ObtenerFacturacionPorPropiedad(int idPropiedad, DateTime? fechaInicio, DateTime? fechaFin)
            {
                List<ReporteFacturacionPropiedadDTO> lista = new List<ReporteFacturacionPropiedadDTO>();

                using (SqlConnection conexion = Conexion.Instancia.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_ReporteFacturacionPorPropiedad", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.Add("@IdPropiedad", SqlDbType.Int).Value = idPropiedad;

                        SqlParameter parametroInicio = comando.Parameters.Add("@FechaInicio", SqlDbType.Date);

                        parametroInicio.Value = fechaInicio.HasValue ? (object)fechaInicio.Value.Date : DBNull.Value;

                        SqlParameter parametroFin = comando.Parameters.Add("@FechaFin", SqlDbType.Date);

                        parametroFin.Value = fechaFin.HasValue ? (object)fechaFin.Value.Date : DBNull.Value;

                        conexion.Open();

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReporteFacturacionPropiedadDTO reporte =
                                    new ReporteFacturacionPropiedadDTO
                                    {
                                        IdCargo =
                                            Convert.ToInt32(
                                                reader["IdCargo"]),

                                        IdPropiedad =
                                            Convert.ToInt32(
                                                reader["IdPropiedad"]),

                                        CodigoPropiedad =
                                            reader[
                                                "CodigoPropiedad"]
                                                .ToString(),

                                        TipoCargo =
                                            reader["TipoCargo"]
                                                .ToString(),

                                        Descripcion =
                                            reader["Descripcion"]
                                                .ToString(),

                                        MontoBase =
                                            Convert.ToDecimal(
                                                reader["MontoBase"]),

                                        Impuesto =
                                            Convert.ToDecimal(
                                                reader["Impuesto"]),

                                        Total =
                                            Convert.ToDecimal(
                                                reader["Total"]),

                                        Estado =
                                            reader["Estado"].ToString(),

                                        FechaEmision =
                                            Convert.ToDateTime(
                                                reader["FechaEmision"]),

                                        FechaVencimiento =
                                            Convert.ToDateTime(
                                                reader[
                                                    "FechaVencimiento"])
                                    };

                                lista.Add(reporte);
                            }
                        }
                    }
                }

                return lista;
            }

            // ============================================================
            // REPORTE 3: PROPIEDADES MOROSAS
            // ============================================================

            /// <summary>
            /// Obtiene las propiedades que poseen al menos un cargo
            /// vencido que todavía no ha sido pagado.
            /// </summary>
            public List<ReporteMorosidadDTO>
                ObtenerPropiedadesMorosas()
            {
                List<ReporteMorosidadDTO> lista = new List<ReporteMorosidadDTO>();

                using (SqlConnection conexion = Conexion.Instancia.ObtenerConexion())
                {
                    using (SqlCommand comando =
                        new SqlCommand("sp_ReportePropiedadesMorosas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        conexion.Open();

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReporteMorosidadDTO reporte = new ReporteMorosidadDTO
                                    {
                                        IdPropiedad =
                                            Convert.ToInt32(
                                                reader["IdPropiedad"]),

                                        CodigoPropiedad =
                                            reader[
                                                "CodigoPropiedad"]
                                                .ToString(),

                                        IdPropietario =
                                            Convert.ToInt32(
                                                reader["IdPropietario"]),

                                        NombrePropietario =
                                            reader[
                                                "NombrePropietario"]
                                                .ToString(),

                                        MontoTotalAdeudado =
                                            Convert.ToDecimal(
                                                reader[
                                                    "MontoTotalAdeudado"]),

                                        CantidadCargosPendientes =
                                            Convert.ToInt32(
                                                reader[
                                                    "CantidadCargosPendientes"]),

                                        UltimoPago =
                                            reader["UltimoPago"] ==
                                            DBNull.Value
                                                ? (DateTime?)null
                                                : Convert.ToDateTime(
                                                    reader["UltimoPago"]),

                                        DiasMaximosMora =
                                            Convert.ToInt32(
                                                reader[
                                                    "DiasMaximosMora"]),

                                        ClasificacionRiesgo =
                                            reader[
                                                "ClasificacionRiesgo"]
                                                .ToString()
                                    };

                                lista.Add(reporte);
                            }
                        }
                    }
                }

                return lista;
            }

            // REPORTE 4: INGRESOS MENSUALES
 
            /// Obtiene el total facturado en colones y dólares
            /// para cada uno de los doce meses del año indicado.
            public List<IngresoMensualDTO>
                ObtenerIngresosMensuales(int anio)
            {
                List<IngresoMensualDTO> lista = new List<IngresoMensualDTO>();

                using (SqlConnection conexion = Conexion.Instancia.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_ReporteIngresosMensuales", conexion))
                    {
                        comando.CommandType =
                            CommandType.StoredProcedure;

                        comando.Parameters.Add(
                            "@Anio",
                            SqlDbType.Int).Value = anio;

                        conexion.Open();

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                IngresoMensualDTO ingreso =
                                    new IngresoMensualDTO
                                    {
                                        NumeroMes =
                                            Convert.ToInt32(
                                                reader["NumeroMes"]),

                                        Mes =
                                            reader["Mes"].ToString(),

                                        TotalColones =
                                            Convert.ToDecimal(
                                                reader["TotalColones"]),

                                        TotalDolares =
                                            Convert.ToDecimal(
                                                reader["TotalDolares"])
                                    };

                                lista.Add(ingreso);
                            }
                        }
                    }
                }

                return lista;
            }
        }
    
}
