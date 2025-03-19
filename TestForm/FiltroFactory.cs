using FiltrosAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAppProcesamiento
{
    public static class FiltroFactory{
        public static FiltroDTO CrearFiltroDTO(IFiltro filtro)
        {
            return new FiltroDTO
            {
                Nombre = filtro.Nombre
            };
        }
    }
}
