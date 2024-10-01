//using AutoMapper;
using GestioneUtente.Business.Abstractions;
using GestioneUtente.Repository.Abstractions;
using GestioneUtente.Repository.Model;
//using Torneo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneUtente.Business;
using GestioneUtente.Repository;
using Microsoft.Extensions.Logging;


namespace GestioneUtente.Business;

public class Business : IBusiness
{
    private readonly IRepository _repository;
    private readonly ILogger<Business> _logger;
    //private readonly IMapper _mapper;

    //public Business(IRepository repository, IMapper mapper)
    public Business(IRepository repository, ILogger<Business> logger)
    {
        //_mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<Utente>?> GetUtenti()
    {
        var utenti = await _repository.GetUtenti();
        return utenti;
    }

    public async Task<Utente?> GetUtente(int id)
    {
        var utente = await _repository.GetUtente(id);
        return utente;
    }

    //public async Task<ActionResult<Utente>> PostUtente(Utente utente)
    //{
    //    _torneoDbContext.Utente.Add(utente);
    //    await _torneoDbContext.SaveChangesAsync();

    //    return CreatedAtAction("GetUtente", new { id = utente.Id }, utente);
    //}

    //public async Task<IActionResult> PutUtente(int id, Utente utente)
    //{
    //    if (id != utente.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _torneoDbContext.Entry(utente).State = EntityState.Modified;

    //    try
    //    {
    //        await _torneoDbContext.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!UtenteExists(id))
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

    //public async Task<IActionResult> DeleteUtente(int id)
    //{
    //    var utente = await _torneoDbContext.Utente.FindAsync(id);
    //    if (utente == null)
    //    {
    //        return NotFound();
    //    }

    //    _torneoDbContext.Utente.Remove(utente);
    //    await _torneoDbContext.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool UtenteExists(int id)
    //{
    //    return _torneoDbContext.Utente.Any(e => e.Id == id);
    //}


    public async Task AssegnaUtenteAStanza(int idUtente, int idStanza)
    {
        await _repository.AssegnaUtenteAStanza(idUtente, idStanza);
    }


    //public async Task<IActionResult> UtenteEsceDallaStanza(int idUtente)
    //{
    //    UtenteBO _utenteBO = new UtenteBO(_context);
    //    var result = await _utenteBO.UtenteEsceDallaStanza(idUtente);
    //    if (!result)
    //    {
    //        return BadRequest("Utente non trovato.");
    //    }

    //    return Ok("Utente è uscito dalla stanza con successo.");
    //}


    public async Task<bool> CambiaRuolo(int id, char nuovoRuolo)
    {
      return await _repository.CambiaRuolo(id, nuovoRuolo);
    }

    // Metodo per spostare tutti gli utenti nella stanza padre
    
    public async Task<bool> SpostaTuttiGliUtentiNellaStanzaPadre(int idStanza)
    {
        try
        {
            // Chiama il metodo del repository per spostare gli utenti
            return await _repository.SpostaTuttiGliUtentiNellaStanzaPadre(idStanza);
        }
        catch (Exception ex)
        {
            // Utilizza il logger per registrare l'errore
            _logger.LogError(ex, $"Errore durante lo spostamento degli utenti dalla stanza con ID {idStanza} alla stanza padre.");
            return false;
        }
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
