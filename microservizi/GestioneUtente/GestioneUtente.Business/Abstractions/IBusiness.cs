using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GestioneUtente.Repository.Abstractions;
using GestioneUtente.Repository.Model;
//using Torneo.Shared;
using Microsoft.AspNetCore.Mvc;
using GestioneUtente.Repository;

namespace GestioneUtente.Business.Abstractions;
public interface IBusiness

{
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
