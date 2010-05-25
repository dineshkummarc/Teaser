using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class Game : BaseItem
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int Line { get; set; }
        public int WeekId { get; set; }
        public string HomeScore { get; set; }
        public string AwayScore { get; set; }
    }
}
