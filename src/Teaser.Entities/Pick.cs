using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities.Base;

namespace Teaser.Entities
{
    public class Pick : BaseItem
    {
        public int ProTeamId { get; set; }
        public ProTeam ProTeam { get; set; }
        public int TeaserTeamId { get; set; }
        public TeaserTeam TeaserTeam { get; set; }
        public int WeekId { get; set; }
        public Week Week { get; set; }
        public bool Cover { get; set; }
    }
}
