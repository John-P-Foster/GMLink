using Microsoft.AspNetCore.Mvc;
using GMLink.Models;

namespace GMLink.Controllers
{


    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository;
        private IReservationRepository repositoryR;
        private Cart cart;
        public PurchaseController(IPurchaseRepository repoService, IReservationRepository repo, Cart cartService)
        {
            repositoryR = repo;
            repository = repoService;
            cart = cartService;
        }
        
        public ViewResult Checkout() => View(new Purchase());

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                purchase.UserName = AccountController.CurrentUser.UserName;
                purchase.Lines = cart.Lines.ToArray();
                repository.SaveOrder(purchase);
                TempData["message"] = $"reservation number {purchase.PurchaseID} has been saved";
                cart.Clear();
                foreach (var line in purchase.Lines)
                {
                    Reservation reservation = line.Reservation;
                    reservation.Description = "Booked";
                    repositoryR.SaveReservation(reservation);
                }
                return View("Completed");
            }
            else
            {
                return View(purchase);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}