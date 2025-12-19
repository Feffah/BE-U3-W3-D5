using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_U3_W3_D5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        [HttpGet("events")]
        public IActionResult GetEvents()
        {
            // Placeholder implementation
            return Ok(new[] { "Event 1", "Event 2", "Event 3" });
        }
        [HttpGet("event/{id}")]
        public IActionResult GetEventById(int id)
        {
            // Placeholder implementation
            return Ok($"Event {id}");
        }
        [HttpPost("event")]
        public IActionResult CreateEvent([FromBody] string eventInfo)
        {
            // Placeholder implementation
            return CreatedAtAction(nameof(GetEventById), new { id = 1 }, eventInfo);
        }
        [HttpPut("event/{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] string eventInfo)
        {
            // Placeholder implementation
            return NoContent();
        }
        [HttpDelete("event/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            // Placeholder implementation
            return NoContent();
        }
    }
}
