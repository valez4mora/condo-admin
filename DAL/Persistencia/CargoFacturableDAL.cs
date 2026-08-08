using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;
using Util.Patrones;


namespace DAL.Persistencia
{
    public class CargoFacturableDAL : ICargoFacturableDAL
    {
        public bool Registrar(CargoFacturableDTO cargo)
        {
            //habre un canal de comunicacion hacia sql
            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                //instruccion de INSERT con los datos que vienen del DTO
                string sql = @"INSERT INTO CargoFacturable
                   (Descripcion,Tipo,MontoBase,IVA,Total,FechaEmision,FechaVencimiento,Estado,
                    IdPropiedad)
                    VALUES
                    (@Descripcion,@Tipo,@MontoBase,@IVA,@Total,@FechaEmision,@FechaVencimiento,@Estado,
                    @IdPropiedad)";

                //se llenan los datos con los valores que traiga cargo
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Descripcion", cargo.Descripcion);
                cmd.Parameters.AddWithValue("@Tipo", cargo.Tipo);
                cmd.Parameters.AddWithValue("@MontoBase", cargo.MontoBase);
                cmd.Parameters.AddWithValue("@IVA", cargo.IVA);
                cmd.Parameters.AddWithValue("@Total", cargo.Total);
                cmd.Parameters.AddWithValue("@FechaEmision", cargo.FechaEmision);
                cmd.Parameters.AddWithValue("@FechaVencimiento", cargo.FechaVencimiento);
                cmd.Parameters.AddWithValue("@Estado", cargo.Estado);
                cmd.Parameters.AddWithValue("@IdPropiedad", cargo.IdPropiedad);

                //se ejecuta el insert,en caso de que sea mayor a 1 , se inserto el cargo
                //si no, el insert fallo
                return cmd.ExecuteNonQuery() > 0;

            }
        }

        public List<CargoFacturableDTO> ObtenerPorPropiedad(PropiedadDTO propiedad)
        {
            //se utiliza una lista ,ya que una propiedad puede tener varios cargos
            List<CargoFacturableDTO> lista = new List<CargoFacturableDTO>(); //se crea la lista

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT *FROM CargoFacturable WHERE IdPropiedad=@IdPropiedad";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdPropiedad", propiedad.IdPropiedad);

                //DataReader ya que necesitamos leer los resultados
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) //avanza a la siguiente fila del resultado 
                {
                    CargoFacturableDTO c = new CargoFacturableDTO();//por cada vuelta se crea un objeto nuevo
                    //se lee el valor de cada columna y se castea 
                    c.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                    c.Descripcion = dr["Descripcion"].ToString();
                    c.Tipo = dr["Tipo"].ToString();
                    c.MontoBase = Convert.ToDecimal(dr["MontoBase"]);
                    c.IVA = Convert.ToDecimal(dr["IVA"]);
                    c.Total = Convert.ToDecimal(dr["Total"]);
                    c.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                    c.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    c.Estado = dr["Estado"].ToString();
                    c.IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]);

                    lista.Add(c);//se agrega a la lista
                }
            }
            return lista;
        }

        public List<CargoFacturableDTO> ObtenerTodos()
        {
            List<CargoFacturableDTO> lista = new List<CargoFacturableDTO>();

            using (SqlConnection cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT*FROM CargoFacturable"; //se seleccionan todos 
                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CargoFacturableDTO c = new CargoFacturableDTO();
                    c.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                    c.Descripcion = dr["Descripcion"].ToString();
                    c.Tipo = dr["Tipo"].ToString();
                    c.MontoBase = Convert.ToDecimal(dr["MontoBase"]);
                    c.IVA = Convert.ToDecimal(dr["IVA"]);
                    c.Total = Convert.ToDecimal(dr["Total"]);
                    c.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                    c.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    c.Estado = dr["Estado"].ToString();
                    c.IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]);

                    lista.Add(c);
                }
            }
            return lista;
        }

       
    }
}