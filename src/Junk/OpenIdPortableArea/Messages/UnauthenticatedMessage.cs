namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     Represents when a User's attempt to authenticate with an OpenId Provider was unsuccessful
    /// </summary>
    public class UnauthenticatedMessage : EventMessage
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="result"></param>
        public UnauthenticatedMessage(string result)
        {
            Message = string.Format("OpenID not Authenticated: {0}", result);
        }
    }
}