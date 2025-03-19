using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiltroPersistirMySQL;

namespace FiltroPersistirMySQL
{
    public static class DatabaseConnectorFactory
    {
        /// <summary>
        /// Crea y retorna un conector a MySQL.
        /// </summary>
        /// <returns>Instancia de IDatabaseConnector configurada para MySQL.</returns>
        public static IDatabaseConnector CrearConector()
        {
            // Por ejemplo, podrías obtener la cadena de conexión de un archivo de configuración
            string connectionString = "server=localhost;database=imagenes;user=root;password=1234;";
            return new MySQLDatabaseConnector(connectionString);
        }
    }
}
