using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.Service.UserProfileServices
{
    public interface IUserProfileService
    {
        IList<UserProfile> Get();
    }
}
