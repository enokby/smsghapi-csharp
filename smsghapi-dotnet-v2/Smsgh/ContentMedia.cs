using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ContentMedia
    {
        private readonly string _accountId;
        private readonly Guid _id;
        public ContentMedia() {}

        public ContentMedia(ApiDictionary jso)
        {
            Tags = new List<Tag>();
            foreach (string key in jso.Keys)
                switch (key.ToLower()) {
                    case "id":
                        _id = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                    case "libraryid":
                        LibraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "locationpath":
                        LocationPath = Convert.ToString(jso[key]);
                        break;
                    case "tags":
                        var tags = jso[key] as IEnumerable;
                        if (tags != null)
                            foreach (JObject mo in tags) {
                                Tags.Add(new Tag(mo.ToObject<ApiDictionary>()));
                            }
                        break;
                    case "type":
                        Type = Convert.ToString(jso[key]);
                        break;
                    case "preference":
                        Preference = Convert.ToString(jso[key]);
                        break;
                    case "drmprotect":
                        DrmProtect = Convert.ToBoolean(jso[key]);
                        break;
                    case "encodingstatus":
                        EncodingStatus = Convert.ToString(jso[key]);
                        break;
                    case "streamable":
                        Streamable = Convert.ToBoolean(jso[key]);
                        break;
                    case "displaytext":
                        DisplayText = Convert.ToString(jso[key]);
                        break;
                    case "contenttext":
                        ContentText = Convert.ToString(jso[key]);
                        break;
                    case "approved":
                        Approved = Convert.ToBoolean(jso[key]);
                        break;
                    case "deleted":
                        Deleted = Convert.ToBoolean(jso[key]);
                        break;
                    case "datecreated":
                        DateTime dateCreated;
                        if (jso[key].ToString() != "")
                            DateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        break;
                    case "datemodified":
                        DateTime dateModified;
                        if (jso[key].ToString() != "")
                            DateModified = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified)
                                ? dateModified
                                : (DateTime?)null;
                        break;
                    case "datedeleted":
                        DateTime dateDeleted;
                        if (jso[key].ToString() != "")
                            DateDeleted = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDeleted)
                                ? dateDeleted
                                : (DateTime?)null;
                        break;
                    case "callbackurl":
                        CallbackUrl = Convert.ToString(jso[key]);
                        break;
                }
        }

        [JsonIgnore]
        public Guid Id
        {
            get { return _id; }
        }

        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        public string Name { set; get; }
        public Guid LibraryId { set; get; }
        public string LocationPath { set; get; }
        public List<Tag> Tags { set; get; }
        public string Type { set; get; }
        public string Preference { set; get; }
        public bool DrmProtect { set; get; }
        public string EncodingStatus { set; get; }
        public bool Streamable { set; get; }
        public string DisplayText { set; get; }
        public string ContentText { set; get; }
        public bool Approved { set; get; }
        public bool Deleted { set; get; }
        public DateTime? DateCreated { set; get; }
        public DateTime? DateModified { set; get; }
        public DateTime? DateDeleted { set; get; }
        public string CallbackUrl { set; get; }
    }
}