using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeTeamRepository : ITeamRepository
    {
        IList<Team> list = new List<Team>();

        public FakeTeamRepository()
        {
            list.Add(new Team(1, "Oakland", "Raiders"));
            /*
             
	Baltimore Ravens

	Cincinnati Bengals

	Cleveland Browns

	Pittsburgh Steelers

AFC-South
	Houston Texans

	Indianapolis Colts

	Jacksonville Jaguars

	Tennessee Titans

AFC-East
	Buffalo Bills

	Miami Dolphins

	New England Patriots

	New York Jets

AFC-West
	Denver Broncos

	Kansas City Chiefs

	Oakland Raiders

	San Diego Chargers

NFC-North
	Chicago Bears

	Detroit Lions

	Green Bay Packers

	Minnesota Vikings

NFC-South
	Atlanta Falcons

	Carolina Panthers

	New Orleans Saints

	Tampa Bay Buccaneers

NFC-East
	Dallas Cowboys

	New York Giants

	Philadelphia Eagles

	Washington Redskins

NFC-West
	Arizona Cardinals

	San Francisco 49ers

	Seattle Seahawks

	St. Louis Rams
*/
        }


        #region IRepository<Team> Members

        public List<Team> Get()
        {
            throw new NotImplementedException();
        }

        public Team Save(Team entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Team entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
