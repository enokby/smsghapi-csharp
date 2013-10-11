// $Id: SmsghApi.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents an SMSGH API host.
/// </summary>
public class SmsghApi
{
	// Data fields.
	private string clientId;
	private string clientSecret;
	private string hostname;
	private int    port;
	private bool   https;
	private int    timeout;
	private ApiMessagesResource messagesResource;
	private ApiAccountResource accountResource;
	private ApiContactsResource contactsResource;
	private ApiPremiumResource premiumResource;
	private ApiBulkMessagingResource bulkMessagingResource;
	
    /// <summary>
    /// Gets or sets the client ID of this SMSGH API host.
    /// </summary>
	public string ClientId {
		get {
			return this.clientId;
		}
		set {
			this.clientId = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the client secret of this SMSGH API host.
    /// </summary>
	public string ClientSecret {
		get {
			return this.clientSecret;
		}
		set {
			this.clientSecret = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the hostname of this SMSGH API host.
    /// </summary>
	public string Hostname {
		get {
			return this.hostname;
		}
		set {
			this.hostname = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the port of this SMSGH API host.
    /// </summary>
	public int Port {
		get {
			return this.port;
		}
		set {
			this.port = value;
		}
	}
	
    /// <summary>
    /// Indicates whether this SMSGH API host should use secured connection.
    /// </summary>
	public bool Https {
		get {
			return this.https;
		}
		set {
			this.https = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the timeout of this SMSGH API host.
    /// </summary>
	public int Timeout {
		get {
			return this.timeout;
		}
		set {
			this.timeout = value;
		}
	}
	
    /// <summary>
    /// Gets the API account resource of this SMSGH API host.
    /// </summary>
	public ApiAccountResource Account {
		get {
			return this.accountResource;
		}
	}
	
    /// <summary>
    /// Gets the API messages resource of this SMSGH API host.
    /// </summary>
	public ApiMessagesResource Messages {
		get {
			return this.messagesResource;
		}
	}
	
    /// <summary>
    /// Gets the API contacts resource of this SMSGH API host.
    /// </summary>
	public ApiContactsResource Contacts {
		get {
			return this.contactsResource;
		}
	}
	
    /// <summary>
    /// Gets the API premium resource of this SMSGH API host.
    /// </summary>
	public ApiPremiumResource Premium {
		get {
			return this.premiumResource;
		}
	}
	
    /// <summary>
    /// Gets the API bulk messaging resource of this SMSGH API host.
    /// </summary>
	public ApiBulkMessagingResource BulkMessaging {
		get {
			return this.bulkMessagingResource;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="SmsghApi"/> class.
    /// </summary>
	public SmsghApi() {
		this.hostname = "api.smsgh.com";
		this.port = 443;
		this.https = true;
		this.timeout = 15;
		this.accountResource = new ApiAccountResource(this);
		this.messagesResource = new ApiMessagesResource(this);
		this.contactsResource = new ApiContactsResource(this);
		this.premiumResource = new ApiPremiumResource(this);
		this.bulkMessagingResource = new ApiBulkMessagingResource(this);
		ServicePointManager.Expect100Continue = false;
		ServicePointManager.ServerCertificateValidationCallback = CertChecker;
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="SmsghApi"/> class
	/// by setting a default client ID and secret.
    /// </summary>
	public SmsghApi(string clientId, string clientSecret) : this() {
		this.clientId = clientId;
		this.clientSecret = clientSecret;
	}
	
    /// <summary>
    /// CertChecker.
    /// </summary>
	private static bool CertChecker(object s, X509Certificate cert,
		X509Chain chain, SslPolicyErrors errs) {
		return true;
	}
}
}
