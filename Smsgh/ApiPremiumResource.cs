// $Id: ApiPremiumResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;
using Smsgh.Json.Utilities;

/// <summary>
/// Represents an API premium resource.
/// </summary>
public class ApiPremiumResource
{
	private SmsghApi apiHost;
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiPremiumResource"/> class.
    /// </summary>
	public ApiPremiumResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
    /// <summary>
    /// Retrieves all API number plans.
    /// </summary>
	public ApiList<ApiNumberPlan> GetNumberPlans()
	{
		return GetNumberPlans(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API number plans by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiNumberPlan> GetNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves all shared API number plans.
    /// </summary>
	public ApiList<ApiNumberPlan> GetSharedNumberPlans()
	{
		return GetSharedNumberPlans(-1, -1);
	}
	
    /// <summary>
    /// Retrieves shared API number plans by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiNumberPlan> GetSharedNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans/shared", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves all not-shared API number plans.
    /// </summary>
	public ApiList<ApiNumberPlan> GetNotSharedNumberPlans()
	{
		return GetNotSharedNumberPlans(-1, -1);
	}
	
    /// <summary>
    /// Retrieves not-shared API number plans by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiNumberPlan> GetNotSharedNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans/notshared", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves all API keywords for a number plan.
    /// </summary>
	/// <param name="numberPlanId">ID of the API number plan to query.</param>
	public ApiList<ApiMoKeyWord> GetNumberPlanKeywords(long numberPlanId)
	{
		return GetNumberPlanKeywords(numberPlanId, -1, -1);
	}
	
    /// <summary>
    /// Retrieves API keywords for a number plan by page and page size.
    /// </summary>
	/// <param name="numberPlanId">ID of the API number plan to query.</param>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiMoKeyWord> GetNumberPlanKeywords
		(long numberPlanId, int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiMoKeyWord>
			(this.apiHost, "/v3/numberplans/"
				+ numberPlanId + "/keywords", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves all API campaigns.
    /// </summary>
	public ApiList<ApiCampaign> GetCampaigns()
	{
		return GetCampaigns(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API campaigns by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiCampaign> GetCampaigns(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiCampaign>
			(this.apiHost, "/v3/campaigns", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves an API campaign by ID.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to query.</param>
	public ApiCampaign GetCampaign(int campaignId)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/campaigns/" + campaignId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Creates a new API campaign.
    /// </summary>
	/// <param name="apiCampaign">The API campaign to create.</param>
	public ApiCampaign Create(ApiCampaign apiCampaign)
	{
		try {
			if (apiCampaign == null)
				throw new ArgumentNullException("apiCampaign");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiCampaign);
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API campaign.
    /// </summary>
	/// <param name="apiCampaign">The API campaign to update.</param>
	public ApiCampaign Update(ApiCampaign apiCampaign)
	{
		try {
			if (apiCampaign == null)
				throw new ArgumentNullException("apiCampaign");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiCampaign);
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/campaigns/" + apiCampaign.CampaignId,
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to delete.</param>
	public void DeleteCampaign(int campaignId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/campaigns/" + campaignId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all API MO keywords.
    /// </summary>
	public ApiList<ApiMoKeyWord> GetKeywords()
	{
		return GetKeywords(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API MO keywords by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiMoKeyWord> GetKeywords(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiMoKeyWord>
			(this.apiHost, "/v3/keywords", page, pageSize);
	}
	
    /// <summary>
    /// Creates a new API MO keyword.
    /// </summary>
	/// <param name="apiMoKeyword">API MO keyword to create.</param>
	public ApiMoKeyWord Create(ApiMoKeyWord apiMoKeyword)
	{
		try {
			if (apiMoKeyword == null)
				throw new ArgumentNullException("apiMoKeyword");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiMoKeyword);
			return new ApiMoKeyWord(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/keywords",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API MO keyword.
    /// </summary>
	/// <param name="apiMoKeyword">API MO keyword to update.</param>
	public ApiMoKeyWord Update(ApiMoKeyWord apiMoKeyword)
	{
		try {
			if (apiMoKeyword == null)
				throw new ArgumentNullException("apiMoKeyword");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiMoKeyword);
			return new ApiMoKeyWord(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/keywords/" + apiMoKeyword.Id,
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API MO keyword.
    /// </summary>
	/// <param name="keywordId">ID of the API MO keyword to delete</param>
	public void DeleteKeyword(int keywordId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/keywords/" + keywordId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Adds an API MO keyword to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to add keyword to.</param>
	/// <param name="keywordId">ID of the API MO keyword to add to campaign.</param>
	public ApiCampaign AddKeywordToCampaign(int campaignId, int keywordId)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/campaigns/"
					+ campaignId + "/keywords/" + keywordId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Removes an API MO keyword from an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to remove keyword from.</param>
	/// <param name="keywordId">ID of the API MO keyword to remove from campaign.</param>
	public void RemoveKeywordFromCampaign(int campaignId, int keywordId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/campaigns/"
					+ campaignId + "/keywords/" + keywordId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all API actions on an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to query its actions.</param>
	public ApiList<ApiAction> GetActions(long campaignId)
	{
		return GetActions(campaignId, -1, -1);
	}
	
    /// <summary>
    /// Retrieves API actions on an API campaign by page and page size.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign to query its actions</param>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiAction> GetActions(long campaignId, int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiAction>
			(this.apiHost, "/v3/campaigns/" + campaignId + "/actions", page, pageSize);
	}
	
    /// <summary>
    /// Adds a default reply action to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="message">Message.</param>
	public ApiCampaign AddDefaultReplyAction(long campaignId, string message)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns/" + campaignId + "/actions/default_reply",
					Encoding.UTF8.GetBytes(String.Format("{{\"message\":{0}}}",
						JavaScriptUtils.ToEscapedJavaScriptString(message)))));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Adds a dynamic URL action to an API campaign with default send response.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="url">URL to add.</param>
	public ApiCampaign AddDynamicUrlAction(long campaignId, string url)
	{
		return AddDynamicUrlAction(campaignId, url, "no");
	}
	
    /// <summary>
    /// Adds a dynamic URL action to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="url">URL to add.</param>
	/// <param name="sendResponse">A <c>yes</c> or <c>no</c> send response.</param>
	public ApiCampaign AddDynamicUrlAction(long campaignId, string url, string sendResponse)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns/" + campaignId + "/actions/dynamic_url",
					Encoding.UTF8.GetBytes(String.Format
						("{{\"url\":{0},\"send_response\":{1}}}",
							JavaScriptUtils.ToEscapedJavaScriptString(url),
								JavaScriptUtils.ToEscapedJavaScriptString(sendResponse)))));
		} catch (Exception ex) {
			Console.WriteLine(ex.ToString());
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Adds an email address action to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="address">Email address to add.</param>
	public ApiCampaign AddEmailAddressAction(long campaignId, string address)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns/" + campaignId + "/actions/email",
					Encoding.UTF8.GetBytes(String.Format("{{\"address\":{0}}}",
						JavaScriptUtils.ToEscapedJavaScriptString(address)))));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Adds a forward-to-mobile action to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="number">Phone number to add.</param>
	public ApiCampaign AddForwardToMobileAction(long campaignId, string number)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns/" + campaignId + "/actions/phone",
					Encoding.UTF8.GetBytes(String.Format("{{\"number\":{0}}}",
						JavaScriptUtils.ToEscapedJavaScriptString(number)))));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Adds a forward-to-SMPP action to an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="appId">Application ID to add.</param>
	public ApiCampaign AddForwardToSmppAction(long campaignId, string appId)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/campaigns/" + campaignId + "/actions/smpp",
					Encoding.UTF8.GetBytes(String.Format("{{\"app_id\":{0}}}",
						JavaScriptUtils.ToEscapedJavaScriptString(appId)))));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Removes an action from an API campaign.
    /// </summary>
	/// <param name="campaignId">ID of the API campaign.</param>
	/// <param name="actionId">ID of the action to remove.</param>
	public ApiCampaign RemoveActionFromCampaign(long campaignId, long actionId)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/campaigns/" + campaignId
					+ "/actions/" + actionId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
}
}
