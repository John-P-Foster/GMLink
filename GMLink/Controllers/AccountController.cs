using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GMLink.Models.ViewModels;
using GMLink.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GMLink.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public static AppUser? CurrentUser { get; set; }
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IReservationRepository resRepositroy;

        public AccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signInMgr, IReservationRepository repository)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            resRepositroy = repository;
        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        CurrentUser = user;
                        return Redirect("/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/Home/Index")
        {
            CurrentUser = null;
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
        // GET: /<controller>/ 
        [Authorize]
        public ViewResult Index()
        {
            return View(userManager.Users);
        }
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }
        //POST: Account/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    CurrentUser = user;
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/AccountDetails/Create");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }
        }
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ViewResult EditReservations(int reservationId) =>
           View(resRepositroy.Reservations
               .FirstOrDefault(p => p.ReservationID == reservationId));
        public ViewResult myReservations() => View(resRepositroy.Reservations);

        [HttpPost]
        public IActionResult EditReservations(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                resRepositroy.SaveReservation(reservation);
                TempData["message"] = $"{reservation.ReservationID} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(reservation);
            }
        }
        public ViewResult CreateReservation() => View("EditReservations", new Reservation());
    }
}