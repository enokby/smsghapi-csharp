using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ContentFolder
    {
        private readonly long _contentFolderId;
        private readonly long _contentMediaCount;
        private readonly List<ContentFolder> _folders;
        private readonly List<ContentMedia> _medias;
        private readonly long _subFolderCount;
        public ContentFolder() {}

        public ContentFolder(ApiDictionary jso)
        {
            _folders = new List<ContentFolder>();
            _medias = new List<ContentMedia>();
            foreach (string key in jso.Keys)
                switch (key.ToLower()) {
                    case "contentfolderid":
                        _contentFolderId = Convert.ToInt64(jso[key]);
                        break;
                    case "contentlibraryid":
                        ContentLibraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "foldername":
                        FolderName = Convert.ToString(jso[key]);
                        break;
                    case "absolutepath":
                        AbosultePath = Convert.ToString(jso[key]);
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
                    case "parentid":
                        ParentId = Convert.ToInt64(jso[key]);
                        break;
                    case "subfoldercount":
                        _subFolderCount = Convert.ToInt64(jso[key]);
                        break;
                    case "contentmediacount":
                        _contentMediaCount = Convert.ToInt64(jso[key]);
                        break;
                    case "subfolders":
                        var subfolders = jso[key] as IEnumerable;
                        if (subfolders != null)
                            foreach (JObject mo in subfolders) {
                                _folders.Add(new ContentFolder(mo.ToObject<ApiDictionary>()));
                            }
                        break;
                    case "contentmedias":
                        var medias = jso[key] as IEnumerable;
                        if (medias != null)
                            foreach (JObject mo in medias) {
                                _medias.Add(new ContentMedia(mo.ToObject<ApiDictionary>()));
                            }
                        break;
                }
        }

        [JsonIgnore]
        public long ContentFolderId
        {
            get { return _contentFolderId; }
        }

        [JsonIgnore]
        public long SubFolderCount
        {
            get { return _subFolderCount; }
        }

        [JsonIgnore]
        public long ContentMediaCount
        {
            get { return _contentMediaCount; }
        }

        [JsonIgnore]
        public List<ContentFolder> Folders
        {
            get { return _folders; }
        }

        public List<ContentMedia> Medias
        {
            get { return _medias; }
        }

        public Guid ContentLibraryId { set; get; }
        public string FolderName { set; get; }
        public string AbosultePath { set; get; }
        public long? ParentId { set; get; }
        public DateTime? DateCreated { set; get; }
        public DateTime? DateModified { set; get; }
    }
}