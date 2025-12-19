using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_U3_W3_D5.Models.Entities
{
    public class Artista
    {        

        [Required]
        [Key]
        public int ArtistaId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genere { get; set; }

        [Required]
        public string Biografia { get; set; }

        public ICollection<Biglietto> Biglietti { get; set; } = new List<Biglietto>();

    }
}
