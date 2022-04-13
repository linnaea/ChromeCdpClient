using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// The action to take when a certificate error occurs. continue will continue processing the
/// request and cancel will cancel the request.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum CertificateErrorAction {
[EnumMember(Value = "continue")] Continue,
[EnumMember(Value = "cancel")] Cancel,
}
