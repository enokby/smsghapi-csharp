/**
 * $Id: ApiMessageResponse.cs 226 2013-08-29 11:34:52Z mkwayisi $
 */

namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

public class ApiMessageResponse
{
	/**
	 * Data fields.
	 */
	private readonly int status;
	private readonly Guid messageId;
	private readonly double rate;
	private readonly string networkId;
	private readonly string clientReference;
	private readonly Dictionary<string,string> detail;
	
	/**
	 * Gets or sets status.
	 */
	public int Status {
		get {
			return this.status;
		}
	}
	
	/**
	 * Gets or sets messageId.
	 */
	public Guid MessageId {
		get {
			return this.messageId;
		}
	}
	
	/**
	 * Gets or sets rate.
	 */
	public double Rate {
		get {
			return this.rate;
		}
	}
	
	/**
	 * Gets or sets networkId.
	 */
	public string NetworkId {
		get {
			return this.networkId;
		}
	}
	
	/**
	 * Gets or sets clientReference.
	 */
	public string ClientReference {
		get {
			return this.clientReference;
		}
	}
	
	/**
	 * Gets or sets detail.
	 */
	public Dictionary<string, string> Detail {
		get {
			return this.detail;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiMessageResponse()
	{
	}
	
	/**
	 * Constructor from object.
	 */
	public ApiMessageResponse(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys) {
			switch (key.ToLower()) {
				case "status":
					this.status = Convert.ToInt32(jso[key]);
					break;
				case "messageid":
					this.messageId = new Guid(Convert.ToString(jso[key]));
					break;
				case "rate":
					this.rate = Convert.ToDouble(jso[key]);
					break;
				case "networkid":
					this.networkId = Convert.ToString(jso[key]);
					break;
				case "clientreference":
					this.clientReference = Convert.ToString(jso[key]);
					break;
				case "detail":
					// TODO: Convert to type Dictionary.
					this.detail = null; // Suppress compiler warning.
					break;
			}
		}
	}
	
}
}
