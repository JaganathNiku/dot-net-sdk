using System.Net;

namespace LoginRadiusSDK.V2.Exception
{
    /// <summary>
    /// Represents a connection error that occurred in the LoginRadius SDK when attempting to make an HTTP request to the LoginRadius REST API.
    /// </summary>
    public class ConnectionException : LoginRadiusException
    {
        /// <summary>
        /// Gets the response payload for non-200 response
        /// </summary>
        public string Response { get; private set; }

        /// <summary>
        /// Gets the <see cref="System.Net.WebExceptionStatus"/> returned from a failed HTTP request.
        /// </summary>
        public WebExceptionStatus WebExceptionStatus { get; private set; }

        /// <summary>
        /// Gets the <see cref="System.Net.HttpWebRequest"/> sent by the SDK.
        /// </summary>
        public HttpWebRequest Request { get; private set; }

        /// <summary>
        /// Represents errors that occur during application execution
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="response">The response from server</param>
        /// <param name="status">The <see cref="System.Net.WebExceptionStatus"/> that triggered this exception.</param>
        /// <param name="request">HTTP request sent by this SDK.</param>
        public ConnectionException(string message, string response, WebExceptionStatus status,
            HttpWebRequest request) : base(message)
        {
            Response = response;
            WebExceptionStatus = status;
            Request = request;
        }

        /// <summary>
        /// Copy constructor provided by convenience for derived classes.
        /// </summary>
        /// <param name="ex">The original exception to copy information from.</param>
        protected ConnectionException(ConnectionException ex) : this(ex.Message, ex.Response, ex.WebExceptionStatus,
            ex.Request)
        {
        }

        public ConnectionException(string message, ConnectionException response)
        {
            string errorMessage = string.IsNullOrEmpty(ExceptionMessagePrefix)
                ? message
                : $"{ExceptionMessagePrefix}: {message}";
            Response = response == null ? errorMessage : errorMessage + response;
        }

        /// <summary>
        /// Gets the prefix to use when logging the exception information.
        /// </summary>
        protected override string ExceptionMessagePrefix
        {
            get { return "Connection Exception"; }
        }
    }
}