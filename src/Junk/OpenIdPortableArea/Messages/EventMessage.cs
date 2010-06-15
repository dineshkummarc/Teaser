using MvcContrib.PortableAreas;

namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     A base class that defines a message
    /// </summary>
    public abstract class EventMessage : IEventMessage
    {
        /// <summary>
        ///     Contains a message describing the event
        /// </summary>
        public string Message { get; set; }
    }
}
