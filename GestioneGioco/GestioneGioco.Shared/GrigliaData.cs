using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestioneGioco.Shared
{
   

    public class GrigliaData
    {
        public int Dimensione { get; set; }
        public List<List<string>> Celle { get; set; }
        public Dictionary<string, Nave> Navi { get; set; }

        public GrigliaData() { }

        public GrigliaData(Griglia griglia)
        {
            Dimensione = griglia.Dimensione;
            Celle = new List<List<string>>();
            Navi = new Dictionary<string, Nave>();

            for (int i = 0; i < Dimensione; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < Dimensione; j++)
                {
                    row.Add(griglia.Celle[i, j]);
                }
                Celle.Add(row);
            }

            foreach (var naveKvp in griglia.Navi)
            {
                Navi[naveKvp.Key] = naveKvp.Value;
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static GrigliaData FromJson(string json)
        {
            return JsonSerializer.Deserialize<GrigliaData>(json);
        }
    }
}


