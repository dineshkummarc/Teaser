using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{ 
    public class FakeSiteUserRoleRepository : ISiteUserRoleRepository
    {
        IList<SiteUserRole> list = new List<SiteUserRole>();

        public FakeSiteUserRoleRepository(ISiteUserRepository siteUserRepo, IRoleRepository roleRepo)
        {
            list.Add(new SiteUserRole(1, 1, 1));
            list.Add(new SiteUserRole(2, 2, 2));
            list.Add(new SiteUserRole(3, 2, 1));
            list.Add(new SiteUserRole(4, 3, 3));
            list.Add(new SiteUserRole(5, 3, 2));
            list.Add(new SiteUserRole(6, 3, 1));
            list.Add(new SiteUserRole(7, 4, 4));
            list.Add(new SiteUserRole(8, 4, 3));
            list.Add(new SiteUserRole(9, 4, 2));
            list.Add(new SiteUserRole(10, 4, 1));

  
            var users = siteUserRepo.Get();
            var maxUserId = users.Max(x=>x.Id);
            var minUserId = 5;
            var roles = roleRepo.Get(); 
            var maxRoleId = roles.Max(x=>x.Id);
            var minRoleId = roles.Min(x=>x.Id);
            for (int i = 11; i <= 20 ; i++)
            {
                var userId = (i % (maxUserId+1 - minUserId)) + minUserId;
                var roleId = (i % (maxRoleId+1 - minRoleId)) + minRoleId;
                if (!this.list.Any(x => x.RoleId == roleId && x.SiteUserId == userId))
                {
                    list.Add(new SiteUserRole(i, userId, roleId));
                }
            }
        }
        public IQueryable<SiteUserRole> Get()
        {
            return list.AsQueryable();
        }



        #region IRepository<SiteUserRole> Members


        public SiteUserRole Save(SiteUserRole entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SiteUserRole entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
