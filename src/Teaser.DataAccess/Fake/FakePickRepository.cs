using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakePickRepository
    {
        IList<Pick> list = new List<Pick>();

        public FakePickRepository()
        {
            for (int i = 1; i <= 3; i++)
            {
                Pick x = new Pick();
                x.Id = i;
                list.Add(x);
            }
        }
    }
}
