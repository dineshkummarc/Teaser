using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    public class FakeLeagueRepository: ILeagueRepository
    {
        IList<League> list = new List<League>();

        public FakeLeagueRepository()
        {
            list.Add(new League { Id = 1, Name = "NTL" });
            list.Add(new League { Id = 2, Name = "Stu Season" });
        }


        #region IRepository<League> Members

        public IQueryable<League> Get()
        {
            return list.AsQueryable();
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
