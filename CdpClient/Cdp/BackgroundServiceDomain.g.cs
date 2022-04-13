using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Defines events for background web platform features.
/// </summary>
[Experimental]public sealed partial class BackgroundServiceDomain {
private readonly ConnectedTarget _target;
public BackgroundServiceDomain(ConnectedTarget target) => _target = target;
public sealed partial class StartObservingParams {
[JsonPropertyName("service")]public BackgroundService.ServiceName Service{get;set;}
}
/// <summary>
/// Enables event updates for the service.
/// </summary>
/// <param name="service"></param>
public async Task StartObserving(
 BackgroundService.ServiceName @service) {
var resp = await _target.SendRequest("BackgroundService.startObserving",
new StartObservingParams {
Service=@service,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopObservingParams {
[JsonPropertyName("service")]public BackgroundService.ServiceName Service{get;set;}
}
/// <summary>
/// Disables event updates for the service.
/// </summary>
/// <param name="service"></param>
public async Task StopObserving(
 BackgroundService.ServiceName @service) {
var resp = await _target.SendRequest("BackgroundService.stopObserving",
new StopObservingParams {
Service=@service,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetRecordingParams {
[JsonPropertyName("shouldRecord")]public bool ShouldRecord{get;set;}
[JsonPropertyName("service")]public BackgroundService.ServiceName Service{get;set;}
}
/// <summary>
/// Set the recording state for the service.
/// </summary>
/// <param name="shouldRecord"></param>
/// <param name="service"></param>
public async Task SetRecording(
 bool @shouldRecord,BackgroundService.ServiceName @service) {
var resp = await _target.SendRequest("BackgroundService.setRecording",
new SetRecordingParams {
ShouldRecord=@shouldRecord,Service=@service,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ClearEventsParams {
[JsonPropertyName("service")]public BackgroundService.ServiceName Service{get;set;}
}
/// <summary>
/// Clears all stored data for the service.
/// </summary>
/// <param name="service"></param>
public async Task ClearEvents(
 BackgroundService.ServiceName @service) {
var resp = await _target.SendRequest("BackgroundService.clearEvents",
new ClearEventsParams {
Service=@service,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RecordingStateChangedParams {
[JsonPropertyName("isRecording")]public bool IsRecording{get;set;}
[JsonPropertyName("service")]public BackgroundService.ServiceName Service{get;set;}
}
private Action<RecordingStateChangedParams>? _onRecordingStateChanged;
/// <summary>
/// Called when the recording state for the service has been updated.
/// </summary>
public event Action<RecordingStateChangedParams> OnRecordingStateChanged {
add => _onRecordingStateChanged += value; remove => _onRecordingStateChanged -= value;}
public sealed partial class BackgroundServiceEventReceivedParams {
[JsonPropertyName("backgroundServiceEvent")]public BackgroundService.BackgroundServiceEvent BackgroundServiceEvent{get;set;}
}
private Action<BackgroundServiceEventReceivedParams>? _onBackgroundServiceEventReceived;
/// <summary>
/// Called with all existing backgroundServiceEvents when enabled, and all new
/// events afterwards if enabled and recording.
/// </summary>
public event Action<BackgroundServiceEventReceivedParams> OnBackgroundServiceEventReceived {
add => _onBackgroundServiceEventReceived += value; remove => _onBackgroundServiceEventReceived -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "BackgroundService.recordingStateChanged":
_onRecordingStateChanged?.Invoke(_target.DeserializeEvent<RecordingStateChangedParams>(data));
break;
case "BackgroundService.backgroundServiceEventReceived":
_onBackgroundServiceEventReceived?.Invoke(_target.DeserializeEvent<BackgroundServiceEventReceivedParams>(data));
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
_onRecordingStateChanged = null;
_onBackgroundServiceEventReceived = null;
}
}
