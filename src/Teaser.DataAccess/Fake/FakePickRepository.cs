using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.DataAccess.Fake
{
    public class FakePickRepository : IPickRepository
    {
        IList<Pick> list = new List<Pick>();

        public FakePickRepository() // IGameRepository gameRepository
        {
            for (int i = 1; i <= 1; i++)
            {
                Pick x = new Pick();
                x.Id = i;
                x.GameId = 1;
                x.TeaserTeamId = i;
                x.ProTeamId = 1;
                list.Add(x);

                /*
            string[] h = { "Id", "WeekId", "TeaserTeamId", "ProTeamId" };
                for (int i = 1; i <= 52; i++)
                {
                    Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "1" });
                    Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "3" });
                    Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "5" });
                    Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "7" });
                } */

            }
        }

        #region IRepository<Pick> Members

        public IQueryable<Pick> Get()
        {
            return this.list.AsQueryable();
        }

        public Pick Save(Pick entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Pick entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
