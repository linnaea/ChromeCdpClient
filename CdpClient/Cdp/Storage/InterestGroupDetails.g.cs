using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Storage;
/// <summary>
/// The full details of an interest group.
/// </summary>
public sealed partial class InterestGroupDetails {
[JsonPropertyName("ownerOrigin")]public string OwnerOrigin{get;set;}
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("expirationTime")]public Network.TimeSinceEpoch ExpirationTime{get;set;}
[JsonPropertyName("joiningOrigin")]public string JoiningOrigin{get;set;}
[JsonPropertyName("biddingUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BiddingUrl{get;set;}
[JsonPropertyName("biddingWasmHelperUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BiddingWasmHelperUrl{get;set;}
[JsonPropertyName("updateUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UpdateUrl{get;set;}
[JsonPropertyName("trustedBiddingSignalsUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? TrustedBiddingSignalsUrl{get;set;}
[JsonPropertyName("trustedBiddingSignalsKeys")]public string[] TrustedBiddingSignalsKeys{get;set;}
[JsonPropertyName("userBiddingSignals")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UserBiddingSignals{get;set;}
[JsonPropertyName("ads")]public InterestGroupAd[] Ads{get;set;}
[JsonPropertyName("adComponents")]public InterestGroupAd[] AdComponents{get;set;}
}
