namespace smsghapi_dotnet_v2.Smsgh
{
    public abstract class AbstractApi
    {
        protected static BasicRestClient RestClient;
        protected static ApiHost Host;

        protected AbstractApi(ApiHost host)
        {
            Host = host;
            string baseUrl = Host.SecuredConnection ? "https://" : "http://";
            baseUrl += Host.Hostname;

            if (Host.Port > 0) baseUrl += ":" + Host.Port;
            if (!Host.ContextPath.IsEmpty()) baseUrl += "/" + Host.ContextPath;

            RestClient = new BasicRestClient(baseUrl, Host.EnabledLog);

            // Add additional headers to process requests
            RestClient.RequestHeaders.Add("Authorization", Host.Auth.GetCredentials());
            RestClient.ConnectionTimeout = Host.Timeout;
            RestClient.ReadWriteTimeout = Host.Timeout;
        }
    }
}