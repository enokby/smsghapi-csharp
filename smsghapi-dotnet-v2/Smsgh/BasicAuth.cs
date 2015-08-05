using System;
using System.Text;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    ///     Basic Authorization Wrapper
    /// </summary>
    public class BasicAuth : IAuth
    {
        /// <summary>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public BasicAuth(string userName, string password)
        {
            Password = password;
            UserName = userName;
        }

        /// <summary>
        ///     The user name
        /// </summary>
        public string UserName { private set; get; }

        /// <summary>
        ///     The password
        /// </summary>
        public string Password { private set; get; }

        /// <summary>
        ///     Generate the BASIC AUTH header string
        /// </summary>
        /// <returns>Basic Auth header string</returns>
        public string GetCredentials()
        {
            string encoded = String.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", UserName, Password))));
            return encoded;
        }
    }
}