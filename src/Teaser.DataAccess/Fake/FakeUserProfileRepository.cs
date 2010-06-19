using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.DataAccess.Interfaces;
using Teaser.Entities;

namespace Teaser.DataAccess.Fake
{
    public class FakeUserProfileRepository : IUserProfileRepository
    {
        private IUserTeaserTeamRepository _userTeaserTeamRepo;
        private IRpxUserRepository _rpxUserRepo;
        private ILeagueRepository _leagueRepo;
        private ISiteUserRoleRepository _siteUserRoleRepo;

        public FakeUserProfileRepository(IUserTeaserTeamRepository userTeaserTeamRepo,
            IRpxUserRepository rpxUserRepo, ILeagueRepository leagueRepo,
            ISiteUserRoleRepository siteUserRoleRepo)
        {
            _userTeaserTeamRepo = userTeaserTeamRepo;
            _rpxUserRepo = rpxUserRepo;
            _leagueRepo = leagueRepo;
            _siteUserRoleRepo = siteUserRoleRepo;


            //list.Add(new SiteUserRole(1, 1, 1));
            //list.Add(new SiteUserRole(2, 2, 2)); 

            //var users = siteUserRepo.Get();
            //var maxUserId = users.Max(x=>x.Id);
            //var minUserId = 5;
            //var roles = roleRepo.Get(); 
            //var maxRoleId = roles.Max(x=>x.Id);
            //var minRoleId = roles.Min(x=>x.Id);
            //for (int i = 11; i <= 20 ; i++)
            //{
            //    var userId = (i % (maxUserId+1 - minUserId)) + minUserId;
            //    var roleId = (i % (maxRoleId+1 - minRoleId)) + minRoleId;
            //    if (!this.list.Any(x => x.RoleId == roleId && x.SiteUserId == userId))
            //    {
            //        list.Add(new SiteUserRole(i, userId, roleId));
            //    }
            //}
        }

        public IQueryable<UserProfile> Get()
        {
            //var q = from u in _userTeaserTeamRepo.Get() 
            //join rpxUser in _rpxUserRepo.Get() on u.SiteUserId equals rpxUser.SiteUserId
            //join ur in this._siteUserRoleRepo.Get()  on u.SiteUserId equals ur.SiteUserId
            //select new UserProfile
            //{
            //     League = u.
            //    u.Id,
            //    u.SiteUserId,
            //    u.TeaserTeamId, 
            //    SiteUserName = u.SiteUser.Name, 
            //    RoleName = ur.Role.Name,
            //    TeaserTeamName = u.TeaserTeam.Name, 
            //    TeaserTeamLeagueName = u.TeaserTeam.League.Name, 
            //    rpxUser.DisplayName, 
            //    rpxUser.Identifier
            //}
            //return q;

            throw new NotImplementedException();

        }

         
    }
}
