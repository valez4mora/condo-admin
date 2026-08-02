using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Util.Patrones
{
    public class Conexion
    {
        private static Conexion instancia;
        private string cadenaConexion;

        private Conexion()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["CondominioDB"].ConnectionString;

        }

        //punto de acceso a la instancia (singleton)
        public static Conexion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Conexion();
                }
                return instancia;
            }
        }
        
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
