using System;
using System.Globalization;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class TicketResponse
    {
        private readonly string _attachment;
        private readonly long _id;


        public TicketResponse() {}

        public TicketResponse(ApiDictionary json) : this()
        {
            foreach (string key in json.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = Convert.ToInt64(json[key]);
                        break;
                    case "time":
                        DateTime timeParsed;
                        if (json[key].ToString() != "")
                            Time = DateTime.TryParseExact(json[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        break;
                    case "content":
                        Content = Convert.ToString(json[key]);
                        break;
                    case "attachment":
                        _attachment = Convert.ToString(json[key]);
                        break;
                }
            }
        }

        [JsonIgnore]
        public DateTime? Time { get; private set; }

        public string Content { get; set; }

        [JsonIgnore]
        public long Id
        {
            get { return _id; }
        }

        [JsonIgnore]
        public string Attachment
        {
            get { return _attachment; }
        }
    }
}