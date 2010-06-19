using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teaser.Web.Models
{
    public class UserProfileModel
    {
        public string SiteUserName { get; set; }
        public string RpxUserIdentity { get; set; }
        public string LeagueName { get; set; }
        public string TeaserTeamName { get; set; }
        public string RoleName { get; set; } 
    }
}
