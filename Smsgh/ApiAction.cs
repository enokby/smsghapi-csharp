// $Id: ApiAction.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
/// Represents an API action.
/// </summary>
public class ApiAction
{
	// Data fields.
	private readonly string _actionMeta;
	private readonly long   _actionTypeId;
	private readonly long   _campaignId;
	private readonly long   _id;
	private readonly bool   _isActive;
	
    /// <summary>
    /// Gets the action meta of this API action.
    /// </summary>
	public string ActionMeta {
		get {
			return this._actionMeta;
		}
	}
	
    /// <summary>
    /// Gets the action type ID of this API action.
    /// </summary>
	public long ActionTypeId {
		get {
			return this._actionTypeId;
		}
	}
	
    /// <summary>
    /// Gets the campaign ID of this API action.
    /// </summary>
	public long CampaignId {
		get {
			return this._campaignId;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API action.
    /// </summary>
	public long Id {
		get {
			return this._id;
		}
	}
	
    /// <summary>
    /// Indicates whether this API action is active.
    /// </summary>
	public bool IsActive {
		get {
			return this._isActive;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiAction"/> class.
    /// </summary>
	public ApiAction(ApiDictionary jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "actionmeta":
				this._actionMeta = Convert.ToString(jso[key]);
				break;
			case "actiontypeid":
				this._actionTypeId = Convert.ToInt64(jso[key]);
				break;
			case "campaignid":
				this._campaignId = Convert.ToInt64(jso[key]);
				break;
			case "id":
				this._id = Convert.ToInt64(jso[key]);
				break;
			case "isactive":
				this._isActive = Convert.ToBoolean(jso[key]);
				break;
		}
	}
}
}
