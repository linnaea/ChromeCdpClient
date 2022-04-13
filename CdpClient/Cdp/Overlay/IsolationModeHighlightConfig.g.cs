using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
public sealed partial class IsolationModeHighlightConfig {
/// <summary>
/// The fill color of the resizers (default: transparent).
/// </summary>
[JsonPropertyName("resizerColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ResizerColor{get;set;}
/// <summary>
/// The fill color for resizer handles (default: transparent).
/// </summary>
[JsonPropertyName("resizerHandleColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ResizerHandleColor{get;set;}
/// <summary>
/// The fill color for the mask covering non-isolated elements (default: transparent).
/// </summary>
[JsonPropertyName("maskColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? MaskColor{get;set;}
}
