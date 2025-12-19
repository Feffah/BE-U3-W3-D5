using BE_U3_W3_D5.Models.Entities;
using BE_U3_W3_D5.Models.Dto;
using BE_U3_W3_D5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BE_U3_W3_D5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private readonly ArtistaService _artistaService;
        public ArtistaController(ArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        [HttpGet("artists")]
        public async Task<IActionResult> GetArtists()
        {
            return Ok(await _artistaService.GetAllArtisti()) ;
        }

        [HttpGet("artist/{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            return Ok(await _artistaService.GetArtistaById(id));
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("artist")]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistaDto artistDto)
        {
            var artist = new Artista
            {
                Nome = artistDto.Nome,
                Genere = artistDto.Genere,
                Biografia = artistDto.Biografia
            };
            return Ok(await _artistaService.CreateArtista(artist));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("artist/{id}")]
            public async Task<IActionResult> UpdateArtist(int id, [FromBody] CreateArtistaDto artistDto)
        {
            var artist = new Artista
            {
                Nome = artistDto.Nome,
                Genere = artistDto.Genere,
                Biografia = artistDto.Biografia
            };
            return Ok(await _artistaService.UpdateArtista(id, artist));
           }

        [Authorize(Roles = "Admin")]
        [HttpDelete("artist/{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var deleted = await _artistaService.DeleteArtista(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
