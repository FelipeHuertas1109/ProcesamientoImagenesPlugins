using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FiltrosAPI;
using System.Drawing;

namespace FiltroMetadata
{
    public class FiltroMetadata : IFiltro
    {
        // Esta propiedad identifica el plugin.
        public string Nombre => "Obtener metadata";

        // Propiedad para almacenar la información extraída de la imagen.
        public string Informacion { get; private set; }

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            // Construir la cadena de metadata.
            Informacion = $"Dimensiones: {imagenOriginal.Width} x {imagenOriginal.Height}\n" +
                          $"Resolución horizontal: {imagenOriginal.HorizontalResolution}\n" +
                          $"Resolución vertical: {imagenOriginal.VerticalResolution}";
            // No se modifica la imagen, se retorna la original.
            return imagenOriginal;
        }
    }
}


