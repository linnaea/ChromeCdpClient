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
[Experimental]public sealed partial class SignedExchangeError {
/// <summary>
/// Error message.
/// </summary>
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// The index of the signature which caused the error.
/// </summary>
[JsonPropertyName("signatureIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? SignatureIndex{get;set;}
/// <summary>
/// The field which caused the error.
/// </summary>
[JsonPropertyName("errorField")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SignedExchangeErrorField? ErrorField{get;set;}
}
