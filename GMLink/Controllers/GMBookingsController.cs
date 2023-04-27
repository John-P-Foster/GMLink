using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GMLink.Controllers
{
    public class GMBookingsController : Controller
    {
        private IPurchaseRepository repository;
        public GMBookingsController(IPurchaseRepository repository)
        {
            this.repository = repository;
        }
            public IActionResult ViewBookings()
        {
            return View();
        }
    }
}
