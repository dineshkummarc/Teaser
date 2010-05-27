using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeGameRepository : IGameRepository
    {
        IList<Game> list = new List<Game>();

        public FakeGameRepository( )
        {

            int Id = 1;
            int teamId = 1;
            for (int i = 1; i <= 16; i++) //week 1
            { 
                int  homeId = teamId++ ;
                int awayId = teamId++ ;
                if (teamId > 32) teamId = 1;
                DateTime date = new DateTime(2010, 1, 1); // "1/1/2010"; //(i > 16) ? "1/7/2010" : "1/1/2010"; 
                int weekId =  1 ;  //(i > 16) ? "2" : "1"; 
                int line = (i % 4 == 1) ? 12 : (i % 4 == 2) ? -14 : (i % 4 == 3) ? 24 : -6;
                int homeScore = (i % 3 == 1) ? 9 : (i % 3 == 2) ? 14 : 24;
                int awayScore = (i % 5 == 1) ? 14 : (i % 5 == 2) ? 31 : (i % 5 == 3) ? 3 : 16;
                list.Add(new Game
                {
                    Id = Id++,
                    HomeTeamId = homeId,
                    AwayTeamId = awayId,
                    Date = date,
                    Line = line,
                    HomeScore=homeScore, AwayScore=awayScore, WeekId=weekId 
                });
            }
            teamId = 1;
            for (int i = 1; i <= 16; i++) //week 2
            {
                int id = Id++ ;
                int homeId = teamId ;
                teamId = teamId + 2;
                int awayId = teamId ;
                teamId = (teamId % 2 == 0) ? teamId + 1 : teamId - 1;
                DateTime date = new DateTime(2010, 1, 7); 
                int weekId = 2;
                int line = (i % 4 == 1) ? 3 : (i % 4 == 2) ? -1 : (i % 4 == 3) ? 14 : -13;
                int homeScore = (i % 3 == 1) ? 6 : (i % 3 == 2) ? 10 : 23;
                int awayScore = (i % 5 == 1) ? 7 : (i % 5 == 2) ? 21 : (i % 5 == 3) ? 3 : 28;
                list.Add(new Game
                {
                    Id = id,
                    HomeTeamId = homeId,
                    AwayTeamId = awayId,
                    Date = date,
                    Line = line,
                    HomeScore = homeScore,
                    AwayScore = awayScore,
                    WeekId = weekId
                });
            }
        }




        #region IRepository<Game> Members

        public IQueryable<Game> Get()
        {
            return list.AsQueryable();
        }

        public Game Save(Game entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
