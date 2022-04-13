using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Determines what type of Trust Token operation is executed and
/// depending on the type, some additional parameters. The values
/// are specified in third_party/blink/renderer/core/fetch/trust_token.idl.
/// </summary>
[Experimental]public sealed partial class TrustTokenParams {
[JsonPropertyName("type")]public TrustTokenOperationType Type{get;set;}
/// <summary>
/// Only set for "token-redemption" type and determine whether
/// to request a fresh SRR or use a still valid cached SRR.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum RefreshPolicyEnum {
[EnumMember(Value = "UseCached")] UseCached,
[EnumMember(Value = "Refresh")] Refresh,
}
[JsonPropertyName("refreshPolicy")]public RefreshPolicyEnum RefreshPolicy{get;set;}
/// <summary>
/// Origins of issuers from whom to request tokens or redemption
/// records.
/// </summary>
[JsonPropertyName("issuers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Issuers{get;set;}
}
