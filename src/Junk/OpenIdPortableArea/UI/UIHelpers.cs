using System.Web.Mvc;
using System.Web.Mvc.Html;
using OpenIdPortableArea.Areas.OpenId.Models;

namespace OpenIdPortableArea.UI
{
    public static class UIHelpers
    {
        /// <summary>
        ///     Loads a simple LoginStatusWidget to display whether or not the user is authenticated
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString LoginStatusWidget(this HtmlHelper helper)
        {
            return helper.Action("LoginStatusWidget", "OpenId", new { area = "OpenId" });
        }

        /// <summary>
        ///     Loads a simple ProvidersWidget to display various OpenId Providers
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString ProvidersWidget(this HtmlHelper helper)
        {
            return helper.Action("ProvidersWidget", "OpenId", new { area = "OpenId" });
        }

        /// <summary>
        ///     Loads a simple LoginWidget that takes an OpenId endpoint Uri as input
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString LoginWidget(this HtmlHelper helper)
        {
            return helper.Action("LoginWidget", "OpenId", new { area = "OpenId" });
        }

        /// <summary>
        ///     Loads a simple LoginWidget that takes an OpenId endpoint Uri as input
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        public static MvcHtmlString LoginWidget(this HtmlHelper helper, LoginInput loginInput)
        {
            return helper.Action("LoginWidget", "OpenId", new { area = "OpenId", ReturnUrl = loginInput.ReturnUrl, OpenIdUrl = loginInput.OpenIdUrl });
        }
    }
}
