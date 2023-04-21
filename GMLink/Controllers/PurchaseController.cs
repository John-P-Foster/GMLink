using Microsoft.AspNetCore.Mvc;
using GMLink.Models;

namespace GMLink.Controllers
{
    public class PurchaseController : Controller
    {
        public ViewResult Checkout() => View (new Purchase());
    }
}
