using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class FederatedAuthRequestIssueDetails {
[JsonPropertyName("federatedAuthRequestIssueReason")]public FederatedAuthRequestIssueReason FederatedAuthRequestIssueReason{get;set;}
}
