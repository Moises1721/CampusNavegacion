using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampusNavegacion
{
    public partial class MainForm : Form
    {
        private Grafo grafo = new Grafo();
        private TablaHash tabla = new TablaHash();
        public MainForm()
        {
            InitializeComponent();

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

            MessageBox.Show(grafo.MostrarGrafo());

            MessageBox.Show("BFS: " + grafo.BFS("A"));

            MessageBox.Show("DFS: " + grafo.DFS("A", "G"));

            tabla.RegistrarVisita("A");
            tabla.RegistrarVisita("B");
            tabla.RegistrarVisita("B");
            tabla.RegistrarVisita("C");
            tabla.RegistrarVisita("C");
            tabla.RegistrarVisita("C");

            MessageBox.Show(tabla.MostrarVisitas());

            MessageBox.Show("Más visitado: " + tabla.EdificioMasVisitado());
        }
    }
    }

