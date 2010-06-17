using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;
using System.Configuration;

namespace Teaser.DataAccess.Fake
{
    public class FakeRpxUserRepository : IRpxUserRepository
    {
        
        IList<RpxUser> list = new List<RpxUser>();

        public FakeRpxUserRepository()
        {
            var s = ConfigurationSettings.AppSettings["RpxUser1Id"];
            list.Add(new RpxUser { 
                Id = 1,
                Identifier =   ConfigurationSettings.AppSettings["RpxUser1Id"],  
                SiteUserId = 1,
                DisplayName =  ConfigurationSettings.AppSettings["RpxUser1Name"]  
            });
        }






        #region IRpxUserRepository Members

        public IQueryable<RpxUser> Get()
        {
            return list.AsQueryable();
        }

        #endregion

        #region IRepository<RpxUser> Members


        public RpxUser Save(RpxUser item)
        {
            RpxUser repoItem = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
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
         


        public bool Delete(RpxUser entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
