using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.Service.UserProfileServices
{
    public class UserProfileService
    { 
        private readonly IUserProfileRepository _UserProfileRepository;
        public UserProfileService(IUserProfileRepository UserProfileRepository)
        {
            this._UserProfileRepository = UserProfileRepository;
        }
          
        public IList<UserProfile> Get()
        {
            return this._UserProfileRepository.Get().ToList<UserProfile>();
        }
         
    }
}
