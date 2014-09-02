using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class Tag
    {
        public Tag() {}

        public Tag(ApiDictionary jso)
        {
            foreach (string key in jso.Keys)
                switch (key.ToLower()) {
                    case "key":
                        Key = Convert.ToString(jso[key]);
                        break;
                    case "value":
                        Value = Convert.ToString(jso[key]);
                        break;
                }
        }

        public string Key { set; get; }
        public string Value { set; get; }
    }
}