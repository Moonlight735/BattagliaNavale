//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GestioneGioco.Repository;
//using GestioneGioco.Repository.Model;
//using GestioneGioco.Business.Abstractions;
//using GestioneGioco.Repository.Abstractions;
//using GestioneGioco.Shared;
//using Newtonsoft.Json;

//namespace GestioneGioco.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PartiteController : ControllerBase
//    {
//        private readonly IBusiness _business;
//        private readonly ILogger<PartiteController> _logger;

//        public PartiteController(IBusiness business, ILogger<PartiteController> logger)
//        {
//            _business = business;
//            _logger = logger;
//        }

//        //        // GET: api/Partita
//        //        [HttpGet]
//        //        public async Task<ActionResult<IEnumerable<Partita>>> GetPartite()
//        //        {
//        //            return await _context.Partita
//        //                .Include(p => p.Stanze)
//        //                //.Include(p => p.GrigliePartite)
//        //                .ToListAsync();
//        //        }

//        //        // GET: api/Partita/5
//        //        [HttpGet("{id}")]
//        //        public async Task<ActionResult<Partita>> GetPartita(int id)
//        //        {
//        //            var partita = await _context.Partita
//        //                .Include(p => p.Stanze)
//        //                //.Include(p => p.GrigliePartite)
//        //                .FirstOrDefaultAsync(p => p.Id == id);

//        //            if (partita == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            return partita;
//        //        }

//        //        // PUT: api/Partita/5
//        //        [HttpPut("{id}")]
//        //        public async Task<IActionResult> PutPartita(int id, Partita partita)
//        //        {
//        //            if (id != partita.Id)
//        //            {
//        //                return BadRequest();
//        //            }

//        //            _context.Entry(partita).State = EntityState.Modified;

//        //            try
//        //            {
//        //                await _context.SaveChangesAsync();
//        //            }
//        //            catch (DbUpdateConcurrencyException)
//        //            {
//        //                if (!PartitaExists(id))
//        //                {
//        //                    return NotFound();
//        //                }
//        //                else
//        //                {
//        //                    throw;
//        //                }
//        //            }

//        //            return NoContent();
//        //        }

//        //        // POST: api/Partita
//        //        [HttpPost]
//        //        public async Task<ActionResult<Partita>> PostPartita(Partita partita)
//        //        {
//        //            _context.Partita.Add(partita);
//        //            await _context.SaveChangesAsync();

//        //            return CreatedAtAction("GetPartita", new { id = partita.Id }, partita);
//        //        }

//        //        // DELETE: api/Partita/5
//        //        [HttpDelete("{id}")]
//        //        public async Task<IActionResult> DeletePartita(int id)
//        //        {
//        //            var partita = await _context.Partita.FindAsync(id);
//        //            if (partita == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            _context.Partita.Remove(partita);
//        //            await _context.SaveChangesAsync();

//        //            return NoContent();
//        //        }

//        // POST: api/CreatePartita
//        [HttpPost("CreatePartita")]
//        public async Task<ActionResult<Partita>> CreatePartita()
//        {
            
//            var partita = await _business.CreatePartita();

//            // Restituisce la nuova entità creata
//            return Ok(partita); 
//        }

//        // GET: api/Partita/5/GrigliePartita
//        [HttpGet("{id}/GrigliePartita")]
//        public async Task<ActionResult<IEnumerable<GrigliaPartita>>> GetGrigliePartitaByPartita(int id)
//        {
//            var grigliePartita = await _business.GetGrigliePartitaByPartita(id);
                
//            if (grigliePartita == null || !grigliePartita.Any())
//            {
//                return NotFound();
//            }

//            return grigliePartita;
//        }

//        // GET: api/Partita/GrigliaPartita?id_partita=1&id_utente=1
//        [HttpGet("GetGrigliaPartitaByPartitaAndUtente")]
//        public async Task<ActionResult<GrigliaPartita>> GetGrigliaPartitaByPartitaAndUtente(int id_partita, int id_utente)
//        {
//            var grigliaPartita = await _business.GetGrigliaPartitaByPartitaAndUtente(id_partita, id_utente);

//            if (grigliaPartita == null)
//            {
//                return NotFound();
//            }

//            return grigliaPartita;
//        }

//        //        // GET: api/Partita/5/Stanza
//        //        [HttpGet("{id}/Stanza")]
//        //        public async Task<ActionResult<Stanza>> GetStanzaByPartita(int id)
//        //        {
//        //            var stanza = await _context.Stanza
//        //                .FirstOrDefaultAsync(s => s.Id == id);

//        //            if (stanza == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            return stanza;
//        //        }

//        //        private bool PartitaExists(int id)
//        //        {
//        //            return _context.Partita.Any(e => e.Id == id);
//        //        }
//    }
//}