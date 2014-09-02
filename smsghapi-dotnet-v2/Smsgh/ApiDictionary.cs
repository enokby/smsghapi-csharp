using System.Collections.Generic;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ApiDictionary : Dictionary<string, object>
    {
        public ApiDictionary() : base(EqualityComparer<string>.Default) {}

        public ApiDictionary(ApiDictionary apiDictionary) : base(apiDictionary, EqualityComparer<string>.Default) {}
    }
}