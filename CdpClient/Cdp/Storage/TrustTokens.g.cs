using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Storage;
/// <summary>
/// Pair of issuer origin and number of available (signed, but not used) Trust
/// Tokens from that issuer.
/// </summary>
[Experimental]public sealed partial class TrustTokens {
[JsonPropertyName("issuerOrigin")]public string IssuerOrigin{get;set;}
[JsonPropertyName("count")]public double Count{get;set;}
}
