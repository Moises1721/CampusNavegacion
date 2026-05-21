using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNavegacion
{
    public class Grafo
    {
        private Dictionary<string, List<(string destino, int distancia)>> adj;

        public Grafo()
        {
            adj = new Dictionary<string, List<(string, int)>>();
        }
    
        public void AgregarEdificio(string nombre)
        {
            if (!adj.ContainsKey(nombre))
            {
                adj[nombre] = new List<(string, int)>();
            }
        }
        public void AgregarCamino(string origen, string destino, int distancia)
        {
            if (adj.ContainsKey(origen) && adj.ContainsKey(destino))
            {
                adj[origen].Add((destino, distancia));
                adj[destino].Add((origen, distancia));
            }
        }
        public string MostrarGrafo()
        {
            string resultado = "";

            foreach (var edificio in adj)
            {
                resultado += edificio.Key + " -> ";

                foreach (var conexion in edificio.Value)
                {
                    resultado += $"({conexion.destino}, {conexion.distancia}m) ";
                }

                resultado += Environment.NewLine;
            }

            return resultado;
        }
        public string BFS(string inicio)
        {
            if (!adj.ContainsKey(inicio))
                return "El edificio no existe.";

            Queue<string> cola = new Queue<string>();
            HashSet<string> visitados = new HashSet<string>();

            string recorrido = "";

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                recorrido += actual + " ";

                foreach (var vecino in adj[actual])
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        cola.Enqueue(vecino.destino);
                        visitados.Add(vecino.destino);
                    }
                }
            }

            return recorrido;
        }
        public string DFS(string inicio, string destino)
        {
            if (!adj.ContainsKey(inicio) || !adj.ContainsKey(destino))
                return "Uno de los edificios no existe.";

            Stack<string> pila = new Stack<string>();
            HashSet<string> visitados = new HashSet<string>();
            Dictionary<string, string> padres = new Dictionary<string, string>();

            pila.Push(inicio);
            visitados.Add(inicio);

            while (pila.Count > 0)
            {
                string actual = pila.Pop();

                if (actual == destino)
                    break;

                foreach (var vecino in adj[actual])
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        pila.Push(vecino.destino);
                        visitados.Add(vecino.destino);

                        padres[vecino.destino] = actual;
                    }
                }
            }

            if (!visitados.Contains(destino))
                return "No existe camino.";

            List<string> camino = new List<string>();
            string nodoActual = destino;

            while (nodoActual != inicio)
            {
                camino.Add(nodoActual);
                nodoActual = padres[nodoActual];
            }

            camino.Add(inicio);
            camino.Reverse();

            return string.Join(" -> ", camino);
        }
    }
}
