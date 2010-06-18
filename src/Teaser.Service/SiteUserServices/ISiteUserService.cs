using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;

namespace Teaser.Service.SiteUserServices
{
    public interface ISiteUserService
    {
        SiteUser  GetByName(string name);
        IList<SiteUser> Get();
        SiteUser Save(SiteUser item);
        bool Delete(SiteUser item); 
    }
}
