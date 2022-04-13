using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Supports additional targets discovery and allows to attach to them.
/// </summary>
public sealed partial class TargetDomain {
private readonly ConnectedTarget _target;
public TargetDomain(ConnectedTarget target) => _target = target;
public sealed partial class ActivateTargetParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
}
/// <summary>
/// Activates (focuses) the target.
/// </summary>
/// <param name="targetId"></param>
public async Task ActivateTarget(
 Target.TargetID @targetId) {
var resp = await _target.SendRequest("Target.activateTarget",
new ActivateTargetParams {
TargetId=@targetId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AttachToTargetParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
/// <summary>
/// Enables "flat" access to the session via specifying sessionId attribute in the commands.
/// We plan to make this the default, deprecate non-flattened mode,
/// and eventually retire it. See crbug.com/991325.
/// </summary>
[JsonPropertyName("flatten")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Flatten{get;set;}
}
public sealed partial class AttachToTargetReturn {
/// <summary>
/// Id assigned to the session.
/// </summary>
[JsonPropertyName("sessionId")]public Target.SessionID SessionId{get;set;}
}
/// <summary>
/// Attaches to the target with given id.
/// </summary>
/// <param name="targetId"></param>
/// <param name="flatten">Enables "flat" access to the session via specifying sessionId attribute in the commands.
/// We plan to make this the default, deprecate non-flattened mode,
/// and eventually retire it. See crbug.com/991325.</param>
public async Task<AttachToTargetReturn> AttachToTarget(
 Target.TargetID @targetId,bool? @flatten=default) {
var resp = await _target.SendRequest("Target.attachToTarget",
new AttachToTargetParams {
TargetId=@targetId,Flatten=@flatten,});
return _target.DeserializeResponse<AttachToTargetReturn>(resp);
}
public sealed partial class AttachToBrowserTargetReturn {
/// <summary>
/// Id assigned to the session.
/// </summary>
[JsonPropertyName("sessionId")]public Target.SessionID SessionId{get;set;}
}
/// <summary>
/// Attaches to the browser target, only uses flat sessionId mode.
/// </summary>
[Experimental]public async Task<AttachToBrowserTargetReturn> AttachToBrowserTarget(
) {
var resp = await _target.SendRequest("Target.attachToBrowserTarget",
VoidData.Instance);
return _target.DeserializeResponse<AttachToBrowserTargetReturn>(resp);
}
public sealed partial class CloseTargetParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
}
public sealed partial class CloseTargetReturn {
/// <summary>
/// Always set to true. If an error occurs, the response indicates protocol error.
/// </summary>
[Obsolete][JsonPropertyName("success")]public bool Success{get;set;}
}
/// <summary>
/// Closes the target. If the target is a page that gets closed too.
/// </summary>
/// <param name="targetId"></param>
public async Task<CloseTargetReturn> CloseTarget(
 Target.TargetID @targetId) {
var resp = await _target.SendRequest("Target.closeTarget",
new CloseTargetParams {
TargetId=@targetId,});
return _target.DeserializeResponse<CloseTargetReturn>(resp);
}
public sealed partial class ExposeDevToolsProtocolParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
/// <summary>
/// Binding name, 'cdp' if not specified.
/// </summary>
[JsonPropertyName("bindingName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BindingName{get;set;}
}
/// <summary>
/// Inject object to the target's main frame that provides a communication
/// channel with browser target.
/// 
/// Injected object will be available as `window[bindingName]`.
/// 
/// The object has the follwing API:
/// - `binding.send(json)` - a method to send messages over the remote debugging protocol
/// - `binding.onmessage = json => handleMessage(json)` - a callback that will be called for the protocol notifications and command responses.
/// </summary>
/// <param name="targetId"></param>
/// <param name="bindingName">Binding name, 'cdp' if not specified.</param>
[Experimental]public async Task ExposeDevToolsProtocol(
 Target.TargetID @targetId,string? @bindingName=default) {
var resp = await _target.SendRequest("Target.exposeDevToolsProtocol",
new ExposeDevToolsProtocolParams {
TargetId=@targetId,BindingName=@bindingName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CreateBrowserContextParams {
/// <summary>
/// If specified, disposes this context when debugging session disconnects.
/// </summary>
[JsonPropertyName("disposeOnDetach")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DisposeOnDetach{get;set;}
/// <summary>
/// Proxy server, similar to the one passed to --proxy-server
/// </summary>
[JsonPropertyName("proxyServer")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ProxyServer{get;set;}
/// <summary>
/// Proxy bypass list, similar to the one passed to --proxy-bypass-list
/// </summary>
[JsonPropertyName("proxyBypassList")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ProxyBypassList{get;set;}
/// <summary>
/// An optional list of origins to grant unlimited cross-origin access to.
/// Parts of the URL other than those constituting origin are ignored.
/// </summary>
[JsonPropertyName("originsWithUniversalNetworkAccess")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? OriginsWithUniversalNetworkAccess{get;set;}
}
public sealed partial class CreateBrowserContextReturn {
/// <summary>
/// The id of the context created.
/// </summary>
[JsonPropertyName("browserContextId")]public Browser.BrowserContextID BrowserContextId{get;set;}
}
/// <summary>
/// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
/// one.
/// </summary>
/// <param name="disposeOnDetach">If specified, disposes this context when debugging session disconnects.</param>
/// <param name="proxyServer">Proxy server, similar to the one passed to --proxy-server</param>
/// <param name="proxyBypassList">Proxy bypass list, similar to the one passed to --proxy-bypass-list</param>
/// <param name="originsWithUniversalNetworkAccess">An optional list of origins to grant unlimited cross-origin access to.
/// Parts of the URL other than those constituting origin are ignored.</param>
[Experimental]public async Task<CreateBrowserContextReturn> CreateBrowserContext(
 bool? @disposeOnDetach=default,string? @proxyServer=default,string? @proxyBypassList=default,string[]? @originsWithUniversalNetworkAccess=default) {
var resp = await _target.SendRequest("Target.createBrowserContext",
new CreateBrowserContextParams {
DisposeOnDetach=@disposeOnDetach,ProxyServer=@proxyServer,ProxyBypassList=@proxyBypassList,OriginsWithUniversalNetworkAccess=@originsWithUniversalNetworkAccess,});
return _target.DeserializeResponse<CreateBrowserContextReturn>(resp);
}
public sealed partial class GetBrowserContextsReturn {
/// <summary>
/// An array of browser context ids.
/// </summary>
[JsonPropertyName("browserContextIds")]public Browser.BrowserContextID[] BrowserContextIds{get;set;}
}
/// <summary>
/// Returns all browser contexts created with `Target.createBrowserContext` method.
/// </summary>
[Experimental]public async Task<GetBrowserContextsReturn> GetBrowserContexts(
) {
var resp = await _target.SendRequest("Target.getBrowserContexts",
VoidData.Instance);
return _target.DeserializeResponse<GetBrowserContextsReturn>(resp);
}
public sealed partial class CreateTargetParams {
/// <summary>
/// The initial URL the page will be navigated to. An empty string indicates about:blank.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Frame width in DIP (headless chrome only).
/// </summary>
[JsonPropertyName("width")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Width{get;set;}
/// <summary>
/// Frame height in DIP (headless chrome only).
/// </summary>
[JsonPropertyName("height")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Height{get;set;}
/// <summary>
/// The browser context to create the page in.
/// </summary>
[Experimental][JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
/// <summary>
/// Whether BeginFrames for this target will be controlled via DevTools (headless chrome only,
/// not supported on MacOS yet, false by default).
/// </summary>
[Experimental][JsonPropertyName("enableBeginFrameControl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? EnableBeginFrameControl{get;set;}
/// <summary>
/// Whether to create a new Window or Tab (chrome-only, false by default).
/// </summary>
[JsonPropertyName("newWindow")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? NewWindow{get;set;}
/// <summary>
/// Whether to create the target in background or foreground (chrome-only,
/// false by default).
/// </summary>
[JsonPropertyName("background")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Background{get;set;}
}
public sealed partial class CreateTargetReturn {
/// <summary>
/// The id of the page opened.
/// </summary>
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
}
/// <summary>
/// Creates a new page.
/// </summary>
/// <param name="url">The initial URL the page will be navigated to. An empty string indicates about:blank.</param>
/// <param name="width">Frame width in DIP (headless chrome only).</param>
/// <param name="height">Frame height in DIP (headless chrome only).</param>
/// <param name="browserContextId">EXPERIMENTAL The browser context to create the page in.</param>
/// <param name="enableBeginFrameControl">EXPERIMENTAL Whether BeginFrames for this target will be controlled via DevTools (headless chrome only,
/// not supported on MacOS yet, false by default).</param>
/// <param name="newWindow">Whether to create a new Window or Tab (chrome-only, false by default).</param>
/// <param name="background">Whether to create the target in background or foreground (chrome-only,
/// false by default).</param>
public async Task<CreateTargetReturn> CreateTarget(
 string @url,long? @width=default,long? @height=default,Browser.BrowserContextID? @browserContextId=default,bool? @enableBeginFrameControl=default,bool? @newWindow=default,bool? @background=default) {
var resp = await _target.SendRequest("Target.createTarget",
new CreateTargetParams {
Url=@url,Width=@width,Height=@height,BrowserContextId=@browserContextId,EnableBeginFrameControl=@enableBeginFrameControl,NewWindow=@newWindow,Background=@background,});
return _target.DeserializeResponse<CreateTargetReturn>(resp);
}
public sealed partial class DetachFromTargetParams {
/// <summary>
/// Session to detach.
/// </summary>
[JsonPropertyName("sessionId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.SessionID? SessionId{get;set;}
/// <summary>
/// Deprecated.
/// </summary>
[Obsolete][JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
/// <summary>
/// Detaches session with given id.
/// </summary>
/// <param name="sessionId">Session to detach.</param>
/// <param name="targetId">OBSOLETE Deprecated.</param>
public async Task DetachFromTarget(
 Target.SessionID? @sessionId=default,Target.TargetID? @targetId=default) {
var resp = await _target.SendRequest("Target.detachFromTarget",
new DetachFromTargetParams {
SessionId=@sessionId,TargetId=@targetId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DisposeBrowserContextParams {
[JsonPropertyName("browserContextId")]public Browser.BrowserContextID BrowserContextId{get;set;}
}
/// <summary>
/// Deletes a BrowserContext. All the belonging pages will be closed without calling their
/// beforeunload hooks.
/// </summary>
/// <param name="browserContextId"></param>
[Experimental]public async Task DisposeBrowserContext(
 Browser.BrowserContextID @browserContextId) {
var resp = await _target.SendRequest("Target.disposeBrowserContext",
new DisposeBrowserContextParams {
BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetTargetInfoParams {
[JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
public sealed partial class GetTargetInfoReturn {
[JsonPropertyName("targetInfo")]public Target.TargetInfo TargetInfo{get;set;}
}
/// <summary>
/// Returns information about a target.
/// </summary>
/// <param name="targetId"></param>
[Experimental]public async Task<GetTargetInfoReturn> GetTargetInfo(
 Target.TargetID? @targetId=default) {
var resp = await _target.SendRequest("Target.getTargetInfo",
new GetTargetInfoParams {
TargetId=@targetId,});
return _target.DeserializeResponse<GetTargetInfoReturn>(resp);
}
public sealed partial class GetTargetsReturn {
/// <summary>
/// The list of targets.
/// </summary>
[JsonPropertyName("targetInfos")]public Target.TargetInfo[] TargetInfos{get;set;}
}
/// <summary>
/// Retrieves a list of available targets.
/// </summary>
public async Task<GetTargetsReturn> GetTargets(
) {
var resp = await _target.SendRequest("Target.getTargets",
VoidData.Instance);
return _target.DeserializeResponse<GetTargetsReturn>(resp);
}
public sealed partial class SendMessageToTargetParams {
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// Identifier of the session.
/// </summary>
[JsonPropertyName("sessionId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.SessionID? SessionId{get;set;}
/// <summary>
/// Deprecated.
/// </summary>
[Obsolete][JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
/// <summary>
/// Sends protocol message over session with given id.
/// Consider using flat mode instead; see commands attachToTarget, setAutoAttach,
/// and crbug.com/991325.
/// </summary>
/// <param name="message"></param>
/// <param name="sessionId">Identifier of the session.</param>
/// <param name="targetId">OBSOLETE Deprecated.</param>
[Obsolete]public async Task SendMessageToTarget(
 string @message,Target.SessionID? @sessionId=default,Target.TargetID? @targetId=default) {
var resp = await _target.SendRequest("Target.sendMessageToTarget",
new SendMessageToTargetParams {
Message=@message,SessionId=@sessionId,TargetId=@targetId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAutoAttachParams {
/// <summary>
/// Whether to auto-attach to related targets.
/// </summary>
[JsonPropertyName("autoAttach")]public bool AutoAttach{get;set;}
/// <summary>
/// Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
/// to run paused targets.
/// </summary>
[JsonPropertyName("waitForDebuggerOnStart")]public bool WaitForDebuggerOnStart{get;set;}
/// <summary>
/// Enables "flat" access to the session via specifying sessionId attribute in the commands.
/// We plan to make this the default, deprecate non-flattened mode,
/// and eventually retire it. See crbug.com/991325.
/// </summary>
[JsonPropertyName("flatten")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Flatten{get;set;}
}
/// <summary>
/// Controls whether to automatically attach to new targets which are considered to be related to
/// this one. When turned on, attaches to all existing related targets as well. When turned off,
/// automatically detaches from all currently attached targets.
/// This also clears all targets added by `autoAttachRelated` from the list of targets to watch
/// for creation of related targets.
/// </summary>
/// <param name="autoAttach">Whether to auto-attach to related targets.</param>
/// <param name="waitForDebuggerOnStart">Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
/// to run paused targets.</param>
/// <param name="flatten">Enables "flat" access to the session via specifying sessionId attribute in the commands.
/// We plan to make this the default, deprecate non-flattened mode,
/// and eventually retire it. See crbug.com/991325.</param>
[Experimental]public async Task SetAutoAttach(
 bool @autoAttach,bool @waitForDebuggerOnStart,bool? @flatten=default) {
var resp = await _target.SendRequest("Target.setAutoAttach",
new SetAutoAttachParams {
AutoAttach=@autoAttach,WaitForDebuggerOnStart=@waitForDebuggerOnStart,Flatten=@flatten,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AutoAttachRelatedParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
/// <summary>
/// Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
/// to run paused targets.
/// </summary>
[JsonPropertyName("waitForDebuggerOnStart")]public bool WaitForDebuggerOnStart{get;set;}
}
/// <summary>
/// Adds the specified target to the list of targets that will be monitored for any related target
/// creation (such as child frames, child workers and new versions of service worker) and reported
/// through `attachedToTarget`. The specified target is also auto-attached.
/// This cancels the effect of any previous `setAutoAttach` and is also cancelled by subsequent
/// `setAutoAttach`. Only available at the Browser target.
/// </summary>
/// <param name="targetId"></param>
/// <param name="waitForDebuggerOnStart">Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
/// to run paused targets.</param>
[Experimental]public async Task AutoAttachRelated(
 Target.TargetID @targetId,bool @waitForDebuggerOnStart) {
var resp = await _target.SendRequest("Target.autoAttachRelated",
new AutoAttachRelatedParams {
TargetId=@targetId,WaitForDebuggerOnStart=@waitForDebuggerOnStart,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDiscoverTargetsParams {
/// <summary>
/// Whether to discover available targets.
/// </summary>
[JsonPropertyName("discover")]public bool Discover{get;set;}
}
/// <summary>
/// Controls whether to discover available targets and notify via
/// `targetCreated/targetInfoChanged/targetDestroyed` events.
/// </summary>
/// <param name="discover">Whether to discover available targets.</param>
public async Task SetDiscoverTargets(
 bool @discover) {
var resp = await _target.SendRequest("Target.setDiscoverTargets",
new SetDiscoverTargetsParams {
Discover=@discover,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetRemoteLocationsParams {
/// <summary>
/// List of remote locations.
/// </summary>
[JsonPropertyName("locations")]public Target.RemoteLocation[] Locations{get;set;}
}
/// <summary>
/// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
/// `true`.
/// </summary>
/// <param name="locations">List of remote locations.</param>
[Experimental]public async Task SetRemoteLocations(
 Target.RemoteLocation[] @locations) {
var resp = await _target.SendRequest("Target.setRemoteLocations",
new SetRemoteLocationsParams {
Locations=@locations,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AttachedToTargetParams {
/// <summary>
/// Identifier assigned to the session used to send/receive messages.
/// </summary>
[JsonPropertyName("sessionId")]public Target.SessionID SessionId{get;set;}
[JsonPropertyName("targetInfo")]public Target.TargetInfo TargetInfo{get;set;}
[JsonPropertyName("waitingForDebugger")]public bool WaitingForDebugger{get;set;}
}
private Action<AttachedToTargetParams>? _onAttachedToTarget;
/// <summary>
/// Issued when attached to target because of auto-attach or `attachToTarget` command.
/// </summary>
[Experimental]public event Action<AttachedToTargetParams> OnAttachedToTarget {
add => _onAttachedToTarget += value; remove => _onAttachedToTarget -= value;}
public sealed partial class DetachedFromTargetParams {
/// <summary>
/// Detached session identifier.
/// </summary>
[JsonPropertyName("sessionId")]public Target.SessionID SessionId{get;set;}
/// <summary>
/// Deprecated.
/// </summary>
[Obsolete][JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
private Action<DetachedFromTargetParams>? _onDetachedFromTarget;
/// <summary>
/// Issued when detached from target for any reason (including `detachFromTarget` command). Can be
/// issued multiple times per target if multiple sessions have been attached to it.
/// </summary>
[Experimental]public event Action<DetachedFromTargetParams> OnDetachedFromTarget {
add => _onDetachedFromTarget += value; remove => _onDetachedFromTarget -= value;}
public sealed partial class ReceivedMessageFromTargetParams {
/// <summary>
/// Identifier of a session which sends a message.
/// </summary>
[JsonPropertyName("sessionId")]public Target.SessionID SessionId{get;set;}
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// Deprecated.
/// </summary>
[Obsolete][JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
private Action<ReceivedMessageFromTargetParams>? _onReceivedMessageFromTarget;
/// <summary>
/// Notifies about a new protocol message received from the session (as reported in
/// `attachedToTarget` event).
/// </summary>
public event Action<ReceivedMessageFromTargetParams> OnReceivedMessageFromTarget {
add => _onReceivedMessageFromTarget += value; remove => _onReceivedMessageFromTarget -= value;}
public sealed partial class TargetCreatedParams {
[JsonPropertyName("targetInfo")]public Target.TargetInfo TargetInfo{get;set;}
}
private Action<TargetCreatedParams>? _onTargetCreated;
/// <summary>
/// Issued when a possible inspection target is created.
/// </summary>
public event Action<TargetCreatedParams> OnTargetCreated {
add => _onTargetCreated += value; remove => _onTargetCreated -= value;}
public sealed partial class TargetDestroyedParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
}
private Action<TargetDestroyedParams>? _onTargetDestroyed;
/// <summary>
/// Issued when a target is destroyed.
/// </summary>
public event Action<TargetDestroyedParams> OnTargetDestroyed {
add => _onTargetDestroyed += value; remove => _onTargetDestroyed -= value;}
public sealed partial class TargetCrashedParams {
[JsonPropertyName("targetId")]public Target.TargetID TargetId{get;set;}
/// <summary>
/// Termination status type.
/// </summary>
[JsonPropertyName("status")]public string Status{get;set;}
/// <summary>
/// Termination error code.
/// </summary>
[JsonPropertyName("errorCode")]public long ErrorCode{get;set;}
}
private Action<TargetCrashedParams>? _onTargetCrashed;
/// <summary>
/// Issued when a target has crashed.
/// </summary>
public event Action<TargetCrashedParams> OnTargetCrashed {
add => _onTargetCrashed += value; remove => _onTargetCrashed -= value;}
public sealed partial class TargetInfoChangedParams {
[JsonPropertyName("targetInfo")]public Target.TargetInfo TargetInfo{get;set;}
}
private Action<TargetInfoChangedParams>? _onTargetInfoChanged;
/// <summary>
/// Issued when some information about a target has changed. This only happens between
/// `targetCreated` and `targetDestroyed`.
/// </summary>
public event Action<TargetInfoChangedParams> OnTargetInfoChanged {
add => _onTargetInfoChanged += value; remove => _onTargetInfoChanged -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Target.attachedToTarget":
_onAttachedToTarget?.Invoke(_target.DeserializeEvent<AttachedToTargetParams>(data));
break;
case "Target.detachedFromTarget":
_onDetachedFromTarget?.Invoke(_target.DeserializeEvent<DetachedFromTargetParams>(data));
break;
case "Target.receivedMessageFromTarget":
_onReceivedMessageFromTarget?.Invoke(_target.DeserializeEvent<ReceivedMessageFromTargetParams>(data));
break;
case "Target.targetCreated":
_onTargetCreated?.Invoke(_target.DeserializeEvent<TargetCreatedParams>(data));
break;
case "Target.targetDestroyed":
_onTargetDestroyed?.Invoke(_target.DeserializeEvent<TargetDestroyedParams>(data));
break;
case "Target.targetCrashed":
_onTargetCrashed?.Invoke(_target.DeserializeEvent<TargetCrashedParams>(data));
break;
case "Target.targetInfoChanged":
_onTargetInfoChanged?.Invoke(_target.DeserializeEvent<TargetInfoChangedParams>(data));
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
_onAttachedToTarget = null;
_onDetachedFromTarget = null;
_onReceivedMessageFromTarget = null;
_onTargetCreated = null;
_onTargetDestroyed = null;
_onTargetCrashed = null;
_onTargetInfoChanged = null;
}
}
