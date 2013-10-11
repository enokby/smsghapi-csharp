// $Id: ApiAccountProfile.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API account profile.
/// </summary>
public class ApiAccountProfile
{
	// Data fields.
	private string   accountId;
	private string   accountManager;
	private long     accountNumber;
	private string   accountStatus;
	private double   balance;
	private string   company;
	private double   credit;
	private string   emailAddress;
	private DateTime lastAccessed;
	private string   mobileNumber;
	private int      numberOfServices;
	private string   primaryContact;
	private double   unpostedBalance;
	
    /// <summary>
    /// Gets the ID of this account profile.
    /// </summary>
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the account manager of this account profile.
    /// </summary>
	public string AccountManager {
		get {
			return this.accountManager;
		}
	}
	
    /// <summary>
    /// Gets the account number of this account profile.
    /// </summary>
	public long AccountNumber {
		get {
			return this.accountNumber;
		}
	}
	
    /// <summary>
    /// Gets the account status of this account profile.
    /// </summary>
	public string AccountStatus {
		get {
			return this.accountStatus;
		}
	}
	
    /// <summary>
    /// Gets the balance of this account profile.
    /// </summary>
	public double Balance {
		get {
			return this.balance;
		}
	}
	
    /// <summary>
    /// Gets the company of this account profile.
    /// </summary>
	public string Company {
		get {
			return this.company;
		}
	}
	
    /// <summary>
    /// Gets the credit of this account profile.
    /// </summary>
	public double Credit {
		get {
			return this.credit;
		}
	}
	
    /// <summary>
    /// Gets the email address of this account profile.
    /// </summary>
	public string EmailAddress {
		get {
			return this.emailAddress;
		}
	}
	
    /// <summary>
    /// Gets the last accessed date of this account profile.
    /// </summary>
	public DateTime LastAccessed {
		get {
			return this.lastAccessed;
		}
	}
	
    /// <summary>
    /// Gets the mobile number of this account profile.
    /// </summary>
	public string MobileNumber {
		get {
			return this.mobileNumber;
		}
	}
	
    /// <summary>
    /// Gets the number of services on this account profile.
    /// </summary>
	public int NumberOfServices {
		get {
			return this.numberOfServices;
		}
	}
	
    /// <summary>
    /// Gets the primary contact of this account profile.
    /// </summary>
	public string PrimaryContact {
		get {
			return this.primaryContact;
		}
	}
	
    /// <summary>
    /// Gets the unposted balance of this account profile.
    /// </summary>
	public double UnpostedBalance {
		get {
			return this.unpostedBalance;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiAccountProfile"/> class.
    /// </summary>
	public ApiAccountProfile(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys) {
			switch (key.ToLower()) {
				case "accountid":
					this.accountId = Convert.ToString(jso[key]);
					break;
				case "accountmanager":
					this.accountManager = Convert.ToString(jso[key]);
					break;
				case "accountnumber":
					this.accountNumber = Convert.ToInt64(jso[key]);
					break;
				case "accountstatus":
					this.accountStatus = Convert.ToString(jso[key]);
					break;
				case "balance":
					this.balance = Convert.ToDouble(jso[key]);
					break;
				case "company":
					this.company = Convert.ToString(jso[key]);
					break;
				case "credit":
					this.credit = Convert.ToDouble(jso[key]);
					break;
				case "emailaddress":
					this.emailAddress = Convert.ToString(jso[key]);
					break;
				case "lastaccessed":
					if (jso[key].ToString() != "")
						this.lastAccessed = Convert.ToDateTime(jso[key]);
					break;
				case "mobilenumber":
					this.mobileNumber = Convert.ToString(jso[key]);
					break;
				case "numberofservices":
					this.numberOfServices = Convert.ToInt32(jso[key]);
					break;
				case "primarycontact":
					this.primaryContact = Convert.ToString(jso[key]);
					break;
				case "unpostedbalance":
					this.unpostedBalance = Convert.ToDouble(jso[key]);
					break;
			}
		}
	}
}
}
