using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
[JsonConverter(typeof(StringEnumConverter))] public enum Ctap2Version {
[EnumMember(Value = "ctap2_0")] Ctap2_0,
[EnumMember(Value = "ctap2_1")] Ctap2_1,
}
