namespace LoginRadiusSDK.V2.Exception
{
    /// <summary>
    /// Represents an error that occurred in the LoginRadius SDK when attempting to load information from the application's config file.
    /// </summary>
    public class ConfigException : LoginRadiusException
    {
        /// <summary>
        /// Represents errors that are related to the application's configuration.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public ConfigException(string message) : base(message)
        {
        }

        /// <summary>
        /// Gets the prefix to use when logging the exception information.
        /// </summary>
        protected string ExceptionMessagePrefix
        {
            get { return "Configuration Exception"; }
        }
    }
}