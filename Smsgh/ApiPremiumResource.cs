// $Id: ApiPremiumResource.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
    ///     Represents an API premium resource.
    /// </summary>
    public class ApiPremiumResource
    {
        private readonly SmsghApiHost _apiHost;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiPremiumResource" /> class.
        /// </summary>
        public ApiPremiumResource(SmsghApiHost apiHost)
        {
            _apiHost = apiHost;
        }

        /// <summary>
        ///     Retrieves all API number plans.
        /// </summary>
        public ApiList<ApiNumberPlan> GetNumberPlans()
        {
            return GetNumberPlans(-1, -1, -1);
        }

        /// <summary>
        /// Get a Number pLan by id
        /// </summary>
        /// <param name="numberPlanId">NUmber Plan Id</param>
        /// <returns>Intance of ApiNumberPlan</returns>
        public ApiNumberPlan GetNumberPlan(long numberPlanId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/numberplans/" + numberPlanId;
            else
            {
                uri = "/" + _apiHost.ContextPath + "/numberplans/" + numberPlanId;
            }    
        
            return new ApiNumberPlan(ApiHelper.GetJson<ApiDictionary>(this._apiHost, "GET", uri, null));
        }

        /// <summary>
        ///     Retrieves API number plans by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        /// <param name="type">Number Plan Type</param>
        public ApiList<ApiNumberPlan> GetNumberPlans(int page, int pageSize, int type)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/numberplans/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/numberplans/";
            }

            if (type >= 0)
            {
                uri += "?Type=" + type;
                return ApiHelper.GetApiList<ApiNumberPlan>
                    (_apiHost, uri, page, pageSize, true);
            }

            return ApiHelper.GetApiList<ApiNumberPlan>
                (_apiHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Retrieves all shared API number plans.
        /// </summary>
        /// <summary>
        ///     Retrieves shared API number plans by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        /// <summary>
        ///     Retrieves all not-shared API number plans.
        /// </summary>
        /// <summary>
        ///     Retrieves not-shared API number plans by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        /// <summary>
        ///     Retrieves all API keywords for a number plan.
        /// </summary>
        /// <param name="numberPlanId">ID of the API number plan to query.</param>
        public ApiList<ApiMoKeyWord> GetNumberPlanKeywords(long numberPlanId)
        {
            return GetNumberPlanKeywords(numberPlanId, -1, -1);
        }

        /// <summary>
        ///     Retrieves API keywords for a number plan by page and page size.
        /// </summary>
        /// <param name="numberPlanId">ID of the API number plan to query.</param>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiMoKeyWord> GetNumberPlanKeywords
            (long numberPlanId, int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/numberplans/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/numberplans/";
            }
            return ApiHelper.GetApiList<ApiMoKeyWord>
                (_apiHost, uri
                               + numberPlanId + "/keywords", page, pageSize);
        }

        /// <summary>
        ///     Retrieves all API campaigns.
        /// </summary>
        public ApiList<ApiCampaign> GetCampaigns()
        {
            return GetCampaigns(-1, -1);
        }

        /// <summary>
        ///     Retrieves API campaigns by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiCampaign> GetCampaigns(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            return ApiHelper.GetApiList<ApiCampaign>
                (_apiHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Retrieves an API campaign by ID.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to query.</param>
        public ApiCampaign GetCampaign(int campaignId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "GET", uri + campaignId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        /// Get keyword by Id
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        public ApiMoKeyWord GetKeyword(int keywordId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/keywords/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/keywords/";
            }

            try
            {
                return new ApiMoKeyWord(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "GET", uri + keywordId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }


        /// <summary>
        ///     Creates a new API campaign.
        /// </summary>
        /// <param name="apiCampaign">The API campaign to create.</param>
        public ApiCampaign Create(ApiCampaign apiCampaign)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                if (apiCampaign == null)
                    throw new ArgumentNullException("apiCampaign");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiCampaign);
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                //throw new Exception("Error", ex);
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates an API campaign.
        /// </summary>
        /// <param name="apiCampaign">The API campaign to update.</param>
        public ApiCampaign Update(ApiCampaign apiCampaign)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                if (apiCampaign == null)
                    throw new ArgumentNullException("apiCampaign");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiCampaign);
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "PUT", uri + apiCampaign.CampaignId,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Deletes an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to delete.</param>
        public void DeleteCampaign(int campaignId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "DELETE", uri + campaignId, null);
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
        }

        /// <summary>
        ///     Retrieves all API MO keywords.
        /// </summary>
        public ApiList<ApiMoKeyWord> GetKeywords()
        {
            return GetKeywords(-1, -1);
        }

        /// <summary>
        ///     Retrieves API MO keywords by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiMoKeyWord> GetKeywords(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/keywords/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/keywords/";
            }

            return ApiHelper.GetApiList<ApiMoKeyWord>
                (_apiHost, uri, page, pageSize);
        }

        /// <summary>
        ///     Creates a new API MO keyword.
        /// </summary>
        /// <param name="apiMoKeyword">API MO keyword to create.</param>
        public ApiMoKeyWord Create(ApiMoKeyWord apiMoKeyword)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/keywords/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/keywords/";
            }

            try
            {
                if (apiMoKeyword == null)
                    throw new ArgumentNullException("apiMoKeyword");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiMoKeyword);
                return new ApiMoKeyWord(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Updates an API MO keyword.
        /// </summary>
        /// <param name="apiMoKeyword">API MO keyword to update.</param>
        public ApiMoKeyWord Update(ApiMoKeyWord apiMoKeyword)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/keywords/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/keywords/";
            }
            try
            {
                if (apiMoKeyword == null)
                    throw new ArgumentNullException("apiMoKeyword");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiMoKeyword);
                return new ApiMoKeyWord(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "PUT", uri + apiMoKeyword.Id,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Deletes an API MO keyword.
        /// </summary>
        /// <param name="keywordId">ID of the API MO keyword to delete</param>
        public void DeleteKeyword(int keywordId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/keywords/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/keywords/";
            }

            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "DELETE", uri + keywordId, null);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
                //throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        ///     Adds an API MO keyword to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to add keyword to.</param>
        /// <param name="keywordId">ID of the API MO keyword to add to campaign.</param>
        public ApiCampaign AddKeywordToCampaign(int campaignId, int keywordId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "PUT", uri
                                          + campaignId + "/keywords/" + keywordId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Removes an API MO keyword from an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to remove keyword from.</param>
        /// <param name="keywordId">ID of the API MO keyword to remove from campaign.</param>
        public void RemoveKeywordFromCampaign(int campaignId, int keywordId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }
            try
            {
                ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "DELETE", uri
                                             + campaignId + "/keywords/" + keywordId, null);
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }            
        }

        /// <summary>
        ///     Retrieves all API actions on an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to query its actions.</param>
        public ApiList<ApiAction> GetActions(long campaignId)
        {
            return GetActions(campaignId, -1, -1);
        }

        /// <summary>
        ///     Retrieves API actions on an API campaign by page and page size.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign to query its actions</param>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiAction> GetActions(long campaignId, int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }
            return ApiHelper.GetApiList<ApiAction>
                (_apiHost, uri + campaignId + "/actions", page, pageSize);
        }

        /// <summary>
        /// Get Campaign Keywords
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ApiList<ApiMoKeyWord> GetCampaignKeywords(long campaignId, int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }
            return ApiHelper.GetApiList<ApiMoKeyWord>
                (_apiHost, uri + campaignId + "/keywords", page, pageSize);
            
        }

        public ApiList<ApiMoKeyWord> GetCampaignKeywords(long campaignId)
        {
            return GetCampaignKeywords(campaignId, -1, -1);
        } 

        /// <summary>
        ///     Adds a default reply action to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="message">Message.</param>
        public ApiCampaign AddDefaultReplyAction(long campaignId, string message)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                if(message == null)
                    throw new ArgumentNullException("message"); 

                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri + campaignId + "/actions/default_reply",
                        Encoding.UTF8.GetBytes(String.Format("{{\"message\":{0}}}",
                            message))));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Adds a dynamic URL action to an API campaign with default send response.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="url">URL to add.</param>
        public ApiCampaign AddDynamicUrlAction(long campaignId, string url)
        {
            return AddDynamicUrlAction(campaignId, url, "no");
        }

        /// <summary>
        ///     Adds a dynamic URL action to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="url">URL to add.</param>
        /// <param name="sendResponse">A <c>yes</c> or <c>no</c> send response.</param>
        public ApiCampaign AddDynamicUrlAction(long campaignId, string url, string sendResponse)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri + campaignId + "/actions/dynamic_url",
                        Encoding.UTF8.GetBytes(String.Format
                            ("{{\"url\":{0},\"send_response\":{1}}}",
                                url,
                                sendResponse))));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Adds an email address action to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="address">Email address to add.</param>
        public ApiCampaign AddEmailAddressAction(long campaignId, string address)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }
            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri + campaignId + "/actions/email",
                        Encoding.UTF8.GetBytes(String.Format("{{\"address\":{0}}}",
                            address))));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Adds a forward-to-mobile action to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="number">Phone number to add.</param>
        public ApiCampaign AddForwardToMobileAction(long campaignId, string number)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri + campaignId + "/actions/phone",
                        Encoding.UTF8.GetBytes(String.Format("{{\"number\":{0}}}",
                            number))));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Adds a forward-to-SMPP action to an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="appId">Application ID to add.</param>
        public ApiCampaign AddForwardToSmppAction(long campaignId, string appId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }
            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri + campaignId + "/actions/smpp",
                        Encoding.UTF8.GetBytes(String.Format("{{\"api_id\":{0}}}",
                            appId))));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }

        /// <summary>
        ///     Removes an action from an API campaign.
        /// </summary>
        /// <param name="campaignId">ID of the API campaign.</param>
        /// <param name="actionId">ID of the action to remove.</param>
        public ApiCampaign RemoveActionFromCampaign(long campaignId, long actionId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/campaigns/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/campaigns/";
            }

            try
            {
                return new ApiCampaign(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "DELETE", uri + campaignId
                                             + "/actions/" + actionId, null));
            }
            catch (Exception ex)
            {
                ApiHelper.CatchException(ex);
            }
            return null;
        }
    }
}