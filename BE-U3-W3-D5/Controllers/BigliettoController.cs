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
    public class BigliettoController : ControllerBase
    {
        private readonly BigliettoService _bigliettoService;

        public BigliettoController(BigliettoService bigliettoService)
        {
            _bigliettoService = bigliettoService;
        }

        [Authorize]
        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await _bigliettoService.GetAllBiglietti());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ticket/{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            return Ok(await _bigliettoService.GetBigliettoById(id));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost("ticket")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateBigliettoDto ticketDto)
        {
            var ticket = new Biglietto
            {
                EventoId = ticketDto.EventoId,
                ArtistaId = ticketDto.ArtistaId,
                UserId = ticketDto.UserId,
                DataAcquisto = ticketDto.DataAcquisto
            };
            return Ok(await _bigliettoService.CreateBiglietto(ticket)) ;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPut("ticket/{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] CreateBigliettoDto ticketDto)
        {
            var ticket = new Biglietto
            {
                EventoId = ticketDto.EventoId,
                ArtistaId = ticketDto.ArtistaId,
                UserId = ticketDto.UserId,
                DataAcquisto = ticketDto.DataAcquisto
            };
            return Ok(await _bigliettoService.UpdateBiglietto(id, ticket));
        }

        [HttpDelete("ticket/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var deleted = await _bigliettoService.DeleteBiglietto(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
