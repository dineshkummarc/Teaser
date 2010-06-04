using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.Service.PickServices
{
    public interface IPickService
    { 
        IList<Pick> GetPicksByWeekIdLeagueId(int weekId, int LeagueId);
        Pick Save(Pick item);
        bool Delete(Pick item);  
    }
}
