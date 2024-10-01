using GestioneStanze.Repository.Model;

namespace GestioneStanze.Repository.Abstractions;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<List<Stanza>?> GetStanze();
    Task<Stanza?> GetStanza(int id);
    Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco);
    Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco);
    Task<Stanza?> GetStanzaPadre(int id_stanza_param);
    Task<List<Utente>> GetUtentiInStanza(int id);
    Task<List<Utente>> GetGiocatoriInStanza(int id);
}
