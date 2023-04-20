using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace GMLink.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository repository;
        public ReservationController(IReservationRepository repo)
        {
            repository = repo;
        }
        public ViewResult ListReservation() => View(repository.Reservations);
    }
}

