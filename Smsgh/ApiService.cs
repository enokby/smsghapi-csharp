// $Id$
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiService
{
	/**
	 * Data fields.
	 */
	private string   accountId;
	private DateTime billDate;
	private long     billingCycleId;
	private DateTime dateCreated;
	private string   description;
	private bool     isCreditBased;
	private bool     isPrepaid;
	private double   rate;
	private long     serviceId;
	private long     serviceStatusTypeId;
	private long     serviceTypeId;
	
	/**
	 * Gets accountId.
	 */
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Gets billDate.
	 */
	public DateTime BillDate {
		get {
			return this.billDate;
		}
	}
	
	/**
	 * Gets billingCycleId.
	 */
	public long BillingCycleId {
		get {
			return this.billingCycleId;
		}
	}
	
	/**
	 * Gets dateCreated.
	 */
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
	}
	
	/**
	 * Gets description.
	 */
	public string Description {
		get {
			return this.description;
		}
	}
	
	/**
	 * Gets isCreditBased.
	 */
	public bool IsCreditBased {
		get {
			return this.isCreditBased;
		}
	}
	
	/**
	 * Gets isPrepaid.
	 */
	public bool IsPrepaid {
		get {
			return this.isPrepaid;
		}
	}
	
	/**
	 * Gets rate.
	 */
	public double Rate {
		get {
			return this.rate;
		}
	}
	
	/**
	 * Gets serviceId.
	 */
	public long ServiceId {
		get {
			return this.serviceId;
		}
	}
	
	/**
	 * Gets serviceStatusTypeId.
	 */
	public long ServiceStatusTypeId {
		get {
			return this.serviceStatusTypeId;
		}
	}
	
	/**
	 * Gets serviceTypeId.
	 */
	public long ServiceTypeId {
		get {
			return this.serviceTypeId;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiService(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "billdate":
				if (jso[key].ToString() != "")
					this.billDate = Convert.ToDateTime(jso[key]);
				break;
			case "billingcycleid":
				this.billingCycleId = Convert.ToInt64(jso[key]);
				break;
			case "datecreated":
				if (jso[key].ToString() != "")
					this.dateCreated = Convert.ToDateTime(jso[key]);
				break;
			case "description":
				this.description = Convert.ToString(jso[key]);
				break;
			case "iscreditbased":
				this.isCreditBased = Convert.ToBoolean(jso[key]);
				break;
			case "isprepaid":
				this.isPrepaid = Convert.ToBoolean(jso[key]);
				break;
			case "rate":
				this.rate = Convert.ToDouble(jso[key]);
				break;
			case "serviceid":
				this.serviceId = Convert.ToInt64(jso[key]);
				break;
			case "servicestatustypeid":
				this.serviceStatusTypeId = Convert.ToInt64(jso[key]);
				break;
			case "servicetypeid":
				this.serviceTypeId = Convert.ToInt64(jso[key]);
				break;
		}
	}
}
}
