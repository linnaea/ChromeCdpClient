using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class InspectorDomain {
private readonly ConnectedTarget _target;
public InspectorDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables inspector domain notifications.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Inspector.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables inspector domain notifications.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Inspector.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DetachedParams {
/// <summary>
/// The reason why connection has been terminated.
/// </summary>
[JsonPropertyName("reason")]public string Reason{get;set;}
}
private Action<DetachedParams>? _onDetached;
/// <summary>
/// Fired when remote debugging connection is about to be terminated. Contains detach reason.
/// </summary>
public event Action<DetachedParams> OnDetached {
add => _onDetached += value; remove => _onDetached -= value;}
private Action? _onTargetCrashed;
/// <summary>
/// Fired when debugging target has crashed
/// </summary>
public event Action OnTargetCrashed {
add => _onTargetCrashed += value; remove => _onTargetCrashed -= value;}
private Action? _onTargetReloadedAfterCrash;
/// <summary>
/// Fired when debugging target has reloaded after crash
/// </summary>
public event Action OnTargetReloadedAfterCrash {
add => _onTargetReloadedAfterCrash += value; remove => _onTargetReloadedAfterCrash -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Inspector.detached":
_onDetached?.Invoke(_target.DeserializeEvent<DetachedParams>(data));
break;
case "Inspector.targetCrashed":
_onTargetCrashed?.Invoke();
break;
case "Inspector.targetReloadedAfterCrash":
_onTargetReloadedAfterCrash?.Invoke();
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
_onDetached = null;
_onTargetCrashed = null;
_onTargetReloadedAfterCrash = null;
}
}
