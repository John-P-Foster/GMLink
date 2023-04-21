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
        public CartController(IReservationRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }


        public RedirectToActionResult AddToCart(int reservationID, string returnUrl)
        {
            
            Reservation reservation = repository.Reservations.FirstOrDefault(p => p.ReservationID == reservationID);
            if (reservation != null)
            {
                Cart cart = GetCart();
                cart.AddItem(reservation, 1);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int reservationID, string returnUrl)
        {
            Reservation reservation = repository.Reservations
            .FirstOrDefault(p => p.ReservationID == reservationID);

        if (reservation != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(reservation);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}