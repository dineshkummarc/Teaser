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
            FakeGameRepository gameRepository = new FakeGameRepository();
            AddPicksForWeek(gameRepository, 1);
            AddPicksForWeek(gameRepository, 2);
        }

        private void AddPicksForWeek(FakeGameRepository gameRepository, int weekId)
        {
            int minGameId = gameRepository.Get().Where(x => x.WeekId == weekId).Min(x => x.Id);
            int maxGameId = gameRepository.Get().Where(x => x.WeekId == weekId).Max(x => x.Id);
            int maxTeaserTeamId = 50;
            for (int i = 1; i <= maxTeaserTeamId; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    Pick p = new Pick();
                    p.Id = (list.Count == 0) ? 1 : list.Max(x => x.Id) + 1;
                    int gameId = (p.Id % (minGameId - maxGameId)) + minGameId;
                    //int gameId = (j % maxGameId) + minGameId;
                    Game g = gameRepository.Get().Where(x => x.Id == gameId).Single();
                    p.GameId = g.Id;
                    p.TeaserTeamId = i;
                    p.ProTeamId = ((j % 2) == 0) ? g.HomeTeamId : g.AwayTeamId;
                    list.Add(p);
                } 
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
