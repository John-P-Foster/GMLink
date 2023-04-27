using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using GMLink.Models.ViewModels;

namespace GMLink.Controllers
{
    public class GMBookingsController : Controller
    {
        private IPurchaseRepository repository;

        public GMBookingsController (IPurchaseRepository repo)
        {

            repository = repo;
        }
        public ViewResult ViewBookings() => View(repository.Purchases
            .OrderBy(p => p.PurchaseID));
       
    }
}
