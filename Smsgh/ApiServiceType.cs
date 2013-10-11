// $Id: ApiServiceType.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API service type.
/// </summary>
public class ApiServiceType
{
	// Data fields.
	private string descriptor;
	private bool   isCreditBased;
	private bool   isPrepaid;
	private string name;
	private double rate;
	private bool   requiresActivation;
	
    /// <summary>
    /// Gets the descriptor of this API service type.
    /// </summary>
	public string Descriptor {
		get {
			return this.descriptor;
		}
	}
	
    /// <summary>
    /// Indicated whether this API service type is credit based.
    /// </summary>
	public bool IsCreditBased {
		get {
			return this.isCreditBased;
		}
	}
	
    /// <summary>
    /// Indicated whether this API service type is prepaid.
    /// </summary>
	public bool IsPrepaid {
		get {
			return this.isPrepaid;
		}
	}
	
    /// <summary>
    /// Gets the name of this API service type.
    /// </summary>
	public string Name {
		get {
			return this.name;
		}
	}
	
    /// <summary>
    /// Gets the rate of this API service type.
    /// </summary>
	public double Rate {
		get {
			return this.rate;
		}
	}
	
    /// <summary>
    /// Indicated whether this API service type requires activation.
    /// </summary>
	public bool RequiresActivation {
		get {
			return this.requiresActivation;
		}
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiServiceType(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "descriptor":
				this.descriptor = Convert.ToString(jso[key]);
				break;
			case "iscreditbased":
				this.isCreditBased = Convert.ToBoolean(jso[key]);
				break;
			case "isprepaid":
				this.isPrepaid = Convert.ToBoolean(jso[key]);
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
