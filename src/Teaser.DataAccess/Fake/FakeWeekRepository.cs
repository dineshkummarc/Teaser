using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeWeekRepository : IWeekRepository
    {
        IList<Week> list = new List<Week>();

        public FakeWeekRepository()
        {
            for (int i = 1; i <= 20; i++)
            {
                list.Add(new Week { Id=i, WeekNumber="Week "+i });
            }
        }


        #region IRepository<Week> Members

        public IQueryable<Week> Get()
        {
            throw new NotImplementedException();
        }

        public Week Save(Week entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Week entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
