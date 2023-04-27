using System.Reflection.PortableExecutable;

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

        public void SaveReservation(Reservation reservation)
        {
            if (reservation.ReservationID == 0)
            {
                context.Reservations.Add(reservation);
            }
            else
            {
                Reservation dbEntry = context.Reservations
                .FirstOrDefault(p => p.ReservationID == reservation.ReservationID);
                if (dbEntry != null)
                {
                    dbEntry.GameMaster = reservation.GameMaster;
                    dbEntry.Description = reservation.Description;
                    dbEntry.Price = reservation.Price;
                    dbEntry.Date = reservation.Date;
                }
            }
            context.SaveChanges();
        }
        public Reservation DeleteReservation(int reservaionID)
        {
            Reservation dbEntry = context.Reservations
                .FirstOrDefault(p => p.ReservationID == reservaionID);
            if (dbEntry != null)
            {
                context.Reservations.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
