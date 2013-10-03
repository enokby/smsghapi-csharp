// $Id: ApiPremiumResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;
using Smsgh.Json.Utilities;

public class ApiPremiumResource
{
	/**
	 * Data fields.
	 */
	private ApiHost apiHost;
	
	/**
	 * Primary constructor.
	 */
	public ApiPremiumResource(ApiHost apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Gets all number plans.
	 */
	public ApiList<ApiNumberPlan> GetNumberPlans()
	{
		return GetNumberPlans(-1, -1);
	}
	
	/**
	 * Gets number plans by page and pageSize.
	 */
	public ApiList<ApiNumberPlan> GetNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans", page, pageSize);
	}
	
	/**
	 * Gets all shared number plans.
	 */
	public ApiList<ApiNumberPlan> GetSharedNumberPlans()
	{
		return GetSharedNumberPlans(-1, -1);
	}
	
	/**
	 * Gets shared number plans by page and pageSize.
	 */
	public ApiList<ApiNumberPlan> GetSharedNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans/shared", page, pageSize);
	}
	
	/**
	 * Gets all not-shared number plans.
	 */
	public ApiList<ApiNumberPlan> GetNotSharedNumberPlans()
	{
		return GetNotSharedNumberPlans(-1, -1);
	}
	
	/**
	 * Gets not-shared number plans by page and pageSize.
	 */
	public ApiList<ApiNumberPlan> GetNotSharedNumberPlans(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiNumberPlan>
			(this.apiHost, "/v3/numberplans/notshared", page, pageSize);
	}
	
	/**
	 * Gets all number plan keywords by number plan ID.
	 */
	public ApiList<ApiMoKeyword> GetNumberPlanKeywords(long numberPlanId)
	{
		return GetNumberPlanKeywords(numberPlanId, -1, -1);
	}
	
	/**
	 * Gets number plan keywords by number plan ID, page and pageSize.
	 */
	public ApiList<ApiMoKeyword> GetNumberPlanKeywords
		(long numberPlanId, int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiMoKeyword>
			(this.apiHost, "/v3/numberplans/"
				+ numberPlanId + "/keywords", page, pageSize);
	}
	
	/**
	 * Gets all campaigns.
	 */
	public ApiList<ApiCampaign> GetCampaigns()
	{
		return GetCampaigns(-1, -1);
	}
	
	/**
	 * Gets campaigns by page and pageSize.
	 */
	public ApiList<ApiCampaign> GetCampaigns(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiCampaign>
			(this.apiHost, "/v3/campaigns", page, pageSize);
	}
	
	/**
	 * Gets campaign by ID.
	 */
	public ApiCampaign GetCampaign(int campaignId)
	{
		try {
			return new ApiCampaign(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/campaigns/" + campaignId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Creates new campaign.
	 */
	public ApiCampaign CreateCampaign(ApiCampaign apiCampaign)
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
	
	/**
	 * Updates campaign.
	 */
	public ApiCampaign UpdateCampaign(ApiCampaign apiCampaign)
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
	
	/**
	 * Deletes campaign.
	 */
	public void DeleteCampaign(int campaignId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/campaigns/" + campaignId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets keywords.
	 */
	public ApiList<ApiMoKeyword> GetKeywords()
	{
		return GetKeywords(-1, -1);
	}
	
	/**
	 * Gets keywords by page and pageSize.
	 */
	public ApiList<ApiMoKeyword> GetKeywords(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiMoKeyword>
			(this.apiHost, "/v3/keywords", page, pageSize);
	}
	
	/**
	 * Creates keyword.
	 */
	public ApiMoKeyword CreateKeyword(ApiMoKeyword apiMoKeyword)
	{
		try {
			if (apiMoKeyword == null)
				throw new ArgumentNullException("apiMoKeyword");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiMoKeyword);
			return new ApiMoKeyword(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/keywords",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Updates keyword.
	 */
	public ApiMoKeyword UpdateKeyword(ApiMoKeyword apiMoKeyword)
	{
		try {
			if (apiMoKeyword == null)
				throw new ArgumentNullException("apiMoKeyword");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiMoKeyword);
			return new ApiMoKeyword(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/keywords/" + apiMoKeyword.Id,
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Deletes keyword.
	 */
	public void DeleteKeyword(int keywordId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/keywords/" + keywordId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Adds keyword to campaign.
	 */
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
	
	/**
	 * Removes keyword from campaign.
	 */
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
	
	/**
	 * Gets all campaign actions.
	 */
	public ApiList<ApiAction> GetActions(long campaignId)
	{
		return GetActions(campaignId, -1, -1);
	}
	
	/**
	 * Get campaign actions by page and pageSize.
	 */
	public ApiList<ApiAction> GetActions(long campaignId, int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiAction>
			(this.apiHost, "/v3/campaigns/" + campaignId + "/actions", page, pageSize);
	}
	
	/**
	 * Adds default reply action to campaign.
	 */
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
	
	/**
	 * Adds dynamic URL action to campaign by url.
	 */
	public ApiCampaign AddDynamicUrlAction(long campaignId, string url)
	{
		return AddDynamicUrlAction(campaignId, url, "no");
	}
	
	/**
	 * Adds dynamic URL action to campaign by url and sendResponse.
	 */
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
	
	/**
	 * Adds email address action to campaign.
	 */
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
	
	/**
	 * Adds forward to mobile action to campaign.
	 */
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
	
	/**
	 * Adds forward to SMPP action to campaign.
	 */
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
}
}
