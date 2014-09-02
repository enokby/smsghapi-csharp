using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class HttpRequestException : Exception
    {
        public HttpRequestException(Exception e, HttpResponse httpResponse) : base(e.Message)
        {
            HttpResponse = httpResponse;
        }

        public HttpRequestException(Exception e) : base(e.Message) {}
        public HttpResponse HttpResponse { private set; get; }
    }
}