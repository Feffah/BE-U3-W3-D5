
using BE_U3_W3_D5.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE_U3_W3_D5.Services
{
    public class ArtistaService
    {
        private readonly ApplicationDbContext _context;

        public ArtistaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Artista>> GetAllArtisti()
        {
            return await _context.Artisti.AsNoTracking().ToListAsync();
        }

        public async Task<Artista?> GetArtistaById(int id)
        {
            return await _context.Artisti.AsNoTracking().FirstOrDefaultAsync(a => a.ArtistaId == id);
        }

        public async Task<Artista> CreateArtista(Artista artista)
        {
            _context.Artisti.Add(artista);
            await _context.SaveChangesAsync();
            return artista;
        }

        public async Task<Artista?> UpdateArtista(int id, Artista updatedArtista)
        {
            var artista = await _context.Artisti.FindAsync(id);
            if (artista == null)
            {
                return null;
            }
            artista.Nome = updatedArtista.Nome;
            artista.Genere = updatedArtista.Genere;
            await _context.SaveChangesAsync();
            return artista;
        }

        public async Task<bool> DeleteArtista(int id)
        {
            var artista = await _context.Artisti.FindAsync(id);
            if (artista == null)
            {
                return false;
            }
            _context.Artisti.Remove(artista);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
