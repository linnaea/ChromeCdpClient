using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Details for a request that has been blocked with the BLOCKED_BY_RESPONSE
/// code. Currently only used for COEP/COOP, but may be extended to include
/// some CSP errors in the future.
/// </summary>
public sealed partial class BlockedByResponseIssueDetails {
[JsonPropertyName("request")]public AffectedRequest Request{get;set;}
[JsonPropertyName("parentFrame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? ParentFrame{get;set;}
[JsonPropertyName("blockedFrame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? BlockedFrame{get;set;}
[JsonPropertyName("reason")]public BlockedByResponseReason Reason{get;set;}
}
