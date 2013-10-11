// $Id: ApiMoKeyWord.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API MO keyword.
/// </summary>
public class ApiMoKeyWord
{
	// Data fields.
	private string alias1;
	private string alias2;
	private string alias3;
	private string alias4;
	private string alias5;
	private long   id;
	private bool   isActive;
	private bool   isDefault;
	private string keyword;
	private long   numberPlanId;
	
    /// <summary>
    /// Gets or sets the alias 1 of this API MO keyword.
    /// </summary>
	public string Alias1 {
		get {
			return this.alias1;
		}
		set {
			this.alias1 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the alias 2 of this API MO keyword.
    /// </summary>
	public string Alias2 {
		get {
			return this.alias2;
		}
		set {
			this.alias2 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the alias 3 of this API MO keyword.
    /// </summary>
	public string Alias3 {
		get {
			return this.alias3;
		}
		set {
			this.alias3 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the alias 4 of this API MO keyword.
    /// </summary>
	public string Alias4 {
		get {
			return this.alias4;
		}
		set {
			this.alias4 = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the alias 5 of this API MO keyword.
    /// </summary>
	public string Alias5 {
		get {
			return this.alias5;
		}
		set {
			this.alias5 = value;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API MO keyword.
    /// </summary>
	[JsonIgnoreAttribute]
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Gets or sets a value indicating whether this API MO keyword is active.
    /// </summary>
	public bool IsActive {
		get {
			return this.isActive;
		}
		set {
			this.isActive = value;
		}
	}
	
    /// <summary>
    /// Gets or sets a value indicating whether this API MO keyword is default.
    /// </summary>
	public bool IsDefault {
		get {
			return this.isDefault;
		}
		set {
			this.isActive = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the keyword of this API MO keyword.
    /// </summary>
	public string Keyword {
		get {
			return this.keyword;
		}
		set {
			this.keyword = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the number plan ID of this API MO keyword.
    /// </summary>
	public long NumberPlanId {
		get {
			return this.numberPlanId;
		}
		set {
			this.numberPlanId = value;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of this API MO keyword class.
    /// </summary>
	public ApiMoKeyWord()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiMoKeyWord(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "alias1":
				this.alias1 = Convert.ToString(jso[key]);
				break;
			case "alias2":
				this.alias2 = Convert.ToString(jso[key]);
				break;
			case "alias3":
				this.alias3 = Convert.ToString(jso[key]);
				break;
			case "alias4":
				this.alias4 = Convert.ToString(jso[key]);
				break;
			case "alias5":
				this.alias5 = Convert.ToString(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "isactive":
				this.isActive = Convert.ToBoolean(jso[key]);
				break;
			case "isdefault":
				this.isDefault = Convert.ToBoolean(jso[key]);
				break;
			case "keyword":
				this.keyword = Convert.ToString(jso[key]);
				break;
			case "numberplanid":
				this.numberPlanId = Convert.ToInt64(jso[key]);
				break;
		}
	}
}
}
