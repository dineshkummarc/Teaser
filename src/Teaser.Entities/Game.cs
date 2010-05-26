using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class Game : BaseItem
    {
        public int HomeTeamId { get; set; }
        public ProTeam HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public ProTeam AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int Line { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int WeekId { get; set; }
        public Week Week { get; set; }
    }
}
