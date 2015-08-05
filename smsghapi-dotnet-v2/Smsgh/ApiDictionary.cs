using System.Collections.Generic;

namespace smsghapi_dotnet_v2.Smsgh
{
    /// <summary>
    ///     Custom Dictionary
    /// </summary>
    public class ApiDictionary : Dictionary<string, object>
    {
        /// <summary>
        /// </summary>
        public ApiDictionary() : base(EqualityComparer<string>.Default) {}

        /// <summary>
        /// </summary>
        /// <param name="apiDictionary"></param>
        public ApiDictionary(ApiDictionary apiDictionary) : base(apiDictionary, EqualityComparer<string>.Default) {}
    }
}