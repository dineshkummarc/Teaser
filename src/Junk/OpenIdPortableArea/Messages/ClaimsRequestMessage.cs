using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     Message for configuring the ClaimsRequest
    /// </summary>
    public class ClaimsRequestMessage : EventMessage
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public ClaimsRequestMessage()
        {
            Message = "Configuring ClaimsRequest";
        }

        /// <summary>
        ///     Contains a claim object to be configured.
        ///     Configuring properties of this object sets the demand level of desired user data.
        /// </summary>
        /// <remarks>
        ///     While it is helpful to request additional data from the OpenId Providers,
        ///     very few ever really honor the requests.
        /// </remarks>
        public ClaimsRequest Claim { get; set; }

        /// <summary>
        ///     Returns Message
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Message;
        }
    }
}