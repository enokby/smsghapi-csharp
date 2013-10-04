// $Id: ApiSender.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiSender
{
	/**
	 * Data fields.
	 */
	private string    accountId;
	private string    address;
	private long      id;
	private bool      isDeleted;
	private DateTime  timeAdded;
	private DateTime? timeDeleted;
	
	/**
	 * Gets accountId.
	 */
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Gets or sets address.
	 */
	public string Address {
		get {
			return this.address;
		}
		set {
			this.address = value;
		}
	}
	
	/**
	 * Gets id.
	 */
	[JsonIgnoreAttribute]
	public long Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets isDeleted.
	 */
	[JsonIgnoreAttribute]
	public bool IsDeleted {
		get {
			return this.isDeleted;
		}
	}
	
	/**
	 * Gets timeAdded.
	 */
	[JsonIgnoreAttribute]
	public DateTime TimeAdded {
		get {
			return this.timeAdded;
		}
	}
	
	/**
	 * Gets timeDeleted.
	 */
	[JsonIgnoreAttribute]
	public DateTime? TimeDeleted {
		get {
			return this.timeDeleted;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiSender()
	{
	}
	
	/**
	 * Constructor from JSO.
	 */
	public ApiSender(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "address":
				this.address = Convert.ToString(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "isdeleted":
				this.isDeleted = Convert.ToBoolean(jso[key]);
				break;
			case "timeadded":
				this.timeAdded = Convert.ToDateTime(jso[key]);
				break;
			case "timedeleted":
				if (jso[key].ToString() != "")
					this.timeDeleted = Convert.ToDateTime(jso[key]);
				break;
		}
	}
}
}
