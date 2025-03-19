using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace FiltroPersistirMySQL
{
    public class MySQLDatabaseConnector : IDatabaseConnector
    {
        private string connectionString;

        public MySQLDatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool GuardarImagen(string nombre, byte[] imagenBytes, out string error)
        {
            error = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Imagenes (Nombre, Imagen) VALUES (@nombre, @imagen)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@imagen", imagenBytes);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}