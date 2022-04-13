using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// Details about the security state of the page certificate.
/// </summary>
[Experimental]public sealed partial class CertificateSecurityState {
/// <summary>
/// Protocol name (e.g. "TLS 1.2" or "QUIC").
/// </summary>
[JsonPropertyName("protocol")]public string Protocol{get;set;}
/// <summary>
/// Key Exchange used by the connection, or the empty string if not applicable.
/// </summary>
[JsonPropertyName("keyExchange")]public string KeyExchange{get;set;}
/// <summary>
/// (EC)DH group used by the connection, if applicable.
/// </summary>
[JsonPropertyName("keyExchangeGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? KeyExchangeGroup{get;set;}
/// <summary>
/// Cipher name.
/// </summary>
[JsonPropertyName("cipher")]public string Cipher{get;set;}
/// <summary>
/// TLS MAC. Note that AEAD ciphers do not have separate MACs.
/// </summary>
[JsonPropertyName("mac")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Mac{get;set;}
/// <summary>
/// Page certificate.
/// </summary>
[JsonPropertyName("certificate")]public string[] Certificate{get;set;}
/// <summary>
/// Certificate subject name.
/// </summary>
[JsonPropertyName("subjectName")]public string SubjectName{get;set;}
/// <summary>
/// Name of the issuing CA.
/// </summary>
[JsonPropertyName("issuer")]public string Issuer{get;set;}
/// <summary>
/// Certificate valid from date.
/// </summary>
[JsonPropertyName("validFrom")]public Network.TimeSinceEpoch ValidFrom{get;set;}
/// <summary>
/// Certificate valid to (expiration) date
/// </summary>
[JsonPropertyName("validTo")]public Network.TimeSinceEpoch ValidTo{get;set;}
/// <summary>
/// The highest priority network error code, if the certificate has an error.
/// </summary>
[JsonPropertyName("certificateNetworkError")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? CertificateNetworkError{get;set;}
/// <summary>
/// True if the certificate uses a weak signature aglorithm.
/// </summary>
[JsonPropertyName("certificateHasWeakSignature")]public bool CertificateHasWeakSignature{get;set;}
/// <summary>
/// True if the certificate has a SHA1 signature in the chain.
/// </summary>
[JsonPropertyName("certificateHasSha1Signature")]public bool CertificateHasSha1Signature{get;set;}
/// <summary>
/// True if modern SSL
/// </summary>
[JsonPropertyName("modernSSL")]public bool ModernSSL{get;set;}
/// <summary>
/// True if the connection is using an obsolete SSL protocol.
/// </summary>
[JsonPropertyName("obsoleteSslProtocol")]public bool ObsoleteSslProtocol{get;set;}
/// <summary>
/// True if the connection is using an obsolete SSL key exchange.
/// </summary>
[JsonPropertyName("obsoleteSslKeyExchange")]public bool ObsoleteSslKeyExchange{get;set;}
/// <summary>
/// True if the connection is using an obsolete SSL cipher.
/// </summary>
[JsonPropertyName("obsoleteSslCipher")]public bool ObsoleteSslCipher{get;set;}
/// <summary>
/// True if the connection is using an obsolete SSL signature.
/// </summary>
[JsonPropertyName("obsoleteSslSignature")]public bool ObsoleteSslSignature{get;set;}
}
