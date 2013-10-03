// $Id$
namespace Smsgh
{

using System;
using Smsgh.Json;

public class ApiAccountSettings
{
	/**
	 * Data fields.
	 */
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
	 * Gets or sets countryCode.
	 */
	public string CountryCode {
		get {
			return this.countryCode;
		}
		set {
			this.countryCode = value;
		}
	}
	
	/**
	 * Gets or sets deliveryReportNotificationUrl.
	 */
	public string DeliveryReportNotificationUrl {
		get {
			return this.deliveryReportNotificationUrl;
		}
		set {
			this.deliveryReportNotificationUrl = value;
		}
	}
	
	/**
	 * Gets or sets emailDailySummary.
	 */
	public bool EmailDailySummary {
		get {
			return this.emailDailySummary;
		}
		set {
			this.emailDailySummary = value;
		}
	}
	
	/**
	 * Gets emailInvoiceReminders.
	 */
	public bool EmailInvoiceReminders {
		get {
			return this.emailInvoiceReminders;
		}
		set {
			this.emailInvoiceReminders = value;
		}
	}
	
	/**
	 * Gets emailMaintenance.
	 */
	public bool EmailMaintenance {
		get {
			return this.emailMaintenance;
		}
		set {
			this.emailMaintenance = value;
		}
	}
	
	/**
	 * Gets emailNewInvoice.
	 */
	public bool EmailNewInvoice {
		get {
			return this.emailNewInvoice;
		}
		set {
			this.emailNewInvoice = value;
		}
	}
	
	/**
	 * Gets smsFortnightBalance.
	 */
	public bool SmsFortnightBalance {
		get {
			return this.smsFortnightBalance;
		}
		set {
			this.smsFortnightBalance = value;
		}
	}
	
	/**
	 * Gets smsLowBalanceNotification.
	 */
	public bool SmsLowBalanceNotification {
		get {
			return this.smsLowBalanceNotification;
		}
		set {
			this.smsLowBalanceNotification = value;
		}
	}
	
	/**
	 * Gets smsMaintenance.
	 */
	public bool SmsMaintenance {
		get {
			return this.smsMaintenance;
		}
		set {
			this.smsMaintenance = value;
		}
	}
	
	/**
	 * Gets smsPromotionalMessages.
	 */
	public bool SmsPromotionalMessages {
		get {
			return this.smsPromotionalMessages;
		}
		set {
			this.smsPromotionalMessages = value;
		}
	}
	
	/**
	 * Gets smsTopUpNotification.
	 */
	public bool SmsTopUpNotification {
		get {
			return this.smsTopUpNotification;
		}
		set {
			this.smsTopUpNotification = value;
		}
	}
	
	/**
	 * Gets timeZone.
	 */
	public string TimeZone {
		get {
			return this.timeZone;
		}
		set {
			this.timeZone = value;
		}
	}
	
	/**
	 * Primary constructor.
	 */
	public ApiAccountSettings(JavaScriptObject jso)
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