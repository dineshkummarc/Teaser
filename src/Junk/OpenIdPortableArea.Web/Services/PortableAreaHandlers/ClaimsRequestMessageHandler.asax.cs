using OpenIdPortableArea.Messages;
using MvcContrib.PortableAreas;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace MvcApplication1.Services.PortableAreaHandlers
{
    public class ClaimsRequestMessageHandler : MessageHandler<ClaimsRequestMessage>
    {
        public override void Handle(ClaimsRequestMessage message)
        {
            message.Claim.Email = DemandLevel.Require;
            message.Claim.FullName = DemandLevel.Require;
            message.Claim.Country = DemandLevel.Request;
            message.Claim.BirthDate = DemandLevel.Request;
            message.Claim.Nickname = DemandLevel.Request;
            message.Claim.TimeZone = DemandLevel.Request;
        }
    }
}