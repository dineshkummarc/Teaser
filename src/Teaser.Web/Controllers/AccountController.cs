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
using Teaser.Service.UserProfileServices;

namespace Teaser.Web.Controllers
{
    [HandleError]
    public partial class AccountController : Controller
    {
        private readonly IRpxUserService _rpxUserService;
        private readonly ISiteUserService _siteUserService;
        private readonly IUserProfileService _userProfileService;

        public AccountController(IRpxUserService rpxUserService, ISiteUserService siteUserService, IUserProfileService userProfileService)
        {
            _rpxUserService = rpxUserService;
            _siteUserService = siteUserService;
            _userProfileService = userProfileService;
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
                    bool registeredUser = false;
                    if (rpxUser.SiteUserId == null)
                    {
                        var su = this._siteUserService.GetByName(profile.DisplayName);
                        if (su == null)
                        {
                            su = this._siteUserService.Save(new SiteUser { Name = profile.DisplayName });
                            registeredUser = true;
                        }
                        rpxUser.SiteUserId = su.Id;
                    }
                    this._rpxUserService.Save(rpxUser);
                    FormsAuthentication.SetAuthCookie(profile.DisplayName, false);

                    if (registeredUser)
                    {
                        return RedirectToAction(MVC.Account.UserProfile(rpxUser.Id));
                    }
                    else
                    {
                        return RedirectToAction(MVC.Account.Register(rpxUser.Id));
                    }
                    //  RedirectToAction("UserInfo", "Account"); 
                     
                    //return  RedirectToAction( MVC.Account.UserInfo(rpxUser.Id)); //  RedirectToAction("UserInfo", "Account"); 
                }
                catch (RpxException )
                {
                    return RedirectToAction("Login");
                }
            }
        }
        public virtual ActionResult TicketInfo()
        {  
            ViewData["UserData"] = User.Identity.Name;
            return View();
        }


        [AutoMapModel(typeof(UserProfile), typeof(UserProfileModel))]
        public virtual ActionResult UserProfile(int id)
        {
            var up = this._userProfileService.Get().Where(x => x.SiteUser.Id == id).FirstOrDefault();
            return View(up);
        }

        [AutoMapModel(typeof(RpxUser), typeof(RpxUserModel))]
        public virtual ActionResult UserInfo(int id)
        {
            var rpxUser = this._rpxUserService.Get().Where(x => x.Id == id).SingleOrDefault();
            return View(rpxUser);
        }


        [AutoMapModel(typeof(RpxUser), typeof(RpxUserModel ))]
        public virtual ActionResult Register(int id)
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
