using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.DataAccess.Interfaces
{ 
    public interface IUserTeaserTeamRepository : IRepository<UserTeaserTeam >
    {
        IQueryable<UserTeaserTeam> Get();
    }
}
