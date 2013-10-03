// $Id: ApiAccountResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Smsgh.Json;

public class ApiAccountResource
{
	/**
	 * Data fields.
	 */
	private ApiHost apiHost;
	
	/**
	 * Primary constructor.
	 */
	public ApiAccountResource(ApiHost apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Gets account profile.
	 */
	public ApiAccountProfile GetProfile()
	{
		try {
			return new ApiAccountProfile(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/profile", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets primary contact.
	 */
	public ApiAccountContact GetPrimaryContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/primary_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets billing contact.
	 */
	public ApiAccountContact GetBillingContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/billing_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets technical contact.
	 */
	public ApiAccountContact GetTechnicalContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(apiHost, "GET", "/v3/account/technical_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets all account contacts.
	 */
	public List<ApiAccountContact> GetContacts()
	{
		List<ApiAccountContact> aacs = new List<ApiAccountContact>(3);
		try {
			foreach (JavaScriptObject jso in ApiHelper.GetJson<JavaScriptArray>
				(this.apiHost, "GET", "/v3/account/contacts", null))
				aacs.Add(new ApiAccountContact(jso));
			return aacs;
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Updates an account contact.
	 */
	public void UpdateContact(ApiAccountContact apiAccountContact)
	{
		try {
			if (apiAccountContact == null)
				throw new ArgumentNullException("apiAccountContact");
			StringWriter stringWriter = new StringWriter();
			new JsonSerializer().Serialize(stringWriter, apiAccountContact);
			
			ApiHelper.GetJson<JavaScriptObject>(apiHost, "PUT",
				"/v3/account/contacts/" + apiAccountContact.AccountContactId,
					Encoding.UTF8.GetBytes(stringWriter.ToString()));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets account services.
	 */
	public ApiList<ApiAccountService> GetServices() { return GetServices(-1, -1); }
	public ApiList<ApiAccountService> GetServices(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiAccountService>
			(this.apiHost, "/v3/account/services", page, pageSize);
	}
	
	/**
	 * Gets account settings.
	 */
	public ApiAccountSettings GetSettings()
	{
		try {
			return new ApiAccountSettings(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/settings", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Updates account settings.
	 */
	public ApiAccountSettings UpdateSettings(ApiAccountSettings apiAccountSettings)
	{
		try {
			if (apiAccountSettings == null)
				throw new ArgumentNullException("apiAccountSettings");
			StringWriter stringWriter = new StringWriter();
			new JsonSerializer().Serialize(stringWriter, apiAccountSettings);
			return new ApiAccountSettings(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/account/settings",
					Encoding.UTF8.GetBytes(stringWriter.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets child accounts.
	 */
	public ApiList<ApiChildAccount> GetChildAccounts() { return GetChildAccounts(-1, -1); }
	public ApiList<ApiChildAccount> GetChildAccounts(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiChildAccount>
			(this.apiHost, "/v3/account/childaccounts", page, pageSize);
	}
	
	/**
	 * Gets account invoices.
	 */
	public ApiList<ApiAccountInvoice> GetInvoices() { return GetInvoices(-1, -1); }
	public ApiList<ApiAccountInvoice> GetInvoices(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiAccountInvoice>
			(this.apiHost, "/v3/account/invoices", page, pageSize);
	}
}
}