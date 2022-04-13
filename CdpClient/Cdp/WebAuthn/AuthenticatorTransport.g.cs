using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
[JsonConverter(typeof(StringEnumConverter))] public enum AuthenticatorTransport {
[EnumMember(Value = "usb")] Usb,
[EnumMember(Value = "nfc")] Nfc,
[EnumMember(Value = "ble")] Ble,
[EnumMember(Value = "cable")] Cable,
[EnumMember(Value = "internal")] Internal,
}
