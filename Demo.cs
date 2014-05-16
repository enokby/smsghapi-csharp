using System;
using SmsghApi.Sdk.Smsgh;

namespace SmsghApi.Sdk
{
    public class Demo
    {
        /**
     * Main
     */

        public static void Main()
        {
            var apiHost = new SmsghApiHost
            {
                ClientId = "user123",
                ClientSecret = "btfder",
                ContextPath = "v3",
                Hostname = "api.smsgh.com"
            };

            try
            {
                /**
             * Sending a quick message.
             */
                ApiMessageResponse response = apiHost.Messages
                    .Send("SMSGH", "+23324818378", "Hello world!");
                Console.WriteLine(response.Status);
                Console.ReadKey();

                /**
             * Sending a message with extended properties.
             */
                //ApiMessage apiMessage = new ApiMessage();
                //apiMessage.From = "SMSGH";
                //apiMessage.To = "+233248183783";
                //apiMessage.Content = "Hello world!";
                //apiMessage.RegisteredDelivery = true;
                //apiHost.Messages.Send(apiMessage);

                /**
             * Scheduling a message.
             */
                // ApiMessage
                //apiMessage = new ApiMessage();
                //apiMessage.From = "SMSGH";
                //apiMessage.To = "+233248183783";
                //apiMessage.Content = "Hello world!";
                //apiHost.Messages
                //    .Schedule(apiMessage, System.DateTime.Now.AddDays(1));
            }
            catch (ApiException ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
                Console.WriteLine("Server Status : {0}", ex.HttpStatusCode);
                Console.WriteLine("Server Reason: {0}", ex.Reason);
                Console.WriteLine("Server Data Body: {0}", ex.RawBody);
                Console.ReadKey();
            }
        }
    }
}