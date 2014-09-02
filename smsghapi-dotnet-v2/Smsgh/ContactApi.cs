using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class ContactApi : AbstractApi
    {
        public ContactApi(ApiHost host) : base(host) {}

        public ApiList<Contact> GetContacts(uint page, uint pageSize, ulong groupId, string filter)
        {
            const string resource = "/contacts/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (groupId > 0) parameterMap.Set("GroupId", Convert.ToString(groupId));
            if (!filter.IsEmpty()) parameterMap.Set("Search", filter.Trim());

            if (page == 0 && pageSize == 0 && groupId == 0 && filter.IsEmpty()) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new ApiList<Contact>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ApiList<Contact> GetContacts(uint page, uint pageSize)
        {
            return GetContacts(page, pageSize, 0, string.Empty);
        }

        public ApiList<Contact> GetContacts(ulong groupId, string filter)
        {
            return GetContacts(0, 0, groupId, filter);
        }

        public ApiList<Contact> GetContacts(uint page, uint pageSize, ulong groupId)
        {
            return GetContacts(page, pageSize, groupId, string.Empty);
        }

        public ApiList<Contact> GetContacts(uint page, uint pageSize, string filter)
        {
            return GetContacts(page, pageSize, 0, filter);
        }

        public ApiList<Contact> GetContacts()
        {
            return GetContacts(0, 0, 0, string.Empty);
        }

        public ApiList<Contact> GetContacts(ulong groupId)
        {
            return GetContacts(0, 0, groupId, string.Empty);
        }

        public ApiList<Contact> GetContacts(string filter)
        {
            return GetContacts(0, 0, 0, filter);
        }

        public Contact GetContact(ulong contactId)
        {
            string resource = "/contacts/" + contactId;
            HttpResponse response = RestClient.Get(resource);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public Contact AddContact(ParameterMap data)
        {
            const string resource = "/contacts/";
            if (data == null) throw new HttpRequestException(new Exception("Parameter 'data' cannot be null"));
            HttpResponse response = RestClient.Post(resource, data);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.Created)) {
                return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public Contact AddContact(Contact contact)
        {
            const string resource = "/contacts/";
            const string contentType = "application/json";
            if (contact == null) throw new HttpRequestException(new Exception("Parameter 'contact' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, contact);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.Created)) {
                return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContact(ulong contactId, ParameterMap data)
        {
            string resource = "/contacts/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += contactId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContact(ulong contactId, Contact data)
        {
            string resource = "/contacts/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += contactId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContact(Contact data)
        {
            string resource = "/contacts/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.ContactId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool DeleteContact(ulong contactId)
        {
            string resource = "/contacts/" + contactId;
            HttpResponse response = RestClient.Delete(resource);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return true;
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ApiList<ContactGroup> GetContactGroups(uint page, uint pageSize)
        {
            const string resource = "/contacts/groups/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0 && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new ApiList<ContactGroup>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ApiList<ContactGroup> GetContactGroups()
        {
            return GetContactGroups(0, 0);
        }

        public ContactGroup GetContactGroup(ulong groupId)
        {
            string resource = "/contacts/groups/" + groupId;
            HttpResponse response = RestClient.Get(resource);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ContactGroup AddContactGroup(ContactGroup group)
        {
            const string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (group == null) throw new HttpRequestException(new Exception("Parameter 'group' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, group);
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.Created)) {
                return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ContactGroup AddContactGroup(string groupName)
        {
            const string resource = "/contacts/groups/";
            if (groupName.IsEmpty())
                throw new HttpRequestException(new Exception("Parameter 'groupName' cannot be null"));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Name", groupName);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.Created)) {
                return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public ContactGroup AddContactGroup(ParameterMap data)
        {
            const string resource = "/contacts/groups/";
            if (data == null) throw new HttpRequestException(new Exception("Parameter 'data' cannot be null"));
            HttpResponse response = RestClient.Post(resource, data);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.Created)) {
                return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContactGroup(ulong groupId, ParameterMap data)
        {
            string resource = "/contacts/groups/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += groupId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContactGroup(ulong groupId, ContactGroup data)
        {
            string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += groupId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContactGroup(ContactGroup data)
        {
            string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.GroupId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool UpdateContactGroup(ulong groupId, string groupName)
        {
            string resource = "/contacts/groups/";
            if (groupName.IsEmpty()) throw new Exception("Parameter 'groupName' cannot be null");
            resource += groupId;
            ParameterMap parameter = RestClient.NewParams();
            parameter.Set("Name", groupName);
            HttpResponse response = RestClient.Put(resource, parameter);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return true;
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        public bool DeleteContactGroup(ulong groupId)
        {
            string resource = "/contacts/groups/" + groupId;
            HttpResponse response = RestClient.Delete(resource);
            if (response != null && response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                return true;
            }
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }
    }
}