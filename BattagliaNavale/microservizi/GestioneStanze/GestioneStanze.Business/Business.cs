//using Torneo.Business.Factory;
using GestioneStanze.Business.Abstractions;
using GestioneStanze.Repository.Abstractions;
using GestioneStanze.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneStanze.Business;
using GestioneStanze.Repository;


namespace GestioneStanze.Business;

public class Business : IBusiness
{
    private readonly IRepository _repository;
    
    public Business(IRepository repository)
    {
        
        _repository = repository;
    }

    public async Task<List<Stanza>?> GetStanze()
    {
        var stanze = await _repository.GetStanze();
        return stanze;
    }

    public async Task<Stanza?> GetStanza(int id)
    {
        var stanza = await _repository.GetStanza(id);
        return stanza;
    }
    public async Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco)
    {
        var stanze = await _repository.GetStanzeNellaFase(fase_del_gioco);
        return stanze;
    }

    public async Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco)
    {
        var result = await _repository.CambiaFaseDelGioco(id, fase_del_gioco);
        return result;
    }
    public async Task<Stanza?> GetStanzaPadre(int id_stanza_param)
    {
        var stanzaPadre = await _repository.GetStanzaPadre(id_stanza_param);
        return stanzaPadre;
    }

    public async Task<List<Utente>> GetUtentiInStanza(int id)
    {
        var utenti = await _repository.GetUtentiInStanza(id);
        return utenti;
    }

    public async Task<List<Utente>> GetGiocatoriInStanza(int id)
    {
        var giocatori = await _repository.GetGiocatoriInStanza(id);
        return giocatori;
    }
}
