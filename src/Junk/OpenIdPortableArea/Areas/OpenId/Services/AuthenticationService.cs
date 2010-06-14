using System;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using OpenIdPortableArea.Helpers;
using OpenIdPortableArea.Messages;

namespace OpenIdPortableArea.Areas.OpenId.Services
{
    /// <summary>
    ///     A service that provides OpenId support
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        Action _logout;
        Identifier _identifier;
        IAuthenticationRequest _request;
        IAuthenticationResponse _response;
        OpenIdRelyingParty _relyingParty;

        /// <summary>
        ///     Constructor
        /// </summary>
        public AuthenticationService()
        {
            _logout = OpenIdHelpers.Logout;
            _relyingParty = new OpenIdRelyingParty();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logout"></param>
        public AuthenticationService(Action logout)
        {
            _logout = logout;
        }

        /// <summary>
        ///     Logs out the user
        /// </summary>
        public void Logout() { _logout(); }

        /// <summary>
        ///     Determines if a request can be made to
        ///     the user's OpenId provider.
        /// </summary>
        /// <param name="openIdUrl"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        /// <exception cref="ProtocolException"></exception>
        public bool IsValid(string openIdUrl, Uri callbackUrl)
        {
            if (!Identifier.TryParse(openIdUrl, out _identifier))
                return false;

            try
            {
                _request = _relyingParty.CreateRequest(openIdUrl, Realm.AutoDetect, callbackUrl);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Adds a claim to the request.
        /// </summary>
        /// <param name="claim"></param>
        public void AddClaim(ClaimsRequest claim)
        {
            _request.AddExtension(claim);
        }

        /// <summary>
        ///     Returns an ActionResult that will redirect
        ///     the user to their OpenId provider.
        /// </summary>
        /// <returns></returns>
        public ActionResult Redirect()
        {
            return _request.RedirectingResponse.AsActionResult();
        }

        /// <summary>
        ///     Pareses the response and returns its status
        /// </summary>
        /// <returns></returns>
        public AuthenticationStatus GetAuthenticationStatus()
        {
            _response = _relyingParty.GetResponse();
            return _response.Status;
        }

        /// <summary>
        ///     Sets properties on the AuthenticatedMessage
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetMessage(AuthenticatedMessage message)
        {
            if (_response.Status != AuthenticationStatus.Authenticated)
                throw new InvalidOperationException(
                    string.Format("AuthenticationStatus must be Authenticated.  Was [{0}]", _response.Status));

            ClaimsResponse claim = _response.GetExtension<ClaimsResponse>();
            bool isSecure = _response.Provider.Uri.Scheme == "https";

            message.IsSecure = isSecure;
            message.ClaimsResponse = claim;
            message.ClaimedIdentifier = _response.ClaimedIdentifier;
        }
    }
}
