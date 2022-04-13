using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Enum of AudioNode::ChannelCountMode from the spec
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ChannelCountMode {
[EnumMember(Value = "clamped-max")] ClampedMax,
[EnumMember(Value = "explicit")] Explicit,
[EnumMember(Value = "max")] Max,
}
