using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using AutoMapper;
using Teaser.Web.Core;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Service.RpxUserServices;
using StructureMap.Attributes;
using Teaser.Service.SiteUserServices;
using System.Web.Security;
using System.Security.Principal;


namespace Teaser.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                //MVC.Default.Index() // use T4MVC
                new { controller = "Default", action = "Index", id = "" } // Parameter defaults
                //new { controller = "Default", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

      /*
	  protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);


            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    // Automatically maps interface IXyz to class Xyz
                    scan.WithDefaultConventions();
                    scan.Assembly(GetType().Assembly);
                });

                x.ForRequestedType(typeof(IProductRepository)).Use(typeof(FakeProductRepository));
            });


            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            AutoMapperConfiguration.Configure();
        }
		*/

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);


            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    // Automatically maps interface IXyz to class Xyz
                    scan.WithDefaultConventions();
                    scan.Assembly(GetType().Assembly);
                });
                x.ForRequestedType(typeof(IRpxUserService)).CacheBy(InstanceScope.Singleton).Use(typeof(RpxUserService));
                x.ForRequestedType(typeof(ISiteUserService)).CacheBy(InstanceScope.Singleton).Use(typeof(SiteUserService));


                x.ForRequestedType(typeof(IProductRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(FakeProductRepository));
                x.ForRequestedType(typeof(IRpxUserRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(FakeRpxUserRepository));
                x.ForRequestedType(typeof(ISiteUserRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(FakeSiteUserRepository));


                //x.ForRequestedType(typeof(IProductRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(SqlProductRepository));
                //x.ForRequestedType(typeof(IRpxUserRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(SqlRpxUserRepository));
                //x.ForRequestedType(typeof(ISiteUserRepository)).CacheBy(InstanceScope.Singleton).Use(typeof(SqlSiteUserRepository));


            });


            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            AutoMapperConfiguration.Configure();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //if (HttpContext.Current.User != null)
            //{
            //    if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    {
            //        if (HttpContext.Current.User.Identity is FormsIdentity)
            //        {
            //            FormsIdentity id =
            //                (FormsIdentity)HttpContext.Current.User.Identity;
            //            FormsAuthenticationTicket ticket = id.Ticket;

            //            // Get the stored user-data, in this case, our roles
            //            string userData = ticket.UserData;
            //            string[] roles = userData.Split(',');
            //            HttpContext.Current.User = new GenericPrincipal(id, roles);

            //        }
            //    }
            //}
        }
    }
}