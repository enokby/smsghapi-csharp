// $Id: ApiContactsResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Smsgh.Json;

/// <summary>
/// Represents an API contacts resource.
/// </summary>
public class ApiContactsResource
{
	// Data fields.
	private SmsghApi apiHost;
	
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiContactsResource"/> class.
    /// </summary>
	public ApiContactsResource(SmsghApi apiHost)
	{
		this.apiHost = apiHost;
	}
	
    /// <summary>
    /// Retrieves all API contacts.
    /// </summary>
	public ApiList<ApiContact> Get()
	{
		return Get(-1, -1, -1, null);
	}
	
    /// <summary>
    /// Retrieves API contacts by group ID and filter.
    /// </summary>
	/// <param name="groupId">ID of the group to retrieve its contacts.</param>
	/// <param name="filter">Filter to narrow the results.</param>
	public ApiList<ApiContact> Get(long groupId, string filter)
	{
		return Get(-1, -1, groupId, filter);
	}
	
    /// <summary>
    /// Retrieves API contacts by page and page size.
    /// </summary>
	/// <param name="page">One-based index of page.</param>
	/// <param name="pageSize">Maximum number of entries in page.</param>
	public ApiList<ApiContact> Get(int page, int pageSize)
	{
		return Get(page, pageSize, -1, null);
	}
	
    /// <summary>
    /// Retrieves API contacts by page, page size, group ID and filter.
    /// </summary>
	/// <param name="page">One-based index of page.</param>
	/// <param name="pageSize">Maximum number of entries in page.</param>
	/// <param name="groupId">ID of the group to retrieve its contacts.</param>
	/// <param name="filter">Filter to narrow the results.</param>
	public ApiList<ApiContact> Get
		(int page, int pageSize, long groupId, string filter)
	{
		string uri = "/v3/contacts";
		if (groupId > 0)
			uri += "?GroupId=" + groupId;
		if (filter != null) {
			uri += String.Format("{0}Filter={1}",
				groupId > 0 ? "&" : "?",
					HttpUtility.UrlEncode(filter));
		}
		return ApiHelper.GetApiList<ApiContact>
			(this.apiHost, uri, page, pageSize, uri.IndexOf("?") > 0);
	}
	
    /// <summary>
    /// Retrieves an API contact by ID.
    /// </summary>
	/// <param name="contactId">ID of the contact to retrieve.</param>
	public ApiContact Get(long contactId)
	{
		return Get(Convert.ToString(contactId));
	}
	
    /// <summary>
    /// Retrieves an API contact by phone number.
    /// </summary>
	/// <param name="phoneNumber">Phone number of the contact to retrieve.</param>
	public ApiContact Get(string phoneNumber)
	{
		try {
			if (phoneNumber == null)
				throw new ArgumentNullException("phoneNumber");
			phoneNumber = new Regex("[^\\d]").Replace(phoneNumber, "");
			return new ApiContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/contacts/" + phoneNumber, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Creates a new API contact.
    /// </summary>
	/// <param name="apiContact">The API contact to create.</param>
	public ApiContact Create(ApiContact apiContact)
	{
		try {
			if (apiContact == null)
				throw new ArgumentNullException("apiContact");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiContact);
			return new ApiContact(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/contacts",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API contact.
    /// </summary>
	/// <param name="apiContact">The API contact to update.</param>
	public void Update(ApiContact apiContact)
	{
		try {
			if (apiContact == null)
				throw new ArgumentNullException("apiContact");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiContact);
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/contacts/" + apiContact.ContactId,
					Encoding.UTF8.GetBytes(zw.ToString()));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API contact by ID.
    /// </summary>
	/// <param name="page">ID of the API contact to delete.</param>
	public void Delete(long contactId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/contacts/" + contactId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Retrieves all API contact groups.
    /// </summary>
	public ApiList<ApiContactGroup> GetGroups()
	{
		return GetGroups(-1, -1);
	}
	
    /// <summary>
    /// Retrieves API contact groups by page and page size.
    /// </summary>
	/// <param name="page">One-based index of the page to query.</param>
	/// <param name="pageSize">Maximum number of entries in a page.</param>
	public ApiList<ApiContactGroup> GetGroups(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiContactGroup>
			(this.apiHost, "/v3/contacts/groups", page, pageSize);
	}
	
    /// <summary>
    /// Retrieves an API contact group by ID.
    /// </summary>
	/// <param name="groupId">ID of the contact group to query.</param>
	public ApiContactGroup GetGroup(long groupId)
	{
		try {
			return new ApiContactGroup(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/contacts/groups/" + groupId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Creates a new API contact group.
    /// </summary>
	/// <param name="apiContactGroup">The API contact group to create.</param>
	public ApiContactGroup CreateGroup(ApiContactGroup apiContactGroup)
	{
		try {
			if (apiContactGroup == null)
				throw new ArgumentNullException("apiContactGroup");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiContactGroup);
			return new ApiContactGroup(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "POST", "/v3/contacts/groups",
					Encoding.UTF8.GetBytes(zw.ToString())));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Updates an API contact group.
    /// </summary>
	/// <param name="apiContactGroup">API contact group to update.</param>
	public void UpdateGroup(ApiContactGroup apiContactGroup)
	{
		try {
			if (apiContactGroup == null)
				throw new ArgumentNullException("apiContactGroup");
			StringWriter zw = new StringWriter();
			new JsonSerializer().Serialize(zw, apiContactGroup);
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "PUT", "/v3/contacts/groups/" + apiContactGroup.GroupId,
					Encoding.UTF8.GetBytes(zw.ToString()));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
    /// <summary>
    /// Deletes an API contact group by ID.
    /// </summary>
	/// <param name="groupId">ID of the API contact group to delete.</param>
	public void DeleteGroup(long groupId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/contacts/groups/" + groupId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
}
}
