using GestioneUtente.Repository.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestioneUtente.Repository.Abstractions;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<List<Utente>?> GetUtenti();
    Task<Utente?> GetUtente(int id);
    //Task<ActionResult<Utente>> PostUtente(Utente utente);
    //Task<IActionResult> PutUtente(int id, Utente utente);
    //Task<IActionResult> DeleteUtente(int id);
    Task AssegnaUtenteAStanza(int idUtente, int idStanza);
    //Task<IActionResult> UtenteEsceDallaStanza(int idUtente);
    Task<bool> CambiaRuolo(int id, char nuovoRuolo);
    Task<bool> SpostaTuttiGliUtentiNellaStanzaPadre(int idStanza);


    //Task<List<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) => await _torneoDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);
    //Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
    //Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
    //Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);
}
