using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Information about the cached resource.
/// </summary>
public sealed partial class CachedResource {
/// <summary>
/// Resource URL. This is the url of the original network request.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Type of this resource.
/// </summary>
[JsonPropertyName("type")]public ResourceType Type{get;set;}
/// <summary>
/// Cached response data.
/// </summary>
[JsonPropertyName("response")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Response? Response{get;set;}
/// <summary>
/// Cached response body size.
/// </summary>
[JsonPropertyName("bodySize")]public double BodySize{get;set;}
}
