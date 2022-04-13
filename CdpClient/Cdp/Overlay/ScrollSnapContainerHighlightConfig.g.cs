using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
public sealed partial class ScrollSnapContainerHighlightConfig {
/// <summary>
/// The style of the snapport border (default: transparent)
/// </summary>
[JsonPropertyName("snapportBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? SnapportBorder{get;set;}
/// <summary>
/// The style of the snap area border (default: transparent)
/// </summary>
[JsonPropertyName("snapAreaBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? SnapAreaBorder{get;set;}
/// <summary>
/// The margin highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("scrollMarginColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ScrollMarginColor{get;set;}
/// <summary>
/// The padding highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("scrollPaddingColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ScrollPaddingColor{get;set;}
}
