using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class OriginTrialToken {
[JsonPropertyName("origin")]public string Origin{get;set;}
[JsonPropertyName("matchSubDomains")]public bool MatchSubDomains{get;set;}
[JsonPropertyName("trialName")]public string TrialName{get;set;}
[JsonPropertyName("expiryTime")]public Network.TimeSinceEpoch ExpiryTime{get;set;}
[JsonPropertyName("isThirdParty")]public bool IsThirdParty{get;set;}
[JsonPropertyName("usageRestriction")]public OriginTrialUsageRestriction UsageRestriction{get;set;}
}
