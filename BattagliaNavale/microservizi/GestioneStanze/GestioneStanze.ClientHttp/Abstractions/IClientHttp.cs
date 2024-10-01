using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneStanze.ClientHttp.Abstractions;
public interface IClientHttp
{
    Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco, CancellationToken cancellationToken = default);
}

