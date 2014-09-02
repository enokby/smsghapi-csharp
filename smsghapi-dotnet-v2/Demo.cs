using System;
using System.Collections.Generic;
using System.Web.WebSockets;
using smsghapi_dotnet_v2.Smsgh;

namespace smsghapi_dotnet_v2
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            const string clientId = "hqikydyh";
            const string clientSecret = "kakdxpvd";
            const string hostname = "api.smsgh.local";
            const string contextPath = "";


            try {
                var host = new ApiHost {ContextPath = contextPath, EnabledLog = true, Hostname = hostname, Auth = new BasicAuth(clientId, clientSecret)};

                //var messageApi = new MessagingApi(host);
                //MessageResponse msg = messageApi.SendQuickMessage("Arsene", "+233247063817", "Hello Big Bro!", true);
                //Console.WriteLine(msg.Status);

                //const string messageId = "9327e44b281049f090fcae3ebbccb883";

                //// The message will be sent four days from today
                //DateTime sendTime = DateTime.UtcNow.AddDays(4);

                //msg = messageApi.ScheduleMessage(messageId, sendTime);

                //var accountApi = new AccountApi(host);
                //AccountProfile profile = accountApi.GetAccountProfile();
                //Console.WriteLine("Profile Account Id {0}", profile.AccountId);

                //List<AccountContact> contacts = accountApi.GetContacts();
                //foreach (AccountContact accountContact in contacts)
                //{
                //    Console.WriteLine("Account Contact ID {0}", accountContact.AccountContactId);
                //}

                var contentApi = new ContentApi(host);
                var filters = new Dictionary<string, string>() { { "LibraryId", "9327e44b281049f090fcae3ebbccb883" }, { "Author", "arsene" }, { "LocationPath", "walterdido/music/chants/" } };
                ApiList<ContentMedia> list = contentApi.GetContentMedias(filters);

                //ApiList<ContentLibrary> libraries = contentApi.GetContentLibraries();
                //foreach (ContentLibrary lib in libraries)
                //{
                //    Console.WriteLine("***** Library Data ******");
                //    Console.WriteLine("Library Name {0}", lib.Name);
                //    Console.WriteLine("Library ShortName {0}", lib.ShortName);
                //    Console.WriteLine();
                //}

                //ApiList<ContentMedia> medias = contentApi.GetContentMedias();
                //foreach (ContentMedia media in medias)
                //{
                //    Console.WriteLine("***** Content Media Data ******");
                //    Console.WriteLine("Media Name {0}", media.Name);
                //    Console.WriteLine("Media Display Text {0}", media.DisplayText);
                //    if (media.Tags != null && media.Tags.Count > 0)
                //    {
                //        Console.WriteLine("--------Media Tags---------");
                //        foreach (Tag tag in media.Tags)
                //        {
                //            Console.WriteLine("Tag Key {0}", tag.Key);
                //            Console.Write("Tag Val {0}", tag.Value);
                //        }
                //    }

                //    Console.WriteLine();
                //}

                var mediaInfo = new MediaInfo
                {
                    ContentName = "SDK Media 2",
                    DisplayText = "View this tube [CONTENT] by [Author]",
                    LibraryId = new Guid("9327e44b-2810-49f0-90fc-ae3ebbccb883"),
                    Streamable = false,
                    DrmProtect = true,
                    Tags = new Dictionary<string, string>() { { "Author", "Arsene GANDOTE" } },
                    Preference = "N/A"
                };

                const string filePath = @"C:\Users\smsgh\Music\CeCe Winans\Comforter _Cece Winans.mp3";

                var response = contentApi.AddContentMedia(filePath, mediaInfo);
                //const string mediaId = "ce3779b6-6213-4ec3-aa50-2b665ded1bbf";
                //Console.WriteLine("Deleted {0}", contentApi.DeleteContentMedia(mediaId));
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }
}