using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
[JsonConverter(typeof(StringEnumConverter))] public enum AuthenticatorProtocol {
[EnumMember(Value = "u2f")] U2f,
[EnumMember(Value = "ctap2")] Ctap2,
}
