using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace OpenIdPortableArea.Areas.OpenId
{
    /// <summary>
    ///     Registration for this Area.  Provides default routes.
    /// </summary>
    public class OpenIdAreaRegistration : PortableAreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            RegisterRoutes(context);

            base.RegisterArea(context, bus);
        }

        public void RegisterRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                "OpenId",
                "OpenId/{action}",
                new { controller = "OpenId", action = "Login" }
            );
        }

        public override string AreaName
        {
            get { return "OpenId"; }
        }
    }
}