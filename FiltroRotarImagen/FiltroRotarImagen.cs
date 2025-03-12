using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FiltrosAPI;
using System.Drawing;

namespace FiltroRotarImagen
{
    public class FiltroRotarImagen : IFiltro
    {
        public string Nombre => "Rotar Imagen";

        public Bitmap AplicarFiltro(Bitmap imagenOriginal)
        {
            // Rotar 90 grados
            imagenOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return imagenOriginal;
        }
    }
}

