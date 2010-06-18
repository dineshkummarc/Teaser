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




        #region IRepository<Role> Members


        public Role Save(Role entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IRepository<Role> Members

        IQueryable<Role> IRepository<Role>.Get()
        {
            throw new NotImplementedException();
        }

        Role IRepository<Role>.Save(Role entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Role>.Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
