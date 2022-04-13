using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// This information is currently necessary, as the front-end has a difficult
/// time finding a specific cookie. With this, we can convey specific error
/// information without the cookie.
/// </summary>
public sealed partial class CookieIssueDetails {
/// <summary>
/// If AffectedCookie is not set then rawCookieLine contains the raw
/// Set-Cookie header string. This hints at a problem where the
/// cookie line is syntactically or semantically malformed in a way
/// that no valid cookie could be created.
/// </summary>
[JsonPropertyName("cookie")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedCookie? Cookie{get;set;}
[JsonPropertyName("rawCookieLine")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RawCookieLine{get;set;}
[JsonPropertyName("cookieWarningReasons")]public CookieWarningReason[] CookieWarningReasons{get;set;}
[JsonPropertyName("cookieExclusionReasons")]public CookieExclusionReason[] CookieExclusionReasons{get;set;}
/// <summary>
/// Optionally identifies the site-for-cookies and the cookie url, which
/// may be used by the front-end as additional context.
/// </summary>
[JsonPropertyName("operation")]public CookieOperation Operation{get;set;}
[JsonPropertyName("siteForCookies")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SiteForCookies{get;set;}
[JsonPropertyName("cookieUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? CookieUrl{get;set;}
[JsonPropertyName("request")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedRequest? Request{get;set;}
}
