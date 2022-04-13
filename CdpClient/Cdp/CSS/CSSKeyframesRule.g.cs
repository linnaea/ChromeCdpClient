using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS keyframes rule representation.
/// </summary>
public sealed partial class CSSKeyframesRule {
/// <summary>
/// Animation name.
/// </summary>
[JsonPropertyName("animationName")]public Value AnimationName{get;set;}
/// <summary>
/// List of keyframes.
/// </summary>
[JsonPropertyName("keyframes")]public CSSKeyframeRule[] Keyframes{get;set;}
}
