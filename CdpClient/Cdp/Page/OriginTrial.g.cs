using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class OriginTrial {
[JsonPropertyName("trialName")]public string TrialName{get;set;}
[JsonPropertyName("status")]public OriginTrialStatus Status{get;set;}
[JsonPropertyName("tokensWithStatus")]public OriginTrialTokenWithStatus[] TokensWithStatus{get;set;}
}
