using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.DataAccess.Interfaces
{
    public interface ISiteUserRepository : IRepository<SiteUser>
    {
        IQueryable<SiteUser> Get();
    }
}
