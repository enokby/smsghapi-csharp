// $Id: ApiBulkMessagingResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;

public class ApiBulkMessagingResource
{
	/**
	 * Data fields.
	 */
	private ApiHost apiHost;
	
	/**
	 * Primary constructor.
	 */
	public ApiBulkMessagingResource(ApiHost apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Gets all senders.
	 */
	public ApiList<ApiSender> GetSenders()
	{
		return GetSenders(-1, -1);
	}
	
	/**
	 * Gets senders by page and pageSize.
	 */
	public ApiList<ApiSender> GetSenders(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiSender>
			(this.apiHost, "/v3/senders", page, pageSize);
	}
	
	/**
	 * Gets sender by ID.
	 */
	public ApiSender GetSender(long senderId)
	{
		return new ApiSender(ApiHelper.GetJson<JavaScriptObject>
			(this.apiHost, "GET", "/v3/senders/" + senderId, null));
	}
	
	/**
	 * Creates new sender.
	 */
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
	
	/**
	 * Updates sender.
	 */
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
	
	/**
	 * Deletes sender by ID.
	 */
	public void DeleteSender(long senderId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/senders/" + senderId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets all message templates.
	 */
	public ApiList<ApiTemplate> GetTemplates()
	{
		return GetTemplates(-1, -1);
	}
	
	/**
	 * Gets message templates by page and pageSize.
	 */
	public ApiList<ApiTemplate> GetTemplates(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiTemplate>
			(this.apiHost, "/v3/templates", page, pageSize);
	}
	
	/**
	 * Gets message template by ID.
	 */
	public ApiTemplate GetTemplate(long templateId)
	{
		try {
			return new ApiTemplate(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/templates/" + templateId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Creates message template.
	 */
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
	
	/**
	 * Updates message template.
	 */
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
	
	/**
	 * Deletes message template.
	 */
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
