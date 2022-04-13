using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// WebSocket request data.
/// </summary>
public sealed partial class WebSocketRequest {
/// <summary>
/// HTTP request headers.
/// </summary>
[JsonPropertyName("headers")]public Headers Headers{get;set;}
}
