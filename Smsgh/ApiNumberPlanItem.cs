// $Id: ApiNumberPlanItem.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;

namespace SmsghApi.Sdk.Smsgh
{
    /// <summary>
/// Represents an API number plan item.
/// </summary>
public class ApiNumberPlanItem
{
	// Data fields.
	private readonly long   _id;
	private readonly string _network;
	private readonly double _payout;
	private readonly double _reversePayout;
	private readonly string _shortCode;
	
    /// <summary>
    /// Gets the ID of this API number plan item.
    /// </summary>
	public long Id {
		get {
			return this._id;
		}
	}
	
    /// <summary>
    /// Gets the network of this API number plan item.
    /// </summary>
	public string Network {
		get {
			return this._network;
		}
	}
	
    /// <summary>
    /// Gets the payout of this API number plan item.
    /// </summary>
	public double Payout {
		get {
			return this._payout;
		}
	}
	
    /// <summary>
    /// Gets the reverse payout of this API number plan item.
    /// </summary>
	public double ReversePayout {
		get {
			return this._reversePayout;
		}
	}
	
    /// <summary>
    /// Gets the short code of this API number plan item.
    /// </summary>
	public string ShortCode {
		get {
			return this._shortCode;
		}
	}
	
    /// <summary>
    /// Used internally to initialize this API number plan item.
    /// </summary>
	public ApiNumberPlanItem(ApiDictionary jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "id":
				this._id = Convert.ToInt64(jso[key]);
				break;
			case "network":
				this._network = Convert.ToString(jso[key]);
				break;
			case "payout":
				this._payout = Convert.ToDouble(jso[key]);
				break;
			case "reversepayout":
				this._reversePayout = Convert.ToDouble(jso[key]);
				break;
			case "shortcode":
				this._shortCode = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
