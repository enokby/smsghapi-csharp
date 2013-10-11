// $Id: ApiTemplate.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API message template.
/// </summary>
public class ApiTemplate
{
	// Data fields.
	private string   accountId;
	private DateTime dateCreated;
	private long     id;
	private string   name;
	private string   text;
	
    /// <summary>
    /// Gets the account ID of this API message template.
    /// </summary>
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets the created date of this API message template.
    /// </summary>
	[JsonIgnoreAttribute]
	public DateTime DateCreated {
		get {
			return this.dateCreated;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API message template.
    /// </summary>
	[JsonIgnoreAttribute]
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Gets or sets the name of this API message template.
    /// </summary>
	public string Name {
		get {
			return this.name;
		}
		set {
			this.name = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the text of this API message template.
    /// </summary>
	public string Text {
		get {
			return this.text;
		}
		set {
			this.text = value;
		}
	}
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiTemplate"/> class.
    /// </summary>
	public ApiTemplate()
	{
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
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
