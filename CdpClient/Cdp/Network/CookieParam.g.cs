using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Cookie parameter object
/// </summary>
public sealed partial class CookieParam {
/// <summary>
/// Cookie name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Cookie value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
/// <summary>
/// The request-URI to associate with the setting of the cookie. This value can affect the
/// default domain, path, source port, and source scheme values of the created cookie.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// Cookie domain.
/// </summary>
[JsonPropertyName("domain")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Domain{get;set;}
/// <summary>
/// Cookie path.
/// </summary>
[JsonPropertyName("path")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Path{get;set;}
/// <summary>
/// True if cookie is secure.
/// </summary>
[JsonPropertyName("secure")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Secure{get;set;}
/// <summary>
/// True if cookie is http-only.
/// </summary>
[JsonPropertyName("httpOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HttpOnly{get;set;}
/// <summary>
/// Cookie SameSite type.
/// </summary>
[JsonPropertyName("sameSite")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CookieSameSite? SameSite{get;set;}
/// <summary>
/// Cookie expiration date, session cookie if not set
/// </summary>
[JsonPropertyName("expires")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TimeSinceEpoch? Expires{get;set;}
/// <summary>
/// Cookie Priority.
/// </summary>
[Experimental][JsonPropertyName("priority")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CookiePriority? Priority{get;set;}
/// <summary>
/// True if cookie is SameParty.
/// </summary>
[Experimental][JsonPropertyName("sameParty")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? SameParty{get;set;}
/// <summary>
/// Cookie source scheme type.
/// </summary>
[Experimental][JsonPropertyName("sourceScheme")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CookieSourceScheme? SourceScheme{get;set;}
/// <summary>
/// Cookie source port. Valid values are {-1, [1, 65535]}, -1 indicates an unspecified port.
/// An unspecified port value allows protocol clients to emulate legacy cookie scope for the port.
/// This is a temporary ability and it will be removed in the future.
/// </summary>
[Experimental][JsonPropertyName("sourcePort")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? SourcePort{get;set;}
/// <summary>
/// Cookie partition key. The site of the top-level URL the browser was visiting at the start
/// of the request to the endpoint that set the cookie.
/// If not set, the cookie will be set as not partitioned.
/// </summary>
[Experimental][JsonPropertyName("partitionKey")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PartitionKey{get;set;}
}
