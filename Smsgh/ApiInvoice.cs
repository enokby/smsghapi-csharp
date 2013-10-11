// $Id: ApiInvoice.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API invoice.
/// </summary>
public class ApiInvoice
{
	// Data fields.
	private double amount;
	private DateTime created;
	private string description;
	private DateTime dueDate;
	private double ending;
	private long id;
	private bool isPaid;
	private string type;
	
    /// <summary>
    /// Gets the amount of this API invoice.
    /// </summary>
	public double Amount {
		get {
			return this.amount;
		}
	}
	
    /// <summary>
    /// Gets the created date of this API invoice.
    /// </summary>
	public DateTime Created {
		get {
			return this.created;
		}
	}
	
    /// <summary>
    /// Gets the description of this API invoice.
    /// </summary>
	public string Description {
		get {
			return this.description;
		}
	}
	
    /// <summary>
    /// Gets the due date of this API invoice.
    /// </summary>
	public DateTime DueDate {
		get {
			return this.dueDate;
		}
	}
	
    /// <summary>
    /// Gets the ending of this API invoice.
    /// </summary>
	public double Ending {
		get {
			return this.ending;
		}
	}
	
    /// <summary>
    /// Gets the ID of this API invoice.
    /// </summary>
	public long Id {
		get {
			return this.id;
		}
	}
	
    /// <summary>
    /// Indicates whether this API invoice is paid.
    /// </summary>
	public bool IsPaid {
		get {
			return this.isPaid;
		}
	}
	
    /// <summary>
    /// Gets the type of this API invoice.
    /// </summary>
	public string Type {
		get {
			return this.type;
		}
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiInvoice(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "amount":
				this.amount = Convert.ToDouble(jso[key]);
				break;
			case "created":
				if (jso[key].ToString() != "")
					this.created = Convert.ToDateTime(jso[key]);
				break;
			case "description":
				this.description = Convert.ToString(jso[key]);
				break;
			case "duedate":
				if (jso[key].ToString() != "")
					this.dueDate = Convert.ToDateTime(jso[key]);
				break;
			case "ending":
				this.ending = Convert.ToDouble(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt64(jso[key]);
				break;
			case "ispaid":
				this.isPaid = Convert.ToBoolean(jso[key]);
				break;
			case "type":
				this.type = Convert.ToString(jso[key]);
				break;
		}
	}
}
}
