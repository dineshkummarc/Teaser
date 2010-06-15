namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     Message indicating that the user is about to logout.
    /// </summary>
    public class LoggedOutMessage : EventMessage
    {
        /// <summary>
        ///     Constructor.  Provides default message configuration.
        /// </summary>
        public LoggedOutMessage()
        {
            Message = "User Logging Out";
            ReturnUrl = "~/OpenId/Login";
            UseDefaultLogoutMethod = true;
        }

        /// <summary>
        ///     Indicates whether or not the OpenIdPortableArea should
        ///     use its default logout method (FormsAuthentication)
        /// </summary>
        public bool UseDefaultLogoutMethod { get; set; }

        /// <summary>
        ///     Contains a Url that OpenIdPortable Area will redirect to after this message object is processed
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}