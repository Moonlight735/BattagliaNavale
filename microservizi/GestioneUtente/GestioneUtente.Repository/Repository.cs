using GestioneUtente.Repository;
using GestioneUtente.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
//using System.Web.Mvc;
using GestioneUtente.Repository.Abstractions;


namespace GestioneUtente.Repository;

public class Repository : IRepository
{
    private GestioneUtenteDbContext _gestioneutenteDbContext;

    private ILogger<Repository> _logger;

    public Repository(GestioneUtenteDbContext gestioneutenteDbContext, ILogger<Repository> logger)
    {
        _logger = logger;
        _gestioneutenteDbContext = gestioneutenteDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _gestioneutenteDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Utente>?> GetUtenti()
    {
        var utenti = await _gestioneutenteDbContext.Utente.ToListAsync();
        return utenti;
    }

    public async Task<Utente?> GetUtente(int id)
    {
        var utente = await _gestioneutenteDbContext.Utente.FindAsync(id);
        return utente;
    }

    //public async Task<ActionResult<Utente>> PostUtente(Utente utente)
    // {
    //     _torneoDbContext.Utente.Add(utente);
    //     await _torneoDbContext.SaveChangesAsync();

    //     return CreatedAtAction("GetUtente", new { id = utente.Id }, utente);
    // }

    // public async Task<IActionResult> PutUtente(int id, Utente utente)
    // {
    //     if (id != utente.Id)
    //     {
    //         return BadRequest();
    //     }

    //     _torneoDbContext.Entry(utente).State = EntityState.Modified;

    //     try
    //     {
    //         await _torneoDbContext.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!UtenteExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }

    //     return NoContent();
    // }

    // public async Task<IActionResult> DeleteUtente(int id)
    // {
    //     var utente = await _torneoDbContext.Utente.FindAsync(id);
    //     if (utente == null)
    //     {
    //         return NotFound();
    //     }

    //     _torneoDbContext.Utente.Remove(utente);
    //     await _torneoDbContext.SaveChangesAsync();

    //     return NoContent();
    // }

    private bool UtenteExists(int id)
    {
        return _gestioneutenteDbContext.Utente.Any(e => e.Id == id);
    }


    public async Task AssegnaUtenteAStanza(int idUtente, int idStanza)
    {
        var utente = await _gestioneutenteDbContext.Set<Utente>().FindAsync(idUtente);
        var stanza = await _gestioneutenteDbContext.Set<Stanza>().FindAsync(idStanza);

        utente.IdStanza = stanza.Id;

        _gestioneutenteDbContext.Entry(utente).State = EntityState.Modified;

        await _gestioneutenteDbContext.SaveChangesAsync();
    }


    // public async Task<IActionResult> UtenteEsceDallaStanza(int idUtente)
    // {
    //     UtenteBO _utenteBO = new UtenteBO(_context);
    //     var result = await _utenteBO.UtenteEsceDallaStanza(idUtente);
    //     if (!result)
    //     {
    //         return BadRequest("Utente non trovato.");
    //     }

    //     return Ok("Utente è uscito dalla stanza con successo.");
    // }


    public async Task<bool> CambiaRuolo(int id, char nuovoRuolo)
    {
        
        var utente = await _gestioneutenteDbContext.Set<Utente>().FindAsync(id);

        if (utente == null)
        {
            return false;
        }

        
        utente.Ruolo = nuovoRuolo;

        // Aggiorna l'utente nel database
        _gestioneutenteDbContext.Entry(utente).State = EntityState.Modified;

        try
        {
            await _gestioneutenteDbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UtenteExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }


    // Metodo per spostare tutti gli utenti nella stanza padre
    public async Task<bool> SpostaTuttiGliUtentiNellaStanzaPadre(int idStanza)
    {
        // Recupera la stanza specificata
        var stanza = await _gestioneutenteDbContext.Stanza
            .Include(s => s.StanzaPadre) // Include per caricare la stanza padre
            .FirstOrDefaultAsync(s => s.Id == idStanza);

        if (stanza == null)
        {
            // Stanza non trovata
            return false;
        }

        if (stanza.StanzaPadre == null)
        {
            // Nessuna stanza padre, impossibile spostare gli utenti
            return false;
        }

        // Recupera tutti gli utenti associati alla stanza specificata
        var utentiDaSpostare = await _gestioneutenteDbContext.Utente
            .Where(u => u.IdStanza == idStanza)
            .ToListAsync();

        if (!utentiDaSpostare.Any())
        {
            // Nessun utente da spostare
            return false;
        }

        // Aggiorna l'ID della stanza per tutti gli utenti trovati
        foreach (var utente in utentiDaSpostare)
        {
            utente.IdStanza = stanza.StanzaPadre.Id;
        }

        // Salva le modifiche nel database
        await _gestioneutenteDbContext.SaveChangesAsync();

        return true;
    }


    //public async Task<List<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) => await _torneoDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);

    //public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default)
    //{
    //    return await _torneoDbContext.TransactionalOutboxList.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    //}

    //public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default)
    //{
    //    _torneoDbContext.TransactionalOutboxList.Remove(
    //        (await GetTransactionalOutboxByKey(id, cancellationToken)) ??
    //        throw new ArgumentException($"TransactionalOutbox with id {id} not found", nameof(id)));
    //}

    //public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default)
    //{
    //    await _torneoDbContext.TransactionalOutboxList.AddAsync(transactionalOutbox);
    //}

}