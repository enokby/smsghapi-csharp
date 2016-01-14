using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smsghapi_dotnet_v2.Smsgh;

namespace smsghapi_dotnet_v2_tests
{
    [TestClass]
    public class UnitTest1
    {
        public const string clientId = "hqikydyh";
        public const string clientSecret = "kakdxpvd";

        [TestInitialize]
        public void Init()
        {
            // Initialisations
        }

        [TestMethod]
        public void Sms_Is_Effectively_Sent()
        {
            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("Arsene", "+233506290240", "Hello Big Bro!", true);
                Console.WriteLine(msg.Status);                
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }
        }
    }
}
