using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Information about a signed exchange response.
/// </summary>
[Experimental]public sealed partial class SignedExchangeInfo {
/// <summary>
/// The outer response of signed HTTP exchange which was received from network.
/// </summary>
[JsonPropertyName("outerResponse")]public Response OuterResponse{get;set;}
/// <summary>
/// Information about the signed exchange header.
/// </summary>
[JsonPropertyName("header")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SignedExchangeHeader? Header{get;set;}
/// <summary>
/// Security details for the signed exchange header.
/// </summary>
[JsonPropertyName("securityDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SecurityDetails? SecurityDetails{get;set;}
/// <summary>
/// Errors occurred while handling the signed exchagne.
/// </summary>
[JsonPropertyName("errors")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SignedExchangeError[]? Errors{get;set;}
}
