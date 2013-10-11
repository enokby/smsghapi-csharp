// $Id: ApiContactGroup.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API contact group.
/// </summary>
public class ApiContactGroup
{
	// Data fields.
	private string accountId;
	private long   contactCount;
	private long   groupId;
	private string name;
	
    /// <summary>
    /// Gets the account ID of this API contact group.
    /// </summary>
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the contact count of this API contact group.
    /// </summary>
	[JsonIgnoreAttribute]
	public long ContactCount {
		get {
			return this.contactCount;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API contact group.
    /// </summary>
	[JsonIgnoreAttribute]
	public long GroupId {
		get {
			return this.groupId;
		}
	}
	
    /// <summary>
    /// Gets or sets the name of this API contact group.
    /// </summary>
	public string Name {
		get {
			return this.name;
		}
		set {
			this.name = value;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of this API contact group.
    /// </summary>
	public ApiContactGroup()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiContactGroup(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "contactcount":
				this.contactCount = Convert.ToInt64(jso[key]);
				break;
			case "groupid":
				this.groupId = Convert.ToInt64(jso[key]);
				break;
			case "name":
				this.name = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
