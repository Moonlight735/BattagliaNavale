using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneUtente.ClientHttp.Abstractions;
public interface IClientHttp
{
    Task<bool> CambiaRuolo(int id, char nuovoRuolo, CancellationToken cancellationToken = default);
}

