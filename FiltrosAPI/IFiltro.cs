using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiltrosAPI
{
    public interface IFiltro
    {
        string Nombre { get; }
        Bitmap AplicarFiltro(Bitmap imagenOriginal);
    }
}

