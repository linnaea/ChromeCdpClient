using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// WebSocket message data. This represents an entire WebSocket message, not just a fragmented frame as the name suggests.
/// </summary>
public sealed partial class WebSocketFrame {
/// <summary>
/// WebSocket message opcode.
/// </summary>
[JsonPropertyName("opcode")]public double Opcode{get;set;}
/// <summary>
/// WebSocket message mask.
/// </summary>
[JsonPropertyName("mask")]public bool Mask{get;set;}
/// <summary>
/// WebSocket message payload data.
/// If the opcode is 1, this is a text message and payloadData is a UTF-8 string.
/// If the opcode isn't 1, then payloadData is a base64 encoded string representing binary data.
/// </summary>
[JsonPropertyName("payloadData")]public string PayloadData{get;set;}
}
