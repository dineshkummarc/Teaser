using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpx4Mvc
{
    /// <summary>
    /// RPX Profile
    /// </summary>
    public class RpxProfile
    {
        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Preferred username
        /// </summary>
        public string PreferredUsername { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Provider name
        /// </summary>
        public string ProviderName { get; set; }
        
        /// <summary>
        /// Identifier
        /// </summary>
        public string Identifier { get; set; }
    }
}
