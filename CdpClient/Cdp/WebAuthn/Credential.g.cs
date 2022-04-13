using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
public sealed partial class Credential {
[JsonPropertyName("credentialId")]public string CredentialId{get;set;}
[JsonPropertyName("isResidentCredential")]public bool IsResidentCredential{get;set;}
/// <summary>
/// Relying Party ID the credential is scoped to. Must be set when adding a
/// credential.
/// </summary>
[JsonPropertyName("rpId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RpId{get;set;}
/// <summary>
/// The ECDSA P-256 private key in PKCS#8 format. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("privateKey")]public string PrivateKey{get;set;}
/// <summary>
/// An opaque byte sequence with a maximum size of 64 bytes mapping the
/// credential to a specific user. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("userHandle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UserHandle{get;set;}
/// <summary>
/// Signature counter. This is incremented by one for each successful
/// assertion.
/// See https://w3c.github.io/webauthn/#signature-counter
/// </summary>
[JsonPropertyName("signCount")]public long SignCount{get;set;}
/// <summary>
/// The large blob associated with the credential.
/// See https://w3c.github.io/webauthn/#sctn-large-blob-extension (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("largeBlob")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? LargeBlob{get;set;}
}
