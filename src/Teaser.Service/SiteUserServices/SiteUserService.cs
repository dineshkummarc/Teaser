using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.Service.SiteUserServices
{

    public class SiteUserService : ISiteUserService
    {
        private readonly ISiteUserRepository _SiteUserRepository;
        public SiteUserService(ISiteUserRepository SiteUserRepository)
        {
            this._SiteUserRepository = SiteUserRepository;
        }


        #region ISiteUserService Members

        public IList<SiteUser> Get()
        {
            return this._SiteUserRepository.Get().ToList<SiteUser>();
        }
        

        public SiteUser Save(SiteUser item)
        {
            return this._SiteUserRepository.Save(item);
        }

        public bool Delete(SiteUser item)
        {
            return this._SiteUserRepository.Delete(item);
        }

        #endregion
         
        public SiteUser GetByName(string name)
        {
            return this._SiteUserRepository.Get()
                .Where(x => x.Name == name).SingleOrDefault();
        } 
    }

}
