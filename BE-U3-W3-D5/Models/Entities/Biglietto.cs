using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_U3_W3_D5.Models.Entities
{
    public class Biglietto
    {
        [Key]
        public int IdBiglietto { get; set; }
        // FK Evento
        [Required]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        // FK Artista
        [Required]
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }

        // FK Utente
        [Required]
        public string UserId { get; set; }        
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }

}
}
