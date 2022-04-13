using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Storage;
/// <summary>
/// Enum of interest group access types.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum InterestGroupAccessType {
[EnumMember(Value = "join")] Join,
[EnumMember(Value = "leave")] Leave,
[EnumMember(Value = "update")] Update,
[EnumMember(Value = "bid")] Bid,
[EnumMember(Value = "win")] Win,
}
