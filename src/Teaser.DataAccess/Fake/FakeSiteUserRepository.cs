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
                list.Add(new SiteUser(i, "User" + i, "a@a.com"   ));
            } 
        }


        public IQueryable<SiteUser> Get()
        {
            return list.AsQueryable();
        }



        #region IRepository<SiteUser> Members


        public SiteUser Save(SiteUser item)
        {
            SiteUser repoItem = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
            if (repoItem != null)
            {
                list.Remove(repoItem);
            }
            else
            {
                int maxId = (this.list.Count <= 0) ? 0 : this.list.Max(x => x.Id);
                item.Id = maxId + 1;
            }
            this.list.Add(item);
            return item;  
        }

        public bool Delete(SiteUser item)
        {
            bool bReturn = false;
            SiteUser repoItem = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
            if (repoItem != null)
            {
                list.Remove(repoItem);
                bReturn = true;
            }
            return bReturn;
        }

        #endregion
    }
}
