using System.Collections.Generic;

namespace SmsghApi.Sdk.Smsgh
{
    public class ApiDictionary : Dictionary<string , object>
    {
        public ApiDictionary()
            : base(EqualityComparer<string>.Default)
        {
            
        }

        public ApiDictionary(ApiDictionary apiDictionary)
            : base(apiDictionary, EqualityComparer<string>.Default)
        {
            
        }
    }
}
