using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FiltrosAPI;

namespace TestForm
{
    public partial class Form1 : Form
    {
        // Bitmap para la imagen que se cargue
        private Bitmap imagenActual;

        // Gestor que carga los plugins
        private GestorPlugins gestor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar el gestor al iniciar el Form
            gestor = new GestorPlugins();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            // Diálogo para seleccionar la imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imágenes|*.png;*.jpg;";
            openFileDialog.Title = "Seleccionar una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Carga la imagen en memoria
                imagenActual = new Bitmap(openFileDialog.FileName);

                // Muestra la imagen en el PictureBox de "Inicial"
                pbImagenInicial.Image = imagenActual;
                pbImagenInicial.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnCargarFiltros_Click(object sender, EventArgs e)
        {
            // Carpeta donde se ubican los DLL de tus plugins
            string rutaPlugins = Path.Combine(Application.StartupPath, "Plugins");

            // Cargar todos los filtros disponibles
            gestor.CargarFiltros(rutaPlugins);

            // Mostrar un mensaje con cuántos se cargaron
            label2.Text = $"Se cargaron {gestor.FiltrosDisponibles.Count} filtros.";
        }

        private void btnEjecutarFiltro_Click(object sender, EventArgs e)
        {
            // Verificar que haya una imagen
            if (imagenActual == null)
            {
                MessageBox.Show("No hay imagen cargada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determinar qué RadioButton está marcado para saber qué filtro aplicar
            string nombreFiltroSeleccionado = null;

            if (rbEscalaGrises.Checked)
            {
                nombreFiltroSeleccionado = "Escala de grises";
                // Asegúrate de que coincida con el .Nombre que retorna tu plugin
            }
            else if (rbObtenerMetadata.Checked)
            {
                nombreFiltroSeleccionado = "Obtener metadata";
            }
            else if (rbRotarImagen.Checked)
            {
                nombreFiltroSeleccionado = "Rotar Imagen";
            }
            else if (rbFiltroSepia.Checked)
            {
                nombreFiltroSeleccionado = "Filtro sepia";
            }
            else if (rbPersistirImagen.Checked)
            {
                nombreFiltroSeleccionado = "Persistir imagen en BD";
            }

            if (string.IsNullOrEmpty(nombreFiltroSeleccionado))
            {
                MessageBox.Show("Selecciona un filtro en los RadioButtons.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar el plugin correspondiente en la lista
            IFiltro filtroSeleccionado = gestor.FiltrosDisponibles
                .Find(f => f.Nombre == nombreFiltroSeleccionado);

            if (filtroSeleccionado == null)
            {
                MessageBox.Show("El filtro seleccionado no está disponible o no se ha cargado el plugin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Aplicar el filtro
            Bitmap imagenConFiltro = filtroSeleccionado.AplicarFiltro((Bitmap)imagenActual.Clone());

            // Mostrar el resultado en el PictureBox "Con Filtro"
            pbImagenConFiltro.Image = imagenConFiltro;
            pbImagenConFiltro.SizeMode = PictureBoxSizeMode.Zoom;

            // Si el filtro es "Obtener metadata", mostrar la información en label2
            if (filtroSeleccionado.Nombre == "Obtener metadata")
            {
                // Usamos dynamic para acceder a la propiedad Informacion sin necesidad de referenciar el plugin directamente.
                dynamic metadataPlugin = filtroSeleccionado;
                label2.Text = metadataPlugin.Informacion;
            }
            else
            {
                label2.Text = $"Se aplicó el filtro: {filtroSeleccionado.Nombre}";
            }
        }

        // Eventos vacíos si no los usas
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void btnEscalaGrises_CheckedChanged(object sender, EventArgs e) { }
    }
}

