using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    public class FakeRoleRepository : IRoleRepository
    {
        
        IList<Role> list = new List<Role>();

        public FakeRoleRepository()
        { 
            list.Add(new Role(1, "Coach"));
            list.Add(new Role(2, "LeagueCommish"));
            list.Add(new Role(3, "SiteAdmin"));
            list.Add(new Role(4, "Dev"));
        }


        public IQueryable<Role> Get()
        {
            return list.AsQueryable();
        }



    }
}
