using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class OAuth : IAuth
    {
        public OAuth(string bearerToken)
        {
            BearerToken = bearerToken;
        }

        public string BearerToken { private set; get; }

        public string GetCredentials()
        {
            string encoded = String.Format("Bearer {0}", BearerToken);
            return encoded;
        }
    }
}