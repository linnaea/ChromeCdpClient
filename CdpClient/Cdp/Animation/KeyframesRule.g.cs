using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Animation;
/// <summary>
/// Keyframes Rule
/// </summary>
public sealed partial class KeyframesRule {
/// <summary>
/// CSS keyframed animation's name.
/// </summary>
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Name{get;set;}
/// <summary>
/// List of animation keyframes.
/// </summary>
[JsonPropertyName("keyframes")]public KeyframeStyle[] Keyframes{get;set;}
}
