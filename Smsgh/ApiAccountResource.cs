// $Id: ApiAccountResource.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
    ///     Represents an API account resource.
    /// </summary>
    public class ApiAccountResource
    {
        // Data fields.
        private readonly SmsghApiHost _apiHostHost;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiAccountResource" /> class.
        /// </summary>
        public ApiAccountResource(SmsghApiHost apiHostHost)
        {
            _apiHostHost = apiHostHost;
        }

        /// <summary>
        ///     Retrieves account profile.
        /// </summary>
        public ApiAccountProfile GetProfile()
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/profile/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/profile/";
            }

            try
            {
                return new ApiAccountProfile(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Retrieves primary contact.
        /// </summary>
        public ApiAccountContact GetPrimaryContact()
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/primary_contact/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/primary_contact/";
            }

            try
            {
                return new ApiAccountContact(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Retrieves billing contact.
        /// </summary>
        public ApiAccountContact GetBillingContact()
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/billing_contact/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/billing_contact/";
            }
            try
            {
                return new ApiAccountContact(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Retrieves technical contact.
        /// </summary>
        public ApiAccountContact GetTechnicalContact()
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/technical_contact/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/technical_contact/";
            }

            try
            {
                return new ApiAccountContact(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Retrieves all account contacts.
        /// </summary>
        public List<ApiAccountContact> GetContacts()
        {
            var aacs = new List<ApiAccountContact>();

            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/contacts/";
            }

            try
            {
                aacs.AddRange(ApiHelper.GetJson<List<ApiDictionary>>(_apiHostHost, "GET", uri, null).Select(jso => new ApiAccountContact(jso)));
                return aacs;
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates an <see cref="ApiAccountContact" />.
        /// </summary>
        /// <param name="apiAccountContact">API account contact to update</param>
        public void Update(ApiAccountContact apiAccountContact)
        {

            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/contacts/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/contacts/";
            }

            try
            {
                if (apiAccountContact == null)
                    throw new ArgumentNullException("apiAccountContact");
                var stringWriter = new StringWriter();
                new JsonSerializer().Serialize(stringWriter, apiAccountContact);

                ApiHelper.GetJson<ApiDictionary>(_apiHostHost, "PUT",
                    uri + apiAccountContact.AccountContactId,
                    Encoding.UTF8.GetBytes(stringWriter.ToString()));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }

        /// <summary>
        ///     Retrieves all account services.
        /// </summary>
        public ApiList<ApiService> GetServices()
        {
            return GetServices(-1, -1);
        }

        /// <summary>
        ///     Retrieves account services by page and page size.
        /// </summary>
        /// <param name="page">One-based index of page</param>
        /// <param name="pageSize">Maxium number of entries in a page</param>
        public ApiList<ApiService> GetServices(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/services/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/services/";
            }

            var services = ApiHelper.GetApiList<ApiService>
                (_apiHostHost, uri , page, pageSize, false);
            return services;
        }

        /// <summary>
        ///     Retrieves account settings.
        /// </summary>
        public ApiSettings GetSettings()
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/settings/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/settings/";
            }

            try
            {
                return new ApiSettings(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates account settings.
        /// </summary>
        /// <param name="apiSettings">API account settings to update.</param>
        public ApiSettings Update(ApiSettings apiSettings)
        {

            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/settings/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/settings/";
            }

            try
            {
                if (apiSettings == null)
                    throw new ArgumentNullException();
                var stringWriter = new StringWriter();
                new JsonSerializer().Serialize(stringWriter, apiSettings);
                return new ApiSettings(ApiHelper.GetJson<ApiDictionary>
                    (_apiHostHost, "PUT", uri,
                        Encoding.UTF8.GetBytes(stringWriter.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Retrieves all child accounts.
        /// </summary>
        //public ApiList<ApiChildAccount> GetChildAccounts()
        //{
        //    return GetChildAccounts(-1, -1);
        //}

        ///// <summary>
        /////     Retrieves child accounts by page and page size.
        ///// </summary>
        ///// <param name="page">One-based index of page</param>
        ///// <param name="pageSize">Maximum number of entries in a page</param>
        //public ApiList<ApiChildAccount> GetChildAccounts(int page, int pageSize)
        //{
        //    string uri;
        //    if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
        //        uri = "/account/childaccounts/";
        //    else
        //    {
        //        uri = "/" + _apiHostHost.ContextPath + "/account/childaccounts/";
        //    }

        //    return ApiHelper.GetApiList<ApiChildAccount>
        //        (_apiHostHost, uri, page, pageSize);
        //}

        /// <summary>
        ///     Retrieves all account invoices.
        /// </summary>
        public ApiList<ApiInvoice> GetInvoices()
        {
            return GetInvoices(-1, -1);
        }

        /// <summary>
        ///     Retrieves account invoices by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiInvoice> GetInvoices(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHostHost.ContextPath))
                uri = "/account/invoices/";
            else
            {
                uri = "/" + _apiHostHost.ContextPath + "/account/invoices/";
            }

            return ApiHelper.GetApiList<ApiInvoice>
                (_apiHostHost, uri, page, pageSize);
        }
    }
}