using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpx4Mvc
{
    /// <summary>
    /// RPX Authentication Info
    /// </summary>
    public class RpxAuthInfo
    {
        /// <summary>
        /// RPX Profile
        /// </summary>
        public RpxProfile Profile { get; set; }

        /// <summary>
        /// RPX Status
        /// </summary>
        public string Stat { get; set; }
    }
}
