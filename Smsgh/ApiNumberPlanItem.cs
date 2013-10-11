// $Id: ApiNumberPlanItem.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API number plan item.
/// </summary>
public class ApiNumberPlanItem
{
	// Data fields.
	private long   id;
	private string network;
	private double payout;
	private double reversePayout;
	private string shortCode;
	
    /// <summary>
    /// Gets the ID of this API number plan item.
    /// </summary>
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Gets the network of this API number plan item.
    /// </summary>
	public string Network {
		get {
			return this.network;
		}
	}
	
    /// <summary>
    /// Gets the payout of this API number plan item.
    /// </summary>
	public double Payout {
		get {
			return this.payout;
		}
	}
	
    /// <summary>
    /// Gets the reverse payout of this API number plan item.
    /// </summary>
	public double ReversePayout {
		get {
			return this.reversePayout;
		}
	}
	
    /// <summary>
    /// Gets the short code of this API number plan item.
    /// </summary>
	public string ShortCode {
		get {
			return this.shortCode;
		}
	}
	
    /// <summary>
    /// Used internally to initialize this API number plan item.
    /// </summary>
	public ApiNumberPlanItem(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "network":
				this.network = Convert.ToString(jso[key]);
				break;
			case "payout":
				this.payout = Convert.ToDouble(jso[key]);
				break;
			case "reversepayout":
				this.reversePayout = Convert.ToDouble(jso[key]);
				break;
			case "shortcode":
				this.shortCode = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
