// $Id: ApiNumberPlan.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

public class ApiNumberPlan
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Gets accountId.
	 */
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Gets dateActivated.
	 */
	public DateTime DateActivated {
		get {
			return this.dateActivated;
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
	 * Gets dateDeactivated.
	 */
	public DateTime? DateDeactivated {
		get {
			return this.dateDeactivated;
		}
	}
	
	/**
	 * Gets dateExpiring.
	 */
	public DateTime DateExpiring {
		get {
			return this.dateExpiring;
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
	 * Gets id.
	 */
	public long Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets initialCost.
	 */
	public double InitialCost {
		get {
			return this.initialCost;
		}
	}
	
	/**
	 * Gets isActive.
	 */
	public bool IsActive {
		get {
			return this.isActive;
		}
	}
	
	/**
	 * Gets isPremium.
	 */
	public bool IsPremium {
		get {
			return this.isPremium;
		}
	}
	
	/**
	 * Gets maxAllowedKeywords.
	 */
	public int MaxAllowedKeywords {
		get {
			return this.maxAllowedKeywords;
		}
	}
	
	/**
	 * Gets moKeywords.
	 */
	public List<ApiMoKeyWord> MoKeywords {
		get {
			return this.moKeywords;
		}
	}
	
	/**
	 * Gets notes.
	 */
	public string Notes {
		get {
			return this.notes;
		}
	}
	
	/**
	 * Gets numberPlanItems.
	 */
	public List<ApiNumberPlanItem> NumberPlanItems
	{
		get {
			return this.numberPlanItems;
		}
	}
	
	/**
	 * Gets periodicCostBasis.
	 */
	public double PeriodicCostBasis {
		get {
			return this.periodicCostBasis;
		}
	}
	
	/**
	 * Gets serviceType.
	 */
	public ApiServiceType ServiceType {
		get {
			return this.serviceType;
		}
	}
	
	/**
	 * Constructor from JSO.
	 */
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
