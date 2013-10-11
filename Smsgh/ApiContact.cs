// $Id: ApiContact.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API contact.
/// </summary>
public class ApiContact
{
	// Data fields.
	private long   contactId;
	private string custom1;
	private string custom2;
	private string custom3;
	private string firstName;
	private long   groupId;
	private string groupName;
	private string mobileNumber;
	private string owner;
	private string surname;
	private string title;
	
    /// <summary>
    /// Gets the ID of this API contact.
    /// </summary>
	[JsonIgnoreAttribute]
	public long ContactId {
		get {
			return this.contactId;
		}
	}
	
    /// <summary>
    /// Gets or sets the custom 1 of this API contact.
    /// </summary>
	public string Custom1 {
		get {
			return this.custom1;
		}
		set {
			this.custom1 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the custom 2 of this API contact.
    /// </summary>
	public string Custom2 {
		get {
			return this.custom2;
		}
		set {
			this.custom2 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the custom 3 of this API contact.
    /// </summary>
	public string Custom3 {
		get {
			return this.custom3;
		}
		set {
			this.custom3 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the first name of this API contact.
    /// </summary>
	public string FirstName {
		get {
			return this.firstName;
		}
		set {
			this.firstName = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the group ID of this API contact.
    /// </summary>
	public long GroupId {
		get {
			return this.groupId;
		}
		set {
			this.groupId = value;
		}
	}
	
    /// <summary>
    /// Gets the group name of this API contact.
    /// </summary>
	[JsonIgnoreAttribute]
	public string GroupName {
		get {
			return this.groupName;
		}
	}
	
    /// <summary>
    /// Gets or sets the mobile number of this API contact.
    /// </summary>
	public string MobileNumber {
		get {
			return this.mobileNumber;
		}
		set {
			this.mobileNumber = value;
		}
	}
	
    /// <summary>
    /// Gets the owner of this API contact.
    /// </summary>
	[JsonIgnoreAttribute]
	public string Owner {
		get {
			return this.owner;
		}
	}
	
    /// <summary>
    /// Gets or sets the surname of this API contact.
    /// </summary>
	public string Surname {
		get {
			return this.surname;
		}
		set {
			this.surname = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the title of this API contact.
    /// </summary>
	public string Title {
		get {
			return this.title;
		}
		set {
			this.title = value;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiContact"/> class.
    /// </summary>
	public ApiContact()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the instance of this class.
    /// </summary>
	public ApiContact(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "contactid":
				this.contactId = Convert.ToInt64(jso[key]);
				break;
			case "custom1":
				this.custom1 = Convert.ToString(jso[key]);
				break;
			case "custom2":
				this.custom2 = Convert.ToString(jso[key]);
				break;
			case "custom3":
				this.custom3 = Convert.ToString(jso[key]);
				break;
			case "firstname":
				this.firstName = Convert.ToString(jso[key]);
				break;
			case "groupid":
				this.groupId = Convert.ToInt64(jso[key]);
				break;
			case "groupname":
				this.groupName = Convert.ToString(jso[key]);
				break;
			case "mobilenumber":
				this.mobileNumber = Convert.ToString(jso[key]);
				break;
			case "owner":
				this.owner = Convert.ToString(jso[key]);
				break;
			case "surname":
				this.surname = Convert.ToString(jso[key]);
				break;
			case "title":
				this.title = Convert.ToString(jso[key]);
				break;
		}
	}
}
}