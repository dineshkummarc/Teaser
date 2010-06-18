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
using Teaser.Service.SiteUserServices;

namespace Teaser.Web.Controllers
{
    [HandleError]
    public partial class AccountController : Controller
    {
        private readonly IRpxUserService _rpxUserService;
        private readonly ISiteUserService _siteUserService;

        public AccountController(IRpxUserService rpxUserService, ISiteUserService  siteUserService)
        {
            _rpxUserService = rpxUserService;
            _siteUserService = siteUserService;
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
                    RpxUser rpxUser = this._rpxUserService.GetByIdentifier(profile.Identifier);
                    if (rpxUser == null) { rpxUser = new RpxUser(); }
                    rpxUser.Identifier = profile.Identifier;
                    rpxUser.Url = profile.Url;
                    rpxUser.DisplayName = profile.DisplayName;
                    rpxUser.ProviderName = profile.ProviderName;
                    rpxUser.JsonData = js.Serialize(profile);
                    if (rpxUser.SiteUserId == null)
                    {
                        var su = this._siteUserService.GetByName(profile.DisplayName);
                        if (su == null)
                        {
                            su = this._siteUserService.Save(new SiteUser { Name = profile.DisplayName });
                            rpxUser.SiteUserId = su.Id;
                        }
                        else
                        {
                            throw new Exception("User already in this table");
                        }
                    }
                    this._rpxUserService.Save(rpxUser);
                    FormsAuthentication.SetAuthCookie(profile.DisplayName, false);
                    return  RedirectToAction( MVC.Account.UserInfo(rpxUser.Id)); //  RedirectToAction("UserInfo", "Account"); 
                }
                catch (RpxException )
                {
                    return RedirectToAction("Login");
                }
            }
        }

        [AutoMapModel(typeof(RpxUser), typeof(RpxUserModel ))]
        public virtual ActionResult UserInfo(int id)
        {
            var rpxUser = this._rpxUserService.Get().Where(x=>x.Id == id).SingleOrDefault();
            return View(rpxUser);
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

        public virtual ActionResult Index()
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
