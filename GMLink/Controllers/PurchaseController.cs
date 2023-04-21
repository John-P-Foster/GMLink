using Microsoft.AspNetCore.Mvc;
using GMLink.Models;

namespace GMLink.Controllers
{


    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository;
        private Cart cart;
        public PurchaseController(IPurchaseRepository repoService, Cart cartService)
        {
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
                purchase.Lines = cart.Lines.ToArray();
                repository.SaveOrder(purchase);
                cart.Clear();
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