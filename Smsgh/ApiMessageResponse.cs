// $Id: ApiMessageResponse.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

/// <summary>
/// Represents an API message response.
/// </summary>
public class ApiMessageResponse
{
	// Data fields.
	private string clientReference;
	private Dictionary<string,string> detail;
	private Guid   messageId;
	private string networkId;
	private double rate;
	private int    status;
	
    /// <summary>
    /// Gets the status of this API message response.
    /// </summary>
	public int Status {
		get {
			return this.status;
		}
	}
	
    /// <summary>
    /// Gets the message ID of this API message response.
    /// </summary>
	public Guid MessageId {
		get {
			return this.messageId;
		}
	}
	
    /// <summary>
    /// Gets the rate of this API message response.
    /// </summary>
	public double Rate {
		get {
			return this.rate;
		}
	}
	
    /// <summary>
    /// Gets the network ID of this API message response.
    /// </summary>
	public string NetworkId {
		get {
			return this.networkId;
		}
	}
	
    /// <summary>
    /// Gets the client reference of this API message response.
    /// </summary>
	public string ClientReference {
		get {
			return this.clientReference;
		}
	}
	
    /// <summary>
    /// Gets the detail of this API message response.
    /// </summary>
	public Dictionary<string, string> Detail {
		get {
			return this.detail;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of this API message response.
    /// </summary>
	public ApiMessageResponse()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiMessageResponse(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys) {
			switch (key.ToLower()) {
				case "clientreference":
					this.clientReference = Convert.ToString(jso[key]);
					break;
				case "detail":
					// ???
					this.detail = null;  // Suppress compiler warning.
					break;
				case "messageid":
					this.messageId = new Guid(Convert.ToString(jso[key]));
					break;
				case "networkid":
					this.networkId = Convert.ToString(jso[key]);
					break;
				case "rate":
					this.rate = Convert.ToDouble(jso[key]);
					break;
				case "status":
					this.status = Convert.ToInt32(jso[key]);
					break;
			}
		}
	}
}
}
