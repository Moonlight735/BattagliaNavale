using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GestioneStanze.Repository.Abstractions;
using GestioneStanze.Repository.Model;


namespace GestioneStanze.Repository;

public class Repository : IRepository
{
    private GestioneStanzeDbContext _gestionestanzeDbContext;

    private ILogger<Repository> _logger;

    public Repository(GestioneStanzeDbContext gestionestanzeDbContext, ILogger<Repository> logger)
    {
        _logger = logger;
        _gestionestanzeDbContext = gestionestanzeDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _gestionestanzeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Stanza>?> GetStanze()
    {
        var stanze = await _gestionestanzeDbContext.Stanza.ToListAsync();
        return stanze;
    }


    public async Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco)
    {
        var stanze = await _gestionestanzeDbContext.Stanza
            .Where(s => s.FaseDelGioco == fase_del_gioco)
            .ToListAsync();

        return stanze;
    }


    public async Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco)
    {
        var stanza = await _gestionestanzeDbContext.Stanza.FindAsync(id);
        if (stanza == null)
        {
            return false;
        }

        stanza.FaseDelGioco = fase_del_gioco;
        _gestionestanzeDbContext.Entry(stanza).State = EntityState.Modified;

        try
        {
            await _gestionestanzeDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StanzaExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }



    public async Task<Stanza?> GetStanza(int id)
    {
        var stanza = await _gestionestanzeDbContext.Stanza.FindAsync(id);

        return stanza;
    }

    public async Task<Stanza?> GetStanzaPadre(int id_stanza_param)
    {
        // Trova la stanza con id_stanza_param
        var stanza = await _gestionestanzeDbContext.Stanza
            .FirstOrDefaultAsync(s => s.Id == id_stanza_param);

        if (stanza == null || stanza.IdStanzaPadre == null)
        {
            // Se la stanza non esiste o non ha un IdStanzaPadre, ritorna null
            return null;
        }

        // Trova la stanza padre utilizzando l'IdStanzaPadre
        var stanzaPadre = await _gestionestanzeDbContext.Stanza
            .Include(s => s.StanzeFiglie)
            .FirstOrDefaultAsync(s => s.Id == stanza.IdStanzaPadre);

        return stanzaPadre;
    }


    //public async Task<ActionResult<Stanza>> PostStanza(Stanza stanza)
    //{
    //    _context.Stanza.Add(stanza);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetStanza", new { id = stanza.Id }, stanza);
    //}


    //public async Task<IActionResult> PutStanza(int id, Stanza stanza)
    //{
    //    if (id != stanza.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(stanza).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!StanzaExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}


    //public async Task<IActionResult> DeleteStanza(int id)
    //{
    //    var stanza = await _context.Stanza.FindAsync(id);
    //    if (stanza == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Stanza.Remove(stanza);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    private bool StanzaExists(int id)
    {
        return _gestionestanzeDbContext.Stanza.Any(e => e.Id == id);
    }


    public async Task<List<Utente>> GetUtentiInStanza(int id)
    {
        var utenti = await _gestionestanzeDbContext.Utente
        .Where(u => u.Stanza.Id == id)
        .Select(u => new Utente                 //Valorizzo a null i campi non presenti nella select x non esporne il contenuto (ex. password) 
        {
            Id = u.Id,
            Username = u.Username,
            Ruolo = u.Ruolo,
            IdStanza = u.IdStanza
        })
        .ToListAsync();

        return utenti;
    }

    public async Task<List<Utente>> GetGiocatoriInStanza(int id)
    {
        var giocatori = await _gestionestanzeDbContext.Utente
        .Where(u => u.Stanza.Id == id && u.Ruolo == 'G')
        .Select(u => new Utente                 //Valorizzo a null i campi non presenti nella select x non esporne il contenuto (ex. password) 
        {
            Id = u.Id,
            Username = u.Username,
            Ruolo = u.Ruolo,
            IdStanza = u.IdStanza
        })
        .ToListAsync();

        return giocatori;
    }

}