using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
public sealed partial class VirtualAuthenticatorOptions {
[JsonPropertyName("protocol")]public AuthenticatorProtocol Protocol{get;set;}
/// <summary>
/// Defaults to ctap2_0. Ignored if |protocol| == u2f.
/// </summary>
[JsonPropertyName("ctap2Version")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Ctap2Version? Ctap2Version{get;set;}
[JsonPropertyName("transport")]public AuthenticatorTransport Transport{get;set;}
/// <summary>
/// Defaults to false.
/// </summary>
[JsonPropertyName("hasResidentKey")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasResidentKey{get;set;}
/// <summary>
/// Defaults to false.
/// </summary>
[JsonPropertyName("hasUserVerification")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasUserVerification{get;set;}
/// <summary>
/// If set to true, the authenticator will support the largeBlob extension.
/// https://w3c.github.io/webauthn#largeBlob
/// Defaults to false.
/// </summary>
[JsonPropertyName("hasLargeBlob")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasLargeBlob{get;set;}
/// <summary>
/// If set to true, the authenticator will support the credBlob extension.
/// https://fidoalliance.org/specs/fido-v2.1-rd-20201208/fido-client-to-authenticator-protocol-v2.1-rd-20201208.html#sctn-credBlob-extension
/// Defaults to false.
/// </summary>
[JsonPropertyName("hasCredBlob")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasCredBlob{get;set;}
/// <summary>
/// If set to true, the authenticator will support the minPinLength extension.
/// https://fidoalliance.org/specs/fido-v2.1-ps-20210615/fido-client-to-authenticator-protocol-v2.1-ps-20210615.html#sctn-minpinlength-extension
/// Defaults to false.
/// </summary>
[JsonPropertyName("hasMinPinLength")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasMinPinLength{get;set;}
/// <summary>
/// If set to true, tests of user presence will succeed immediately.
/// Otherwise, they will not be resolved. Defaults to true.
/// </summary>
[JsonPropertyName("automaticPresenceSimulation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AutomaticPresenceSimulation{get;set;}
/// <summary>
/// Sets whether User Verification succeeds or fails for an authenticator.
/// Defaults to false.
/// </summary>
[JsonPropertyName("isUserVerified")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsUserVerified{get;set;}
}
