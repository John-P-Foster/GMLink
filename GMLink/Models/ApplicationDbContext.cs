using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GMLink.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<AppUserDetail> AppUserDetails { get; set; }
    }
}
