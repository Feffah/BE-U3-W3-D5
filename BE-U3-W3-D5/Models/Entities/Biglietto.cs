using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_U3_W3_D5.Models.Entities
{
    public class Biglietto
    {

        // FK Evento
        [Required]
        public int EventoId { get; set; }
        [ForeignKey(nameof(EventoId))]
        public Evento Evento { get; set; }

        // FK Artista
        [Required]
        public int ArtistaId { get; set; }
        [ForeignKey(nameof(ArtistaId))]
        public Artista Artista { get; set; }

        // FK Utente
        [Required]
        public Guid UserId { get; set; }        
        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime DataAcquisto { get; set; }

}
}
