using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teaser.Web.Controllers
{
    public partial class DefaultController : Controller
    {

        public virtual ActionResult Index()
        {
            ViewData["Message"] = "Welcome to Teaser League!";

            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }


    }
}
