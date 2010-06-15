namespace OpenIdPortableArea.Messages
{
    /// <summary>
    ///     A message indicating that the user is logging out
    /// </summary>
    public class LoggingOutMessage : EventMessage
    {
        /// <summary>
        ///     Constructor.  Provides default message configuration.
        /// </summary>
        public LoggingOutMessage()
        {
            Message = "Logging Out Event";
            AutoLogout = true;
        }

        /// <summary>
        ///     Indicates whether or not the OpenIdPortableArea should
        ///     automatically log out the current user.
        /// </summary>
        public bool AutoLogout { get; set; }

        /// <summary>
        ///     Contains a Url that OpenIdPortable Area will redirect to after this message object is processed.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}