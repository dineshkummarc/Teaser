using System;
using Teaser.Entities;
using System.Linq;
namespace Teaser.DataAccess.Interfaces
{
    public interface ISiteUserRepository
    {
        IQueryable<SiteUser> Get();
    }
}
