using System;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.Messaging;
using OpenIdPortableArea.Messages;
using OpenIdPortableArea.Areas.OpenId.Models;
using OpenIdPortableArea.Areas.OpenId.Services;
using System.Web;

namespace OpenIdPortableArea.Areas.OpenId.Controllers
{
    /// <summary>
    ///     OpenIdController
    /// </summary>
    public class OpenIdController : Controller
    {
        const string OpenIdUrlFormKey = "openIdUrl";

        private IAuthenticationService _authenticationService;
        private IEventMessageBusService _messageBusService;

        public HttpRequestBase HttpRequest { get; set; }

        private void Initialize(IAuthenticationService authenticationService, IEventMessageBusService messageBusService)
        {
            _authenticationService = authenticationService;
            _messageBusService = messageBusService;
        }

        public OpenIdController()
        {
            Initialize(new AuthenticationService(), new EventMessageBusService());
        }

        public OpenIdController(IAuthenticationService authenticationService, IEventMessageBusService messageBusService)
        {
            Initialize(authenticationService, messageBusService);
        }

        /// <summary>
        ///     Displays the Logout View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Logout(string returnUrl)
        {
            var message = _messageBusService.Send<LoggingOutMessage>(m => m.ReturnUrl = returnUrl);

            if (!message.AutoLogout)
                return View("Logout");

            return Logout();
        }

        /// <summary>
        ///     Logs out the current user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Logout()
        {
            var message = _messageBusService.Send<LoggedOutMessage>();

            if (message.UseDefaultLogoutMethod)
                _authenticationService.Logout();

            return Redirect(message.ReturnUrl);
        }

        /// <summary>
        ///     Returns the Login View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            return View("Login", new LoginInput { ReturnUrl = returnUrl });
        }

        /// <summary>
        ///     Redirects the user to their OpenId Provider
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Login(LoginInput loginInput)
        {
            Uri callbackUrl = GetCallBackUrl(loginInput.ReturnUrl);

            bool isValid = _authenticationService.IsValid(loginInput.OpenIdUrl, callbackUrl);

            if (!isValid)
            {
                AddError("The specified OpenID URL is invalid.  Please check the URL and resubmit.");
                return View("Login", loginInput);
            }

            var message = _messageBusService.Send<ClaimsRequestMessage>(m => m.Claim = new ClaimsRequest());

            try
            {
                _authenticationService.AddClaim(message.Claim);
                return _authenticationService.Redirect();
            }
            catch (ProtocolException ex)
            {
                AddError(ex.Message);
            }
            catch
            {
                AddError("There was an error processing the request.");
            }

            return View("Login", loginInput);
        }

        /// <summary>
        ///     Callback Action for the OpenId Provider.  Sends a Message regarding the Status of the OpenId Provider's response.
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Result(LoginInput loginInput)
        {
            AuthenticationStatus status = _authenticationService.GetAuthenticationStatus();
            switch (status)
            {
                case AuthenticationStatus.Authenticated:
                    string url = string.IsNullOrEmpty(loginInput.ReturnUrl) ? "~/OpenId/Success" : loginInput.ReturnUrl;

                    var message = _messageBusService.Send<AuthenticatedMessage>(m =>
                    {
                        m.ReturnUrl = url;
                        _authenticationService.SetMessage(m);
                    });

                    return Redirect(message.ReturnUrl);

                case AuthenticationStatus.Canceled:
                    var canceledMessage = _messageBusService.Send<UnauthenticatedMessage>("Canceled");
                    AddError("The OpenID authentication was cancelled.");
                    break;

                case AuthenticationStatus.Failed:
                    var failedMessage = _messageBusService.Send<UnauthenticatedMessage>("Failed");
                    AddError("The OpenID authentication failed.");
                    break;
            }

            return View("Login", loginInput);
        }

        /// <summary>
        ///     Displays a view to the user indicating that they were successfully logged in.
        /// </summary>
        /// <returns></returns>
        public ActionResult Success()
        {
            return View();
        }

        /* Widget Actions
        ---------------------------------------------------------------------*/

        /// <summary>
        ///     Returns a partial view containing OpenId Providers
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult ProvidersWidget()
        {
            return PartialView();
        }

        /// <summary>
        ///     Returns a partial view that is a simple form that contains
        ///     a text box and button, and posts back to Login.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult LoginWidget(LoginInput loginInput)
        {
            return PartialView(loginInput);
        }

        /// <summary>
        ///     Returns a partial view that displays the status of the
        ///     currently logged in user.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult LoginStatusWidget()
        {
            return PartialView();
        }

        /// <summary>
        ///     Adds a ModelState Error using OpenIdUrlFormKey.
        /// </summary>
        /// <param name="message"></param>
        protected void AddError(string message)
        {
            ModelState.AddModelError(OpenIdUrlFormKey, message);
        }

        /// <summary>
        ///     Builds a Callback url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Uri GetCallBackUrl(string url)
        {
            var values = new { action = "Result", returnUrl = url };

            var request = HttpRequest ?? Request;

            string uri = Url.RouteUrl(
                "OpenId",
                values,
                request.Url.Scheme);

            return new Uri(uri);
        }
    }
}