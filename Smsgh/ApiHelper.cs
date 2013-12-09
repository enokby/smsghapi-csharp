// $Id: ApiHelper.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    public static class ApiHelper
    {
        /**
	 * GetJson
	 */

        public static T GetJson<T>(
            SmsghApiHost apiHostHost, string method, string uri, byte[] data)
        {
            var request = WebRequest.Create(
                String.Format("http{0}://{1}:{2}{3}",
                    apiHostHost.Https ? "s" : "", apiHostHost.Hostname,
                    apiHostHost.Port, uri)) as HttpWebRequest;

            if (request == null) throw new ApiException("Cannot Process Http request");

            request.Method = method;
            request.Accept = "application/json";
            request.Timeout = apiHostHost.Timeout*1000;
            request.Headers.Add(String.Format("Authorization: Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}",
                    apiHostHost.ClientId, apiHostHost.ClientSecret)))));
            request.ContentType = "application/json";

            if (data != null)
            {
                request.ContentLength = data.Length;
                request.GetRequestStream().Write(data, 0, data.Length);
            }
            else
            {
                request.ContentLength = 0;
            }

            string responseFromServer = null;
            var httpStatus = (HttpStatusCode) 0;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null) {
                    httpStatus = response.StatusCode;
                    using (Stream resStream = response.GetResponseStream())
                    using (resStream)
                    {
                        if (resStream != null)
                        {
                            using (var reader = new StreamReader(resStream))
                            {
                                responseFromServer = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }


            // In case of 204 response code response content length is 0
            if (httpStatus != HttpStatusCode.NoContent && string.IsNullOrEmpty(responseFromServer)) throw new ApiException("Unable to Process Http request");
            return JsonConvert.DeserializeObject<T>(responseFromServer);
        }

        /**
	 * Gets ApiList<T>
	 */

        public static ApiList<T> GetApiList<T>
            (SmsghApiHost apiHostHost, string uri, int page, int pageSize)
        {
            return GetApiList<T>(apiHostHost, uri, page, pageSize, false);
        }

        /**
	 * Gets ApiList<T> (Extended)
	 */

        public static ApiList<T> GetApiList<T>
            (SmsghApiHost apiHostHost, string uri, int page, int pageSize, bool hasQ)
        {
            if (page > 0)
            {
                uri += String.Format("{0}Page={1}", hasQ ? "&" : "?", page);
                if (!hasQ) hasQ = true;
            }
            if (pageSize > 0)
            {
                uri += String.Format("{0}PageSize={1}",
                    hasQ ? "&" : "?", pageSize);
            }
            try
            {
                return new ApiList<T>(
                    GetJson<ApiDictionary>
                        (apiHostHost, "GET", uri, null));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}