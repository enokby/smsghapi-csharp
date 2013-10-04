// $Id$

namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiAccountProfile
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Get accountId.
	 */
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Get accountManager.
	 */
	public string AccountManager {
		get {
			return this.accountManager;
		}
	}
	
	/**
	 * Get accountNumber.
	 */
	public long AccountNumber {
		get {
			return this.accountNumber;
		}
	}
	
	/**
	 * Get accountStatus;
	 */
	public string AccountStatus {
		get {
			return this.accountStatus;
		}
	}
	
	/**
	 * Get balance.
	 */
	public double Balance {
		get {
			return this.balance;
		}
	}
	
	/**
	 * Get company.
	 */
	public string Company {
		get {
			return this.company;
		}
	}
	
	/**
	 * Get credit.
	 */
	public double Credit {
		get {
			return this.credit;
		}
	}
	
	/**
	 * Get emailAddress.
	 */
	public string EmailAddress {
		get {
			return this.emailAddress;
		}
	}
	
	/**
	 * Get lastAccessed.
	 */
	public DateTime LastAccessed {
		get {
			return this.lastAccessed;
		}
	}
	
	/**
	 * Get mobileNumber.
	 */
	public string MobileNumber {
		get {
			return this.mobileNumber;
		}
	}
	
	/**
	 * Get numberOfServices.
	 */
	public int NumberOfServices {
		get {
			return this.numberOfServices;
		}
	}
	
	/**
	 * Get primaryContact.
	 */
	public string PrimaryContact {
		get {
			return this.primaryContact;
		}
	}
	
	/**
	 * Get unpostedBalance.
	 */
	public double UnpostedBalance {
		get {
			return this.unpostedBalance;
		}
	}
	
	/**
	 * Primary constructor.
	 */
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
