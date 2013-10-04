/**
 * $Id: ApiMessage.cs 226 2013-08-29 11:34:52Z mkwayisi $
 */

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
	private Guid      id;
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
	public Guid Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets id.
	 */
	public Guid MessageId {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets networkId.
	 */
	public string NetworkId {
		get {
			return this.networkId;
		}
	}
	
	/**
	 * Gets rate.
	 */
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
	public double Units {
		get {
			return this.units;
		}
	}
	
	/**
	 * Gets updateTime.
	 */
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
	 * Construct from JavaScriptObject.
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
					this.id = new Guid(Convert.ToString(jso[key]));
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
				default:
					// Nothing here to see.
					break;
			}
		}
	}
	
	/**
	 * Encodes a string.
	 */
	private static string jsonEncode(string str)
	{
		return str == null ? "null" :
			str
			.Replace("\"", "\\\"")
			.Replace("\b", "\\b")
			.Replace("\f", "\\f")
			.Replace("\r", "\\r")
			.Replace("\n", "\\n")
			.Replace("\t", "\\t")
			.Insert(0, "\"") + "\"";
	}
	
	/**
	 * Serializes this object as JSON.
	 */
	public string Serialize()
	{
		StringBuilder sbBuffer = new StringBuilder().Append("{")
			.AppendFormat("\"From\":{0},", jsonEncode(this.from))
			.AppendFormat("\"To\":{0},", jsonEncode(this.to))
			.AppendFormat("\"Content\":{0}", jsonEncode(this.content));
			
		if (this.apiMessageType >= 0) {
			sbBuffer.AppendFormat(
				",\"ApiMessageType\":{0}",
					this.apiMessageType);
		}
		
		if (this.clientReference != null) {
			sbBuffer.AppendFormat(
				",\"ClientReference\":{0}",
					jsonEncode(this.clientReference));
		}
		
		if (this.flashMessage) {
			sbBuffer.Append(",\"FlashMessage\":true");
		}
		
		if (this.registeredDelivery) {
			sbBuffer.Append(",\"RegisteredDelivery\":true");
		}
		
		if (this.time != null) {
			sbBuffer.AppendFormat(
				",\"Time\":\"{0}\"",
					this.time.GetValueOrDefault()
						.ToString("yyyy-MM-dd HH:mm:ss"));
		}
		
		if (this.udh != null) {
			sbBuffer.AppendFormat(
				",\"Udh\":{0}",
					jsonEncode(this.udh));
		}
		
		return sbBuffer.Append("}").ToString();
	}
}
}