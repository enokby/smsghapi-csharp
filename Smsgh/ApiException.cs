// $Id: ApiException.cs 0 1970-01-01 00:00:00Z mkwayisi $
namespace Smsgh
{

using System;

public class ApiException : Exception
{
	/// <summary>
    /// Initializes a new instance of this API exception class.
    /// </summary>
	public ApiException(string message) : base(message) { }
}
}
