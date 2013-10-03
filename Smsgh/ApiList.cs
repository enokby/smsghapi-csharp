// $Id: ApiList.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.Collections.Generic;
using Smsgh.Json;

public class ApiList<T>
{
	/**
	 * Data fields.
	 */
	private int count;
	private int totalPages;
	private List<T> items;
	
	/**
	 * Gets or sets count.
	 */
	public int Count {
		get {
			return this.count;
		}
		set {
			this.count = value;
		}
	}
	
	/**
	 * Gets or sets totalPages.
	 */
	public int TotalPages {
		get {
			return this.totalPages;
		}
		set {
			this.totalPages = value;
		}
	}
	
	/**
	 * Gets items.
	 */
	public List<T> Items {
		get {
			return this.items;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiList(JavaScriptObject jso)
	{
		this.items = new List<T>();
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "count":
				this.count = Convert.ToInt32(jso[key]);
				break;
			case "totalpages":
				this.totalPages = Convert.ToInt32(jso[key]);
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
						(new ApiAccountInvoice(o), typeof(T)));
				break;
				
			case "mokeywordlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiMoKeyword(o), typeof(T)));
				break;
				
			case "numberplanlist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiNumberPlan(o), typeof(T)));
				break;
				
			case "servicelist":
				foreach (JavaScriptObject o in jso[key] as JavaScriptArray)
					this.items.Add((T) Convert.ChangeType
						(new ApiAccountService(o), typeof(T)));
				break;
		}
	}
	
	/**
	 * GetEnumerator.
	 */
	public List<T>.Enumerator GetEnumerator()
	{
		return this.items.GetEnumerator();
	}
}
}
