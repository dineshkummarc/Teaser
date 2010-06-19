using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class UserTeaserTeam : BaseItem
    {
        public int SiteUserId { get; set; }
        public int TeaserTeamId { get; set; } 
        public TeaserTeam TeaserTeam { get; set; }
        public SiteUser SiteUser { get; set; } 

        
        public UserTeaserTeam()
        {
            this.Id = -1;
            this.TeaserTeam = new TeaserTeam();
            this.SiteUser = new SiteUser();
        }
        public UserTeaserTeam(int id, int siteUserId, int teaserTeamId)
        {
            this.Id = id;
            this.SiteUserId = siteUserId;
            this.TeaserTeamId = teaserTeamId; 
        } 
    }
}
