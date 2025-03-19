using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FiltrosAPI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace FiltroMetadata
{
    public class FiltroMetadata : IFiltro
    {
        // Nombre que se muestra en la interfaz
        public string Nombre => "Obtener metadata";

        // Propiedad para almacenar la información extraída
        public string Informacion { get; private set; }

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            StringBuilder sb = new StringBuilder();

            // Información básica de la imagen
            sb.AppendLine($"Dimensiones: {imagenOriginal.Width} x {imagenOriginal.Height}");
            sb.AppendLine($"Resolución horizontal: {imagenOriginal.HorizontalResolution} dpi");
            sb.AppendLine($"Resolución vertical: {imagenOriginal.VerticalResolution} dpi");
            sb.AppendLine($"Formato de píxel: {imagenOriginal.PixelFormat}");

            // Intentar obtener metadata adicional mediante PropertyItems
            try
            {
                PropertyItem[] propItems = imagenOriginal.PropertyItems;
                if (propItems != null && propItems.Length > 0)
                {
                    sb.AppendLine("\nMetadata (Property Items):");
                    foreach (PropertyItem prop in propItems)
                    {
                        sb.AppendLine($"  Propiedad ID: 0x{prop.Id:X}, Tipo: {prop.Type}, Longitud: {prop.Len}");
                        // Se muestra el valor en hexadecimal
                        sb.AppendLine("  Valor: " + BitConverter.ToString(prop.Value));
                    }
                }
                else
                {
                    sb.AppendLine("\nNo se encontraron PropertyItems adicionales.");
                }
            }
            catch (System.Exception ex)
            {
                sb.AppendLine($"\nError obteniendo PropertyItems: {ex.Message}");
            }

            // Guardar la información en la propiedad para poder usarla en la UI
            Informacion = sb.ToString();

            // Retornar la imagen original sin modificaciones
            return imagenOriginal;
        }
    }
}


