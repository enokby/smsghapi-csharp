using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmsghApi.Sdk.Smsgh
{
    public class ApiTicketsResource
    {
        private readonly SmsghApiHost _apiHost;

        public ApiTicketsResource(SmsghApiHost apiHost)
        {
            _apiHost = apiHost;
        }

        /// <summary>
        ///     Retrieves all Support Tickets
        /// </summary>
        public ApiList<ApiTicket> GetTickets()
        {
            return GetTickets(-1, -1);
        }

        /// <summary>
        /// Get a Support Ticket by id
        /// </summary>
        /// <param name="ticketId">Support Ticket Id</param>
        /// <returns>Intance of ApiTicket</returns>
        public ApiTicket GetTicket(long ticketId)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/tickets/" + ticketId;
            else
            {
                uri = "/" + _apiHost.ContextPath + "/tickets/" + ticketId;
            }

            return new ApiTicket(ApiHelper.GetJson<ApiDictionary>(_apiHost, "GET", uri, null));
        }

        /// <summary>
        ///     Retrieves API Support tickets by page and page size.
        /// </summary>
        /// <param name="page">One-based index of the page to query.</param>
        /// <param name="pageSize">Maximum number of entries in a page.</param>
        public ApiList<ApiTicket> GetTickets(int page, int pageSize)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/tickets/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/tickets/";
            }

            return ApiHelper.GetApiList<ApiTicket>
                (_apiHost, uri, page, pageSize);
        }


        /// <summary>
        ///     Creates a new API Ticket.
        /// </summary>
        /// <param name="apiTicket">The API Ticket to create.</param>
        public ApiTicket Create(ApiTicket apiTicket)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/tickets/";
            else
            {
                uri = "/" + _apiHost.ContextPath + "/tickets/";
            }

            try
            {
                if (apiTicket == null)
                    throw new ArgumentNullException("apiTicket");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, apiTicket);
                return new ApiTicket(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "POST", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                //throw new Exception("Error", ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Reply to a Support Ticket
        /// </summary>
        /// <param name="ticketId">The Ticket Id</param>
        /// <param name="reply">The ApiTicketResponse instance containing the reply</param>
        /// <returns>Updated ApiTicket instance</returns>
        public ApiTicket ReplyTicket(long ticketId, ApiTicketResponse reply)
        {
            string uri;
            if (string.IsNullOrEmpty(_apiHost.ContextPath))
                uri = "/tickets/" + ticketId;
            else
            {
                uri = "/" + _apiHost.ContextPath + "/tickets/" + ticketId;
            }

            try
            {
                if (reply == null)
                    throw new ArgumentNullException("reply");
                var zw = new StringWriter();
                new JsonSerializer().Serialize(zw, reply);
                return new ApiTicket(ApiHelper.GetJson<ApiDictionary>
                    (_apiHost, "PUT", uri,
                        Encoding.UTF8.GetBytes(zw.ToString())));
            }
            catch (Exception ex)
            {
                //throw new Exception("Error", ex);
                throw new ApiException(ex.Message);
            }
            
        }
    }
}
