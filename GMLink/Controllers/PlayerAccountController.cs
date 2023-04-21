using Microsoft.AspNetCore.Mvc;
using GMLink.Models;

namespace GMLink.Controllers
{
    public class PlayerAccountController : Controller
    {
        private IPlayerAccountRepository repository;
        public PlayerAccountController(IPlayerAccountRepository repo)
        {
            repository = repo;
        }
        public ViewResult CreatePlayer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePlayerAccount(PlayerAccount playerAccount)
        {
            repository.SavePlayerAccount(playerAccount);
            return RedirectToAction("Home/Index.cshtml");
        }
    }
}
