using BE_U3_W3_D5.Models.Dto;
using BE_U3_W3_D5.Models.Entities;
using BE_U3_W3_D5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_U3_W3_D5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _eventoService;
        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {

            return Ok(await _eventoService.GetAllEventi());
        }
        [HttpGet("event/{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            return Ok(await _eventoService.GetEventoById(id));
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("event")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventoDto eventoDto)
        {
            var evento = new Evento
            {
                Titolo = eventoDto.Titolo,
                Data = eventoDto.Data,
                Luogo = eventoDto.Luogo,
                ArtistaId = eventoDto.ArtistaId
            };
            return Ok(await _eventoService.CreateEvento(evento));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("event/{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] CreateEventoDto eventoDto)
        {
            var evento = new Evento
            {
                Titolo = eventoDto.Titolo,
                Data = eventoDto.Data,
                Luogo = eventoDto.Luogo,
                ArtistaId = eventoDto.ArtistaId
            };
            return Ok(await _eventoService.UpdateEvento(id, evento));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("event/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var deleted =  _eventoService.DeleteEvento(id);
            if (!deleted.Result)
                return NotFound();
            return NoContent();
        }
    }
}
