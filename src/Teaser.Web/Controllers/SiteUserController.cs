using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teaser.Service.SiteUserServices;
using Teaser.Entities;
using Teaser.Web.Models;

namespace Teaser.Web.Controllers
{
    public partial class SiteUserController : Controller
    {
         
        private readonly ISiteUserService _siteUserService;

        public SiteUserController(  ISiteUserService siteUserService)
        { 
            _siteUserService = siteUserService;
        }

        [AutoMapModel(typeof(IEnumerable<SiteUser>), typeof(SiteUserModel[]))]
        public virtual ActionResult Index()
        {
            var v = this._siteUserService.Get();
            return View(v);
        }

        //
        // GET: /SiteUser/Details/5

        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SiteUser/Create

        public virtual ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SiteUser/Create

        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /SiteUser/Edit/5

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SiteUser/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SiteUser/Delete/5

        public virtual ActionResult Delete(int id)
        {
            this._siteUserService.Delete(this._siteUserService.Get().Where(x => x.Id == id).SingleOrDefault());
            return RedirectToAction(MVC.SiteUser.Index());
        }

        //
        // POST: /SiteUser/Delete/5

        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                this._siteUserService.Delete(this._siteUserService.Get().Where(x=> x.Id == id).SingleOrDefault());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
