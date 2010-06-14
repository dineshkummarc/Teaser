using System;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Messages;

namespace OpenIdPortableArea.Areas.OpenId.Services
{
    /// <summary>
    ///     A message bus that abstracts away the management and sending of IEventMessages
    /// </summary>
    public interface IEventMessageBusService
    {
        /// <summary>
        ///     Sends a specific message, with an action
        ///     to be performed just before the message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="beforeSend">An action that takes the message as a paramter</param>
        /// <param name="args">Parameters that may be required to create the message</param>
        /// <returns></returns>
        T Send<T>(Action<T> beforeSend, params object[] args) where T : IEventMessage;

        /// <summary>
        ///     Sends a specific message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        T Send<T>(params object[] args) where T : IEventMessage;
    }

    /// <summary>
    ///     Provides message sending functionality
    /// </summary>
    public class EventMessageBusService : IEventMessageBusService
    {
        IApplicationBus _bus;
        IEventMessageFactory _eventMessageFactory;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public EventMessageBusService()
        {
            _bus = MvcContrib.Bus.Instance;
            _eventMessageFactory = new EventMessageFactory();
        }

        /// <summary>
        ///     Constructor with seams for injecting a specific bus and factory
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="eventMessageFactory"></param>
        public EventMessageBusService(IApplicationBus bus, IEventMessageFactory eventMessageFactory)
        {
            _bus = bus;
            _eventMessageFactory = eventMessageFactory;
        }

        /// <summary>
        ///     Sends a specific message, with an action
        ///     to be performed just before the message is sent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="beforeSend">An action that takes the message as a paramter</param>
        /// <param name="args">Parameters that may be required to create the message</param>
        /// <returns></returns>
        public T Send<T>(Action<T> beforeSend, params object[] args) where T : IEventMessage
        {
            var message = _eventMessageFactory.GetMessage<T>(args);
            beforeSend(message);
            _bus.Send(message);
            return message;
        }

        /// <summary>
        ///     Sends a specific message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Send<T>(params object[] args) where T : IEventMessage
        {
            var message = _eventMessageFactory.GetMessage<T>(args);
            _bus.Send(message);
            return message;
        }
    }
}