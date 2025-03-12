using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FiltrosAPI;

namespace TestForm
{
    public class GestorPlugins
    {
        public List<IFiltro> FiltrosDisponibles { get; private set; } = new List<IFiltro>();

        public void CargarFiltros(string rutaCarpeta)
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Buscar todos los .dll en la carpeta
            foreach (string archivo in Directory.GetFiles(rutaCarpeta, "*.dll"))
            {
                try
                {
                    Assembly ensamblado = Assembly.LoadFrom(archivo);
                    foreach (Type tipo in ensamblado.GetTypes())
                    {
                        // Verifica si el tipo implementa IFiltro y no es interfaz ni abstracto
                        if (typeof(IFiltro).IsAssignableFrom(tipo)
                            && !tipo.IsInterface
                            && !tipo.IsAbstract)
                        {
                            IFiltro filtro = (IFiltro)Activator.CreateInstance(tipo);
                            FiltrosDisponibles.Add(filtro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar {archivo}: {ex.Message}");
                }
            }
        }
    }
}

