/**
 * $Id: ApiException.cs 226 2013-08-29 11:34:52Z mkwayisi $
 */

namespace Smsgh
{
public class ApiException : System.Exception
{
	/**
	 * Primary constructor.
	 */
	public ApiException(string message) : base(message) { }
}
}
