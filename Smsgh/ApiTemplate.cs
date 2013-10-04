// $Id: ApiTemplate.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiTemplate
{
	/**
	 * Data fields.
	 */
	private string   accountId;
	private DateTime dateCreated;
	private long     id;
	private string   name;
	private string   text;
	
	/**
	 * Gets accountId.
	 */
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
	/**
	 * Gets dateCreated.
	 */
	[JsonIgnoreAttribute]
	public DateTime DateCreated {
		get {
			return this.dateCreated;
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
	 * Gets or sets name.
	 */
	public string Name {
		get {
			return this.name;
		}
		set {
			this.name = value;
		}
	}
	
	/**
	 * Gets or sets text.
	 */
	public string Text {
		get {
			return this.text;
		}
		set {
			this.text = value;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiTemplate()
	{
	}
	
	/**
	 * Constructor from JSO.
	 */
	public ApiTemplate(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "datecreated":
				if (jso[key].ToString() != "")
					this.dateCreated = Convert.ToDateTime(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "name":
				this.name = Convert.ToString(jso[key]);
				break;
			case "text":
				this.text = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
