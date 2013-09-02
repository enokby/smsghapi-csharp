// $Id: ApiHost.cs 229 2013-08-30 16:38:25Z mkwayisi $

namespace Smsgh
{

using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class ApiHost
{
	/**
	 * Data fields.
	 */
	private string clientId;
	private string clientSecret;
	private string hostname;
	private int    port;
	private bool   https;
	private int    timeout;
	private ApiMessagesResource messagesResource;
	
	/**
	 * Gets or sets clientId.
	 */
	public string ClientId {
		get {
			return this.clientId;
		}
		set {
			this.clientId = value;
		}
	}
	
	/**
	 * Gets or sets clientSecret.
	 */
	public string ClientSecret {
		get {
			return this.clientSecret;
		}
		set {
			this.clientSecret = value;
		}
	}
	
	/**
	 * Gets or sets hostname.
	 */
	public string Hostname {
		get {
			return this.hostname;
		}
		set {
			this.hostname = value;
		}
	}
	
	/**
	 * Gets or sets port.
	 */
	public int Port {
		get {
			return this.port;
		}
		set {
			this.port = value;
		}
	}
	
	/**
	 * Gets or sets Https.
	 */
	public bool Https {
		get {
			return this.https;
		}
		set {
			this.https = value;
		}
	}
	
	/**
	 * Gets or sets timeout.
	 */
	public int Timeout {
		get {
			return this.timeout;
		}
		set {
			this.timeout = value;
		}
	}
	
	/**
	 * Gets messagesResource.
	 */
	public ApiMessagesResource MessagesResource {
		get {
			return this.messagesResource;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiHost() {
		this.hostname = "api.smsgh.com";
		this.port = 443;
		this.https = true;
		this.timeout = 15;
		this.messagesResource = new ApiMessagesResource(this);
		ServicePointManager.ServerCertificateValidationCallback = CertChecker;
	}
	
	/**
	 * Constructor with client id and secret.
	 */
	public ApiHost(string clientId, string clientSecret) : this() {
		this.clientId = clientId;
		this.clientSecret = clientSecret;
	}
	
	/**
	 * CertChecker
	 */
	private static bool CertChecker(object s, X509Certificate cert,
		X509Chain chain, SslPolicyErrors errs) {
		return true;
	}
}
}
