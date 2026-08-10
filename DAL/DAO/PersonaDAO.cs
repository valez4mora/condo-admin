using DAL.Singleton;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PersonaDAO
    {
        Conexion conexion = Conexion.Instancia;

        public bool Registrar(PersonaDTO persona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO Persona
                    (Identificacion, Nombre, Apellidos, Sexo, Telefono, 
                    Email, Direccion, Fotografia)

                    VALUES

                    (@Identificacion, @Nombre, @Apellidos, @Sexo,
                    @Telefono, @Email, @Direccion, @Fotografia)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                cmd.Parameters.AddWithValue("@Sexo", persona.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@Email", persona.Email);
                cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);

                SqlParameter parametroFoto =
                    cmd.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1);

                parametroFoto.Value =
                    persona.Fotografia != null
                        ? (object)persona.Fotografia
                        : DBNull.Value;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Devuelve una lista con todas las personas
        public List<PersonaDTO> ObtenerTodas()
        {
            List<PersonaDTO> lista = new List<PersonaDTO>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT * FROM Persona";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    PersonaDTO p = new PersonaDTO();

                    p.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                    p.Identificacion = dr["Identificacion"].ToString();
                    p.Nombre = dr["Nombre"].ToString();
                    p.Apellidos = dr["Apellidos"].ToString();
                    p.Sexo = dr["Sexo"].ToString();
                    p.Telefono = dr["Telefono"].ToString();
                    p.Email = dr["Email"].ToString();
                    p.Direccion = dr["Direccion"].ToString();

                    if (dr["Fotografia"] != DBNull.Value)
                        p.Fotografia = (byte[])dr["Fotografia"];

                    lista.Add(p);
                }
            }

            return lista;
        }

        public PersonaDTO ObtenerPorId(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "SELECT * FROM Persona WHERE IdPersona=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    PersonaDTO p = new PersonaDTO();

                    p.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                    p.Identificacion = dr["Identificacion"].ToString();
                    p.Nombre = dr["Nombre"].ToString();
                    p.Apellidos = dr["Apellidos"].ToString();
                    p.Sexo = dr["Sexo"].ToString();
                    p.Telefono = dr["Telefono"].ToString();
                    p.Email = dr["Email"].ToString();
                    p.Direccion = dr["Direccion"].ToString();

                    if (dr["Fotografia"] != DBNull.Value)
                        p.Fotografia = (byte[])dr["Fotografia"];

                    return p;
                }

                return null;
            }
        }

        // Actualiza la información de una persona existente
        public bool Modificar(PersonaDTO persona)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE Persona SET
                Identificacion=@Identificacion,
                Nombre=@Nombre,
                Apellidos=@Apellidos,
                Sexo=@Sexo,
                Telefono=@Telefono,
                Email=@Email,
                Direccion=@Direccion,
                Fotografia=@Fotografia
                WHERE IdPersona=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                cmd.Parameters.AddWithValue("@Sexo", persona.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@Email", persona.Email);
                cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);

                SqlParameter parametroFoto =
                    cmd.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1);

                parametroFoto.Value =
                    persona.Fotografia != null
                        ? (object)persona.Fotografia
                        : DBNull.Value;

                cmd.Parameters.AddWithValue("@Id", persona.IdPersona);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Elimina una persona utilizando su Id
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM Persona WHERE IdPersona=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Evita id duplicadas
        public bool ExisteIdentificacion(string identificacion)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT COUNT(*)
                       FROM Persona
                       WHERE Identificacion=@Identificacion";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Identificacion", identificacion);

                int cantidad = (int)cmd.ExecuteScalar();

                return cantidad > 0;
            }
        }

        public int ObtenerIdPorIdentificacion(string identificacion)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT IdPersona 
                       FROM Persona 
                       WHERE Identificacion=@Identificacion";


                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Identificacion", identificacion);


                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
