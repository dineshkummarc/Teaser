using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class SiteUser  : BaseItem
    {
        public string Name { get; set; } 

        
        public SiteUser()
        {
            this.Id = -1;
        }
        public SiteUser(int id, string name )
        {
            this.Id = id;
            this.Name = name; 
        } 

    }
}
