using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    class FakeLeagueRepository: ILeagueRepository
    {
        IList<League> list = new List<League>();

        public FakeLeagueRepository()
        {
            for (int i = 1; i <= 3; i++)
            {
                League x = new League();
                x.Id = i;
                list.Add(x);
            }
        }


        #region IRepository<League> Members

        public List<League> Get()
        {
            throw new NotImplementedException();
        }

        public League Save(League entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(League entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
