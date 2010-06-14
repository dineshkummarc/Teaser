using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     Message sent whenever an OpenId provider has verified the identity of the user
    /// </summary>
    public class AuthenticatedMessage : EventMessage
    {
        /// <summary>
        ///     Constructor.  Sets the Message
        /// </summary>
        public AuthenticatedMessage()
        {
            Message = "OpenId Provider Authentication was Successful.";
        }

        /// <summary>
        ///     A string containing the unique OpenId for the authenticated user
        /// </summary>
        public string ClaimedIdentifier { get; set; }

        /// <summary>
        ///     The ClaimsResponse that may contain anscillary data returned by the OpenId Provider
        /// </summary>
        public ClaimsResponse ClaimsResponse { get; set; }

        /// <summary>
        ///     Returns whether or not the ClaimedIdentifier is from a secure OpenId Provider
        /// </summary>
        public bool IsSecure { get; set; }

        /// <summary>
        ///     Contains a Url that OpenIdPortable Area will redirect to after this message object is processed.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}