using System;
using System.IO;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ContentMediaFile
    {
        private readonly string _fileExtension;
        private readonly string _fileLocalName;
        private readonly string _streamType;
        public ContentMediaFile() {}

        public ContentMediaFile(string fileName, string mediaType, byte[] fileContent)
        {
            FileName = fileName;

            _fileExtension = Path.GetExtension(fileName);
            _fileLocalName = string.Format("{0}{1}", Guid.NewGuid(), FileExtension);
            MediaType = mediaType;
            FileContent = fileContent;
            _streamType = mediaType == null ? null : mediaType.Split('/')[0];
        }

        public string FileName { get; set; }

        /// <summary>
        ///     ContentFile Mime Type
        /// </summary>
        public string MediaType { get; set; }

        public byte[] FileContent { get; set; }

        public string FileExtension
        {
            get { return _fileExtension; }
        }

        public string FileLocalName
        {
            get { return _fileLocalName; }
        }

        public string StreamType
        {
            get { return _streamType; }
        }
    }
}