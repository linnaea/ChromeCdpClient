using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class HeapProfilerDomain {
private readonly ConnectedTarget _target;
public HeapProfilerDomain(ConnectedTarget target) => _target = target;
public sealed partial class AddInspectedHeapObjectParams {
/// <summary>
/// Heap snapshot object id to be accessible by means of $x command line API.
/// </summary>
[JsonPropertyName("heapObjectId")]public HeapProfiler.HeapSnapshotObjectId HeapObjectId{get;set;}
}
/// <summary>
/// Enables console to refer to the node with given id via $x (see Command Line API for more details
/// $x functions).
/// </summary>
/// <param name="heapObjectId">Heap snapshot object id to be accessible by means of $x command line API.</param>
public async Task AddInspectedHeapObject(
 HeapProfiler.HeapSnapshotObjectId @heapObjectId) {
var resp = await _target.SendRequest("HeapProfiler.addInspectedHeapObject",
new AddInspectedHeapObjectParams {
HeapObjectId=@heapObjectId,});
_target.DeserializeResponse<VoidData>(resp);
}
public async Task CollectGarbage(
) {
var resp = await _target.SendRequest("HeapProfiler.collectGarbage",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Disable(
) {
var resp = await _target.SendRequest("HeapProfiler.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public async Task Enable(
) {
var resp = await _target.SendRequest("HeapProfiler.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetHeapObjectIdParams {
/// <summary>
/// Identifier of the object to get heap object id for.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
}
public sealed partial class GetHeapObjectIdReturn {
/// <summary>
/// Id of the heap snapshot object corresponding to the passed remote object id.
/// </summary>
[JsonPropertyName("heapSnapshotObjectId")]public HeapProfiler.HeapSnapshotObjectId HeapSnapshotObjectId{get;set;}
}
/// <param name="objectId">Identifier of the object to get heap object id for.</param>
public async Task<GetHeapObjectIdReturn> GetHeapObjectId(
 Runtime.RemoteObjectId @objectId) {
var resp = await _target.SendRequest("HeapProfiler.getHeapObjectId",
new GetHeapObjectIdParams {
ObjectId=@objectId,});
return _target.DeserializeResponse<GetHeapObjectIdReturn>(resp);
}
public sealed partial class GetObjectByHeapObjectIdParams {
[JsonPropertyName("objectId")]public HeapProfiler.HeapSnapshotObjectId ObjectId{get;set;}
/// <summary>
/// Symbolic group name that can be used to release multiple objects.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
}
public sealed partial class GetObjectByHeapObjectIdReturn {
/// <summary>
/// Evaluation result.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
}
/// <param name="objectId"></param>
/// <param name="objectGroup">Symbolic group name that can be used to release multiple objects.</param>
public async Task<GetObjectByHeapObjectIdReturn> GetObjectByHeapObjectId(
 HeapProfiler.HeapSnapshotObjectId @objectId,string? @objectGroup=default) {
var resp = await _target.SendRequest("HeapProfiler.getObjectByHeapObjectId",
new GetObjectByHeapObjectIdParams {
ObjectId=@objectId,ObjectGroup=@objectGroup,});
return _target.DeserializeResponse<GetObjectByHeapObjectIdReturn>(resp);
}
public sealed partial class GetSamplingProfileReturn {
/// <summary>
/// Return the sampling profile being collected.
/// </summary>
[JsonPropertyName("profile")]public HeapProfiler.SamplingHeapProfile Profile{get;set;}
}
public async Task<GetSamplingProfileReturn> GetSamplingProfile(
) {
var resp = await _target.SendRequest("HeapProfiler.getSamplingProfile",
VoidData.Instance);
return _target.DeserializeResponse<GetSamplingProfileReturn>(resp);
}
public sealed partial class StartSamplingParams {
/// <summary>
/// Average sample interval in bytes. Poisson distribution is used for the intervals. The
/// default value is 32768 bytes.
/// </summary>
[JsonPropertyName("samplingInterval")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SamplingInterval{get;set;}
}
/// <param name="samplingInterval">Average sample interval in bytes. Poisson distribution is used for the intervals. The
/// default value is 32768 bytes.</param>
public async Task StartSampling(
 double? @samplingInterval=default) {
var resp = await _target.SendRequest("HeapProfiler.startSampling",
new StartSamplingParams {
SamplingInterval=@samplingInterval,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartTrackingHeapObjectsParams {
[JsonPropertyName("trackAllocations")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? TrackAllocations{get;set;}
}
/// <param name="trackAllocations"></param>
public async Task StartTrackingHeapObjects(
 bool? @trackAllocations=default) {
var resp = await _target.SendRequest("HeapProfiler.startTrackingHeapObjects",
new StartTrackingHeapObjectsParams {
TrackAllocations=@trackAllocations,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopSamplingReturn {
/// <summary>
/// Recorded sampling heap profile.
/// </summary>
[JsonPropertyName("profile")]public HeapProfiler.SamplingHeapProfile Profile{get;set;}
}
public async Task<StopSamplingReturn> StopSampling(
) {
var resp = await _target.SendRequest("HeapProfiler.stopSampling",
VoidData.Instance);
return _target.DeserializeResponse<StopSamplingReturn>(resp);
}
public sealed partial class StopTrackingHeapObjectsParams {
/// <summary>
/// If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken
/// when the tracking is stopped.
/// </summary>
[JsonPropertyName("reportProgress")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReportProgress{get;set;}
[JsonPropertyName("treatGlobalObjectsAsRoots")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? TreatGlobalObjectsAsRoots{get;set;}
/// <summary>
/// If true, numerical values are included in the snapshot
/// </summary>
[JsonPropertyName("captureNumericValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CaptureNumericValue{get;set;}
}
/// <param name="reportProgress">If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken
/// when the tracking is stopped.</param>
/// <param name="treatGlobalObjectsAsRoots"></param>
/// <param name="captureNumericValue">If true, numerical values are included in the snapshot</param>
public async Task StopTrackingHeapObjects(
 bool? @reportProgress=default,bool? @treatGlobalObjectsAsRoots=default,bool? @captureNumericValue=default) {
var resp = await _target.SendRequest("HeapProfiler.stopTrackingHeapObjects",
new StopTrackingHeapObjectsParams {
ReportProgress=@reportProgress,TreatGlobalObjectsAsRoots=@treatGlobalObjectsAsRoots,CaptureNumericValue=@captureNumericValue,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TakeHeapSnapshotParams {
/// <summary>
/// If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken.
/// </summary>
[JsonPropertyName("reportProgress")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReportProgress{get;set;}
/// <summary>
/// If true, a raw snapshot without artificial roots will be generated
/// </summary>
[JsonPropertyName("treatGlobalObjectsAsRoots")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? TreatGlobalObjectsAsRoots{get;set;}
/// <summary>
/// If true, numerical values are included in the snapshot
/// </summary>
[JsonPropertyName("captureNumericValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CaptureNumericValue{get;set;}
}
/// <param name="reportProgress">If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken.</param>
/// <param name="treatGlobalObjectsAsRoots">If true, a raw snapshot without artificial roots will be generated</param>
/// <param name="captureNumericValue">If true, numerical values are included in the snapshot</param>
public async Task TakeHeapSnapshot(
 bool? @reportProgress=default,bool? @treatGlobalObjectsAsRoots=default,bool? @captureNumericValue=default) {
var resp = await _target.SendRequest("HeapProfiler.takeHeapSnapshot",
new TakeHeapSnapshotParams {
ReportProgress=@reportProgress,TreatGlobalObjectsAsRoots=@treatGlobalObjectsAsRoots,CaptureNumericValue=@captureNumericValue,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AddHeapSnapshotChunkParams {
[JsonPropertyName("chunk")]public string Chunk{get;set;}
}
private Action<AddHeapSnapshotChunkParams>? _onAddHeapSnapshotChunk;
public event Action<AddHeapSnapshotChunkParams> OnAddHeapSnapshotChunk {
add => _onAddHeapSnapshotChunk += value; remove => _onAddHeapSnapshotChunk -= value;}
public sealed partial class HeapStatsUpdateParams {
/// <summary>
/// An array of triplets. Each triplet describes a fragment. The first integer is the fragment
/// index, the second integer is a total count of objects for the fragment, the third integer is
/// a total size of the objects for the fragment.
/// </summary>
[JsonPropertyName("statsUpdate")]public long[] StatsUpdate{get;set;}
}
private Action<HeapStatsUpdateParams>? _onHeapStatsUpdate;
/// <summary>
/// If heap objects tracking has been started then backend may send update for one or more fragments
/// </summary>
public event Action<HeapStatsUpdateParams> OnHeapStatsUpdate {
add => _onHeapStatsUpdate += value; remove => _onHeapStatsUpdate -= value;}
public sealed partial class LastSeenObjectIdParams {
[JsonPropertyName("lastSeenObjectId")]public long LastSeenObjectId{get;set;}
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
}
private Action<LastSeenObjectIdParams>? _onLastSeenObjectId;
/// <summary>
/// If heap objects tracking has been started then backend regularly sends a current value for last
/// seen object id and corresponding timestamp. If the were changes in the heap since last event
/// then one or more heapStatsUpdate events will be sent before a new lastSeenObjectId event.
/// </summary>
public event Action<LastSeenObjectIdParams> OnLastSeenObjectId {
add => _onLastSeenObjectId += value; remove => _onLastSeenObjectId -= value;}
public sealed partial class ReportHeapSnapshotProgressParams {
[JsonPropertyName("done")]public long Done{get;set;}
[JsonPropertyName("total")]public long Total{get;set;}
[JsonPropertyName("finished")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Finished{get;set;}
}
private Action<ReportHeapSnapshotProgressParams>? _onReportHeapSnapshotProgress;
public event Action<ReportHeapSnapshotProgressParams> OnReportHeapSnapshotProgress {
add => _onReportHeapSnapshotProgress += value; remove => _onReportHeapSnapshotProgress -= value;}
private Action? _onResetProfiles;
public event Action OnResetProfiles {
add => _onResetProfiles += value; remove => _onResetProfiles -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "HeapProfiler.addHeapSnapshotChunk":
_onAddHeapSnapshotChunk?.Invoke(_target.DeserializeEvent<AddHeapSnapshotChunkParams>(data));
break;
case "HeapProfiler.heapStatsUpdate":
_onHeapStatsUpdate?.Invoke(_target.DeserializeEvent<HeapStatsUpdateParams>(data));
break;
case "HeapProfiler.lastSeenObjectId":
_onLastSeenObjectId?.Invoke(_target.DeserializeEvent<LastSeenObjectIdParams>(data));
break;
case "HeapProfiler.reportHeapSnapshotProgress":
_onReportHeapSnapshotProgress?.Invoke(_target.DeserializeEvent<ReportHeapSnapshotProgressParams>(data));
break;
case "HeapProfiler.resetProfiles":
_onResetProfiles?.Invoke();
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
_onAddHeapSnapshotChunk = null;
_onHeapStatsUpdate = null;
_onLastSeenObjectId = null;
_onReportHeapSnapshotProgress = null;
_onResetProfiles = null;
}
}
