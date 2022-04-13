using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Details for a issue arising from an SAB being instantiated in, or
/// transferred to a context that is not cross-origin isolated.
/// </summary>
public sealed partial class SharedArrayBufferIssueDetails {
[JsonPropertyName("sourceCodeLocation")]public SourceCodeLocation SourceCodeLocation{get;set;}
[JsonPropertyName("isWarning")]public bool IsWarning{get;set;}
[JsonPropertyName("type")]public SharedArrayBufferIssueType Type{get;set;}
}
