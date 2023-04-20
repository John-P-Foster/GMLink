namespace GMLink.Models
{
    public class EFReservationRepository : IReservationRepository
    { 
        private ApplicationDbContext context;
        public EFReservationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Reservation> Reservations => context.Reservations;
    }
}
