// $Id: ApiService.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API service.
/// </summary>
public class ApiService
{
	// Data fields.
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
	
    /// <summary>
    /// Gets the account ID of this API service.
    /// </summary>
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the bill date of this API service.
    /// </summary>
	public DateTime BillDate {
		get {
			return this.billDate;
		}
	}
	
    /// <summary>
    /// Gets the billing cycle ID of this API service.
    /// </summary>
	public long BillingCycleId {
		get {
			return this.billingCycleId;
		}
	}
	
    /// <summary>
    /// Gets the created date of this API service.
    /// </summary>
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
	}
	
    /// <summary>
    /// Gets the description of this API service.
    /// </summary>
	public string Description {
		get {
			return this.description;
		}
	}
	
    /// <summary>
    /// Indicates whether this API service is credit based.
    /// </summary>
	public bool IsCreditBased {
		get {
			return this.isCreditBased;
		}
	}
	
    /// <summary>
    /// Indicated whether this API service is prepaid.
    /// </summary>
	public bool IsPrepaid {
		get {
			return this.isPrepaid;
		}
	}
	
    /// <summary>
    /// Gets the rate of this API service.
    /// </summary>
	public double Rate {
		get {
			return this.rate;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API service.
    /// </summary>
	public long ServiceId {
		get {
			return this.serviceId;
		}
	}
	
    /// <summary>
    /// Gets the status type ID of this API service.
    /// </summary>
	public long ServiceStatusTypeId {
		get {
			return this.serviceStatusTypeId;
		}
	}
	
    /// <summary>
    /// Gets the type ID of this API service.
    /// </summary>
	public long ServiceTypeId {
		get {
			return this.serviceTypeId;
		}
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
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
