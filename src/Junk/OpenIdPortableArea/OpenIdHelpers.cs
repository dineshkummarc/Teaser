using System;
using System.Web;
using System.Web.Security;

namespace OpenIdPortableArea.Helpers
{
    /// <summary>
    ///     Contains static helper methods
    /// </summary>
    public static class OpenIdHelpers
    {
        /// <summary>
        ///     Uses the FormsAuthenticationTicket to add a FormsAuthentication Cookie
        /// </summary>
        /// <param name="ticket"></param>
        public static void Login(FormsAuthenticationTicket ticket)
        {
            string ticketString = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketString);
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        ///     Creates a FormsAuthenticationTicket, and adds a FormsAuthentication Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        /// <param name="duration"></param>
        /// <param name="isPersistant"></param>
        public static void Login(string name, string userData, TimeSpan duration, bool isPersistant)
        {
            DateTime dateTime = DateTime.Now;

            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket
                        (1, name,
                        dateTime,
                        dateTime.Add(duration),
                        isPersistant,
                        userData);

            Login(ticket);
        }

        /// <summary>
        ///     Logs out the user.
        /// </summary>
        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}