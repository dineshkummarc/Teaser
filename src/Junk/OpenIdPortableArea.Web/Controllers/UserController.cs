using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Services.UserServices;
using MvcApplication1.Models;
using MvcApplication1.Services.Entities;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    { 
        private UserRepository _userRepository = new UserRepository();

        public ActionResult Index()
        {
            return RedirectToAction("ViewPage1"); // ViewPage1();
            //var l = _userRepository.FindAll().ToList<MvcApplication1.Services.Entities.User>(); 
            //return View(new UserListViewModel(l, 0, 0));
        }


        public ActionResult ViewPage1()
        {
            var l = _userRepository.FindAll().ToList<MvcApplication1.Services.Entities.User>();
            return View(l);
        }

    }
}
