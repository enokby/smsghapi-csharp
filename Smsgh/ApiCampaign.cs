// $Id: ApiCampaign.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

public class ApiCampaign
{
	/**
	 * Data fields.
	 */
	private string             accountId;
	private List<ApiAction>    actions;
	private string             brief;
	private long               campaignId;
	private DateTime           dateCreated;
	private DateTime           dateEnded;
	private string             description;
	private bool               enabled;
	private bool               isDefault;
	private List<ApiMoKeyword> moKeywords;
	private bool               pendingApproval;
	
	/**
	 * Gets accountId.
	 */
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Gets actions.
	 */
	[JsonIgnoreAttribute]
	public List<ApiAction> Actions {
		get {
			return this.actions;
		}
	}
	
	/**
	 * Gets or sets brief.
	 */
	public string Brief {
		get {
			return this.brief;
		}
		set {
			this.brief = value;
		}
	}
	
	/**
	 * Gets campaignId.
	 */
	[JsonIgnoreAttribute]
	public long CampaignId {
		get {
			return this.campaignId;
		}
	}
	
	/**
	 * Gets or sets dateCreated.
	 */
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
		set {
			this.dateCreated = value;
		}
	}
	
	/**
	 * Gets or sets dateEnded
	 */
	public DateTime DateEnded {
		get {
			return this.dateEnded;
		}
		set {
			this.dateEnded = value;
		}
	}
	
	/**
	 * Gets or sets description.
	 */
	public string Description {
		get {
			return this.description;
		}
		set {
			this.description = value;
		}
	}
	
	/**
	 * Gets enabled.
	 */
	[JsonIgnoreAttribute]
	public bool Enabled {
		get {
			return this.enabled;
		}
	}
	
	/**
	 * Gets isDefault.
	 */
	[JsonIgnoreAttribute]
	public bool IsDefault {
		get {
			return this.isDefault;
		}
	}
	
	/**
	 * Gets moKeywords.
	 */
	[JsonIgnoreAttribute]
	public List<ApiMoKeyword> MoKeywords {
		get {
			return this.moKeywords;
		}
	}
	
	/**
	 * Gets pendingApproval.
	 */
	[JsonIgnoreAttribute]
	public bool PendingApproval {
		get {
			return this.pendingApproval;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiCampaign()
	{
	}
	
	/**
	 * Constructor from JSO.
	 */
	public ApiCampaign(JavaScriptObject jso)
	{
		this.actions = new List<ApiAction>();
		this.moKeywords = new List<ApiMoKeyword>();
		
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "actions":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.actions.Add(new ApiAction(o));
				break;
			case "brief":
				this.brief = Convert.ToString(jso[key]);
				break;
			case "campaignid":
				this.campaignId = Convert.ToInt64(jso[key]);
				break;
			case "datecreated":
				this.dateCreated = Convert.ToDateTime(jso[key]);
				break;
			case "dateended":
				this.dateEnded = Convert.ToDateTime(jso[key]);
				break;
			case "description":
				this.description = Convert.ToString(jso[key]);
				break;
			case "enabled":
				this.enabled = Convert.ToBoolean(jso[key]);
				break;
			case "isdefault":
				this.isDefault = Convert.ToBoolean(jso[key]);
				break;
			case "mokeywords":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.moKeywords.Add(new ApiMoKeyword(o));
				break;
			case "pendingapproval":
				this.pendingApproval = Convert.ToBoolean(jso[key]);
				break;
		}
	}
}
}
