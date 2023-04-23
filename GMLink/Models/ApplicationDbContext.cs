using Microsoft.EntityFrameworkCore;

namespace GMLink.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
