using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class MessagingApi : AbstractApi
    {
        public MessagingApi(ApiHost host) : base(host) {}

        public MessageResponse SendMessage(Message mesg)
        {
            if (mesg == null) throw new Exception("Parameter 'mesg' cannot be null");
            const string resource = "/messages/";
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, mesg);
            const string contentType = "application/json";
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MessageResponse SendQuickMessage(string from, string to, string content, bool registeredDelivery)
        {
            var mesg = new Message {From = @from, Content = content, To = to, RegisteredDelivery = registeredDelivery};
            return SendMessage(mesg);
        }

        public MessageResponse ScheduleMessage(Guid messageId, DateTime time)
        {
            string resource = "/messages/";
            const string contentType = "application/json";
            resource += messageId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(String.Format("{{\"Time\":\"{0}\"}}", time.ToString("yyyy-MM-dd HH:mm:ss"))));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }


        public MessageResponse ScheduleMessage(string messageId, DateTime time)
        {
            string resource = "/messages/";
            if (!messageId.IsGuid()) throw new Exception("messageId must not be null and be a valid UUID");

            const string contentType = "application/json";
            resource += messageId.Replace("-", "");
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(String.Format("{{\"Time\":\"{0}\"}}", time.ToString("yyyy-MM-dd HH:mm:ss"))));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Message GetMessage(Guid messageId)
        {
            string resource = "/messages/";
            resource += messageId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Message(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Message GetMessage(string messageId)
        {
            string resource = "/messages/";
            if (!messageId.IsGuid()) throw new Exception("messageId must not be null and be a valid UUID");
            resource += messageId.Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Message(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Message> GetMessages(DateTime? start, DateTime? end, uint index, uint limit, bool pending, string direction)
        {
            const string resource = "/messages/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (start != null) parameterMap.Set("start", HttpUtility.UrlEncode(start.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")));
            if (end != null) parameterMap.Set("end", HttpUtility.UrlEncode(end.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")));
            if (index > 0) parameterMap.Set("index", Convert.ToString(index));
            if (limit > 0) parameterMap.Set("limit", Convert.ToString(limit));
            parameterMap.Set("pending", pending ? "true" : "false");
            if (!direction.IsEmpty()) parameterMap.Set("direction", direction.Trim());
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Message>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Sender> GetSenderIds(uint page, uint pageSize)
        {
            const string resource = "/senders/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Sender>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Sender> GetSenderIds()
        {
            return GetSenderIds(0, 0);
        }

        public Sender GetSender(ulong senderId)
        {
            string resource = "/senders/" + senderId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender AddSenderId(Sender sender)
        {
            const string resource = "/senders/";
            const string contentType = "application/json";
            if (sender == null) throw new Exception("Parameter 'sender' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, sender);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender AddSenderId(string address)
        {
            const string resource = "/senders/";
            if (string.IsNullOrEmpty(address))
                throw new Exception("Parameter 'address' cannot be null");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Address", address);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender UpdateSenderId(ulong senderId, ParameterMap data)
        {
            string resource = "/senders/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += senderId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender UpdateSenderId(ulong senderId, Sender data)
        {
            string resource = "/senders/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += senderId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender UpdateSenderId(Sender data)
        {
            string resource = "/senders/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Sender UpdateSenderId(ulong senderId, string address)
        {
            string resource = "/senders/";
            if (string.IsNullOrEmpty(address)) throw new Exception("Parameter 'address' cannot be null");
            resource += senderId;
            ParameterMap parameter = RestClient.NewParams();
            parameter.Set("Address", address);
            HttpResponse response = RestClient.Put(resource, parameter);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public bool DeleteSenderId(ulong senderId)
        {
            string resource = "/senders/" + senderId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MessageTemplate> GetMessageTemplates(uint page, uint pageSize)
        {
            const string resource = "/templates/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MessageTemplate>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MessageTemplate> GetMessageTemplates()
        {
            return GetMessageTemplates(0, 0);
        }

        public MessageTemplate GetMessageTemplate(ulong templateId)
        {
            string resource = "/templates/" + templateId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MessageTemplate AddMessageTemplate(MessageTemplate mesgTemplate)
        {
            const string resource = "/templates/";
            const string contentType = "application/json";
            if (mesgTemplate == null) throw new Exception("Parameter 'mesgTemplate' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, mesgTemplate);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MessageTemplate UpdateMessageTemplate(MessageTemplate data)
        {
            string resource = "/templates/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public bool DeleteMessageTemplate(ulong templateId)
        {
            string resource = "/templates/" + templateId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<NumberPlan> GetNumberPlans(uint page, uint pageSize, int type)
        {
            const string resource = "/numberplans/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (type >= 0) parameterMap.Set("Type", Convert.ToString(type));

            if (page == 0 && pageSize == 0 && type < 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<NumberPlan>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<NumberPlan> GetNumberPlans()
        {
            return GetNumberPlans(0, 0, -1);
        }

        public ApiList<MoKeyWord> GetNumberPlanMoKeywords(ulong numberPlanId, uint page, uint pageSize)
        {
            string resource = "/numberplans/" + numberPlanId + "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MoKeyWord> GetNumberPlanMoKeywords(ulong numberPlanId)
        {
            return GetNumberPlanMoKeywords(numberPlanId, 0, 0);
        }

        public ApiList<MoKeyWord> GetCampaignMoKeywords(ulong campaignId, uint page, uint pageSize)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MoKeyWord> GetCampaignMoKeywords(ulong campaignId)
        {
            return GetCampaignMoKeywords(campaignId, 0, 0);
        }

        public ApiList<Campaign> GetCampaigns(uint page, uint pageSize, int type)
        {
            const string resource = "/campaigns/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (type >= 0) parameterMap.Set("Type", Convert.ToString(type));

            if (page == 0 && pageSize == 0 && type < 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Campaign>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Campaign> GetCampaigns()
        {
            return GetCampaigns(0, 0, -1);
        }

        public Campaign GetCampaign(ulong campaignId)
        {
            string resource = "/campaigns/" + campaignId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }


        public NumberPlan GetNumberPlan(ulong numberPlanId)
        {
            string resource = "/numberplans/" + numberPlanId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new NumberPlan(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MoKeyWord> GetMoKeywords(uint page, uint pageSize)
        {
            const string resource = "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<MoKeyWord> GetMoKeywords()
        {
            return GetMoKeywords(0, 0);
        }

        public MoKeyWord GetMoKeyword(ulong keywordId)
        {
            string resource = "/keywords/" + keywordId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign AddCampaign(Campaign campaign)
        {
            const string resource = "/campaigns/";
            const string contentType = "application/json";
            if (campaign == null) throw new Exception("Parameter 'campaign' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, campaign);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign UpdateCampaign(Campaign campaign)
        {
            string resource = "/campaigns/";
            const string contentType = "application/json";
            if (campaign == null) throw new HttpRequestException(new Exception("Parameter 'campaign' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, campaign);
            resource += campaign.CampaignId;
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign UpdateCampaign(ulong campaignId, Campaign data)
        {
            string resource = "/campaigns/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += campaignId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public bool DeleteCampaign(ulong campaignId)
        {
            string resource = "/campaigns/" + campaignId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MoKeyWord AddMoKeyword(MoKeyWord keyword)
        {
            const string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new HttpRequestException(new Exception("Parameter 'keyword' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MoKeyWord UpdateMoKeyword(ulong keywordId, MoKeyWord keyword)
        {
            string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new Exception("Parameter 'keyword' cannot be null");
            resource += keywordId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public MoKeyWord UpdateMoKeyword(MoKeyWord keyword)
        {
            string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new Exception("Parameter 'keyword' cannot be null");
            resource += keyword.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public bool DeleteMoKeyword(ulong keywordId)
        {
            string resource = "/keywords/" + keywordId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign SetCampaignMoKeyword(ulong campaignId, long keywordId)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/" + keywordId;
            HttpResponse response = RestClient.Put(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign DeleteCampaignMoKeyword(ulong campaignId, long keywordId)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/" + keywordId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Action> GetCampaignActions(ulong campaignId, uint page, uint pageSize)
        {
            string resource = "/campaigns/" + campaignId + "/actions/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Action>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public ApiList<Action> GetCampaignActions(ulong campaignId)
        {
            return GetCampaignActions(campaignId, 0, 0);
        }

        public Campaign SetCampaignDefaultReplyTextAction(ulong campaignId, string message)
        {
            string resource = "/campaigns/" + campaignId + "/actions/default_reply";
            if (message.IsEmpty()) throw new HttpRequestException(new Exception("Parameter 'message' cannot be empty "));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("message", message);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign SetCampaignDynamicUrlAction(ulong campaignId, string url, string sendResponse)
        {
            string resource = "/campaigns/" + campaignId + "/actions/dynamic_url";
            if (url.IsValidUrl()) throw new HttpRequestException(new Exception("Parameter 'url' must be a valid url"));
            if (sendResponse.IsEmpty()) throw new HttpRequestException(new Exception("Parameter 'sendResponse' cannot be null"));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("url", url).Set("send_response", sendResponse);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign SetCampaignDynamicUrlAction(ulong campaignId, string url)
        {
            return SetCampaignDynamicUrlAction(campaignId, url, "No");
        }

        public Campaign SetCampaignEmailAddressAction(ulong campaignId, string address)
        {
            string resource = "/campaigns/" + campaignId + "/actions/email";
            if (address.IsEmail()) throw new HttpRequestException(new Exception("Parameter 'address' must be a valid email "));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("address", address);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign SetCampaignForwardToMobileAction(ulong campaignId, string number)
        {
            string resource = "/campaigns/" + campaignId + "/actions/phone";
            if (number.IsEmpty()) throw new HttpRequestException(new Exception("Parameter 'number' must not be empty."));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("number", number);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign SetCampaignForwardToSmppAction(ulong campaignId, string smppApiId)
        {
            string resource = "/campaigns/" + campaignId + "/actions/smpp";
            if (smppApiId.IsEmpty()) throw new HttpRequestException(new Exception("Parameter 'smppApiId' must not be empty"));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("api_id", smppApiId);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        public Campaign DeleteCampaignAction(ulong campaignId, ulong actionId)
        {
            string resource = "/campaigns/" + campaignId + "/actions/" + actionId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}