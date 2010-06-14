using System;
using System.Web.Mvc;
using System.Linq;
using OpenIdPortableArea.Helpers;
using OpenIdPortableArea;
using MvcApplication1.Services.Entities;
using MvcApplication1.Services.UserServices;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private UserRepository _userRepository = new UserRepository();

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            User user = (User)Session["user"];
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool exists = _userRepository.FindAll().Any(u => u.Name == user.Name);
            if (exists)
            {
                ModelState.AddModelError("", "User already exists with that name.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                _userRepository.Add(user);
                _userRepository.Save();

                // Issue forms authentication ticket.
                OpenIdHelpers.Login(user.Name, string.Empty, new TimeSpan(5, 0, 0, 0), false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}
