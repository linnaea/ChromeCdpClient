using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Animation;
/// <summary>
/// Keyframe Style
/// </summary>
public sealed partial class KeyframeStyle {
/// <summary>
/// Keyframe's time offset.
/// </summary>
[JsonPropertyName("offset")]public string Offset{get;set;}
/// <summary>
/// `AnimationEffect`'s timing function.
/// </summary>
[JsonPropertyName("easing")]public string Easing{get;set;}
}
