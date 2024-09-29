using GestioneUtente.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using GestioneUtente.Repository.Model;

namespace GestioneUtente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GriglieDiGiocoController : ControllerBase
    {
        private readonly GestioneUtenteDbContext _context;

        public GriglieDiGiocoController(GestioneUtenteDbContext context)
        {
            _context = context;
        }

        // POST: api/GriglieDiGioco
        [HttpPost]
        public async Task<ActionResult<GrigliaDiGioco>> PostGrigliaDiGioco([FromBody] GrigliaDiGiocoRequest grigliaDiGiocoRequest)
        {
            // Converte la griglia in una stringa JSON
            string schemaGrigliaJson = JsonConvert.SerializeObject(grigliaDiGiocoRequest.Griglia);

            // Crea una nuova entità GrigliaDiGioco
            var grigliaDiGioco = new GrigliaDiGioco
            {
                SchemaGriglia = schemaGrigliaJson
            };

            // Aggiunge l'entità al contesto e salva le modifiche
            _context.GrigliaDiGioco.Add(grigliaDiGioco);
            await _context.SaveChangesAsync();

            // Restituisce la nuova entità creata
            return CreatedAtAction("GetGrigliaDiGioco", new { id = grigliaDiGioco.Id }, grigliaDiGioco);
        }

        // GET: api/GriglieDiGioco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrigliaDiGioco>> GetGrigliaDiGioco(int id)
        {
            var grigliaDiGioco = await _context.GrigliaDiGioco.FindAsync(id);

            if (grigliaDiGioco == null)
            {
                return NotFound();
            }

            return grigliaDiGioco;
        }

        private bool GrigliaDiGiocoExists(int id)
        {
            return _context.GrigliaDiGioco.Any(e => e.Id == id);
        }

        // PUT: api/GrigliaDiGioco/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrigliaDiGioco(int id, [FromBody] GrigliaUpdateRequest request)
        {
            var existingGriglia = await _context.GrigliaDiGioco.FindAsync(id);
            if (existingGriglia == null)
            {
                return NotFound("Griglia di gioco non trovata.");
            }

            // Converte la griglia in una stringa JSON
            string schemaGrigliaJson = JsonConvert.SerializeObject(request.SchemaGriglia);

            // Update the existing griglia with the new schema
            existingGriglia.SchemaGriglia = schemaGrigliaJson;

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.GrigliaDiGioco.Any(e => e.Id == id))
                {
                    return NotFound("Griglia di gioco non trovata durante il tentativo di aggiornamento.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}

    // Classe per gestire la richiesta di griglia di gioco
    public class GrigliaDiGiocoRequest
    {
        public List<List<string>> Griglia { get; set; }
    }

    public class GrigliaUpdateRequest
    {
    //public int GrigliaDiGiocoId { get; set; }
        public List<List<string>> SchemaGriglia { get; set; }
    }

