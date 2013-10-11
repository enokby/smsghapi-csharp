// $Id: ApiList.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

/// <summary>
/// Represents an API list.
/// </summary>
public class ApiList<T>
{
	// Data fields.
	private long count;
	private long totalPages;
	private List<T> items;
	
    /// <summary>
    /// Gets the count of this API list.
    /// </summary>
	public long Count {
		get {
			return this.count;
		}
	}
	
    /// <summary>
    /// Gets the total pages of this API list.
    /// </summary>
	public long TotalPages {
		get {
			return this.totalPages;
		}
	}
	
    /// <summary>
    /// Gets the items in this API list.
    /// </summary>
	public List<T> Items {
		get {
			return this.items;
		}
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiList(JavaScriptObject jso)
	{
		this.items = new List<T>();
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "count":
				this.count = Convert.ToInt64(jso[key]);
				break;
			case "totalpages":
				this.totalPages = Convert.ToInt64(jso[key]);
				break;
				
			case "actionlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiAction(o), typeof(T)));
				break;
				
			case "campaignlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiCampaign(o), typeof(T)));
				break;
				
			case "childaccountlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiChildAccount(o), typeof(T)));
				break;
				
			case "contactlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiContact(o), typeof(T)));
				break;
				
			case "grouplist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiContactGroup(o), typeof(T)));
				break;
				
			case "invoicestatementlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiInvoice(o), typeof(T)));
				break;
				
			case "messages":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiMessage(o), typeof(T)));
				break;
				
			case "messagetemplatelist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiTemplate(o), typeof(T)));
				break;
				
			case "mokeywordlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiMoKeyWord(o), typeof(T)));
				break;
				
			case "numberplanlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiNumberPlan(o), typeof(T)));
				break;
				
			case "senderaddresseslist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiSender(o), typeof(T)));
				break;
				
			case "servicelist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiService(o), typeof(T)));
				break;
		}
	}
	
    /// <summary>
    /// Returns the enumerator of this API list.
    /// </summary>
	public List<T>.Enumerator GetEnumerator()
	{
		return this.items.GetEnumerator();
	}
}
}
