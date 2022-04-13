using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Animation;
/// <summary>
/// Animation instance.
/// </summary>
public sealed partial class Animation {
/// <summary>
/// `Animation`'s id.
/// </summary>
[JsonPropertyName("id")]public string Id{get;set;}
/// <summary>
/// `Animation`'s name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// `Animation`'s internal paused state.
/// </summary>
[JsonPropertyName("pausedState")]public bool PausedState{get;set;}
/// <summary>
/// `Animation`'s play state.
/// </summary>
[JsonPropertyName("playState")]public string PlayState{get;set;}
/// <summary>
/// `Animation`'s playback rate.
/// </summary>
[JsonPropertyName("playbackRate")]public double PlaybackRate{get;set;}
/// <summary>
/// `Animation`'s start time.
/// </summary>
[JsonPropertyName("startTime")]public double StartTime{get;set;}
/// <summary>
/// `Animation`'s current time.
/// </summary>
[JsonPropertyName("currentTime")]public double CurrentTime{get;set;}
/// <summary>
/// Animation type of `Animation`.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "CSSTransition")] CSSTransition,
[EnumMember(Value = "CSSAnimation")] CSSAnimation,
[EnumMember(Value = "WebAnimation")] WebAnimation,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// `Animation`'s source animation node.
/// </summary>
[JsonPropertyName("source")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AnimationEffect? Source{get;set;}
/// <summary>
/// A unique ID for `Animation` representing the sources that triggered this CSS
/// animation/transition.
/// </summary>
[JsonPropertyName("cssId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? CssId{get;set;}
}
