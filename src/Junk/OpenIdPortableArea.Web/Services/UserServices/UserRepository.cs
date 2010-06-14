using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Services.Entities;

namespace MvcApplication1.Services.UserServices
{
    public class UserRepository
    {
        IList<User> list = new List<User>();


        public UserRepository()
        {
            /*list.Add(new User
            {
                Email = "a@gmail.com",
                OpenId = "http://www.google.com/accounts/XXXX",
                Name = "a a"
            });
             */
            list.Add(new User{ Email="b@b.com", Name="b", OpenId="bsdf"});
            list.Add(new User{ Email="c@c.com", Name="c", OpenId="csdf"});
            list.Add(new User{ Email="d@d.com", Name="d", OpenId="dsdf"});
        }

        public User FindByOpenId(string claimedIdentifier)
        {
            return list.Where(x => x.OpenId == claimedIdentifier).SingleOrDefault();
        }
        public IQueryable<User> FindAll()
        {
            return list.AsQueryable<User>();
        }
        public void Add(User u)
        { 
            list.Add(u);
        }

        public void Save( )
        { 
        }

    }
}
