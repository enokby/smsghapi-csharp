// $Id: ApiSender.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API sender.
/// </summary>
public class ApiSender
{
	// Data fields.
	private string    accountId;
	private string    address;
	private long      id;
	private bool      isDeleted;
	private DateTime  timeAdded;
	private DateTime? timeDeleted;
	
    /// <summary>
    /// Gets the account ID of this API sender.
    /// </summary>
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets or sets the address of this API sender.
    /// </summary>
	public string Address {
		get {
			return this.address;
		}
		set {
			this.address = value;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API sender.
    /// </summary>
	[JsonIgnoreAttribute]
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Indicated whether this API sender is deleted.
    /// </summary>
	[JsonIgnoreAttribute]
	public bool IsDeleted {
		get {
			return this.isDeleted;
		}
	}
	
    /// <summary>
    /// Gets the created date of this API sender.
    /// </summary>
	[JsonIgnoreAttribute]
	public DateTime TimeAdded {
		get {
			return this.timeAdded;
		}
	}
	
    /// <summary>
    /// Gets the deleted date of this API sender.
    /// </summary>
	[JsonIgnoreAttribute]
	public DateTime? TimeDeleted {
		get {
			return this.timeDeleted;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiSender"/> class.
    /// </summary>
	public ApiSender()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
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
