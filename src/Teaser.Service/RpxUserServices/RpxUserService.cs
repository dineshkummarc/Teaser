using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;
using Teaser.DataAccess.Interfaces;

namespace Teaser.Service.RpxUserServices
{

    public class RpxUserService : IRpxUserService
    {
        private readonly IRpxUserRepository _rpxUserRepository;
        public RpxUserService(IRpxUserRepository rpxUserRepository)
        {
            this._rpxUserRepository = rpxUserRepository;
        }


        #region IRpxUserService Members

        public IList<RpxUser> Get()
        {
            return this._rpxUserRepository.Get().ToList<RpxUser>();
        }

        public RpxUser Save(RpxUser item)
        {
            return this._rpxUserRepository.Save(item);
        }

        public bool Delete(RpxUser item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
