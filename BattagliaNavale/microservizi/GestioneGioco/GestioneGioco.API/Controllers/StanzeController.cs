//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Torneo.Repository;
//using Torneo.Repository.Model;

//namespace Torneo.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StanzeController : ControllerBase
//    {
//        private readonly TorneoDbContext _context;

//        public StanzeController(TorneoDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Stanze
//        [HttpGet]
//        //public async Task<ActionResult<IEnumerable<Stanza>>> GetStanze()
//        //{
//        //    return await _context.Stanza.ToListAsync();
//        //}

//        public async Task<IActionResult> GetStanze()
//        {
//            var stanze = await _context.Stanza.ToListAsync();
//            return Ok(stanze);
//        }

//        // Nuovo endpoint per ottenere le stanze in una specifica fase del gioco
//        // GET: api/Stanze/fase/{fase_del_gioco}
//        [HttpGet("fase/{fase_del_gioco}")]
//        public async Task<ActionResult<IEnumerable<Stanza>>> GetStanzeNellaFase(string fase_del_gioco)
//        {
//            var stanze = await _context.Stanza
//                .Where(s => s.FaseDelGioco == fase_del_gioco)
//                .ToListAsync();

//            if (stanze == null || !stanze.Any())
//            {
//                return NotFound();
//            }

//            return Ok(stanze);
//        }

//        // Nuovo endpoint per cambiare la fase del gioco di una stanza specifica
//        // PUT: api/Stanze/{id}/cambia-fase
//        [HttpPut("{id}/cambia-fase")]
//        public async Task<IActionResult> CambiaFaseDelGioco(int id, [FromBody] string fase_del_gioco)
//        {
//            var stanza = await _context.Stanza.FindAsync(id);
//            if (stanza == null)
//            {
//                return NotFound();
//            }

//            stanza.FaseDelGioco = fase_del_gioco;
//            _context.Entry(stanza).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StanzaExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }


//        // GET: api/Stanze/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Stanza>> GetStanza(int id)
//        {
//            var stanza = await _context.Stanza.FindAsync(id);

//            if (stanza == null)
//            {
//                return NotFound();
//            }

//            return stanza;
//        }

//        // POST: api/Stanze
//        [HttpPost]
//        public async Task<ActionResult<Stanza>> PostStanza(Stanza stanza)
//        {
//            _context.Stanza.Add(stanza);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetStanza", new { id = stanza.Id }, stanza);
//        }

//        //da verificare se cancellare
//        // PUT: api/Stanze/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutStanza(int id, Stanza stanza)
//        {
//            if (id != stanza.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(stanza).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StanzaExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // DELETE: api/Stanze/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStanza(int id)
//        {
//            var stanza = await _context.Stanza.FindAsync(id);
//            if (stanza == null)
//            {
//                return NotFound();
//            }

//            _context.Stanza.Remove(stanza);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool StanzaExists(int id)
//        {
//            return _context.Stanza.Any(e => e.Id == id);
//        }

//        // Nuovo endpoint per ottenere la lista degli utenti in una stanza specifica
//        [HttpGet("/stanza/{id}/utenti")]
//        public async Task<ActionResult<IEnumerable<Utente>>> GetUtentiInStanza(int id)
//        {
//            var utenti = await _context.Utente
//            .Where(u => u.Stanza.Id == id)
//            .ToListAsync();

//            if (utenti == null || !utenti.Any())
//            {
//                return NotFound();
//            }

//            return Ok(utenti);
//        }
//    }
//}
