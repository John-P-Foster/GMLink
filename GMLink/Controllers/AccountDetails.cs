using GMLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace GMLink.Controllers
{
    public class AccountDetails : Controller
    {
        public ViewResult Index()
        {
            return View(AccountController.CurrentUser);
        }
    }
}
