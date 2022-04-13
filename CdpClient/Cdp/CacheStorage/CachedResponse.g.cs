using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CacheStorage;
/// <summary>
/// Cached response
/// </summary>
public sealed partial class CachedResponse {
/// <summary>
/// Entry content, base64-encoded. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("body")]public string Body{get;set;}
}
