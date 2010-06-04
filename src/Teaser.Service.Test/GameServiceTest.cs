using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teaser.Service.Test
{
    /// <summary>
    /// Summary description for GameServiceTest
    /// </summary>
    [TestClass]
    public class GameServiceTest : BaseServiceTest
    {

        [TestMethod]
        public void GameService_GetGamesByWeekId1_IsNotNull()
        {
            var q = this._GameService.GetGamesByWeekId(1);
            Assert.IsNotNull(q);
        }
        [TestMethod]
        public void GameService_GetGamesByWeekId1_Returns16Games()
        {
            var q = this._GameService.GetGamesByWeekId(1);
            const int numberOfGamesInOneWeek = 16;
            Assert.AreEqual(numberOfGamesInOneWeek, q.Count);
        } 
        [TestMethod]
        public void GameService_GetGamesByWeekIdNegative999999_Returns0Games()
        {
            var q = this._GameService.GetGamesByWeekId(-99999999);
            const int numberGames = 0;
            Assert.AreEqual(numberGames, q.Count);
        }
    }
}
