using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain provides experimental commands only supported in headless mode.
/// </summary>
[Experimental]public sealed partial class HeadlessExperimentalDomain {
private readonly ConnectedTarget _target;
public HeadlessExperimentalDomain(ConnectedTarget target) => _target = target;
public sealed partial class BeginFrameParams {
/// <summary>
/// Timestamp of this BeginFrame in Renderer TimeTicks (milliseconds of uptime). If not set,
/// the current time will be used.
/// </summary>
[JsonPropertyName("frameTimeTicks")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? FrameTimeTicks{get;set;}
/// <summary>
/// The interval between BeginFrames that is reported to the compositor, in milliseconds.
/// Defaults to a 60 frames/second interval, i.e. about 16.666 milliseconds.
/// </summary>
[JsonPropertyName("interval")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Interval{get;set;}
/// <summary>
/// Whether updates should not be committed and drawn onto the display. False by default. If
/// true, only side effects of the BeginFrame will be run, such as layout and animations, but
/// any visual updates may not be visible on the display or in screenshots.
/// </summary>
[JsonPropertyName("noDisplayUpdates")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? NoDisplayUpdates{get;set;}
/// <summary>
/// If set, a screenshot of the frame will be captured and returned in the response. Otherwise,
/// no screenshot will be captured. Note that capturing a screenshot can fail, for example,
/// during renderer initialization. In such a case, no screenshot data will be returned.
/// </summary>
[JsonPropertyName("screenshot")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public HeadlessExperimental.ScreenshotParams? Screenshot{get;set;}
}
public sealed partial class BeginFrameReturn {
/// <summary>
/// Whether the BeginFrame resulted in damage and, thus, a new frame was committed to the
/// display. Reported for diagnostic uses, may be removed in the future.
/// </summary>
[JsonPropertyName("hasDamage")]public bool HasDamage{get;set;}
/// <summary>
/// Base64-encoded image data of the screenshot, if one was requested and successfully taken. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("screenshotData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ScreenshotData{get;set;}
}
/// <summary>
/// Sends a BeginFrame to the target and returns when the frame was completed. Optionally captures a
/// screenshot from the resulting frame. Requires that the target was created with enabled
/// BeginFrameControl. Designed for use with --run-all-compositor-stages-before-draw, see also
/// https://goo.gl/3zHXhB for more background.
/// </summary>
/// <param name="frameTimeTicks">Timestamp of this BeginFrame in Renderer TimeTicks (milliseconds of uptime). If not set,
/// the current time will be used.</param>
/// <param name="interval">The interval between BeginFrames that is reported to the compositor, in milliseconds.
/// Defaults to a 60 frames/second interval, i.e. about 16.666 milliseconds.</param>
/// <param name="noDisplayUpdates">Whether updates should not be committed and drawn onto the display. False by default. If
/// true, only side effects of the BeginFrame will be run, such as layout and animations, but
/// any visual updates may not be visible on the display or in screenshots.</param>
/// <param name="screenshot">If set, a screenshot of the frame will be captured and returned in the response. Otherwise,
/// no screenshot will be captured. Note that capturing a screenshot can fail, for example,
/// during renderer initialization. In such a case, no screenshot data will be returned.</param>
public async Task<BeginFrameReturn> BeginFrame(
 double? @frameTimeTicks=default,double? @interval=default,bool? @noDisplayUpdates=default,HeadlessExperimental.ScreenshotParams? @screenshot=default) {
var resp = await _target.SendRequest("HeadlessExperimental.beginFrame",
new BeginFrameParams {
FrameTimeTicks=@frameTimeTicks,Interval=@interval,NoDisplayUpdates=@noDisplayUpdates,Screenshot=@screenshot,});
return _target.DeserializeResponse<BeginFrameReturn>(resp);
}
/// <summary>
/// Disables headless events for the target.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("HeadlessExperimental.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables headless events for the target.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("HeadlessExperimental.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class NeedsBeginFramesChangedParams {
/// <summary>
/// True if BeginFrames are needed, false otherwise.
/// </summary>
[JsonPropertyName("needsBeginFrames")]public bool NeedsBeginFrames{get;set;}
}
private Action<NeedsBeginFramesChangedParams>? _onNeedsBeginFramesChanged;
/// <summary>
/// Issued when the target starts or stops needing BeginFrames.
/// Deprecated. Issue beginFrame unconditionally instead and use result from
/// beginFrame to detect whether the frames were suppressed.
/// </summary>
[Obsolete]public event Action<NeedsBeginFramesChangedParams> OnNeedsBeginFramesChanged {
add => _onNeedsBeginFramesChanged += value; remove => _onNeedsBeginFramesChanged -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "HeadlessExperimental.needsBeginFramesChanged":
_onNeedsBeginFramesChanged?.Invoke(_target.DeserializeEvent<NeedsBeginFramesChangedParams>(data));
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
_onNeedsBeginFramesChanged = null;
}
}
