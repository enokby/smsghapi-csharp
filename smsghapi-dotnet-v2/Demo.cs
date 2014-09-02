using System;
using System.Collections.Generic;
using System.Web.WebSockets;
using smsghapi_dotnet_v2.Smsgh;

namespace smsghapi_dotnet_v2
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            const string clientId = "hqikydyh";
            const string clientSecret = "kakdxpvd";


            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("Arsene", "+233247063817", "Hello Big Bro!", true);
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

            Console.ReadKey();
        }
    }
}