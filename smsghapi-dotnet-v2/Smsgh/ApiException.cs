// $Id: ApiException.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ApiException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of this API exception class.
        /// </summary>
        public ApiException(string message) : base(message)
        {
            HttpStatusCode = 400;
            Reason = string.Empty;
            Description = string.Empty;
            RawBody = string.Empty;
        }

        public int HttpStatusCode { set; get; }
        public string Reason { set; get; }
        public string Description { set; get; }
        public string RawBody { set; get; }
    }
}