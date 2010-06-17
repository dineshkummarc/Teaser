using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeRpxUserRepository : IRpxUserRepository
    {
        
        IList<RpxUser> list = new List<RpxUser>();

        public FakeRpxUserRepository()
        {  
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
                int maxId = this.list.Max(x => x.Id);
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
