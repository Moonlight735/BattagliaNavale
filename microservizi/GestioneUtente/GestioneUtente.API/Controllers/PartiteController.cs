using GestioneUtente.Repository;
using GestioneUtente.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestioneUtente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiteController : ControllerBase
    {
        private readonly GestioneUtenteDbContext _context;

        public PartiteController(GestioneUtenteDbContext context)
        {
            _context = context;
        }

        // GET: api/Partita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partita>>> GetPartite()
        {
            return await _context.Partita
                .Include(p => p.Stanze)
                //.Include(p => p.GrigliePartite)
                .ToListAsync();
        }

        // GET: api/Partita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partita>> GetPartita(int id)
        {
            var partita = await _context.Partita
                .Include(p => p.Stanze)
                //.Include(p => p.GrigliePartite)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (partita == null)
            {
                return NotFound();
            }

            return partita;
        }

        // PUT: api/Partita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartita(int id, Partita partita)
        {
            if (id != partita.Id)
            {
                return BadRequest();
            }

            _context.Entry(partita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Partita
        [HttpPost]
        public async Task<ActionResult<Partita>> PostPartita(Partita partita)
        {
            _context.Partita.Add(partita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartita", new { id = partita.Id }, partita);
        }

        // DELETE: api/Partita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartita(int id)
        {
            var partita = await _context.Partita.FindAsync(id);
            if (partita == null)
            {
                return NotFound();
            }

            _context.Partita.Remove(partita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Partita/5/GrigliePartita
        [HttpGet("{id}/GrigliePartita")]
        public async Task<ActionResult<IEnumerable<GrigliaPartita>>> GetGrigliePartitaByPartita(int id)
        {
            var grigliePartita = await _context.GrigliaPartita
                .Where(gp => gp.Id == id)
                .ToListAsync();

            if (grigliePartita == null || !grigliePartita.Any())
            {
                return NotFound();
            }

            return grigliePartita;
        }

        // GET: api/Partita/5/Stanza
        [HttpGet("{id}/Stanza")]
        public async Task<ActionResult<Stanza>> GetStanzaByPartita(int id)
        {
            var stanza = await _context.Stanza
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stanza == null)
            {
                return NotFound();
            }

            return stanza;
        }

        private bool PartitaExists(int id)
        {
            return _context.Partita.Any(e => e.Id == id);
        }
    }
}