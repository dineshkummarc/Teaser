using System;
using System.Web;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Messages;
using OpenIdPortableArea.Helpers;
using MvcApplication1.Services.UserServices;
using MvcApplication1.Services.Entities;

namespace MvcApplication1.Services.PortableAreaHandlers
{
    public class AuthenticatedMessageHandler : MessageHandler<AuthenticatedMessage>
    {

        UserRepository _userRepository = new UserRepository();

        public override void Handle(AuthenticatedMessage message)
        {
            const string openid = "http://johncoder.myopenid.com/";


            User user = _userRepository.FindByOpenId(message.ClaimedIdentifier);

            if (user != null)
            {
                OpenIdHelpers.Login(user.Name,
                    user.Email,
                    new TimeSpan(0, 5, 0),
                    true);
            }
            else
            {
                user = new User
                {
                    OpenId = message.ClaimedIdentifier,
                    Email = message.ClaimsResponse.Email,
                    Name = message.ClaimsResponse.FullName
                };


                HttpContext.Current.Session.Add(
                    "user",
                    user);

                message.ReturnUrl = "~/Home/Register";
            }


            //if (message.ClaimedIdentifier == openid)
            //{
            //    OpenIdHelpers.Login("Joe Shmo", "jshmo@openid.com", new TimeSpan(0, 5, 0), true);
            //}
            //else
            //{
            //    if (message.ClaimsResponse != null)
            //        HttpContext.Current.Session.Add("OpenIDClaimedEmail", message.ClaimsResponse.Email ?? string.Empty);

            //    HttpContext.Current.Session.Add("OpenIDClaimedIdentifier", message.ClaimedIdentifier);
                
            //    message.ReturnUrl = "~/Home/Register";
            //}
        }
    }
}