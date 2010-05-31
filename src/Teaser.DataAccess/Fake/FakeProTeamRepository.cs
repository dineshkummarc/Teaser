using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeProTeamRepository : IProTeamRepository
    {
        IList<ProTeam> list = new List<ProTeam>();

        public FakeProTeamRepository()
        { 
            list.Add(new ProTeam(1, "Baltimore", "Ravens"));
            list.Add(new ProTeam(2, "Cincinnati", "Bengals"));
            list.Add(new ProTeam(3, "Cleveland", "Browns"));
            list.Add(new ProTeam(4, "Pittsburgh", "Steelers"));
            list.Add(new ProTeam(5, "Houston", "Texans"));
            list.Add(new ProTeam(6, "Indianapolis", "Colts"));
            list.Add(new ProTeam(7, "Jacksonville", "Jaguars"));
            list.Add(new ProTeam(8, "Tennessee", "Titans"));
            list.Add(new ProTeam(9, "Buffalo", " Bills"));
            list.Add(new ProTeam(10, "Miami", " Dolphins"));
            list.Add(new ProTeam(11, "New England", "Patriots"));
            list.Add(new ProTeam(12, "New York", "Jets"));
            list.Add(new ProTeam(13, "Denver", "Broncos"));
            list.Add(new ProTeam(14, "Kansas City", "Chiefs"));
            list.Add(new ProTeam(15, "Oakland", " Raiders"));
            list.Add(new ProTeam(16, "San Diego", "Chargers"));
            list.Add(new ProTeam(17, "Chicago", " Bears"));
            list.Add(new ProTeam(18, "Detroit", " Lions"));
            list.Add(new ProTeam(19, "Green Bay", " Packers"));
            list.Add(new ProTeam(20, "Minnesota", "Vikings"));
            list.Add(new ProTeam(21, "Atlanta", "Falcons"));
            list.Add(new ProTeam(22, "Carolina", "Panthers"));
            list.Add(new ProTeam(23, "New Orleans", "Saints"));
            list.Add(new ProTeam(24, "Tampa Bay", " Buccaneers"));
            list.Add(new ProTeam(25, "Dallas", " Cowboys"));
            list.Add(new ProTeam(26, "New York", "Giants"));
            list.Add(new ProTeam(27, "Philadelphia", "Eagles"));
            list.Add(new ProTeam(28, "Washington", "Redskins"));
            list.Add(new ProTeam(29, "Arizona", "Cardinals"));
            list.Add(new ProTeam(30, "San Francisco", "49ers"));
            list.Add(new ProTeam(31, "Seattle", "Seahawks"));
            list.Add(new ProTeam(32, "St. Louis", "Rams")); 
        }


        #region IRepository<Team> Members

        public IQueryable<ProTeam> Get()
        {
            return list.AsQueryable();
        }

        public ProTeam Save(ProTeam entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProTeam entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
