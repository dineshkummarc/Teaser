using OpenIdPortableArea.Messages;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Helpers;

namespace MvcApplication1.Services.PortableAreaHandlers
{
    public class LoggedOutMessageHandler : MessageHandler<LoggedOutMessage>
    {
        public override void Handle(LoggedOutMessage message)
        {
            // Signal that the OpenIdPortableArea should not handle
            // logging out with its default behavior
            message.UseDefaultLogoutMethod = false;

            // Logout the user
            OpenIdHelpers.Logout();

            // Set a return url
            //message.SetDefaultReturnUrl("~/");
        }
    }
}