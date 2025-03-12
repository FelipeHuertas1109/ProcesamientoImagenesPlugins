using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FiltrosAPI;
using System.Drawing;

namespace FiltroEscalaGrises
{
    public class FiltroEscalaGrises : IFiltro
    {
        public string Nombre => "Escala de grises";

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            // Creamos un nuevo bitmap para la imagen resultante
            Bitmap imagenGris = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);
            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    Color pixel = imagenOriginal.GetPixel(x, y);
                    // Fórmula básica para escala de grises
                    int intensidad = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    Color gris = Color.FromArgb(intensidad, intensidad, intensidad);
                    imagenGris.SetPixel(x, y, gris);
                }
            }
            return imagenGris;
        }
    }
}

