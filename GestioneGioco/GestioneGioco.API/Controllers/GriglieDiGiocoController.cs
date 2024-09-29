using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using GestioneGioco.Repository;
using GestioneGioco.Repository.Model;
using GestioneGioco.Business.Abstractions;
using GestioneGioco.Api.Controllers;
using GestioneGioco.Shared;

namespace GestioneGioco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GriglieDiGiocoController : ControllerBase
    {
        private readonly IBusiness _business;
        private readonly ILogger<GriglieDiGiocoController> _logger;
        public GriglieDiGiocoController(IBusiness business, ILogger<GriglieDiGiocoController> logger)
        {
            _business = business;
            _logger = logger;
        }
        // POST: api/CreateGrigliaDiGioco
        [HttpPost("CreateGrigliaDiGioco")]
        public async Task<ActionResult> CreateGrigliaDiGioco([FromBody] GrigliaDiGiocoRequest grigliaDiGiocoRequest)
        {
            // Converte la griglia in una stringa JSON
            string schemaGrigliaJson = JsonConvert.SerializeObject(grigliaDiGiocoRequest.Griglia);

            var grigliaDiGiocoDto = new GrigliaDiGiocoDto { GrigliaDiGioco = schemaGrigliaJson };
            var grigliaDiGioco = await _business.CreateGrigliaDiGioco(grigliaDiGiocoDto);

            // Restituisce la nuova entità creata
            return new OkObjectResult(grigliaDiGioco); //TO DO: da controllare i campi di ritorno
        }

//        // GET: api/GriglieDiGioco/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<GrigliaDiGioco>> GetGrigliaDiGioco(int id)
//        {
//            var grigliaDiGioco = await _context.GrigliaDiGioco.FindAsync(id);

//            if (grigliaDiGioco == null)
//            {
//                return NotFound();
//            }

//            return grigliaDiGioco;
//        }

//        private bool GrigliaDiGiocoExists(int id)
//        {
//            return _context.GrigliaDiGioco.Any(e => e.Id == id);
//        }

//        // PUT: api/GrigliaDiGioco/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateGrigliaDiGioco(int id, [FromBody] GrigliaUpdateRequest request)
//        {
//            var existingGriglia = await _context.GrigliaDiGioco.FindAsync(id);
//            if (existingGriglia == null)
//            {
//                return NotFound("Griglia di gioco non trovata.");
//            }

//            // Converte la griglia in una stringa JSON
//            string schemaGrigliaJson = JsonConvert.SerializeObject(request.SchemaGriglia);

//            // Update the existing griglia with the new schema
//            existingGriglia.SchemaGrigliaAvversario = schemaGrigliaJson;

//            // Save changes to the database
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!_context.GrigliaDiGioco.Any(e => e.Id == id))
//                {
//                    return NotFound("Griglia di gioco non trovata durante il tentativo di aggiornamento.");
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }
  
    //public class GrigliaUpdateRequest
    //{
    ////public int GrigliaDiGiocoId { get; set; }
    //    public List<List<string>> SchemaGriglia { get; set; }
    //}
  }
}
