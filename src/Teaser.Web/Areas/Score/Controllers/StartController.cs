using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teaser.Web.Areas.Score.Controllers
{
    public partial class StartController : Controller
    {
        //
        // GET: /Score/Home/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
