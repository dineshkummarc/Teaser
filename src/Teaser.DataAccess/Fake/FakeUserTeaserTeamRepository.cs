using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeUserTeaserTeamRepository : IUserTeaserTeamRepository
    {

        IList<UserTeaserTeam> list = new List<UserTeaserTeam>();


        public FakeUserTeaserTeamRepository(ISiteUserRepository siteUserRepo, ITeaserTeamRepository teaserTeamRepo)
        {
            list.Add(new UserTeaserTeam(1, 1, 1));
            list.Add(new UserTeaserTeam(2, 2, 2));
            list.Add(new UserTeaserTeam(3, 3, 3));
            list.Add(new UserTeaserTeam(4, 4, 4));
            list.Add(new UserTeaserTeam(5, 5, 5));
            list.Add(new UserTeaserTeam(6, 6, 6));
            list.Add(new UserTeaserTeam(7, 7, 7));
            list.Add(new UserTeaserTeam(8, 8, 8));
            list.Add(new UserTeaserTeam(9, 9, 9)); 
        }
        public IQueryable<UserTeaserTeam> Get()
        {
            return list.AsQueryable();
        }



        #region IRepository<UserTeaserTeam> Members


        public UserTeaserTeam Save(UserTeaserTeam entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserTeaserTeam entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
