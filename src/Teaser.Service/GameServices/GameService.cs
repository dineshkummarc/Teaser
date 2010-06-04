using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.Service.GameServices
{
    public class GameService : IGameService
    { 
        private readonly IGameRepository _gameRepository; 

        public GameService(IGameRepository gameRepository )
        {
            this._gameRepository = gameRepository;
        }


        #region IGameService Members

        public IList<Game> GetGamesByWeekId(int weekId)
        {
            return this._gameRepository.Get().Where(x => x.WeekId == weekId).ToList();
        }

        public Game Save(Game item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Game item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
