using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// A domain for interacting with Cast, Presentation API, and Remote Playback API
/// functionalities.
/// </summary>
[Experimental]public sealed partial class CastDomain {
private readonly ConnectedTarget _target;
public CastDomain(ConnectedTarget target) => _target = target;
public sealed partial class EnableParams {
[JsonPropertyName("presentationUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PresentationUrl{get;set;}
}
/// <summary>
/// Starts observing for sinks that can be used for tab mirroring, and if set,
/// sinks compatible with |presentationUrl| as well. When sinks are found, a
/// |sinksUpdated| event is fired.
/// Also starts observing for issue messages. When an issue is added or removed,
/// an |issueUpdated| event is fired.
/// </summary>
/// <param name="presentationUrl"></param>
public async Task Enable(
 string? @presentationUrl=default) {
var resp = await _target.SendRequest("Cast.enable",
new EnableParams {
PresentationUrl=@presentationUrl,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Stops observing for sinks and issues.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Cast.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetSinkToUseParams {
[JsonPropertyName("sinkName")]public string SinkName{get;set;}
}
/// <summary>
/// Sets a sink to be used when the web page requests the browser to choose a
/// sink via Presentation API, Remote Playback API, or Cast SDK.
/// </summary>
/// <param name="sinkName"></param>
public async Task SetSinkToUse(
 string @sinkName) {
var resp = await _target.SendRequest("Cast.setSinkToUse",
new SetSinkToUseParams {
SinkName=@sinkName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartDesktopMirroringParams {
[JsonPropertyName("sinkName")]public string SinkName{get;set;}
}
/// <summary>
/// Starts mirroring the desktop to the sink.
/// </summary>
/// <param name="sinkName"></param>
public async Task StartDesktopMirroring(
 string @sinkName) {
var resp = await _target.SendRequest("Cast.startDesktopMirroring",
new StartDesktopMirroringParams {
SinkName=@sinkName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartTabMirroringParams {
[JsonPropertyName("sinkName")]public string SinkName{get;set;}
}
/// <summary>
/// Starts mirroring the tab to the sink.
/// </summary>
/// <param name="sinkName"></param>
public async Task StartTabMirroring(
 string @sinkName) {
var resp = await _target.SendRequest("Cast.startTabMirroring",
new StartTabMirroringParams {
SinkName=@sinkName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopCastingParams {
[JsonPropertyName("sinkName")]public string SinkName{get;set;}
}
/// <summary>
/// Stops the active Cast session on the sink.
/// </summary>
/// <param name="sinkName"></param>
public async Task StopCasting(
 string @sinkName) {
var resp = await _target.SendRequest("Cast.stopCasting",
new StopCastingParams {
SinkName=@sinkName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SinksUpdatedParams {
[JsonPropertyName("sinks")]public Cast.Sink[] Sinks{get;set;}
}
private Action<SinksUpdatedParams>? _onSinksUpdated;
/// <summary>
/// This is fired whenever the list of available sinks changes. A sink is a
/// device or a software surface that you can cast to.
/// </summary>
public event Action<SinksUpdatedParams> OnSinksUpdated {
add => _onSinksUpdated += value; remove => _onSinksUpdated -= value;}
public sealed partial class IssueUpdatedParams {
[JsonPropertyName("issueMessage")]public string IssueMessage{get;set;}
}
private Action<IssueUpdatedParams>? _onIssueUpdated;
/// <summary>
/// This is fired whenever the outstanding issue/error message changes.
/// |issueMessage| is empty if there is no issue.
/// </summary>
public event Action<IssueUpdatedParams> OnIssueUpdated {
add => _onIssueUpdated += value; remove => _onIssueUpdated -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Cast.sinksUpdated":
_onSinksUpdated?.Invoke(_target.DeserializeEvent<SinksUpdatedParams>(data));
break;
case "Cast.issueUpdated":
_onIssueUpdated?.Invoke(_target.DeserializeEvent<IssueUpdatedParams>(data));
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
_onSinksUpdated = null;
_onIssueUpdated = null;
}
}
