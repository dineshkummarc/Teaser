using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class SiteUserRole : BaseItem
    {
        public int SiteUserId { get; set; }
        public int RoleId { get; set; } 
        public SiteUser SiteUser { get; set; }
        public Role Role { get; set; } 

        
        public SiteUserRole()
        {
            this.Id = -1;
        }
        public SiteUserRole(int id, int siteUserId, int roleId)
        {
            this.Id = id;
            this.SiteUserId = siteUserId;
            this.RoleId = roleId; 
        } 

    }
}
