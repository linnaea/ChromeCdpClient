using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Details for issues around "Attribution Reporting API" usage.
/// Explainer: https://github.com/WICG/conversion-measurement-api
/// </summary>
public sealed partial class AttributionReportingIssueDetails {
[JsonPropertyName("violationType")]public AttributionReportingIssueType ViolationType{get;set;}
[JsonPropertyName("frame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? Frame{get;set;}
[JsonPropertyName("request")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedRequest? Request{get;set;}
[JsonPropertyName("violatingNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? ViolatingNodeId{get;set;}
[JsonPropertyName("invalidParameter")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? InvalidParameter{get;set;}
}
