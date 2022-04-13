using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Enum of AudioNode::ChannelInterpretation from the spec
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ChannelInterpretation {
[EnumMember(Value = "discrete")] Discrete,
[EnumMember(Value = "speakers")] Speakers,
}
