using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teaser.Entities
{
    public class UserProfile
    {
        public SiteUser SiteUser { get; set; }
        public RpxUser RpxUser { get; set; }
        public League League { get; set; }
        public TeaserTeam TeaserTeam { get; set; }
        public Role Role { get; set; } 
    }
}
