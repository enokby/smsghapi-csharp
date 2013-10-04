// $Id$
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiAccountContact
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Get accountContactId.
	 */
	[JsonIgnoreAttribute]
	public long AccountContactId {
		get {
			return this.accountContactId;
		}
	}
	
	/**
	 * Gets or sets address1.
	 */
	public string Address1 {
		get {
			return this.address1;
		}
		set {
			this.address1 = value;
		}
	}
	
	/**
	 * Gets or sets address2.
	 */
	public string Address2 {
		get {
			return this.address2;
		}
		set {
			this.address2 = value;
		}
	}
	
	/**
	 * Gets or sets city.
	 */
	public string City {
		get {
			return this.city;
		}
		set {
			this.city = value;
		}
	}
	
	/**
	 * Gets or set country.
	 */
	public string Country {
		get {
			return this.country;
		}
		set {
			this.country = value;
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
	 * Gets or sets lastName.
	 */
	public string LastName {
		get {
			return this.lastName;
		}
		set {
			this.lastName = value;
		}
	}
	
	/**
	 * Gets or sets province.
	 */
	public string Province {
		get {
			return this.province;
		}
		set {
			this.province = value;
		}
	}
	
	/**
	 * Gets or sets postalCode.
	 */
	public string PostalCode {
		get {
			return this.postalCode;
		}
		set {
			this.postalCode = value;
		}
	}
	
	/**
	 * Gets or sets primaryEmail.
	 */
	public string PrimaryEmail {
		get {
			return this.primaryEmail;
		}
		set {
			this.primaryEmail = value;
		}
	}
	
	/**
	 * Gets or sets primaryPhone.
	 */
	public string PrimaryPhone {
		get {
			return this.primaryPhone;
		}
		set {
			this.primaryPhone = value;
		}
	}
	
	/**
	 * Gets or sets privateNote.
	 */
	public string PrivateNote {
		get {
			return this.privateNote;
		}
		set {
			this.privateNote = value;
		}
	}
	
	/**
	 * Gets or sets publicNote.
	 */
	public string PublicNote {
		get {
			return this.publicNote;
		}
		set {
			this.publicNote = value;
		}
	}
	
	/**
	 * Gets or sets secondaryEmail.
	 */
	public string SecondaryEmail {
		get {
			return this.secondaryEmail;
		}
		set {
			this.secondaryEmail = value;
		}
	}
	
	/**
	 * Gets or sets secondaryPhone.
	 */
	public string SecondaryPhone {
		get {
			return this.secondaryPhone;
		}
		set {
			this.secondaryPhone = value;
		}
	}
	
	/**
	 * Primary Constructor.
	 */
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