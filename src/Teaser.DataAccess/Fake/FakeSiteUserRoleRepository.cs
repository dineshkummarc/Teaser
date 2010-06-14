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
            list.Add(new SiteUserRole(3, 3, 3));
            list.Add(new SiteUserRole(4, 4, 4));

  
            var users = siteUserRepo.Get();
            var maxUserId = users.Max(x=>x.Id)+1;
            var minUserId = 5;
            var roles = roleRepo.Get(); 
            var maxRoleId = roles.Max(x=>x.Id)+1;
            var minRoleId = roles.Min(x=>x.Id);
            for (int i = 5; i <= 34 ; i++)
            {
                var userId = (i % (maxUserId - minUserId)) + minUserId;
                var roleId = (i % (maxRoleId - minRoleId)) + minRoleId;
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


    }
}
