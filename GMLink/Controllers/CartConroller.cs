using System.Linq;
using GMLink.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMLink.Infrastructure;
using GMLink.Models.ViewModels;

namespace GMLink.Controllers
{
    public class CartController : Controller
    {

        private IReservationRepository repository;

        private Cart cart;
        public CartController(IReservationRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToActionResult AddToCart(int reservationID, string returnUrl)
        {
            
            Reservation reservation = repository.Reservations.FirstOrDefault(p => p.ReservationID == reservationID);
            if (reservation != null)
            {
                cart.AddItem(reservation, 1);

            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int reservationID, string returnUrl)
        {
            Reservation reservation = repository.Reservations
            .FirstOrDefault(p => p.ReservationID == reservationID);

        if (reservation != null)
            {
                cart.RemoveLine(reservation);
                reservation.Description = "Available";
                repository.SaveReservation(reservation);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}