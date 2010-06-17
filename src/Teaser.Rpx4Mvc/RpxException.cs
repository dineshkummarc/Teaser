using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpx4Mvc
{
    /// <summary>
    /// Rpx Exception
    /// </summary>
    public class RpxException : Exception
    {
        /// <summary>
        /// Rpx Exception
        /// </summary>
        public RpxException() : base() { }

        /// <summary>
        /// Rpx Exception
        /// </summary>
        /// <param name="message">Message</param>
        public RpxException(string message) : base(message) { }

        /// <summary>
        /// Rpx Exception
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="innerException">Inner exception</param>
        public RpxException(string message, Exception innerException) : base(message, innerException) { }
    }
}
