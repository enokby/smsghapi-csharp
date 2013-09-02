/**
 * $Id: ApiMessagesResource.cs 229 2013-08-30 16:38:25Z mkwayisi $
 */
namespace Smsgh
{

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Smsgh.Json;

public class ApiMessagesResource
{
	/**
	 * Data fields.
	 */
	private ApiHost apiHost;
	private const string URI_V3_MESSAGES = "/v3/messages";
	
	/**
	 * Primary constructor.
	 */
	internal ApiMessagesResource(ApiHost apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Creates a request.
	 */
	private HttpWebRequest CreateRequest(string uri)
	{
		HttpWebRequest request = HttpWebRequest.Create(
			String.Format("http{0}://{1}:{2}{3}",
				this.apiHost.Https ? "s" : "", this.apiHost.Hostname,
					this.apiHost.Port, uri)) as HttpWebRequest;
		request.Accept = "application/json";
		request.Timeout = this.apiHost.Timeout * 1000;
		request.Headers.Add(String.Format("Authorization: Basic {0}",
			Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}",
					this.apiHost.ClientId, this.apiHost.ClientSecret)))));
		return request;
	}
	
	/**
	 * Makes an ApiMessageResponse from WebResponse.
	 */
	private ApiMessageResponse ApiMessageResponse(WebResponse wr)
	{
		using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
		using (StringReader zr = new StringReader(sr.ReadToEnd()))
		using (JsonReader jr = new JsonReader(zr))
			return new ApiMessageResponse(
				new JsonSerializer().Deserialize(jr) as JavaScriptObject);
	}
	
	/**
	 * Sends a message.
	 */
	public ApiMessageResponse Send(ApiMessage apiMessage)
	{
		try {
			if (apiMessage == null)
				throw new ArgumentNullException();
			byte[] data = Encoding.UTF8.GetBytes(apiMessage.Serialize());
			HttpWebRequest httpWebRequest = CreateRequest(URI_V3_MESSAGES);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentLength = data.Length;
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.GetRequestStream().Write(data, 0, data.Length);
			return ApiMessageResponse(httpWebRequest.GetResponse());
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Quick send.
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
	 * Schedules a message.
	 */
	public ApiMessageResponse Schedule(ApiMessage apiMessage, DateTime time)
	{
		if (apiMessage == null)
			throw new ArgumentNullException();
		apiMessage.Time = time;
		return this.Send(apiMessage);
	}
	
	/**
	 * Reschedules a message.
	 */
	public ApiMessageResponse Reschedule(Guid messageId, DateTime time)
	{
		try {
			byte[] data = Encoding.UTF8.GetBytes(String.Format(
				"{{\"Time\":\"{0}\"}}", time.ToString("yyyy-MM-dd HH:mm:ss")));
			HttpWebRequest httpWebRequest = CreateRequest(String.Format(
				"{0}/{1}", URI_V3_MESSAGES, messageId.ToString().Replace("-", "")));
			httpWebRequest.Method = "PUT";
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.ContentLength = data.Length;
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.GetRequestStream().Write(data, 0, data.Length);
			return ApiMessageResponse(httpWebRequest.GetResponse());
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Cancels a scheduled message.
	 */
	public ApiMessageResponse Cancel(Guid messageId)
	{
		try {
			HttpWebRequest httpWebRequest = CreateRequest(String.Format(
				"{0}/{1}", URI_V3_MESSAGES, messageId.ToString().Replace("-", "")));
			httpWebRequest.Method = "DELETE";
			return ApiMessageResponse(httpWebRequest.GetResponse());
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Retrieves a message.
	 */
	public ApiMessage GetMessage(Guid messageId)
	{
		try {
			HttpWebRequest httpWebRequest = CreateRequest(String.Format(
				"{0}/{1}", URI_V3_MESSAGES, messageId.ToString().Replace("-", "")));
			using (WebResponse wr = httpWebRequest.GetResponse())
			using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
			using (StringReader zr = new StringReader(sr.ReadToEnd()))
			using (JsonReader jr = new JsonReader(zr))
				return new ApiMessage(
					new JsonSerializer().Deserialize(jr) as JavaScriptObject);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Retrieves messages.
	 */
	public List<ApiMessage> GetMessages(int index, int limit)
	{
		return GetMessages(index, limit, null, null, false, null);
	}
	
	/**
	 * Retrieves messages.
	 */
	public List<ApiMessage> GetMessages(int index, int limit,
		DateTime? start, DateTime? end, bool pending, string direction)
	{
		List<ApiMessage> apiMessages = new List<ApiMessage>();
		StringBuilder sbUri = new StringBuilder(URI_V3_MESSAGES);
		sbUri.AppendFormat("?index={0}", index > 0 ? index : 0);
		
		if (limit > 0)
			sbUri.AppendFormat("&limit={0}", limit);
			
		if (start != null) {
			sbUri.AppendFormat("&start={0}",
				start.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"));
		}
		
		if (end != null) {
			sbUri.AppendFormat("&end={0}",
				start.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"));
		}
		
		if (pending)
			sbUri.Append("&pending=true");
			
		if (direction != null)
			sbUri.AppendFormat("&direction={0}", direction);
			
		try {
			HttpWebRequest httpWebRequest = CreateRequest(sbUri.ToString());
			using (WebResponse wr = httpWebRequest.GetResponse())
			using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
			using (StringReader zr = new StringReader(sr.ReadToEnd()))
			using (JsonReader jr = new JsonReader(zr)) {
				JavaScriptObject jso = new JsonSerializer()
					.Deserialize(jr) as JavaScriptObject;
				foreach (string key in jso.Keys) {
					switch (key.ToLower()) {
						case "messages":
							foreach (JavaScriptObject obj in jso[key] as JavaScriptArray)
								apiMessages.Add(new ApiMessage(obj));
							break;
					}
				}
				return apiMessages;
			}
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
}
}