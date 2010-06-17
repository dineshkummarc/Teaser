using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.Service.RpxUserServices
{
    public interface IRpxUserService
    { 
        IList<RpxUser> Get();
        RpxUser Save(RpxUser item);
        bool Delete(RpxUser item); 
    }
}
