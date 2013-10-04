// $Id: ApiContact.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiContact
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Gets contactId.
	 */
	[JsonIgnoreAttribute]
	public long ContactId {
		get {
			return this.contactId;
		}
	}
	
	/**
	 * Gets or sets custom1.
	 */
	public string Custom1 {
		get {
			return this.custom1;
		}
		set {
			this.custom1 = value;
		}
	}
	
	/**
	 * Gets or sets custom2.
	 */
	public string Custom2 {
		get {
			return this.custom2;
		}
		set {
			this.custom2 = value;
		}
	}
	
	/**
	 * Gets or sets custom3.
	 */
	public string Custom3 {
		get {
			return this.custom3;
		}
		set {
			this.custom3 = value;
		}
	}
	
	/**
	 * Gets or sets firstName.
	 */
	public string FirstName {
		get {
			return this.firstName;
		}
		set {
			this.firstName = value;
		}
	}
	
	/**
	 * Gets or sets groupId.
	 */
	public long GroupId {
		get {
			return this.groupId;
		}
		set {
			this.groupId = value;
		}
	}
	
	/**
	 * Gets groupName.
	 */
	[JsonIgnoreAttribute]
	public string GroupName {
		get {
			return this.groupName;
		}
	}
	
	/**
	 * Gets or sets mobileNumber.
	 */
	public string MobileNumber {
		get {
			return this.mobileNumber;
		}
		set {
			this.mobileNumber = value;
		}
	}
	
	/**
	 * Gets owner.
	 */
	[JsonIgnoreAttribute]
	public string Owner {
		get {
			return this.owner;
		}
	}
	
	/**
	 * Gets or sets surname.
	 */
	public string Surname {
		get {
			return this.surname;
		}
		set {
			this.surname = value;
		}
	}
	
	/**
	 * Gets or sets title.
	 */
	public string Title {
		get {
			return this.title;
		}
		set {
			this.title = value;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiContact()
	{
	}
	
	/**
	 * Constructor from a JSO.
	 */
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