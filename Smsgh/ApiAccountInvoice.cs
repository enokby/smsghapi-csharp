// $Id$
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiAccountInvoice
{
	/**
	 * Data fields.
	 */
	private double amount;
	private DateTime created;
	private string description;
	private DateTime dueDate;
	private double ending;
	private int id;
	private bool isPaid;
	private string type;
	
	/**
	 * Gets amount.
	 */
	public double Amount {
		get {
			return this.amount;
		}
	}
	
	/**
	 * Gets created.
	 */
	public DateTime Created {
		get {
			return this.created;
		}
	}
	
	/**
	 * Gets description.
	 */
	public string Description {
		get {
			return this.description;
		}
	}
	
	/**
	 * Gets dueDate.
	 */
	public DateTime DueDate {
		get {
			return this.dueDate;
		}
	}
	
	/**
	 * Gets ending.
	 */
	public double Ending {
		get {
			return this.ending;
		}
	}
	
	/**
	 * Gets id.
	 */
	public int Id {
		get {
			return this.id;
		}
	}
	
	/**
	 * Gets isPaid.
	 */
	public bool IsPaid {
		get {
			return this.isPaid;
		}
	}
	
	/**
	 * Gets type.
	 */
	public string Type {
		get {
			return this.type;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiAccountInvoice(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "amount":
				this.amount = Convert.ToDouble(jso[key]);
				break;
			case "created":
				this.created = Convert.ToDateTime(jso[key]);
				break;
			case "description":
				this.description = Convert.ToString(jso[key]);
				break;
			case "duedate":
				this.dueDate = Convert.ToDateTime(jso[key]);
				break;
			case "ending":
				this.ending = Convert.ToDouble(jso[key]);
				break;
			case "id":
				this.id = Convert.ToInt32(jso[key]);
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
