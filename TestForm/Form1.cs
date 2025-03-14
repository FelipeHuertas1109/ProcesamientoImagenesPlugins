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
            // Opcional: Asegurarse de que el contenedor de filtros (groupBoxFiltros) esté vacío
            groupBox1.Controls.Clear();
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL Files|*.dll";
            openFileDialog.Title = "Seleccionar el DLL del filtro";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivo = openFileDialog.FileName;
                string error;
                IFiltro filtro = gestor.CargarFiltroDeArchivo(archivo, out error);

                if (filtro != null)
                {
                    // Crear un nuevo RadioButton para el filtro cargado
                    RadioButton rb = new RadioButton();
                    rb.Text = filtro.Nombre;
                    rb.Tag = filtro; // Guardar la instancia del filtro en la propiedad Tag
                    rb.AutoSize = true;
                    rb.Enabled = true;
                    rb.Checked = false; // Opcional: se marca de inmediato al cargar

                    // Posicionar el RadioButton dentro de groupBox1
                    int count = groupBox1.Controls.Count;
                    rb.Location = new Point(10, 20 + count * 25);

                    // Agregar el RadioButton al groupBox1
                    groupBox1.Controls.Add(rb);

                    label2.Text = $"Filtro '{filtro.Nombre}' cargado exitosamente.";
                }
                else
                {
                    MessageBox.Show("Error al cargar el filtro: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEjecutarFiltro_Click(object sender, EventArgs e)
        {
            if (imagenActual == null)
            {
                MessageBox.Show("No hay imagen cargada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar en groupBoxFiltros el RadioButton seleccionado
            IFiltro filtroSeleccionado = null;
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    filtroSeleccionado = rb.Tag as IFiltro;
                    break;
                }
            }

            if (filtroSeleccionado == null)
            {
                MessageBox.Show("No hay filtro seleccionado. Asegúrate de marcar el RadioButton correspondiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aplicar el filtro sobre una copia de la imagen original
            Bitmap imagenConFiltro = filtroSeleccionado.AplicarFiltro((Bitmap)imagenActual.Clone());
            pbImagenConFiltro.Image = imagenConFiltro;
            pbImagenConFiltro.SizeMode = PictureBoxSizeMode.Zoom;

            // Si el filtro es "Obtener metadata", mostrar la información en label2
            if (filtroSeleccionado.Nombre == "Obtener metadata")
            {
                // Acceder dinámicamente a la propiedad Informacion
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

