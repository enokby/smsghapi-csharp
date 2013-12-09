// $Id: SmsghApi.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
    ///     Represents an SMSGH API host.
    /// </summary>
    public class SmsghApiHost
    {
        // Data fields.
        private readonly ApiAccountResource _accountResource;
        private readonly ApiBulkMessagingResource _bulkMessagingResource;
        private readonly ApiContactsResource _contactsResource;
        private readonly ApiMessagesResource _messagesResource;
        private readonly ApiPremiumResource _premiumResource;
        private readonly ApiTicketsResource _ticketsResource;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsghApiHost" /> class.
        /// </summary>
        public SmsghApiHost()
        {
            Hostname = "api.smsgh.com";
            Port = 443;
            Https = true;
            Timeout = 15;
            ContextPath = string.Empty;
            _accountResource = new ApiAccountResource(this);
            _messagesResource = new ApiMessagesResource(this);
            _contactsResource = new ApiContactsResource(this);
            _premiumResource = new ApiPremiumResource(this);
            _bulkMessagingResource = new ApiBulkMessagingResource(this);
            _ticketsResource = new ApiTicketsResource(this);
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = CertChecker;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsghApiHost" /> class
        ///     by setting a default client ID and secret.
        /// </summary>
        public SmsghApiHost(string clientId, string clientSecret) : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        /// <summary>
        ///     Gets or sets the client ID of this SMSGH API host.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the client secret of this SMSGH API host.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Gets or sets the hostname of this SMSGH API host.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        ///     Gets or sets the port of this SMSGH API host.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        ///     Indicates whether this SMSGH API host should use secured connection.
        /// </summary>
        public bool Https { get; set; }

        /// <summary>
        ///     Gets or sets the timeout of this SMSGH API host.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// The Api Context Path
        /// </summary>
        public String ContextPath { get; set; }

        /// <summary>
        ///     Gets the API account resource of this SMSGH API host.
        /// </summary>
        public ApiAccountResource Account
        {
            get { return _accountResource; }
        }

        /// <summary>
        ///     Gets the API messages resource of this SMSGH API host.
        /// </summary>
        public ApiMessagesResource Messages
        {
            get { return _messagesResource; }
        }

        /// <summary>
        ///     Gets the API contacts resource of this SMSGH API host.
        /// </summary>
        public ApiContactsResource Contacts
        {
            get { return _contactsResource; }
        }

        /// <summary>
        ///     Gets the API premium resource of this SMSGH API host.
        /// </summary>
        public ApiPremiumResource Premium
        {
            get { return _premiumResource; }
        }

        /// <summary>
        ///     Gets the API bulk messaging resource of this SMSGH API host.
        /// </summary>
        public ApiBulkMessagingResource BulkMessaging
        {
            get { return _bulkMessagingResource; }
        }

        /// <summary>
        /// Get the API tickets resource
        /// </summary>
        public ApiTicketsResource Tickets
        {
            get { return _ticketsResource; }
        }

        /// <summary>
        ///     CertChecker.
        /// </summary>
        private static bool CertChecker(object s, X509Certificate cert,
            X509Chain chain, SslPolicyErrors errs)
        {
            return true;
        }
    }
}