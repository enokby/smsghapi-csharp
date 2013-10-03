// $Id: ApiNumberPlanItem.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiNumberPlanItem
{
	/**
	 * Data fields.
	 */
	private long   id;
	private string network;
	private double payout;
	private double reversePayout;
	private string shortCode;
	
	/**
	 * Gets id.
	 */
	public long Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets network.
	 */
	public string Network {
		get {
			return this.network;
		}
	}
	
	/**
	 * Gets payout.
	 */
	public double Payout {
		get {
			return this.payout;
		}
	}
	
	/**
	 * Gets reversePayout.
	 */
	public double ReversePayout {
		get {
			return this.reversePayout;
		}
	}
	
	/**
	 * Gets shortCode.
	 */
	public string ShortCode {
		get {
			return this.shortCode;
		}
	}
	
	/**
	 * Constructor from JSO.
	 */
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
