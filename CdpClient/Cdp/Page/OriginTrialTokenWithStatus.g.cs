using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class OriginTrialTokenWithStatus {
[JsonPropertyName("rawTokenText")]public string RawTokenText{get;set;}
/// <summary>
/// `parsedToken` is present only when the token is extractable and
/// parsable.
/// </summary>
[JsonPropertyName("parsedToken")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public OriginTrialToken? ParsedToken{get;set;}
[JsonPropertyName("status")]public OriginTrialTokenStatus Status{get;set;}
}
