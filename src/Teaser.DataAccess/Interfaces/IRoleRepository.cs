using System;
using Teaser.Entities;
using System.Linq;
namespace Teaser.DataAccess.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        IQueryable<Role> Get();
    }
}
