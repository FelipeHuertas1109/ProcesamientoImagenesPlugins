using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiltrosAPI;

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

            // Opcional: Notificar el resultado al usuario
            if (!exito)
            {
                MessageBox.Show("Error al guardar la imagen en la base de datos: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Imagen guardada exitosamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Retornar la imagen original (el filtro se limita a guardar en la BD)
            return imagenOriginal;
        }
    }
}
