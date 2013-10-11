// $Id: ApiNumberPlan.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

/// <summary>
/// Represents an API number plan.
/// </summary>
public class ApiNumberPlan
{
	// Data fields.
	private string                  accountId;
	private DateTime                dateActivated;
	private DateTime                dateCreated;
	private DateTime?               dateDeactivated;
	private DateTime                dateExpiring;
	private string                  description;
	private long                    id;
	private double                  initialCost;
	private bool                    isActive;
	private bool                    isPremium;
	private int                     maxAllowedKeywords;
	private List<ApiMoKeyWord>      moKeywords;
	private string                  notes;
	private List<ApiNumberPlanItem> numberPlanItems;
	private double                  periodicCostBasis;
	private ApiServiceType          serviceType;
	
    /// <summary>
    /// Gets the account ID of this API number plan.
    /// </summary>
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the activated date of this API number plan.
    /// </summary>
	public DateTime DateActivated {
		get {
			return this.dateActivated;
		}
	}
	
    /// <summary>
    /// Gets the created date of this API number plan.
    /// </summary>
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
	}
	
    /// <summary>
    /// Gets the deactivated date of this API number plan.
    /// </summary>
	public DateTime? DateDeactivated {
		get {
			return this.dateDeactivated;
		}
	}
	
    /// <summary>
    /// Gets the expiring date of this API number plan.
    /// </summary>
	public DateTime DateExpiring {
		get {
			return this.dateExpiring;
		}
	}
	
    /// <summary>
    /// Gets the description of this API number plan.
    /// </summary>
	public string Description {
		get {
			return this.description;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API number plan.
    /// </summary>
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Gets the initial cost of this API number plan.
    /// </summary>
	public double InitialCost {
		get {
			return this.initialCost;
		}
	}
	
    /// <summary>
    /// Indicated whether this API number plan is active.
    /// </summary>
	public bool IsActive {
		get {
			return this.isActive;
		}
	}
	
    /// <summary>
    /// Indicates whether this API number plan is a premium.
    /// </summary>
	public bool IsPremium {
		get {
			return this.isPremium;
		}
	}
	
    /// <summary>
    /// Gets the maximum allowed keywords on this API number plan.
    /// </summary> 
	public int MaxAllowedKeywords {
		get {
			return this.maxAllowedKeywords;
		}
	}
	
    /// <summary>
    /// Gets the API MO keywords this API number plan.
    /// </summary>
	public List<ApiMoKeyWord> MoKeywords {
		get {
			return this.moKeywords;
		}
	}
	
    /// <summary>
    /// Gets the notes of this API number plan.
    /// </summary>
	public string Notes {
		get {
			return this.notes;
		}
	}
	
    /// <summary>
    /// Gets the API number plan items of this API number plan.
    /// </summary>
	public List<ApiNumberPlanItem> NumberPlanItems
	{
		get {
			return this.numberPlanItems;
		}
	}
	
    /// <summary>
    /// Gets the periodic cost basis of this API number plan.
    /// </summary>
	public double PeriodicCostBasis {
		get {
			return this.periodicCostBasis;
		}
	}
	
    /// <summary>
    /// Gets the API service type of this API number plan.
    /// </summary>
	public ApiServiceType ServiceType {
		get {
			return this.serviceType;
		}
	}
	
    /// <summary>
    /// Used internally to initialize a new instance of this class.
    /// </summary>
	public ApiNumberPlan(JavaScriptObject jso)
	{
		this.moKeywords = new List<ApiMoKeyWord>();
		this.numberPlanItems = new List<ApiNumberPlanItem>();
		
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "dateactivated":
				if (jso[key].ToString() != "")
					this.dateActivated = Convert.ToDateTime(jso[key]);
				break;
			case "datecreated":
				if (jso[key].ToString() != "")
					this.dateCreated = Convert.ToDateTime(jso[key]);
				break;
			case "datedeactivated":
				if (jso[key].ToString() != "")
					this.dateDeactivated = Convert.ToDateTime(jso[key]);
				break;
			case "dateexpiring":
				if (jso[key].ToString() != "")
					this.dateExpiring = Convert.ToDateTime(jso[key]);
				break;
			case "description":
				this.description = Convert.ToString(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "initialcost":
				this.initialCost = Convert.ToDouble(jso[key]);
				break;
			case "isactive":
				this.isActive = Convert.ToBoolean(jso[key]);
				break;
			case "ispremium":
				this.isPremium = Convert.ToBoolean(jso[key]);
				break;
			case "maxallowedkeywords":
				this.maxAllowedKeywords = Convert.ToInt32(jso[key]);
				break;
			case "mokeywords":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.moKeywords.Add(new ApiMoKeyWord(o));
				break;
			case "notes":
				this.notes = Convert.ToString(jso[key]);
				break;
			case "numberplanitems":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.numberPlanItems.Add(new ApiNumberPlanItem(o));
				break;
			case "periodiccostbasis":
				this.periodicCostBasis = Convert.ToDouble(jso[key]);
				break;
			case "servicetype":
				this.serviceType = new ApiServiceType(jso[key] as JavaScriptObject);
				break;
		}
	}
}
}
