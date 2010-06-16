using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;

namespace Rpx4Mvc.Web.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        public ActionResult Login(string token)
        {
            if (string.IsNullOrEmpty(token)) {
                return View();
            } else {
                string rpxApiKey = ConfigurationSettings.AppSettings["RpxApiKey"];
                IRpxLogin rpxLogin = new RpxLogin(rpxApiKey);
                try
                {
                    RpxProfile profile = rpxLogin.GetProfile(token);

                    FormsAuthentication.SetAuthCookie(profile.DisplayName, false);
                }
                catch (RpxException)
                {
                    return RedirectToAction("Login");
                }

                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Welcome()
        {
            return View();
        }
    }
}
