using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain allows configuring virtual authenticators to test the WebAuthn
/// API.
/// </summary>
[Experimental]public sealed partial class WebAuthnDomain {
private readonly ConnectedTarget _target;
public WebAuthnDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Enable the WebAuthn domain and start intercepting credential storage and
/// retrieval with a virtual authenticator.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("WebAuthn.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disable the WebAuthn domain.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("WebAuthn.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AddVirtualAuthenticatorParams {
[JsonPropertyName("options")]public WebAuthn.VirtualAuthenticatorOptions Options{get;set;}
}
public sealed partial class AddVirtualAuthenticatorReturn {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
}
/// <summary>
/// Creates and adds a virtual authenticator.
/// </summary>
/// <param name="options"></param>
public async Task<AddVirtualAuthenticatorReturn> AddVirtualAuthenticator(
 WebAuthn.VirtualAuthenticatorOptions @options) {
var resp = await _target.SendRequest("WebAuthn.addVirtualAuthenticator",
new AddVirtualAuthenticatorParams {
Options=@options,});
return _target.DeserializeResponse<AddVirtualAuthenticatorReturn>(resp);
}
public sealed partial class RemoveVirtualAuthenticatorParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
}
/// <summary>
/// Removes the given authenticator.
/// </summary>
/// <param name="authenticatorId"></param>
public async Task RemoveVirtualAuthenticator(
 WebAuthn.AuthenticatorId @authenticatorId) {
var resp = await _target.SendRequest("WebAuthn.removeVirtualAuthenticator",
new RemoveVirtualAuthenticatorParams {
AuthenticatorId=@authenticatorId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AddCredentialParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
[JsonPropertyName("credential")]public WebAuthn.Credential Credential{get;set;}
}
/// <summary>
/// Adds the credential to the specified authenticator.
/// </summary>
/// <param name="authenticatorId"></param>
/// <param name="credential"></param>
public async Task AddCredential(
 WebAuthn.AuthenticatorId @authenticatorId,WebAuthn.Credential @credential) {
var resp = await _target.SendRequest("WebAuthn.addCredential",
new AddCredentialParams {
AuthenticatorId=@authenticatorId,Credential=@credential,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetCredentialParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
[JsonPropertyName("credentialId")]public string CredentialId{get;set;}
}
public sealed partial class GetCredentialReturn {
[JsonPropertyName("credential")]public WebAuthn.Credential Credential{get;set;}
}
/// <summary>
/// Returns a single credential stored in the given virtual authenticator that
/// matches the credential ID.
/// </summary>
/// <param name="authenticatorId"></param>
/// <param name="credentialId"></param>
public async Task<GetCredentialReturn> GetCredential(
 WebAuthn.AuthenticatorId @authenticatorId,string @credentialId) {
var resp = await _target.SendRequest("WebAuthn.getCredential",
new GetCredentialParams {
AuthenticatorId=@authenticatorId,CredentialId=@credentialId,});
return _target.DeserializeResponse<GetCredentialReturn>(resp);
}
public sealed partial class GetCredentialsParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
}
public sealed partial class GetCredentialsReturn {
[JsonPropertyName("credentials")]public WebAuthn.Credential[] Credentials{get;set;}
}
/// <summary>
/// Returns all the credentials stored in the given virtual authenticator.
/// </summary>
/// <param name="authenticatorId"></param>
public async Task<GetCredentialsReturn> GetCredentials(
 WebAuthn.AuthenticatorId @authenticatorId) {
var resp = await _target.SendRequest("WebAuthn.getCredentials",
new GetCredentialsParams {
AuthenticatorId=@authenticatorId,});
return _target.DeserializeResponse<GetCredentialsReturn>(resp);
}
public sealed partial class RemoveCredentialParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
[JsonPropertyName("credentialId")]public string CredentialId{get;set;}
}
/// <summary>
/// Removes a credential from the authenticator.
/// </summary>
/// <param name="authenticatorId"></param>
/// <param name="credentialId"></param>
public async Task RemoveCredential(
 WebAuthn.AuthenticatorId @authenticatorId,string @credentialId) {
var resp = await _target.SendRequest("WebAuthn.removeCredential",
new RemoveCredentialParams {
AuthenticatorId=@authenticatorId,CredentialId=@credentialId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ClearCredentialsParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
}
/// <summary>
/// Clears all the credentials from the specified device.
/// </summary>
/// <param name="authenticatorId"></param>
public async Task ClearCredentials(
 WebAuthn.AuthenticatorId @authenticatorId) {
var resp = await _target.SendRequest("WebAuthn.clearCredentials",
new ClearCredentialsParams {
AuthenticatorId=@authenticatorId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetUserVerifiedParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
[JsonPropertyName("isUserVerified")]public bool IsUserVerified{get;set;}
}
/// <summary>
/// Sets whether User Verification succeeds or fails for an authenticator.
/// The default is true.
/// </summary>
/// <param name="authenticatorId"></param>
/// <param name="isUserVerified"></param>
public async Task SetUserVerified(
 WebAuthn.AuthenticatorId @authenticatorId,bool @isUserVerified) {
var resp = await _target.SendRequest("WebAuthn.setUserVerified",
new SetUserVerifiedParams {
AuthenticatorId=@authenticatorId,IsUserVerified=@isUserVerified,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAutomaticPresenceSimulationParams {
[JsonPropertyName("authenticatorId")]public WebAuthn.AuthenticatorId AuthenticatorId{get;set;}
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Sets whether tests of user presence will succeed immediately (if true) or fail to resolve (if false) for an authenticator.
/// The default is true.
/// </summary>
/// <param name="authenticatorId"></param>
/// <param name="enabled"></param>
public async Task SetAutomaticPresenceSimulation(
 WebAuthn.AuthenticatorId @authenticatorId,bool @enabled) {
var resp = await _target.SendRequest("WebAuthn.setAutomaticPresenceSimulation",
new SetAutomaticPresenceSimulationParams {
AuthenticatorId=@authenticatorId,Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
}
}
