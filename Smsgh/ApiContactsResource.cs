// $Id: ApiContactsResource.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
    ///     Represents an API contacts resource.
    /// </summary>
    public class ApiContactsResource
    {
        // Data fields.
        private readonly SmsghApiHost _apiHostHost;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiContactsResource" /> class.
        /// </summary>
        public ApiContactsResource(SmsghApiHost apiHostHost)
        {
            _apiHostHost = apiHostHost;
        }

        /// <summary>
        ///     Retrieves all API contacts.
        /// </summary>
        public ApiList<ApiContact> Get()
        {
            return Get(-1, -1, -1, null);
        }

        /// <summary>
        ///     Retrieves API contacts by group ID and filter.
        /// </summary>
        /// <param name="groupId">ID of the group to retrieve its contacts.</param>
        /// <param name="filter">Filter to narrow the results.</param>
        public ApiList<ApiContact> Get(long groupId, string filter)
        {
            return Get(-1, -1, groupId, filter);
        }

        /// <summary>
        ///     Retrieves API contacts by page and page size.
        /// </summary>
        /// <param name="page">One-based index of page.</param>
        /// <param name="pageSize">Maximum number of entries in page.</param>
        public ApiList<ApiContact> Get(int page, int pageSize)
        {
            return Get(page, pageSize, -1, null);
        }

        /// <summary>
        ///     Retrieves API contacts by page, page size, group ID and filter.
        /// </summary>
        /// <param name="page">One-based index of page.</param>
        /// <param name="pageSize">Maximum number of entries in page.</param>
        /// <param name="groupId">ID of the group to retrieve its contacts.</param>
        /// <param name="filter">Filter to narrow the results.</param>
        public ApiList<ApiContact> Get
            (int page, int pageSize, long groupId, string filter)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/";
            }
            //string uri = "/v3/contacts";
            if (groupId > 0)
                uri += "?GroupId=" + groupId;
            if (filter != null)
            {
                uri += String.Format("{0}Filter={1}",
                    groupId > 0 ? "&" : "?",
                    HttpUtility.UrlEncode(filter));
            }
            return ApiHelper.GetApiList<ApiContact>
                (_apiHostHost, uri, page, pageSize, uri.IndexOf("?", System.StringComparison.InvariantCulture) > 0);
        }

        /// <summary>
        ///     Retrieves an API contact by ID.
        /// </summary>
        /// <param name="contactId">ID of the contact to retrieve.</param>
        public ApiContact Get(long contactId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/";
            }

            try
            {
                return new ApiContact(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri + contactId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Creates a new API contact.
        /// </summary>
        /// <param name="apiContact">The API contact to create.</param>
        public ApiContact Create(ApiContact apiContact)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/";
            }

            try
            {
                if (apiContact == null)
                    throw new ArgumentNullException("apiContact");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiContact);
                return new ApiContact(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates an API contact.
        /// </summary>
        /// <param name="apiContact">The API contact to update.</param>
        public void Update(ApiContact apiContact)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/";
            }


            try
            {
                if (apiContact == null)
                    throw new ArgumentNullException("apiContact");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiContact);
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "PUT", uri + apiContact.ContactId,
                        Encoding.UTF8.GetBytes(zw.ToString()));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }

        /// <summary>
        ///     Deletes an API contact by ID.
        /// </summary>
        /// <param name="contactId"> Contact Id </param>
        public void Delete(long contactId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/";
            }

            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "DELETE", uri + contactId, null);
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }

        /// <summary>
        ///     Retrieves all API contact groups.
        /// </summary>
        public ApiList<ApiContactGroup> GetGroups()
        {
            return GetGroups(-1, -1);
        }

        /// <summary>
        ///     Retrieves API contact groups by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiContactGroup> GetGroups(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/groups/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/groups/";
            }


            return ApiHelper.GetApiList<ApiContactGroup>
                (_apiHostHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Retrieves an API contact group by ID.
        /// </summary>
        /// <param name="groupId">ID of the contact group to query.</param>
        public ApiContactGroup GetGroup(long groupId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/groups/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/groups/";
            }


            try
            {
                return new ApiContactGroup(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri + groupId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Creates a new API contact group.
        /// </summary>
        /// <param name="apiContactGroup">The API contact group to create.</param>
        public ApiContactGroup CreateGroup(ApiContactGroup apiContactGroup)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/groups/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/groups/";
            }


            try
            {
                if (apiContactGroup == null)
                    throw new ArgumentNullException("apiContactGroup");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiContactGroup);
                return new ApiContactGroup(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates an API contact group.
        /// </summary>
        /// <param name="apiContactGroup">API contact group to update.</param>
        public void UpdateGroup(ApiContactGroup apiContactGroup)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/groups/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/groups/";
            }


            try
            {
                if (apiContactGroup == null)
                    throw new ArgumentNullException("apiContactGroup");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiContactGroup);
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "PUT", uri + apiContactGroup.GroupId,
                        Encoding.UTF8.GetBytes(zw.ToString()));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }

        /// <summary>
        ///     Deletes an API contact group by ID.
        /// </summary>
        /// <param name="groupId">ID of the API contact group to delete.</param>
        public void DeleteGroup(long groupId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/contacts/groups/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/contacts/groups/";
            }

            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "DELETE", uri + groupId, null);
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }
    }
}