using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// The Browser domain defines methods and events for browser managing.
/// </summary>
public sealed partial class BrowserDomain {
private readonly ConnectedTarget _target;
public BrowserDomain(ConnectedTarget target) => _target = target;
public sealed partial class SetPermissionParams {
/// <summary>
/// Descriptor of permission to override.
/// </summary>
[JsonPropertyName("permission")]public Browser.PermissionDescriptor Permission{get;set;}
/// <summary>
/// Setting of the permission.
/// </summary>
[JsonPropertyName("setting")]public Browser.PermissionSetting Setting{get;set;}
/// <summary>
/// Origin the permission applies to, all origins if not specified.
/// </summary>
[JsonPropertyName("origin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Origin{get;set;}
/// <summary>
/// Context to override. When omitted, default browser context is used.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Set permission settings for given origin.
/// </summary>
/// <param name="permission">Descriptor of permission to override.</param>
/// <param name="setting">Setting of the permission.</param>
/// <param name="origin">Origin the permission applies to, all origins if not specified.</param>
/// <param name="browserContextId">Context to override. When omitted, default browser context is used.</param>
[Experimental]public async Task SetPermission(
 Browser.PermissionDescriptor @permission,Browser.PermissionSetting @setting,string? @origin=default,Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Browser.setPermission",
new SetPermissionParams {
Permission=@permission,Setting=@setting,Origin=@origin,BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GrantPermissionsParams {
[JsonPropertyName("permissions")]public Browser.PermissionType[] Permissions{get;set;}
/// <summary>
/// Origin the permission applies to, all origins if not specified.
/// </summary>
[JsonPropertyName("origin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Origin{get;set;}
/// <summary>
/// BrowserContext to override permissions. When omitted, default browser context is used.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Grant specific permissions to the given origin and reject all others.
/// </summary>
/// <param name="permissions"></param>
/// <param name="origin">Origin the permission applies to, all origins if not specified.</param>
/// <param name="browserContextId">BrowserContext to override permissions. When omitted, default browser context is used.</param>
[Experimental]public async Task GrantPermissions(
 Browser.PermissionType[] @permissions,string? @origin=default,Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Browser.grantPermissions",
new GrantPermissionsParams {
Permissions=@permissions,Origin=@origin,BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ResetPermissionsParams {
/// <summary>
/// BrowserContext to reset permissions. When omitted, default browser context is used.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Reset all permission management for all origins.
/// </summary>
/// <param name="browserContextId">BrowserContext to reset permissions. When omitted, default browser context is used.</param>
[Experimental]public async Task ResetPermissions(
 Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Browser.resetPermissions",
new ResetPermissionsParams {
BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDownloadBehaviorParams {
/// <summary>
/// Whether to allow all or deny all download requests, or use default Chrome behavior if
/// available (otherwise deny). |allowAndName| allows download and names files according to
/// their dowmload guids.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum BehaviorEnum {
[EnumMember(Value = "deny")] Deny,
[EnumMember(Value = "allow")] Allow,
[EnumMember(Value = "allowAndName")] AllowAndName,
[EnumMember(Value = "default")] Default,
}
[JsonPropertyName("behavior")]public BehaviorEnum Behavior{get;set;}
/// <summary>
/// BrowserContext to set download behavior. When omitted, default browser context is used.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
/// <summary>
/// The default path to save downloaded files to. This is required if behavior is set to 'allow'
/// or 'allowAndName'.
/// </summary>
[JsonPropertyName("downloadPath")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? DownloadPath{get;set;}
/// <summary>
/// Whether to emit download events (defaults to false).
/// </summary>
[JsonPropertyName("eventsEnabled")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? EventsEnabled{get;set;}
}
/// <summary>
/// Set the behavior when downloading a file.
/// </summary>
/// <param name="behavior">Whether to allow all or deny all download requests, or use default Chrome behavior if
/// available (otherwise deny). |allowAndName| allows download and names files according to
/// their dowmload guids.</param>
/// <param name="browserContextId">BrowserContext to set download behavior. When omitted, default browser context is used.</param>
/// <param name="downloadPath">The default path to save downloaded files to. This is required if behavior is set to 'allow'
/// or 'allowAndName'.</param>
/// <param name="eventsEnabled">Whether to emit download events (defaults to false).</param>
[Experimental]public async Task SetDownloadBehavior(
 SetDownloadBehaviorParams.BehaviorEnum @behavior,Browser.BrowserContextID? @browserContextId=default,string? @downloadPath=default,bool? @eventsEnabled=default) {
var resp = await _target.SendRequest("Browser.setDownloadBehavior",
new SetDownloadBehaviorParams {
Behavior=@behavior,BrowserContextId=@browserContextId,DownloadPath=@downloadPath,EventsEnabled=@eventsEnabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CancelDownloadParams {
/// <summary>
/// Global unique identifier of the download.
/// </summary>
[JsonPropertyName("guid")]public string Guid{get;set;}
/// <summary>
/// BrowserContext to perform the action in. When omitted, default browser context is used.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Cancel a download if in progress
/// </summary>
/// <param name="guid">Global unique identifier of the download.</param>
/// <param name="browserContextId">BrowserContext to perform the action in. When omitted, default browser context is used.</param>
[Experimental]public async Task CancelDownload(
 string @guid,Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Browser.cancelDownload",
new CancelDownloadParams {
Guid=@guid,BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Close browser gracefully.
/// </summary>
public async Task Close(
) {
var resp = await _target.SendRequest("Browser.close",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Crashes browser on the main thread.
/// </summary>
[Experimental]public async Task Crash(
) {
var resp = await _target.SendRequest("Browser.crash",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Crashes GPU process.
/// </summary>
[Experimental]public async Task CrashGpuProcess(
) {
var resp = await _target.SendRequest("Browser.crashGpuProcess",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetVersionReturn {
/// <summary>
/// Protocol version.
/// </summary>
[JsonPropertyName("protocolVersion")]public string ProtocolVersion{get;set;}
/// <summary>
/// Product name.
/// </summary>
[JsonPropertyName("product")]public string Product{get;set;}
/// <summary>
/// Product revision.
/// </summary>
[JsonPropertyName("revision")]public string Revision{get;set;}
/// <summary>
/// User-Agent.
/// </summary>
[JsonPropertyName("userAgent")]public string UserAgent{get;set;}
/// <summary>
/// V8 version.
/// </summary>
[JsonPropertyName("jsVersion")]public string JsVersion{get;set;}
}
/// <summary>
/// Returns version information.
/// </summary>
public async Task<GetVersionReturn> GetVersion(
) {
var resp = await _target.SendRequest("Browser.getVersion",
VoidData.Instance);
return _target.DeserializeResponse<GetVersionReturn>(resp);
}
public sealed partial class GetBrowserCommandLineReturn {
/// <summary>
/// Commandline parameters
/// </summary>
[JsonPropertyName("arguments")]public string[] Arguments{get;set;}
}
/// <summary>
/// Returns the command line switches for the browser process if, and only if
/// --enable-automation is on the commandline.
/// </summary>
[Experimental]public async Task<GetBrowserCommandLineReturn> GetBrowserCommandLine(
) {
var resp = await _target.SendRequest("Browser.getBrowserCommandLine",
VoidData.Instance);
return _target.DeserializeResponse<GetBrowserCommandLineReturn>(resp);
}
public sealed partial class GetHistogramsParams {
/// <summary>
/// Requested substring in name. Only histograms which have query as a
/// substring in their name are extracted. An empty or absent query returns
/// all histograms.
/// </summary>
[JsonPropertyName("query")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Query{get;set;}
/// <summary>
/// If true, retrieve delta since last call.
/// </summary>
[JsonPropertyName("delta")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Delta{get;set;}
}
public sealed partial class GetHistogramsReturn {
/// <summary>
/// Histograms.
/// </summary>
[JsonPropertyName("histograms")]public Browser.Histogram[] Histograms{get;set;}
}
/// <summary>
/// Get Chrome histograms.
/// </summary>
/// <param name="query">Requested substring in name. Only histograms which have query as a
/// substring in their name are extracted. An empty or absent query returns
/// all histograms.</param>
/// <param name="delta">If true, retrieve delta since last call.</param>
[Experimental]public async Task<GetHistogramsReturn> GetHistograms(
 string? @query=default,bool? @delta=default) {
var resp = await _target.SendRequest("Browser.getHistograms",
new GetHistogramsParams {
Query=@query,Delta=@delta,});
return _target.DeserializeResponse<GetHistogramsReturn>(resp);
}
public sealed partial class GetHistogramParams {
/// <summary>
/// Requested histogram name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// If true, retrieve delta since last call.
/// </summary>
[JsonPropertyName("delta")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Delta{get;set;}
}
public sealed partial class GetHistogramReturn {
/// <summary>
/// Histogram.
/// </summary>
[JsonPropertyName("histogram")]public Browser.Histogram Histogram{get;set;}
}
/// <summary>
/// Get a Chrome histogram by name.
/// </summary>
/// <param name="name">Requested histogram name.</param>
/// <param name="delta">If true, retrieve delta since last call.</param>
[Experimental]public async Task<GetHistogramReturn> GetHistogram(
 string @name,bool? @delta=default) {
var resp = await _target.SendRequest("Browser.getHistogram",
new GetHistogramParams {
Name=@name,Delta=@delta,});
return _target.DeserializeResponse<GetHistogramReturn>(resp);
}
public sealed partial class GetWindowBoundsParams {
/// <summary>
/// Browser window id.
/// </summary>
[JsonPropertyName("windowId")]public Browser.WindowID WindowId{get;set;}
}
public sealed partial class GetWindowBoundsReturn {
/// <summary>
/// Bounds information of the window. When window state is 'minimized', the restored window
/// position and size are returned.
/// </summary>
[JsonPropertyName("bounds")]public Browser.Bounds Bounds{get;set;}
}
/// <summary>
/// Get position and size of the browser window.
/// </summary>
/// <param name="windowId">Browser window id.</param>
[Experimental]public async Task<GetWindowBoundsReturn> GetWindowBounds(
 Browser.WindowID @windowId) {
var resp = await _target.SendRequest("Browser.getWindowBounds",
new GetWindowBoundsParams {
WindowId=@windowId,});
return _target.DeserializeResponse<GetWindowBoundsReturn>(resp);
}
public sealed partial class GetWindowForTargetParams {
/// <summary>
/// Devtools agent host id. If called as a part of the session, associated targetId is used.
/// </summary>
[JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
public sealed partial class GetWindowForTargetReturn {
/// <summary>
/// Browser window id.
/// </summary>
[JsonPropertyName("windowId")]public Browser.WindowID WindowId{get;set;}
/// <summary>
/// Bounds information of the window. When window state is 'minimized', the restored window
/// position and size are returned.
/// </summary>
[JsonPropertyName("bounds")]public Browser.Bounds Bounds{get;set;}
}
/// <summary>
/// Get the browser window that contains the devtools target.
/// </summary>
/// <param name="targetId">Devtools agent host id. If called as a part of the session, associated targetId is used.</param>
[Experimental]public async Task<GetWindowForTargetReturn> GetWindowForTarget(
 Target.TargetID? @targetId=default) {
var resp = await _target.SendRequest("Browser.getWindowForTarget",
new GetWindowForTargetParams {
TargetId=@targetId,});
return _target.DeserializeResponse<GetWindowForTargetReturn>(resp);
}
public sealed partial class SetWindowBoundsParams {
/// <summary>
/// Browser window id.
/// </summary>
[JsonPropertyName("windowId")]public Browser.WindowID WindowId{get;set;}
/// <summary>
/// New window bounds. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined
/// with 'left', 'top', 'width' or 'height'. Leaves unspecified fields unchanged.
/// </summary>
[JsonPropertyName("bounds")]public Browser.Bounds Bounds{get;set;}
}
/// <summary>
/// Set position and/or size of the browser window.
/// </summary>
/// <param name="windowId">Browser window id.</param>
/// <param name="bounds">New window bounds. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined
/// with 'left', 'top', 'width' or 'height'. Leaves unspecified fields unchanged.</param>
[Experimental]public async Task SetWindowBounds(
 Browser.WindowID @windowId,Browser.Bounds @bounds) {
var resp = await _target.SendRequest("Browser.setWindowBounds",
new SetWindowBoundsParams {
WindowId=@windowId,Bounds=@bounds,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDockTileParams {
[JsonPropertyName("badgeLabel")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BadgeLabel{get;set;}
/// <summary>
/// Png encoded image. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("image")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Image{get;set;}
}
/// <summary>
/// Set dock tile details, platform-specific.
/// </summary>
/// <param name="badgeLabel"></param>
/// <param name="image">Png encoded image. (Encoded as a base64 string when passed over JSON)</param>
[Experimental]public async Task SetDockTile(
 string? @badgeLabel=default,string? @image=default) {
var resp = await _target.SendRequest("Browser.setDockTile",
new SetDockTileParams {
BadgeLabel=@badgeLabel,Image=@image,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ExecuteBrowserCommandParams {
[JsonPropertyName("commandId")]public Browser.BrowserCommandId CommandId{get;set;}
}
/// <summary>
/// Invoke custom browser commands used by telemetry.
/// </summary>
/// <param name="commandId"></param>
[Experimental]public async Task ExecuteBrowserCommand(
 Browser.BrowserCommandId @commandId) {
var resp = await _target.SendRequest("Browser.executeBrowserCommand",
new ExecuteBrowserCommandParams {
CommandId=@commandId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DownloadWillBeginParams {
/// <summary>
/// Id of the frame that caused the download to begin.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Global unique identifier of the download.
/// </summary>
[JsonPropertyName("guid")]public string Guid{get;set;}
/// <summary>
/// URL of the resource being downloaded.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Suggested file name of the resource (the actual name of the file saved on disk may differ).
/// </summary>
[JsonPropertyName("suggestedFilename")]public string SuggestedFilename{get;set;}
}
private Action<DownloadWillBeginParams>? _onDownloadWillBegin;
/// <summary>
/// Fired when page is about to start a download.
/// </summary>
[Experimental]public event Action<DownloadWillBeginParams> OnDownloadWillBegin {
add => _onDownloadWillBegin += value; remove => _onDownloadWillBegin -= value;}
public sealed partial class DownloadProgressParams {
/// <summary>
/// Global unique identifier of the download.
/// </summary>
[JsonPropertyName("guid")]public string Guid{get;set;}
/// <summary>
/// Total expected bytes to download.
/// </summary>
[JsonPropertyName("totalBytes")]public double TotalBytes{get;set;}
/// <summary>
/// Total bytes received.
/// </summary>
[JsonPropertyName("receivedBytes")]public double ReceivedBytes{get;set;}
/// <summary>
/// Download status.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StateEnum {
[EnumMember(Value = "inProgress")] InProgress,
[EnumMember(Value = "completed")] Completed,
[EnumMember(Value = "canceled")] Canceled,
}
[JsonPropertyName("state")]public StateEnum State{get;set;}
}
private Action<DownloadProgressParams>? _onDownloadProgress;
/// <summary>
/// Fired when download makes progress. Last call has |done| == true.
/// </summary>
[Experimental]public event Action<DownloadProgressParams> OnDownloadProgress {
add => _onDownloadProgress += value; remove => _onDownloadProgress -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Browser.downloadWillBegin":
_onDownloadWillBegin?.Invoke(_target.DeserializeEvent<DownloadWillBeginParams>(data));
break;
case "Browser.downloadProgress":
_onDownloadProgress?.Invoke(_target.DeserializeEvent<DownloadProgressParams>(data));
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
_onDownloadWillBegin = null;
_onDownloadProgress = null;
}
}
