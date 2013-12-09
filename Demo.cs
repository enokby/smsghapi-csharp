using Smsgh;

public class Demo
{
    /**
     * Main
     */
    public static void Main()
    {
        SmsghApiHost apiHost = new SmsghApiHost();
        apiHost.ClientId = "user123";
        apiHost.ClientSecret = "secret";
        apiHost.ContextPath = "v3";
        apiHost.Hostname = "api.smsgh.com"
        
        try {
            /**
             * Sending a quick message.
             */
            apiHost.Messages
                .Send("SMSGH", "+233248183783", "Hello world!");
                
            /**
             * Sending a message with extended properties.
             */
            ApiMessage apiMessage = new ApiMessage();
            apiMessage.From = "SMSGH";
            apiMessage.To = "+233248183783";
            apiMessage.Content = "Hello world!";
            apiMessage.IsRegisteredDelivery = true;
            apiHost.Messages.Send(apiMessage);
            
            /**
             * Scheduling a message.
             */
            // ApiMessage
            apiMessage = new ApiMessage();
            apiMessage.From = "SMSGH";
            apiMessage.To = "+233248183783";
            apiMessage.Content = "Hello world!";
            apiHost.Messages
                .Schedule(apiMessage, System.DateTime.Now.AddDays(1));
        } catch (ApiException ex) {
            System.Console.WriteLine("Exception: {0}", ex.Message);
        }
    }
}
