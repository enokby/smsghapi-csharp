// $Id: ApiMessagesResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Web;
using System.Text;
using Smsgh.Json;

/// <summary>
/// Represents an API messages resource.
/// </summary>
public class ApiMessagesResource
{
	private SmsghApi apiHost;
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiMessagesResource"/> class.
    /// </summary>
	public ApiMessagesResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
    /// <summary>
    /// Sends a quick SMS message.
    /// </summary>
	/// <param name="from">ID of the sender of the message.</param>
	/// <param name="to">Recipient phone number of the message.</param>
	/// <param name="content">Body content of the message.</param>
	public ApiMessageResponse Send(string from, string to, string content)
	{
		ApiMessage apiMessage = new ApiMessage();
		apiMessage.From = from;
		apiMessage.To = to;
		apiMessage.Content = content;
		return Send(apiMessage);
	}
	
    /// <summary>
    /// Sends a new message.
    /// </summary>
	/// <param name="apiMessage">API message to send.</param>
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
	
    /// <summary>
    /// Schedules a message.
    /// </summary>
	/// <param name="apiMessage">API message to schedule.</param>
	/// <param name="time">Date and time to send the message.</param>
	public ApiMessageResponse Schedule(ApiMessage apiMessage, DateTime time)
	{
		if (apiMessage != null)
			apiMessage.Time = time;
		return Send(apiMessage);
	}
	
    /// <summary>
    /// Reschedules and already scheduled message.
    /// </summary>
	/// <param name="messageId">ID of the scheduled message.</param>
	/// <param name="time">New date and time to send the message.</param>
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
	
    /// <summary>
    /// Cancels an already scheduled API message.
    /// </summary>
	/// <param name="messageId">ID of the message to cancel.</param>
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
	
    /// <summary>
    /// Retrieves an API message by ID.
    /// </summary>
	/// <param name="messageId">ID of the API message.</param>
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
	
    /// <summary>
    /// Retrieves several API messages.
    /// </summary>
	/// <param name="start">The date to start querying from.</param>
	/// <param name="end">The last possible time in the query.</param>
	/// <param name="index">The number of results to skip from the result set.</param>
	/// <param name="limit">The maximum number of results to return</param>
	/// <param name="pending">Indicates if only scheduled messages should be returned</param>
	/// <param name="direction">An <c>in</c> or <c>out</c> value used to filter.</param>
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
