// $Id: ApiMessage.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;

/// <summary>
/// Represents an API message.
/// </summary>
public class ApiMessage
{
	// Data fields.
	private int       apiMessageType = -1;
	private string    clientReference;
	private string    content;
	private string    direction;
	private bool      flashMessage;
	private string    from;
	private Guid      messageId;
	private string    networkId;
	private double    rate;
	private bool      registeredDelivery;
	private string    status;
	private DateTime? time;
	private string    to;
	private string    udh;
	private double    units;
	private DateTime? updateTime;
	
    /// <summary>
    /// Gets or sets the API message type of this API message.
    /// </summary>
	public int ApiMessageType {
		get {
			return this.apiMessageType;
		}
		set {
			this.apiMessageType = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the client reference of this API message.
    /// </summary>
	public string ClientReference {
		get {
			return this.clientReference;
		}
		set {
			this.clientReference = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the content of this API message.
    /// </summary>
	public string Content {
		get {
			return this.content;
		}
		set {
			this.content = value;
		}
	}
	
    /// <summary>
    /// Gets the direction of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public string Direction {
		get {
			return this.direction;
		}
	}
	
    /// <summary>
    /// Gets or sets a value indicating whether is this API message is flash.
    /// </summary>
	public bool IsFlashMessage {
		get {
			return this.flashMessage;
		}
		set {
			this.flashMessage = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the originator of this API message.
    /// </summary>
	public string From {
		get {
			return this.from;
		}
		set {
			this.from = value;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public Guid MessageId {
		get {
			return this.messageId;
		}
	}
	
    /// <summary>
    /// Gets the network ID of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public string NetworkId {
		get {
			return this.networkId;
		}
	}
	
    /// <summary>
    /// Gets the rate of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public double Rate {
		get {
			return this.rate;
		}
	}
	
    /// <summary>
    /// Gets or sets a value indicating whether this API message is registered delivery.
    /// </summary>
	public bool IsRegisteredDelivery {
		get {
			return this.registeredDelivery;
		}
		set {
			this.registeredDelivery = value;
		}
	}
	
    /// <summary>
    /// Gets the status of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public string Status {
		get {
			return this.status;
		}
	}
	
    /// <summary>
    /// Gets or sets the scheduled time of this API message.
    /// </summary>
	public System.DateTime? Time {
		get {
			return this.time;
		}
		set {
			this.time = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the destination of this API message.
    /// </summary>
	public string To {
		get {
			return this.to;
		}
		set {
			this.to = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the UDH of this API message.
    /// </summary>
	public string Udh {
		get {
			return this.udh;
		}
		set {
			this.udh = value;
		}
	}
	
    /// <summary>
    /// Gets the units of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public double Units {
		get {
			return this.units;
		}
	}
	
    /// <summary>
    /// Gets the update time of this API message.
    /// </summary>
	[JsonIgnoreAttribute]
	public System.DateTime? UpdateTime {
		get {
			return this.updateTime;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of this API message.
    /// </summary>
	public ApiMessage()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiMessage(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys) {
			switch (key.ToLower()) {
				case "apimessagetype":
					this.apiMessageType = Convert.ToInt32(jso[key]);
					break;
				case "clientreference":
					this.clientReference = Convert.ToString(jso[key]);
					break;
				case "content":
					this.content = Convert.ToString(jso[key]);
					break;
				case "direction":
					this.direction = Convert.ToString(jso[key]);
					break;
				case "flashmessage":
					this.flashMessage = Convert.ToBoolean(jso[key]);
					break;
				case "from":
					this.from = Convert.ToString(jso[key]);
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
				case "registereddelivery":
					this.registeredDelivery = Convert.ToBoolean(jso[key]);
					break;
				case "status":
					this.status = Convert.ToString(jso[key]);
					break;
				case "time":
					this.time = Convert.ToDateTime(jso[key]);
					break;
				case "to":
					this.to = Convert.ToString(jso[key]);
					break;
				case "udh":
					this.udh = Convert.ToString(jso[key]);
					break;
				case "units":
					this.units = Convert.ToDouble(jso[key]);
					break;
				case "updatetime":
					this.updateTime = Convert.ToDateTime(jso[key]);
					break;
			}
		}
	}
}
}
