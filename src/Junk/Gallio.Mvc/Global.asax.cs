using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Stable.Core.Services;
using StructureMap;
using Stable.Core.UiCore;
using Fragile.Core.Services;
using Stable.Core.Services.Impl;


namespace Stable
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);

            //ObjectFactory.Initialize(cfg => cfg.Scan(s =>
            //{
            //    s.TheCallingAssembly();
            //    s.WithDefaultConventions();
            //}));

            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    // Automatically maps interface IXyz to class Xyz
                    scan.WithDefaultConventions();
                    scan.Assembly(GetType().Assembly);
                });

                x.ForRequestedType(typeof(IProductRepository)).Use(typeof(SecondProductRepository));
            });

			ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

			AutoMapperConfiguration.Configure();
		}
	}
}