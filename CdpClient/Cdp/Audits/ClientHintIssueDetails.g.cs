using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// This issue tracks client hints related issues. It's used to deprecate old
/// features, encourage the use of new ones, and provide general guidance.
/// </summary>
public sealed partial class ClientHintIssueDetails {
[JsonPropertyName("sourceCodeLocation")]public SourceCodeLocation SourceCodeLocation{get;set;}
[JsonPropertyName("clientHintIssueReason")]public ClientHintIssueReason ClientHintIssueReason{get;set;}
}
