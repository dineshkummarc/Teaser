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
    }
}
