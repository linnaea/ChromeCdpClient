using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class ContentSecurityPolicyIssueDetails {
/// <summary>
/// The url not included in allowed sources.
/// </summary>
[JsonPropertyName("blockedURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BlockedURL{get;set;}
/// <summary>
/// Specific directive that is violated, causing the CSP issue.
/// </summary>
[JsonPropertyName("violatedDirective")]public string ViolatedDirective{get;set;}
[JsonPropertyName("isReportOnly")]public bool IsReportOnly{get;set;}
[JsonPropertyName("contentSecurityPolicyViolationType")]public ContentSecurityPolicyViolationType ContentSecurityPolicyViolationType{get;set;}
[JsonPropertyName("frameAncestor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? FrameAncestor{get;set;}
[JsonPropertyName("sourceCodeLocation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceCodeLocation? SourceCodeLocation{get;set;}
[JsonPropertyName("violatingNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? ViolatingNodeId{get;set;}
}
