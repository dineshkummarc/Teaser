using OpenIdPortableArea.Messages;
using MvcContrib.PortableAreas;

namespace MvcApplication1.Services.PortableAreaHandlers
{
    public class LoggingOutMessageHandler : MessageHandler<LoggingOutMessage>
    {
        public override void Handle(LoggingOutMessage message)
        {
            // Disable the default auto logout behavior
            message.AutoLogout = false;

            // Set a return url
            //message.SetDefaultReturnUrl("~/");
        }
    }
}