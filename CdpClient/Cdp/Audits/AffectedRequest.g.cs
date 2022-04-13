using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Information about a request that is affected by an inspector issue.
/// </summary>
public sealed partial class AffectedRequest {
/// <summary>
/// The unique request id.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
}
