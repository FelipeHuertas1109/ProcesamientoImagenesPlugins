namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCargarImagen = new Button();
            btnCargarFiltros = new Button();
            btnEjecutarFiltro = new Button();
            label1 = new Label();
            pbImagenInicial = new PictureBox();
            pbImagenConFiltro = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            rbEscalaGrises = new RadioButton();
            rbObtenerMetadata = new RadioButton();
            rbRotarImagen = new RadioButton();
            rbFiltroSepia = new RadioButton();
            rbPersistirImagen = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pbImagenInicial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenConFiltro).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.Location = new Point(36, 26);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(221, 39);
            btnCargarImagen.TabIndex = 0;
            btnCargarImagen.Text = "Cargar imágen";
            btnCargarImagen.UseVisualStyleBackColor = true;
            btnCargarImagen.Click += btnCargarImagen_Click;
            // 
            // btnCargarFiltros
            // 
            btnCargarFiltros.Location = new Point(36, 88);
            btnCargarFiltros.Name = "btnCargarFiltros";
            btnCargarFiltros.Size = new Size(221, 42);
            btnCargarFiltros.TabIndex = 1;
            btnCargarFiltros.Text = "Cargar componentes (filtros)";
            btnCargarFiltros.UseVisualStyleBackColor = true;
            btnCargarFiltros.Click += btnCargarFiltros_Click;
            // 
            // btnEjecutarFiltro
            // 
            btnEjecutarFiltro.Location = new Point(36, 332);
            btnEjecutarFiltro.Name = "btnEjecutarFiltro";
            btnEjecutarFiltro.Size = new Size(221, 43);
            btnEjecutarFiltro.TabIndex = 2;
            btnEjecutarFiltro.Text = "Ejecutar filtro seleccionado";
            btnEjecutarFiltro.UseVisualStyleBackColor = true;
            btnEjecutarFiltro.Click += btnEjecutarFiltro_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 378);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 3;
            label1.Text = "Salida de mensajes";
            // 
            // pbImagenInicial
            // 
            pbImagenInicial.Location = new Point(348, 26);
            pbImagenInicial.Name = "pbImagenInicial";
            pbImagenInicial.Size = new Size(356, 228);
            pbImagenInicial.TabIndex = 4;
            pbImagenInicial.TabStop = false;
            // 
            // pbImagenConFiltro
            // 
            pbImagenConFiltro.Location = new Point(348, 280);
            pbImagenConFiltro.Name = "pbImagenConFiltro";
            pbImagenConFiltro.Size = new Size(356, 244);
            pbImagenConFiltro.TabIndex = 5;
            pbImagenConFiltro.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 410);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 10;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 9);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 11;
            label3.Text = "Inicial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(348, 262);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 12;
            label4.Text = "Con Filtro";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbPersistirImagen);
            groupBox1.Controls.Add(rbFiltroSepia);
            groupBox1.Controls.Add(rbRotarImagen);
            groupBox1.Controls.Add(rbObtenerMetadata);
            groupBox1.Controls.Add(rbEscalaGrises);
            groupBox1.Location = new Point(36, 154);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(221, 156);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // rbEscalaGrises
            // 
            rbEscalaGrises.AutoSize = true;
            rbEscalaGrises.Location = new Point(6, 22);
            rbEscalaGrises.Name = "rbEscalaGrises";
            rbEscalaGrises.Size = new Size(106, 19);
            rbEscalaGrises.TabIndex = 0;
            rbEscalaGrises.TabStop = true;
            rbEscalaGrises.Text = "Escala de grises";
            rbEscalaGrises.UseVisualStyleBackColor = true;
            // 
            // rbObtenerMetadata
            // 
            rbObtenerMetadata.AutoSize = true;
            rbObtenerMetadata.Location = new Point(6, 47);
            rbObtenerMetadata.Name = "rbObtenerMetadata";
            rbObtenerMetadata.Size = new Size(121, 19);
            rbObtenerMetadata.TabIndex = 1;
            rbObtenerMetadata.TabStop = true;
            rbObtenerMetadata.Text = "Obtener metadata";
            rbObtenerMetadata.UseVisualStyleBackColor = true;
            // 
            // rbRotarImagen
            // 
            rbRotarImagen.AutoSize = true;
            rbRotarImagen.Location = new Point(6, 72);
            rbRotarImagen.Name = "rbRotarImagen";
            rbRotarImagen.Size = new Size(96, 19);
            rbRotarImagen.TabIndex = 2;
            rbRotarImagen.TabStop = true;
            rbRotarImagen.Text = "Rotar Imagen";
            rbRotarImagen.UseVisualStyleBackColor = true;
            // 
            // rbFiltroSepia
            // 
            rbFiltroSepia.AutoSize = true;
            rbFiltroSepia.Location = new Point(6, 97);
            rbFiltroSepia.Name = "rbFiltroSepia";
            rbFiltroSepia.Size = new Size(83, 19);
            rbFiltroSepia.TabIndex = 3;
            rbFiltroSepia.TabStop = true;
            rbFiltroSepia.Text = "Filtro Sepia";
            rbFiltroSepia.UseVisualStyleBackColor = true;
            // 
            // rbPersistirImagen
            // 
            rbPersistirImagen.AutoSize = true;
            rbPersistirImagen.Location = new Point(6, 122);
            rbPersistirImagen.Name = "rbPersistirImagen";
            rbPersistirImagen.Size = new Size(143, 19);
            rbPersistirImagen.TabIndex = 4;
            rbPersistirImagen.TabStop = true;
            rbPersistirImagen.Text = "Persistir imagen en BD";
            rbPersistirImagen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 552);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pbImagenConFiltro);
            Controls.Add(pbImagenInicial);
            Controls.Add(label1);
            Controls.Add(btnEjecutarFiltro);
            Controls.Add(btnCargarFiltros);
            Controls.Add(btnCargarImagen);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbImagenInicial).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenConFiltro).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargarImagen;
        private Button btnCargarFiltros;
        private Button btnEjecutarFiltro;
        private Label label1;
        private PictureBox pbImagenInicial;
        private PictureBox pbImagenConFiltro;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private RadioButton rbPersistirImagen;
        private RadioButton rbFiltroSepia;
        private RadioButton rbRotarImagen;
        private RadioButton rbObtenerMetadata;
        private RadioButton rbEscalaGrises;
    }
}
