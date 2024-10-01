////using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Torneo.Business.Abstractions;
//using Torneo.Repository.Model;
////using Torneo.Shared;
//using Torneo.Business.Abstractions;

//namespace Torneo.Api.Controllers;

//[Route("[controller]")]
//[ApiController]
//public class UtentiController
//{
//    private readonly IBusiness _business;
//    //private readonly IMapper _mapper;
//    private readonly ILogger<UtentiController> _logger;
//    //public UtentiController(IBusiness business, IMapper mapper, ILogger<UtentiController> logger)
//    public UtentiController(IBusiness business, ILogger<UtentiController> logger)
//    {
//        _business = business;
//        //_mapper = mapper;
//        _logger = logger;
//    }

//    // GET: api/Utenti
//    [HttpGet]
//        //public async Task<ActionResult<IEnumerable<Utente>>> GetUtenti()
//        //{
//        //    return await _context.Utente.ToListAsync();
//        //}

//        public async Task<IActionResult> GetUtenti()
//        {
//            var utenti = await _business.GetUtenti();
//            return new OkObjectResult(utenti);
//        }

//        // GET: api/Utenti/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Utente>> GetUtente(int id)
//        {
//            var utente = await _business.GetUtente(id);

//            if (utente == null)
//            {
//                return new NotFoundResult();
//            }

//            return utente;
//        }

//    //// POST: api/Utenti
//    //[HttpPost]
//    //public async Task<ActionResult<Utente>> PostUtente(Utente utente)
//    //{
//    //    _context.Utente.Add(utente);
//    //    await _context.SaveChangesAsync();

//    //    return CreatedAtAction("GetUtente", new { id = utente.Id }, utente);
//    //}

//    //// PUT: api/Utenti/5
//    //[HttpPut("{id}")]
//    //public async Task<IActionResult> PutUtente(int id, Utente utente)
//    //{
//    //    if (id != utente.Id)
//    //    {
//    //        return BadRequest();
//    //    }

//    //    _context.Entry(utente).State = EntityState.Modified;

//    //    try
//    //    {
//    //        await _context.SaveChangesAsync();
//    //    }
//    //    catch (DbUpdateConcurrencyException)
//    //    {
//    //        if (!UtenteExists(id))
//    //        {
//    //            return NotFound();
//    //        }
//    //        else
//    //        {
//    //            throw;
//    //        }
//    //    }

//    //    return NoContent();
//    //}

//    //// DELETE: api/Utenti/5
//    //[HttpDelete("{id}")]
//    //public async Task<IActionResult> DeleteUtente(int id)
//    //{
//    //    var utente = await _context.Utente.FindAsync(id);
//    //    if (utente == null)
//    //    {
//    //        return NotFound();
//    //    }

//    //    _context.Utente.Remove(utente);
//    //    await _context.SaveChangesAsync();

//    //    return NoContent();
//    //}

//    //private bool UtenteExists(int id)
//    //{
//    //    return _context.Utente.Any(e => e.Id == id);
//    //}

//    [HttpPost("{idUtente}/assegna-stanza/{idStanza}")]
//    public async Task<IActionResult> AssegnaUtenteAStanza(int idUtente, int idStanza)
//    {
//        await _business.AssegnaUtenteAStanza(idUtente, idStanza);
//        return new OkObjectResult("Utente assegnato alla stanza con successo.");
//    }

//    //[HttpPost("{idUtente}/esciStanza")]
//    //public async Task<IActionResult> UtenteEsceDallaStanza(int idUtente)
//    //{
//    //    UtenteBO _utenteBO = new UtenteBO(_context);
//    //    var result = await _utenteBO.UtenteEsceDallaStanza(idUtente);
//    //    if (!result)
//    //    {
//    //        return BadRequest("Utente non trovato.");
//    //    }

//    //    return Ok("Utente è uscito dalla stanza con successo.");
//    //}

//    // POST: api/Utenti/{id}/cambia-ruolo
//    [HttpPost("{id}/cambia-ruolo")]
//    public async Task<IActionResult> CambiaRuolo(int id, [FromBody] string nuovoRuolo)
//    {
//        if (nuovoRuolo.Length != 1)
//        {
//            return new BadRequestObjectResult("Il ruolo deve essere un singolo carattere.");
//        }

//        var result = await _business.CambiaRuolo(id, nuovoRuolo[0]);

//        if (!result)
//        {
//            return new BadRequestObjectResult("Errore nel cambiare il ruolo dell'utente. Verifica l'ID utente e il ruolo fornito.");
//        }

//        return new OkObjectResult("Ruolo cambiato con successo.");
//    }
//}





