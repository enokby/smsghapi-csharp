// $Id: ApiMessagesResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Web;
using System.Text;
using Smsgh.Json;

public class ApiMessagesResource
{
	private SmsghApi apiHost;
	
	/**
	 * Primary constructor.
	 */
	public ApiMessagesResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Sends a quick message.
	 */
	public ApiMessageResponse Send(string from, string to, string content)
	{
		ApiMessage apiMessage = new ApiMessage();
		apiMessage.From = from;
		apiMessage.To = to;
		apiMessage.Content = content;
		return Send(apiMessage);
	}
	
	/**
	 * Sends a message.
	 */
	public ApiMessageResponse Send(ApiMessage apiMessage)
	{
		try {
			if (apiMessage == null)
				throw new ArgumentNullException("apiMessage");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiMessage);
			return new ApiMessageResponse(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/messages",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Schedules a message.
	 */
	public ApiMessageResponse Schedule(ApiMessage apiMessage, DateTime time)
	{
		if (apiMessage != null)
			apiMessage.Time = time;
		return Send(apiMessage);
	}
	
	/**
	 * Reschedules a message by ID and time.
	 */
	public ApiMessageResponse Reschedule(Guid messageId, DateTime time)
	{
		try {
			return new ApiMessageResponse(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/messages/"
					+ messageId.ToString().Replace("-", ""),
						Encoding.UTF8.GetBytes(String.Format
							("{{\"Time\":\"{0}\"}}",
								time.ToString("yyyy-MM-dd HH:mm:ss")))));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Cancels scheduled message by ID.
	 */
	public ApiMessageResponse Cancel(Guid messageId)
	{
		try {
			return new ApiMessageResponse(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/messages/"
					+ messageId.ToString().Replace("-", ""), null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets a message.
	 */
	public ApiMessage Get(Guid messageId)
	{
		try {
			return new ApiMessage(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/messages/"
					+ messageId.ToString().Replace("-", ""), null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets messages by several params.
	 */
	public ApiList<ApiMessage> Get(DateTime? start, DateTime? end,
		int index, int limit, bool pending, string direction) {
		bool hasQ = false;
		StringBuilder sb = new StringBuilder();
		sb.Append("/v3/messages");
		
		if (start != null) {
			sb.Append(hasQ ? "&" : "?")
				.Append("start=")
				.Append(HttpUtility.UrlEncode(start.GetValueOrDefault()
					.ToString("yyyy-MM-dd HH:mm:ss")));
			if (!hasQ) hasQ = true;
		}
		
		if (end != null) {
			sb.Append(hasQ ? "&" : "?")
				.Append("end=")
				.Append(HttpUtility.UrlEncode(end.GetValueOrDefault()
					.ToString("yyyy-MM-dd HH:mm:ss")));
			if (!hasQ) hasQ = true;
		}
		
		if (index > 0) {
			sb.Append(hasQ ? "&" : "?")
				.Append("index=")
				.Append(index);
			if (!hasQ) hasQ = true;
		}
		
		if (limit > 0) {
			sb.Append(hasQ ? "&" : "?")
				.Append("limit=")
				.Append(limit);
			if (!hasQ) hasQ = true;
		}
		
		if (pending) {
			sb.Append(hasQ ? "&" : "?")
				.Append("pending=")
				.Append(pending);
			if (!hasQ) hasQ = true;
		}
		
		if (direction != null) {
			sb.Append(hasQ ? "&" : "?")
				.Append("direction=")
				.Append(HttpUtility.UrlEncode(direction));
		}
		
		return ApiHelper.GetApiList<ApiMessage>
			(this.apiHost, sb.ToString(), -1, -1);
	}
}
}
