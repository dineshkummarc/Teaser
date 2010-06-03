using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces; 
using Teaser.DataAccess.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teaser.Service.GameServices;

namespace Teaser.Service.Test 
{
    /// <summary>
    /// Summary description for BaseServiceTest
    /// </summary>
    [TestClass]
    public class BaseServiceTest
    {
        protected IGameRepository _GameRepository;
        protected IGameService _GameService; 

        [TestInitialize]
        public void Startup()
        {
            _GameRepository = new FakeGameRepository();
            _GameService = new GameService(this._GameRepository);  
        }
        
    }
}

