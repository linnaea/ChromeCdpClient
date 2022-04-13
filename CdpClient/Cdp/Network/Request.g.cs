using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// HTTP request data.
/// </summary>
public sealed partial class Request {
/// <summary>
/// Request URL (without fragment).
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Fragment of the requested URL starting with hash, if present.
/// </summary>
[JsonPropertyName("urlFragment")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UrlFragment{get;set;}
/// <summary>
/// HTTP request method.
/// </summary>
[JsonPropertyName("method")]public string Method{get;set;}
/// <summary>
/// HTTP request headers.
/// </summary>
[JsonPropertyName("headers")]public Headers Headers{get;set;}
/// <summary>
/// HTTP POST request data.
/// </summary>
[JsonPropertyName("postData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PostData{get;set;}
/// <summary>
/// True when the request has POST data. Note that postData might still be omitted when this flag is true when the data is too long.
/// </summary>
[JsonPropertyName("hasPostData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasPostData{get;set;}
/// <summary>
/// Request body elements. This will be converted from base64 to binary
/// </summary>
[Experimental][JsonPropertyName("postDataEntries")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public PostDataEntry[]? PostDataEntries{get;set;}
/// <summary>
/// The mixed content type of the request.
/// </summary>
[JsonPropertyName("mixedContentType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Security.MixedContentType? MixedContentType{get;set;}
/// <summary>
/// Priority of the resource request at the time request is sent.
/// </summary>
[JsonPropertyName("initialPriority")]public ResourcePriority InitialPriority{get;set;}
/// <summary>
/// The referrer policy of the request, as defined in https://www.w3.org/TR/referrer-policy/
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ReferrerPolicyEnum {
[EnumMember(Value = "unsafe-url")] UnsafeUrl,
[EnumMember(Value = "no-referrer-when-downgrade")] NoReferrerWhenDowngrade,
[EnumMember(Value = "no-referrer")] NoReferrer,
[EnumMember(Value = "origin")] Origin,
[EnumMember(Value = "origin-when-cross-origin")] OriginWhenCrossOrigin,
[EnumMember(Value = "same-origin")] SameOrigin,
[EnumMember(Value = "strict-origin")] StrictOrigin,
[EnumMember(Value = "strict-origin-when-cross-origin")] StrictOriginWhenCrossOrigin,
}
[JsonPropertyName("referrerPolicy")]public ReferrerPolicyEnum ReferrerPolicy{get;set;}
/// <summary>
/// Whether is loaded via link preload.
/// </summary>
[JsonPropertyName("isLinkPreload")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsLinkPreload{get;set;}
/// <summary>
/// Set for requests when the TrustToken API is used. Contains the parameters
/// passed by the developer (e.g. via "fetch") as understood by the backend.
/// </summary>
[Experimental][JsonPropertyName("trustTokenParams")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TrustTokenParams? TrustTokenParams{get;set;}
/// <summary>
/// True if this resource request is considered to be the 'same site' as the
/// request correspondinfg to the main frame.
/// </summary>
[Experimental][JsonPropertyName("isSameSite")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsSameSite{get;set;}
}
