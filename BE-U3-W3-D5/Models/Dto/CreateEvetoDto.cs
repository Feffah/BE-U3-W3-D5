using System.ComponentModel.DataAnnotations;

namespace BE_U3_W3_D5.Models.Dto
{
    public class CreateEventoDto
    {
        [Required]
        public string Titolo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Luogo { get; set; }

        [Required]
        public int ArtistaId { get; set; }
    }

}
