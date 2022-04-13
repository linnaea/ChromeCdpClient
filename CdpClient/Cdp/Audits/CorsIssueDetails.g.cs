using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Details for a CORS related issue, e.g. a warning or error related to
/// CORS RFC1918 enforcement.
/// </summary>
public sealed partial class CorsIssueDetails {
[JsonPropertyName("corsErrorStatus")]public Network.CorsErrorStatus CorsErrorStatus{get;set;}
[JsonPropertyName("isWarning")]public bool IsWarning{get;set;}
[JsonPropertyName("request")]public AffectedRequest Request{get;set;}
[JsonPropertyName("location")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceCodeLocation? Location{get;set;}
[JsonPropertyName("initiatorOrigin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? InitiatorOrigin{get;set;}
[JsonPropertyName("resourceIPAddressSpace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.IPAddressSpace? ResourceIPAddressSpace{get;set;}
[JsonPropertyName("clientSecurityState")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ClientSecurityState? ClientSecurityState{get;set;}
}
