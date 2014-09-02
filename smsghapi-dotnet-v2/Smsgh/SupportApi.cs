using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class SupportApi : AbstractApi
    {
        public SupportApi(ApiHost host) : base(host) {}

        public ApiList<Ticket> GetSupportTickets(uint page, uint pageSize)
        {
            const string resource = "/tickets/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new ApiList<Ticket>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ApiList<Ticket> GetSupportTickets()
        {
            return GetSupportTickets(0, 0);
        }

        public Ticket GetSupportTicket(ulong ticketId)
        {
            string resource = "/tickets/" + ticketId;
            HttpResponse response = RestClient.Get(resource);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public Ticket AddSupportTicket(Ticket ticket)
        {
            const string resource = "/tickets/";
            const string contentType = "application/json";
            if (ticket == null) throw new HttpRequestException(new Exception("Parameter 'ticket' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, ticket);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public Ticket UpdateSupportTicket(ulong ticketId, TicketResponse reply)
        {
            string resource = "/tickets/" + ticketId;
            const string contentType = "application/json";
            if (reply == null) throw new HttpRequestException(new Exception("Parameter 'reply' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, reply);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }
    }
}