using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_U3_W3_D5.Models.Entities
{
    public class Evento
    {

        [Required]
        [Key]
        public int EventoId { get; set; }

        [Required]
        public string Titolo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Luogo { get; set; }

        [ForeignKey(nameof(ArtistaId))]
        public Artista Artista { get; set; }
        public int ArtistaId { get; set; }

        public ICollection<Biglietto> Biglietti { get; set; } = new List<Biglietto>();
    }
}
