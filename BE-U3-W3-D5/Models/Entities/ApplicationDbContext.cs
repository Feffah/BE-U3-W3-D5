using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BE_U3_W3_D5.Models.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventi { get; set; }

        public DbSet<Artista> Artisti { get; set; }

        public DbSet<Biglietto> Biglietti { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
