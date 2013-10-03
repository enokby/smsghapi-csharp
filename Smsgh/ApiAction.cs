// $Id: ApiAction.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiAction
{
	/**
	 * Data fields.
	 */
	private string actionMeta;
	private long   actionTypeId;
	private long   campaignId;
	private long   id;
	private bool   isActive;
	
	/**
	 * Gets actionMeta.
	 */
	public string ActionMeta {
		get {
			return this.actionMeta;
		}
	}
	
	/**
	 * Gets actionTypeId.
	 */
	public long ActionTypeId {
		get {
			return this.actionTypeId;
		}
	}
	
	/**
	 * Gets campaignId.
	 */
	public long CampaignId {
		get {
			return this.campaignId;
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
	 * Gets isActive.
	 */
	public bool IsActive {
		get {
			return this.isActive;
		}
	}
	
	/**
	 * Constructor from JSO.
	 */
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
