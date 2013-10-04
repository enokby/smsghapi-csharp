// $Id$
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiChildAccount
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Gets accountNumber.
	 */
	public long AccountNumber {
		get {
			return this.accountNumber;
		}
	}
	
	/**
	 * Gets balance.
	 */
	public double Balance {
		get {
			return this.balance;
		}
	}
	
	/**
	 * Gets canImpersonate.
	 */
	public bool CanImpersonate {
		get {
			return this.canImpersonate;
		}
	}
	
	/**
	 * Gets child.
	 */
	public string Child {
		get {
			return this.child;
		}
	}
	
	/**
	 * Gets credit.
	 */
	public double Credit {
		get {
			return this.credit;
		}
	}
	
	/**
	 * Gets id.
	 */
	public long Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets parent.
	 */
	public string Parent {
		get {
			return this.parent;
		}
	}
	
	/**
	 * Gets productId.
	 */
	public string ProductId {
		get {
			return this.productId;
		}
	}
	
	/**
	 * Gets productName.
	 */
	public string ProductName {
		get {
			return this.productName;
		}
	}
	
	/**
	 * Gets status.
	 */
	public int Status {
		get {
			return this.status;
		}
	}
	
	/**
	 * Gets timeCreated.
	 */
	public DateTime TimeCreated {
		get {
			return this.timeCreated;
		}
	}
	
	/**
	 * Gets dateTime.
	 */
	public DateTime? TimeRemoved {
		get {
			return this.timeRemoved;
		}
	}
	
	/**
	 * Primary constructor.
	 */
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
