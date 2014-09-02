using System;
using System.Globalization;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ContentLibrary
    {
        /// <summary>
        ///     Unity Account Id attached to the Library
        /// </summary>
        private readonly string _accountId;

        private readonly long _folderId;

        /// <summary>
        ///     Library Id
        /// </summary>
        private readonly Guid _libraryId;

        public ContentLibrary() {}

        public ContentLibrary(ApiDictionary jso)
        {
            foreach (string key in jso.Keys)
                switch (key.ToLower()) {
                    case "libraryid":
                        _libraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                    case "shortname":
                        ShortName = Convert.ToString(jso[key]);
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
                                : (DateTime?) null;
                        break;
                    case "folderid":
                        _folderId = Convert.ToInt64(jso[key]);
                        break;
                }
        }

        /// <summary>
        ///     Library Name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     Library Short Name
        /// </summary>
        public string ShortName { set; get; }

        /// <summary>
        ///     Gets or sets the created date of this Library.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        ///     Gets or sets the modification date of the Library
        /// </summary>
        public DateTime? DateModified { get; set; }

        [JsonIgnore]
        public Guid LibraryId
        {
            get { return _libraryId; }
        }

        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        [JsonIgnore]
        public long FolderId
        {
            get { return _folderId; }
        }
    }
}