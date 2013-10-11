// $Id: ApiCampaign.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

/// <summary>
/// Represents an API campaign.
/// </summary>
public class ApiCampaign
{
	// Data fields.
	private string             accountId;
	private List<ApiAction>    actions;
	private string             brief;
	private long               campaignId;
	private DateTime           dateCreated;
	private DateTime           dateEnded;
	private string             description;
	private bool               enabled;
	private bool               isDefault;
	private List<ApiMoKeyWord> moKeywords;
	private bool               pendingApproval;
	
    /// <summary>
    /// Gets the account ID of this API campaign.
    /// </summary>
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the API actions of this API campaign.
    /// </summary>
	[JsonIgnoreAttribute]
	public List<ApiAction> Actions {
		get {
			return this.actions;
		}
	}
	
    /// <summary>
    /// Gets or sets the brief of this API campaign.
    /// </summary>
	public string Brief {
		get {
			return this.brief;
		}
		set {
			this.brief = value;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API campaign.
    /// </summary>
	[JsonIgnoreAttribute]
	public long CampaignId {
		get {
			return this.campaignId;
		}
	}
	
    /// <summary>
    /// Gets or sets the created date of this API campaign.
    /// </summary>
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
		set {
			this.dateCreated = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the end date of this API campaign.
    /// </summary>
	public DateTime DateEnded {
		get {
			return this.dateEnded;
		}
		set {
			this.dateEnded = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the description of this API campaign.
    /// </summary>
	public string Description {
		get {
			return this.description;
		}
		set {
			this.description = value;
		}
	}
	
    /// <summary>
    /// Indicates whether this API campaign is enabled.
    /// </summary>
	[JsonIgnoreAttribute]
	public bool Enabled {
		get {
			return this.enabled;
		}
	}
	
    /// <summary>
    /// Indicated whether this API campaign is default.
    /// </summary>
	[JsonIgnoreAttribute]
	public bool IsDefault {
		get {
			return this.isDefault;
		}
	}
	
    /// <summary>
    /// Gets the API MO keywords of this API campaign.
    /// </summary>
	[JsonIgnoreAttribute]
	public List<ApiMoKeyWord> MoKeywords {
		get {
			return this.moKeywords;
		}
	}
	
    /// <summary>
    /// Indicates whether this API campaign is pending approval.
    /// </summary>
	[JsonIgnoreAttribute]
	public bool PendingApproval {
		get {
			return this.pendingApproval;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiCampaign"/> class.
    /// </summary>
	public ApiCampaign()
	{
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiCampaign"/>
	/// from a <see cref="Smsgh.Json.JavaScriptObject"/> instance.
    /// </summary>
	public ApiCampaign(JavaScriptObject jso)
	{
		this.actions = new List<ApiAction>();
		this.moKeywords = new List<ApiMoKeyWord>();
		
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
				if (jso[key].ToString() != "")
					this.dateCreated = Convert.ToDateTime(jso[key]);
				break;
			case "dateended":
				if (jso[key].ToString() != "")
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
					this.moKeywords.Add(new ApiMoKeyWord(o));
				break;
			case "pendingapproval":
				this.pendingApproval = Convert.ToBoolean(jso[key]);
				break;
		}
	}
}
}
