// $Id: ApiMoKeyWord.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiMoKeyWord
{
	/**
	 * Data fields.
	 */
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
	
	/**
	 * Gets or sets alias1.
	 */
	public string Alias1 {
		get {
			return this.alias1;
		}
		set {
			this.alias1 = value;
		}
	}
	
	/**
	 * Gets or sets alias2.
	 */
	public string Alias2 {
		get {
			return this.alias2;
		}
		set {
			this.alias2 = value;
		}
	}
	
	/**
	 * Gets or sets alias3.
	 */
	public string Alias3 {
		get {
			return this.alias3;
		}
		set {
			this.alias3 = value;
		}
	}
	
	/**
	 * Gets or sets alias4.
	 */
	public string Alias4 {
		get {
			return this.alias4;
		}
		set {
			this.alias4 = value;
		}
	}
	
	/**
	 * Gets or sets alias5.
	 */
	public string Alias5 {
		get {
			return this.alias5;
		}
		set {
			this.alias5 = value;
		}
	}
	
	/**
	 * Gets id.
	 */
	[JsonIgnoreAttribute]
	public long Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets or sets isActive.
	 */
	public bool IsActive {
		get {
			return this.isActive;
		}
		set {
			this.isActive = value;
		}
	}
	
	/**
	 * Gets or sets isDefault.
	 */
	public bool IsDefault {
		get {
			return this.isDefault;
		}
		set {
			this.isActive = value;
		}
	}
	
	/**
	 * Gets or sets keyword.
	 */
	public string Keyword {
		get {
			return this.keyword;
		}
		set {
			this.keyword = value;
		}
	}
	
	/**
	 * Gets or sets numberPlanId.
	 */
	public long NumberPlanId {
		get {
			return this.numberPlanId;
		}
		set {
			this.numberPlanId = value;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiMoKeyWord()
	{
	}
	
	/**
	 * Constructor from JSO.
	 */
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
