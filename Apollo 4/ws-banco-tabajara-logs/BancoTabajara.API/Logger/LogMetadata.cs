using BancoTabajara.API.Excecoes;
using System;

namespace BancoTabajara.API.Logger
{
    public class LogMetadata
    {
        /// <summary>
        /// The request URI.
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// The request method (GET, POST, etc).
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// The request timestamp.
        /// </summary>
        public DateTime RequestTimestamp { get; set; }

        /// <summary>
        /// The response status code.
        /// </summary>
        public int? ResponseStatusCode { get; set; }

        /// <summary>
        /// The response timestamp.
        /// </summary>
        public DateTime ResponseTimestamp { get; set; }

        /// <summary>
        /// The response exception payload.
        /// </summary>
        public PayLoadExcecao ResponseExceptionPayLoad { get; set; }
    }
}