// $Id: ApiBulkMessagingResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;

/// <summary>
/// Represents an API bulk messaging resource.
/// </summary>
public class ApiBulkMessagingResource
{
	private SmsghApi apiHost;
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBulkMessagingResource"/> class.
    /// </summary>
	public ApiBulkMessagingResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
    /// <summary>
    /// Retrieves all API senders.
    /// </summary>
	public ApiList<ApiSender> GetSenders()
	{
		return GetSenders(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API senders by page and pageSize.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in page.</param>
	public ApiList<ApiSender> GetSenders(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiSender>
			(this.apiHost, "/v3/senders", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves an API sender by ID.
    /// </summary>
	/// <param name="senderId">ID of the sender to retrieve.</param>
	public ApiSender GetSender(long senderId)
	{
		return new ApiSender(ApiHelper.GetJson<JavaScriptObject>
			(this.apiHost, "GET", "/v3/senders/" + senderId, null));
	}
	
    /// <summary>
    /// Creates a new API sender.
    /// </summary>
	/// <param name="apiSender">API sender to create.</param>
	public ApiSender Create(ApiSender apiSender)
	{
		try {
			if (apiSender == null)
				throw new ArgumentNullException("apiSender");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiSender);
			return new ApiSender(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/senders",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API sender.
    /// </summary>
	/// <param name="apiSender">API sender to update.</param>
	public ApiSender Update(ApiSender apiSender)
	{
		try {
			if (apiSender == null)
				throw new ArgumentNullException("apiSender");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiSender);
			return new ApiSender(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/senders/" + apiSender.Id,
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API sender by ID.
    /// </summary>
	/// <param name="senderId">ID of the API sender to delete.</param>
	public void DeleteSender(long senderId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/senders/" + senderId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all API message templates.
    /// </summary>
	public ApiList<ApiTemplate> GetTemplates()
	{
		return GetTemplates(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API message templates by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiTemplate> GetTemplates(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiTemplate>
			(this.apiHost, "/v3/templates", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves an API message template by ID.
    /// </summary>
	/// <param name="templateId">ID of the API message template to query.</param>
	public ApiTemplate GetTemplate(long templateId)
	{
		try {
			return new ApiTemplate(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/templates/" + templateId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Creates a new API message template.
    /// </summary>
	/// <param name="apiTemplate">API message template to create.</param>
	public ApiTemplate Create(ApiTemplate apiTemplate)
	{
		try {
			if (apiTemplate == null)
				throw new ArgumentNullException("apiTemplate");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiTemplate);
			return new ApiTemplate(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/templates",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API message template.
    /// </summary>
	/// <param name="apiTemplate">API message template to update.</param>
	public ApiTemplate Update(ApiTemplate apiTemplate)
	{
		try {
			if (apiTemplate == null)
				throw new ArgumentNullException("apiTemplate");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiTemplate);
			return new ApiTemplate(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/templates/" + apiTemplate.Id,
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API message template by ID.
    /// </summary>
	/// <param name="templateId">ID of API message template to delete.</param>
	public void DeleteTemplate(long templateId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/templates/" + templateId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
}
}
