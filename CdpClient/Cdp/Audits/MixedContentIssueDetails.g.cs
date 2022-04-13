using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class MixedContentIssueDetails {
/// <summary>
/// The type of resource causing the mixed content issue (css, js, iframe,
/// form,...). Marked as optional because it is mapped to from
/// blink::mojom::RequestContextType, which will be replaced
/// by network::mojom::RequestDestination
/// </summary>
[JsonPropertyName("resourceType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public MixedContentResourceType? ResourceType{get;set;}
/// <summary>
/// The way the mixed content issue is being resolved.
/// </summary>
[JsonPropertyName("resolutionStatus")]public MixedContentResolutionStatus ResolutionStatus{get;set;}
/// <summary>
/// The unsafe http url causing the mixed content issue.
/// </summary>
[JsonPropertyName("insecureURL")]public string InsecureURL{get;set;}
/// <summary>
/// The url responsible for the call to an unsafe url.
/// </summary>
[JsonPropertyName("mainResourceURL")]public string MainResourceURL{get;set;}
/// <summary>
/// The mixed content request.
/// Does not always exist (e.g. for unsafe form submission urls).
/// </summary>
[JsonPropertyName("request")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedRequest? Request{get;set;}
/// <summary>
/// Optional because not every mixed content issue is necessarily linked to a frame.
/// </summary>
[JsonPropertyName("frame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? Frame{get;set;}
}
