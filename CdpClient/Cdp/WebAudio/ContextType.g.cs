using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Enum of BaseAudioContext types
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ContextType {
[EnumMember(Value = "realtime")] Realtime,
[EnumMember(Value = "offline")] Offline,
}
