using Microsoft.AspNetCore.Mvc;
using GMLink.Models;
using GMLink.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GMLink.Controllers
{


    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository;
        private IReservationRepository repositoryR;
        private UserManager<AppUser> userManager;
        private Cart cart;
        public PurchaseController(IPurchaseRepository repoService, IReservationRepository repo, Cart cartService, UserManager<AppUser> userMgr)
        {
            repositoryR = repo;
            repository = repoService;
            cart = cartService;
            userManager = userMgr;
        }
        [Authorize]
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
                decimal price = 0;
                purchase.UserName = User.Identity?.Name;
                purchase.Lines = cart.Lines.ToArray();
                repository.SaveOrder(purchase);
                TempData["message"] = $"reservation number {purchase.PurchaseID} has been saved";
                cart.Clear();
                foreach (var line in purchase.Lines)
                {
                    Reservation reservation = line.Reservation;
                    reservation.Description = User.Identity?.Name;
                    price += reservation.Price;
                    repositoryR.SaveReservation(reservation);
                }
                purchase.Total = price;
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