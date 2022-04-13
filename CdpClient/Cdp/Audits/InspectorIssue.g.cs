using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// An inspector issue reported from the back-end.
/// </summary>
public sealed partial class InspectorIssue {
[JsonPropertyName("code")]public InspectorIssueCode Code{get;set;}
[JsonPropertyName("details")]public InspectorIssueDetails Details{get;set;}
/// <summary>
/// A unique id for this issue. May be omitted if no other entity (e.g.
/// exception, CDP message, etc.) is referencing this issue.
/// </summary>
[JsonPropertyName("issueId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IssueId? IssueId{get;set;}
}
