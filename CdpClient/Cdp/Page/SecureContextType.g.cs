using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Indicates whether the frame is a secure context and why it is the case.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum SecureContextType {
[EnumMember(Value = "Secure")] Secure,
[EnumMember(Value = "SecureLocalhost")] SecureLocalhost,
[EnumMember(Value = "InsecureScheme")] InsecureScheme,
[EnumMember(Value = "InsecureAncestor")] InsecureAncestor,
}
