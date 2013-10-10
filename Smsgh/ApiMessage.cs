// $Id: ApiMessage.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using Smsgh.Json;

public class ApiMessage
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Gets or sets apiMessageType.
	 */
	public int ApiMessageType {
		get {
			return this.apiMessageType;
		}
		set {
			this.apiMessageType = value;
		}
	}
	
	/**
	 * Gets or sets clientReference.
	 */
	public string ClientReference {
		get {
			return this.clientReference;
		}
		set {
			this.clientReference = value;
		}
	}
	
	/**
	 * Gets or sets content.
	 */
	public string Content {
		get {
			return this.content;
		}
		set {
			this.content = value;
		}
	}
	
	/**
	 * Gets direction.
	 */
	[JsonIgnoreAttribute]
	public string Direction {
		get {
			return this.direction;
		}
	}
	
	/**
	 * Gets or sets flashMessage;
	 */
	public bool IsFlashMessage {
		get {
			return this.flashMessage;
		}
		set {
			this.flashMessage = value;
		}
	}
	
	/**
	 * Gets or sets from.
	 */
	public string From {
		get {
			return this.from;
		}
		set {
			this.from = value;
		}
	}
	
	/**
	 * Gets id.
	 */
	[JsonIgnoreAttribute]
	public Guid MessageId {
		get {
			return this.messageId;
		}
	}
	
	/**
	 * Gets networkId.
	 */
	[JsonIgnoreAttribute]
	public string NetworkId {
		get {
			return this.networkId;
		}
	}
	
	/**
	 * Gets rate.
	 */
	[JsonIgnoreAttribute]
	public double Rate {
		get {
			return this.rate;
		}
	}
	
	/**
	 * Gets or sets registeredDelivery.
	 */
	public bool IsRegisteredDelivery {
		get {
			return this.registeredDelivery;
		}
		set {
			this.registeredDelivery = value;
		}
	}
	
	/**
	 * Gets status.
	 */
	[JsonIgnoreAttribute]
	public string Status {
		get {
			return this.status;
		}
	}
	
	/**
	 * Gets or sets time.
	 */
	public System.DateTime? Time {
		get {
			return this.time;
		}
		set {
			this.time = value;
		}
	}
	
	/**
	 * Gets or sets to.
	 */
	public string To {
		get {
			return this.to;
		}
		set {
			this.to = value;
		}
	}
	
	/**
	 * Gets or sets udh.
	 */
	public string Udh {
		get {
			return this.udh;
		}
		set {
			this.udh = value;
		}
	}
	
	/**
	 * Gets units.
	 */
	[JsonIgnoreAttribute]
	public double Units {
		get {
			return this.units;
		}
	}
	
	/**
	 * Gets updateTime.
	 */
	[JsonIgnoreAttribute]
	public System.DateTime? UpdateTime {
		get {
			return this.updateTime;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiMessage()
	{
	}
	
	/**
	 * Construct from JSO.
	 */
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
