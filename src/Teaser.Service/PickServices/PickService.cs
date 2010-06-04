using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.Service.PickServices
{
    public class PickService :IPickService
    {
        private readonly IPickRepository _pickRepository; 
        public PickService(IPickRepository pickRepository )
        {
            this._pickRepository = pickRepository;
        }



        #region IPickService Members

        public IList<Pick> GetPicksByWeekIdLeagueId(int weekId, int leagueId)
        {
            return this._pickRepository.Get()
                .Where(x => x.Game.WeekId == weekId)
                .Where(x=> x.TeaserTeam.LeagueId == leagueId)
                .ToList();
        }

        public Pick Save(Pick item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Pick item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
