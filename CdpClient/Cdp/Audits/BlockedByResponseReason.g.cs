using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Enum indicating the reason a response has been blocked. These reasons are
/// refinements of the net error BLOCKED_BY_RESPONSE.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum BlockedByResponseReason {
[EnumMember(Value = "CoepFrameResourceNeedsCoepHeader")] CoepFrameResourceNeedsCoepHeader,
[EnumMember(Value = "CoopSandboxedIFrameCannotNavigateToCoopPage")] CoopSandboxedIFrameCannotNavigateToCoopPage,
[EnumMember(Value = "CorpNotSameOrigin")] CorpNotSameOrigin,
[EnumMember(Value = "CorpNotSameOriginAfterDefaultedToSameOriginByCoep")] CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
[EnumMember(Value = "CorpNotSameSite")] CorpNotSameSite,
}
