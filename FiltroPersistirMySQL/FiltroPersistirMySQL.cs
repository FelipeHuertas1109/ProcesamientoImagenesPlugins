using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiltrosAPI;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FiltroPersistirMySQL
{
    public class FiltroPersistirMySQL : IFiltro
    {
        // El nombre del filtro que aparecerá en la UI
        public string Nombre => "Persistir imagen en MySQL";

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            // Convertir la imagen a un array de bytes en formato PNG
            byte[] imagenBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                imagenOriginal.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imagenBytes = ms.ToArray();
            }

            // Usar la fábrica para obtener el conector a la base de datos MySQL
            IDatabaseConnector conector = DatabaseConnectorFactory.CrearConector();
            string error;
            bool exito = conector.GuardarImagen("ImagenPersistida", imagenBytes, out error);


            // Retornar la imagen original (el filtro se limita a guardar en la BD)
            return imagenOriginal;
        }
    }
}
