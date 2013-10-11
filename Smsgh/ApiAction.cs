// $Id: ApiAction.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API action.
/// </summary>
public class ApiAction
{
	// Data fields.
	private string actionMeta;
	private long   actionTypeId;
	private long   campaignId;
	private long   id;
	private bool   isActive;
	
    /// <summary>
    /// Gets the action meta of this API action.
    /// </summary>
	public string ActionMeta {
		get {
			return this.actionMeta;
		}
	}
	
    /// <summary>
    /// Gets the action type ID of this API action.
    /// </summary>
	public long ActionTypeId {
		get {
			return this.actionTypeId;
		}
	}
	
    /// <summary>
    /// Gets the campaign ID of this API action.
    /// </summary>
	public long CampaignId {
		get {
			return this.campaignId;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API action.
    /// </summary>
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Indicates whether this API action is active.
    /// </summary>
	public bool IsActive {
		get {
			return this.isActive;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiAction"/> class.
    /// </summary>
	public ApiAction(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "actionmeta":
				this.actionMeta = Convert.ToString(jso[key]);
				break;
			case "actiontypeid":
				this.actionTypeId = Convert.ToInt64(jso[key]);
				break;
			case "campaignid":
				this.campaignId = Convert.ToInt64(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "isactive":
				this.isActive = Convert.ToBoolean(jso[key]);
				break;
		}
	}
}
}
