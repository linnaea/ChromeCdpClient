using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Network level fetch failure reason.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ErrorReason {
[EnumMember(Value = "Failed")] Failed,
[EnumMember(Value = "Aborted")] Aborted,
[EnumMember(Value = "TimedOut")] TimedOut,
[EnumMember(Value = "AccessDenied")] AccessDenied,
[EnumMember(Value = "ConnectionClosed")] ConnectionClosed,
[EnumMember(Value = "ConnectionReset")] ConnectionReset,
[EnumMember(Value = "ConnectionRefused")] ConnectionRefused,
[EnumMember(Value = "ConnectionAborted")] ConnectionAborted,
[EnumMember(Value = "ConnectionFailed")] ConnectionFailed,
[EnumMember(Value = "NameNotResolved")] NameNotResolved,
[EnumMember(Value = "InternetDisconnected")] InternetDisconnected,
[EnumMember(Value = "AddressUnreachable")] AddressUnreachable,
[EnumMember(Value = "BlockedByClient")] BlockedByClient,
[EnumMember(Value = "BlockedByResponse")] BlockedByResponse,
}
