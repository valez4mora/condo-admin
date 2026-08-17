using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Singleton
{
    /// <summary>
    /// Administra la configuración y creación de conexiones con la
    /// base de datos del sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase implementa el patrón Singleton para mantener un único
    /// punto de acceso a la cadena de conexión configurada con el nombre
    /// <c>CondominioDB</c>.
    /// </remarks>
    public class Conexion
    {
        /// <summary>
        /// Almacena la única instancia de la clase <see cref="Conexion"/>.
        /// </summary>
        private static Conexion instancia;

        /// <summary>
        /// Almacena la cadena utilizada para conectarse con la base de datos.
        /// </summary>
        private string cadenaConexion;

        /// <summary>
        /// Inicializa la instancia y obtiene la cadena de conexión desde
        /// el archivo de configuración de la aplicación.
        /// </summary>
        /// <remarks>
        /// El constructor es privado para impedir la creación directa de
        /// objetos y garantizar la aplicación del patrón Singleton.
        /// </remarks>
        private Conexion()
        {
            cadenaConexion = ConfigurationManager
                .ConnectionStrings["CondominioDB"]
                .ConnectionString;
        }

        /// <summary>
        /// Obtiene la única instancia disponible de la clase
        /// <see cref="Conexion"/>.
        /// </summary>
        /// <value>
        /// Instancia compartida que administra el acceso a la cadena
        /// de conexión.
        /// </value>
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

        /// <summary>
        /// Crea una nueva conexión SQL utilizando la cadena configurada.
        /// </summary>
        /// <returns>
        /// Nueva instancia de <see cref="SqlConnection"/>. La conexión
        /// se devuelve cerrada y debe abrirse antes de utilizarse.
        /// </returns>
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}