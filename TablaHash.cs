using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampusNavegacion
{
    public class TablaHash
    {
        private Dictionary<string, int> visitas;

        public TablaHash()
        {
            visitas = new Dictionary<string, int>();
        }

        public void RegistrarVisita(string edificio)
        {
            if (visitas.ContainsKey(edificio))
            {
                visitas[edificio]++;
            }
            else
            {
                visitas[edificio] = 1;
            }
        }

        public int ObtenerConteo(string edificio)
        {
            if (visitas.ContainsKey(edificio))
            {
                return visitas[edificio];
            }

            return 0;
        }

        public string MostrarEstadisticas()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.AppendLine("=== ESTADÍSTICAS DE VISITAS ===");
            resultado.AppendLine("--------------------------------------------------");

            if (visitas.Count == 0)
            {
                resultado.AppendLine("No hay visitas registradas.");
                return resultado.ToString();
            }

            var visitasOrdenadas = visitas
                .OrderByDescending(v => v.Value)
                .ThenBy(v => v.Key)
                .ToList();

            int maxVisitas = visitasOrdenadas.Max(v => v.Value);

            foreach (var item in visitasOrdenadas)
            {
                string nombreCorto = ObtenerNombreCorto(item.Key);
                string barras = GenerarBarra(item.Value, maxVisitas);

                resultado.AppendLine(nombreCorto);
                resultado.AppendLine($"{barras}  {item.Value} visita{(item.Value == 1 ? "" : "s")}");
                resultado.AppendLine();
            }

            resultado.AppendLine("--------------------------------------------------");

            var masVisitado = visitasOrdenadas.First();

            resultado.AppendLine(
                $"Edificio más visitado: {masVisitado.Key} con {masVisitado.Value} visita{(masVisitado.Value == 1 ? "" : "s")}"
            );

            return resultado.ToString();
        }

        public string MostrarVisitas()
        {
            return MostrarEstadisticas();
        }

        public string EdificioMasVisitado()
        {
            if (visitas.Count == 0)
            {
                return "No hay visitas registradas.";
            }

            var masVisitado = visitas
                .OrderByDescending(v => v.Value)
                .ThenBy(v => v.Key)
                .First();

            return masVisitado.Key + " con " + masVisitado.Value + " visita" + (masVisitado.Value == 1 ? "" : "s");
        }

        public List<string> ObtenerClavesVisitadas()
        {
            List<string> claves = new List<string>();

            foreach (var item in visitas)
            {
                string clave = ObtenerClaveDesdeNombre(item.Key);

                if (!string.IsNullOrWhiteSpace(clave))
                {
                    claves.Add(clave);
                }
            }

            return claves;
        }

        private string GenerarBarra(int valor, int maximo)
        {
            int largoMaximo = 28;

            int cantidad = (int)Math.Round((double)valor / maximo * largoMaximo);

            if (cantidad < 1)
            {
                cantidad = 1;
            }

            return new string('█', cantidad);
        }

        private string ObtenerClaveDesdeNombre(string nombre)
        {
            if (nombre.Contains("(A)")) return "A";
            if (nombre.Contains("(B)")) return "B";
            if (nombre.Contains("(C)")) return "C";
            if (nombre.Contains("(D)")) return "D";
            if (nombre.Contains("(E)")) return "E";
            if (nombre.Contains("(F)")) return "F";
            if (nombre.Contains("(G)")) return "G";

            return "";
        }

        private string ObtenerNombreCorto(string nombre)
        {
            if (nombre.Contains("(A)")) return "Biblioteca";
            if (nombre.Contains("(B)")) return "Cafetería";
            if (nombre.Contains("(C)")) return "Laboratorio";
            if (nombre.Contains("(D)")) return "Rectoría";
            if (nombre.Contains("(E)")) return "Gimnasio";
            if (nombre.Contains("(F)")) return "Aulas";
            if (nombre.Contains("(G)")) return "Estacionam.";

            return nombre;
        }
    }
}