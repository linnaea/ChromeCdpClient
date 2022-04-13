using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Loading priority of a resource request.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ResourcePriority {
[EnumMember(Value = "VeryLow")] VeryLow,
[EnumMember(Value = "Low")] Low,
[EnumMember(Value = "Medium")] Medium,
[EnumMember(Value = "High")] High,
[EnumMember(Value = "VeryHigh")] VeryHigh,
}
