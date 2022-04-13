using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Runtime domain exposes JavaScript runtime by means of remote evaluation and mirror objects.
/// Evaluation results are returned as mirror object that expose object type, string representation
/// and unique identifier that can be used for further object reference. Original objects are
/// maintained in memory unless they are either explicitly released or are released along with the
/// other objects in their object group.
/// </summary>
public sealed partial class RuntimeDomain {
private readonly ConnectedTarget _target;
public RuntimeDomain(ConnectedTarget target) => _target = target;
public sealed partial class AwaitPromiseParams {
/// <summary>
/// Identifier of the promise.
/// </summary>
[JsonPropertyName("promiseObjectId")]public Runtime.RemoteObjectId PromiseObjectId{get;set;}
/// <summary>
/// Whether the result is expected to be a JSON object that should be sent by value.
/// </summary>
[JsonPropertyName("returnByValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReturnByValue{get;set;}
/// <summary>
/// Whether preview should be generated for the result.
/// </summary>
[JsonPropertyName("generatePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GeneratePreview{get;set;}
}
public sealed partial class AwaitPromiseReturn {
/// <summary>
/// Promise result. Will contain rejected value if promise was rejected.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
/// <summary>
/// Exception details if stack strace is available.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Add handler to promise with given promise object id.
/// </summary>
/// <param name="promiseObjectId">Identifier of the promise.</param>
/// <param name="returnByValue">Whether the result is expected to be a JSON object that should be sent by value.</param>
/// <param name="generatePreview">Whether preview should be generated for the result.</param>
public async Task<AwaitPromiseReturn> AwaitPromise(
 Runtime.RemoteObjectId @promiseObjectId,bool? @returnByValue=default,bool? @generatePreview=default) {
var resp = await _target.SendRequest("Runtime.awaitPromise",
new AwaitPromiseParams {
PromiseObjectId=@promiseObjectId,ReturnByValue=@returnByValue,GeneratePreview=@generatePreview,});
return _target.DeserializeResponse<AwaitPromiseReturn>(resp);
}
public sealed partial class CallFunctionOnParams {
/// <summary>
/// Declaration of the function to call.
/// </summary>
[JsonPropertyName("functionDeclaration")]public string FunctionDeclaration{get;set;}
/// <summary>
/// Identifier of the object to call function on. Either objectId or executionContextId should
/// be specified.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// Call arguments. All call arguments must belong to the same JavaScript world as the target
/// object.
/// </summary>
[JsonPropertyName("arguments")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.CallArgument[]? Arguments{get;set;}
/// <summary>
/// In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.
/// </summary>
[JsonPropertyName("silent")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Silent{get;set;}
/// <summary>
/// Whether the result is expected to be a JSON object which should be sent by value.
/// </summary>
[JsonPropertyName("returnByValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReturnByValue{get;set;}
/// <summary>
/// Whether preview should be generated for the result.
/// </summary>
[Experimental][JsonPropertyName("generatePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GeneratePreview{get;set;}
/// <summary>
/// Whether execution should be treated as initiated by user in the UI.
/// </summary>
[JsonPropertyName("userGesture")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? UserGesture{get;set;}
/// <summary>
/// Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.
/// </summary>
[JsonPropertyName("awaitPromise")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AwaitPromise{get;set;}
/// <summary>
/// Specifies execution context which global object will be used to call function on. Either
/// executionContextId or objectId should be specified.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
/// <summary>
/// Symbolic group name that can be used to release multiple objects. If objectGroup is not
/// specified and objectId is, objectGroup will be inherited from object.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
/// <summary>
/// Whether to throw an exception if side effect cannot be ruled out during evaluation.
/// </summary>
[Experimental][JsonPropertyName("throwOnSideEffect")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ThrowOnSideEffect{get;set;}
}
public sealed partial class CallFunctionOnReturn {
/// <summary>
/// Call result.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Calls function with given declaration on the given object. Object group of the result is
/// inherited from the target object.
/// </summary>
/// <param name="functionDeclaration">Declaration of the function to call.</param>
/// <param name="objectId">Identifier of the object to call function on. Either objectId or executionContextId should
/// be specified.</param>
/// <param name="arguments">Call arguments. All call arguments must belong to the same JavaScript world as the target
/// object.</param>
/// <param name="silent">In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.</param>
/// <param name="returnByValue">Whether the result is expected to be a JSON object which should be sent by value.</param>
/// <param name="generatePreview">EXPERIMENTAL Whether preview should be generated for the result.</param>
/// <param name="userGesture">Whether execution should be treated as initiated by user in the UI.</param>
/// <param name="awaitPromise">Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.</param>
/// <param name="executionContextId">Specifies execution context which global object will be used to call function on. Either
/// executionContextId or objectId should be specified.</param>
/// <param name="objectGroup">Symbolic group name that can be used to release multiple objects. If objectGroup is not
/// specified and objectId is, objectGroup will be inherited from object.</param>
/// <param name="throwOnSideEffect">EXPERIMENTAL Whether to throw an exception if side effect cannot be ruled out during evaluation.</param>
public async Task<CallFunctionOnReturn> CallFunctionOn(
 string @functionDeclaration,Runtime.RemoteObjectId? @objectId=default,Runtime.CallArgument[]? @arguments=default,bool? @silent=default,bool? @returnByValue=default,bool? @generatePreview=default,bool? @userGesture=default,bool? @awaitPromise=default,Runtime.ExecutionContextId? @executionContextId=default,string? @objectGroup=default,bool? @throwOnSideEffect=default) {
var resp = await _target.SendRequest("Runtime.callFunctionOn",
new CallFunctionOnParams {
FunctionDeclaration=@functionDeclaration,ObjectId=@objectId,Arguments=@arguments,Silent=@silent,ReturnByValue=@returnByValue,GeneratePreview=@generatePreview,UserGesture=@userGesture,AwaitPromise=@awaitPromise,ExecutionContextId=@executionContextId,ObjectGroup=@objectGroup,ThrowOnSideEffect=@throwOnSideEffect,});
return _target.DeserializeResponse<CallFunctionOnReturn>(resp);
}
public sealed partial class CompileScriptParams {
/// <summary>
/// Expression to compile.
/// </summary>
[JsonPropertyName("expression")]public string Expression{get;set;}
/// <summary>
/// Source url to be set for the script.
/// </summary>
[JsonPropertyName("sourceURL")]public string SourceURL{get;set;}
/// <summary>
/// Specifies whether the compiled script should be persisted.
/// </summary>
[JsonPropertyName("persistScript")]public bool PersistScript{get;set;}
/// <summary>
/// Specifies in which execution context to perform script run. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
}
public sealed partial class CompileScriptReturn {
/// <summary>
/// Id of the script.
/// </summary>
[JsonPropertyName("scriptId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ScriptId? ScriptId{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Compiles expression.
/// </summary>
/// <param name="expression">Expression to compile.</param>
/// <param name="sourceURL">Source url to be set for the script.</param>
/// <param name="persistScript">Specifies whether the compiled script should be persisted.</param>
/// <param name="executionContextId">Specifies in which execution context to perform script run. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.</param>
public async Task<CompileScriptReturn> CompileScript(
 string @expression,string @sourceURL,bool @persistScript,Runtime.ExecutionContextId? @executionContextId=default) {
var resp = await _target.SendRequest("Runtime.compileScript",
new CompileScriptParams {
Expression=@expression,SourceURL=@sourceURL,PersistScript=@persistScript,ExecutionContextId=@executionContextId,});
return _target.DeserializeResponse<CompileScriptReturn>(resp);
}
/// <summary>
/// Disables reporting of execution contexts creation.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Runtime.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Discards collected exceptions and console API calls.
/// </summary>
public async Task DiscardConsoleEntries(
) {
var resp = await _target.SendRequest("Runtime.discardConsoleEntries",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables reporting of execution contexts creation by means of `executionContextCreated` event.
/// When the reporting gets enabled the event will be sent immediately for each existing execution
/// context.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Runtime.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EvaluateParams {
/// <summary>
/// Expression to evaluate.
/// </summary>
[JsonPropertyName("expression")]public string Expression{get;set;}
/// <summary>
/// Symbolic group name that can be used to release multiple objects.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
/// <summary>
/// Determines whether Command Line API should be available during the evaluation.
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
/// Specifies in which execution context to perform evaluation. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.
/// This is mutually exclusive with `uniqueContextId`, which offers an
/// alternative way to identify the execution context that is more reliable
/// in a multi-process environment.
/// </summary>
[JsonPropertyName("contextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ContextId{get;set;}
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
/// Whether execution should be treated as initiated by user in the UI.
/// </summary>
[JsonPropertyName("userGesture")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? UserGesture{get;set;}
/// <summary>
/// Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.
/// </summary>
[JsonPropertyName("awaitPromise")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AwaitPromise{get;set;}
/// <summary>
/// Whether to throw an exception if side effect cannot be ruled out during evaluation.
/// This implies `disableBreaks` below.
/// </summary>
[Experimental][JsonPropertyName("throwOnSideEffect")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ThrowOnSideEffect{get;set;}
/// <summary>
/// Terminate execution after timing out (number of milliseconds).
/// </summary>
[Experimental][JsonPropertyName("timeout")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.TimeDelta? Timeout{get;set;}
/// <summary>
/// Disable breakpoints during execution.
/// </summary>
[Experimental][JsonPropertyName("disableBreaks")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DisableBreaks{get;set;}
/// <summary>
/// Setting this flag to true enables `let` re-declaration and top-level `await`.
/// Note that `let` variables can only be re-declared if they originate from
/// `replMode` themselves.
/// </summary>
[Experimental][JsonPropertyName("replMode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReplMode{get;set;}
/// <summary>
/// The Content Security Policy (CSP) for the target might block 'unsafe-eval'
/// which includes eval(), Function(), setTimeout() and setInterval()
/// when called with non-callable arguments. This flag bypasses CSP for this
/// evaluation and allows unsafe-eval. Defaults to true.
/// </summary>
[Experimental][JsonPropertyName("allowUnsafeEvalBlockedByCSP")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AllowUnsafeEvalBlockedByCSP{get;set;}
/// <summary>
/// An alternative way to specify the execution context to evaluate in.
/// Compared to contextId that may be reused across processes, this is guaranteed to be
/// system-unique, so it can be used to prevent accidental evaluation of the expression
/// in context different than intended (e.g. as a result of navigation across process
/// boundaries).
/// This is mutually exclusive with `contextId`.
/// </summary>
[Experimental][JsonPropertyName("uniqueContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? UniqueContextId{get;set;}
}
public sealed partial class EvaluateReturn {
/// <summary>
/// Evaluation result.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Evaluates expression on global object.
/// </summary>
/// <param name="expression">Expression to evaluate.</param>
/// <param name="objectGroup">Symbolic group name that can be used to release multiple objects.</param>
/// <param name="includeCommandLineAPI">Determines whether Command Line API should be available during the evaluation.</param>
/// <param name="silent">In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.</param>
/// <param name="contextId">Specifies in which execution context to perform evaluation. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.
/// This is mutually exclusive with `uniqueContextId`, which offers an
/// alternative way to identify the execution context that is more reliable
/// in a multi-process environment.</param>
/// <param name="returnByValue">Whether the result is expected to be a JSON object that should be sent by value.</param>
/// <param name="generatePreview">EXPERIMENTAL Whether preview should be generated for the result.</param>
/// <param name="userGesture">Whether execution should be treated as initiated by user in the UI.</param>
/// <param name="awaitPromise">Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.</param>
/// <param name="throwOnSideEffect">EXPERIMENTAL Whether to throw an exception if side effect cannot be ruled out during evaluation.
/// This implies `disableBreaks` below.</param>
/// <param name="timeout">EXPERIMENTAL Terminate execution after timing out (number of milliseconds).</param>
/// <param name="disableBreaks">EXPERIMENTAL Disable breakpoints during execution.</param>
/// <param name="replMode">EXPERIMENTAL Setting this flag to true enables `let` re-declaration and top-level `await`.
/// Note that `let` variables can only be re-declared if they originate from
/// `replMode` themselves.</param>
/// <param name="allowUnsafeEvalBlockedByCSP">EXPERIMENTAL The Content Security Policy (CSP) for the target might block 'unsafe-eval'
/// which includes eval(), Function(), setTimeout() and setInterval()
/// when called with non-callable arguments. This flag bypasses CSP for this
/// evaluation and allows unsafe-eval. Defaults to true.</param>
/// <param name="uniqueContextId">EXPERIMENTAL An alternative way to specify the execution context to evaluate in.
/// Compared to contextId that may be reused across processes, this is guaranteed to be
/// system-unique, so it can be used to prevent accidental evaluation of the expression
/// in context different than intended (e.g. as a result of navigation across process
/// boundaries).
/// This is mutually exclusive with `contextId`.</param>
public async Task<EvaluateReturn> Evaluate(
 string @expression,string? @objectGroup=default,bool? @includeCommandLineAPI=default,bool? @silent=default,Runtime.ExecutionContextId? @contextId=default,bool? @returnByValue=default,bool? @generatePreview=default,bool? @userGesture=default,bool? @awaitPromise=default,bool? @throwOnSideEffect=default,Runtime.TimeDelta? @timeout=default,bool? @disableBreaks=default,bool? @replMode=default,bool? @allowUnsafeEvalBlockedByCSP=default,string? @uniqueContextId=default) {
var resp = await _target.SendRequest("Runtime.evaluate",
new EvaluateParams {
Expression=@expression,ObjectGroup=@objectGroup,IncludeCommandLineAPI=@includeCommandLineAPI,Silent=@silent,ContextId=@contextId,ReturnByValue=@returnByValue,GeneratePreview=@generatePreview,UserGesture=@userGesture,AwaitPromise=@awaitPromise,ThrowOnSideEffect=@throwOnSideEffect,Timeout=@timeout,DisableBreaks=@disableBreaks,ReplMode=@replMode,AllowUnsafeEvalBlockedByCSP=@allowUnsafeEvalBlockedByCSP,UniqueContextId=@uniqueContextId,});
return _target.DeserializeResponse<EvaluateReturn>(resp);
}
public sealed partial class GetIsolateIdReturn {
/// <summary>
/// The isolate id.
/// </summary>
[JsonPropertyName("id")]public string Id{get;set;}
}
/// <summary>
/// Returns the isolate id.
/// </summary>
[Experimental]public async Task<GetIsolateIdReturn> GetIsolateId(
) {
var resp = await _target.SendRequest("Runtime.getIsolateId",
VoidData.Instance);
return _target.DeserializeResponse<GetIsolateIdReturn>(resp);
}
public sealed partial class GetHeapUsageReturn {
/// <summary>
/// Used heap size in bytes.
/// </summary>
[JsonPropertyName("usedSize")]public double UsedSize{get;set;}
/// <summary>
/// Allocated heap size in bytes.
/// </summary>
[JsonPropertyName("totalSize")]public double TotalSize{get;set;}
}
/// <summary>
/// Returns the JavaScript heap usage.
/// It is the total usage of the corresponding isolate not scoped to a particular Runtime.
/// </summary>
[Experimental]public async Task<GetHeapUsageReturn> GetHeapUsage(
) {
var resp = await _target.SendRequest("Runtime.getHeapUsage",
VoidData.Instance);
return _target.DeserializeResponse<GetHeapUsageReturn>(resp);
}
public sealed partial class GetPropertiesParams {
/// <summary>
/// Identifier of the object to return properties for.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
/// <summary>
/// If true, returns properties belonging only to the element itself, not to its prototype
/// chain.
/// </summary>
[JsonPropertyName("ownProperties")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? OwnProperties{get;set;}
/// <summary>
/// If true, returns accessor properties (with getter/setter) only; internal properties are not
/// returned either.
/// </summary>
[Experimental][JsonPropertyName("accessorPropertiesOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AccessorPropertiesOnly{get;set;}
/// <summary>
/// Whether preview should be generated for the results.
/// </summary>
[Experimental][JsonPropertyName("generatePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GeneratePreview{get;set;}
/// <summary>
/// If true, returns non-indexed properties only.
/// </summary>
[Experimental][JsonPropertyName("nonIndexedPropertiesOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? NonIndexedPropertiesOnly{get;set;}
}
public sealed partial class GetPropertiesReturn {
/// <summary>
/// Object properties.
/// </summary>
[JsonPropertyName("result")]public Runtime.PropertyDescriptor[] Result{get;set;}
/// <summary>
/// Internal object properties (only of the element itself).
/// </summary>
[JsonPropertyName("internalProperties")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.InternalPropertyDescriptor[]? InternalProperties{get;set;}
/// <summary>
/// Object private properties.
/// </summary>
[Experimental][JsonPropertyName("privateProperties")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.PrivatePropertyDescriptor[]? PrivateProperties{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Returns properties of a given object. Object group of the result is inherited from the target
/// object.
/// </summary>
/// <param name="objectId">Identifier of the object to return properties for.</param>
/// <param name="ownProperties">If true, returns properties belonging only to the element itself, not to its prototype
/// chain.</param>
/// <param name="accessorPropertiesOnly">EXPERIMENTAL If true, returns accessor properties (with getter/setter) only; internal properties are not
/// returned either.</param>
/// <param name="generatePreview">EXPERIMENTAL Whether preview should be generated for the results.</param>
/// <param name="nonIndexedPropertiesOnly">EXPERIMENTAL If true, returns non-indexed properties only.</param>
public async Task<GetPropertiesReturn> GetProperties(
 Runtime.RemoteObjectId @objectId,bool? @ownProperties=default,bool? @accessorPropertiesOnly=default,bool? @generatePreview=default,bool? @nonIndexedPropertiesOnly=default) {
var resp = await _target.SendRequest("Runtime.getProperties",
new GetPropertiesParams {
ObjectId=@objectId,OwnProperties=@ownProperties,AccessorPropertiesOnly=@accessorPropertiesOnly,GeneratePreview=@generatePreview,NonIndexedPropertiesOnly=@nonIndexedPropertiesOnly,});
return _target.DeserializeResponse<GetPropertiesReturn>(resp);
}
public sealed partial class GlobalLexicalScopeNamesParams {
/// <summary>
/// Specifies in which execution context to lookup global scope variables.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
}
public sealed partial class GlobalLexicalScopeNamesReturn {
[JsonPropertyName("names")]public string[] Names{get;set;}
}
/// <summary>
/// Returns all let, const and class variables from global scope.
/// </summary>
/// <param name="executionContextId">Specifies in which execution context to lookup global scope variables.</param>
public async Task<GlobalLexicalScopeNamesReturn> GlobalLexicalScopeNames(
 Runtime.ExecutionContextId? @executionContextId=default) {
var resp = await _target.SendRequest("Runtime.globalLexicalScopeNames",
new GlobalLexicalScopeNamesParams {
ExecutionContextId=@executionContextId,});
return _target.DeserializeResponse<GlobalLexicalScopeNamesReturn>(resp);
}
public sealed partial class QueryObjectsParams {
/// <summary>
/// Identifier of the prototype to return objects for.
/// </summary>
[JsonPropertyName("prototypeObjectId")]public Runtime.RemoteObjectId PrototypeObjectId{get;set;}
/// <summary>
/// Symbolic group name that can be used to release the results.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
}
public sealed partial class QueryObjectsReturn {
/// <summary>
/// Array with objects.
/// </summary>
[JsonPropertyName("objects")]public Runtime.RemoteObject Objects{get;set;}
}
/// <param name="prototypeObjectId">Identifier of the prototype to return objects for.</param>
/// <param name="objectGroup">Symbolic group name that can be used to release the results.</param>
public async Task<QueryObjectsReturn> QueryObjects(
 Runtime.RemoteObjectId @prototypeObjectId,string? @objectGroup=default) {
var resp = await _target.SendRequest("Runtime.queryObjects",
new QueryObjectsParams {
PrototypeObjectId=@prototypeObjectId,ObjectGroup=@objectGroup,});
return _target.DeserializeResponse<QueryObjectsReturn>(resp);
}
public sealed partial class ReleaseObjectParams {
/// <summary>
/// Identifier of the object to release.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
}
/// <summary>
/// Releases remote object with given id.
/// </summary>
/// <param name="objectId">Identifier of the object to release.</param>
public async Task ReleaseObject(
 Runtime.RemoteObjectId @objectId) {
var resp = await _target.SendRequest("Runtime.releaseObject",
new ReleaseObjectParams {
ObjectId=@objectId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ReleaseObjectGroupParams {
/// <summary>
/// Symbolic object group name.
/// </summary>
[JsonPropertyName("objectGroup")]public string ObjectGroup{get;set;}
}
/// <summary>
/// Releases all remote objects that belong to a given group.
/// </summary>
/// <param name="objectGroup">Symbolic object group name.</param>
public async Task ReleaseObjectGroup(
 string @objectGroup) {
var resp = await _target.SendRequest("Runtime.releaseObjectGroup",
new ReleaseObjectGroupParams {
ObjectGroup=@objectGroup,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Tells inspected instance to run if it was waiting for debugger to attach.
/// </summary>
public async Task RunIfWaitingForDebugger(
) {
var resp = await _target.SendRequest("Runtime.runIfWaitingForDebugger",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RunScriptParams {
/// <summary>
/// Id of the script to run.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// Specifies in which execution context to perform script run. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
/// <summary>
/// Symbolic group name that can be used to release multiple objects.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
/// <summary>
/// In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.
/// </summary>
[JsonPropertyName("silent")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Silent{get;set;}
/// <summary>
/// Determines whether Command Line API should be available during the evaluation.
/// </summary>
[JsonPropertyName("includeCommandLineAPI")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeCommandLineAPI{get;set;}
/// <summary>
/// Whether the result is expected to be a JSON object which should be sent by value.
/// </summary>
[JsonPropertyName("returnByValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReturnByValue{get;set;}
/// <summary>
/// Whether preview should be generated for the result.
/// </summary>
[JsonPropertyName("generatePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GeneratePreview{get;set;}
/// <summary>
/// Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.
/// </summary>
[JsonPropertyName("awaitPromise")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AwaitPromise{get;set;}
}
public sealed partial class RunScriptReturn {
/// <summary>
/// Run result.
/// </summary>
[JsonPropertyName("result")]public Runtime.RemoteObject Result{get;set;}
/// <summary>
/// Exception details.
/// </summary>
[JsonPropertyName("exceptionDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExceptionDetails? ExceptionDetails{get;set;}
}
/// <summary>
/// Runs script with given id in a given context.
/// </summary>
/// <param name="scriptId">Id of the script to run.</param>
/// <param name="executionContextId">Specifies in which execution context to perform script run. If the parameter is omitted the
/// evaluation will be performed in the context of the inspected page.</param>
/// <param name="objectGroup">Symbolic group name that can be used to release multiple objects.</param>
/// <param name="silent">In silent mode exceptions thrown during evaluation are not reported and do not pause
/// execution. Overrides `setPauseOnException` state.</param>
/// <param name="includeCommandLineAPI">Determines whether Command Line API should be available during the evaluation.</param>
/// <param name="returnByValue">Whether the result is expected to be a JSON object which should be sent by value.</param>
/// <param name="generatePreview">Whether preview should be generated for the result.</param>
/// <param name="awaitPromise">Whether execution should `await` for resulting value and return once awaited promise is
/// resolved.</param>
public async Task<RunScriptReturn> RunScript(
 Runtime.ScriptId @scriptId,Runtime.ExecutionContextId? @executionContextId=default,string? @objectGroup=default,bool? @silent=default,bool? @includeCommandLineAPI=default,bool? @returnByValue=default,bool? @generatePreview=default,bool? @awaitPromise=default) {
var resp = await _target.SendRequest("Runtime.runScript",
new RunScriptParams {
ScriptId=@scriptId,ExecutionContextId=@executionContextId,ObjectGroup=@objectGroup,Silent=@silent,IncludeCommandLineAPI=@includeCommandLineAPI,ReturnByValue=@returnByValue,GeneratePreview=@generatePreview,AwaitPromise=@awaitPromise,});
return _target.DeserializeResponse<RunScriptReturn>(resp);
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
var resp = await _target.SendRequest("Runtime.setAsyncCallStackDepth",
new SetAsyncCallStackDepthParams {
MaxDepth=@maxDepth,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetCustomObjectFormatterEnabledParams {
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <param name="enabled"></param>
[Experimental]public async Task SetCustomObjectFormatterEnabled(
 bool @enabled) {
var resp = await _target.SendRequest("Runtime.setCustomObjectFormatterEnabled",
new SetCustomObjectFormatterEnabledParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetMaxCallStackSizeToCaptureParams {
[JsonPropertyName("size")]public long Size{get;set;}
}
/// <param name="size"></param>
[Experimental]public async Task SetMaxCallStackSizeToCapture(
 long @size) {
var resp = await _target.SendRequest("Runtime.setMaxCallStackSizeToCapture",
new SetMaxCallStackSizeToCaptureParams {
Size=@size,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Terminate current or next JavaScript execution.
/// Will cancel the termination when the outer-most script execution ends.
/// </summary>
[Experimental]public async Task TerminateExecution(
) {
var resp = await _target.SendRequest("Runtime.terminateExecution",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AddBindingParams {
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// If specified, the binding would only be exposed to the specified
/// execution context. If omitted and `executionContextName` is not set,
/// the binding is exposed to all execution contexts of the target.
/// This parameter is mutually exclusive with `executionContextName`.
/// Deprecated in favor of `executionContextName` due to an unclear use case
/// and bugs in implementation (crbug.com/1169639). `executionContextId` will be
/// removed in the future.
/// </summary>
[Obsolete][JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
/// <summary>
/// If specified, the binding is exposed to the executionContext with
/// matching name, even for contexts created after the binding is added.
/// See also `ExecutionContext.name` and `worldName` parameter to
/// `Page.addScriptToEvaluateOnNewDocument`.
/// This parameter is mutually exclusive with `executionContextId`.
/// </summary>
[Experimental][JsonPropertyName("executionContextName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ExecutionContextName{get;set;}
}
/// <summary>
/// If executionContextId is empty, adds binding with the given name on the
/// global objects of all inspected contexts, including those created later,
/// bindings survive reloads.
/// Binding function takes exactly one argument, this argument should be string,
/// in case of any other input, function throws an exception.
/// Each binding function call produces Runtime.bindingCalled notification.
/// </summary>
/// <param name="name"></param>
/// <param name="executionContextId">OBSOLETE If specified, the binding would only be exposed to the specified
/// execution context. If omitted and `executionContextName` is not set,
/// the binding is exposed to all execution contexts of the target.
/// This parameter is mutually exclusive with `executionContextName`.
/// Deprecated in favor of `executionContextName` due to an unclear use case
/// and bugs in implementation (crbug.com/1169639). `executionContextId` will be
/// removed in the future.</param>
/// <param name="executionContextName">EXPERIMENTAL If specified, the binding is exposed to the executionContext with
/// matching name, even for contexts created after the binding is added.
/// See also `ExecutionContext.name` and `worldName` parameter to
/// `Page.addScriptToEvaluateOnNewDocument`.
/// This parameter is mutually exclusive with `executionContextId`.</param>
[Experimental]public async Task AddBinding(
 string @name,Runtime.ExecutionContextId? @executionContextId=default,string? @executionContextName=default) {
var resp = await _target.SendRequest("Runtime.addBinding",
new AddBindingParams {
Name=@name,ExecutionContextId=@executionContextId,ExecutionContextName=@executionContextName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveBindingParams {
[JsonPropertyName("name")]public string Name{get;set;}
}
/// <summary>
/// This method does not remove binding function from global object but
/// unsubscribes current runtime agent from Runtime.bindingCalled notifications.
/// </summary>
/// <param name="name"></param>
[Experimental]public async Task RemoveBinding(
 string @name) {
var resp = await _target.SendRequest("Runtime.removeBinding",
new RemoveBindingParams {
Name=@name,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class BindingCalledParams {
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("payload")]public string Payload{get;set;}
/// <summary>
/// Identifier of the context where the call was made.
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
}
private Action<BindingCalledParams>? _onBindingCalled;
/// <summary>
/// Notification is issued every time when binding is called.
/// </summary>
[Experimental]public event Action<BindingCalledParams> OnBindingCalled {
add => _onBindingCalled += value; remove => _onBindingCalled -= value;}
public sealed partial class ConsoleAPICalledParams {
/// <summary>
/// Type of the call.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "log")] Log,
[EnumMember(Value = "debug")] Debug,
[EnumMember(Value = "info")] Info,
[EnumMember(Value = "error")] Error,
[EnumMember(Value = "warning")] Warning,
[EnumMember(Value = "dir")] Dir,
[EnumMember(Value = "dirxml")] Dirxml,
[EnumMember(Value = "table")] Table,
[EnumMember(Value = "trace")] Trace,
[EnumMember(Value = "clear")] Clear,
[EnumMember(Value = "startGroup")] StartGroup,
[EnumMember(Value = "startGroupCollapsed")] StartGroupCollapsed,
[EnumMember(Value = "endGroup")] EndGroup,
[EnumMember(Value = "assert")] Assert,
[EnumMember(Value = "profile")] Profile,
[EnumMember(Value = "profileEnd")] ProfileEnd,
[EnumMember(Value = "count")] Count,
[EnumMember(Value = "timeEnd")] TimeEnd,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// Call arguments.
/// </summary>
[JsonPropertyName("args")]public Runtime.RemoteObject[] Args{get;set;}
/// <summary>
/// Identifier of the context where the call was made.
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
/// <summary>
/// Call timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Runtime.Timestamp Timestamp{get;set;}
/// <summary>
/// Stack trace captured when the call was made. The async stack chain is automatically reported for
/// the following call types: `assert`, `error`, `trace`, `warning`. For other types the async call
/// chain can be retrieved using `Debugger.getStackTrace` and `stackTrace.parentId` field.
/// </summary>
[JsonPropertyName("stackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? StackTrace{get;set;}
/// <summary>
/// Console context descriptor for calls on non-default console context (not console.*):
/// 'anonymous#unique-logger-id' for call on unnamed context, 'name#unique-logger-id' for call
/// on named context.
/// </summary>
[Experimental][JsonPropertyName("context")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Context{get;set;}
}
private Action<ConsoleAPICalledParams>? _onConsoleAPICalled;
/// <summary>
/// Issued when console API was called.
/// </summary>
public event Action<ConsoleAPICalledParams> OnConsoleAPICalled {
add => _onConsoleAPICalled += value; remove => _onConsoleAPICalled -= value;}
public sealed partial class ExceptionRevokedParams {
/// <summary>
/// Reason describing why exception was revoked.
/// </summary>
[JsonPropertyName("reason")]public string Reason{get;set;}
/// <summary>
/// The id of revoked exception, as reported in `exceptionThrown`.
/// </summary>
[JsonPropertyName("exceptionId")]public long ExceptionId{get;set;}
}
private Action<ExceptionRevokedParams>? _onExceptionRevoked;
/// <summary>
/// Issued when unhandled exception was revoked.
/// </summary>
public event Action<ExceptionRevokedParams> OnExceptionRevoked {
add => _onExceptionRevoked += value; remove => _onExceptionRevoked -= value;}
public sealed partial class ExceptionThrownParams {
/// <summary>
/// Timestamp of the exception.
/// </summary>
[JsonPropertyName("timestamp")]public Runtime.Timestamp Timestamp{get;set;}
[JsonPropertyName("exceptionDetails")]public Runtime.ExceptionDetails ExceptionDetails{get;set;}
}
private Action<ExceptionThrownParams>? _onExceptionThrown;
/// <summary>
/// Issued when exception was thrown and unhandled.
/// </summary>
public event Action<ExceptionThrownParams> OnExceptionThrown {
add => _onExceptionThrown += value; remove => _onExceptionThrown -= value;}
public sealed partial class ExecutionContextCreatedParams {
/// <summary>
/// A newly created execution context.
/// </summary>
[JsonPropertyName("context")]public Runtime.ExecutionContextDescription Context{get;set;}
}
private Action<ExecutionContextCreatedParams>? _onExecutionContextCreated;
/// <summary>
/// Issued when new execution context is created.
/// </summary>
public event Action<ExecutionContextCreatedParams> OnExecutionContextCreated {
add => _onExecutionContextCreated += value; remove => _onExecutionContextCreated -= value;}
public sealed partial class ExecutionContextDestroyedParams {
/// <summary>
/// Id of the destroyed context
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
}
private Action<ExecutionContextDestroyedParams>? _onExecutionContextDestroyed;
/// <summary>
/// Issued when execution context is destroyed.
/// </summary>
public event Action<ExecutionContextDestroyedParams> OnExecutionContextDestroyed {
add => _onExecutionContextDestroyed += value; remove => _onExecutionContextDestroyed -= value;}
private Action? _onExecutionContextsCleared;
/// <summary>
/// Issued when all executionContexts were cleared in browser
/// </summary>
public event Action OnExecutionContextsCleared {
add => _onExecutionContextsCleared += value; remove => _onExecutionContextsCleared -= value;}
public sealed partial class InspectRequestedParams {
[JsonPropertyName("object")]public Runtime.RemoteObject Object{get;set;}
[JsonPropertyName("hints")]public object Hints{get;set;}
/// <summary>
/// Identifier of the context where the call was made.
/// </summary>
[Experimental][JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
}
private Action<InspectRequestedParams>? _onInspectRequested;
/// <summary>
/// Issued when object should be inspected (for example, as a result of inspect() command line API
/// call).
/// </summary>
public event Action<InspectRequestedParams> OnInspectRequested {
add => _onInspectRequested += value; remove => _onInspectRequested -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Runtime.bindingCalled":
_onBindingCalled?.Invoke(_target.DeserializeEvent<BindingCalledParams>(data));
break;
case "Runtime.consoleAPICalled":
_onConsoleAPICalled?.Invoke(_target.DeserializeEvent<ConsoleAPICalledParams>(data));
break;
case "Runtime.exceptionRevoked":
_onExceptionRevoked?.Invoke(_target.DeserializeEvent<ExceptionRevokedParams>(data));
break;
case "Runtime.exceptionThrown":
_onExceptionThrown?.Invoke(_target.DeserializeEvent<ExceptionThrownParams>(data));
break;
case "Runtime.executionContextCreated":
_onExecutionContextCreated?.Invoke(_target.DeserializeEvent<ExecutionContextCreatedParams>(data));
break;
case "Runtime.executionContextDestroyed":
_onExecutionContextDestroyed?.Invoke(_target.DeserializeEvent<ExecutionContextDestroyedParams>(data));
break;
case "Runtime.executionContextsCleared":
_onExecutionContextsCleared?.Invoke();
break;
case "Runtime.inspectRequested":
_onInspectRequested?.Invoke(_target.DeserializeEvent<InspectRequestedParams>(data));
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
_onBindingCalled = null;
_onConsoleAPICalled = null;
_onExceptionRevoked = null;
_onExceptionThrown = null;
_onExecutionContextCreated = null;
_onExecutionContextDestroyed = null;
_onExecutionContextsCleared = null;
_onInspectRequested = null;
}
}
