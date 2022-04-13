using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Security
/// </summary>
public sealed partial class SecurityDomain {
private readonly ConnectedTarget _target;
public SecurityDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables tracking security state changes.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Security.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables tracking security state changes.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Security.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetIgnoreCertificateErrorsParams {
/// <summary>
/// If true, all certificate errors will be ignored.
/// </summary>
[JsonPropertyName("ignore")]public bool Ignore{get;set;}
}
/// <summary>
/// Enable/disable whether all certificate errors should be ignored.
/// </summary>
/// <param name="ignore">If true, all certificate errors will be ignored.</param>
[Experimental]public async Task SetIgnoreCertificateErrors(
 bool @ignore) {
var resp = await _target.SendRequest("Security.setIgnoreCertificateErrors",
new SetIgnoreCertificateErrorsParams {
Ignore=@ignore,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HandleCertificateErrorParams {
/// <summary>
/// The ID of the event.
/// </summary>
[JsonPropertyName("eventId")]public long EventId{get;set;}
/// <summary>
/// The action to take on the certificate error.
/// </summary>
[JsonPropertyName("action")]public Security.CertificateErrorAction Action{get;set;}
}
/// <summary>
/// Handles a certificate error that fired a certificateError event.
/// </summary>
/// <param name="eventId">The ID of the event.</param>
/// <param name="action">The action to take on the certificate error.</param>
[Obsolete]public async Task HandleCertificateError(
 long @eventId,Security.CertificateErrorAction @action) {
var resp = await _target.SendRequest("Security.handleCertificateError",
new HandleCertificateErrorParams {
EventId=@eventId,Action=@action,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetOverrideCertificateErrorsParams {
/// <summary>
/// If true, certificate errors will be overridden.
/// </summary>
[JsonPropertyName("override")]public bool Override{get;set;}
}
/// <summary>
/// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
/// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
/// </summary>
/// <param name="override">If true, certificate errors will be overridden.</param>
[Obsolete]public async Task SetOverrideCertificateErrors(
 bool @override) {
var resp = await _target.SendRequest("Security.setOverrideCertificateErrors",
new SetOverrideCertificateErrorsParams {
Override=@override,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CertificateErrorParams {
/// <summary>
/// The ID of the event.
/// </summary>
[JsonPropertyName("eventId")]public long EventId{get;set;}
/// <summary>
/// The type of the error.
/// </summary>
[JsonPropertyName("errorType")]public string ErrorType{get;set;}
/// <summary>
/// The url that was requested.
/// </summary>
[JsonPropertyName("requestURL")]public string RequestURL{get;set;}
}
private Action<CertificateErrorParams>? _onCertificateError;
/// <summary>
/// There is a certificate error. If overriding certificate errors is enabled, then it should be
/// handled with the `handleCertificateError` command. Note: this event does not fire if the
/// certificate error has been allowed internally. Only one client per target should override
/// certificate errors at the same time.
/// </summary>
[Obsolete]public event Action<CertificateErrorParams> OnCertificateError {
add => _onCertificateError += value; remove => _onCertificateError -= value;}
public sealed partial class VisibleSecurityStateChangedParams {
/// <summary>
/// Security state information about the page.
/// </summary>
[JsonPropertyName("visibleSecurityState")]public Security.VisibleSecurityState VisibleSecurityState{get;set;}
}
private Action<VisibleSecurityStateChangedParams>? _onVisibleSecurityStateChanged;
/// <summary>
/// The security state of the page changed.
/// </summary>
[Experimental]public event Action<VisibleSecurityStateChangedParams> OnVisibleSecurityStateChanged {
add => _onVisibleSecurityStateChanged += value; remove => _onVisibleSecurityStateChanged -= value;}
public sealed partial class SecurityStateChangedParams {
/// <summary>
/// Security state.
/// </summary>
[JsonPropertyName("securityState")]public Security.SecurityState SecurityState{get;set;}
/// <summary>
/// True if the page was loaded over cryptographic transport such as HTTPS.
/// </summary>
[Obsolete][JsonPropertyName("schemeIsCryptographic")]public bool SchemeIsCryptographic{get;set;}
/// <summary>
/// Previously a list of explanations for the security state. Now always
/// empty.
/// </summary>
[Obsolete][JsonPropertyName("explanations")]public Security.SecurityStateExplanation[] Explanations{get;set;}
/// <summary>
/// Information about insecure content on the page.
/// </summary>
[Obsolete][JsonPropertyName("insecureContentStatus")]public Security.InsecureContentStatus InsecureContentStatus{get;set;}
/// <summary>
/// Overrides user-visible description of the state. Always omitted.
/// </summary>
[Obsolete][JsonPropertyName("summary")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Summary{get;set;}
}
private Action<SecurityStateChangedParams>? _onSecurityStateChanged;
/// <summary>
/// The security state of the page changed. No longer being sent.
/// </summary>
[Obsolete]public event Action<SecurityStateChangedParams> OnSecurityStateChanged {
add => _onSecurityStateChanged += value; remove => _onSecurityStateChanged -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Security.certificateError":
_onCertificateError?.Invoke(_target.DeserializeEvent<CertificateErrorParams>(data));
break;
case "Security.visibleSecurityStateChanged":
_onVisibleSecurityStateChanged?.Invoke(_target.DeserializeEvent<VisibleSecurityStateChangedParams>(data));
break;
case "Security.securityStateChanged":
_onSecurityStateChanged?.Invoke(_target.DeserializeEvent<SecurityStateChangedParams>(data));
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
_onCertificateError = null;
_onVisibleSecurityStateChanged = null;
_onSecurityStateChanged = null;
}
}
