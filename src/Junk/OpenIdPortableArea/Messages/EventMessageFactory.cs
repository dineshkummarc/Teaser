using System;
using MvcContrib.PortableAreas;
using System.Collections.Generic;

namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     A factory responsible for creating and managing messages
    /// </summary>
    public interface IEventMessageFactory
    {
        /// <summary>
        ///     Returns a message of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">Arguments necessary to create this message</param>
        /// <returns></returns>
        T GetMessage<T>(params object[] args) where T : IEventMessage;
    }

    /// <summary>
    ///     Creates and manages IEventMessages
    /// </summary>
    public class EventMessageFactory : IEventMessageFactory
    {
        private Dictionary<Type, IEventMessage> _messages = new Dictionary<Type, IEventMessage>();

        /// <summary>
        ///     Gets a cached message based on its type, or instantiates a new one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">Arguments necessary to create this message</param>
        /// <returns></returns>
        public T GetMessage<T>(params object[] args) where T : IEventMessage
        {
            Type type = typeof(T);
            IEventMessage message;

            if (!_messages.ContainsKey(type))
            {
                message = (IEventMessage)Activator.CreateInstance(typeof(T), args);
                _messages.Add(type, message);
                return (T)message;
            }

            _messages.TryGetValue(type, out message);
            return (T)message;
        }
    }
}
