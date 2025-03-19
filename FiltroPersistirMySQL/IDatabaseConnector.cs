using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltroPersistirMySQL
{
    public interface IDatabaseConnector
    {
        /// <summary>
        /// Guarda la imagen en la base de datos.
        /// </summary>
        /// <param name="nombre">Nombre o identificador de la imagen.</param>
        /// <param name="imagenBytes">La imagen en formato de array de bytes.</param>
        /// <param name="error">Mensaje de error, en caso de fallo.</param>
        /// <returns>true si se guardó correctamente, false en caso contrario.</returns>
        bool GuardarImagen(string nombre, byte[] imagenBytes, out string error);
    }
}
