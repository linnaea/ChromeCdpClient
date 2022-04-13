using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
public sealed partial class ProfilerDomain {
private readonly ConnectedTarget _target;
public ProfilerDomain(ConnectedTarget target) => _target = target;
public async Task Disable(
) {
var resp = await _target.SendRequest("Profiler.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Enable(
) {
var resp = await _target.SendRequest("Profiler.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetBestEffortCoverageReturn {
/// <summary>
/// Coverage data for the current isolate.
/// </summary>
[JsonPropertyName("result")]public Profiler.ScriptCoverage[] Result{get;set;}
}
/// <summary>
/// Collect coverage data for the current isolate. The coverage data may be incomplete due to
/// garbage collection.
/// </summary>
public async Task<GetBestEffortCoverageReturn> GetBestEffortCoverage(
) {
var resp = await _target.SendRequest("Profiler.getBestEffortCoverage",
VoidData.Instance);
return _target.DeserializeResponse<GetBestEffortCoverageReturn>(resp);
}
public sealed partial class SetSamplingIntervalParams {
/// <summary>
/// New sampling interval in microseconds.
/// </summary>
[JsonPropertyName("interval")]public long Interval{get;set;}
}
/// <summary>
/// Changes CPU profiler sampling interval. Must be called before CPU profiles recording started.
/// </summary>
/// <param name="interval">New sampling interval in microseconds.</param>
public async Task SetSamplingInterval(
 long @interval) {
var resp = await _target.SendRequest("Profiler.setSamplingInterval",
new SetSamplingIntervalParams {
Interval=@interval,});
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Start(
) {
var resp = await _target.SendRequest("Profiler.start",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartPreciseCoverageParams {
/// <summary>
/// Collect accurate call counts beyond simple 'covered' or 'not covered'.
/// </summary>
[JsonPropertyName("callCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CallCount{get;set;}
/// <summary>
/// Collect block-based coverage.
/// </summary>
[JsonPropertyName("detailed")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Detailed{get;set;}
/// <summary>
/// Allow the backend to send updates on its own initiative
/// </summary>
[JsonPropertyName("allowTriggeredUpdates")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AllowTriggeredUpdates{get;set;}
}
public sealed partial class StartPreciseCoverageReturn {
/// <summary>
/// Monotonically increasing time (in seconds) when the coverage update was taken in the backend.
/// </summary>
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
}
/// <summary>
/// Enable precise code coverage. Coverage data for JavaScript executed before enabling precise code
/// coverage may be incomplete. Enabling prevents running optimized code and resets execution
/// counters.
/// </summary>
/// <param name="callCount">Collect accurate call counts beyond simple 'covered' or 'not covered'.</param>
/// <param name="detailed">Collect block-based coverage.</param>
/// <param name="allowTriggeredUpdates">Allow the backend to send updates on its own initiative</param>
public async Task<StartPreciseCoverageReturn> StartPreciseCoverage(
 bool? @callCount=default,bool? @detailed=default,bool? @allowTriggeredUpdates=default) {
var resp = await _target.SendRequest("Profiler.startPreciseCoverage",
new StartPreciseCoverageParams {
CallCount=@callCount,Detailed=@detailed,AllowTriggeredUpdates=@allowTriggeredUpdates,});
return _target.DeserializeResponse<StartPreciseCoverageReturn>(resp);
}
/// <summary>
/// Enable type profile.
/// </summary>
[Experimental]public async Task StartTypeProfile(
) {
var resp = await _target.SendRequest("Profiler.startTypeProfile",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopReturn {
/// <summary>
/// Recorded profile.
/// </summary>
[JsonPropertyName("profile")]public Profiler.Profile Profile{get;set;}
}
public async Task<StopReturn> Stop(
) {
var resp = await _target.SendRequest("Profiler.stop",
VoidData.Instance);
return _target.DeserializeResponse<StopReturn>(resp);
}
/// <summary>
/// Disable precise code coverage. Disabling releases unnecessary execution count records and allows
/// executing optimized code.
/// </summary>
public async Task StopPreciseCoverage(
) {
var resp = await _target.SendRequest("Profiler.stopPreciseCoverage",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disable type profile. Disabling releases type profile data collected so far.
/// </summary>
[Experimental]public async Task StopTypeProfile(
) {
var resp = await _target.SendRequest("Profiler.stopTypeProfile",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TakePreciseCoverageReturn {
/// <summary>
/// Coverage data for the current isolate.
/// </summary>
[JsonPropertyName("result")]public Profiler.ScriptCoverage[] Result{get;set;}
/// <summary>
/// Monotonically increasing time (in seconds) when the coverage update was taken in the backend.
/// </summary>
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
}
/// <summary>
/// Collect coverage data for the current isolate, and resets execution counters. Precise code
/// coverage needs to have started.
/// </summary>
public async Task<TakePreciseCoverageReturn> TakePreciseCoverage(
) {
var resp = await _target.SendRequest("Profiler.takePreciseCoverage",
VoidData.Instance);
return _target.DeserializeResponse<TakePreciseCoverageReturn>(resp);
}
public sealed partial class TakeTypeProfileReturn {
/// <summary>
/// Type profile for all scripts since startTypeProfile() was turned on.
/// </summary>
[JsonPropertyName("result")]public Profiler.ScriptTypeProfile[] Result{get;set;}
}
/// <summary>
/// Collect type profile.
/// </summary>
[Experimental]public async Task<TakeTypeProfileReturn> TakeTypeProfile(
) {
var resp = await _target.SendRequest("Profiler.takeTypeProfile",
VoidData.Instance);
return _target.DeserializeResponse<TakeTypeProfileReturn>(resp);
}
public sealed partial class ConsoleProfileFinishedParams {
[JsonPropertyName("id")]public string Id{get;set;}
/// <summary>
/// Location of console.profileEnd().
/// </summary>
[JsonPropertyName("location")]public Debugger.Location Location{get;set;}
[JsonPropertyName("profile")]public Profiler.Profile Profile{get;set;}
/// <summary>
/// Profile title passed as an argument to console.profile().
/// </summary>
[JsonPropertyName("title")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Title{get;set;}
}
private Action<ConsoleProfileFinishedParams>? _onConsoleProfileFinished;
public event Action<ConsoleProfileFinishedParams> OnConsoleProfileFinished {
add => _onConsoleProfileFinished += value; remove => _onConsoleProfileFinished -= value;}
public sealed partial class ConsoleProfileStartedParams {
[JsonPropertyName("id")]public string Id{get;set;}
/// <summary>
/// Location of console.profile().
/// </summary>
[JsonPropertyName("location")]public Debugger.Location Location{get;set;}
/// <summary>
/// Profile title passed as an argument to console.profile().
/// </summary>
[JsonPropertyName("title")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Title{get;set;}
}
private Action<ConsoleProfileStartedParams>? _onConsoleProfileStarted;
/// <summary>
/// Sent when new profile recording is started using console.profile() call.
/// </summary>
public event Action<ConsoleProfileStartedParams> OnConsoleProfileStarted {
add => _onConsoleProfileStarted += value; remove => _onConsoleProfileStarted -= value;}
public sealed partial class PreciseCoverageDeltaUpdateParams {
/// <summary>
/// Monotonically increasing time (in seconds) when the coverage update was taken in the backend.
/// </summary>
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
/// <summary>
/// Identifier for distinguishing coverage events.
/// </summary>
[JsonPropertyName("occasion")]public string Occasion{get;set;}
/// <summary>
/// Coverage data for the current isolate.
/// </summary>
[JsonPropertyName("result")]public Profiler.ScriptCoverage[] Result{get;set;}
}
private Action<PreciseCoverageDeltaUpdateParams>? _onPreciseCoverageDeltaUpdate;
/// <summary>
/// Reports coverage delta since the last poll (either from an event like this, or from
/// `takePreciseCoverage` for the current isolate. May only be sent if precise code
/// coverage has been started. This event can be trigged by the embedder to, for example,
/// trigger collection of coverage data immediately at a certain point in time.
/// </summary>
[Experimental]public event Action<PreciseCoverageDeltaUpdateParams> OnPreciseCoverageDeltaUpdate {
add => _onPreciseCoverageDeltaUpdate += value; remove => _onPreciseCoverageDeltaUpdate -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Profiler.consoleProfileFinished":
_onConsoleProfileFinished?.Invoke(_target.DeserializeEvent<ConsoleProfileFinishedParams>(data));
break;
case "Profiler.consoleProfileStarted":
_onConsoleProfileStarted?.Invoke(_target.DeserializeEvent<ConsoleProfileStartedParams>(data));
break;
case "Profiler.preciseCoverageDeltaUpdate":
_onPreciseCoverageDeltaUpdate?.Invoke(_target.DeserializeEvent<PreciseCoverageDeltaUpdateParams>(data));
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
_onConsoleProfileFinished = null;
_onConsoleProfileStarted = null;
_onPreciseCoverageDeltaUpdate = null;
}
}
