using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CampusNavegacion
{
    public partial class MainForm : Form
    {
        private Grafo grafo;
        private TablaHash tabla;

        private string ultimoRecorrido = "";

        private List<string> nodosResaltados;
        private List<(string origen, string destino)> aristasResaltadas;

        private Dictionary<string, Point> posiciones;

        public MainForm()
        {
            InitializeComponent();

            grafo = new Grafo();
            tabla = new TablaHash();

            posiciones = new Dictionary<string, Point>();
            nodosResaltados = new List<string>();
            aristasResaltadas = new List<(string origen, string destino)>();

            CargarDatosCampus();
            CargarCombos();

            txtResultado.Text = "Seleccione una operación para visualizar los resultados.";

            this.Shown += (s, e) => AjustarSeparador();
            this.Resize += (s, e) => AjustarSeparador();
        }

        private void AjustarSeparador()
        {
            if (splitContainerMain.Width <= 0)
            {
                return;
            }

            int anchoDerecho = 470;
            int distancia = splitContainerMain.Width - anchoDerecho;

            if (distancia < 560)
            {
                distancia = 560;
            }

            if (distancia > splitContainerMain.Width - 390)
            {
                distancia = splitContainerMain.Width - 390;
            }

            if (distancia > 0 && distancia < splitContainerMain.Width)
            {
                splitContainerMain.SplitterDistance = distancia;
            }
        }

        private void LimpiarResaltadoVisual()
        {
            nodosResaltados.Clear();
            aristasResaltadas.Clear();
        }

        private void CargarDatosCampus()
        {
            grafo.AgregarEdificio("A");
            grafo.AgregarEdificio("B");
            grafo.AgregarEdificio("C");
            grafo.AgregarEdificio("D");
            grafo.AgregarEdificio("E");
            grafo.AgregarEdificio("F");
            grafo.AgregarEdificio("G");

            grafo.AgregarCamino("A", "B", 120);
            grafo.AgregarCamino("A", "C", 200);
            grafo.AgregarCamino("B", "D", 150);
            grafo.AgregarCamino("B", "E", 300);
            grafo.AgregarCamino("C", "F", 100);
            grafo.AgregarCamino("D", "F", 80);
            grafo.AgregarCamino("E", "G", 250);
            grafo.AgregarCamino("F", "G", 180);
        }

        private void CargarCombos()
        {
            cmbInicio.Items.Clear();
            cmbDestino.Items.Clear();

            string[] edificios =
            {
                "A — Biblioteca",
                "B — Cafetería",
                "C — Laboratorio",
                "D — Rectoría",
                "E — Gimnasio",
                "F — Aulas",
                "G — Estacionam."
            };

            cmbInicio.Items.AddRange(edificios);
            cmbDestino.Items.AddRange(edificios);

            cmbInicio.SelectedIndex = 0;
            cmbDestino.SelectedIndex = 6;
        }

        private string ObtenerClaveSeleccionada(ComboBox combo)
        {
            if (combo.SelectedItem == null)
            {
                return "";
            }

            string texto = combo.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(texto))
            {
                return "";
            }

            return texto.Substring(0, 1);
        }

        private void btnMostrarGrafo_Click(object sender, EventArgs e)
        {
            ultimoRecorrido = "GRAFO";
            LimpiarResaltadoVisual();

            txtResultado.Text = grafo.MostrarGrafo();
            panelMapa.Invalidate();
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            string inicio = ObtenerClaveSeleccionada(cmbInicio);

            ultimoRecorrido = "BFS";
            LimpiarResaltadoVisual();

            nodosResaltados = grafo.ObtenerVisitadosBFS(inicio);

            txtResultado.Text = grafo.BFS(inicio);

            foreach (string edificio in nodosResaltados)
            {
                tabla.RegistrarVisita(grafo.FormatearEdificio(edificio));
            }

            panelMapa.Invalidate();
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            string inicio = ObtenerClaveSeleccionada(cmbInicio);
            string destino = ObtenerClaveSeleccionada(cmbDestino);

            ultimoRecorrido = "DFS";
            LimpiarResaltadoVisual();

            nodosResaltados = grafo.ObtenerCaminoDFS(inicio, destino);

            for (int i = 0; i < nodosResaltados.Count - 1; i++)
            {
                aristasResaltadas.Add((nodosResaltados[i], nodosResaltados[i + 1]));
            }

            txtResultado.Text = grafo.DFS(inicio, destino);

            foreach (string edificio in nodosResaltados)
            {
                tabla.RegistrarVisita(grafo.FormatearEdificio(edificio));
            }

            panelMapa.Invalidate();
        }

        private void btnTablaHash_Click(object sender, EventArgs e)
        {
            ultimoRecorrido = "TABLAHASH";
            LimpiarResaltadoVisual();

            nodosResaltados = tabla.ObtenerClavesVisitadas();

            txtResultado.Text = tabla.MostrarEstadisticas();
            panelMapa.Invalidate();
        }

        private void btnMinHeap_Click(object sender, EventArgs e)
        {
            ultimoRecorrido = "MINHEAP";
            LimpiarResaltadoVisual();

            MinHeap minHeap = new MinHeap();

            foreach (var ruta in grafo.ObtenerTodasLasRutasUnicas())
            {
                string descripcion = $"{ObtenerNombreCorto(ruta.origen)} -> {ObtenerNombreCorto(ruta.destino)}";
                minHeap.Insertar(descripcion, ruta.distancia);
            }

            txtResultado.Text = minHeap.MostrarRutasOrdenadasTodas();
            panelMapa.Invalidate();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            tabla = new TablaHash();

            ultimoRecorrido = "";
            LimpiarResaltadoVisual();

            cmbInicio.SelectedIndex = 0;
            cmbDestino.SelectedIndex = 6;

            txtResultado.Text = "Sistema reiniciado correctamente.";
            panelMapa.Invalidate();
        }

        private void panelMapa_Paint(object sender, PaintEventArgs e)
        {
            ActualizarPosicionesMapa();

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DibujarTituloMapa(g);
            DibujarAristas(g);
            DibujarNodos(g);
            DibujarLeyenda(g);
        }

        private void ActualizarPosicionesMapa()
        {
            int ancho = panelMapa.Width;
            int alto = panelMapa.Height;

            posiciones["C"] = new Point((int)(ancho * 0.18), (int)(alto * 0.22));
            posiciones["F"] = new Point((int)(ancho * 0.78), (int)(alto * 0.22));

            posiciones["A"] = new Point((int)(ancho * 0.18), (int)(alto * 0.52));
            posiciones["B"] = new Point((int)(ancho * 0.45), (int)(alto * 0.52));
            posiciones["D"] = new Point((int)(ancho * 0.78), (int)(alto * 0.52));
            posiciones["G"] = new Point((int)(ancho * 0.91), (int)(alto * 0.52));

            posiciones["E"] = new Point((int)(ancho * 0.45), (int)(alto * 0.76));
        }

        private void DibujarTituloMapa(Graphics g)
        {
            using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.FromArgb(33, 72, 115)))
            {
                g.DrawString("MAPA DEL CAMPUS UNIVERSITARIO", font, brush, 25, 20);
            }
        }

        private void DibujarAristas(Graphics g)
        {
            DibujarArista(g, "A", "B", "120m");
            DibujarArista(g, "A", "C", "200m");
            DibujarArista(g, "B", "D", "150m");
            DibujarArista(g, "B", "E", "300m");
            DibujarArista(g, "C", "F", "100m");
            DibujarArista(g, "D", "F", "80m");
            DibujarArista(g, "E", "G", "250m");
            DibujarArista(g, "F", "G", "180m");
        }

        private void DibujarArista(Graphics g, string origen, string destino, string distancia)
        {
            Point p1 = posiciones[origen];
            Point p2 = posiciones[destino];

            Color colorLinea = Color.FromArgb(175, 190, 210);
            float grosor = 2.5f;

            if (ultimoRecorrido == "DFS" && AristaResaltada(origen, destino))
            {
                colorLinea = Color.FromArgb(39, 174, 96);
                grosor = 5f;
            }

            using (Pen pen = new Pen(colorLinea, grosor))
            {
                g.DrawLine(pen, p1, p2);
            }

            Point medio = new Point(
                (p1.X + p2.X) / 2,
                (p1.Y + p2.Y) / 2
            );

            using (Font font = new Font("Segoe UI", 8, FontStyle.Regular))
            using (Brush brush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                g.DrawString(distancia, font, brush, medio.X - 15, medio.Y - 18);
            }
        }

        private bool AristaResaltada(string a, string b)
        {
            foreach (var arista in aristasResaltadas)
            {
                if ((arista.origen == a && arista.destino == b) ||
                    (arista.origen == b && arista.destino == a))
                {
                    return true;
                }
            }

            return false;
        }

        private void DibujarNodos(Graphics g)
        {
            string inicio = ObtenerClaveSeleccionada(cmbInicio);
            string destino = ObtenerClaveSeleccionada(cmbDestino);

            foreach (var item in posiciones)
            {
                string clave = item.Key;
                Point punto = item.Value;

                Color colorNodo = Color.FromArgb(52, 152, 219);

                if (ultimoRecorrido == "BFS")
                {
                    if (clave == inicio)
                    {
                        colorNodo = Color.FromArgb(155, 89, 182);
                    }
                    else if (nodosResaltados.Contains(clave))
                    {
                        colorNodo = Color.FromArgb(243, 156, 18);
                    }
                }
                else if (ultimoRecorrido == "DFS")
                {
                    if (clave == inicio)
                    {
                        colorNodo = Color.FromArgb(155, 89, 182);
                    }
                    else if (clave == destino && nodosResaltados.Contains(clave))
                    {
                        colorNodo = Color.FromArgb(231, 76, 60);
                    }
                    else if (nodosResaltados.Contains(clave))
                    {
                        colorNodo = Color.FromArgb(39, 174, 96);
                    }
                }
                else if (ultimoRecorrido == "TABLAHASH")
                {
                    if (nodosResaltados.Contains(clave))
                    {
                        colorNodo = Color.FromArgb(243, 156, 18);
                    }
                }

                Rectangle circulo = new Rectangle(
                    punto.X - 24,
                    punto.Y - 24,
                    48,
                    48
                );

                using (Brush brush = new SolidBrush(colorNodo))
                using (Pen pen = new Pen(Color.White, 3))
                {
                    g.FillEllipse(brush, circulo);
                    g.DrawEllipse(pen, circulo);
                }

                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    SizeF size = g.MeasureString(clave, font);

                    g.DrawString(
                        clave,
                        font,
                        textBrush,
                        punto.X - (size.Width / 2),
                        punto.Y - (size.Height / 2)
                    );
                }

                using (Font font = new Font("Segoe UI", 8, FontStyle.Regular))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
                {
                    string nombre = ObtenerNombreCorto(clave);
                    SizeF size = g.MeasureString(nombre, font);

                    g.DrawString(
                        nombre,
                        font,
                        textBrush,
                        punto.X - (size.Width / 2),
                        punto.Y + 31
                    );
                }
            }
        }

        private string ObtenerNombreCorto(string clave)
        {
            switch (clave)
            {
                case "A":
                    return "Biblioteca";

                case "B":
                    return "Cafetería";

                case "C":
                    return "Laboratorio";

                case "D":
                    return "Rectoría";

                case "E":
                    return "Gimnasio";

                case "F":
                    return "Aulas";

                case "G":
                    return "Estacionam.";

                default:
                    return clave;
            }
        }

        private void DibujarLeyenda(Graphics g)
        {
            int y = panelMapa.Height - 45;

            DibujarItemLeyenda(g, 25, y, Color.FromArgb(52, 152, 219), "Sin visitar");
            DibujarItemLeyenda(g, 135, y, Color.FromArgb(155, 89, 182), "Origen");
            DibujarItemLeyenda(g, 225, y, Color.FromArgb(231, 76, 60), "Destino");
            DibujarItemLeyenda(g, 325, y, Color.FromArgb(243, 156, 18), "Visitado");
            DibujarItemLeyenda(g, 430, y, Color.FromArgb(39, 174, 96), "Camino");
        }

        private void DibujarItemLeyenda(Graphics g, int x, int y, Color color, string texto)
        {
            using (Brush brush = new SolidBrush(color))
            using (Font font = new Font("Segoe UI", 8, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
            {
                g.FillEllipse(brush, x, y, 11, 11);
                g.DrawString(texto, font, textBrush, x + 16, y - 4);
            }
        }
    }
}