using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
[JsonConverter(typeof(StringEnumConverter))] public enum ContentSecurityPolicyViolationType {
[EnumMember(Value = "kInlineViolation")] KInlineViolation,
[EnumMember(Value = "kEvalViolation")] KEvalViolation,
[EnumMember(Value = "kURLViolation")] KURLViolation,
[EnumMember(Value = "kTrustedTypesSinkViolation")] KTrustedTypesSinkViolation,
[EnumMember(Value = "kTrustedTypesPolicyViolation")] KTrustedTypesPolicyViolation,
[EnumMember(Value = "kWasmEvalViolation")] KWasmEvalViolation,
}
