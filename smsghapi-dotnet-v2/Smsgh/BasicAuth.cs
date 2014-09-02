using System;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class BasicAuth : IAuth
    {
        public BasicAuth(string userName, string password)
        {
            Password = password;
            UserName = userName;
        }

        public string UserName { private set; get; }
        public string Password { private set; get; }

        public string GetCredentials()
        {
            string encoded = String.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", UserName, Password))));
            return encoded;
        }
    }
}