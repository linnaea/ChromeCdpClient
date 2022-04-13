using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Debugger domain exposes JavaScript debugging capabilities. It allows setting and removing
/// breakpoints, stepping through execution, exploring stack traces, etc.
/// </summary>
public sealed partial class DebuggerDomain {
private readonly ConnectedTarget _target;
public DebuggerDomain(ConnectedTarget target) => _target = target;
public sealed partial class ContinueToLocationParams {
/// <summary>
/// Location to continue to.
/// </summary>
[JsonPropertyName("location")]public Debugger.Location Location{get;set;}
[JsonConverter(typeof(StringEnumConverter))] public enum TargetCallFramesEnum {
[EnumMember(Value = "any")] Any,
[EnumMember(Value = "current")] Current,
}
[JsonPropertyName("targetCallFrames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TargetCallFramesEnum? TargetCallFrames{get;set;}
}
/// <summary>
/// Continues execution until specific location is reached.
/// </summary>
/// <param name="location">Location to continue to.</param>
/// <param name="targetCallFrames"></param>
public async Task ContinueToLocation(
 Debugger.Location @location,ContinueToLocationParams.TargetCallFramesEnum? @targetCallFrames=default) {
var resp = await _target.SendRequest("Debugger.continueToLocation",
new ContinueToLocationParams {
Location=@location,TargetCallFrames=@targetCallFrames,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables debugger for given page.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Debugger.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EnableParams {
/// <summary>
/// The maximum size in bytes of collected scripts (not referenced by other heap objects)
/// the debugger can hold. Puts no limit if parameter is omitted.
/// </summary>
[Experimental][JsonPropertyName("maxScriptsCacheSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MaxScriptsCacheSize{get;set;}
}
public sealed partial class EnableReturn {
/// <summary>
/// Unique identifier of the debugger.
/// </summary>
[Experimental][JsonPropertyName("debuggerId")]public Runtime.UniqueDebuggerId DebuggerId{get;set;}
}
/// <summary>
/// Enables debugger for the given page. Clients should not assume that the debugging has been
/// enabled until the result for this command is received.
/// </summary>
/// <param name="maxScriptsCacheSize">EXPERIMENTAL The maximum size in bytes of collected scripts (not referenced by other heap objects)
/// the debugger can hold. Puts no limit if parameter is omitted.</param>
public async Task<EnableReturn> Enable(
 double? @maxScriptsCacheSize=default) {
var resp = await _target.SendRequest("Debugger.enable",
new EnableParams {
MaxScriptsCacheSize=@maxScriptsCacheSize,});
return _target.DeserializeResponse<EnableReturn>(resp);
}
public sealed partial class EvaluateOnCallFrameParams {
/// <summary>
/// Call frame identifier to evaluate on.
/// </summary>
[JsonPropertyName("callFrameId")]public Debugger.CallFrameId CallFrameId{get;set;}
/// <summary>
/// Expression to evaluate.
/// </summary>
[JsonPropertyName("expression")]public string Expression{get;set;}
/// <summary>
/// String object group name to put result into (allows rapid releasing resulting object handles
/// using `releaseObjectGroup`).
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
/// <summary>
/// Specifies whether command line API should be available to the evaluated expression, defaults
/// to false.
/// </summary>
[JsonPropertyName("includeCommandLineAPI")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeCommandLineAPI{get;set;}
/// <summary>
/// In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.
/// </summary>
[JsonPropertyName("silent")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Silent{get;set;}
/// <summary>
/// Whether the result is expected to be a JSON object that should be sent by value.
/// </summary>
[JsonPropertyName("returnByValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReturnByValue{get;set;}
/// <summary>
/// Whether preview should be generated for the result.
/// </summary>
[Experimental][JsonPropertyName("generatePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GeneratePreview{get;set;}
/// <summary>
/// Whether to throw an exception if side effect cannot be ruled out during evaluation.
/// </summary>
[JsonPropertyName("throwOnSideEffect")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ThrowOnSideEffect{get;set;}
/// <summary>
/// Terminate execution after timing out (number of milliseconds).
/// </summary>
[Experimental][JsonPropertyName("timeout")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.TimeDelta? Timeout{get;set;}
}
public sealed partial class EvaluateOnCallFrameReturn {
/// <summary>
/// Object wrapper for the evaluation result.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Evaluates expression on a given call frame.
/// </summary>
/// <param name="callFrameId">Call frame identifier to evaluate on.</param>
/// <param name="expression">Expression to evaluate.</param>
/// <param name="objectGroup">String object group name to put result into (allows rapid releasing resulting object handles
/// using `releaseObjectGroup`).</param>
/// <param name="includeCommandLineAPI">Specifies whether command line API should be available to the evaluated expression, defaults
/// to false.</param>
/// <param name="silent">In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.</param>
/// <param name="returnByValue">Whether the result is expected to be a JSON object that should be sent by value.</param>
/// <param name="generatePreview">EXPERIMENTAL Whether preview should be generated for the result.</param>
/// <param name="throwOnSideEffect">Whether to throw an exception if side effect cannot be ruled out during evaluation.</param>
/// <param name="timeout">EXPERIMENTAL Terminate execution after timing out (number of milliseconds).</param>
public async Task<EvaluateOnCallFrameReturn> EvaluateOnCallFrame(
 Debugger.CallFrameId @callFrameId,string @expression,string? @objectGroup=default,bool? @includeCommandLineAPI=default,bool? @silent=default,bool? @returnByValue=default,bool? @generatePreview=default,bool? @throwOnSideEffect=default,Runtime.TimeDelta? @timeout=default) {
var resp = await _target.SendRequest("Debugger.evaluateOnCallFrame",
new EvaluateOnCallFrameParams {
CallFrameId=@callFrameId,Expression=@expression,ObjectGroup=@objectGroup,IncludeCommandLineAPI=@includeCommandLineAPI,Silent=@silent,ReturnByValue=@returnByValue,GeneratePreview=@generatePreview,ThrowOnSideEffect=@throwOnSideEffect,Timeout=@timeout,});
return _target.DeserializeResponse<EvaluateOnCallFrameReturn>(resp);
}
public sealed partial class GetPossibleBreakpointsParams {
/// <summary>
/// Start of range to search possible breakpoint locations in.
/// </summary>
[JsonPropertyName("start")]public Debugger.Location Start{get;set;}
/// <summary>
/// End of range to search possible breakpoint locations in (excluding). When not specified, end
/// of scripts is used as end of range.
/// </summary>
[JsonPropertyName("end")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.Location? End{get;set;}
/// <summary>
/// Only consider locations which are in the same (non-nested) function as start.
/// </summary>
[JsonPropertyName("restrictToFunction")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? RestrictToFunction{get;set;}
}
public sealed partial class GetPossibleBreakpointsReturn {
/// <summary>
/// List of the possible breakpoint locations.
/// </summary>
[JsonPropertyName("locations")]public Debugger.BreakLocation[] Locations{get;set;}
}
/// <summary>
/// Returns possible locations for breakpoint. scriptId in start and end range locations should be
/// the same.
/// </summary>
/// <param name="start">Start of range to search possible breakpoint locations in.</param>
/// <param name="end">End of range to search possible breakpoint locations in (excluding). When not specified, end
/// of scripts is used as end of range.</param>
/// <param name="restrictToFunction">Only consider locations which are in the same (non-nested) function as start.</param>
public async Task<GetPossibleBreakpointsReturn> GetPossibleBreakpoints(
 Debugger.Location @start,Debugger.Location? @end=default,bool? @restrictToFunction=default) {
var resp = await _target.SendRequest("Debugger.getPossibleBreakpoints",
new GetPossibleBreakpointsParams {
Start=@start,End=@end,RestrictToFunction=@restrictToFunction,});
return _target.DeserializeResponse<GetPossibleBreakpointsReturn>(resp);
}
public sealed partial class GetScriptSourceParams {
/// <summary>
/// Id of the script to get source for.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
}
public sealed partial class GetScriptSourceReturn {
/// <summary>
/// Script source (empty in case of Wasm bytecode).
/// </summary>
[JsonPropertyName("scriptSource")]public string ScriptSource{get;set;}
/// <summary>
/// Wasm bytecode. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("bytecode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Bytecode{get;set;}
}
/// <summary>
/// Returns source for the script with given id.
/// </summary>
/// <param name="scriptId">Id of the script to get source for.</param>
public async Task<GetScriptSourceReturn> GetScriptSource(
 Runtime.ScriptId @scriptId) {
var resp = await _target.SendRequest("Debugger.getScriptSource",
new GetScriptSourceParams {
ScriptId=@scriptId,});
return _target.DeserializeResponse<GetScriptSourceReturn>(resp);
}
public sealed partial class GetWasmBytecodeParams {
/// <summary>
/// Id of the Wasm script to get source for.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
}
public sealed partial class GetWasmBytecodeReturn {
/// <summary>
/// Script source. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("bytecode")]public string Bytecode{get;set;}
}
/// <summary>
/// This command is deprecated. Use getScriptSource instead.
/// </summary>
/// <param name="scriptId">Id of the Wasm script to get source for.</param>
[Obsolete]public async Task<GetWasmBytecodeReturn> GetWasmBytecode(
 Runtime.ScriptId @scriptId) {
var resp = await _target.SendRequest("Debugger.getWasmBytecode",
new GetWasmBytecodeParams {
ScriptId=@scriptId,});
return _target.DeserializeResponse<GetWasmBytecodeReturn>(resp);
}
public sealed partial class GetStackTraceParams {
[JsonPropertyName("stackTraceId")]public Runtime.StackTraceId StackTraceId{get;set;}
}
public sealed partial class GetStackTraceReturn {
[JsonPropertyName("stackTrace")]public Runtime.StackTrace StackTrace{get;set;}
}
/// <summary>
/// Returns stack trace with given `stackTraceId`.
/// </summary>
/// <param name="stackTraceId"></param>
[Experimental]public async Task<GetStackTraceReturn> GetStackTrace(
 Runtime.StackTraceId @stackTraceId) {
var resp = await _target.SendRequest("Debugger.getStackTrace",
new GetStackTraceParams {
StackTraceId=@stackTraceId,});
return _target.DeserializeResponse<GetStackTraceReturn>(resp);
}
/// <summary>
/// Stops on the next JavaScript statement.
/// </summary>
public async Task Pause(
) {
var resp = await _target.SendRequest("Debugger.pause",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class PauseOnAsyncCallParams {
/// <summary>
/// Debugger will pause when async call with given stack trace is started.
/// </summary>
[JsonPropertyName("parentStackTraceId")]public Runtime.StackTraceId ParentStackTraceId{get;set;}
}
/// <param name="parentStackTraceId">Debugger will pause when async call with given stack trace is started.</param>
[Experimental][Obsolete]public async Task PauseOnAsyncCall(
 Runtime.StackTraceId @parentStackTraceId) {
var resp = await _target.SendRequest("Debugger.pauseOnAsyncCall",
new PauseOnAsyncCallParams {
ParentStackTraceId=@parentStackTraceId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveBreakpointParams {
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
}
/// <summary>
/// Removes JavaScript breakpoint.
/// </summary>
/// <param name="breakpointId"></param>
public async Task RemoveBreakpoint(
 Debugger.BreakpointId @breakpointId) {
var resp = await _target.SendRequest("Debugger.removeBreakpoint",
new RemoveBreakpointParams {
BreakpointId=@breakpointId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RestartFrameParams {
/// <summary>
/// Call frame identifier to evaluate on.
/// </summary>
[JsonPropertyName("callFrameId")]public Debugger.CallFrameId CallFrameId{get;set;}
}
public sealed partial class RestartFrameReturn {
/// <summary>
/// New stack trace.
/// </summary>
[JsonPropertyName("callFrames")]public Debugger.CallFrame[] CallFrames{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[JsonPropertyName("asyncStackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? AsyncStackTrace{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[Experimental][JsonPropertyName("asyncStackTraceId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTraceId? AsyncStackTraceId{get;set;}
}
/// <summary>
/// Restarts particular call frame from the beginning.
/// </summary>
/// <param name="callFrameId">Call frame identifier to evaluate on.</param>
[Obsolete]public async Task<RestartFrameReturn> RestartFrame(
 Debugger.CallFrameId @callFrameId) {
var resp = await _target.SendRequest("Debugger.restartFrame",
new RestartFrameParams {
CallFrameId=@callFrameId,});
return _target.DeserializeResponse<RestartFrameReturn>(resp);
}
public sealed partial class ResumeParams {
/// <summary>
/// Set to true to terminate execution upon resuming execution. In contrast
/// to Runtime.terminateExecution, this will allows to execute further
/// JavaScript (i.e. via evaluation) until execution of the paused code
/// is actually resumed, at which point termination is triggered.
/// If execution is currently not paused, this parameter has no effect.
/// </summary>
[JsonPropertyName("terminateOnResume")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? TerminateOnResume{get;set;}
}
/// <summary>
/// Resumes JavaScript execution.
/// </summary>
/// <param name="terminateOnResume">Set to true to terminate execution upon resuming execution. In contrast
/// to Runtime.terminateExecution, this will allows to execute further
/// JavaScript (i.e. via evaluation) until execution of the paused code
/// is actually resumed, at which point termination is triggered.
/// If execution is currently not paused, this parameter has no effect.</param>
public async Task Resume(
 bool? @terminateOnResume=default) {
var resp = await _target.SendRequest("Debugger.resume",
new ResumeParams {
TerminateOnResume=@terminateOnResume,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SearchInContentParams {
/// <summary>
/// Id of the script to search in.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// String to search for.
/// </summary>
[JsonPropertyName("query")]public string Query{get;set;}
/// <summary>
/// If true, search is case sensitive.
/// </summary>
[JsonPropertyName("caseSensitive")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CaseSensitive{get;set;}
/// <summary>
/// If true, treats string parameter as regex.
/// </summary>
[JsonPropertyName("isRegex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsRegex{get;set;}
}
public sealed partial class SearchInContentReturn {
/// <summary>
/// List of search matches.
/// </summary>
[JsonPropertyName("result")]public Debugger.SearchMatch[] Result{get;set;}
}
/// <summary>
/// Searches for given string in script content.
/// </summary>
/// <param name="scriptId">Id of the script to search in.</param>
/// <param name="query">String to search for.</param>
/// <param name="caseSensitive">If true, search is case sensitive.</param>
/// <param name="isRegex">If true, treats string parameter as regex.</param>
public async Task<SearchInContentReturn> SearchInContent(
 Runtime.ScriptId @scriptId,string @query,bool? @caseSensitive=default,bool? @isRegex=default) {
var resp = await _target.SendRequest("Debugger.searchInContent",
new SearchInContentParams {
ScriptId=@scriptId,Query=@query,CaseSensitive=@caseSensitive,IsRegex=@isRegex,});
return _target.DeserializeResponse<SearchInContentReturn>(resp);
}
public sealed partial class SetAsyncCallStackDepthParams {
/// <summary>
/// Maximum depth of async call stacks. Setting to `0` will effectively disable collecting async
/// call stacks (default).
/// </summary>
[JsonPropertyName("maxDepth")]public long MaxDepth{get;set;}
}
/// <summary>
/// Enables or disables async call stacks tracking.
/// </summary>
/// <param name="maxDepth">Maximum depth of async call stacks. Setting to `0` will effectively disable collecting async
/// call stacks (default).</param>
public async Task SetAsyncCallStackDepth(
 long @maxDepth) {
var resp = await _target.SendRequest("Debugger.setAsyncCallStackDepth",
new SetAsyncCallStackDepthParams {
MaxDepth=@maxDepth,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBlackboxPatternsParams {
/// <summary>
/// Array of regexps that will be used to check script url for blackbox state.
/// </summary>
[JsonPropertyName("patterns")]public string[] Patterns{get;set;}
}
/// <summary>
/// Replace previous blackbox patterns with passed ones. Forces backend to skip stepping/pausing in
/// scripts with url matching one of the patterns. VM will try to leave blackboxed script by
/// performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
/// </summary>
/// <param name="patterns">Array of regexps that will be used to check script url for blackbox state.</param>
[Experimental]public async Task SetBlackboxPatterns(
 string[] @patterns) {
var resp = await _target.SendRequest("Debugger.setBlackboxPatterns",
new SetBlackboxPatternsParams {
Patterns=@patterns,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBlackboxedRangesParams {
/// <summary>
/// Id of the script.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
[JsonPropertyName("positions")]public Debugger.ScriptPosition[] Positions{get;set;}
}
/// <summary>
/// Makes backend skip steps in the script in blackboxed ranges. VM will try leave blacklisted
/// scripts by performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
/// Positions array contains positions where blackbox state is changed. First interval isn't
/// blackboxed. Array should be sorted.
/// </summary>
/// <param name="scriptId">Id of the script.</param>
/// <param name="positions"></param>
[Experimental]public async Task SetBlackboxedRanges(
 Runtime.ScriptId @scriptId,Debugger.ScriptPosition[] @positions) {
var resp = await _target.SendRequest("Debugger.setBlackboxedRanges",
new SetBlackboxedRangesParams {
ScriptId=@scriptId,Positions=@positions,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBreakpointParams {
/// <summary>
/// Location to set breakpoint in.
/// </summary>
[JsonPropertyName("location")]public Debugger.Location Location{get;set;}
/// <summary>
/// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
/// breakpoint if this expression evaluates to true.
/// </summary>
[JsonPropertyName("condition")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Condition{get;set;}
}
public sealed partial class SetBreakpointReturn {
/// <summary>
/// Id of the created breakpoint for further reference.
/// </summary>
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
/// <summary>
/// Location this breakpoint resolved into.
/// </summary>
[JsonPropertyName("actualLocation")]public Debugger.Location ActualLocation{get;set;}
}
/// <summary>
/// Sets JavaScript breakpoint at a given location.
/// </summary>
/// <param name="location">Location to set breakpoint in.</param>
/// <param name="condition">Expression to use as a breakpoint condition. When specified, debugger will only stop on the
/// breakpoint if this expression evaluates to true.</param>
public async Task<SetBreakpointReturn> SetBreakpoint(
 Debugger.Location @location,string? @condition=default) {
var resp = await _target.SendRequest("Debugger.setBreakpoint",
new SetBreakpointParams {
Location=@location,Condition=@condition,});
return _target.DeserializeResponse<SetBreakpointReturn>(resp);
}
public sealed partial class SetInstrumentationBreakpointParams {
/// <summary>
/// Instrumentation name.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum InstrumentationEnum {
[EnumMember(Value = "beforeScriptExecution")] BeforeScriptExecution,
[EnumMember(Value = "beforeScriptWithSourceMapExecution")] BeforeScriptWithSourceMapExecution,
}
[JsonPropertyName("instrumentation")]public InstrumentationEnum Instrumentation{get;set;}
}
public sealed partial class SetInstrumentationBreakpointReturn {
/// <summary>
/// Id of the created breakpoint for further reference.
/// </summary>
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
}
/// <summary>
/// Sets instrumentation breakpoint.
/// </summary>
/// <param name="instrumentation">Instrumentation name.</param>
public async Task<SetInstrumentationBreakpointReturn> SetInstrumentationBreakpoint(
 SetInstrumentationBreakpointParams.InstrumentationEnum @instrumentation) {
var resp = await _target.SendRequest("Debugger.setInstrumentationBreakpoint",
new SetInstrumentationBreakpointParams {
Instrumentation=@instrumentation,});
return _target.DeserializeResponse<SetInstrumentationBreakpointReturn>(resp);
}
public sealed partial class SetBreakpointByUrlParams {
/// <summary>
/// Line number to set breakpoint at.
/// </summary>
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
/// <summary>
/// URL of the resources to set breakpoint on.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// Regex pattern for the URLs of the resources to set breakpoints on. Either `url` or
/// `urlRegex` must be specified.
/// </summary>
[JsonPropertyName("urlRegex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UrlRegex{get;set;}
/// <summary>
/// Script hash of the resources to set breakpoint on.
/// </summary>
[JsonPropertyName("scriptHash")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ScriptHash{get;set;}
/// <summary>
/// Offset in the line to set breakpoint at.
/// </summary>
[JsonPropertyName("columnNumber")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ColumnNumber{get;set;}
/// <summary>
/// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
/// breakpoint if this expression evaluates to true.
/// </summary>
[JsonPropertyName("condition")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Condition{get;set;}
}
public sealed partial class SetBreakpointByUrlReturn {
/// <summary>
/// Id of the created breakpoint for further reference.
/// </summary>
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
/// <summary>
/// List of the locations this breakpoint resolved into upon addition.
/// </summary>
[JsonPropertyName("locations")]public Debugger.Location[] Locations{get;set;}
}
/// <summary>
/// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
/// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
/// `locations` property. Further matching script parsing will result in subsequent
/// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
/// </summary>
/// <param name="lineNumber">Line number to set breakpoint at.</param>
/// <param name="url">URL of the resources to set breakpoint on.</param>
/// <param name="urlRegex">Regex pattern for the URLs of the resources to set breakpoints on. Either `url` or
/// `urlRegex` must be specified.</param>
/// <param name="scriptHash">Script hash of the resources to set breakpoint on.</param>
/// <param name="columnNumber">Offset in the line to set breakpoint at.</param>
/// <param name="condition">Expression to use as a breakpoint condition. When specified, debugger will only stop on the
/// breakpoint if this expression evaluates to true.</param>
public async Task<SetBreakpointByUrlReturn> SetBreakpointByUrl(
 long @lineNumber,string? @url=default,string? @urlRegex=default,string? @scriptHash=default,long? @columnNumber=default,string? @condition=default) {
var resp = await _target.SendRequest("Debugger.setBreakpointByUrl",
new SetBreakpointByUrlParams {
LineNumber=@lineNumber,Url=@url,UrlRegex=@urlRegex,ScriptHash=@scriptHash,ColumnNumber=@columnNumber,Condition=@condition,});
return _target.DeserializeResponse<SetBreakpointByUrlReturn>(resp);
}
public sealed partial class SetBreakpointOnFunctionCallParams {
/// <summary>
/// Function object id.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
/// <summary>
/// Expression to use as a breakpoint condition. When specified, debugger will
/// stop on the breakpoint if this expression evaluates to true.
/// </summary>
[JsonPropertyName("condition")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Condition{get;set;}
}
public sealed partial class SetBreakpointOnFunctionCallReturn {
/// <summary>
/// Id of the created breakpoint for further reference.
/// </summary>
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
}
/// <summary>
/// Sets JavaScript breakpoint before each call to the given function.
/// If another function was created from the same source as a given one,
/// calling it will also trigger the breakpoint.
/// </summary>
/// <param name="objectId">Function object id.</param>
/// <param name="condition">Expression to use as a breakpoint condition. When specified, debugger will
/// stop on the breakpoint if this expression evaluates to true.</param>
[Experimental]public async Task<SetBreakpointOnFunctionCallReturn> SetBreakpointOnFunctionCall(
 Runtime.RemoteObjectId @objectId,string? @condition=default) {
var resp = await _target.SendRequest("Debugger.setBreakpointOnFunctionCall",
new SetBreakpointOnFunctionCallParams {
ObjectId=@objectId,Condition=@condition,});
return _target.DeserializeResponse<SetBreakpointOnFunctionCallReturn>(resp);
}
public sealed partial class SetBreakpointsActiveParams {
/// <summary>
/// New value for breakpoints active state.
/// </summary>
[JsonPropertyName("active")]public bool Active{get;set;}
}
/// <summary>
/// Activates / deactivates all breakpoints on the page.
/// </summary>
/// <param name="active">New value for breakpoints active state.</param>
public async Task SetBreakpointsActive(
 bool @active) {
var resp = await _target.SendRequest("Debugger.setBreakpointsActive",
new SetBreakpointsActiveParams {
Active=@active,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPauseOnExceptionsParams {
/// <summary>
/// Pause on exceptions mode.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StateEnum {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "uncaught")] Uncaught,
[EnumMember(Value = "all")] All,
}
[JsonPropertyName("state")]public StateEnum State{get;set;}
}
/// <summary>
/// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or
/// no exceptions. Initial pause on exceptions state is `none`.
/// </summary>
/// <param name="state">Pause on exceptions mode.</param>
public async Task SetPauseOnExceptions(
 SetPauseOnExceptionsParams.StateEnum @state) {
var resp = await _target.SendRequest("Debugger.setPauseOnExceptions",
new SetPauseOnExceptionsParams {
State=@state,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetReturnValueParams {
/// <summary>
/// New return value.
/// </summary>
[JsonPropertyName("newValue")]public Runtime.CallArgument NewValue{get;set;}
}
/// <summary>
/// Changes return value in top frame. Available only at return break position.
/// </summary>
/// <param name="newValue">New return value.</param>
[Experimental]public async Task SetReturnValue(
 Runtime.CallArgument @newValue) {
var resp = await _target.SendRequest("Debugger.setReturnValue",
new SetReturnValueParams {
NewValue=@newValue,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetScriptSourceParams {
/// <summary>
/// Id of the script to edit.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// New content of the script.
/// </summary>
[JsonPropertyName("scriptSource")]public string ScriptSource{get;set;}
/// <summary>
/// If true the change will not actually be applied. Dry run may be used to get result
/// description without actually modifying the code.
/// </summary>
[JsonPropertyName("dryRun")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DryRun{get;set;}
}
public sealed partial class SetScriptSourceReturn {
/// <summary>
/// New stack trace in case editing has happened while VM was stopped.
/// </summary>
[JsonPropertyName("callFrames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.CallFrame[]? CallFrames{get;set;}
/// <summary>
/// Whether current call stack  was modified after applying the changes.
/// </summary>
[JsonPropertyName("stackChanged")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? StackChanged{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[JsonPropertyName("asyncStackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? AsyncStackTrace{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[Experimental][JsonPropertyName("asyncStackTraceId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTraceId? AsyncStackTraceId{get;set;}
/// <summary>
/// Exception details if any.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Edits JavaScript source live.
/// </summary>
/// <param name="scriptId">Id of the script to edit.</param>
/// <param name="scriptSource">New content of the script.</param>
/// <param name="dryRun">If true the change will not actually be applied. Dry run may be used to get result
/// description without actually modifying the code.</param>
public async Task<SetScriptSourceReturn> SetScriptSource(
 Runtime.ScriptId @scriptId,string @scriptSource,bool? @dryRun=default) {
var resp = await _target.SendRequest("Debugger.setScriptSource",
new SetScriptSourceParams {
ScriptId=@scriptId,ScriptSource=@scriptSource,DryRun=@dryRun,});
return _target.DeserializeResponse<SetScriptSourceReturn>(resp);
}
public sealed partial class SetSkipAllPausesParams {
/// <summary>
/// New value for skip pauses state.
/// </summary>
[JsonPropertyName("skip")]public bool Skip{get;set;}
}
/// <summary>
/// Makes page not interrupt on any pauses (breakpoint, exception, dom exception etc).
/// </summary>
/// <param name="skip">New value for skip pauses state.</param>
public async Task SetSkipAllPauses(
 bool @skip) {
var resp = await _target.SendRequest("Debugger.setSkipAllPauses",
new SetSkipAllPausesParams {
Skip=@skip,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetVariableValueParams {
/// <summary>
/// 0-based number of scope as was listed in scope chain. Only 'local', 'closure' and 'catch'
/// scope types are allowed. Other scopes could be manipulated manually.
/// </summary>
[JsonPropertyName("scopeNumber")]public long ScopeNumber{get;set;}
/// <summary>
/// Variable name.
/// </summary>
[JsonPropertyName("variableName")]public string VariableName{get;set;}
/// <summary>
/// New variable value.
/// </summary>
[JsonPropertyName("newValue")]public Runtime.CallArgument NewValue{get;set;}
/// <summary>
/// Id of callframe that holds variable.
/// </summary>
[JsonPropertyName("callFrameId")]public Debugger.CallFrameId CallFrameId{get;set;}
}
/// <summary>
/// Changes value of variable in a callframe. Object-based scopes are not supported and must be
/// mutated manually.
/// </summary>
/// <param name="scopeNumber">0-based number of scope as was listed in scope chain. Only 'local', 'closure' and 'catch'
/// scope types are allowed. Other scopes could be manipulated manually.</param>
/// <param name="variableName">Variable name.</param>
/// <param name="newValue">New variable value.</param>
/// <param name="callFrameId">Id of callframe that holds variable.</param>
public async Task SetVariableValue(
 long @scopeNumber,string @variableName,Runtime.CallArgument @newValue,Debugger.CallFrameId @callFrameId) {
var resp = await _target.SendRequest("Debugger.setVariableValue",
new SetVariableValueParams {
ScopeNumber=@scopeNumber,VariableName=@variableName,NewValue=@newValue,CallFrameId=@callFrameId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StepIntoParams {
/// <summary>
/// Debugger will pause on the execution of the first async task which was scheduled
/// before next pause.
/// </summary>
[Experimental][JsonPropertyName("breakOnAsyncCall")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? BreakOnAsyncCall{get;set;}
/// <summary>
/// The skipList specifies location ranges that should be skipped on step into.
/// </summary>
[Experimental][JsonPropertyName("skipList")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.LocationRange[]? SkipList{get;set;}
}
/// <summary>
/// Steps into the function call.
/// </summary>
/// <param name="breakOnAsyncCall">EXPERIMENTAL Debugger will pause on the execution of the first async task which was scheduled
/// before next pause.</param>
/// <param name="skipList">EXPERIMENTAL The skipList specifies location ranges that should be skipped on step into.</param>
public async Task StepInto(
 bool? @breakOnAsyncCall=default,Debugger.LocationRange[]? @skipList=default) {
var resp = await _target.SendRequest("Debugger.stepInto",
new StepIntoParams {
BreakOnAsyncCall=@breakOnAsyncCall,SkipList=@skipList,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Steps out of the function call.
/// </summary>
public async Task StepOut(
) {
var resp = await _target.SendRequest("Debugger.stepOut",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StepOverParams {
/// <summary>
/// The skipList specifies location ranges that should be skipped on step over.
/// </summary>
[Experimental][JsonPropertyName("skipList")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.LocationRange[]? SkipList{get;set;}
}
/// <summary>
/// Steps over the statement.
/// </summary>
/// <param name="skipList">EXPERIMENTAL The skipList specifies location ranges that should be skipped on step over.</param>
public async Task StepOver(
 Debugger.LocationRange[]? @skipList=default) {
var resp = await _target.SendRequest("Debugger.stepOver",
new StepOverParams {
SkipList=@skipList,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class BreakpointResolvedParams {
/// <summary>
/// Breakpoint unique identifier.
/// </summary>
[JsonPropertyName("breakpointId")]public Debugger.BreakpointId BreakpointId{get;set;}
/// <summary>
/// Actual breakpoint location.
/// </summary>
[JsonPropertyName("location")]public Debugger.Location Location{get;set;}
}
private Action<BreakpointResolvedParams>? _onBreakpointResolved;
/// <summary>
/// Fired when breakpoint is resolved to an actual script and location.
/// </summary>
public event Action<BreakpointResolvedParams> OnBreakpointResolved {
add => _onBreakpointResolved += value; remove => _onBreakpointResolved -= value;}
public sealed partial class PausedParams {
/// <summary>
/// Call stack the virtual machine stopped on.
/// </summary>
[JsonPropertyName("callFrames")]public Debugger.CallFrame[] CallFrames{get;set;}
/// <summary>
/// Pause reason.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ReasonEnum {
[EnumMember(Value = "ambiguous")] Ambiguous,
[EnumMember(Value = "assert")] Assert,
[EnumMember(Value = "CSPViolation")] CSPViolation,
[EnumMember(Value = "debugCommand")] DebugCommand,
[EnumMember(Value = "DOM")] DOM,
[EnumMember(Value = "EventListener")] EventListener,
[EnumMember(Value = "exception")] Exception,
[EnumMember(Value = "instrumentation")] Instrumentation,
[EnumMember(Value = "OOM")] OOM,
[EnumMember(Value = "other")] Other,
[EnumMember(Value = "promiseRejection")] PromiseRejection,
[EnumMember(Value = "XHR")] XHR,
}
[JsonPropertyName("reason")]public ReasonEnum Reason{get;set;}
/// <summary>
/// Object containing break-specific auxiliary properties.
/// </summary>
[JsonPropertyName("data")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? Data{get;set;}
/// <summary>
/// Hit breakpoints IDs
/// </summary>
[JsonPropertyName("hitBreakpoints")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? HitBreakpoints{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[JsonPropertyName("asyncStackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? AsyncStackTrace{get;set;}
/// <summary>
/// Async stack trace, if any.
/// </summary>
[Experimental][JsonPropertyName("asyncStackTraceId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTraceId? AsyncStackTraceId{get;set;}
/// <summary>
/// Never present, will be removed.
/// </summary>
[Experimental][Obsolete][JsonPropertyName("asyncCallStackTraceId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTraceId? AsyncCallStackTraceId{get;set;}
}
private Action<PausedParams>? _onPaused;
/// <summary>
/// Fired when the virtual machine stopped on breakpoint or exception or any other stop criteria.
/// </summary>
public event Action<PausedParams> OnPaused {
add => _onPaused += value; remove => _onPaused -= value;}
private Action? _onResumed;
/// <summary>
/// Fired when the virtual machine resumed execution.
/// </summary>
public event Action OnResumed {
add => _onResumed += value; remove => _onResumed -= value;}
public sealed partial class ScriptFailedToParseParams {
/// <summary>
/// Identifier of the script parsed.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// URL or name of the script parsed (if any).
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Line offset of the script within the resource with given URL (for script tags).
/// </summary>
[JsonPropertyName("startLine")]public long StartLine{get;set;}
/// <summary>
/// Column offset of the script within the resource with given URL.
/// </summary>
[JsonPropertyName("startColumn")]public long StartColumn{get;set;}
/// <summary>
/// Last line of the script.
/// </summary>
[JsonPropertyName("endLine")]public long EndLine{get;set;}
/// <summary>
/// Length of the last line of the script.
/// </summary>
[JsonPropertyName("endColumn")]public long EndColumn{get;set;}
/// <summary>
/// Specifies script creation context.
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
/// <summary>
/// Content hash of the script.
/// </summary>
[JsonPropertyName("hash")]public string Hash{get;set;}
/// <summary>
/// Embedder-specific auxiliary data.
/// </summary>
[JsonPropertyName("executionContextAuxData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? ExecutionContextAuxData{get;set;}
/// <summary>
/// URL of source map associated with script (if any).
/// </summary>
[JsonPropertyName("sourceMapURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SourceMapURL{get;set;}
/// <summary>
/// True, if this script has sourceURL.
/// </summary>
[JsonPropertyName("hasSourceURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasSourceURL{get;set;}
/// <summary>
/// True, if this script is ES6 module.
/// </summary>
[JsonPropertyName("isModule")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsModule{get;set;}
/// <summary>
/// This script length.
/// </summary>
[JsonPropertyName("length")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Length{get;set;}
/// <summary>
/// JavaScript top stack frame of where the script parsed event was triggered if available.
/// </summary>
[Experimental][JsonPropertyName("stackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? StackTrace{get;set;}
/// <summary>
/// If the scriptLanguage is WebAssembly, the code section offset in the module.
/// </summary>
[Experimental][JsonPropertyName("codeOffset")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? CodeOffset{get;set;}
/// <summary>
/// The language of the script.
/// </summary>
[Experimental][JsonPropertyName("scriptLanguage")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.ScriptLanguage? ScriptLanguage{get;set;}
/// <summary>
/// The name the embedder supplied for this script.
/// </summary>
[Experimental][JsonPropertyName("embedderName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? EmbedderName{get;set;}
}
private Action<ScriptFailedToParseParams>? _onScriptFailedToParse;
/// <summary>
/// Fired when virtual machine fails to parse the script.
/// </summary>
public event Action<ScriptFailedToParseParams> OnScriptFailedToParse {
add => _onScriptFailedToParse += value; remove => _onScriptFailedToParse -= value;}
public sealed partial class ScriptParsedParams {
/// <summary>
/// Identifier of the script parsed.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// URL or name of the script parsed (if any).
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Line offset of the script within the resource with given URL (for script tags).
/// </summary>
[JsonPropertyName("startLine")]public long StartLine{get;set;}
/// <summary>
/// Column offset of the script within the resource with given URL.
/// </summary>
[JsonPropertyName("startColumn")]public long StartColumn{get;set;}
/// <summary>
/// Last line of the script.
/// </summary>
[JsonPropertyName("endLine")]public long EndLine{get;set;}
/// <summary>
/// Length of the last line of the script.
/// </summary>
[JsonPropertyName("endColumn")]public long EndColumn{get;set;}
/// <summary>
/// Specifies script creation context.
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
/// <summary>
/// Content hash of the script.
/// </summary>
[JsonPropertyName("hash")]public string Hash{get;set;}
/// <summary>
/// Embedder-specific auxiliary data.
/// </summary>
[JsonPropertyName("executionContextAuxData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? ExecutionContextAuxData{get;set;}
/// <summary>
/// True, if this script is generated as a result of the live edit operation.
/// </summary>
[Experimental][JsonPropertyName("isLiveEdit")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsLiveEdit{get;set;}
/// <summary>
/// URL of source map associated with script (if any).
/// </summary>
[JsonPropertyName("sourceMapURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SourceMapURL{get;set;}
/// <summary>
/// True, if this script has sourceURL.
/// </summary>
[JsonPropertyName("hasSourceURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasSourceURL{get;set;}
/// <summary>
/// True, if this script is ES6 module.
/// </summary>
[JsonPropertyName("isModule")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsModule{get;set;}
/// <summary>
/// This script length.
/// </summary>
[JsonPropertyName("length")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Length{get;set;}
/// <summary>
/// JavaScript top stack frame of where the script parsed event was triggered if available.
/// </summary>
[Experimental][JsonPropertyName("stackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? StackTrace{get;set;}
/// <summary>
/// If the scriptLanguage is WebAssembly, the code section offset in the module.
/// </summary>
[Experimental][JsonPropertyName("codeOffset")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? CodeOffset{get;set;}
/// <summary>
/// The language of the script.
/// </summary>
[Experimental][JsonPropertyName("scriptLanguage")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.ScriptLanguage? ScriptLanguage{get;set;}
/// <summary>
/// If the scriptLanguage is WebASsembly, the source of debug symbols for the module.
/// </summary>
[Experimental][JsonPropertyName("debugSymbols")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Debugger.DebugSymbols? DebugSymbols{get;set;}
/// <summary>
/// The name the embedder supplied for this script.
/// </summary>
[Experimental][JsonPropertyName("embedderName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? EmbedderName{get;set;}
}
private Action<ScriptParsedParams>? _onScriptParsed;
/// <summary>
/// Fired when virtual machine parses script. This event is also fired for all known and uncollected
/// scripts upon enabling debugger.
/// </summary>
public event Action<ScriptParsedParams> OnScriptParsed {
add => _onScriptParsed += value; remove => _onScriptParsed -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Debugger.breakpointResolved":
_onBreakpointResolved?.Invoke(_target.DeserializeEvent<BreakpointResolvedParams>(data));
break;
case "Debugger.paused":
_onPaused?.Invoke(_target.DeserializeEvent<PausedParams>(data));
break;
case "Debugger.resumed":
_onResumed?.Invoke();
break;
case "Debugger.scriptFailedToParse":
_onScriptFailedToParse?.Invoke(_target.DeserializeEvent<ScriptFailedToParseParams>(data));
break;
case "Debugger.scriptParsed":
_onScriptParsed?.Invoke(_target.DeserializeEvent<ScriptParsedParams>(data));
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
_onBreakpointResolved = null;
_onPaused = null;
_onResumed = null;
_onScriptFailedToParse = null;
_onScriptParsed = null;
}
}
