using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class AnimationDomain {
private readonly ConnectedTarget _target;
public AnimationDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables animation domain notifications.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Animation.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables animation domain notifications.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Animation.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetCurrentTimeParams {
/// <summary>
/// Id of animation.
/// </summary>
[JsonPropertyName("id")]public string Id{get;set;}
}
public sealed partial class GetCurrentTimeReturn {
/// <summary>
/// Current time of the page.
/// </summary>
[JsonPropertyName("currentTime")]public double CurrentTime{get;set;}
}
/// <summary>
/// Returns the current time of the an animation.
/// </summary>
/// <param name="id">Id of animation.</param>
public async Task<GetCurrentTimeReturn> GetCurrentTime(
 string @id) {
var resp = await _target.SendRequest("Animation.getCurrentTime",
new GetCurrentTimeParams {
Id=@id,});
return _target.DeserializeResponse<GetCurrentTimeReturn>(resp);
}
public sealed partial class GetPlaybackRateReturn {
/// <summary>
/// Playback rate for animations on page.
/// </summary>
[JsonPropertyName("playbackRate")]public double PlaybackRate{get;set;}
}
/// <summary>
/// Gets the playback rate of the document timeline.
/// </summary>
public async Task<GetPlaybackRateReturn> GetPlaybackRate(
) {
var resp = await _target.SendRequest("Animation.getPlaybackRate",
VoidData.Instance);
return _target.DeserializeResponse<GetPlaybackRateReturn>(resp);
}
public sealed partial class ReleaseAnimationsParams {
/// <summary>
/// List of animation ids to seek.
/// </summary>
[JsonPropertyName("animations")]public string[] Animations{get;set;}
}
/// <summary>
/// Releases a set of animations to no longer be manipulated.
/// </summary>
/// <param name="animations">List of animation ids to seek.</param>
public async Task ReleaseAnimations(
 string[] @animations) {
var resp = await _target.SendRequest("Animation.releaseAnimations",
new ReleaseAnimationsParams {
Animations=@animations,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ResolveAnimationParams {
/// <summary>
/// Animation id.
/// </summary>
[JsonPropertyName("animationId")]public string AnimationId{get;set;}
}
public sealed partial class ResolveAnimationReturn {
/// <summary>
/// Corresponding remote object.
/// </summary>
[JsonPropertyName("remoteObject")]public Runtime.RemoteObject RemoteObject{get;set;}
}
/// <summary>
/// Gets the remote object of the Animation.
/// </summary>
/// <param name="animationId">Animation id.</param>
public async Task<ResolveAnimationReturn> ResolveAnimation(
 string @animationId) {
var resp = await _target.SendRequest("Animation.resolveAnimation",
new ResolveAnimationParams {
AnimationId=@animationId,});
return _target.DeserializeResponse<ResolveAnimationReturn>(resp);
}
public sealed partial class SeekAnimationsParams {
/// <summary>
/// List of animation ids to seek.
/// </summary>
[JsonPropertyName("animations")]public string[] Animations{get;set;}
/// <summary>
/// Set the current time of each animation.
/// </summary>
[JsonPropertyName("currentTime")]public double CurrentTime{get;set;}
}
/// <summary>
/// Seek a set of animations to a particular time within each animation.
/// </summary>
/// <param name="animations">List of animation ids to seek.</param>
/// <param name="currentTime">Set the current time of each animation.</param>
public async Task SeekAnimations(
 string[] @animations,double @currentTime) {
var resp = await _target.SendRequest("Animation.seekAnimations",
new SeekAnimationsParams {
Animations=@animations,CurrentTime=@currentTime,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPausedParams {
/// <summary>
/// Animations to set the pause state of.
/// </summary>
[JsonPropertyName("animations")]public string[] Animations{get;set;}
/// <summary>
/// Paused state to set to.
/// </summary>
[JsonPropertyName("paused")]public bool Paused{get;set;}
}
/// <summary>
/// Sets the paused state of a set of animations.
/// </summary>
/// <param name="animations">Animations to set the pause state of.</param>
/// <param name="paused">Paused state to set to.</param>
public async Task SetPaused(
 string[] @animations,bool @paused) {
var resp = await _target.SendRequest("Animation.setPaused",
new SetPausedParams {
Animations=@animations,Paused=@paused,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPlaybackRateParams {
/// <summary>
/// Playback rate for animations on page
/// </summary>
[JsonPropertyName("playbackRate")]public double PlaybackRate{get;set;}
}
/// <summary>
/// Sets the playback rate of the document timeline.
/// </summary>
/// <param name="playbackRate">Playback rate for animations on page</param>
public async Task SetPlaybackRate(
 double @playbackRate) {
var resp = await _target.SendRequest("Animation.setPlaybackRate",
new SetPlaybackRateParams {
PlaybackRate=@playbackRate,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetTimingParams {
/// <summary>
/// Animation id.
/// </summary>
[JsonPropertyName("animationId")]public string AnimationId{get;set;}
/// <summary>
/// Duration of the animation.
/// </summary>
[JsonPropertyName("duration")]public double Duration{get;set;}
/// <summary>
/// Delay of the animation.
/// </summary>
[JsonPropertyName("delay")]public double Delay{get;set;}
}
/// <summary>
/// Sets the timing of an animation node.
/// </summary>
/// <param name="animationId">Animation id.</param>
/// <param name="duration">Duration of the animation.</param>
/// <param name="delay">Delay of the animation.</param>
public async Task SetTiming(
 string @animationId,double @duration,double @delay) {
var resp = await _target.SendRequest("Animation.setTiming",
new SetTimingParams {
AnimationId=@animationId,Duration=@duration,Delay=@delay,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AnimationCanceledParams {
/// <summary>
/// Id of the animation that was cancelled.
/// </summary>
[JsonPropertyName("id")]public string Id{get;set;}
}
private Action<AnimationCanceledParams>? _onAnimationCanceled;
/// <summary>
/// Event for when an animation has been cancelled.
/// </summary>
public event Action<AnimationCanceledParams> OnAnimationCanceled {
add => _onAnimationCanceled += value; remove => _onAnimationCanceled -= value;}
public sealed partial class AnimationCreatedParams {
/// <summary>
/// Id of the animation that was created.
/// </summary>
[JsonPropertyName("id")]public string Id{get;set;}
}
private Action<AnimationCreatedParams>? _onAnimationCreated;
/// <summary>
/// Event for each animation that has been created.
/// </summary>
public event Action<AnimationCreatedParams> OnAnimationCreated {
add => _onAnimationCreated += value; remove => _onAnimationCreated -= value;}
public sealed partial class AnimationStartedParams {
/// <summary>
/// Animation that was started.
/// </summary>
[JsonPropertyName("animation")]public Animation.Animation Animation{get;set;}
}
private Action<AnimationStartedParams>? _onAnimationStarted;
/// <summary>
/// Event for animation that has been started.
/// </summary>
public event Action<AnimationStartedParams> OnAnimationStarted {
add => _onAnimationStarted += value; remove => _onAnimationStarted -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Animation.animationCanceled":
_onAnimationCanceled?.Invoke(_target.DeserializeEvent<AnimationCanceledParams>(data));
break;
case "Animation.animationCreated":
_onAnimationCreated?.Invoke(_target.DeserializeEvent<AnimationCreatedParams>(data));
break;
case "Animation.animationStarted":
_onAnimationStarted?.Invoke(_target.DeserializeEvent<AnimationStartedParams>(data));
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
_onAnimationCanceled = null;
_onAnimationCreated = null;
_onAnimationStarted = null;
}
}
