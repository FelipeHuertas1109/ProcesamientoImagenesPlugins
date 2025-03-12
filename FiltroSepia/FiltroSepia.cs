using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FiltrosAPI;
using System.Drawing;

namespace FiltroSepia
{
    public class FiltroSepia : IFiltro
    {
        public string Nombre => "Filtro sepia";

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            Bitmap imagenSepia = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    Color pixel = imagenOriginal.GetPixel(x, y);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    // Fórmula Sepia
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    // Asegurarnos de que no exceda 255
                    if (tr > 255) tr = 255;
                    if (tg > 255) tg = 255;
                    if (tb > 255) tb = 255;

                    imagenSepia.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            }

            return imagenSepia;
        }
    }
}

