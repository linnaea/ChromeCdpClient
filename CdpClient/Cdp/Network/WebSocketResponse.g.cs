using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// WebSocket response data.
/// </summary>
public sealed partial class WebSocketResponse {
/// <summary>
/// HTTP response status code.
/// </summary>
[JsonPropertyName("status")]public long Status{get;set;}
/// <summary>
/// HTTP response status text.
/// </summary>
[JsonPropertyName("statusText")]public string StatusText{get;set;}
/// <summary>
/// HTTP response headers.
/// </summary>
[JsonPropertyName("headers")]public Headers Headers{get;set;}
/// <summary>
/// HTTP response headers text.
/// </summary>
[JsonPropertyName("headersText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? HeadersText{get;set;}
/// <summary>
/// HTTP request headers.
/// </summary>
[JsonPropertyName("requestHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Headers? RequestHeaders{get;set;}
/// <summary>
/// HTTP request headers text.
/// </summary>
[JsonPropertyName("requestHeadersText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RequestHeadersText{get;set;}
}
