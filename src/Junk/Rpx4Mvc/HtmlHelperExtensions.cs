using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Configuration;

namespace Rpx4Mvc
{
    /// <summary>
    /// Rpx4Mvc HtmlHelper extension methods
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Embedded RPX login control
        /// </summary>
        /// <param name="helper">HTML Helper</param>
        /// <param name="applicationName">Application name</param>
        /// <param name="tokenUrl">Token URL (your account controller)</param>
        /// <returns>Control markup</returns>
        public static string RpxLoginEmbedded(this HtmlHelper helper, string applicationName, string tokenUrl)
        {
            applicationName = ConfigurationSettings.AppSettings["RpxAppName"];
            return "<iframe src=\"https://" + applicationName + ".rpxnow.com/openid/embed?token_url=" + tokenUrl + "\" scrolling=\"no\" frameBorder=\"no\" style=\"width:400px;height:240px;\" class=\"rpx-embedded\"></iframe>";
        }

        /// <summary>
        /// Popup RPX login control
        /// </summary>
        /// <param name="helper">HTML Helper</param>
        /// <param name="applicationName">Application name</param>
        /// <param name="tokenUrl">Token URL (your account controller)</param>
        /// <param name="linkText">Sign in link text</param>
        /// <returns>Control markup</returns>
        public static string RpxLoginPopup(this HtmlHelper helper, string applicationName, string tokenUrl, string linkText)
        {
            applicationName = ConfigurationSettings.AppSettings["RpxAppName"];
            return "<script src=\"https://rpxnow.com/openid/v2/widget\" type=\"text/javascript\"></script><script type=\"text/javascript\">RPXNOW.overlay = true; RPXNOW.language_preference = 'en';</script>" +
                "<a class=\"rpxnow\" onclick=\"return false;\" href=\"https://" + applicationName + ".rpxnow.com/openid/v2/signin?token_url=" + tokenUrl + "\">" + linkText + "</a>";      
        }
    }
}
