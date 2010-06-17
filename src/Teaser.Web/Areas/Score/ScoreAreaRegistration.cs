using System.Web.Mvc;

namespace Teaser.Web.Areas.Score
{
    public class ScoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Score";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Score_default",
                "Score/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
                //new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
