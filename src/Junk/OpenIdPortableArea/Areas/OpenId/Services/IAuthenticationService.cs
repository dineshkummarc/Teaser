using System;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace OpenIdPortableArea.Areas.OpenId.Services
{
    public interface IAuthenticationService
    {
        void AddClaim(ClaimsRequest claim);
        AuthenticationStatus GetAuthenticationStatus();
        bool IsValid(string openIdUrl, Uri callbackUrl);
        void Logout();
        ActionResult Redirect();
        void SetMessage(OpenIdPortableArea.Messages.AuthenticatedMessage message);
    }
}
