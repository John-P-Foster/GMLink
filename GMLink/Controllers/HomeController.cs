using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace GMLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //carl
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Policies ()
        {
            return View();
        }
        public IActionResult BrowseReservations ()
        {
            return View("Views/Reservations/BrowseReservations.cshtml");
        }
        public IActionResult CreatePlayer () 
        {
            return View("Views/Accounts/CreatePlayer.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}