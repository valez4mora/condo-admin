using DAL.Singleton;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PagoDAO : IPagoDAL
    {
        Conexion conexion = Conexion.Instancia;

        // Registrar un pago
        public bool Registrar(PagoDTO pago)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_RegistrarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = pago.IdFactura;
                AgregarMonto(cmd, pago.Monto);
                cmd.Parameters.Add("@FechaPago", SqlDbType.Date).Value = pago.FechaPago.Date;
                cmd.Parameters.Add("@MetodoPago", SqlDbType.VarChar, 50).Value = pago.MetodoPago;
                cmd.Parameters.Add("@Referencia", SqlDbType.VarChar, 100).Value =
                    string.IsNullOrWhiteSpace(pago.Referencia)
                        ? (object)DBNull.Value
                        : pago.Referencia.Trim();

                // Los SP usan SET NOCOUNT ON, por lo que ExecuteNonQuery puede devolver -1
                // aunque la operación haya terminado correctamente.
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // Obtener todos los pagos
        public List<PagoDTO> ObtenerTodos()
        {
            List<PagoDTO> lista = new List<PagoDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_ObtenerPagos",
                    cn
                );

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PagoDTO pago = new PagoDTO
                    {
                        IdPago = Convert.ToInt32(dr["IdPago"]),
                        IdFactura = Convert.ToInt32(dr["IdFactura"]),
                        Monto = Convert.ToDecimal(dr["Monto"]),
                        FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                        MetodoPago = dr["MetodoPago"].ToString(),
                        Referencia = dr["Referencia"] == DBNull.Value
                            ? ""
                            : dr["Referencia"].ToString()
                    };

                    lista.Add(pago);
                }
            }

            return lista;
        }

        // Obtener los pagos pertenecientes a una factura
        public List<PagoDTO> ObtenerPorFactura(int idFactura)
        {
            List<PagoDTO> lista = new List<PagoDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_ObtenerPagosPorFactura",
                    cn
                );

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdFactura",
                    idFactura
                );

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PagoDTO pago = new PagoDTO
                    {
                        IdPago = Convert.ToInt32(dr["IdPago"]),
                        IdFactura = Convert.ToInt32(dr["IdFactura"]),
                        Monto = Convert.ToDecimal(dr["Monto"]),
                        FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                        MetodoPago = dr["MetodoPago"].ToString(),
                        Referencia = dr["Referencia"] == DBNull.Value
                            ? ""
                            : dr["Referencia"].ToString()
                    };

                    lista.Add(pago);
                }
            }

            return lista;
        }

        // Modificar un pago
        public bool Modificar(PagoDTO pago)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_ModificarPago",
                    cn
                );

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdPago",
                    pago.IdPago
                );

                cmd.Parameters.AddWithValue(
                    "@IdFactura",
                    pago.IdFactura
                );

                cmd.Parameters.AddWithValue(
                    "@Monto",
                    pago.Monto
                );

                cmd.Parameters.AddWithValue(
                    "@FechaPago",
                    pago.FechaPago
                );

                cmd.Parameters.AddWithValue(
                    "@MetodoPago",
                    pago.MetodoPago
                );

                cmd.Parameters.AddWithValue(
                    "@Referencia",
                    string.IsNullOrWhiteSpace(pago.Referencia)
                        ? (object)DBNull.Value
                        : pago.Referencia
                );

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // Eliminar un pago
        public bool Eliminar(int idPago)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_EliminarPago",
                    cn
                );

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdPago",
                    idPago
                );

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        private static void AgregarMonto(SqlCommand cmd, decimal monto)
        {
            SqlParameter parametro = cmd.Parameters.Add("@Monto", SqlDbType.Decimal);
            parametro.Precision = 10;
            parametro.Scale = 2;
            parametro.Value = decimal.Round(monto, 2, MidpointRounding.AwayFromZero);
        }
    }
}
