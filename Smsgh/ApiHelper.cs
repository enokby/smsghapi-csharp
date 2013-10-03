// $Id$
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
		ApiHost apiHost, string method, string uri, byte[] data)
	{
		HttpWebRequest request = HttpWebRequest.Create(
			String.Format("http{0}://{1}:{2}{3}",
				apiHost.Https ? "s" : "", apiHost.Hostname,
					apiHost.Port, uri)) as HttpWebRequest;
		request.Accept = "application/json";
		request.Timeout = apiHost.Timeout * 1000;
		request.Headers.Add(String.Format("Authorization: Basic {0}",
			Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}",
					apiHost.ClientId, apiHost.ClientSecret)))));
					
		if (data != null) {
			request.Method = method;
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
	 * GetApiList
	 */
	public static ApiList<T> GetApiList<T>
		(ApiHost apiHost, string uri, int page, int pageSize)
	{
		if (page > 0)
			uri += "?Page=" + page;
		if (pageSize > 0)
			uri += (page > 0 ? "&" : "?") + "PageSize=" + pageSize;
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
