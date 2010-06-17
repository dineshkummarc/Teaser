using System;
using Teaser.Entities;
using System.Linq;


namespace Teaser.DataAccess.Interfaces
{
    public interface ISiteUserRoleRepository : IRepository<SiteUserRole>
    {
        IQueryable<SiteUserRole> Get();
    }
}
