using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Details of a signed certificate timestamp (SCT).
/// </summary>
public sealed partial class SignedCertificateTimestamp {
/// <summary>
/// Validation status.
/// </summary>
[JsonPropertyName("status")]public string Status{get;set;}
/// <summary>
/// Origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// Log name / description.
/// </summary>
[JsonPropertyName("logDescription")]public string LogDescription{get;set;}
/// <summary>
/// Log ID.
/// </summary>
[JsonPropertyName("logId")]public string LogId{get;set;}
/// <summary>
/// Issuance date. Unlike TimeSinceEpoch, this contains the number of
/// milliseconds since January 1, 1970, UTC, not the number of seconds.
/// </summary>
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
/// <summary>
/// Hash algorithm.
/// </summary>
[JsonPropertyName("hashAlgorithm")]public string HashAlgorithm{get;set;}
/// <summary>
/// Signature algorithm.
/// </summary>
[JsonPropertyName("signatureAlgorithm")]public string SignatureAlgorithm{get;set;}
/// <summary>
/// Signature data.
/// </summary>
[JsonPropertyName("signatureData")]public string SignatureData{get;set;}
}
