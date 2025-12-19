using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_U3_W3_D5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettoController : ControllerBase
    {
        [HttpGet("tickets")]
        public IActionResult GetTickets()
        {
            // Placeholder implementation
            return Ok(new[] { "Ticket 1", "Ticket 2", "Ticket 3" });
        }

        [HttpGet("ticket/{id}")]
        public IActionResult GetTicketById(int id)
        {
            // Placeholder implementation
            return Ok($"Ticket {id}");
        }

        [HttpPost("ticket")]
        public IActionResult CreateTicket([FromBody] string ticketInfo)
        {
            // Placeholder implementation
            return CreatedAtAction(nameof(GetTicketById), new { id = 1 }, ticketInfo);
        }

        [HttpPut("ticket/{id}")]
        public IActionResult UpdateTicket(int id, [FromBody] string ticketInfo)
        {
            // Placeholder implementation
            return NoContent();
        }

        [HttpDelete("ticket/{id}")]
        public IActionResult DeleteTicket(int id)
        {
            // Placeholder implementation
            return NoContent();
        }
    }
}
