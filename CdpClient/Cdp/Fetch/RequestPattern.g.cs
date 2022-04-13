using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Fetch;
public sealed partial class RequestPattern {
/// <summary>
/// Wildcards (`'*'` -> zero or more, `'?'` -> exactly one) are allowed. Escape character is
/// backslash. Omitting is equivalent to `"*"`.
/// </summary>
[JsonPropertyName("urlPattern")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UrlPattern{get;set;}
/// <summary>
/// If set, only requests for matching resource types will be intercepted.
/// </summary>
[JsonPropertyName("resourceType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ResourceType? ResourceType{get;set;}
/// <summary>
/// Stage at which to begin intercepting requests. Default is Request.
/// </summary>
[JsonPropertyName("requestStage")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RequestStage? RequestStage{get;set;}
}
