using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class ProTeam : BaseItem
    {
        public string City { get; set; }
        public string Name { get; set; }



        public ProTeam()
        {
            this.Id = -1;
        }
        public ProTeam(int id, string city, string name)
        {
            this.Id = id;
            this.City = city;
            this.Name = name;
        } 
    }
}
