using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GestioneStanze.Repository.Abstractions;
using GestioneStanze.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using GestioneStanze.Repository;

namespace GestioneStanze.Business.Abstractions;
public interface IBusiness

{
    Task<List<Stanza>?> GetStanze();
    Task<Stanza?> GetStanza(int id);
    Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco);
    Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco);
    Task<Stanza?> GetStanzaPadre(int id_stanza_param);
    Task<List<Utente>> GetUtentiInStanza(int id);
    Task<List<Utente>> GetGiocatoriInStanza(int id);

}
