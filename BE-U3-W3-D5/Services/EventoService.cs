using BE_U3_W3_D5.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace BE_U3_W3_D5.Services
{
    public class EventoService
    {
        private readonly ApplicationDbContext _context;

        public EventoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> GetAllEventi()
        {
            return await _context.Eventi.AsNoTracking().ToListAsync();
        }

        public async Task<Evento?> GetEventoById(int id)
        {
            return await _context.Eventi.AsNoTracking().FirstOrDefaultAsync(e => e.EventoId == id);
        }

        public async Task<Evento> CreateEvento(Evento evento)
        {
            _context.Eventi.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<Evento?> UpdateEvento(int id, Evento updatedEvento)
        {
            var evento = await _context.Eventi.FindAsync(id);
            if (evento == null)
            {
                return null;
            }
            evento.Titolo = updatedEvento.Titolo;
            evento.Data = updatedEvento.Data;
            evento.Luogo = updatedEvento.Luogo;
            evento.ArtistaId = updatedEvento.ArtistaId;
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var evento = await _context.Eventi.FindAsync(id);
            if (evento == null)
            {
                return false;
            }
            _context.Eventi.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
