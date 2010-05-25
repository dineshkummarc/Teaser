using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeGameRepository : IGameRepository
    {
        IList<Game> list = new List<Game>();

        public FakeGameRepository( )
        {
            for (int i = 0; i < 42; i++)
            {
                Game x = new Game();
                x.Id = i;
                x.ModifiedBy = (i % 4 == 0) ? "a@a.com" : (i % 3 == 0) ? "b@b.com" : "c@c.com";
                x.ModifiedDate = new DateTime(2009, 1, 1);
                list.Add(x);
            }
             
        }




        #region IRepository<Game> Members

        public List<Game> Get()
        {
            throw new NotImplementedException();
        }

        public Game Save(Game entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
