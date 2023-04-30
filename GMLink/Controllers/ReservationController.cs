using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using GMLink.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GMLink.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository repository;
        private UserManager<AppUser> userManager;

        public ReservationController(IReservationRepository repo, UserManager<AppUser> userMgr)
        {
            repository = repo;
            userManager = userMgr;
            
        }
        public ViewResult ListReservation() => View(repository.Reservations
            .OrderBy(p => p.ReservationID));

        public ViewResult FilterReservation(string SearchTerm) => View(repository.Reservations
            .OrderBy(p => p.ReservationID));

        [Authorize] 
        public ViewResult EditReservations(int reservationId) =>
        View(repository.Reservations
        .FirstOrDefault(p => p.ReservationID == reservationId));

        [Authorize]
        public ViewResult myReservations() => View(repository.Reservations);

        
        [HttpPost]
        public IActionResult EditReservations(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                repository.SaveReservation(reservation);
                TempData["message"] = $"{reservation.ReservationID} has been saved";
                return RedirectToAction("myReservations");
            }
            else
            {
                // there is something wrong with the data values
                return View(reservation);
            }
        }
        [Authorize]
        public ViewResult CreateReservation() => View("EditReservations", new Reservation());

        [HttpPost]
        public IActionResult DeleteReservation(int reservationId)
        {
            Reservation deletedReservation = repository.DeleteReservation(reservationId);
            if (deletedReservation != null)
            {
                TempData["message"] = $"{deletedReservation.ReservationID} deleted";
            }
            return RedirectToAction("myReservations");
        }

    }
}

