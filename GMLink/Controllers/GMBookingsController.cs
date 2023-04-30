using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using GMLink.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GMLink.Controllers
{
    public class GMBookingsController : Controller
    {
        private IPurchaseRepository repository;
        private UserManager<AppUser> userManager;

        public GMBookingsController (IPurchaseRepository repo, UserManager<AppUser> userMgr)
        {

            repository = repo;
            userManager = userMgr;
        }
        public ViewResult ViewBookings() => View(repository.Purchases
            .OrderBy(p => p.PurchaseID));
       
    }
}
