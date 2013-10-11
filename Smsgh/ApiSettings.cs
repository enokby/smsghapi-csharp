// $Id: ApiSettings.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using Smsgh.Json;

/// <summary>
/// Represents an API settings.
/// </summary>
public class ApiSettings
{
	// Data fields.
	private string accountId;
	private string countryCode;
	private string deliveryReportNotificationUrl;
	private bool   emailDailySummary;
	private bool   emailInvoiceReminders;
	private bool   emailMaintenance;
	private bool   emailNewInvoice;
	private bool   smsFortnightBalance;
	private bool   smsLowBalanceNotification;
	private bool   smsMaintenance;
	private bool   smsPromotionalMessages;
	private bool   smsTopUpNotification;
	private string timeZone;
	
    /// <summary>
    /// Gets the account ID of this API settings.
    /// </summary>
	[JsonIgnoreAttribute]
	public string AccountId {
		get {
			return this.accountId;
		}
	}
	
    /// <summary>
    /// Gets or sets the country code of this API settings.
    /// </summary>
	public string CountryCode {
		get {
			return this.countryCode;
		}
		set {
			this.countryCode = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the delivery report notification URL of this API settings.
    /// </summary>
	public string DeliveryReportNotificationUrl {
		get {
			return this.deliveryReportNotificationUrl;
		}
		set {
			this.deliveryReportNotificationUrl = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the email daily summary of this API settings.
    /// </summary>
	public bool EmailDailySummary {
		get {
			return this.emailDailySummary;
		}
		set {
			this.emailDailySummary = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the email invoice reminders of this API settings.
    /// </summary>
	public bool EmailInvoiceReminders {
		get {
			return this.emailInvoiceReminders;
		}
		set {
			this.emailInvoiceReminders = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the email maintenance of this API settings.
    /// </summary>
	public bool EmailMaintenance {
		get {
			return this.emailMaintenance;
		}
		set {
			this.emailMaintenance = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the email new invoice of this API settings.
    /// </summary>
	public bool EmailNewInvoice {
		get {
			return this.emailNewInvoice;
		}
		set {
			this.emailNewInvoice = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the SMS fornight balance of this API settings.
    /// </summary>
	public bool SmsFortnightBalance {
		get {
			return this.smsFortnightBalance;
		}
		set {
			this.smsFortnightBalance = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the SMS low balance notification of this API settings.
    /// </summary>
	public bool SmsLowBalanceNotification {
		get {
			return this.smsLowBalanceNotification;
		}
		set {
			this.smsLowBalanceNotification = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the SMS maintenance of this API settings.
    /// </summary>
	public bool SmsMaintenance {
		get {
			return this.smsMaintenance;
		}
		set {
			this.smsMaintenance = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the SMS promotional messages of this API settings.
    /// </summary>
	public bool SmsPromotionalMessages {
		get {
			return this.smsPromotionalMessages;
		}
		set {
			this.smsPromotionalMessages = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the SMS top-up notification of this API settings.
    /// </summary>
	public bool SmsTopUpNotification {
		get {
			return this.smsTopUpNotification;
		}
		set {
			this.smsTopUpNotification = value;
		}
	}
	
    /// <summary>
    /// Gets or sets the time zone of this API settings.
    /// </summary>
	public string TimeZone {
		get {
			return this.timeZone;
		}
		set {
			this.timeZone = value;
		}
	}
	
    /// <summary>
    /// Used internally to initialize the properties of this class.
    /// </summary>
	public ApiSettings(JavaScriptObject jso)
	{
		foreach (string key in jso.Keys)
		switch (key.ToLower()) {
			case "accountid":
				this.accountId = Convert.ToString(jso[key]);
				break;
			case "countrycode":
				this.countryCode = Convert.ToString(jso[key]);
				break;
			case "deliveryreportnotificationurl":
				this.deliveryReportNotificationUrl = Convert.ToString(jso[key]);
				break;
			case "emaildailysummary":
				this.emailDailySummary = Convert.ToBoolean(jso[key]);
				break;
			case "emailinvoicereminders":
				this.emailInvoiceReminders = Convert.ToBoolean(jso[key]);
				break;
			case "emailmaintenance":
				this.emailMaintenance = Convert.ToBoolean(jso[key]);
				break;
			case "emailnewinvoice":
				this.emailNewInvoice = Convert.ToBoolean(jso[key]);
				break;
			case "smsfortnightbalance":
				this.smsFortnightBalance = Convert.ToBoolean(jso[key]);
				break;
			case "smslowbalancenotification":
				this.smsLowBalanceNotification = Convert.ToBoolean(jso[key]);
				break;
			case "smsmaintenance":
				this.smsMaintenance = Convert.ToBoolean(jso[key]);
				break;
			case "smspromotionalmessages":
				this.smsPromotionalMessages = Convert.ToBoolean(jso[key]);
				break;
			case "smstopupnotification":
				this.smsTopUpNotification = Convert.ToBoolean(jso[key]);
				break;
			case "timezone":
				this.timeZone = Convert.ToString(jso[key]);
				break;
		}
	}
}
}