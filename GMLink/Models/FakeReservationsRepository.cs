using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class FakeReservationsRepository /* : IReservationRepository */
    {
        public IEnumerable<Reservation> Reservations => new List<Reservation> {
            new Reservation { ReservationID = 1, Description = "D&D. Upto 4 players", Price = 25 },
            new Reservation { ReservationID = 2, Description = "D&D. No party limit", Price = 179 },
            new Reservation { ReservationID = 3, Description = "Pathfinder. 4 player limit", Price = 95 }
        };
    }
}
