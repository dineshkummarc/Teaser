using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    public class FakeTeaserTeamRepository : ITeaserTeamRepository
    {
        IList<TeaserTeam> list = new List<TeaserTeam>();

        public FakeTeaserTeamRepository()
        {
            for (int i = 1; i <= 3; i++)
            {
                TeaserTeam x = new TeaserTeam();
                x.Id = i;
                list.Add(x);
            }
        }

        #region IRepository<TeaserTeam> Members

        public List<TeaserTeam> Get()
        {
            throw new NotImplementedException();
        }

        public TeaserTeam Save(TeaserTeam entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TeaserTeam entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
