using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Depending on the concrete errorType, different properties are set.
/// </summary>
public sealed partial class GenericIssueDetails {
/// <summary>
/// Issues with the same errorType are aggregated in the frontend.
/// </summary>
[JsonPropertyName("errorType")]public GenericIssueErrorType ErrorType{get;set;}
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
