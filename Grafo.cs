using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampusNavegacion
{
    public class Grafo
    {
        private Dictionary<string, List<(string destino, int distancia)>> adj;

        public Grafo()
        {
            adj = new Dictionary<string, List<(string destino, int distancia)>>();
        }

        public void AgregarEdificio(string nombre)
        {
            if (!adj.ContainsKey(nombre))
            {
                adj[nombre] = new List<(string destino, int distancia)>();
            }
        }

        public void AgregarCamino(string origen, string destino, int distancia)
        {
            if (!adj.ContainsKey(origen))
            {
                AgregarEdificio(origen);
            }

            if (!adj.ContainsKey(destino))
            {
                AgregarEdificio(destino);
            }

            adj[origen].Add((destino, distancia));
            adj[destino].Add((origen, distancia));
        }

        public string MostrarGrafo()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== LISTA DE ADYACENCIA ===");
            resultado.AppendLine();

            foreach (string edificio in ObtenerOrdenEdificios())
            {
                if (!adj.ContainsKey(edificio))
                {
                    continue;
                }

                resultado.AppendLine(FormatearEdificio(edificio));

                var conexionesOrdenadas = adj[edificio]
                    .OrderBy(c => c.destino)
                    .ToList();

                if (conexionesOrdenadas.Count == 0)
                {
                    resultado.AppendLine("   Sin conexiones");
                    resultado.AppendLine();
                    continue;
                }

                foreach (var conexion in conexionesOrdenadas)
                {
                    resultado.AppendLine(
                        $"   -> {FormatearEdificio(conexion.destino).PadRight(35)} [{conexion.distancia}m]"
                    );
                }

                resultado.AppendLine();
            }

            return resultado.ToString();
        }

        public string BFS(string inicio)
        {
            if (!adj.ContainsKey(inicio))
            {
                return "El edificio no existe.";
            }

            Queue<string> cola = new Queue<string>();
            HashSet<string> visitados = new HashSet<string>();
            Dictionary<string, int> niveles = new Dictionary<string, int>();
            Dictionary<int, List<string>> edificiosPorNivel = new Dictionary<int, List<string>>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);
            niveles[inicio] = 0;

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                int nivelActual = niveles[actual];

                if (!edificiosPorNivel.ContainsKey(nivelActual))
                {
                    edificiosPorNivel[nivelActual] = new List<string>();
                }

                edificiosPorNivel[nivelActual].Add(FormatearEdificio(actual));

                foreach (var vecino in adj[actual].OrderBy(v => v.destino))
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        visitados.Add(vecino.destino);
                        cola.Enqueue(vecino.destino);
                        niveles[vecino.destino] = nivelActual + 1;
                    }
                }
            }

            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== RECORRIDO BFS ===");
            resultado.AppendLine();
            resultado.AppendLine("Iniciando BFS desde: " + FormatearEdificio(inicio));
            resultado.AppendLine("--------------------------------------------------");
            resultado.AppendLine();

            foreach (var nivel in edificiosPorNivel.OrderBy(n => n.Key))
            {
                resultado.AppendLine("Nivel " + nivel.Key + ": " + string.Join(" | ", nivel.Value));
            }

            resultado.AppendLine();
            resultado.AppendLine("--------------------------------------------------");
            resultado.AppendLine("Total edificios visitados: " + visitados.Count);

            return resultado.ToString();
        }

        public List<string> ObtenerVisitadosBFS(string inicio)
        {
            List<string> ordenVisita = new List<string>();

            if (!adj.ContainsKey(inicio))
            {
                return ordenVisita;
            }

            Queue<string> cola = new Queue<string>();
            HashSet<string> visitados = new HashSet<string>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                ordenVisita.Add(actual);

                foreach (var vecino in adj[actual].OrderBy(v => v.destino))
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        visitados.Add(vecino.destino);
                        cola.Enqueue(vecino.destino);
                    }
                }
            }

            return ordenVisita;
        }

        public string DFS(string inicio, string destino)
        {
            if (!adj.ContainsKey(inicio) || !adj.ContainsKey(destino))
            {
                return "Uno de los edificios no existe.";
            }

            Stack<string> pila = new Stack<string>();
            HashSet<string> visitados = new HashSet<string>();
            Dictionary<string, string> padres = new Dictionary<string, string>();
            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== RECORRIDO DFS ===");
            resultado.AppendLine();
            resultado.AppendLine("Origen : " + FormatearEdificio(inicio));
            resultado.AppendLine("Destino: " + FormatearEdificio(destino));
            resultado.AppendLine("--------------------------------------------------");
            resultado.AppendLine();

            pila.Push(inicio);

            bool encontrado = false;

            while (pila.Count > 0)
            {
                string actual = pila.Pop();

                if (visitados.Contains(actual))
                {
                    continue;
                }

                visitados.Add(actual);
                resultado.AppendLine("Visitando: " + FormatearEdificio(actual));

                if (actual == destino)
                {
                    encontrado = true;
                    break;
                }

                var vecinos = adj[actual]
                    .OrderByDescending(v => v.destino)
                    .ToList();

                foreach (var vecino in vecinos)
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        pila.Push(vecino.destino);

                        if (!padres.ContainsKey(vecino.destino))
                        {
                            padres[vecino.destino] = actual;
                        }
                    }
                }
            }

            resultado.AppendLine();

            if (!encontrado)
            {
                resultado.AppendLine("Camino no encontrado.");
                return resultado.ToString();
            }

            List<string> camino = ReconstruirCamino(inicio, destino, padres);
            int distanciaTotal = CalcularDistanciaCamino(camino);

            resultado.AppendLine("Camino encontrado:");
            resultado.AppendLine("   " + string.Join(" -> ", camino));
            resultado.AppendLine();

            resultado.AppendLine("Camino con nombres:");

            foreach (string nodo in camino)
            {
                resultado.AppendLine("   • " + FormatearEdificio(nodo));
            }

            resultado.AppendLine();
            resultado.AppendLine("Distancia total del camino: " + distanciaTotal + " metros");

            return resultado.ToString();
        }

        public List<string> ObtenerCaminoDFS(string inicio, string destino)
        {
            List<string> caminoVacio = new List<string>();

            if (!adj.ContainsKey(inicio) || !adj.ContainsKey(destino))
            {
                return caminoVacio;
            }

            Stack<string> pila = new Stack<string>();
            HashSet<string> visitados = new HashSet<string>();
            Dictionary<string, string> padres = new Dictionary<string, string>();

            pila.Push(inicio);

            bool encontrado = false;

            while (pila.Count > 0)
            {
                string actual = pila.Pop();

                if (visitados.Contains(actual))
                {
                    continue;
                }

                visitados.Add(actual);

                if (actual == destino)
                {
                    encontrado = true;
                    break;
                }

                var vecinos = adj[actual]
                    .OrderByDescending(v => v.destino)
                    .ToList();

                foreach (var vecino in vecinos)
                {
                    if (!visitados.Contains(vecino.destino))
                    {
                        pila.Push(vecino.destino);

                        if (!padres.ContainsKey(vecino.destino))
                        {
                            padres[vecino.destino] = actual;
                        }
                    }
                }
            }

            if (!encontrado)
            {
                return caminoVacio;
            }

            return ReconstruirCamino(inicio, destino, padres);
        }

        private List<string> ReconstruirCamino(string inicio, string destino, Dictionary<string, string> padres)
        {
            List<string> camino = new List<string>();
            string nodoActual = destino;

            camino.Add(nodoActual);

            while (nodoActual != inicio)
            {
                nodoActual = padres[nodoActual];
                camino.Add(nodoActual);
            }

            camino.Reverse();

            return camino;
        }

        private int CalcularDistanciaCamino(List<string> camino)
        {
            int total = 0;

            for (int i = 0; i < camino.Count - 1; i++)
            {
                string actual = camino[i];
                string siguiente = camino[i + 1];

                var conexion = adj[actual].FirstOrDefault(c => c.destino == siguiente);

                total += conexion.distancia;
            }

            return total;
        }

        public List<(string edificio, int distancia)> ObtenerConexionesDesde(string edificio)
        {
            List<(string edificio, int distancia)> conexiones = new List<(string edificio, int distancia)>();

            if (!adj.ContainsKey(edificio))
            {
                return conexiones;
            }

            foreach (var conexion in adj[edificio].OrderBy(c => c.distancia))
            {
                conexiones.Add((FormatearEdificio(conexion.destino), conexion.distancia));
            }

            return conexiones;
        }

        public List<(string origen, string destino, int distancia)> ObtenerTodasLasRutasUnicas()
        {
            List<(string origen, string destino, int distancia)> rutas = new List<(string origen, string destino, int distancia)>();
            HashSet<string> vistas = new HashSet<string>();

            foreach (var origen in adj.Keys.OrderBy(x => x))
            {
                foreach (var conexion in adj[origen])
                {
                    string a = origen;
                    string b = conexion.destino;

                    string clave = string.Compare(a, b) < 0
                        ? a + "-" + b
                        : b + "-" + a;

                    if (!vistas.Contains(clave))
                    {
                        vistas.Add(clave);
                        rutas.Add((a, b, conexion.distancia));
                    }
                }
            }

            return rutas
                .OrderBy(r => r.distancia)
                .ThenBy(r => r.origen)
                .ThenBy(r => r.destino)
                .ToList();
        }

        public string FormatearEdificio(string clave)
        {
            switch (clave)
            {
                case "A":
                    return "Biblioteca Central (A)";

                case "B":
                    return "Cafetería (B)";

                case "C":
                    return "Laboratorio de Cómputo (C)";

                case "D":
                    return "Rectoría (D)";

                case "E":
                    return "Gimnasio (E)";

                case "F":
                    return "Aulas Generales (F)";

                case "G":
                    return "Estacionamiento (G)";

                default:
                    return clave;
            }
        }

        private List<string> ObtenerOrdenEdificios()
        {
            return new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G"
            };
        }
    }
}