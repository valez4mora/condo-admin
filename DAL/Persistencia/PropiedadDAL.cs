using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using Util.Patrones;

namespace DAL.Persistencia
{
    public class PropiedadDAL
    {
            Conexion conexion = Conexion.Instancia;

            // Inserta una nueva propiedad en la base de datos
            public bool Registrar(PropiedadDTO propiedad)
            {
                // using garantiza que la conexión se cierre automáticamente aunque ocurra un error
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    // Abrir conexión
                    cn.Open();

                    // Consulta SQL para insertar un registro
                    string sql = @"INSERT INTO Propiedad
                    (Codigo,Tipo,Area,CantidadResidentes,
                    TarifaMetro,CargoFijo,CuotaMantenimiento,
                    Estado,IdPropietario)

                    VALUES

                    (@Codigo,@Tipo,@Area,@CantidadResidentes,
                    @TarifaMetro,@CargoFijo,@CuotaMantenimiento,
                    @Estado,@IdPropietario)";

                    // Crear comando SQL
                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Codigo", propiedad.Codigo);
                    cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                    cmd.Parameters.AddWithValue("@Area", propiedad.Area);
                    cmd.Parameters.AddWithValue("@CantidadResidentes", propiedad.CantidadResidentes);
                    cmd.Parameters.AddWithValue("@TarifaMetro", propiedad.TarifaMetro);
                    cmd.Parameters.AddWithValue("@CargoFijo", propiedad.CargoFijo);
                    cmd.Parameters.AddWithValue("@CuotaMantenimiento", propiedad.CuotaMantenimiento);
                    cmd.Parameters.AddWithValue("@Estado", propiedad.Estado);
                    cmd.Parameters.AddWithValue("@IdPropietario", propiedad.IdPropietario);

                    // ExecuteNonQuery devuelve la cantidad de filas afectadas.
                    // Si es mayor que 0, significa que el INSERT fue exitoso.
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // Devuelve una lista con todas las propiedades
            public List<PropiedadDTO> ObtenerTodas()
            {
                List<PropiedadDTO> lista = new List<PropiedadDTO>();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    // Consulta para obtener todos los registros
                    string sql = "SELECT * FROM Propiedad";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    // Ejecutar consulta
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Leer cada fila de la consulta
                    while (dr.Read())
                    {
                        // Crear un objeto PropiedadDTO
                        PropiedadDTO p = new PropiedadDTO();

                        // Asignar los datos obtenidos del DataReader
                        p.IdPropiedad = Convert.ToInt32(dr["IdPropiedad"]);
                        p.Codigo = dr["Codigo"].ToString();
                        p.Tipo = dr["Tipo"].ToString();
                        p.Area = Convert.ToDecimal(dr["Area"]);
                        p.CantidadResidentes = Convert.ToInt32(dr["CantidadResidentes"]);
                        p.TarifaMetro = Convert.ToDecimal(dr["TarifaMetro"]);
                        p.CargoFijo = Convert.ToDecimal(dr["CargoFijo"]);
                        p.CuotaMantenimiento = Convert.ToDecimal(dr["CuotaMantenimiento"]);
                        p.Estado = Convert.ToBoolean(dr["Estado"]);
                        p.IdPropietario = Convert.ToInt32(dr["IdPropietario"]);

                        // Agregar el objeto a la lista
                        lista.Add(p);
                    }
                }

                // Retornar la lista completa
                return lista;
            }

            // Busca una propiedad según su Id.
            public PropiedadDTO ObtenerPorId(int id)
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT * FROM Propiedad WHERE IdPropiedad=@Id";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    // Enviar el Id como parámetro
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    // Si encontró un registro
                    if (dr.Read())
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
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            IdPropietario = Convert.ToInt32(dr["IdPropietario"])
                        };
                    }

                    // Si no existe, devuelve null
                    return null;
                }
            }

            // Actualiza la información de una propiedad existente
            public bool Modificar(PropiedadDTO propiedad)
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"UPDATE Propiedad SET
                    Codigo=@Codigo,
                    Tipo=@Tipo,
                    Area=@Area,
                        CantidadResidentes=@CantidadResidentes,
                    TarifaMetro=@TarifaMetro,
                    CargoFijo=@CargoFijo,
                    CuotaMantenimiento=@CuotaMantenimiento,
                    Estado=@Estado,
                    IdPropietario=@IdPropietario

                    WHERE IdPropiedad=@Id";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    // Asignar parámetros
                    cmd.Parameters.AddWithValue("@Codigo", propiedad.Codigo);
                    cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo);
                    cmd.Parameters.AddWithValue("@Area", propiedad.Area);
                    cmd.Parameters.AddWithValue("@CantidadResidentes", propiedad.CantidadResidentes);
                    cmd.Parameters.AddWithValue("@TarifaMetro", propiedad.TarifaMetro);
                    cmd.Parameters.AddWithValue("@CargoFijo", propiedad.CargoFijo);
                    cmd.Parameters.AddWithValue("@CuotaMantenimiento", propiedad.CuotaMantenimiento);
                    cmd.Parameters.AddWithValue("@Estado", propiedad.Estado);
                    cmd.Parameters.AddWithValue("@IdPropietario", propiedad.IdPropietario);
                    cmd.Parameters.AddWithValue("@Id", propiedad.IdPropiedad);

                    // Ejecutar UPDATE
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // Elimina una propiedad utilizando su Id
            public bool Eliminar(int id)
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "DELETE FROM Propiedad WHERE IdPropiedad=@Id";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            // Evita códigos duplicados
            public bool ExisteCodigo(string codigo)
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = "SELECT COUNT(*) FROM Propiedad WHERE Codigo=@Codigo";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    // COUNT(*) devuelve la cantidad de registros encontrados
                    int cantidad = (int)cmd.ExecuteScalar();

                    // Si es mayor que cero, el código ya existe
                    return cantidad > 0;
                }
            }
    }
}