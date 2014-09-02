using System;
using System.Collections.Generic;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class MediaInfo
    {
        public string ContentName { set; get; }
        public Guid LibraryId { set; get; }
        public string DestinationFolder { set; get; }
        public string Preference { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public bool DrmProtect { set; get; }
        public Dictionary<string, string> Tags { set; get; }
        public bool Streamable { set; get; }
        public string ContentText { set; get; }
        public string DisplayText { set; get; }

    }
}