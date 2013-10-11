// $Id: ApiAccountResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Smsgh.Json;

/// <summary>
/// Represents an API account resource.
/// </summary>
public class ApiAccountResource
{
	// Data fields.
	private SmsghApi apiHost;
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiAccountResource"/> class.
    /// </summary>
	public ApiAccountResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
    /// <summary>
    /// Retrieves account profile.
    /// </summary>
	public ApiAccountProfile GetProfile()
	{
		try {
			return new ApiAccountProfile(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/profile", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves primary contact.
    /// </summary>
	public ApiAccountContact GetPrimaryContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/primary_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves billing contact.
    /// </summary>
	public ApiAccountContact GetBillingContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/billing_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves technical contact.
    /// </summary>
	public ApiAccountContact GetTechnicalContact()
	{
		try {
			return new ApiAccountContact(ApiHelper.GetJson<JavaScriptObject>
				(apiHost, "GET", "/v3/account/technical_contact", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all account contacts.
    /// </summary>
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
	
    /// <summary>
    /// Updates an <see cref="ApiAccountContact"/>.
    /// </summary>
	/// <param name="apiAccountContact">API account contact to update</param>
	public void Update(ApiAccountContact apiAccountContact)
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
	
    /// <summary>
    /// Retrieves all account services.
    /// </summary>
	public ApiList<ApiService> GetServices()
	{
		return GetServices(-1, -1);
	}
	
    /// <summary>
    /// Retrieves account services by page and page size.
    /// </summary>
	/// <param name="page">One-based index of page</param>
	/// <param name="pageSize">Maxium number of entries in a page</param>
	public ApiList<ApiService> GetServices(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiService>
			(this.apiHost, "/v3/account/services", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves account settings.
    /// </summary>
	public ApiSettings GetSettings()
	{
		try {
			return new ApiSettings(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/account/settings", null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates account settings.
    /// </summary>
	/// <param name="apiSettings">API account settings to update.</param>
	public ApiSettings Update(ApiSettings apiSettings)
	{
		try {
			if (apiSettings == null)
				throw new ArgumentNullException("apiAccountSettings");
			StringWriter stringWriter = new StringWriter();
			new JsonSerializer().Serialize(stringWriter, apiSettings);
			return new ApiSettings(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/account/settings",
					Encoding.UTF8.GetBytes(stringWriter.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all child accounts.
    /// </summary>
	public ApiList<ApiChildAccount> GetChildAccounts()
	{
		return GetChildAccounts(-1, -1);
	}
	
    /// <summary>
    /// Retrieves child accounts by page and page size.
    /// </summary>
	/// <param name="page">One-based index of page</param>
	/// <param name="pageSize">Maximum number of entries in a page</param>
	public ApiList<ApiChildAccount> GetChildAccounts(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiChildAccount>
			(this.apiHost, "/v3/account/childaccounts", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves all account invoices.
    /// </summary>
	public ApiList<ApiInvoice> GetInvoices()
	{
		return GetInvoices(-1, -1);
	}
	
    /// <summary>
    /// Retrieves account invoices by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiInvoice> GetInvoices(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiInvoice>
			(this.apiHost, "/v3/account/invoices", page, pageSize);
	}
}
}