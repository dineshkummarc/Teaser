using MvcContrib.PortableAreas;
using System.Diagnostics;

namespace MvcApplication1.Services.PortableAreaHandlers
{
    public class LogAllMessagesObserver : MessageHandler<IEventMessage>
    {
        public override void Handle(IEventMessage message)
        {
            Debug.WriteLine(message);
        }
    }
}