using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestioneGioco.Shared
{
    public class Griglia
    {
        public int Dimensione { get; set; }
        public string[,] Celle { get; set; }
        public Dictionary<string, Nave> Navi { get; set; }

        public Griglia(int dimensione)
        {
            Dimensione = dimensione;
            Celle = new string[dimensione, dimensione];
            Navi = new Dictionary<string, Nave>();

            for (int i = 0; i < dimensione; i++)
            {
                for (int j = 0; j < dimensione; j++)
                {
                    Celle[i, j] = "~";
                }
            }
        }

        public Griglia(string json)
        {
            var grigliaData = JsonSerializer.Deserialize<GrigliaData>(json);
            Dimensione = grigliaData.Dimensione;
            Celle = new string[Dimensione, Dimensione];
            Navi = new Dictionary<string, Nave>();

            for (int i = 0; i < Dimensione; i++)
            {
                for (int j = 0; j < Dimensione; j++)
                {
                    Celle[i, j] = grigliaData.Celle[i][j];
                }
            }

            foreach (var naveKvp in grigliaData.Navi)
            {
                Navi[naveKvp.Key] = naveKvp.Value;
            }
        }

        private string CodificaTipoNave(TipoNave tipo)
        {
            return tipo switch
            {
                TipoNave.Portaerei => "P",
                TipoNave.Corazzata => "C",
                TipoNave.Incrociatore => "I",
                TipoNave.Sommergibile => "S",
                TipoNave.Cacciatorpediniere => "K",
                _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo di nave sconosciuto")
            };
        }

        private TipoNave DecodificaTipoNave(string simbolo)
        {
            return simbolo switch
            {
                "P" => TipoNave.Portaerei,
                "C" => TipoNave.Corazzata,
                "I" => TipoNave.Incrociatore,
                "S" => TipoNave.Sommergibile,
                "K" => TipoNave.Cacciatorpediniere,
                _ => throw new ArgumentOutOfRangeException(nameof(simbolo), "Simbolo di nave sconosciuto")
            };
        }

        public bool PosizioneValida(Nave nave, int startX, int startY, Orientamento orientamento)
        {
            int dx = (orientamento == Orientamento.Orizzontale) ? 0 : 1;
            int dy = (orientamento == Orientamento.Orizzontale) ? 1 : 0;

            for (int i = 0; i < nave.Lunghezza; i++)
            {
                int x = startX + i * dx;
                int y = startY + i * dy;
                if (x >= Dimensione || y >= Dimensione || Celle[x, y] != "~")
                    return false;
            }
            return true;
        }

        public bool VerificaDistanza(int startX, int startY, int lunghezza, Orientamento orientamento)
        {
            int dx = (orientamento == Orientamento.Orizzontale) ? 0 : 1;
            int dy = (orientamento == Orientamento.Orizzontale) ? 1 : 0;

            for (int i = -1; i <= lunghezza; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int x = startX + i * dx + j * dy;
                    int y = startY + i * dy + j * dx;
                    if (x >= 0 && x < Dimensione && y >= 0 && y < Dimensione && !(x == startX + i * dx && y == startY + i * dy))
                    {
                        if (Celle[x, y] != "~")
                            return false;
                    }
                }
            }
            return true;
        }

        public void AggiungiNave(Nave nave, int startX, int startY, Orientamento orientamento)
        {
            string simboloNave = CodificaTipoNave(nave.Tipo);
            string chiaveNave = $"{simboloNave}{nave.Id}";
            if (PosizioneValida(nave, startX, startY, orientamento) && VerificaDistanza(startX, startY, nave.Lunghezza, orientamento))
            {
                int dx = (orientamento == Orientamento.Orizzontale) ? 0 : 1;
                int dy = (orientamento == Orientamento.Orizzontale) ? 1 : 0;

                for (int i = 0; i < nave.Lunghezza; i++)
                {
                    Celle[startX + i * dx, startY + i * dy] = chiaveNave;
                }
                Navi[chiaveNave] = nave;
            }
            else
            {
                Console.WriteLine("Posizione non valida per la nave.");
            }
        }
        public (int, int) ConvertiMossa(string mossa)
        {
            if (string.IsNullOrWhiteSpace(mossa) || mossa.Length < 2)
            {
                throw new ArgumentException("La mossa inserita non è valida.");
            }

            // Estrarre la lettera e il numero dalla mossa
            char lettera = mossa[0];
            string numeroParte = mossa.Substring(1);

            // Convertire la lettera in numero (A => 1, B => 2, ..., Z => 26)
            int numeroRiga = char.ToUpper(lettera) - 'A' + 1;

            // Convertire la parte numerica in un intero
            if (!int.TryParse(numeroParte, out int numeroColonna))
            {
                throw new ArgumentException("La mossa inserita non è valida.");
            }

            return (numeroRiga - 1, numeroColonna - 1);
        }

        public string GestisciColpo(string coordinateColpo) 
        {
            var (colonna, riga) = ConvertiMossa(coordinateColpo);
            return GestisciColpo(riga, colonna);
        }
        public string GestisciColpo(int x, int y)
        {
            if (x < 0 || x >= Dimensione || y < 0 || y >= Dimensione)
            {
                return "Colpo fuori dalla griglia.";
            }

            string cella = Celle[x, y];
            if (cella != "~" && cella != "X" && cella != "O")
            {
                // Decodifica il tipo di nave dal simbolo nella cella
                //TipoNave tipoNave = DecodificaTipoNave(cella);
                // Costruisci la chiave della nave per accedere al dizionario Navi
                string chiaveNave = cella;

                if (Navi.ContainsKey(chiaveNave))
                {
                    Nave naveColpita = Navi[chiaveNave];
                    naveColpita.ColpiRicevuti++;
                    Celle[x, y] = "X"; // Simbolo di colpo a segno


                    if (naveColpita.EAffondata())
                    {
                        return $"Affondato {naveColpita.Tipo} ({cella})!";
                    }
                    else
                    {
                        return $"Colpito {naveColpita.Tipo} ({cella})!";
                    }

                }
            }

            Celle[x, y] = "O"; // Simbolo di colpo mancato
            return "Colpo in acqua.";
        }

        private string ConvertiEsito(string esito)
        {
            // Convertire la stringa a minuscolo per un confronto non case-sensitive
            string esitoLowerCase = esito.ToLower();

            if (esitoLowerCase.Contains("affondato") || esitoLowerCase.Contains("colpito"))
            {
                return "X";
            }
            else if (esitoLowerCase.Contains("acqua"))
            {
                return "O";
            }

            return "";
        }

        public void InserisciColpo(string coordinateColpo, string esito)
        {
            var (colonna, riga) = ConvertiMossa(coordinateColpo);
            var simbolo = ConvertiEsito(esito);
            Celle[riga, colonna] = simbolo; 
            
        }
        public void StampaGriglia()
        {
            for (int i = 0; i < Dimensione; i++)
            {
                for (int j = 0; j < Dimensione; j++)
                {
                    Console.Write(Celle[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool VintoPartita()
        {
            // Verifica se non ci sono navi nella griglia
            if (Navi == null || !Navi.Any())
            {
                return false;
            }

            // Verifica se tutte le navi sono affondate
            foreach (var naveKvp in Navi)
            {
                Nave nave = naveKvp.Value;
                if (!nave.EAffondata())
                {
                    return false;
                }
            }
            return true;
        }
        public static Griglia GrigliaIniziale()
        {
            // Crea una nuova griglia di dimensione 10x10
            Griglia griglia = new Griglia(10);

            // Crea e aggiungi la Portaerei (5 caselle) in posizione (0,0) orizzontale
            Nave portaerei = new Nave("1", TipoNave.Portaerei, 5);
            griglia.AggiungiNave(portaerei, 0, 0, Orientamento.Orizzontale);

            // Crea e aggiungi la Corazzata (4 caselle) in posizione (2,0) orizzontale
            Nave corazzata = new Nave("1", TipoNave.Corazzata, 4);
            griglia.AggiungiNave(corazzata, 2, 0, Orientamento.Orizzontale);

            // Crea e aggiungi l'Incrociatore (3 caselle) in posizione (4,0) orizzontale
            Nave incrociatore = new Nave("1", TipoNave.Incrociatore, 3);
            griglia.AggiungiNave(incrociatore, 4, 0, Orientamento.Orizzontale);

            // Crea e aggiungi il Sommergibile (3 caselle) in posizione (6,0) orizzontale
            Nave sommergibile = new Nave("1", TipoNave.Sommergibile, 3);
            griglia.AggiungiNave(sommergibile, 6, 0, Orientamento.Orizzontale);

            // Crea e aggiungi il Cacciatorpediniere (2 caselle) in posizione (8,0) orizzontale
            Nave cacciatorpediniere = new Nave("1", TipoNave.Cacciatorpediniere, 2);
            griglia.AggiungiNave(cacciatorpediniere, 8, 0, Orientamento.Orizzontale);

            // Restituisce la griglia con le navi posizionate
            return griglia;
        }

        public bool VerificaGriglia()
        {
            return true;
        }
    }

}
