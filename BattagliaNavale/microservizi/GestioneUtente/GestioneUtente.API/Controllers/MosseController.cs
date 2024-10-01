using GestioneUtente.Repository;
using GestioneUtente.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestioneUtente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MosseController : ControllerBase
    {
        private readonly GestioneUtenteDbContext _context;

        public MosseController(GestioneUtenteDbContext context)
        {
            _context = context;
        }

        // GET: api/Mossa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mossa>>> GetMosse()
        {
            return await _context.Mossa.ToListAsync();
        }

        // GET: api/Mossa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mossa>> GetMossa(int id)
        {
            var mossa = await _context.Mossa.FindAsync(id);

            if (mossa == null)
            {
                return NotFound();
            }

            return mossa;
        }

        // PUT: api/Mossa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMossa(int id, Mossa mossa)
        {
            if (id != mossa.Id)
            {
                return BadRequest();
            }

            _context.Entry(mossa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MossaExists(id))
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

        // POST: api/Mossa
        [HttpPost]
        public async Task<ActionResult<Mossa>> PostMossa(Mossa mossa)
        {
            _context.Mossa.Add(mossa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMossa", new { id = mossa.Id }, mossa);
        }

        // DELETE: api/Mossa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMossa(int id)
        {
            var mossa = await _context.Mossa.FindAsync(id);
            if (mossa == null)
            {
                return NotFound();
            }

            _context.Mossa.Remove(mossa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Mossa/Partita/5
        [HttpGet("Partita/{partitaId}")]
        public async Task<ActionResult<IEnumerable<Mossa>>> GetMosseByPartita(int partitaId)
        {
            var mosse = await _context.Mossa
                                      .Where(m => m.GrigliaPartita.IdPartita== partitaId)
                                      .OrderBy(m => m.NumeroMossa)
                                      .ToListAsync();

            if (mosse == null || !mosse.Any())
            {
                return NotFound();
            }

            return mosse;
        }

        // GET: api/Mossa/Partita/{partitaId}/Utente/{utenteId}
        [HttpGet("Partita/{partitaId}/Utente/{utenteId}")]
        public async Task<ActionResult<IEnumerable<Mossa>>> GetMosseByPartitaAndUtente(int partitaId, int utenteId)
        {
            var mosse = await _context.Mossa
                                      .Where(m => m.GrigliaPartita.IdPartita == partitaId && m.IdUtente == utenteId)
                                      .OrderBy(m => m.NumeroMossa)
                                      .ToListAsync();

            if (mosse == null || !mosse.Any())
            {
                return NotFound();
            }

            return mosse;
        }

        private bool MossaExists(int id)
        {
            return _context.Mossa.Any(e => e.Id == id);
        }
    }
}
