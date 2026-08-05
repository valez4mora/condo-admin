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
            return new List<FondoReserva>();
        }

        public List<FondoReserva> ObtenerPorPropiedad(int idPropiedad)
        {
            return new List<FondoReserva>();
        }
    }
}
