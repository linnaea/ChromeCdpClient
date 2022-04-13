using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Whether the request complied with Certificate Transparency policy.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum CertificateTransparencyCompliance {
[EnumMember(Value = "unknown")] Unknown,
[EnumMember(Value = "not-compliant")] NotCompliant,
[EnumMember(Value = "compliant")] Compliant,
}
