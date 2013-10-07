// $Id: ApiContactsResource.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Smsgh.Json;

public class ApiContactsResource
{
	/**
	 * Data fields.
	 */
	private ApiHost apiHost;
	
	/**
	 * Primary constructor.
	 */
	public ApiContactsResource(ApiHost apiHost)
	{
		this.apiHost = apiHost;
	}
	
	/**
	 * Gets all contacts.
	 */
	public ApiList<ApiContact> Get()
	{
		return Get(-1, -1, -1, null);
	}
	
	/**
	 * Gets contacts by group ID and filter.
	 */
	public ApiList<ApiContact> Get(long groupId, string filter)
	{
		return Get(-1, -1, groupId, filter);
	}
	
	/**
	 * Gets contacts by page and pageSize.
	 */
	public ApiList<ApiContact> Get(int page, int pageSize)
	{
		return Get(page, pageSize, -1, null);
	}
	
	/**
	 * Gets contacts by page, pageSize, groupId and filter.
	 */
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
	
	/**
	 * Gets contact by ID.
	 */
	public ApiContact Get(int id)
	{
		return Get(Convert.ToString(id));
	}
	
	/**
	 * Gets contact by phone number.
	 */
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
	
	/**
	 * Creates a new contact.
	 */
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
	
	/**
	 * Updates a contact.
	 */
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
	
	/**
	 * Deletes a contact by ID.
	 */
	public void Delete(int contactId)
	{
		try {
			ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "DELETE", "/v3/contacts/" + contactId, null);
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Gets all contact groups.
	 */
	public ApiList<ApiContactGroup> GetGroups()
	{
		return GetGroups(-1, -1);
	}
	
	/**
	 * Gets contact groups by page and pageSize.
	 */
	public ApiList<ApiContactGroup> GetGroups(int page, int pageSize)
	{
		return ApiHelper.GetApiList<ApiContactGroup>
			(this.apiHost, "/v3/contacts/groups", page, pageSize);
	}
	
	/**
	 * Gets contact group by ID.
	 */
	public ApiContactGroup GetGroup(int groupId)
	{
		try {
			return new ApiContactGroup(ApiHelper.GetJson<JavaScriptObject>
				(this.apiHost, "GET", "/v3/contacts/groups/" + groupId, null));
		} catch (Exception ex) {
			throw new ApiException(ex.Message);
		}
	}
	
	/**
	 * Creates contact group.
	 */
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
	
	/**
	 * Updates contact group.
	 */
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
	
	/**
	 * Deletes contact group.
	 */
	public void DeleteGroup(int groupId)
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
