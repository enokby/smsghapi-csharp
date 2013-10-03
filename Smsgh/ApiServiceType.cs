// $Id: ApiServiceType.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiServiceType
{
	/**
	 * Data fields.
	 */
	private string descriptor;
	private bool   isPrepaid;
	private bool   isCreditBased;
	private string name;
	private double rate;
	private bool   requiresActivation;
	
	/**
	 * Gets descriptor.
	 */
	public string Descriptor {
		get {
			return this.descriptor;
		}
	}
	
	/**
	 * Gets isPrepaid.
	 */
	public bool IsPrepaid {
		get {
			return this.isPrepaid;
		}
	}
	
	/**
	 * Gets isCreditBased.
	 */
	public bool IsCreditBased {
		get {
			return this.isCreditBased;
		}
	}
	
	/**
	 * Gets name.
	 */
	public string Name {
		get {
			return this.name;
		}
	}
	
	/**
	 * Gets rate.
	 */
	public double Rate {
		get {
			return this.rate;
		}
	}
	
	/**
	 * Gets requiresActivation.
	 */
	public bool RequiresActivation {
		get {
			return this.requiresActivation;
		}
	}
	
	/**
	 * Constructor from JSO.
	 */
	public ApiServiceType(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "descriptor":
				this.descriptor = Convert.ToString(jso[key]);
				break;
			case "isprepaid":
				this.isPrepaid = Convert.ToBoolean(jso[key]);
				break;
			case "iscreditbased":
				this.isCreditBased = Convert.ToBoolean(jso[key]);
				break;
			case "name":
				this.name = Convert.ToString(jso[key]);
				break;
			case "rate":
				this.rate = Convert.ToDouble(jso[key]);
				break;
			case "requiresactivation":
				this.requiresActivation = Convert.ToBoolean(jso[key]);
				break;
		}
	}
}
}
