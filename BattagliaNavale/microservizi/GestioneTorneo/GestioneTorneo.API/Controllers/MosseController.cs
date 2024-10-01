//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GestioneGioco.Repository;
//using GestioneGioco.Repository.Model;
//using GestioneGioco.Business.Abstractions;
//using GestioneGioco.Shared;
//using Newtonsoft.Json;

//namespace GestioneGioco.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MosseController : ControllerBase
//    {
//        private readonly IBusiness _business;
//        private readonly ILogger<MosseController> _logger;

//        public MosseController(IBusiness business, ILogger<MosseController> logger)
//        {
//            _business = business;
//            _logger = logger;
//        }

//        //// GET: api/Mossa
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<Mossa>>> GetMosse()
//        //{
//        //    return await _context.Mossa.ToListAsync();
//        //}

//        //// GET: api/Mossa/5
//        //[HttpGet("{id}")]
//        //public async Task<ActionResult<Mossa>> GetMossa(int id)
//        //{
//        //    var mossa = await _context.Mossa.FindAsync(id);

//        //    if (mossa == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return mossa;
//        //}

//        //// PUT: api/Mossa/5
//        //[HttpPut("{id}")]
//        //public async Task<IActionResult> PutMossa(int id, Mossa mossa)
//        //{
//        //    if (id != mossa.Id)
//        //    {
//        //        return BadRequest();
//        //    }

//        //    var result = await _business.PutMossa(id, mossa);

            
//        //    if (!result)
//        //    {
//        //        return NotFound();
//        //    }
                
//        //    return NoContent();
//        //}

//        // POST: api/CreateMossa
//        [HttpPost("CreateMossa")]
//        public async Task<ActionResult<Mossa>> CreateMossa([FromBody] MossaRequest mossaRequest)
//        {

//            var mossaDto = new MossaDto
//            {
//                IdGrigliaPartita = mossaRequest.IdGrigliaPartita,
//                IdUtente = mossaRequest.IdUtente,
//                NumeroMossa = mossaRequest.NumeroMossa,
//                MossaEseguita = mossaRequest.MossaEseguita,
//                IdPartita = mossaRequest.IdPartita,
//                //IdUtenteAvversario = mossaRequest.IdUtenteAvversario
//            };
//            var mossa = await _business.CreateMossa(mossaDto);
           

//            // Restituisce la nuova entità creata
//            return Ok(mossa); //TO DO: da controllare i campi di ritorno
//        }

//        // POST: api/EseguiMossaSuAvversario
//        [HttpPost("EseguiMossaSuAvversario")]
//        public async Task<ActionResult<string>> EseguiMossaSuAvversario([FromBody] MossaRequest mossaRequest)
//        {

//            var mossaDto = new MossaDto
//            {
//                IdGrigliaPartita = mossaRequest.IdGrigliaPartita,
//                IdUtente = mossaRequest.IdUtente,
//                NumeroMossa = mossaRequest.NumeroMossa,
//                MossaEseguita = mossaRequest.MossaEseguita,
//                IdPartita = mossaRequest.IdPartita,
//                IdUtenteAvversario = mossaRequest.IdUtenteAvversario
//            };
//            var esito = await _business.EseguiMossaSuAvversario(mossaDto);


//            // Restituisce la nuova entità creata
//            return Ok(esito); //TO DO: da controllare i campi di ritorno
//        }

//        // POST: api/EseguiMossa
//        [HttpPost("EseguiMossa")]
//        public async Task<ActionResult<string>> EseguiMossa([FromBody] MossaRequest mossaRequest)
//        {

//            var mossaDto = new MossaDto
//            {
//                IdGrigliaPartita = mossaRequest.IdGrigliaPartita,
//                IdUtente = mossaRequest.IdUtente,
//                NumeroMossa = mossaRequest.NumeroMossa,
//                MossaEseguita = mossaRequest.MossaEseguita,
//                IdPartita = mossaRequest.IdPartita,
//                IdUtenteAvversario = mossaRequest.IdUtenteAvversario
//            };
//            var mossa = await _business.CreateMossa(mossaDto);
//            var esito = await _business.EseguiMossaSuAvversario(mossaDto);

//            // Restituisce la nuova entità creata
//            return Ok(esito); //TO DO: da controllare i campi di ritorno
//        }

//        //GET: api/VintoPartita
//        [HttpGet("VintoPartita")]

//        public async Task<ActionResult<bool>> VintoPartita(int id_utente, int id_partita)
//        {
//            var risultato = await _business.VintoPartita(id_utente, id_partita);

//            // ASP.NET Core automaticamente serializza "risultato" in JSON poiché è di tipo ActionResult<bool>
//            return Ok(risultato);
//        }


//        //// POST: api/Mossa
//        //[HttpPost]
//        //public async Task<ActionResult<Mossa>> PostMossa(Mossa mossa)
//        //{
//        //    _context.Mossa.Add(mossa);
//        //    await _context.SaveChangesAsync();

//        //    return CreatedAtAction("GetMossa", new { id = mossa.Id }, mossa);
//        //}

//        //// DELETE: api/Mossa/5
//        //[HttpDelete("{id}")]
//        //public async Task<IActionResult> DeleteMossa(int id)
//        //{
//        //    var mossa = await _context.Mossa.FindAsync(id);
//        //    if (mossa == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    _context.Mossa.Remove(mossa);
//        //    await _context.SaveChangesAsync();

//        //    return NoContent();
//        //}

//        //// GET: api/Mossa/Partita/5
//        //[HttpGet("Partita/{partitaId}")]
//        //public async Task<ActionResult<IEnumerable<Mossa>>> GetMosseByPartita(int partitaId)
//        //{
//        //    var mosse = await _context.Mossa
//        //                              .Where(m => m.GrigliaPartita.IdPartita == partitaId)
//        //                              .OrderBy(m => m.NumeroMossa)
//        //                              .ToListAsync();

//        //    if (mosse == null || !mosse.Any())
//        //    {
//        //        return NotFound();
//        //    }

//        //    return mosse;
//        //}

//        //// GET: api/Mossa/Partita/{partitaId}/Utente/{utenteId}
//        //[HttpGet("Partita/{partitaId}/Utente/{utenteId}")]
//        //public async Task<ActionResult<IEnumerable<Mossa>>> GetMosseByPartitaAndUtente(int partitaId, int utenteId)
//        //{
//        //    var mosse = await _context.Mossa
//        //                              .Where(m => m.GrigliaPartita.IdPartita == partitaId && m.IdUtente == utenteId)
//        //                              .OrderBy(m => m.NumeroMossa)
//        //                              .ToListAsync();

//        //    if (mosse == null || !mosse.Any())
//        //    {
//        //        return NotFound();
//        //    }

//        //    return mosse;
//        //}

//        //private bool MossaExists(int id)
//        //{
//        //    return _context.Mossa.Any(e => e.Id == id);
//        //}
//    }
//}
