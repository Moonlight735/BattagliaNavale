using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneStanze.Repository;
using GestioneStanze.Repository.Model;
using GestioneStanze.Business.Abstractions;

namespace GestioneStanze.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StanzeController : ControllerBase
    {
        
        private readonly IBusiness _business;
        
        private readonly ILogger<StanzeController> _logger;
        
        public StanzeController(IBusiness business, ILogger<StanzeController> logger)
        {
            _business = business;
            
            _logger = logger;
        }

        

        // GET: api/Stanze
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Stanza>>> GetStanze()
        //{
        //    return await _context.Stanza.ToListAsync();
        //}

        public async Task<IActionResult> GetStanze()
        {
            var stanze = await _business.GetStanze();
            return Ok(stanze);
        }

        // GET: api/Stanze/fase/{fase_del_gioco}
        [HttpGet("fase/{fase_del_gioco}")]
        public async Task<IActionResult> GetStanzeNellaFase(string fase_del_gioco)
        {
            var stanze = await _business.GetStanzeNellaFase(fase_del_gioco);

            if (stanze == null || !stanze.Any())
            {
                return NotFound();
            }

            return Ok(stanze);
        }

        // PUT: api/{id}/cambia-fase
        [HttpPut("{id}/cambia-fase")]
        public async Task<IActionResult> CambiaFaseDelGioco(int id, [FromBody] string fase_del_gioco)
        {
            var result = await _business.CambiaFaseDelGioco(id, fase_del_gioco);

            if (!result)
            {
                return NotFound("pippo");
            }

            return Ok(result);
        }


        // GET: api/Stanze/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stanza>> GetStanza(int id)
        {
            var stanza = await _business.GetStanza(id);

            if (stanza == null)
            {
                return NotFound();
            }

            return stanza;
        }

        // GET: api/GetStanzaPadre
        [HttpGet("stanza-padre/{id_stanza_param}")]
        public async Task<ActionResult<Stanza?>> GetStanzaPadre(int id_stanza_param)
        {
            var stanzaPadre = await _business.GetStanzaPadre(id_stanza_param);

            if (stanzaPadre == null)
            { 
                return NotFound();
            }

            return stanzaPadre;
        }
        // POST: api/Stanze
        //[HttpPost]
        //public async Task<ActionResult<Stanza>> PostStanza(Stanza stanza)
        //{
        //    _context.Stanza.Add(stanza);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStanza", new { id = stanza.Id }, stanza);
        //}

        ////da verificare se cancellare
        //// PUT: api/Stanze/5
        //[HttpPut("{id}")]
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

        //// DELETE: api/Stanze/5
        //[HttpDelete("{id}")]
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

        //private bool StanzaExists(int id)
        //{
        //    return _context.Stanza.Any(e => e.Id == id);
        //}

        // GET: api/GetUtentiInStanza
        [HttpGet("/stanza/{id}/utenti")]
        public async Task<ActionResult<IEnumerable<Utente>>> GetUtentiInStanza(int id)
        {
            var utenti = await _business.GetUtentiInStanza(id);

            if (utenti == null || !utenti.Any())
            {
                return NotFound();
            }

            return Ok(utenti);
        }

        // GET: api/GetGiocatoriInStanza
        [HttpGet("/stanza/{id}/giocatori")]
        public async Task<ActionResult<IEnumerable<Utente>>> GetGiocatoriInStanza(int id)
        {
            var giocatori = await _business.GetGiocatoriInStanza(id);

            if (giocatori == null || !giocatori.Any())
            {
                return NotFound();
            }

            return Ok(giocatori);
        }
    }
}
