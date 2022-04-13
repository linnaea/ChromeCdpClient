using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Information about a signed exchange header.
/// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#cbor-representation
/// </summary>
[Experimental]public sealed partial class SignedExchangeHeader {
/// <summary>
/// Signed exchange request URL.
/// </summary>
[JsonPropertyName("requestUrl")]public string RequestUrl{get;set;}
/// <summary>
/// Signed exchange response code.
/// </summary>
[JsonPropertyName("responseCode")]public long ResponseCode{get;set;}
/// <summary>
/// Signed exchange response headers.
/// </summary>
[JsonPropertyName("responseHeaders")]public Headers ResponseHeaders{get;set;}
/// <summary>
/// Signed exchange response signature.
/// </summary>
[JsonPropertyName("signatures")]public SignedExchangeSignature[] Signatures{get;set;}
/// <summary>
/// Signed exchange header integrity hash in the form of "sha256-<base64-hash-value>".
/// </summary>
[JsonPropertyName("headerIntegrity")]public string HeaderIntegrity{get;set;}
}
