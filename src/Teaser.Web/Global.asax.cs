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
                new { controller = "Default", action = "Index", id = UrlParameter.Optional } // Parameter defaults
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
                x.ForRequestedType(typeof(IRpxUserService)).Use(typeof(RpxUserService));

                x.ForRequestedType(typeof(IProductRepository)).Use(typeof(FakeProductRepository));
                x.ForRequestedType(typeof(IRpxUserRepository)).Use(typeof(FakeRpxUserRepository));
            });


            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            AutoMapperConfiguration.Configure();
        }
    }
}