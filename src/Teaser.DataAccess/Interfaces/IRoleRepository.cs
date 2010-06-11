using System;
using Teaser.Entities;
using System.Linq;
namespace Teaser.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> Get();
    }
}
