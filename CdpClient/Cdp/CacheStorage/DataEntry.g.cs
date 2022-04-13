using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CacheStorage;
/// <summary>
/// Data entry.
/// </summary>
public sealed partial class DataEntry {
/// <summary>
/// Request URL.
/// </summary>
[JsonPropertyName("requestURL")]public string RequestURL{get;set;}
/// <summary>
/// Request method.
/// </summary>
[JsonPropertyName("requestMethod")]public string RequestMethod{get;set;}
/// <summary>
/// Request headers
/// </summary>
[JsonPropertyName("requestHeaders")]public Header[] RequestHeaders{get;set;}
/// <summary>
/// Number of seconds since epoch.
/// </summary>
[JsonPropertyName("responseTime")]public double ResponseTime{get;set;}
/// <summary>
/// HTTP response status code.
/// </summary>
[JsonPropertyName("responseStatus")]public long ResponseStatus{get;set;}
/// <summary>
/// HTTP response status text.
/// </summary>
[JsonPropertyName("responseStatusText")]public string ResponseStatusText{get;set;}
/// <summary>
/// HTTP response type
/// </summary>
[JsonPropertyName("responseType")]public CachedResponseType ResponseType{get;set;}
/// <summary>
/// Response headers
/// </summary>
[JsonPropertyName("responseHeaders")]public Header[] ResponseHeaders{get;set;}
}
