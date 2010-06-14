using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using Gallio.Framework;
using MbUnit.Framework;
using Moq;
using MvcContrib;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Areas.OpenId;
using OpenIdPortableArea.Areas.OpenId.Controllers;
using OpenIdPortableArea.Areas.OpenId.Models;
using OpenIdPortableArea.Areas.OpenId.Services;
using OpenIdPortableArea.Messages;

namespace OpenIdPortableArea.Tests.Controllers
{
    [TestFixture]
    public class OpenIdControllerTests
    {
        private Mock<IApplicationBus> _bus;
        private OpenIdController _controller;
        private IAuthenticationService _service;
        private EventMessageFactory _eventMessageFactory;
        private IEventMessageBusService _messageBusService;
        private string _openIdUrl = "http://johncoder.myopenid.com/";

        [SetUp]
        public void SetUp()
        { 
            IEventMessage message = new AuthenticatedMessage();
            _bus = new Mock<IApplicationBus>();
            _eventMessageFactory = new EventMessageFactory();
            _messageBusService = new EventMessageBusService(_bus.Object, _eventMessageFactory);

            _service = new FakeAuthenticationService();
            _controller = new OpenIdController(_service, _messageBusService);

            var routes = new RouteCollection();
            OpenIdAreaRegistration area = new OpenIdAreaRegistration();
            area.RegisterRoutes(new AreaRegistrationContext("OpenId", routes));

            var context = FakeHttpContext();
            _controller.HttpRequest = context.Request;

            _controller.Url = new UrlHelper(new RequestContext(context, new RouteData()), routes);
        }

        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();

            request.Setup(req => req.ApplicationPath).Returns("/");
            request.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns("~/");
            request.Setup(req => req.PathInfo).Returns(string.Empty);
            response.Setup(res => res.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns((string virtualPath) => virtualPath);
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost:1234/"));

            user.Setup(usr => usr.Identity).Returns(identity.Object);
            identity.SetupGet(ident => ident.IsAuthenticated).Returns(true);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);

            return context.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _bus = null;
            _eventMessageFactory = null;
            _messageBusService = null;
            _service = null;
            _controller = null;
        }

        [Test]
        public void Login_action_should_return_Login_view()
        {
            ActionResult result = _controller.Login("");

            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult view = (ViewResult)result;
            Assert.AreEqual("Login", view.ViewName);
        }

        [Test]
        public void Login_action_should_return_Login_view_for_invalid_url()
        {
            var input = new LoginInput { OpenIdUrl = "asdf" };

            var result = (ViewResult)_controller.Login(input);

            Assert.AreEqual("Login", result.ViewName);
        }

        [Test]
        public void Login_action_should_send_ClaimsRequestMessage()
        {
            ((FakeAuthenticationService)_service).Valid = true;

            var message = _eventMessageFactory.GetMessage<ClaimsRequestMessage>();

            _controller.Login(new LoginInput { OpenIdUrl = "http://johncoder.myopenid.com/" });

            _bus.Verify(b => b.Send(message), Times.Once(), "ClaimsRequestMessage not sent.");
        }

        [Test]
        public void Login_action_should_return_RedirectResult_for_valid_url()
        {
            var fake = (FakeAuthenticationService)_service;
            fake.Valid = true;
            fake.RedirectResult = new RedirectResult(_openIdUrl);

            var result = _controller.Login(new LoginInput { OpenIdUrl = "http://johncoder.myopenid.com/" });

            Assert.AreSame(fake.RedirectResult, result);
        }

        [Test]
        public void Login_action_should_return_Login_view_for_error()
        {
            var fake = (FakeAuthenticationService)_service;
            fake.Valid = true;
            fake.AddClaimAction = () => { throw new InvalidOperationException(); };

            var result = (ViewResult)_controller.Login(new LoginInput { OpenIdUrl = "http://johncoder.myopenid.com/" });

            Assert.AreEqual("Login", result.ViewName);
        }

        [Test]
        public void Login_action_should_generate_correct_callbackUrl()
        {
            Uri url = _controller.GetCallBackUrl("/Home/Account");
            Assert.AreEqual("http://localhost:1234/OpenId/Result?returnUrl=/Home/Account", url.ToString());
        }

        [Test]
        public void Logout_action_should_send_LoggingOutMessage()
        {
            IEventMessage message = _eventMessageFactory.GetMessage<LoggingOutMessage>();

            _controller.Logout("~/");

            _bus.Verify(b => b.Send(message), Times.Once(), "LoggingOutMessage not sent");
        }

        [Test]
        public void Logout_action_should_send_LoggedOutMessage()
        {
            IEventMessage message = _eventMessageFactory.GetMessage<LoggedOutMessage>();

            _controller.Logout("~/");

            _bus.Verify(b => b.Send(message), Times.Once(), "LoggedOutMessage not sent");
        }

        [Test]
        public void Logout_action_should_return_Login_url()
        {
            Bus.AddMessageHandler(typeof(FakeLoggedOutMessageHandler));

            ActionResult result = _controller.Logout();

            Assert.AreEqual(typeof(RedirectResult), result.GetType());
            RedirectResult view = (RedirectResult)result;
            Assert.AreEqual("~/OpenId/Login", view.Url);

            Bus.Instance.Remove(typeof(FakeLoggedOutMessageHandler));
        }

        [Test]
        public void Logout_action_should_return_Logout_view()
        {
            IEventMessageBusService service = new EventMessageBusService(Bus.Instance, new EventMessageFactory());
            _controller = new OpenIdController(_service, service);
            Bus.AddMessageHandler(typeof(FakeLoggingOutMessageHandler));

            ActionResult result = _controller.Logout("~/");

            Assert.AreEqual(typeof(ViewResult), result.GetType());
            ViewResult view = (ViewResult)result;
            Assert.AreEqual("Logout", view.ViewName);

            Bus.Instance.Remove(typeof(FakeLoggingOutMessageHandler));
        }

        [Test]
        public void Result_action_should_redirect_to_Success_by_default()
        {
            FakeAuthenticationService service = (FakeAuthenticationService)_service;
            service.Status = AuthenticationStatus.Authenticated;

            var result = (RedirectResult)_controller.Result(new LoginInput { OpenIdUrl = _openIdUrl });

            Assert.AreEqual("~/OpenId/Success", result.Url);
        }

        [Test]
        public void Result_action_should_send_AuthenticatedMessage_for_Authenticated_status()
        {
            IEventMessage message = _eventMessageFactory.GetMessage<AuthenticatedMessage>();
            FakeAuthenticationService service = (FakeAuthenticationService)_service;
            service.Status = AuthenticationStatus.Authenticated;

            _controller.Result(new LoginInput { OpenIdUrl = _openIdUrl });

            _bus.Verify(b => b.Send(message), Times.Once(), "AuthenticatedMessage not sent");
        }

        [Test]
        public void Result_action_should_send_UnauthenticatedMessage_for_Canceled_status()
        {
            IEventMessage message = _eventMessageFactory.GetMessage<UnauthenticatedMessage>("Canceled");

            FakeAuthenticationService service = (FakeAuthenticationService)_service;
            service.Status = AuthenticationStatus.Canceled;

            _controller.Result(new LoginInput { OpenIdUrl = _openIdUrl });

            _bus.Verify(b => b.Send(message), Times.Once(), "UnauthenticatedMessage(\"Canceled\") not sent");
        }

        [Test]
        public void Result_action_should_send_UnauthenticatedMessage_for_Failed_status()
        {
            IEventMessage message = _eventMessageFactory.GetMessage<UnauthenticatedMessage>("Failed");

            FakeAuthenticationService service = (FakeAuthenticationService)_service;
            service.Status = AuthenticationStatus.Failed;

            _controller.Result(new LoginInput { OpenIdUrl = _openIdUrl });

            _bus.Verify(b => b.Send(message), Times.Once(), "UnauthenticatedMessage(\"Failed\") not sent");
        }

        [Test]
        public void Result_action_should_return_Login_view_for_Unauthenticated()
        {
            FakeAuthenticationService service = (FakeAuthenticationService)_service;
            service.Status = AuthenticationStatus.Canceled;

            var result = (ViewResult)_controller.Result(new LoginInput { OpenIdUrl = _openIdUrl });

            Assert.AreEqual("Login", result.ViewName);
        }
    }

    #region Fakes

    public class FakeLoggingOutMessageHandler : MessageHandler<LoggingOutMessage>
    {
        public override void Handle(LoggingOutMessage message)
        {
            TestLog.WriteLine("Handling LoggingOutMessage");
            message.AutoLogout = false;
        }
    }

    public class FakeLoggedOutMessageHandler : MessageHandler<LoggedOutMessage>
    {
        public override void Handle(LoggedOutMessage message)
        {
            TestLog.WriteLine("Handling LoggedOutMessage");
        }
    }

    public class FakeAuthenticationService : IAuthenticationService
    {
        public bool Valid { get; set; }
        public ActionResult RedirectResult { get; set; }

        public Action AddClaimAction { get; set; }
        public AuthenticationStatus Status { get; set; }

        public void AddClaim(ClaimsRequest claim)
        {
            if (AddClaimAction != null)
                AddClaimAction();
        }

        public AuthenticationStatus GetAuthenticationStatus()
        {
            return Status;
        }

        public bool IsValid(string openIdUrl, Uri callbackUrl)
        {
            return Valid;
        }

        public void Logout()
        {
            
        }

        public ActionResult Redirect()
        {
            return RedirectResult;
        }

        public void SetMessage(AuthenticatedMessage message)
        {
            
        }
    }

    #endregion
}