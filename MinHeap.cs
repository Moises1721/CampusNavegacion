using System;
using System.Collections.Generic;
using System.Text;

namespace CampusNavegacion
{
    internal class MinHeap
    {
        private List<(string ruta, int distancia)> heap;

        public MinHeap()
        {
            heap = new List<(string ruta, int distancia)>();
        }

        public void Insertar(string ruta, int distancia)
        {
            heap.Add((ruta, distancia));
            Subir(heap.Count - 1);
        }

        public (string ruta, int distancia) ExtraerMinimo()
        {
            if (EstaVacio())
            {
                throw new InvalidOperationException("El heap está vacío.");
            }

            var minimo = heap[0];

            var ultimo = heap[heap.Count - 1];
            heap[0] = ultimo;
            heap.RemoveAt(heap.Count - 1);

            if (!EstaVacio())
            {
                Bajar(0);
            }

            return minimo;
        }

        public bool EstaVacio()
        {
            return heap.Count == 0;
        }

        public string MostrarRutasOrdenadasTodas()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== MIN-HEAP DE RUTAS ===");
            resultado.AppendLine("--------------------------------------------------");

            int contador = 1;
            int total = heap.Count;

            while (!EstaVacio())
            {
                var ruta = ExtraerMinimo();

                resultado.AppendLine(
                    $"{contador}°  {ruta.ruta.PadRight(28)} {ruta.distancia} metros"
                );

                contador++;
            }

            resultado.AppendLine("--------------------------------------------------");
            resultado.AppendLine("Total de rutas: " + total);

            return resultado.ToString();
        }

        public string MostrarRutasOrdenadas(string origen)
        {
            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== MIN-HEAP DE RUTAS DIRECTAS ===");
            resultado.AppendLine();
            resultado.AppendLine("Origen: " + origen);
            resultado.AppendLine();
            resultado.AppendLine("N°  Destino                              Distancia");
            resultado.AppendLine("--------------------------------------------------");

            int contador = 1;

            if (EstaVacio())
            {
                resultado.AppendLine("No hay rutas directas registradas.");
                return resultado.ToString();
            }

            while (!EstaVacio())
            {
                var ruta = ExtraerMinimo();

                string destino = ruta.ruta.PadRight(36);
                string distancia = ruta.distancia + " m";

                resultado.AppendLine($"{contador.ToString().PadRight(3)} {destino} {distancia}");

                contador++;
            }

            resultado.AppendLine();
            resultado.AppendLine("Heap vacío: todas las rutas fueron procesadas.");

            return resultado.ToString();
        }

        public string MostrarRutasOrdenadas()
        {
            return MostrarRutasOrdenadas("Biblioteca Central (A)");
        }

        private void Subir(int indice)
        {
            while (indice > 0)
            {
                int padre = (indice - 1) / 2;

                if (heap[indice].distancia >= heap[padre].distancia)
                {
                    break;
                }

                Intercambiar(indice, padre);
                indice = padre;
            }
        }

        private void Bajar(int indice)
        {
            while (true)
            {
                int hijoIzquierdo = (indice * 2) + 1;
                int hijoDerecho = (indice * 2) + 2;
                int menor = indice;

                if (hijoIzquierdo < heap.Count &&
                    heap[hijoIzquierdo].distancia < heap[menor].distancia)
                {
                    menor = hijoIzquierdo;
                }

                if (hijoDerecho < heap.Count &&
                    heap[hijoDerecho].distancia < heap[menor].distancia)
                {
                    menor = hijoDerecho;
                }

                if (menor == indice)
                {
                    break;
                }

                Intercambiar(indice, menor);
                indice = menor;
            }
        }

        private void Intercambiar(int indiceA, int indiceB)
        {
            var temporal = heap[indiceA];
            heap[indiceA] = heap[indiceB];
            heap[indiceB] = temporal;
        }
    }
}