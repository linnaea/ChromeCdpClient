using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configuration for dual screen hinge
/// </summary>
public sealed partial class HingeConfig {
/// <summary>
/// A rectangle represent hinge
/// </summary>
[JsonPropertyName("rect")]public DOM.Rect Rect{get;set;}
/// <summary>
/// The content box highlight fill color (default: a dark color).
/// </summary>
[JsonPropertyName("contentColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ContentColor{get;set;}
/// <summary>
/// The content box highlight outline color (default: transparent).
/// </summary>
[JsonPropertyName("outlineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? OutlineColor{get;set;}
}
