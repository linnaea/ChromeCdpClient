using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// The underlying connection technology that the browser is supposedly using.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ConnectionType {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "cellular2g")] Cellular2g,
[EnumMember(Value = "cellular3g")] Cellular3g,
[EnumMember(Value = "cellular4g")] Cellular4g,
[EnumMember(Value = "bluetooth")] Bluetooth,
[EnumMember(Value = "ethernet")] Ethernet,
[EnumMember(Value = "wifi")] Wifi,
[EnumMember(Value = "wimax")] Wimax,
[EnumMember(Value = "other")] Other,
}
