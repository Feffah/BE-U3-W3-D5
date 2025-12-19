using BE_U3_W3_D5.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BE_U3_W3_D5.Models.Dto
{
    public class CreateBigliettoDto
    {
        [Required]
        public int EventoId { get; set; }

        [Required]
        public int ArtistaId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }
    }
}
