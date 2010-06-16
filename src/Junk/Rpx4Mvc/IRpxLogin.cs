using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpx4Mvc
{
    /// <summary>
    /// RPX Login Contract
    /// </summary>
    public interface IRpxLogin
    {
        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="token">Token from RPX</param>
        /// <returns>User profile</returns>
        RpxProfile GetProfile(string token);
    }
}
