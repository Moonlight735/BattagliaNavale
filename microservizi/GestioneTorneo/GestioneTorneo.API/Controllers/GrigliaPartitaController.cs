//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GestioneGioco.Repository;
//using GestioneGioco.Repository.Model;
//using GestioneGioco.Business.Abstractions;
//using GestioneGioco.Repository.Abstractions;
//using GestioneGioco.Shared;

//namespace GestioneGioco.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GrigliaPartitaController : ControllerBase
//    {
//        private readonly IBusiness _business;
    
//        private readonly ILogger<GrigliaPartitaController> _logger;
        
//        public GrigliaPartitaController(IBusiness business, ILogger<GrigliaPartitaController> logger)
//        {
//            _business = business;
            
//            _logger = logger;
//        }

//        //        // GET: api/GrigliaPartita
//        //        [HttpGet]
//        //        public async Task<ActionResult<IEnumerable<GrigliaPartita>>> GetGrigliePartite()
//        //        {
//        //            return await _context.GrigliaPartita
//        //                                 .Include(g => g.GrigliaDiGioco)
//        //                                 .Include(g => g.Partita)
//        //                                 .Include(g => g.Utente)
//        //                                 .Include(g => g.Mosse)
//        //                                 .ToListAsync();
//        //        }

//        //        // POST: api/GrigliaPartita/Create
//        //        [HttpPost("Create")]
//        //        public async Task<ActionResult<GrigliaPartita>> CreateGrigliaPartita(int id_utente, int id_partita, int id_griglia_di_gioco, string? schema_griglia_iniziale = null)
//        //        {
//        //            var grigliaPartita = new GrigliaPartita
//        //            {
//        //                IdUtente = id_utente,
//        //                IdPartita = id_partita,
//        //                IdGrigliaDiGioco = id_griglia_di_gioco,
//        //                SchemaGrigliaIniziale = schema_griglia_iniziale
//        //            };

//        //            _context.GrigliaPartita.Add(grigliaPartita);
//        //            await _context.SaveChangesAsync();

//        //            return CreatedAtAction(nameof(GetGrigliaPartita), new { id = grigliaPartita.Id }, grigliaPartita);
//        //        }


//        // GET: api/GrigliaPartita/5
//        [HttpGet("{id}")]
//            public async Task<ActionResult<GrigliaPartita>> GetGrigliaPartita(int id)
//            {
//                var grigliaPartita = await _business.GetGrigliaPartita(id);
                                                   

//                if (grigliaPartita == null)
//                {
//                    return NotFound();
//                }

//                return new OkObjectResult(grigliaPartita);
//            }

//        // GET: api/VerificaGrigliaPartita/5
//        [HttpGet("VerificaGrigliaPartita/{id}")]
//            public async Task<ActionResult<bool>> VerificaGrigliaPartita(int id)
//            {
//                var esito = await _business.VerificaGrigliaPartita(id);
            
//                return Ok(esito);
//            }

//        //        // GET: api/GrigliaPartita/ByPartita/5
//        //        [HttpGet("ByPartita/{id_partita}")]
//        //        public async Task<ActionResult<IEnumerable<GrigliaPartita>>> GetGrigliaPartitaByPartitaId(int id_partita)
//        //        {
//        //            var grigliePartita = await _context.GrigliaPartita
//        //                                               .Include(g => g.GrigliaDiGioco)
//        //                                               .Include(g => g.Partita)
//        //                                               //.Include(g => g.Utente)
//        //                                               .Include(g => g.Mosse)
//        //                                               .Where(g => g.IdPartita == id_partita)
//        //                                               .ToListAsync();

//        //            if (grigliePartita == null || !grigliePartita.Any())
//        //            {
//        //                return NotFound();
//        //            }

//        //            return grigliePartita;
//        //        }

//        //        // GET: api/GrigliaPartita/GrigliaDiGioco?utenteId=1&partitaId=1
//        //        [HttpGet("GrigliaDiGioco")]
//        //        public async Task<ActionResult<GrigliaDiGioco>> GetGrigliaDiGiocoByUtenteIdAndPartitaId(int utenteId, int partitaId)
//        //        {
//        //            var grigliaPartita = await _context.GrigliaPartita
//        //                                               .Include(g => g.GrigliaDiGioco)
//        //                                               .FirstOrDefaultAsync(g => g.IdUtente == utenteId && g.IdPartita == partitaId);

//        //            if (grigliaPartita == null || grigliaPartita.GrigliaDiGioco == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            return grigliaPartita.GrigliaDiGioco;
//        //        }

//        //        // GET: api/GrigliaPartita/Utente/5
//        //        [HttpGet("Utente/{id_griglia_partita}")]
//        //        public async Task<ActionResult<Utente>> GetUtenteByGrigliaPartitaId(int id_griglia_partita)
//        //        {
//        //            var grigliaPartita = await _context.GrigliaPartita
//        //                                               .Include(g => g.Utente)
//        //                                               .FirstOrDefaultAsync(g => g.Id == id_griglia_partita);

//        //            if (grigliaPartita == null || grigliaPartita.Utente == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            return grigliaPartita.Utente;
//        //        }

//        //        // GET: api/GrigliaPartita/Partita/5
//        //        [HttpGet("Partita/{id_griglia_partita}")]
//        //        public async Task<ActionResult<Partita>> GetPartitaByGrigliaPartitaId(int id_griglia_partita)
//        //        {
//        //            var grigliaPartita = await _context.GrigliaPartita  
//        //                                               .Include(g => g.Partita)
//        //                                               .FirstOrDefaultAsync(g => g.Id == id_griglia_partita);

//        //            if (grigliaPartita == null || grigliaPartita.Partita == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            return grigliaPartita.Partita;
//        //        }

//        //        // PUT: api/GrigliaPartita/5
//        //        [HttpPut("{id}")]
//        //        public async Task<IActionResult> PutGrigliaPartita(int id, GrigliaPartita grigliaPartita)
//        //        {
//        //            if (id != grigliaPartita.Id)
//        //            {
//        //                return BadRequest();
//        //            }

//        //            _context.Entry(grigliaPartita).State = EntityState.Modified;

//        //            try
//        //            {
//        //                await _context.SaveChangesAsync();
//        //            }
//        //            catch (DbUpdateConcurrencyException)
//        //            {
//        //                if (!GrigliaPartitaExists(id))
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

//        //        // POST: api/GrigliaPartita
//        //        [HttpPost]
//        //        public async Task<ActionResult<GrigliaPartita>> PostGrigliaPartita(GrigliaPartita grigliaPartita)
//        //        {
//        //            _context.GrigliaPartita.Add(grigliaPartita);
//        //            await _context.SaveChangesAsync();

//        //            return CreatedAtAction(nameof(GetGrigliaPartita), new { id = grigliaPartita.Id }, grigliaPartita);
//        //        }

//        //        // DELETE: api/GrigliaPartita/5
//        //        [HttpDelete("{id}")]
//        //        public async Task<IActionResult> DeleteGrigliaPartita(int id)
//        //        {
//        //            var grigliaPartita = await _context.GrigliaPartita.FindAsync(id);
//        //            if (grigliaPartita == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            _context.GrigliaPartita.Remove(grigliaPartita);
//        //            await _context.SaveChangesAsync();

//        //            return NoContent();
//        //        }

//        //        private bool GrigliaPartitaExists(int id)
//        //        {
//        //            return _context.GrigliaPartita.Any(e => e.Id == id);
//        //        }
//    }
//}
