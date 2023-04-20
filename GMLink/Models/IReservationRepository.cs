using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Reservations { get; }
    }
}
