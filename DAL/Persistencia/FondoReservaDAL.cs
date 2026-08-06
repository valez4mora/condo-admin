using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Patrones;
using Interfaces;

namespace DAL.Persistencia
{
    public class FondoReservaDAL : IFondoReservaDAL
    {
        Conexion conexion = Conexion.Instancia;

        public void Insertar(FondoReserva fondo)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string sql = @"INSERT INTO FondoReserva
                          (IdPropiedad,Porcentaje,Monto,Fecha)
                           VALUES
                          (@IdPropiedad,@Porcentaje,@Monto,@Fecha)";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IdPropiedad", fondo.IdPropiedad);
            cmd.Parameters.AddWithValue("@Porcentaje", fondo.Porcentaje);
            cmd.Parameters.AddWithValue("@Monto", fondo.Monto);
            cmd.Parameters.AddWithValue("@Fecha", fondo.Fecha);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public List<FondoReserva> ObtenerTodos()
        {
            List<FondoReserva> lista = new List<FondoReserva>();

            SqlConnection cn = conexion.ObtenerConexion();

            string sql = "SELECT * FROM FondoReserva";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FondoReserva fondo = new FondoReserva
                {
                    IdFondoReserva = Convert.ToInt32(dr["IdFondoReserva"]),
                    IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                    Porcentaje = Convert.ToDecimal(dr["Porcentaje"]),
                    Monto = Convert.ToDecimal(dr["Monto"]),
                    Fecha = Convert.ToDateTime(dr["Fecha"])
                };

                lista.Add(fondo);
            }

            dr.Close();
            cn.Close();

            return lista;
        }

        public List<FondoReserva> ObtenerPorPropiedad(int idPropiedad)
        {
            List<FondoReserva> lista = new List<FondoReserva>();

            SqlConnection cn = conexion.ObtenerConexion();

            string sql = @"SELECT *
                   FROM FondoReserva
                   WHERE IdPropiedad=@IdPropiedad";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FondoReserva fondo = new FondoReserva
                {
                    IdFondoReserva = Convert.ToInt32(dr["IdFondoReserva"]),
                    IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]),
                    Porcentaje = Convert.ToDecimal(dr["Porcentaje"]),
                    Monto = Convert.ToDecimal(dr["Monto"]),
                    Fecha = Convert.ToDateTime(dr["Fecha"])
                };

                lista.Add(fondo);
            }

            dr.Close();
            cn.Close();

            return lista;
        }
    }
}
