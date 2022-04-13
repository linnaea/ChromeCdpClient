using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class ServiceWorkerDomain {
private readonly ConnectedTarget _target;
public ServiceWorkerDomain(ConnectedTarget target) => _target = target;
public sealed partial class DeliverPushMessageParams {
[JsonPropertyName("origin")]public string Origin{get;set;}
[JsonPropertyName("registrationId")]public ServiceWorker.RegistrationID RegistrationId{get;set;}
[JsonPropertyName("data")]public string Data{get;set;}
}
/// <param name="origin"></param>
/// <param name="registrationId"></param>
/// <param name="data"></param>
public async Task DeliverPushMessage(
 string @origin,ServiceWorker.RegistrationID @registrationId,string @data) {
var resp = await _target.SendRequest("ServiceWorker.deliverPushMessage",
new DeliverPushMessageParams {
Origin=@origin,RegistrationId=@registrationId,Data=@data,});
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Disable(
) {
var resp = await _target.SendRequest("ServiceWorker.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DispatchSyncEventParams {
[JsonPropertyName("origin")]public string Origin{get;set;}
[JsonPropertyName("registrationId")]public ServiceWorker.RegistrationID RegistrationId{get;set;}
[JsonPropertyName("tag")]public string Tag{get;set;}
[JsonPropertyName("lastChance")]public bool LastChance{get;set;}
}
/// <param name="origin"></param>
/// <param name="registrationId"></param>
/// <param name="tag"></param>
/// <param name="lastChance"></param>
public async Task DispatchSyncEvent(
 string @origin,ServiceWorker.RegistrationID @registrationId,string @tag,bool @lastChance) {
var resp = await _target.SendRequest("ServiceWorker.dispatchSyncEvent",
new DispatchSyncEventParams {
Origin=@origin,RegistrationId=@registrationId,Tag=@tag,LastChance=@lastChance,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DispatchPeriodicSyncEventParams {
[JsonPropertyName("origin")]public string Origin{get;set;}
[JsonPropertyName("registrationId")]public ServiceWorker.RegistrationID RegistrationId{get;set;}
[JsonPropertyName("tag")]public string Tag{get;set;}
}
/// <param name="origin"></param>
/// <param name="registrationId"></param>
/// <param name="tag"></param>
public async Task DispatchPeriodicSyncEvent(
 string @origin,ServiceWorker.RegistrationID @registrationId,string @tag) {
var resp = await _target.SendRequest("ServiceWorker.dispatchPeriodicSyncEvent",
new DispatchPeriodicSyncEventParams {
Origin=@origin,RegistrationId=@registrationId,Tag=@tag,});
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Enable(
) {
var resp = await _target.SendRequest("ServiceWorker.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class InspectWorkerParams {
[JsonPropertyName("versionId")]public string VersionId{get;set;}
}
/// <param name="versionId"></param>
public async Task InspectWorker(
 string @versionId) {
var resp = await _target.SendRequest("ServiceWorker.inspectWorker",
new InspectWorkerParams {
VersionId=@versionId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetForceUpdateOnPageLoadParams {
[JsonPropertyName("forceUpdateOnPageLoad")]public bool ForceUpdateOnPageLoad{get;set;}
}
/// <param name="forceUpdateOnPageLoad"></param>
public async Task SetForceUpdateOnPageLoad(
 bool @forceUpdateOnPageLoad) {
var resp = await _target.SendRequest("ServiceWorker.setForceUpdateOnPageLoad",
new SetForceUpdateOnPageLoadParams {
ForceUpdateOnPageLoad=@forceUpdateOnPageLoad,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SkipWaitingParams {
[JsonPropertyName("scopeURL")]public string ScopeURL{get;set;}
}
/// <param name="scopeURL"></param>
public async Task SkipWaiting(
 string @scopeURL) {
var resp = await _target.SendRequest("ServiceWorker.skipWaiting",
new SkipWaitingParams {
ScopeURL=@scopeURL,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartWorkerParams {
[JsonPropertyName("scopeURL")]public string ScopeURL{get;set;}
}
/// <param name="scopeURL"></param>
public async Task StartWorker(
 string @scopeURL) {
var resp = await _target.SendRequest("ServiceWorker.startWorker",
new StartWorkerParams {
ScopeURL=@scopeURL,});
_target.DeserializeResponse<VoidData>(resp);
}
public async Task StopAllWorkers(
) {
var resp = await _target.SendRequest("ServiceWorker.stopAllWorkers",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopWorkerParams {
[JsonPropertyName("versionId")]public string VersionId{get;set;}
}
/// <param name="versionId"></param>
public async Task StopWorker(
 string @versionId) {
var resp = await _target.SendRequest("ServiceWorker.stopWorker",
new StopWorkerParams {
VersionId=@versionId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class UnregisterParams {
[JsonPropertyName("scopeURL")]public string ScopeURL{get;set;}
}
/// <param name="scopeURL"></param>
public async Task Unregister(
 string @scopeURL) {
var resp = await _target.SendRequest("ServiceWorker.unregister",
new UnregisterParams {
ScopeURL=@scopeURL,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class UpdateRegistrationParams {
[JsonPropertyName("scopeURL")]public string ScopeURL{get;set;}
}
/// <param name="scopeURL"></param>
public async Task UpdateRegistration(
 string @scopeURL) {
var resp = await _target.SendRequest("ServiceWorker.updateRegistration",
new UpdateRegistrationParams {
ScopeURL=@scopeURL,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class WorkerErrorReportedParams {
[JsonPropertyName("errorMessage")]public ServiceWorker.ServiceWorkerErrorMessage ErrorMessage{get;set;}
}
private Action<WorkerErrorReportedParams>? _onWorkerErrorReported;
public event Action<WorkerErrorReportedParams> OnWorkerErrorReported {
add => _onWorkerErrorReported += value; remove => _onWorkerErrorReported -= value;}
public sealed partial class WorkerRegistrationUpdatedParams {
[JsonPropertyName("registrations")]public ServiceWorker.ServiceWorkerRegistration[] Registrations{get;set;}
}
private Action<WorkerRegistrationUpdatedParams>? _onWorkerRegistrationUpdated;
public event Action<WorkerRegistrationUpdatedParams> OnWorkerRegistrationUpdated {
add => _onWorkerRegistrationUpdated += value; remove => _onWorkerRegistrationUpdated -= value;}
public sealed partial class WorkerVersionUpdatedParams {
[JsonPropertyName("versions")]public ServiceWorker.ServiceWorkerVersion[] Versions{get;set;}
}
private Action<WorkerVersionUpdatedParams>? _onWorkerVersionUpdated;
public event Action<WorkerVersionUpdatedParams> OnWorkerVersionUpdated {
add => _onWorkerVersionUpdated += value; remove => _onWorkerVersionUpdated -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "ServiceWorker.workerErrorReported":
_onWorkerErrorReported?.Invoke(_target.DeserializeEvent<WorkerErrorReportedParams>(data));
break;
case "ServiceWorker.workerRegistrationUpdated":
_onWorkerRegistrationUpdated?.Invoke(_target.DeserializeEvent<WorkerRegistrationUpdatedParams>(data));
break;
case "ServiceWorker.workerVersionUpdated":
_onWorkerVersionUpdated?.Invoke(_target.DeserializeEvent<WorkerVersionUpdatedParams>(data));
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
_onWorkerErrorReported = null;
_onWorkerRegistrationUpdated = null;
_onWorkerVersionUpdated = null;
}
}
