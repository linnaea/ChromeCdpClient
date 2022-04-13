using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// The reason why request was blocked.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum BlockedReason {
[EnumMember(Value = "other")] Other,
[EnumMember(Value = "csp")] Csp,
[EnumMember(Value = "mixed-content")] MixedContent,
[EnumMember(Value = "origin")] Origin,
[EnumMember(Value = "inspector")] Inspector,
[EnumMember(Value = "subresource-filter")] SubresourceFilter,
[EnumMember(Value = "content-type")] ContentType,
[EnumMember(Value = "coep-frame-resource-needs-coep-header")] CoepFrameResourceNeedsCoepHeader,
[EnumMember(Value = "coop-sandboxed-iframe-cannot-navigate-to-coop-page")] CoopSandboxedIframeCannotNavigateToCoopPage,
[EnumMember(Value = "corp-not-same-origin")] CorpNotSameOrigin,
[EnumMember(Value = "corp-not-same-origin-after-defaulted-to-same-origin-by-coep")] CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
[EnumMember(Value = "corp-not-same-site")] CorpNotSameSite,
}
