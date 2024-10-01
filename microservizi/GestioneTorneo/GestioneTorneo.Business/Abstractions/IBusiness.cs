using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GestioneTorneo.Repository.Abstractions;
using GestioneTorneo.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using GestioneTorneo.Repository;


namespace GestioneTorneo.Business.Abstractions;
public interface IBusiness

{
    Task CambiaFaseDelGioco(int idStanza, string fase_del_gioco, CancellationToken cancellationToken = default);
    //Task<List<Stanza>?> GetStanze();
    //Task<Stanza?> GetStanza(int id);
    //Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco);
    //Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco);
    //Task<Stanza?> GetStanzaPadre(int id_stanza_param);

}
