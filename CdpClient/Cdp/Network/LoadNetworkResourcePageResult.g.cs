using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// An object providing the result of a network resource load.
/// </summary>
[Experimental]public sealed partial class LoadNetworkResourcePageResult {
[JsonPropertyName("success")]public bool Success{get;set;}
/// <summary>
/// Optional values used for error reporting.
/// </summary>
[JsonPropertyName("netError")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? NetError{get;set;}
[JsonPropertyName("netErrorName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? NetErrorName{get;set;}
[JsonPropertyName("httpStatusCode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? HttpStatusCode{get;set;}
/// <summary>
/// If successful, one of the following two fields holds the result.
/// </summary>
[JsonPropertyName("stream")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IO.StreamHandle? Stream{get;set;}
/// <summary>
/// Response headers.
/// </summary>
[JsonPropertyName("headers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Headers? Headers{get;set;}
}
