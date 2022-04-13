using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Resource type as it was perceived by the rendering engine.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ResourceType {
[EnumMember(Value = "Document")] Document,
[EnumMember(Value = "Stylesheet")] Stylesheet,
[EnumMember(Value = "Image")] Image,
[EnumMember(Value = "Media")] Media,
[EnumMember(Value = "Font")] Font,
[EnumMember(Value = "Script")] Script,
[EnumMember(Value = "TextTrack")] TextTrack,
[EnumMember(Value = "XHR")] XHR,
[EnumMember(Value = "Fetch")] Fetch,
[EnumMember(Value = "EventSource")] EventSource,
[EnumMember(Value = "WebSocket")] WebSocket,
[EnumMember(Value = "Manifest")] Manifest,
[EnumMember(Value = "SignedExchange")] SignedExchange,
[EnumMember(Value = "Ping")] Ping,
[EnumMember(Value = "CSPViolationReport")] CSPViolationReport,
[EnumMember(Value = "Preflight")] Preflight,
[EnumMember(Value = "Other")] Other,
}
