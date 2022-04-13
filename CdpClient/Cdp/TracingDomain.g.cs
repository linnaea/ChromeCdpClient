using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class TracingDomain {
private readonly ConnectedTarget _target;
public TracingDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Stop trace events collection.
/// </summary>
public async Task End(
) {
var resp = await _target.SendRequest("Tracing.end",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetCategoriesReturn {
/// <summary>
/// A list of supported tracing categories.
/// </summary>
[JsonPropertyName("categories")]public string[] Categories{get;set;}
}
/// <summary>
/// Gets supported tracing categories.
/// </summary>
public async Task<GetCategoriesReturn> GetCategories(
) {
var resp = await _target.SendRequest("Tracing.getCategories",
VoidData.Instance);
return _target.DeserializeResponse<GetCategoriesReturn>(resp);
}
public sealed partial class RecordClockSyncMarkerParams {
/// <summary>
/// The ID of this clock sync marker
/// </summary>
[JsonPropertyName("syncId")]public string SyncId{get;set;}
}
/// <summary>
/// Record a clock sync marker in the trace.
/// </summary>
/// <param name="syncId">The ID of this clock sync marker</param>
public async Task RecordClockSyncMarker(
 string @syncId) {
var resp = await _target.SendRequest("Tracing.recordClockSyncMarker",
new RecordClockSyncMarkerParams {
SyncId=@syncId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RequestMemoryDumpParams {
/// <summary>
/// Enables more deterministic results by forcing garbage collection
/// </summary>
[JsonPropertyName("deterministic")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Deterministic{get;set;}
/// <summary>
/// Specifies level of details in memory dump. Defaults to "detailed".
/// </summary>
[JsonPropertyName("levelOfDetail")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.MemoryDumpLevelOfDetail? LevelOfDetail{get;set;}
}
public sealed partial class RequestMemoryDumpReturn {
/// <summary>
/// GUID of the resulting global memory dump.
/// </summary>
[JsonPropertyName("dumpGuid")]public string DumpGuid{get;set;}
/// <summary>
/// True iff the global memory dump succeeded.
/// </summary>
[JsonPropertyName("success")]public bool Success{get;set;}
}
/// <summary>
/// Request a global memory dump.
/// </summary>
/// <param name="deterministic">Enables more deterministic results by forcing garbage collection</param>
/// <param name="levelOfDetail">Specifies level of details in memory dump. Defaults to "detailed".</param>
public async Task<RequestMemoryDumpReturn> RequestMemoryDump(
 bool? @deterministic=default,Tracing.MemoryDumpLevelOfDetail? @levelOfDetail=default) {
var resp = await _target.SendRequest("Tracing.requestMemoryDump",
new RequestMemoryDumpParams {
Deterministic=@deterministic,LevelOfDetail=@levelOfDetail,});
return _target.DeserializeResponse<RequestMemoryDumpReturn>(resp);
}
public sealed partial class StartParams {
/// <summary>
/// Category/tag filter
/// </summary>
[Obsolete][JsonPropertyName("categories")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Categories{get;set;}
/// <summary>
/// Tracing options
/// </summary>
[Obsolete][JsonPropertyName("options")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Options{get;set;}
/// <summary>
/// If set, the agent will issue bufferUsage events at this interval, specified in milliseconds
/// </summary>
[JsonPropertyName("bufferUsageReportingInterval")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? BufferUsageReportingInterval{get;set;}
/// <summary>
/// Whether to report trace events as series of dataCollected events or to save trace to a
/// stream (defaults to `ReportEvents`).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TransferModeEnum {
[EnumMember(Value = "ReportEvents")] ReportEvents,
[EnumMember(Value = "ReturnAsStream")] ReturnAsStream,
}
[JsonPropertyName("transferMode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TransferModeEnum? TransferMode{get;set;}
/// <summary>
/// Trace data format to use. This only applies when using `ReturnAsStream`
/// transfer mode (defaults to `json`).
/// </summary>
[JsonPropertyName("streamFormat")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.StreamFormat? StreamFormat{get;set;}
/// <summary>
/// Compression format to use. This only applies when using `ReturnAsStream`
/// transfer mode (defaults to `none`)
/// </summary>
[JsonPropertyName("streamCompression")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.StreamCompression? StreamCompression{get;set;}
[JsonPropertyName("traceConfig")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.TraceConfig? TraceConfig{get;set;}
/// <summary>
/// Base64-encoded serialized perfetto.protos.TraceConfig protobuf message
/// When specified, the parameters `categories`, `options`, `traceConfig`
/// are ignored. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("perfettoConfig")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PerfettoConfig{get;set;}
/// <summary>
/// Backend type (defaults to `auto`)
/// </summary>
[JsonPropertyName("tracingBackend")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.TracingBackend? TracingBackend{get;set;}
}
/// <summary>
/// Start trace events collection.
/// </summary>
/// <param name="categories">OBSOLETE Category/tag filter</param>
/// <param name="options">OBSOLETE Tracing options</param>
/// <param name="bufferUsageReportingInterval">If set, the agent will issue bufferUsage events at this interval, specified in milliseconds</param>
/// <param name="transferMode">Whether to report trace events as series of dataCollected events or to save trace to a
/// stream (defaults to `ReportEvents`).</param>
/// <param name="streamFormat">Trace data format to use. This only applies when using `ReturnAsStream`
/// transfer mode (defaults to `json`).</param>
/// <param name="streamCompression">Compression format to use. This only applies when using `ReturnAsStream`
/// transfer mode (defaults to `none`)</param>
/// <param name="traceConfig"></param>
/// <param name="perfettoConfig">Base64-encoded serialized perfetto.protos.TraceConfig protobuf message
/// When specified, the parameters `categories`, `options`, `traceConfig`
/// are ignored. (Encoded as a base64 string when passed over JSON)</param>
/// <param name="tracingBackend">Backend type (defaults to `auto`)</param>
public async Task Start(
 string? @categories=default,string? @options=default,double? @bufferUsageReportingInterval=default,StartParams.TransferModeEnum? @transferMode=default,Tracing.StreamFormat? @streamFormat=default,Tracing.StreamCompression? @streamCompression=default,Tracing.TraceConfig? @traceConfig=default,string? @perfettoConfig=default,Tracing.TracingBackend? @tracingBackend=default) {
var resp = await _target.SendRequest("Tracing.start",
new StartParams {
Categories=@categories,Options=@options,BufferUsageReportingInterval=@bufferUsageReportingInterval,TransferMode=@transferMode,StreamFormat=@streamFormat,StreamCompression=@streamCompression,TraceConfig=@traceConfig,PerfettoConfig=@perfettoConfig,TracingBackend=@tracingBackend,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class BufferUsageParams {
/// <summary>
/// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
/// total size.
/// </summary>
[JsonPropertyName("percentFull")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? PercentFull{get;set;}
/// <summary>
/// An approximate number of events in the trace log.
/// </summary>
[JsonPropertyName("eventCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? EventCount{get;set;}
/// <summary>
/// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
/// total size.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Value{get;set;}
}
private Action<BufferUsageParams>? _onBufferUsage;
public event Action<BufferUsageParams> OnBufferUsage {
add => _onBufferUsage += value; remove => _onBufferUsage -= value;}
public sealed partial class DataCollectedParams {
[JsonPropertyName("value")]public object[] Value{get;set;}
}
private Action<DataCollectedParams>? _onDataCollected;
/// <summary>
/// Contains an bucket of collected trace events. When tracing is stopped collected events will be
/// send as a sequence of dataCollected events followed by tracingComplete event.
/// </summary>
public event Action<DataCollectedParams> OnDataCollected {
add => _onDataCollected += value; remove => _onDataCollected -= value;}
public sealed partial class TracingCompleteParams {
/// <summary>
/// Indicates whether some trace data is known to have been lost, e.g. because the trace ring
/// buffer wrapped around.
/// </summary>
[JsonPropertyName("dataLossOccurred")]public bool DataLossOccurred{get;set;}
/// <summary>
/// A handle of the stream that holds resulting trace data.
/// </summary>
[JsonPropertyName("stream")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IO.StreamHandle? Stream{get;set;}
/// <summary>
/// Trace data format of returned stream.
/// </summary>
[JsonPropertyName("traceFormat")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.StreamFormat? TraceFormat{get;set;}
/// <summary>
/// Compression format of returned stream.
/// </summary>
[JsonPropertyName("streamCompression")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Tracing.StreamCompression? StreamCompression{get;set;}
}
private Action<TracingCompleteParams>? _onTracingComplete;
/// <summary>
/// Signals that tracing is stopped and there is no trace buffers pending flush, all data were
/// delivered via dataCollected events.
/// </summary>
public event Action<TracingCompleteParams> OnTracingComplete {
add => _onTracingComplete += value; remove => _onTracingComplete -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Tracing.bufferUsage":
_onBufferUsage?.Invoke(_target.DeserializeEvent<BufferUsageParams>(data));
break;
case "Tracing.dataCollected":
_onDataCollected?.Invoke(_target.DeserializeEvent<DataCollectedParams>(data));
break;
case "Tracing.tracingComplete":
_onTracingComplete?.Invoke(_target.DeserializeEvent<TracingCompleteParams>(data));
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
_onBufferUsage = null;
_onDataCollected = null;
_onTracingComplete = null;
}
}
