using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMDebugger;
/// <summary>
/// CSP Violation type.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CSPViolationType {
[EnumMember(Value = "trustedtype-sink-violation")] TrustedtypeSinkViolation,
[EnumMember(Value = "trustedtype-policy-violation")] TrustedtypePolicyViolation,
}
