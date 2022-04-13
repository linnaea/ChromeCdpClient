using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Animation;
/// <summary>
/// AnimationEffect instance
/// </summary>
public sealed partial class AnimationEffect {
/// <summary>
/// `AnimationEffect`'s delay.
/// </summary>
[JsonPropertyName("delay")]public double Delay{get;set;}
/// <summary>
/// `AnimationEffect`'s end delay.
/// </summary>
[JsonPropertyName("endDelay")]public double EndDelay{get;set;}
/// <summary>
/// `AnimationEffect`'s iteration start.
/// </summary>
[JsonPropertyName("iterationStart")]public double IterationStart{get;set;}
/// <summary>
/// `AnimationEffect`'s iterations.
/// </summary>
[JsonPropertyName("iterations")]public double Iterations{get;set;}
/// <summary>
/// `AnimationEffect`'s iteration duration.
/// </summary>
[JsonPropertyName("duration")]public double Duration{get;set;}
/// <summary>
/// `AnimationEffect`'s playback direction.
/// </summary>
[JsonPropertyName("direction")]public string Direction{get;set;}
/// <summary>
/// `AnimationEffect`'s fill mode.
/// </summary>
[JsonPropertyName("fill")]public string Fill{get;set;}
/// <summary>
/// `AnimationEffect`'s target node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// `AnimationEffect`'s keyframes.
/// </summary>
[JsonPropertyName("keyframesRule")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public KeyframesRule? KeyframesRule{get;set;}
/// <summary>
/// `AnimationEffect`'s timing function.
/// </summary>
[JsonPropertyName("easing")]public string Easing{get;set;}
}
