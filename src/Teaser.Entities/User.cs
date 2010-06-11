using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class User  : BaseItem
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string OpenId { get; set; } 
    }
}
