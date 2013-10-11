// $Id: ApiAccountContact.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API account contact.
/// </summary>
public class ApiAccountContact
{
	// Data fields.
	private long   accountContactId;
	private string address1;
	private string address2;
	private string city;
	private string country;
	private string firstName;
	private string lastName;
	private string province;
	private string postalCode;
	private string primaryEmail;
	private string primaryPhone;
	private string privateNote;
	private string publicNote;
	private string secondaryEmail;
	private string secondaryPhone;
	
    /// <summary>
    /// Gets the ID of this account contact.
    /// </summary>
	[JsonIgnoreAttribute]
	public long AccountContactId {
		get {
			return this.accountContactId;
		}
	}
	
    /// <summary>
    /// Gets or sets the address 1 of this account contact.
    /// </summary>
	public string Address1 {
		get {
			return this.address1;
		}
		set {
			this.address1 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the address 2 of this account contact.
    /// </summary>
	public string Address2 {
		get {
			return this.address2;
		}
		set {
			this.address2 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the city of this account contact.
    /// </summary>
	public string City {
		get {
			return this.city;
		}
		set {
			this.city = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the country of this account contact.
    /// </summary>
	public string Country {
		get {
			return this.country;
		}
		set {
			this.country = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the first name of this account contact.
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
    /// Gets or sets the last name of this account contact.
    /// </summary>
	public string LastName {
		get {
			return this.lastName;
		}
		set {
			this.lastName = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the province of this account contact.
    /// </summary>
	public string Province {
		get {
			return this.province;
		}
		set {
			this.province = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the postal code of this account contact.
    /// </summary>
	public string PostalCode {
		get {
			return this.postalCode;
		}
		set {
			this.postalCode = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the primary email of this account contact.
    /// </summary>
	public string PrimaryEmail {
		get {
			return this.primaryEmail;
		}
		set {
			this.primaryEmail = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the primary phone number of this account contact.
    /// </summary>
	public string PrimaryPhone {
		get {
			return this.primaryPhone;
		}
		set {
			this.primaryPhone = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the private note of this account contact.
    /// </summary>
	public string PrivateNote {
		get {
			return this.privateNote;
		}
		set {
			this.privateNote = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the public note of this account contact.
    /// </summary>
	public string PublicNote {
		get {
			return this.publicNote;
		}
		set {
			this.publicNote = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the secondary email of this account contact.
    /// </summary>
	public string SecondaryEmail {
		get {
			return this.secondaryEmail;
		}
		set {
			this.secondaryEmail = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the secondary phone of this account contact.
    /// </summary>
	public string SecondaryPhone {
		get {
			return this.secondaryPhone;
		}
		set {
			this.secondaryPhone = value;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiAccountContact"/> class.
    /// </summary>
	public ApiAccountContact(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys) {
			switch (key.ToLower()) {
				case "accountcontactid":
					this.accountContactId = Convert.ToInt64(jso[key]);
					break;
				case "address1":
					this.address1 = Convert.ToString(jso[key]);
					break;
				case "address2":
					this.address2 = Convert.ToString(jso[key]);
					break;
				case "city":
					this.city = Convert.ToString(jso[key]);
					break;
				case "country":
					this.country = Convert.ToString(jso[key]);
					break;
				case "firstname":
					this.firstName = Convert.ToString(jso[key]);
					break;
				case "lastname":
					this.lastName = Convert.ToString(jso[key]);
					break;
				case "province":
					this.province = Convert.ToString(jso[key]);
					break;
				case "postalcode":
					this.postalCode = Convert.ToString(jso[key]);
					break;
				case "primaryemail":
					this.primaryEmail = Convert.ToString(jso[key]);
					break;
				case "primaryphone":
					this.primaryPhone = Convert.ToString(jso[key]);
					break;
				case "privatenote":
					this.privateNote = Convert.ToString(jso[key]);
					break;
				case "publicnote":
					this.publicNote = Convert.ToString(jso[key]);
					break;
				case "secondaryemail":
					this.secondaryEmail = Convert.ToString(jso[key]);
					break;
				case "secondaryphone":
					this.secondaryPhone = Convert.ToString(jso[key]);
					break;
			}
		}
	}
}
}