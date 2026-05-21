using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string MostrarVisitas()
        {
            string resultado = "";

            foreach (var item in visitas)
            {
                resultado += item.Key + ": " + item.Value + " visitas" + Environment.NewLine;
            }

            return resultado;
        }
        public string EdificioMasVisitado()
        {
            if (visitas.Count == 0)
                return "No hay visitas registradas.";

            string edificio = "";
            int maxVisitas = 0;

            foreach (var item in visitas)
            {
                if (item.Value > maxVisitas)
                {
                    maxVisitas = item.Value;
                    edificio = item.Key;
                }
            }

            return edificio + " con " + maxVisitas + " visitas";
        }
    }
}
