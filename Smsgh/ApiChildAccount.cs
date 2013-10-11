// $Id: ApiChildAccount.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API child account.
/// </summary>
public class ApiChildAccount
{
	// Data fields.
	private long      accountNumber;
	private double    balance;
	private bool      canImpersonate;
	private string    child;
	private double    credit;
	private long      id;
	private string    parent;
	private string    productId;
	private string    productName;
	private int       status;
	private DateTime  timeCreated;
	private DateTime? timeRemoved;
	
    /// <summary>
    /// Gets the account number of this API child account.
    /// </summary>
	public long AccountNumber {
		get {
			return this.accountNumber;
		}
	}
	
    /// <summary>
    /// Gets the balance of this API child account.
    /// </summary>
	public double Balance {
		get {
			return this.balance;
		}
	}
	
    /// <summary>
    /// Indicates whether this API child account can be impersonated.
    /// </summary>
	public bool CanImpersonate {
		get {
			return this.canImpersonate;
		}
	}
	
    /// <summary>
    /// Gets the child of this API child account.
    /// </summary>
	public string Child {
		get {
			return this.child;
		}
	}
	
    /// <summary>
    /// Gets the credit of this API child account.
    /// </summary>
	public double Credit {
		get {
			return this.credit;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API child account.
    /// </summary>
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Gets the parent of this API child account.
    /// </summary>
	public string Parent {
		get {
			return this.parent;
		}
	}
	
    /// <summary>
    /// Gets the product ID of this API child account.
    /// </summary>
	public string ProductId {
		get {
			return this.productId;
		}
	}
	
    /// <summary>
    /// Gets the product name of this API child account.
    /// </summary>
	public string ProductName {
		get {
			return this.productName;
		}
	}
	
    /// <summary>
    /// Gets the status of this API child account.
    /// </summary>
	public int Status {
		get {
			return this.status;
		}
	}
	
    /// <summary>
    /// Gets the created time of this API child account.
    /// </summary>
	public DateTime TimeCreated {
		get {
			return this.timeCreated;
		}
	}
	
    /// <summary>
    /// Gets the removed time of this API child account.
    /// </summary>
	public DateTime? TimeRemoved {
		get {
			return this.timeRemoved;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiChildAccount"/> class.
    /// </summary>
	public ApiChildAccount(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountnumber":
				this.accountNumber = Convert.ToInt64(jso[key]);
				break;
			case "balance":
				this.balance = Convert.ToDouble(jso[key]);
				break;
			case "canimpersonate":
				this.canImpersonate = Convert.ToBoolean(jso[key]);
				break;
			case "child":
				this.child = Convert.ToString(jso[key]);
				break;
			case "credit":
				this.credit = Convert.ToDouble(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "parent":
				this.parent = Convert.ToString(jso[key]);
				break;
			case "productid":
				this.productId = Convert.ToString(jso[key]);
				break;
			case "productname":
				this.productName = Convert.ToString(jso[key]);
				break;
			case "status":
				this.status = Convert.ToInt32(jso[key]);
				break;
			case "timecreated":
				if (jso[key].ToString() != "")
					this.timeCreated = Convert.ToDateTime(jso[key]);
				break;
			case "timeremoved":
				if (jso[key].ToString() != "")
					this.timeRemoved = Convert.ToDateTime(jso[key]);
				break;
		}
	}
}
}
