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
            for (int i = 1; i <= 9; i++)
            {
                list.Add(new SiteUser(i, "User" + i   ));
            } 
        }


        public IQueryable<SiteUser> Get()
        {
            return list.AsQueryable();
        }



        #region IRepository<SiteUser> Members


        public SiteUser Save(SiteUser entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SiteUser entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
