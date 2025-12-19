using System.ComponentModel.DataAnnotations;

namespace BE_U3_W3_D5.Models.Dto
{
    public class CreateArtistaDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genere { get; set; }

        [Required]
        public string Biografia { get; set; }
    }
}
