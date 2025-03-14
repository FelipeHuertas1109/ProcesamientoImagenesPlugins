using System;
using System.IO;
using System.Reflection;
using FiltrosAPI;

namespace TestForm
{
    public class GestorPlugins
    {
        // Método que carga un filtro desde un archivo DLL y lo devuelve
        public IFiltro CargarFiltroDeArchivo(string archivo, out string error)
        {
            error = "";
            try
            {
                Assembly ensamblado = Assembly.LoadFrom(archivo);
                foreach (Type tipo in ensamblado.GetTypes())
                {
                    // Verifica si el tipo implementa IFiltro y no es interfaz ni abstracto
                    if (typeof(IFiltro).IsAssignableFrom(tipo) &&
                        !tipo.IsInterface &&
                        !tipo.IsAbstract)
                    {
                        return (IFiltro)Activator.CreateInstance(tipo);
                    }
                }
                error = "No se encontró un filtro que implemente IFiltro en el DLL.";
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
