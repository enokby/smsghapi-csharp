// $Id: ApiHelper.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using System.Net;
using Smsgh.Json;

public static class ApiHelper
{
	/**
	 * GetJson
	 */
	public static T GetJson<T>(
		SmsghApi apiHost, string method, string uri, byte[] data)
	{
		HttpWebRequest request = HttpWebRequest.Create(
			String.Format("http{0}://{1}:{2}{3}",
				apiHost.Https ? "s" : "", apiHost.Hostname,
					apiHost.Port, uri)) as HttpWebRequest;
		request.Method = method;
		request.Accept = "application/json";
		request.Timeout = apiHost.Timeout * 1000;
		request.Headers.Add(String.Format("Authorization: Basic {0}",
			Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}",
					apiHost.ClientId, apiHost.ClientSecret)))));
					
		if (data != null) {
			request.ContentType = "application/json";
			request.ContentLength = data.Length;
			request.GetRequestStream().Write(data, 0, data.Length);
		}
		
		using (WebResponse wr = request.GetResponse())
		using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
		using (StringReader zr = new StringReader(sr.ReadToEnd()))
		using (JsonReader jr = new JsonReader(zr))
			return (T) new JsonSerializer().Deserialize(jr);
	}
	
	/**
	 * Gets ApiList<T>
	 */
	public static ApiList<T> GetApiList<T>
		(SmsghApi apiHost, string uri, int page, int pageSize)
	{
		return GetApiList<T>(apiHost, uri, page, pageSize, false);
	}
	
	/**
	 * Gets ApiList<T> (Extended)
	 */
	public static ApiList<T> GetApiList<T>
		(SmsghApi apiHost, string uri, int page, int pageSize, bool hasQ)
	{
		if (page > 0) {
			uri += String.Format("{0}Page={1}", hasQ ? "&" : "?", page);
			if (!hasQ) hasQ = true;
		}
		if (pageSize > 0) {
			uri += String.Format("{0}PageSize={1}",
				hasQ ? "&" : "?", pageSize);
		}
		try {
			return new ApiList<T>(
				ApiHelper.GetJson<JavaScriptObject>
					(apiHost, "GET", uri, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
}
}
