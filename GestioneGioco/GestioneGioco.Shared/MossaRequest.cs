using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Shared
{
    public class MossaRequest
    {
        public int IdGrigliaPartita { get; set; }
        public int IdUtente { get; set; }
        public int NumeroMossa { get; set; }
        public string? MossaEseguita { get; set; }
        public int IdPartita { get; set; }
        public int IdUtenteAvversario { get; set; }
    }
}
