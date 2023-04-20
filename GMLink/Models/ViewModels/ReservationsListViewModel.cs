using System.Collections.Generic;
using GMLink.Models;

namespace GMLink.Models.ViewModels
{
    public class ReservationsListViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
