// $Id: ApiContactGroup.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiContactGroup
{
	/**
	 * Data fields.
	 */
	private string accountId;
	private int    contactCount;
	private int    groupId;
	private string name;
	
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
	 * Gets contactCount.
	 */
	[JsonIgnoreAttribute]
	public int ContactCount {
		get {
			return this.contactCount;
		}
	}
	
	/**
	 * Gets groupId.
	 */
	[JsonIgnoreAttribute]
	public int GroupId {
		get {
			return this.groupId;
		}
	}
	
	/**
	 * Gets or sets name.
	 */
	public string Name {
		get {
			return this.name;
		}
		set {
			this.name = value;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiContactGroup()
	{
	}
	
	/**
	 * Constructor from JSO.
	 */
	public ApiContactGroup(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "contactcount":
				this.contactCount = Convert.ToInt32(jso[key]);
				break;
			case "groupid":
				this.groupId = Convert.ToInt32(jso[key]);
				break;
			case "name":
				this.name = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
