using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class Role : BaseItem
    {
        public string Name { get; set; } 

        
        public Role()
        {
            this.Id = -1;
        }
        public Role(int id, string name)
        {
            this.Id = id; 
            this.Name = name;
        } 

    }
}
