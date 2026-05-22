namespace CampusNavegacion
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelMapa;

        private System.Windows.Forms.Panel panelDerecho;

        private System.Windows.Forms.GroupBox groupSeleccion;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.ComboBox cmbInicio;
        private System.Windows.Forms.ComboBox cmbDestino;

        private System.Windows.Forms.GroupBox groupOperaciones;
        private System.Windows.Forms.Button btnMostrarGrafo;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnDFS;
        private System.Windows.Forms.Button btnTablaHash;
        private System.Windows.Forms.Button btnMinHeap;
        private System.Windows.Forms.Button btnReiniciar;

        private System.Windows.Forms.GroupBox groupResultados;
        private System.Windows.Forms.TextBox txtResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelMapa = new System.Windows.Forms.Panel();

            this.panelDerecho = new System.Windows.Forms.Panel();

            this.groupSeleccion = new System.Windows.Forms.GroupBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.cmbInicio = new System.Windows.Forms.ComboBox();
            this.cmbDestino = new System.Windows.Forms.ComboBox();

            this.groupOperaciones = new System.Windows.Forms.GroupBox();
            this.btnMostrarGrafo = new System.Windows.Forms.Button();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();
            this.btnTablaHash = new System.Windows.Forms.Button();
            this.btnMinHeap = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();

            this.groupResultados = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();

            this.panelSuperior.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();

            this.panelDerecho.SuspendLayout();
            this.groupSeleccion.SuspendLayout();
            this.groupOperaciones.SuspendLayout();
            this.groupResultados.SuspendLayout();

            this.SuspendLayout();

            // panelSuperior
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(33, 72, 115);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.lblSubtitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1200, 95);
            this.panelSuperior.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(797, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SISTEMA DE NAVEGACIÓN DEL CAMPUS UNIVERSITARIO";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 60);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(470, 23);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Estructuras de Datos en C# · Grafos · BFS · DFS · Tabla Hash · Min-Heap";

            // splitContainerMain
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 95);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(12);
            this.splitContainerMain.Size = new System.Drawing.Size(1200, 655);
            this.splitContainerMain.SplitterDistance = 720;
            this.splitContainerMain.SplitterWidth = 6;
            this.splitContainerMain.TabIndex = 1;

            // panelMapa
            this.panelMapa.BackColor = System.Drawing.Color.White;
            this.panelMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMapa.Location = new System.Drawing.Point(15, 15);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(690, 625);
            this.panelMapa.TabIndex = 0;
            this.panelMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMapa_Paint);

            // splitContainerMain.Panel1
            this.splitContainerMain.Panel1.Controls.Add(this.panelMapa);

            // panelDerecho
            this.panelDerecho.Controls.Add(this.groupResultados);
            this.panelDerecho.Controls.Add(this.groupOperaciones);
            this.panelDerecho.Controls.Add(this.groupSeleccion);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(12, 12);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(450, 631);
            this.panelDerecho.TabIndex = 0;

            // splitContainerMain.Panel2
            this.splitContainerMain.Panel2.Controls.Add(this.panelDerecho);

            // groupSeleccion
            this.groupSeleccion.Controls.Add(this.lblInicio);
            this.groupSeleccion.Controls.Add(this.cmbInicio);
            this.groupSeleccion.Controls.Add(this.lblDestino);
            this.groupSeleccion.Controls.Add(this.cmbDestino);
            this.groupSeleccion.Controls.Add(this.lblNota);
            this.groupSeleccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupSeleccion.ForeColor = System.Drawing.Color.FromArgb(33, 72, 115);
            this.groupSeleccion.Location = new System.Drawing.Point(0, 0);
            this.groupSeleccion.Name = "groupSeleccion";
            this.groupSeleccion.Size = new System.Drawing.Size(450, 125);
            this.groupSeleccion.TabIndex = 0;
            this.groupSeleccion.TabStop = false;
            this.groupSeleccion.Text = "Selección de Edificios";

            // lblInicio
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(18, 30);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(111, 20);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Edificio Origen:";

            // cmbInicio
            this.cmbInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbInicio.FormattingEnabled = true;
            this.cmbInicio.Location = new System.Drawing.Point(21, 55);
            this.cmbInicio.Name = "cmbInicio";
            this.cmbInicio.Size = new System.Drawing.Size(180, 31);
            this.cmbInicio.TabIndex = 1;

            // lblDestino
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(230, 30);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(122, 20);
            this.lblDestino.TabIndex = 2;
            this.lblDestino.Text = "Edificio Destino:";

            // cmbDestino
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestino.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(233, 55);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(180, 31);
            this.cmbDestino.TabIndex = 3;

            // lblNota
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblNota.ForeColor = System.Drawing.Color.Gray;
            this.lblNota.Location = new System.Drawing.Point(20, 92);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(256, 19);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Nota: el destino solo aplica para DFS.";

            // groupOperaciones
            this.groupOperaciones.Controls.Add(this.btnMostrarGrafo);
            this.groupOperaciones.Controls.Add(this.btnBFS);
            this.groupOperaciones.Controls.Add(this.btnDFS);
            this.groupOperaciones.Controls.Add(this.btnTablaHash);
            this.groupOperaciones.Controls.Add(this.btnMinHeap);
            this.groupOperaciones.Controls.Add(this.btnReiniciar);
            this.groupOperaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOperaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupOperaciones.ForeColor = System.Drawing.Color.FromArgb(33, 72, 115);
            this.groupOperaciones.Location = new System.Drawing.Point(0, 125);
            this.groupOperaciones.Name = "groupOperaciones";
            this.groupOperaciones.Size = new System.Drawing.Size(450, 185);
            this.groupOperaciones.TabIndex = 1;
            this.groupOperaciones.TabStop = false;
            this.groupOperaciones.Text = "Operaciones";

            // btnMostrarGrafo
            this.btnMostrarGrafo.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnMostrarGrafo.FlatAppearance.BorderSize = 0;
            this.btnMostrarGrafo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarGrafo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMostrarGrafo.ForeColor = System.Drawing.Color.White;
            this.btnMostrarGrafo.Location = new System.Drawing.Point(21, 35);
            this.btnMostrarGrafo.Name = "btnMostrarGrafo";
            this.btnMostrarGrafo.Size = new System.Drawing.Size(180, 40);
            this.btnMostrarGrafo.TabIndex = 0;
            this.btnMostrarGrafo.Text = "Mostrar Grafo";
            this.btnMostrarGrafo.UseVisualStyleBackColor = false;
            this.btnMostrarGrafo.Click += new System.EventHandler(this.btnMostrarGrafo_Click);

            // btnBFS
            this.btnBFS.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnBFS.FlatAppearance.BorderSize = 0;
            this.btnBFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBFS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBFS.ForeColor = System.Drawing.Color.White;
            this.btnBFS.Location = new System.Drawing.Point(233, 35);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(180, 40);
            this.btnBFS.TabIndex = 1;
            this.btnBFS.Text = "Recorrido BFS";
            this.btnBFS.UseVisualStyleBackColor = false;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);

            // btnDFS
            this.btnDFS.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnDFS.FlatAppearance.BorderSize = 0;
            this.btnDFS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDFS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDFS.ForeColor = System.Drawing.Color.White;
            this.btnDFS.Location = new System.Drawing.Point(21, 85);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(180, 40);
            this.btnDFS.TabIndex = 2;
            this.btnDFS.Text = "Recorrido DFS";
            this.btnDFS.UseVisualStyleBackColor = false;
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);

            // btnTablaHash
            this.btnTablaHash.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnTablaHash.FlatAppearance.BorderSize = 0;
            this.btnTablaHash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTablaHash.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTablaHash.ForeColor = System.Drawing.Color.White;
            this.btnTablaHash.Location = new System.Drawing.Point(233, 85);
            this.btnTablaHash.Name = "btnTablaHash";
            this.btnTablaHash.Size = new System.Drawing.Size(180, 40);
            this.btnTablaHash.TabIndex = 3;
            this.btnTablaHash.Text = "Tabla Hash";
            this.btnTablaHash.UseVisualStyleBackColor = false;
            this.btnTablaHash.Click += new System.EventHandler(this.btnTablaHash_Click);

            // btnMinHeap
            this.btnMinHeap.BackColor = System.Drawing.Color.FromArgb(211, 84, 0);
            this.btnMinHeap.FlatAppearance.BorderSize = 0;
            this.btnMinHeap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinHeap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMinHeap.ForeColor = System.Drawing.Color.White;
            this.btnMinHeap.Location = new System.Drawing.Point(21, 135);
            this.btnMinHeap.Name = "btnMinHeap";
            this.btnMinHeap.Size = new System.Drawing.Size(180, 35);
            this.btnMinHeap.TabIndex = 4;
            this.btnMinHeap.Text = "Min-Heap Rutas";
            this.btnMinHeap.UseVisualStyleBackColor = false;
            this.btnMinHeap.Click += new System.EventHandler(this.btnMinHeap_Click);

            // btnReiniciar
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Location = new System.Drawing.Point(233, 135);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(180, 35);
            this.btnReiniciar.TabIndex = 5;
            this.btnReiniciar.Text = "Reiniciar Todo";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);

            // groupResultados
            this.groupResultados.Controls.Add(this.txtResultado);
            this.groupResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupResultados.ForeColor = System.Drawing.Color.FromArgb(33, 72, 115);
            this.groupResultados.Location = new System.Drawing.Point(0, 310);
            this.groupResultados.Name = "groupResultados";
            this.groupResultados.Padding = new System.Windows.Forms.Padding(12);
            this.groupResultados.Size = new System.Drawing.Size(450, 321);
            this.groupResultados.TabIndex = 2;
            this.groupResultados.TabStop = false;
            this.groupResultados.Text = "Resultados";

            // txtResultado
            this.txtResultado.BackColor = System.Drawing.Color.FromArgb(28, 39, 51);
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtResultado.ForeColor = System.Drawing.Color.White;
            this.txtResultado.Location = new System.Drawing.Point(12, 32);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultado.Size = new System.Drawing.Size(426, 277);
            this.txtResultado.TabIndex = 0;
            this.txtResultado.WordWrap = false;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(235, 239, 242);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelSuperior);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Navegación del Campus Universitario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();

            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);

            this.panelDerecho.ResumeLayout(false);
            this.groupSeleccion.ResumeLayout(false);
            this.groupSeleccion.PerformLayout();
            this.groupOperaciones.ResumeLayout(false);
            this.groupResultados.ResumeLayout(false);
            this.groupResultados.PerformLayout();

            this.ResumeLayout(false);
        }
    }
}