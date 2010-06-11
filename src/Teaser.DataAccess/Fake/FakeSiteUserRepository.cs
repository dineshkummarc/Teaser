using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    public class FakeSiteUserRepository : ISiteUserRepository
    {

        IList<SiteUser> list = new List<SiteUser>();

        public FakeSiteUserRepository()
        {
            for (int i = 1; i <= 10; i++)
            {
                list.Add(new SiteUser(i, "User" + i, "", "someOpenId" + i));
            } 
        }


        public IQueryable<SiteUser> Get()
        {
            return list.AsQueryable();
        }



    }
}
