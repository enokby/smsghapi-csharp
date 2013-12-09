// $Id: ApiBulkMessagingResource.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
    ///     Represents an API bulk messaging resource.
    /// </summary>
    public class ApiBulkMessagingResource
    {
        private readonly SmsghApiHost _apiHostHost;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiBulkMessagingResource" /> class.
        /// </summary>
        public ApiBulkMessagingResource(SmsghApiHost apiHostHost)
        {
            this._apiHostHost = apiHostHost;
        }

        /// <summary>
        ///     Retrieves all API senders.
        /// </summary>
        public ApiList<ApiSender> GetSenders()
        {
            return GetSenders(-1, -1);
        }

        /// <summary>
        ///     Retrieves API senders by page and pageSize.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in page.</param>
        public ApiList<ApiSender> GetSenders(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/senders/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/senders/";
            }
            return ApiHelper.GetApiList<ApiSender>
                (_apiHostHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Retrieves an API sender by ID.
        /// </summary>
        /// <param name="senderId">ID of the sender to retrieve.</param>
        public ApiSender GetSender(long senderId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/senders/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/senders/";
            }
            return new ApiSender(ApiHelper.GetJson<ApiDictionary>
                (_apiHostHost, "GET", uri + senderId, null));
        }

        /// <summary>
        ///     Creates a new API sender.
        /// </summary>
        /// <param name="apiSender">API sender to create.</param>
        public ApiSender Create(ApiSender apiSender)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/senders/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/senders/";
            }
            try
            {
                if (apiSender == null)
                    throw new ArgumentNullException("apiSender");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiSender);
                return new ApiSender(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Updates an API sender.
        /// </summary>
        /// <param name="apiSender">API sender to update.</param>
        public ApiSender Update(ApiSender apiSender)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/senders/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/senders/";
            }
            try
            {
                if (apiSender == null)
                    throw new ArgumentNullException("apiSender");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiSender);
                return new ApiSender(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "PUT", uri + apiSender.Id,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Deletes an API sender by ID.
        /// </summary>
        /// <param name="senderId">ID of the API sender to delete.</param>
        public void DeleteSender(long senderId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/senders/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/senders/";
            }
            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "DELETE", uri + senderId, null);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Retrieves all API message templates.
        /// </summary>
        public ApiList<ApiTemplate> GetTemplates()
        {
            return GetTemplates(-1, -1);
        }

        /// <summary>
        ///     Retrieves API message templates by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiTemplate> GetTemplates(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/templates/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/templates/";
            }
            return ApiHelper.GetApiList<ApiTemplate>
                (_apiHostHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Retrieves an API message template by ID.
        /// </summary>
        /// <param name="templateId">ID of the API message template to query.</param>
        public ApiTemplate GetTemplate(long templateId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/templates/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/templates/";
            }
            try
            {
                return new ApiTemplate(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri + templateId, null));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Creates a new API message template.
        /// </summary>
        /// <param name="apiTemplate">API message template to create.</param>
        public ApiTemplate Create(ApiTemplate apiTemplate)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/templates/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/templates/";
            }
            try
            {
                if (apiTemplate == null)
                    throw new ArgumentNullException("apiTemplate");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiTemplate);
                return new ApiTemplate(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Updates an API message template.
        /// </summary>
        /// <param name="apiTemplate">API message template to update.</param>
        public ApiTemplate Update(ApiTemplate apiTemplate)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/templates/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/templates/";
            }
            try
            {
                if (apiTemplate == null)
                    throw new ArgumentNullException("apiTemplate");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiTemplate);
                return new ApiTemplate(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "PUT", uri + apiTemplate.Id,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Deletes an API message template by ID.
        /// </summary>
        /// <param name="templateId">ID of API message template to delete.</param>
        public void DeleteTemplate(long templateId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/templates/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/templates/";
            }
            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "DELETE", uri + templateId, null);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}