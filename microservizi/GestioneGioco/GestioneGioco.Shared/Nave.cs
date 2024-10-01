using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Shared
{
    
    public class Nave
    {
        public string Id { get; set; }
        public TipoNave Tipo { get; set; }
        public int Lunghezza { get; set; }
        public int ColpiRicevuti { get; set; }

        public Nave(string id, TipoNave tipo, int lunghezza)
        {
            Id = id;
            Tipo = tipo;
            Lunghezza = lunghezza;
            ColpiRicevuti = 0;
        }

        public bool EAffondata()
        {
            return ColpiRicevuti >= Lunghezza;
        }
    }

}
