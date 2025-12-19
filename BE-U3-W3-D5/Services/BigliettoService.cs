using BE_U3_W3_D5.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace BE_U3_W3_D5.Services
{
    public class BigliettoService
    {
        private readonly ApplicationDbContext _context;
        public BigliettoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Biglietto>> GetAllBiglietti()
        {
            return await _context.Biglietti.AsNoTracking().ToListAsync();
        }
        public async Task<Biglietto?> GetBigliettoById(int id)
        {
            return await _context.Biglietti.AsNoTracking().FirstOrDefaultAsync(b => b.IdBiglietto == id);
        }
        public async Task<Biglietto> CreateBiglietto(Biglietto biglietto)
        {
            _context.Biglietti.Add(biglietto);
            await _context.SaveChangesAsync();
            return biglietto;
        }
        public async Task<Biglietto?> UpdateBiglietto(int id, Biglietto updatedBiglietto)
        {
            var biglietto = await _context.Biglietti.FindAsync(id);
            if (biglietto == null)
            {
                return null;
            }
            biglietto.EventoId = updatedBiglietto.EventoId;
            biglietto.DataAcquisto = updatedBiglietto.DataAcquisto;
            await _context.SaveChangesAsync();
            return biglietto;
        }
        public async Task<bool> DeleteBiglietto(int id)
        {
            var biglietto = await _context.Biglietti.FindAsync(id);
            if (biglietto == null)
            {
                return false;
            }
            _context.Biglietti.Remove(biglietto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
