using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rpx4Mvc;
using System.Web.Script.Serialization;
using System.Configuration; 
using Teaser.Service.RpxUserServices;
using Teaser.Entities;
using Teaser.Web.Models;

namespace Teaser.Web.Controllers
{
    [HandleError]
    public partial class AccountController : Controller
    {
        private readonly IRpxUserService _rpxUserService;

        public AccountController(IRpxUserService rpxUserService)
        {
            _rpxUserService = rpxUserService;
        }


        public virtual ActionResult Login(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            else
            {
                string rpxApiKey = ConfigurationSettings.AppSettings["RpxApiKey"];
                IRpxLogin rpxLogin = new RpxLogin(rpxApiKey);
                try
                {
                    RpxProfile profile = rpxLogin.GetProfile(token); 
                    JavaScriptSerializer js = new JavaScriptSerializer(); 
                    RpxUser user = this._rpxUserService.GetByIdentifier(profile.Identifier);
                    if (user == null) { user = new RpxUser(); }
                    user.Identifier = profile.Identifier;
                    user.Url = profile.Url;
                    user.DisplayName = profile.DisplayName;
                    user.ProviderName = profile.ProviderName;
                    user.JsonData = js.Serialize(profile);
                    this._rpxUserService.Save(user);
                    FormsAuthentication.SetAuthCookie(profile.DisplayName, false);
                }
                catch (RpxException )
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("UserList", "Account");
            }
        }

        [Authorize]
        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Default");
        }


        public virtual ActionResult Welcome()
        {
            return View();
        }


        [AutoMapModel(typeof(IEnumerable<RpxUser>), typeof(RpxUserModel[]))]
        public virtual ActionResult UserList()
        {
            var users =  _rpxUserService.Get();
            return View(users);
        }

    }
}
