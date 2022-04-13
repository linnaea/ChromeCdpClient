using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Media;
/// <summary>
/// Corresponds to kMediaEventTriggered
/// </summary>
public sealed partial class PlayerEvent {
[JsonPropertyName("timestamp")]public Timestamp Timestamp{get;set;}
[JsonPropertyName("value")]public string Value{get;set;}
}
