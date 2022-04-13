using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class MemoryDomain {
private readonly ConnectedTarget _target;
public MemoryDomain(ConnectedTarget target) => _target = target;
public sealed partial class GetDOMCountersReturn {
[JsonPropertyName("documents")]public long Documents{get;set;}
[JsonPropertyName("nodes")]public long Nodes{get;set;}
[JsonPropertyName("jsEventListeners")]public long JsEventListeners{get;set;}
}
public async Task<GetDOMCountersReturn> GetDOMCounters(
) {
var resp = await _target.SendRequest("Memory.getDOMCounters",
VoidData.Instance);
return _target.DeserializeResponse<GetDOMCountersReturn>(resp);
}
public async Task PrepareForLeakDetection(
) {
var resp = await _target.SendRequest("Memory.prepareForLeakDetection",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Simulate OomIntervention by purging V8 memory.
/// </summary>
public async Task ForciblyPurgeJavaScriptMemory(
) {
var resp = await _target.SendRequest("Memory.forciblyPurgeJavaScriptMemory",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPressureNotificationsSuppressedParams {
/// <summary>
/// If true, memory pressure notifications will be suppressed.
/// </summary>
[JsonPropertyName("suppressed")]public bool Suppressed{get;set;}
}
/// <summary>
/// Enable/disable suppressing memory pressure notifications in all processes.
/// </summary>
/// <param name="suppressed">If true, memory pressure notifications will be suppressed.</param>
public async Task SetPressureNotificationsSuppressed(
 bool @suppressed) {
var resp = await _target.SendRequest("Memory.setPressureNotificationsSuppressed",
new SetPressureNotificationsSuppressedParams {
Suppressed=@suppressed,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SimulatePressureNotificationParams {
/// <summary>
/// Memory pressure level of the notification.
/// </summary>
[JsonPropertyName("level")]public Memory.PressureLevel Level{get;set;}
}
/// <summary>
/// Simulate a memory pressure notification in all processes.
/// </summary>
/// <param name="level">Memory pressure level of the notification.</param>
public async Task SimulatePressureNotification(
 Memory.PressureLevel @level) {
var resp = await _target.SendRequest("Memory.simulatePressureNotification",
new SimulatePressureNotificationParams {
Level=@level,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartSamplingParams {
/// <summary>
/// Average number of bytes between samples.
/// </summary>
[JsonPropertyName("samplingInterval")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? SamplingInterval{get;set;}
/// <summary>
/// Do not randomize intervals between samples.
/// </summary>
[JsonPropertyName("suppressRandomness")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? SuppressRandomness{get;set;}
}
/// <summary>
/// Start collecting native memory profile.
/// </summary>
/// <param name="samplingInterval">Average number of bytes between samples.</param>
/// <param name="suppressRandomness">Do not randomize intervals between samples.</param>
public async Task StartSampling(
 long? @samplingInterval=default,bool? @suppressRandomness=default) {
var resp = await _target.SendRequest("Memory.startSampling",
new StartSamplingParams {
SamplingInterval=@samplingInterval,SuppressRandomness=@suppressRandomness,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Stop collecting native memory profile.
/// </summary>
public async Task StopSampling(
) {
var resp = await _target.SendRequest("Memory.stopSampling",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetAllTimeSamplingProfileReturn {
[JsonPropertyName("profile")]public Memory.SamplingProfile Profile{get;set;}
}
/// <summary>
/// Retrieve native memory allocations profile
/// collected since renderer process startup.
/// </summary>
public async Task<GetAllTimeSamplingProfileReturn> GetAllTimeSamplingProfile(
) {
var resp = await _target.SendRequest("Memory.getAllTimeSamplingProfile",
VoidData.Instance);
return _target.DeserializeResponse<GetAllTimeSamplingProfileReturn>(resp);
}
public sealed partial class GetBrowserSamplingProfileReturn {
[JsonPropertyName("profile")]public Memory.SamplingProfile Profile{get;set;}
}
/// <summary>
/// Retrieve native memory allocations profile
/// collected since browser process startup.
/// </summary>
public async Task<GetBrowserSamplingProfileReturn> GetBrowserSamplingProfile(
) {
var resp = await _target.SendRequest("Memory.getBrowserSamplingProfile",
VoidData.Instance);
return _target.DeserializeResponse<GetBrowserSamplingProfileReturn>(resp);
}
public sealed partial class GetSamplingProfileReturn {
[JsonPropertyName("profile")]public Memory.SamplingProfile Profile{get;set;}
}
/// <summary>
/// Retrieve native memory allocations profile collected since last
/// `startSampling` call.
/// </summary>
public async Task<GetSamplingProfileReturn> GetSamplingProfile(
) {
var resp = await _target.SendRequest("Memory.getSamplingProfile",
VoidData.Instance);
return _target.DeserializeResponse<GetSamplingProfileReturn>(resp);
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
