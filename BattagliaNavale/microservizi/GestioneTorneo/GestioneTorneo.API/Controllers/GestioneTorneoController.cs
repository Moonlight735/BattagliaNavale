using GestioneTorneo.Business;
using GestioneTorneo.Business.Abstractions;
//using GestioneTorneo.Shared;
using Microsoft.AspNetCore.Mvc;


namespace GestioneTorneo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestioneTorneoController : ControllerBase
    {
        private readonly IBusiness _business;
        public GestioneTorneoController (IBusiness business) 
        {
            _business = business;
        }

        [HttpGet("CambiaFaseDelGioco/{id}/{fase_del_gioco}")]

        public async Task<IActionResult> CambiaFaseDelGioco(int id, string fase_del_gioco, CancellationToken cancellationToken)
        {
            // Controllo di validità sui parametri per evitare null o valori non validi
            if (id <= 0 || string.IsNullOrEmpty(fase_del_gioco))
            {
                return BadRequest("Parametri non validi.");
            }

            await _business.CambiaFaseDelGioco(id, fase_del_gioco, cancellationToken);

            return Ok();
        }

        // ClientHttp
        //[HttpGet("CambiaFaseDelGioco/{id}/{fase_del_gioco}")]

        //public async Task<IActionResult> CambiaFaseDelGioco(int id, string fase_del_gioco, CancellationToken cancellationToken)
        //{
        //    // Controllo di validità sui parametri per evitare null o valori non validi
        //    if (id <= 0 || string.IsNullOrEmpty(fase_del_gioco))
        //    {
        //        return BadRequest("Parametri non validi.");
        //    }

        //    var result = await _business.CambiaFaseDelGioco(id, fase_del_gioco, cancellationToken);

        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return result ? Ok() : BadRequest();
        //}

        //// PUT: api/Stanze/{id}/cambia-fase
        //[HttpPut("{id}/cambia-fase")]
        //public async Task<IActionResult> CambiaFaseDelGioco(int id, [FromBody] string fase_del_gioco)
        //{
        //    var result = await _business.CambiaFaseDelGioco(id, fase_del_gioco);

        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}