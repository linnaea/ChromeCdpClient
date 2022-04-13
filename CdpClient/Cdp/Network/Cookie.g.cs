using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Cookie object
/// </summary>
public sealed partial class Cookie {
/// <summary>
/// Cookie name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Cookie value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
/// <summary>
/// Cookie domain.
/// </summary>
[JsonPropertyName("domain")]public string Domain{get;set;}
/// <summary>
/// Cookie path.
/// </summary>
[JsonPropertyName("path")]public string Path{get;set;}
/// <summary>
/// Cookie expiration date as the number of seconds since the UNIX epoch.
/// </summary>
[JsonPropertyName("expires")]public double Expires{get;set;}
/// <summary>
/// Cookie size.
/// </summary>
[JsonPropertyName("size")]public long Size{get;set;}
/// <summary>
/// True if cookie is http-only.
/// </summary>
[JsonPropertyName("httpOnly")]public bool HttpOnly{get;set;}
/// <summary>
/// True if cookie is secure.
/// </summary>
[JsonPropertyName("secure")]public bool Secure{get;set;}
/// <summary>
/// True in case of session cookie.
/// </summary>
[JsonPropertyName("session")]public bool Session{get;set;}
/// <summary>
/// Cookie SameSite type.
/// </summary>
[JsonPropertyName("sameSite")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CookieSameSite? SameSite{get;set;}
/// <summary>
/// Cookie Priority
/// </summary>
[Experimental][JsonPropertyName("priority")]public CookiePriority Priority{get;set;}
/// <summary>
/// True if cookie is SameParty.
/// </summary>
[Experimental][JsonPropertyName("sameParty")]public bool SameParty{get;set;}
/// <summary>
/// Cookie source scheme type.
/// </summary>
[Experimental][JsonPropertyName("sourceScheme")]public CookieSourceScheme SourceScheme{get;set;}
/// <summary>
/// Cookie source port. Valid values are {-1, [1, 65535]}, -1 indicates an unspecified port.
/// An unspecified port value allows protocol clients to emulate legacy cookie scope for the port.
/// This is a temporary ability and it will be removed in the future.
/// </summary>
[Experimental][JsonPropertyName("sourcePort")]public long SourcePort{get;set;}
/// <summary>
/// Cookie partition key. The site of the top-level URL the browser was visiting at the start
/// of the request to the endpoint that set the cookie.
/// </summary>
[Experimental][JsonPropertyName("partitionKey")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PartitionKey{get;set;}
/// <summary>
/// True if cookie partition key is opaque.
/// </summary>
[Experimental][JsonPropertyName("partitionKeyOpaque")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? PartitionKeyOpaque{get;set;}
}
