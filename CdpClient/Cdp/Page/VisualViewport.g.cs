using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Visual viewport position, dimensions, and scale.
/// </summary>
public sealed partial class VisualViewport {
/// <summary>
/// Horizontal offset relative to the layout viewport (CSS pixels).
/// </summary>
[JsonPropertyName("offsetX")]public double OffsetX{get;set;}
/// <summary>
/// Vertical offset relative to the layout viewport (CSS pixels).
/// </summary>
[JsonPropertyName("offsetY")]public double OffsetY{get;set;}
/// <summary>
/// Horizontal offset relative to the document (CSS pixels).
/// </summary>
[JsonPropertyName("pageX")]public double PageX{get;set;}
/// <summary>
/// Vertical offset relative to the document (CSS pixels).
/// </summary>
[JsonPropertyName("pageY")]public double PageY{get;set;}
/// <summary>
/// Width (CSS pixels), excludes scrollbar if present.
/// </summary>
[JsonPropertyName("clientWidth")]public double ClientWidth{get;set;}
/// <summary>
/// Height (CSS pixels), excludes scrollbar if present.
/// </summary>
[JsonPropertyName("clientHeight")]public double ClientHeight{get;set;}
/// <summary>
/// Scale relative to the ideal viewport (size at width=device-width).
/// </summary>
[JsonPropertyName("scale")]public double Scale{get;set;}
/// <summary>
/// Page zoom factor (CSS to device independent pixels ratio).
/// </summary>
[JsonPropertyName("zoom")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Zoom{get;set;}
}
