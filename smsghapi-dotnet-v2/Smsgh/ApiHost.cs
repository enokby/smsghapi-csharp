namespace smsghapi_dotnet_v2.Smsgh
{
    public class ApiHost
    {
        public ApiHost()
        {
            Hostname = "api.smsgh.com";
            Port = -1;
            ContextPath = "v3";
            Timeout = 5000;
            EnabledConsoleLog = true;
            SecuredConnection = false;
            Auth = null;
        }


        public ApiHost(IAuth auth) : this()
        {
            Auth = auth;
        }

        public string Hostname { set; get; }
        public int Port { set; get; }
        public string ContextPath { set; get; }
        public int Timeout { set; get; }
        public bool EnabledConsoleLog { set; get; }
        public IAuth Auth { set; get; }

        public bool SecuredConnection { set; get; }
    }
}